﻿using System;

namespace ET.Client
{
    [FriendOf(typeof (FUIEventComponent))]
    [EntitySystemOf(typeof (FUIEventComponent))]
    public static partial class FUIEventComponentSystem
    {
        [EntitySystem]
        private static void Awake(this FUIEventComponent self)
        {
            FUIEventComponent.Instance = self;
            self.UIEventHandlers.Clear();
            foreach (Type v in EventSystem.Instance.GetTypes(typeof (FUIEventAttribute)))
            {
                FUIEventAttribute attr = v.GetCustomAttributes(typeof (FUIEventAttribute), false)[0] as FUIEventAttribute;
                self.UIEventHandlers.Add(attr.PanelId, Activator.CreateInstance(v) as IFUIEventHandler);
                self.PanelIdInfoDict.Add(attr.PanelId, attr.PanelInfo);
                self.PanelTypeInfoDict.Add(attr.PanelId.ToString(), attr.PanelInfo);
            }
        }

        [EntitySystem]
        private static void Destroy(this FUIEventComponent self)
        {
            self.UIEventHandlers.Clear();
            self.PanelIdInfoDict.Clear();
            self.PanelTypeInfoDict.Clear();
            self.isClicked = false;
            FUIEventComponent.Instance = null;
        }

        public static IFUIEventHandler GetUIEventHandler(this FUIEventComponent self, PanelId panelId)
        {
            if (self.UIEventHandlers.TryGetValue(panelId, out IFUIEventHandler handler))
            {
                return handler;
            }

            Log.Error($"panelId : {panelId} is not have any uiEvent");
            return null;
        }

        public static PanelInfo GetPanelInfo(this FUIEventComponent self, PanelId panelId)
        {
            if (self.PanelIdInfoDict.TryGetValue(panelId, out PanelInfo panelInfo))
            {
                return panelInfo;
            }

            Log.Error($"panelId : {panelId} is not have any panelInfo");
            return default;
        }
    }
}