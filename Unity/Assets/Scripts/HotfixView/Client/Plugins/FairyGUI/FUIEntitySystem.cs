using FairyGUI;

namespace ET.Client
{
    [EntitySystemOf(typeof (FUIEntity))]
    public static partial class FUIEntitySystem
    {
        [EntitySystem]
        private static void Awake(this FUIEntity self)
        {
        }

        [EntitySystem]
        private static void Awake(this FUIEntity self, ShowPanelData data)
        {
            self.AddComponent(data);
        }

        public static void SetRoot(this FUIEntity self, GComponent rootGComponent)
        {
            if (self.GComponent == null)
            {
                Log.Error($"FUIEntity {self.PanelId} GComponent is null!!!");
                return;
            }

            if (rootGComponent == null)
            {
                Log.Error($"FUIEntity {self.PanelId} rootGComponent is null!!!");
                return;
            }

            rootGComponent.AddChild(self.GComponent);
        }
    }
}