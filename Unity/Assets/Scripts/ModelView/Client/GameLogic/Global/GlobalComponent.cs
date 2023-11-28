﻿using FairyGUI;
using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(Scene))]
    public class GlobalComponent: Entity, IAwake
    {
        [StaticField]
        public static GlobalComponent Instance;
        
        public Transform Global { get; set; }
        
        public Transform CameraRoot{ get; set; }
        public Transform Unit { get; set; }
        
        public GComponent GRoot{ get; set; }
        
        public GComponent BottomGRoot{ get; set; }
        public GComponent NormalGRoot{ get; set; }
        
        public GComponent SecondGRoot{ get; set; }
        public GComponent PopUpGRoot{ get; set; }
        public GComponent FixedGRoot{ get; set; }
        public GComponent OtherGRoot{ get; set; }
        
        public GlobalConfig GlobalConfig { get; set; }
    }
}