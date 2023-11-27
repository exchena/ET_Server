using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using YooAsset;

namespace ET.Client
{
    [FriendOf(typeof (ResComponent))]
    public static partial class ResComponentSystem
    {
        public static AssetRef GetAssetRef(this ResComponent self, string location)
        {
            self.AssetsOperationHandles.TryGetValue(location, out var assetRef);
            return assetRef;
        }

        #region 卸载

        public static void UnloadUnusedAssets(this ResComponent self)
        {
            YooAssets.GetPackage(self.PackageName).UnloadUnusedAssets();
        }

        public static void ForceUnloadAllAssets(this ResComponent self)
        {
            YooAssets.GetPackage(self.PackageName).ForceUnloadAllAssets();
            self.ClearHandles();
        }

        /// <summary>
        /// 清理已经 句柄无效的所有资源 (在逻辑层已经释放干净了)
        /// </summary>
        /// <param name="self"></param>
        private static void ClearHandles(this ResComponent self)
        {
            HashSet<string> removeKeys = new();
            foreach (var dic in self.AssetsOperationHandles)
            {
                if (dic.Value.AssetHandle == null || !dic.Value.AssetHandle.IsValid)
                {
                    removeKeys.Add(dic.Key);
                }
            }

            foreach (var key in removeKeys)
            {
                self.AssetsOperationHandles.Remove(key);
            }
        }

        public static void UnloadAsset(this ResComponent self, string location)
        {
#if UNITY_EDITOR
            if (!UnityEditor.EditorApplication.isPlayingOrWillChangePlaymode)
                return;
#endif
            self.AssetsOperationHandles.TryGetValue(location, out AssetRef assetRef);

            if (assetRef == null || assetRef.AssetHandle == null)
            {
                Log.Error("资源回收异常!请检查是否重复回收了该资源, AssestName:" + location);
                return;
            }

            if (--assetRef.UseCount == 0)
            {
                assetRef.AssetHandle.Release();

                //每卸载10个资源，则统一移除一次未引用的资源
                if (++self.UnloadUnUseAssetNum % 10 == 9)
                {
                    self.UnloadUnusedAssets();
                }

                self.AssetsOperationHandles.Remove(location);
                assetRef.Dispose();
            }
        }

        #endregion

        #region 异步加载

        public static async ETTask<T> LoadAssetAsync<T>(this ResComponent self, string location) where T : UnityEngine.Object
        {
            if (!self.AssetsOperationHandles.TryGetValue(location, out var assetRef))
            {
                assetRef = self.AddChild<AssetRef>();
                assetRef.AssetHandle = YooAssets.LoadAssetAsync<T>(location);
                self.AssetsOperationHandles[location] = assetRef;
            }

            assetRef.UseCount++;
            await assetRef.AssetHandle;

            return assetRef.AssetHandle.GetAssetObject<T>();
        }

        public static async ETTask<UnityEngine.Object> LoadAssetAsync(this ResComponent self, string location, Type type)
        {
            if (!self.AssetsOperationHandles.TryGetValue(location, out var assetRef))
            {
                assetRef = self.AddChild<AssetRef>();
                assetRef.AssetHandle = YooAssets.LoadAssetAsync(location, type);
                self.AssetsOperationHandles[location] = assetRef;
            }

            assetRef.UseCount++;
            await assetRef.AssetHandle;

            return assetRef.AssetHandle.AssetObject;
        }

        public static async ETTask<UnityEngine.SceneManagement.Scene> LoadSceneAsync(this ResComponent self, string location,
        Action<float> progressCallback = null, LoadSceneMode loadSceneMode = LoadSceneMode.Single, bool activateOnLoad = true, int priority = 100)
        {
            if (!self.SceneOperationHandles.TryGetValue(location, out SceneOperationHandle handle) || handle == null)
            {
                handle = YooAssets.LoadSceneAsync(location, loadSceneMode, activateOnLoad, priority);
                self.SceneOperationHandles[location] = handle;
            }

            if (progressCallback != null)
            {
                self.HandleProgresses.Add(handle, progressCallback);
            }

            await handle;

            return handle.SceneObject;
        }

        public static async ETTask UnLoadSceneAsync(this ResComponent self, string location)
        {
            if (self.SceneOperationHandles.TryGetValue(location, out SceneOperationHandle handle) && handle != null)
            {
                if (!handle.IsDone)
                {
                    await handle;
                }

                if (handle.IsMainScene())
                {
                    SceneManager.SetActiveScene(SceneManager.GetSceneByName("Init"));
                }

                await SceneManager.UnloadSceneAsync(handle.SceneObject);

                await handle.UnloadAsync();

                self.SceneOperationHandles.Remove(location);
            }
        }

        /// <summary>
        /// 异步加载原始资源
        /// </summary>
        /// <param name="self"></param>
        /// <param name="location"></param>
        /// <returns></returns>
        public static async ETTask<byte[]> LoadRawFileDataAsync(this ResComponent self, string location)
        {
            if (!self.AssetsOperationHandles.TryGetValue(location, out var assetRef))
            {
                assetRef = self.AddChild<AssetRef>();
                assetRef.AssetHandle = (YooAssets.LoadAssetAsync<TextAsset>(location));
                self.AssetsOperationHandles[location] = assetRef;
            }

            assetRef.UseCount++;
            await assetRef.AssetHandle;

            return assetRef.AssetHandle.GetAssetObject<TextAsset>().bytes;
        }

        /// <summary>
        /// 同步加载原始资源
        /// </summary>
        /// <param name="self"></param>
        /// <param name="location"></param>
        /// <returns></returns>
        public static byte[] LoadRawFileDataSync(this ResComponent self, string location)
        {
            if (!self.AssetsOperationHandles.TryGetValue(location, out var assetRef))
            {
                assetRef = self.AddChild<AssetRef>();
                assetRef.AssetHandle = (YooAssets.LoadAssetSync<TextAsset>(location));
                self.AssetsOperationHandles[location] = assetRef;
            }

            assetRef.UseCount++;

            return assetRef.AssetHandle.GetAssetObject<TextAsset>().bytes;
        }

        public static async ETTask<string> LoadRawFileTextAsync(this ResComponent self, string location)
        {
            if (!self.AssetsOperationHandles.TryGetValue(location, out var assetRef))
            {
                assetRef = self.AddChild<AssetRef>();
                assetRef.AssetHandle = (YooAssets.LoadAssetAsync<TextAsset>(location));
                self.AssetsOperationHandles[location] = assetRef;
            }

            assetRef.UseCount++;
            await assetRef.AssetHandle;

            return assetRef.AssetHandle.GetAssetObject<TextAsset>().text;
        }

        #endregion

        #region 同步加载

        public static T LoadAsset<T>(this ResComponent self, string location) where T : UnityEngine.Object
        {
            if (!self.AssetsOperationHandles.TryGetValue(location, out var assetRef))
            {
                assetRef = self.AddChild<AssetRef>();
                assetRef.AssetHandle = YooAssets.LoadAssetSync<T>(location);
                self.AssetsOperationHandles[location] = assetRef;
            }

            assetRef.UseCount++;

            return assetRef.AssetHandle.AssetObject as T;
        }

        public static UnityEngine.Object LoadAsset(this ResComponent self, string location, Type type)
        {
            if (!self.AssetsOperationHandles.TryGetValue(location, out var assetRef))
            {
                assetRef = self.AddChild<AssetRef>();
                assetRef.AssetHandle = YooAssets.LoadAssetSync(location, type);
                self.AssetsOperationHandles[location] = assetRef;
            }

            assetRef.UseCount++;

            return assetRef.AssetHandle.AssetObject;
        }

        #endregion
    }
}