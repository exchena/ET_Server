//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Bright.Serialization;
using System.Collections.Generic;


namespace ET
{

public sealed partial class config_Mail: Bright.Config.BeanBase
{
    public config_Mail(ByteBuf _buf) 
    {
        Id = _buf.ReadInt();
        {int n0 = System.Math.Min(_buf.ReadSize(), _buf.Size);Itemid = new System.Collections.Generic.List<int>(n0);for(var i0 = 0 ; i0 < n0 ; i0++) { int _e0;  _e0 = _buf.ReadInt(); Itemid.Add(_e0);}}
        {int n0 = System.Math.Min(_buf.ReadSize(), _buf.Size);Count = new System.Collections.Generic.List<int>(n0);for(var i0 = 0 ; i0 < n0 ; i0++) { int _e0;  _e0 = _buf.ReadInt(); Count.Add(_e0);}}
        PostInit();
    }

    public static config_Mail Deserializeconfig_Mail(ByteBuf _buf)
    {
        return new config_Mail(_buf);
    }

    /// <summary>
    /// Id
    /// </summary>
    public int Id { get; private set; }
    /// <summary>
    /// 道具ID
    /// </summary>
    public System.Collections.Generic.List<int> Itemid { get; private set; }
    /// <summary>
    /// 道具数量
    /// </summary>
    public System.Collections.Generic.List<int> Count { get; private set; }

    public const int __ID__ = 16345268;
    public override int GetTypeId() => __ID__;

    public  void Resolve(Dictionary<string, IConfigSingleton> _tables)
    {
        PostResolve();
    }

    public  void TranslateText(System.Func<string, string, string> translator)
    {
    }

    public override string ToString()
    {
        return "{ "
        + "Id:" + Id + ","
        + "Itemid:" + Bright.Common.StringUtil.CollectionToString(Itemid) + ","
        + "Count:" + Bright.Common.StringUtil.CollectionToString(Count) + ","
        + "}";
    }
    
    partial void PostInit();
    partial void PostResolve();
}
}