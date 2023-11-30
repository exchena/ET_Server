using UnityEngine;

namespace ET.Client
{
    [ComponentOf]
    public class UIGameObjectComponent: Entity, IAwake, IAwake<string>, IDestroy
    {
        private GameObject gameObject;

        public GameObject GameObject
        {
            get
            {
                return this.gameObject;
            }
            set
            {
                this.gameObject = value;
                this.Transform = value.transform;
            }
        }
        
        /// <summary>
        /// 该Gameobject 所对应的资源名 方便销毁时, 自动卸载资源
        /// </summary>
        public string AssetLocationName { get; set; }

        public Transform Transform { get; private set; }
    }
}