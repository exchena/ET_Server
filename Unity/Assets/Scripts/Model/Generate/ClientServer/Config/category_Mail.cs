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
public partial class category_Mail: ConfigSingleton<category_Mail>
{
    private readonly Dictionary<int, config_Mail> _dataMap;
    private readonly List<config_Mail> _dataList;
    
    public category_Mail(ByteBuf _buf)
    {
        _dataMap = new Dictionary<int, config_Mail>();
        _dataList = new List<config_Mail>();
        
        for(int n = _buf.ReadSize() ; n > 0 ; --n)
        {
            config_Mail _v;
            _v = config_Mail.Deserializeconfig_Mail(_buf);
            _dataList.Add(_v);
            _dataMap.Add(_v.Id, _v);
        }
        PostInit();
    }
    
    public category_Mail()
    {
        throw new System.NotImplementedException();
    }

    public Dictionary<int, config_Mail> GetAll()
    {
        return _dataMap;
    }
    
    public List<config_Mail> DataList => _dataList;

    public config_Mail GetOrDefault(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public config_Mail Get(int key) => _dataMap[key];
    public config_Mail this[int key] => _dataMap[key];

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