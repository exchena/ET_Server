using FairyGUI;
using UnityEngine;

namespace ET.Client
{
    [EnableMethod]
    [ChildOf(typeof(FUIComponent))]
    public class FUIEntity : Entity, IAwake, IAwake<ShowPanelData>
    {
        public bool IsPreLoad
        {
            get
            {
                return this.GComponent != null;
            }
        }
        
        public PanelId PanelId
        {
            get
            {
                if (this.panelId == PanelId.Invalid)
                {
                    Log.Error("window id is " + PanelId.Invalid);
                }
                return this.panelId;
            }
            set { this.panelId = value; }
        }
      
        private PanelId panelId = PanelId.Invalid;
        
        public UIPanelType panelType = UIPanelType.Normal;

        public GComponent GComponent { get; set; }
    }
}