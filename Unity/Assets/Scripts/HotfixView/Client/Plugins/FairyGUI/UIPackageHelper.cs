﻿using System;
using System.Collections.Generic;
using FairyGUI;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(FUIComponent))]
    public static partial class UIPackageHelper
    {
        public static async ETTask<GComponent> CreateObjectAsync(string packageName, string componentName)
        {
            ETTask<GComponent> task = ETTask<GComponent>.Create(true);
            UIPackage.CreateObjectAsync(packageName, componentName, result =>
            {
                task.SetResult(result.asCom);
            });
            return await task;
        }

        /// <summary>
        /// 增加 FariyGUI 的 Package
        /// </summary>
        /// <param name="self"></param>
        /// <param name="packageName"></param>
        public static async ETTask AddPackageAsync(this FUIComponent self, string packageName)
        {
            string dataName = $"{packageName}_fui";
            byte[] descData = await ResComponent.Instance.LoadRawFileDataAsync(dataName);
            UIPackage.AddPackage(descData, packageName, (name, extension, type, item) =>
            {
                self.InnerLoader(name, extension, type, item).Coroutine();
            });
            self.UIPackageLocations.Add(packageName, dataName);
        }

        private static async ETTask InnerLoader(this FUIComponent self, string location, string extension, Type type, PackageItem item)
        {
            UnityEngine.Object res = await ResComponent.Instance.LoadAssetAsync("{0}".Fmt(location), type);
            item.owner.SetItemAsset(item, res, DestroyMethod.None);

            string packageName = item.owner.name;
            self.UIPackageLocations.Add(packageName, location);
        }

        /// <summary>
        /// 移除 FariyGUI 的 Package
        /// </summary>
        /// <param name="self"></param>
        /// <param name="packageName"></param>
        public static void RemovePackage(this FUIComponent self, string packageName)
        {
            UIPackage.RemovePackage(packageName);

            List<string> list = self.UIPackageLocations[packageName];
            foreach (string location in list)
            {
                ResComponent.Instance.UnloadAsset(location);
            }

            self.UIPackageLocations.Remove(packageName);
        }
    }
}