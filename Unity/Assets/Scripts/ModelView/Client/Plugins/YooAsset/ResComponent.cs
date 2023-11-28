using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using YooAsset;

namespace ET.Client
{
    [ComponentOf(typeof(Scene))]
    public class ResComponent: Entity, IAwake, IDestroy, IUpdate
    {
        [StaticField]
        public static ResComponent Instance { get; set; }

        /// <summary>
        /// 默认的资源包名
        /// </summary>
        public string PackageName;

        /// <summary>
        /// 运行模式
        /// </summary>
        public EPlayMode PlayMode { private set; get; }

        /// <summary>
        /// 包裹的版本信息
        /// </summary>
        public string PackageVersion { set; get; }

        /// <summary>
        /// 下载器
        /// </summary>
        public ResourceDownloaderOperation Downloader { set; get; }
        
        public Dictionary<string, AssetRef> AssetsOperationHandles = new Dictionary<string, AssetRef>(100);

        public Dictionary<string, SubAssetsOperationHandle> SubAssetsOperationHandles = new Dictionary<string, SubAssetsOperationHandle>();
        
        public Dictionary<string, SceneOperationHandle> SceneOperationHandles = new Dictionary<string, SceneOperationHandle>();
        
        public Dictionary<OperationHandleBase, Action<float>> HandleProgresses = new Dictionary<OperationHandleBase, Action<float>>();

        public Queue<OperationHandleBase> DoneHandleQueue = new Queue<OperationHandleBase>();

        public int UnloadUnUseAssetNum;
    }
}