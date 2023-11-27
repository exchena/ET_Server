using FairyGUI;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(GObjectPoolComponent))]
    [EntitySystemOf(typeof(GObjectPoolComponent))]
    public static partial class GObjectPoolComponentSystem
    {
        [EntitySystem]
        public static void Awake(this GObjectPoolComponent self, Transform poolParent)
        {
            self._gObjectPool = new GObjectPool(poolParent);
        }

        [EntitySystem]
        public static void Destroy(this GObjectPoolComponent self)
        {
            self._gObjectPool?.Clear();
            self._gObjectPool = null;
        }
    }
    
    [ComponentOf]
    [EnableMethod]
    public class GObjectPoolComponent: Entity, IAwake<Transform>, IDestroy
    {
        public GObjectPool _gObjectPool;

        public GObject GetObject(string url)
        {
            return _gObjectPool.GetObject(url);
        }
        
        public GObject GetObject(string url, GComponent gParent)
        {
            GObject obj = _gObjectPool.GetObject(url);
            gParent.AddChild(obj);
            return obj;
        }
        
        public void ReturnObject(GObject obj)
        {
            _gObjectPool.ReturnObject(obj);
        }
    }
}