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
public partial class category_RoleCreateParams: ConfigSingleton<category_RoleCreateParams>
{
    private readonly Dictionary<int, config_RoleCreateParams> _dataMap;
    private readonly List<config_RoleCreateParams> _dataList;
    
    public category_RoleCreateParams(ByteBuf _buf)
    {
        _dataMap = new Dictionary<int, config_RoleCreateParams>();
        _dataList = new List<config_RoleCreateParams>();
        
        for(int n = _buf.ReadSize() ; n > 0 ; --n)
        {
            config_RoleCreateParams _v;
            _v = config_RoleCreateParams.Deserializeconfig_RoleCreateParams(_buf);
            _dataList.Add(_v);
            _dataMap.Add(_v.Id, _v);
        }
        PostInit();
    }
    
    public category_RoleCreateParams()
    {
        throw new System.NotImplementedException();
    }

    public Dictionary<int, config_RoleCreateParams> GetAll()
    {
        return _dataMap;
    }
    
    public List<config_RoleCreateParams> DataList => _dataList;

    public config_RoleCreateParams GetOrDefault(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public config_RoleCreateParams Get(int key) => _dataMap[key];
    public config_RoleCreateParams this[int key] => _dataMap[key];

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