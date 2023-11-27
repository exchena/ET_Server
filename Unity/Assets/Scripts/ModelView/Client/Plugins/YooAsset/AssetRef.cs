using YooAsset;

namespace ET.Client
{
    [EntitySystemOf(typeof (AssetRef))]
    public static partial class AssetRefSystem
    {
        [EntitySystem]
        private static void Awake(this AssetRef self)
        {
        }

        [EntitySystem]
        private static void Destroy(this AssetRef self)
        {
            self.UseCount = 0;
            self.AssetHandle = null;
        }
    }

    [ChildOf(typeof (ResComponent))]
    [EnableMethod]
    public class AssetRef: Entity, IAwake, IDestroy
    {
#if UNITY_EDITOR
        public string AssetLocation;
        private AssetOperationHandle _handle;

        public AssetOperationHandle AssetHandle
        {
            get
            {
                return _handle;
            }
            set
            {
                this._handle = value;
                this.OnLoaded().Coroutine();
            }
        }

        private async ETTask OnLoaded()
        {
            if (this._handle == null) return;

            await this._handle;
            this.AssetLocation = this._handle.AssetObject.name;
        }
#else
        public AssetOperationHandle AssetHandle { get; set; }
#endif

        public int UseCount { get; set; }
    }
}