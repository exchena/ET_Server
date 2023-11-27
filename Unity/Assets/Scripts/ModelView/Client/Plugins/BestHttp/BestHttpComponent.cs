namespace ET.Client
{
    [EnableMethod]
    [ComponentOf(typeof(Scene))]
    public class BestHttpComponent : Entity, IAwake, IDestroy
    {
        public static BestHttpComponent Instance => Root.Instance.Scene.AddOrGetComponent<BestHttpComponent>();
    }
}