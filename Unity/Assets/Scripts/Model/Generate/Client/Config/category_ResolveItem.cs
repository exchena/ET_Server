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
public partial class category_ResolveItem: ConfigSingleton<category_ResolveItem>
{
    private readonly Dictionary<int, config_ResolveItem> _dataMap;
    private readonly List<config_ResolveItem> _dataList;
    
    public category_ResolveItem(ByteBuf _buf)
    {
        _dataMap = new Dictionary<int, config_ResolveItem>();
        _dataList = new List<config_ResolveItem>();
        
        for(int n = _buf.ReadSize() ; n > 0 ; --n)
        {
            config_ResolveItem _v;
            _v = config_ResolveItem.Deserializeconfig_ResolveItem(_buf);
            _dataList.Add(_v);
            _dataMap.Add(_v.Id, _v);
        }
        PostInit();
    }
    
    public category_ResolveItem()
    {
        throw new System.NotImplementedException();
    }

    public Dictionary<int, config_ResolveItem> GetAll()
    {
        return _dataMap;
    }
    
    public List<config_ResolveItem> DataList => _dataList;

    public config_ResolveItem GetOrDefault(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public config_ResolveItem Get(int key) => _dataMap[key];
    public config_ResolveItem this[int key] => _dataMap[key];

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