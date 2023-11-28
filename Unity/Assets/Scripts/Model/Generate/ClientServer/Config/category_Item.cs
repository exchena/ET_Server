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
   
[Config]
public partial class category_Item: ConfigSingleton<category_Item>
{
    private readonly Dictionary<int, config_Item> _dataMap;
    private readonly List<config_Item> _dataList;
    
    public category_Item(ByteBuf _buf)
    {
        _dataMap = new Dictionary<int, config_Item>();
        _dataList = new List<config_Item>();
        
        for(int n = _buf.ReadSize() ; n > 0 ; --n)
        {
            config_Item _v;
            _v = config_Item.Deserializeconfig_Item(_buf);
            _dataList.Add(_v);
            _dataMap.Add(_v.Id, _v);
        }
        PostInit();
    }
    
    public category_Item()
    {
        throw new System.NotImplementedException();
    }

    public Dictionary<int, config_Item> GetAll()
    {
        return _dataMap;
    }
    
    public List<config_Item> DataList => _dataList;

    public config_Item GetOrDefault(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public config_Item Get(int key) => _dataMap[key];
    public config_Item this[int key] => _dataMap[key];

    public override void Resolve(Dictionary<string, IConfigSingleton> _tables)
    {
        foreach(var v in _dataList)
        {
            v.Resolve(_tables);
        }
        PostResolve();
    }

    public override void TranslateText(System.Func<string, string, string> translator)
    {
        foreach(var v in _dataList)
        {
            v.TranslateText(translator);
        }
    }
    
    partial void PostInit();
    partial void PostResolve();
}
}