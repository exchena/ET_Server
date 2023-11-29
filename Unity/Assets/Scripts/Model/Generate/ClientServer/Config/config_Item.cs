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

public sealed partial class config_Item: Bright.Config.BeanBase
{
    public config_Item(ByteBuf _buf) 
    {
        Id = _buf.ReadInt();
        Type = _buf.ReadInt();
        Subtype = _buf.ReadInt();
        Name = _buf.ReadInt();
        Desc = _buf.ReadInt();
        {int n0 = System.Math.Min(_buf.ReadSize(), _buf.Size);GetDes = new System.Collections.Generic.List<int>(n0);for(var i0 = 0 ; i0 < n0 ; i0++) { int _e0;  _e0 = _buf.ReadInt(); GetDes.Add(_e0);}}
        IconRes = _buf.ReadString();
        StackCount = _buf.ReadInt();
        Duration = _buf.ReadInt();
        Quality = _buf.ReadInt();
        ParamInt = _buf.ReadInt();
        PostInit();
    }

    public static config_Item Deserializeconfig_Item(ByteBuf _buf)
    {
        return new config_Item(_buf);
    }

    /// <summary>
    /// Id
    /// </summary>
    public int Id { get; private set; }
    /// <summary>
    /// 主类型
    /// </summary>
    public int Type { get; private set; }
    /// <summary>
    /// 子类型
    /// </summary>
    public int Subtype { get; private set; }
    /// <summary>
    /// 名字
    /// </summary>
    public int Name { get; private set; }
    /// <summary>
    /// 描述
    /// </summary>
    public int Desc { get; private set; }
    /// <summary>
    /// 获取途径
    /// </summary>
    public System.Collections.Generic.List<int> GetDes { get; private set; }
    /// <summary>
    /// 图标资源
    /// </summary>
    public string IconRes { get; private set; }
    /// <summary>
    /// 堆叠数量
    /// </summary>
    public int StackCount { get; private set; }
    /// <summary>
    /// 有效时长(小时)
    /// </summary>
    public int Duration { get; private set; }
    /// <summary>
    /// 道具品质
    /// </summary>
    public int Quality { get; private set; }
    /// <summary>
    /// 附带参数
    /// </summary>
    public int ParamInt { get; private set; }

    public const int __ID__ = 16244240;
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
        + "Type:" + Type + ","
        + "Subtype:" + Subtype + ","
        + "Name:" + Name + ","
        + "Desc:" + Desc + ","
        + "GetDes:" + Bright.Common.StringUtil.CollectionToString(GetDes) + ","
        + "IconRes:" + IconRes + ","
        + "StackCount:" + StackCount + ","
        + "Duration:" + Duration + ","
        + "Quality:" + Quality + ","
        + "ParamInt:" + ParamInt + ","
        + "}";
    }
    
    partial void PostInit();
    partial void PostResolve();
}
}