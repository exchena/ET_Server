using FairyGUI;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof (FUIPrefabLoaderComponent))]
    [EntitySystemOf(typeof (FUIPrefabLoaderComponent))]
    public static partial class FUIPrefabLoaderComponentSystem
    {
        [EntitySystem]
        private static void Awake(this FUIPrefabLoaderComponent self)
        {
        }

        [EntitySystem]
        private static void Awake(this FUIPrefabLoaderComponent self, GGraph graph, string locationName)
        {
            self.ShowPrefab(graph, locationName).Coroutine();
        }

        public static async ETTask ShowPrefab(this FUIPrefabLoaderComponent self, GGraph graph, string locationName)
        {
            graph.visible = false;
            self.AssetLocationName = locationName;
            var objComponent = self.AddComponent<UIGameObjectComponent>();

            await objComponent.LoadPrefabAsync(locationName);
            self.ShowPrefab(graph, objComponent.GameObject);

            //设置默认大小
            self.SetPosAndRot(new Vector3(200, 200, 1000), Quaternion.Euler(new Vector3(0f, 150f, 0f)), new Vector3(400, 400, 400));
            graph.visible = true;
        }

        public static void ShowPrefab(this FUIPrefabLoaderComponent self, GGraph graph, GameObject prefab)
        {
            self.Graph = graph;

            //关于Wrapper的使用, 详见 https://fairygui.com/docs/unity/insert3d
            if (self.Wrapper == null)
            {
                self.Wrapper = new GoWrapper(prefab);
            }
            else
            {
                self.Wrapper.wrapTarget = prefab;
            }

            self.Graph.SetNativeObject(self.Wrapper);
        }

        public static void SetPosAndRot(this FUIPrefabLoaderComponent self, Vector3 pos, Quaternion rot, Vector3 scale)
        {
            Transform trans = self.GetComponent<UIGameObjectComponent>().GameObject.transform;

            trans.localPosition = pos;
            trans.localScale = scale;
            trans.localRotation = rot;

            self.Refresh();
        }

        public static void SetRot(this FUIPrefabLoaderComponent self, Quaternion rot)
        {
            Transform trans = self.GetComponent<UIGameObjectComponent>().GameObject.transform;

            trans.localRotation = rot;
            self.Refresh();
        }

        public static void AddRot(this FUIPrefabLoaderComponent self, Quaternion rot)
        {
            Transform trans = self.GetComponent<UIGameObjectComponent>().GameObject.transform;

            trans.localRotation = new Quaternion(trans.localRotation.x + rot.x, trans.localRotation.y + rot.y, trans.localRotation.w + rot.w,
                trans.localRotation.z + rot.z);
            self.Refresh();
        }

        /// <summary>
        /// 刷新显示的prefab
        /// </summary>
        /// <param name="self"></param>
        public static void Refresh(this FUIPrefabLoaderComponent self)
        {
            self.Wrapper.CacheRenderers();
        }

        [EntitySystem]
        private static void Destroy(this FUIPrefabLoaderComponent self)
        {
            self.Wrapper?.Dispose();
            self.Wrapper = null;
            self.AssetLocationName = string.Empty;
        }
    }
}