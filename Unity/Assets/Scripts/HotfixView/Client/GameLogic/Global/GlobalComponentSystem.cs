using FairyGUI;
using UnityEngine;

namespace ET.Client
{
    [EntitySystemOf(typeof (GlobalComponent))]
    public static partial class GlobalComponentAwakeSystem
    {
        [EntitySystem]
        private static void Awake(this GlobalComponent self)
        {
            GlobalComponent.Instance = self;

            self.Global = GameObject.Find("/Global").transform;
            self.Unit = GameObject.Find("/Global/Unit").transform;
            self.CameraRoot = GameObject.Find("/Global/CameraRoot").transform;

            self.GRoot = GRoot.inst;

            self.BottomGRoot = new GComponent();
            self.BottomGRoot.gameObjectName = "BottomGRoot";
            GRoot.inst.AddChild(self.BottomGRoot);

            self.NormalGRoot = new GComponent();
            self.NormalGRoot.gameObjectName = "NormalGRoot";
            GRoot.inst.AddChild(self.NormalGRoot);

            self.SecondGRoot = new GComponent();
            self.SecondGRoot.gameObjectName = "SecondGRoot";
            GRoot.inst.AddChild(self.SecondGRoot);

            self.PopUpGRoot = new GComponent();
            self.PopUpGRoot.gameObjectName = "PopUpGRoot";
            GRoot.inst.AddChild(self.PopUpGRoot);

            self.FixedGRoot = new GComponent();
            self.FixedGRoot.gameObjectName = "FixedGRoot";
            GRoot.inst.AddChild(self.FixedGRoot);

            self.OtherGRoot = new GComponent();
            self.OtherGRoot.gameObjectName = "OtherGRoot";
            GRoot.inst.AddChild(self.OtherGRoot);
        }
    }
}