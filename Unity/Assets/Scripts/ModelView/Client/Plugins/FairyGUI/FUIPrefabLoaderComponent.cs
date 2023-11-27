using System;
using System.Collections.Generic;
using System.Linq;
using FairyGUI;

namespace ET.Client
{
    //FUI 3DLoader显示模型/预制的管理组件
    [ComponentOf]
    public class FUIPrefabLoaderComponent: Entity, IAwake, IAwake<GGraph, string>, IDestroy
    {
        public string AssetLocationName;
        public GoWrapper Wrapper;
        public GGraph Graph;
    }
}