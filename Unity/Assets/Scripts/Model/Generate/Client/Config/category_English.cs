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
public partial class category_English: ConfigSingleton<category_English>
{
    private readonly Dictionary<int, config_English> _dataMap;
    private readonly List<config_English> _dataList;
    
    public category_English(ByteBuf _buf)
    {
        _dataMap = new Dictionary<int, config_English>();
        _dataList = new List<config_English>();
        
        for(int n = _buf.ReadSize() ; n > 0 ; --n)
        {
            config_English _v;
            _v = config_English.Deserializeconfig_English(_buf);
            _dataList.Add(_v);
            _dataMap.Add(_v.Id, _v);
        }
        PostInit();
    }
    
    public category_English()
    {
        throw new System.NotImplementedException();
    }

    public Dictionary<int, config_English> GetAll()
    {
        return _dataMap;
    }
    
    public List<config_English> DataList => _dataList;

    public config_English GetOrDefault(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public config_English Get(int key) => _dataMap[key];
    public config_English this[int key] => _dataMap[key];

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