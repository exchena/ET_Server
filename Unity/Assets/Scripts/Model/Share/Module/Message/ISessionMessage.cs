using System.Collections.Generic;

namespace ET
{

    public interface ISessionMessage: IMessage
    {
    }
    
    public interface ISessionRequest: ISessionMessage, IRequest
    {
    }
    
    public interface ISessionResponse: ISessionMessage, IResponse
    {

    }
    
    /// <summary>
    /// 广播消息类型 （推送相同的消息给多个Player的客户端）
    /// </summary>
    public interface IBroadCast: ISessionMessage
    {
        List<long> ListId
        {
            get;
            set;
        }
        
        byte[] Message
        {
            get;
            set;
        }
        
        int Opcode
        {
            get;
            set;
        }
    }
}