﻿using System;
using UnityEngine;

namespace ET.Client
{
    [EntitySystemOf(typeof(UIGameObjectComponent))]
    public static partial class UIGameObjectComponentSystem
    {
        [EntitySystem]
        private static void Destroy(this UIGameObjectComponent self)
        {
            UnityEngine.Object.Destroy(self.GameObject);
        }
        
        [EntitySystem]
        private static void Awake(this UIGameObjectComponent self)
        {

        }
        
        [EntitySystem]
        private static void Awake(this UIGameObjectComponent self, string location)
        {
            self.LoadPrefabAsync(location).Coroutine();
        }
        
        /// <summary>
        /// 加载预制资源
        /// </summary>
        /// <param name="self"></param>
        /// <param name="assetName"></param>
        public static async ETTask<GameObject> LoadPrefabAsync(this UIGameObjectComponent self, string assetName, Transform parent = null)
        {
            GameObject obj = await ResourcesComponent.Instance.LoadAssetAsync<GameObject>(assetName);

            if (parent == null)
            {
                self.GameObject = GameObject.Instantiate(obj);
            }
            else
            {
                self.GameObject = GameObject.Instantiate(obj, parent);
            }

            self.AssetLocationName = assetName; //记录资源名, 方便自动回收
            return self.GameObject;
        }
    }
}