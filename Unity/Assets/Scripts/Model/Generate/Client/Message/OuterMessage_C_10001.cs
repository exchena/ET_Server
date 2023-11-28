using ET;
using MemoryPack;
using System.Collections.Generic;
namespace ET
{
	[Message(OuterMessage.HttpGetRouterResponse)]
	[MemoryPackable]
	public partial class HttpGetRouterResponse: MessageObject
	{
		public static HttpGetRouterResponse Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(HttpGetRouterResponse), isFromPool) as HttpGetRouterResponse; 
		}

		[MemoryPackOrder(0)]
		public List<string> Realms { get; set; } = new();

		[MemoryPackOrder(1)]
		public List<string> Routers { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.Realms.Clear();
			this.Routers.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.RouterSync)]
	[MemoryPackable]
	public partial class RouterSync: MessageObject
	{
		public static RouterSync Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(RouterSync), isFromPool) as RouterSync; 
		}

		[MemoryPackOrder(0)]
		public uint ConnectId { get; set; }

		[MemoryPackOrder(1)]
		public string Address { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.ConnectId = default;
			this.Address = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_TestResponse))]
	[Message(OuterMessage.C2M_TestRequest)]
	[MemoryPackable]
	public partial class C2M_TestRequest: MessageObject, IActorLocationRequest
	{
		public static C2M_TestRequest Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_TestRequest), isFromPool) as C2M_TestRequest; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public string request { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.request = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_TestResponse)]
	[MemoryPackable]
	public partial class M2C_TestResponse: MessageObject, IActorResponse
	{
		public static M2C_TestResponse Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_TestResponse), isFromPool) as M2C_TestResponse; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int Error { get; set; }

		[MemoryPackOrder(2)]
		public string Message { get; set; }

		[MemoryPackOrder(3)]
		public string response { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.response = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(Actor_TransferResponse))]
	[Message(OuterMessage.Actor_TransferRequest)]
	[MemoryPackable]
	public partial class Actor_TransferRequest: MessageObject, IActorLocationRequest
	{
		public static Actor_TransferRequest Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(Actor_TransferRequest), isFromPool) as Actor_TransferRequest; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int MapIndex { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.MapIndex = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.Actor_TransferResponse)]
	[MemoryPackable]
	public partial class Actor_TransferResponse: MessageObject, IActorLocationResponse
	{
		public static Actor_TransferResponse Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(Actor_TransferResponse), isFromPool) as Actor_TransferResponse; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int Error { get; set; }

		[MemoryPackOrder(2)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(G2C_EnterMap))]
	[Message(OuterMessage.C2G_EnterMap)]
	[MemoryPackable]
	public partial class C2G_EnterMap: MessageObject, IRequest
	{
		public static C2G_EnterMap Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2G_EnterMap), isFromPool) as C2G_EnterMap; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int StageId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.StageId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.G2C_EnterMap)]
	[MemoryPackable]
	public partial class G2C_EnterMap: MessageObject, IResponse
	{
		public static G2C_EnterMap Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(G2C_EnterMap), isFromPool) as G2C_EnterMap; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int Error { get; set; }

		[MemoryPackOrder(2)]
		public string Message { get; set; }

// 自己unitId
		[MemoryPackOrder(3)]
		public long MyId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.MyId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.MoveInfo)]
	[MemoryPackable]
	public partial class MoveInfo: MessageObject
	{
		public static MoveInfo Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(MoveInfo), isFromPool) as MoveInfo; 
		}

		[MemoryPackOrder(0)]
		public List<Unity.Mathematics.float3> Points { get; set; } = new();

		[MemoryPackOrder(1)]
		public Unity.Mathematics.quaternion Rotation { get; set; }

		[MemoryPackOrder(2)]
		public int TurnSpeed { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.Points.Clear();
			this.Rotation = default;
			this.TurnSpeed = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.UnitInfo)]
	[MemoryPackable]
	public partial class UnitInfo: MessageObject
	{
		public static UnitInfo Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(UnitInfo), isFromPool) as UnitInfo; 
		}

		[MemoryPackOrder(0)]
		public long UnitId { get; set; }

		[MemoryPackOrder(1)]
		public int ConfigId { get; set; }

		[MemoryPackOrder(2)]
		public int Type { get; set; }

		[MemoryPackOrder(3)]
		public Unity.Mathematics.float3 Position { get; set; }

		[MemoryPackOrder(4)]
		public Unity.Mathematics.float3 Forward { get; set; }

		[MongoDB.Bson.Serialization.Attributes.BsonDictionaryOptions(MongoDB.Bson.Serialization.Options.DictionaryRepresentation.ArrayOfArrays)]
		[MemoryPackOrder(5)]
		public Dictionary<int, long> KV { get; set; } = new();
		[MemoryPackOrder(6)]
		public MoveInfo MoveInfo { get; set; }

		[MemoryPackOrder(7)]
		public List<string> Types { get; set; } = new();

		[MemoryPackOrder(8)]
		public List<byte[]> Entitys { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.UnitId = default;
			this.ConfigId = default;
			this.Type = default;
			this.Position = default;
			this.Forward = default;
			this.KV.Clear();
			this.MoveInfo = default;
			this.Types.Clear();
			this.Entitys.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_CreateUnits)]
	[MemoryPackable]
	public partial class M2C_CreateUnits: MessageObject, IActorMessage
	{
		public static M2C_CreateUnits Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_CreateUnits), isFromPool) as M2C_CreateUnits; 
		}

		[MemoryPackOrder(0)]
		public List<UnitInfo> Units { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.Units.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_CreateMyUnit)]
	[MemoryPackable]
	public partial class M2C_CreateMyUnit: MessageObject, IActorMessage
	{
		public static M2C_CreateMyUnit Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_CreateMyUnit), isFromPool) as M2C_CreateMyUnit; 
		}

		[MemoryPackOrder(0)]
		public UnitInfo Unit { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.Unit = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_StartSceneChange)]
	[MemoryPackable]
	public partial class M2C_StartSceneChange: MessageObject, IActorMessage
	{
		public static M2C_StartSceneChange Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_StartSceneChange), isFromPool) as M2C_StartSceneChange; 
		}

		[MemoryPackOrder(0)]
		public long SceneInstanceId { get; set; }

		[MemoryPackOrder(1)]
		public string SceneName { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.SceneInstanceId = default;
			this.SceneName = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_RemoveUnits)]
	[MemoryPackable]
	public partial class M2C_RemoveUnits: MessageObject, IActorMessage
	{
		public static M2C_RemoveUnits Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_RemoveUnits), isFromPool) as M2C_RemoveUnits; 
		}

		[MemoryPackOrder(0)]
		public List<long> Units { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.Units.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//持续移动请求(服务器直接校验并记录位置即可)
	[Message(OuterMessage.C2M_KeepMoveResult)]
	[MemoryPackable]
	public partial class C2M_KeepMoveResult: MessageObject, IActorLocationMessage
	{
		public static C2M_KeepMoveResult Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_KeepMoveResult), isFromPool) as C2M_KeepMoveResult; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public Unity.Mathematics.float3 Position { get; set; }

		[MemoryPackOrder(2)]
		public int FaceAngle { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Position = default;
			this.FaceAngle = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_KeepMoveResult)]
	[MemoryPackable]
	public partial class M2C_KeepMoveResult: MessageObject, IActorMessage
	{
		public static M2C_KeepMoveResult Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_KeepMoveResult), isFromPool) as M2C_KeepMoveResult; 
		}

		[MemoryPackOrder(0)]
		public long Id { get; set; }

		[MemoryPackOrder(1)]
		public Unity.Mathematics.float3 Position { get; set; }

		[MemoryPackOrder(2)]
		public List<Unity.Mathematics.float3> Points { get; set; } = new();

		[MemoryPackOrder(3)]
		public int FaceAngle { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.Id = default;
			this.Position = default;
			this.Points.Clear();
			this.FaceAngle = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//寻路移动请求
	[Message(OuterMessage.C2M_PathfindingResult)]
	[MemoryPackable]
	public partial class C2M_PathfindingResult: MessageObject, IActorLocationMessage
	{
		public static C2M_PathfindingResult Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_PathfindingResult), isFromPool) as C2M_PathfindingResult; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public Unity.Mathematics.float3 Position { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Position = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.C2M_Stop)]
	[MemoryPackable]
	public partial class C2M_Stop: MessageObject, IActorLocationMessage
	{
		public static C2M_Stop Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_Stop), isFromPool) as C2M_Stop; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_PathfindingResult)]
	[MemoryPackable]
	public partial class M2C_PathfindingResult: MessageObject, IActorMessage
	{
		public static M2C_PathfindingResult Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_PathfindingResult), isFromPool) as M2C_PathfindingResult; 
		}

		[MemoryPackOrder(0)]
		public long Id { get; set; }

		[MemoryPackOrder(1)]
		public Unity.Mathematics.float3 Position { get; set; }

		[MemoryPackOrder(2)]
		public List<Unity.Mathematics.float3> Points { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.Id = default;
			this.Position = default;
			this.Points.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_Stop)]
	[MemoryPackable]
	public partial class M2C_Stop: MessageObject, IActorMessage
	{
		public static M2C_Stop Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_Stop), isFromPool) as M2C_Stop; 
		}

		[MemoryPackOrder(0)]
		public int Error { get; set; }

		[MemoryPackOrder(1)]
		public long Id { get; set; }

		[MemoryPackOrder(2)]
		public Unity.Mathematics.float3 Position { get; set; }

		[MemoryPackOrder(3)]
		public Unity.Mathematics.quaternion Rotation { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.Error = default;
			this.Id = default;
			this.Position = default;
			this.Rotation = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(G2C_Ping))]
	[Message(OuterMessage.C2G_Ping)]
	[MemoryPackable]
	public partial class C2G_Ping: MessageObject, IRequest
	{
		public static C2G_Ping Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2G_Ping), isFromPool) as C2G_Ping; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.G2C_Ping)]
	[MemoryPackable]
	public partial class G2C_Ping: MessageObject, IResponse
	{
		public static G2C_Ping Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(G2C_Ping), isFromPool) as G2C_Ping; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int Error { get; set; }

		[MemoryPackOrder(2)]
		public string Message { get; set; }

		[MemoryPackOrder(3)]
		public long Time { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.Time = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.G2C_Test)]
	[MemoryPackable]
	public partial class G2C_Test: MessageObject, IMessage
	{
		public static G2C_Test Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(G2C_Test), isFromPool) as G2C_Test; 
		}

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_Reload))]
	[Message(OuterMessage.C2M_Reload)]
	[MemoryPackable]
	public partial class C2M_Reload: MessageObject, IRequest
	{
		public static C2M_Reload Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_Reload), isFromPool) as C2M_Reload; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public string Account { get; set; }

		[MemoryPackOrder(2)]
		public string Password { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Account = default;
			this.Password = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_Reload)]
	[MemoryPackable]
	public partial class M2C_Reload: MessageObject, IResponse
	{
		public static M2C_Reload Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_Reload), isFromPool) as M2C_Reload; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int Error { get; set; }

		[MemoryPackOrder(2)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(R2C_Login))]
	[Message(OuterMessage.C2R_Login)]
	[MemoryPackable]
	public partial class C2R_Login: MessageObject, IRequest
	{
		public static C2R_Login Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2R_Login), isFromPool) as C2R_Login; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public string Account { get; set; }

		[MemoryPackOrder(2)]
		public string Password { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Account = default;
			this.Password = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.R2C_Login)]
	[MemoryPackable]
	public partial class R2C_Login: MessageObject, IResponse
	{
		public static R2C_Login Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(R2C_Login), isFromPool) as R2C_Login; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int Error { get; set; }

		[MemoryPackOrder(2)]
		public string Message { get; set; }

		[MemoryPackOrder(3)]
		public string Address { get; set; }

		[MemoryPackOrder(4)]
		public long Key { get; set; }

		[MemoryPackOrder(5)]
		public long GateId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.Address = default;
			this.Key = default;
			this.GateId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(G2C_LoginGate))]
	[Message(OuterMessage.C2G_LoginGate)]
	[MemoryPackable]
	public partial class C2G_LoginGate: MessageObject, IRequest
	{
		public static C2G_LoginGate Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2G_LoginGate), isFromPool) as C2G_LoginGate; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public long Key { get; set; }

		[MemoryPackOrder(2)]
		public long GateId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Key = default;
			this.GateId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.G2C_LoginGate)]
	[MemoryPackable]
	public partial class G2C_LoginGate: MessageObject, IResponse
	{
		public static G2C_LoginGate Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(G2C_LoginGate), isFromPool) as G2C_LoginGate; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int Error { get; set; }

		[MemoryPackOrder(2)]
		public string Message { get; set; }

		[MemoryPackOrder(3)]
		public long PlayerId { get; set; }

		[MemoryPackOrder(4)]
		public Msg_BroadcastPlayer PlayerDatas { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.PlayerId = default;
			this.PlayerDatas = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.G2C_TestHotfixMessage)]
	[MemoryPackable]
	public partial class G2C_TestHotfixMessage: MessageObject, IMessage
	{
		public static G2C_TestHotfixMessage Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(G2C_TestHotfixMessage), isFromPool) as G2C_TestHotfixMessage; 
		}

		[MemoryPackOrder(0)]
		public string Info { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.Info = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_TestRobotCase))]
	[Message(OuterMessage.C2M_TestRobotCase)]
	[MemoryPackable]
	public partial class C2M_TestRobotCase: MessageObject, IActorLocationRequest
	{
		public static C2M_TestRobotCase Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_TestRobotCase), isFromPool) as C2M_TestRobotCase; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int N { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.N = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_TestRobotCase)]
	[MemoryPackable]
	public partial class M2C_TestRobotCase: MessageObject, IActorLocationResponse
	{
		public static M2C_TestRobotCase Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_TestRobotCase), isFromPool) as M2C_TestRobotCase; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int Error { get; set; }

		[MemoryPackOrder(2)]
		public string Message { get; set; }

		[MemoryPackOrder(3)]
		public int N { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.N = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.C2M_TestRobotCase2)]
	[MemoryPackable]
	public partial class C2M_TestRobotCase2: MessageObject, IActorLocationMessage
	{
		public static C2M_TestRobotCase2 Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_TestRobotCase2), isFromPool) as C2M_TestRobotCase2; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int N { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.N = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_TestRobotCase2)]
	[MemoryPackable]
	public partial class M2C_TestRobotCase2: MessageObject, IActorLocationMessage
	{
		public static M2C_TestRobotCase2 Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_TestRobotCase2), isFromPool) as M2C_TestRobotCase2; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int N { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.N = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_TransferMap))]
	[Message(OuterMessage.C2M_TransferMap)]
	[MemoryPackable]
	public partial class C2M_TransferMap: MessageObject, IActorLocationRequest
	{
		public static C2M_TransferMap Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_TransferMap), isFromPool) as C2M_TransferMap; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_TransferMap)]
	[MemoryPackable]
	public partial class M2C_TransferMap: MessageObject, IActorLocationResponse
	{
		public static M2C_TransferMap Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_TransferMap), isFromPool) as M2C_TransferMap; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int Error { get; set; }

		[MemoryPackOrder(2)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_ExitMap))]
	[Message(OuterMessage.C2M_ExitMap)]
	[MemoryPackable]
	public partial class C2M_ExitMap: MessageObject, IActorLocationRequest
	{
		public static C2M_ExitMap Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2M_ExitMap), isFromPool) as C2M_ExitMap; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.M2C_ExitMap)]
	[MemoryPackable]
	public partial class M2C_ExitMap: MessageObject, IActorLocationResponse
	{
		public static M2C_ExitMap Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(M2C_ExitMap), isFromPool) as M2C_ExitMap; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int Error { get; set; }

		[MemoryPackOrder(2)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(G2C_Benchmark))]
	[Message(OuterMessage.C2G_Benchmark)]
	[MemoryPackable]
	public partial class C2G_Benchmark: MessageObject, IRequest
	{
		public static C2G_Benchmark Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2G_Benchmark), isFromPool) as C2G_Benchmark; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.G2C_Benchmark)]
	[MemoryPackable]
	public partial class G2C_Benchmark: MessageObject, IResponse
	{
		public static G2C_Benchmark Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(G2C_Benchmark), isFromPool) as G2C_Benchmark; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int Error { get; set; }

		[MemoryPackOrder(2)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(G2C_UseItem))]
	[Message(OuterMessage.C2G_UseItem)]
	[MemoryPackable]
	public partial class C2G_UseItem: MessageObject, IRequest
	{
		public static C2G_UseItem Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2G_UseItem), isFromPool) as C2G_UseItem; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public long ItemId { get; set; }

		[MemoryPackOrder(2)]
		public int UseType { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ItemId = default;
			this.UseType = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.G2C_UseItem)]
	[MemoryPackable]
	public partial class G2C_UseItem: MessageObject, IResponse
	{
		public static G2C_UseItem Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(G2C_UseItem), isFromPool) as G2C_UseItem; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int Error { get; set; }

		[MemoryPackOrder(2)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(G2C_SellItem))]
	[Message(OuterMessage.C2G_SellItem)]
	[MemoryPackable]
	public partial class C2G_SellItem: MessageObject, IRequest
	{
		public static C2G_SellItem Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2G_SellItem), isFromPool) as C2G_SellItem; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public List<long> ItemIds { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.ItemIds.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.G2C_SellItem)]
	[MemoryPackable]
	public partial class G2C_SellItem: MessageObject, IResponse
	{
		public static G2C_SellItem Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(G2C_SellItem), isFromPool) as G2C_SellItem; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int Error { get; set; }

		[MemoryPackOrder(2)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(G2C_ChangeMission))]
	[Message(OuterMessage.C2G_ChangeMission)]
	[MemoryPackable]
	public partial class C2G_ChangeMission: MessageObject, IRequest
	{
		public static C2G_ChangeMission Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2G_ChangeMission), isFromPool) as C2G_ChangeMission; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int MissionId { get; set; }

		[MemoryPackOrder(2)]
		public int Type { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.MissionId = default;
			this.Type = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.G2C_ChangeMission)]
	[MemoryPackable]
	public partial class G2C_ChangeMission: MessageObject, IResponse
	{
		public static G2C_ChangeMission Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(G2C_ChangeMission), isFromPool) as G2C_ChangeMission; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int Error { get; set; }

		[MemoryPackOrder(2)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//任务信息改变
	[Message(OuterMessage.Msg_MissionProcess)]
	[MemoryPackable]
	public partial class Msg_MissionProcess: MessageObject, IMessage
	{
		public static Msg_MissionProcess Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(Msg_MissionProcess), isFromPool) as Msg_MissionProcess; 
		}

		[MemoryPackOrder(0)]
		public int GoalType { get; set; }

		[MemoryPackOrder(1)]
		public int ParamX { get; set; }

		[MemoryPackOrder(2)]
		public int Process { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.GoalType = default;
			this.ParamX = default;
			this.Process = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(G2C_CreateRole))]
	[Message(OuterMessage.C2G_CreateRole)]
	[MemoryPackable]
	public partial class C2G_CreateRole: MessageObject, IRequest
	{
		public static C2G_CreateRole Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(C2G_CreateRole), isFromPool) as C2G_CreateRole; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public byte[] RoleMeshInfo { get; set; }

		[MemoryPackOrder(2)]
		public string PlayerName { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.RoleMeshInfo = default;
			this.PlayerName = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.G2C_CreateRole)]
	[MemoryPackable]
	public partial class G2C_CreateRole: MessageObject, IResponse
	{
		public static G2C_CreateRole Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(G2C_CreateRole), isFromPool) as G2C_CreateRole; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int Error { get; set; }

		[MemoryPackOrder(2)]
		public string Message { get; set; }

		[MemoryPackOrder(3)]
		public long PlayerId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.PlayerId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//邮件信息
	[Message(OuterMessage.Msg_PlayerMails)]
	[MemoryPackable]
	public partial class Msg_PlayerMails: MessageObject, IMessage
	{
		public static Msg_PlayerMails Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(Msg_PlayerMails), isFromPool) as Msg_PlayerMails; 
		}

		[MemoryPackOrder(0)]
		public List<byte[]> Mails { get; set; } = new();

		[MemoryPackOrder(1)]
		public bool FullMail { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.Mails.Clear();
			this.FullMail = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//邮件信息
	[Message(OuterMessage.Msg_UnlockSystems)]
	[MemoryPackable]
	public partial class Msg_UnlockSystems: MessageObject, IMessage
	{
		public static Msg_UnlockSystems Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(Msg_UnlockSystems), isFromPool) as Msg_UnlockSystems; 
		}

		[MemoryPackOrder(0)]
		public List<int> Systems { get; set; } = new();

		[MemoryPackOrder(1)]
		public bool AllSystem { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.Systems.Clear();
			this.AllSystem = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//邮件信息
	[Message(OuterMessage.Msg_SetMailState)]
	[MemoryPackable]
	public partial class Msg_SetMailState: MessageObject, IMessage
	{
		public static Msg_SetMailState Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(Msg_SetMailState), isFromPool) as Msg_SetMailState; 
		}

		[MemoryPackOrder(0)]
		public long MailId { get; set; }

		[MemoryPackOrder(1)]
		public int State { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.MailId = default;
			this.State = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//红点信息
	[Message(OuterMessage.Msg_RedPoint)]
	[MemoryPackable]
	public partial class Msg_RedPoint: MessageObject, IMessage
	{
		public static Msg_RedPoint Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(Msg_RedPoint), isFromPool) as Msg_RedPoint; 
		}

		[MemoryPackOrder(0)]
		public int SystemId { get; set; }

		[MemoryPackOrder(1)]
		public int ParamId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.SystemId = default;
			this.ParamId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//推送提示消息 或 跑马灯
	[Message(OuterMessage.Msg_BroadcastTip)]
	[MemoryPackable]
	public partial class Msg_BroadcastTip: MessageObject, IMessage
	{
		public static Msg_BroadcastTip Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(Msg_BroadcastTip), isFromPool) as Msg_BroadcastTip; 
		}

		[MemoryPackOrder(0)]
		public int TipId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.TipId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//刷新player及 挂载的组件数据
	[Message(OuterMessage.Msg_BroadcastPlayer)]
	[MemoryPackable]
	public partial class Msg_BroadcastPlayer: MessageObject, IMessage
	{
		public static Msg_BroadcastPlayer Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(Msg_BroadcastPlayer), isFromPool) as Msg_BroadcastPlayer; 
		}

		[MemoryPackOrder(0)]
		public byte[] Player { get; set; }

		[MemoryPackOrder(1)]
		public List<byte[]> Entitys { get; set; } = new();

		[MemoryPackOrder(2)]
		public List<string> Types { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.Player = default;
			this.Entitys.Clear();
			this.Types.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//推送奖励道具
	[Message(OuterMessage.Msg_BroadcastRewards)]
	[MemoryPackable]
	public partial class Msg_BroadcastRewards: MessageObject, IMessage
	{
		public static Msg_BroadcastRewards Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(Msg_BroadcastRewards), isFromPool) as Msg_BroadcastRewards; 
		}

		[MemoryPackOrder(0)]
		public List<Msg_Item> Rewards { get; set; } = new();

		[MemoryPackOrder(1)]
		public bool CostItem { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.Rewards.Clear();
			this.CostItem = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//道具信息
	[Message(OuterMessage.Msg_Item)]
	[MemoryPackable]
	public partial class Msg_Item: MessageObject, IMessage
	{
		public static Msg_Item Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(Msg_Item), isFromPool) as Msg_Item; 
		}

		[MemoryPackOrder(0)]
		public long Id { get; set; }

		[MemoryPackOrder(1)]
		public int ItemConfigId { get; set; }

		[MemoryPackOrder(2)]
		public long Count { get; set; }

		[MemoryPackOrder(3)]
		public List<KeyVal_Int> ItemInfos { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.Id = default;
			this.ItemConfigId = default;
			this.Count = default;
			this.ItemInfos.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

//字典信息
	[Message(OuterMessage.KeyVal_Int)]
	[MemoryPackable]
	public partial class KeyVal_Int: MessageObject, IMessage
	{
		public static KeyVal_Int Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(KeyVal_Int), isFromPool) as KeyVal_Int; 
		}

		[MemoryPackOrder(0)]
		public int Key { get; set; }

		[MemoryPackOrder(1)]
		public int Val { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.Key = default;
			this.Val = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(OuterMessage.Msg_BroadCast)]
	[MemoryPackable]
	public partial class Msg_BroadCast: MessageObject, IActorBroadCast
	{
		public static Msg_BroadCast Create(bool isFromPool = true) 
		{ 
			return ObjectPool.Instance.Fetch(typeof(Msg_BroadCast), isFromPool) as Msg_BroadCast; 
		}

		[MemoryPackOrder(0)]
		public long Id { get; set; }

		[MemoryPackOrder(1)]
		public List<long> ListId { get; set; } = new();

		[MemoryPackOrder(2)]
		public int Opcode { get; set; }

		[MemoryPackOrder(3)]
		public byte[] Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.Id = default;
			this.ListId.Clear();
			this.Opcode = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	public static class OuterMessage
	{
		 public const ushort HttpGetRouterResponse = 10002;
		 public const ushort RouterSync = 10003;
		 public const ushort C2M_TestRequest = 10004;
		 public const ushort M2C_TestResponse = 10005;
		 public const ushort Actor_TransferRequest = 10006;
		 public const ushort Actor_TransferResponse = 10007;
		 public const ushort C2G_EnterMap = 10008;
		 public const ushort G2C_EnterMap = 10009;
		 public const ushort MoveInfo = 10010;
		 public const ushort UnitInfo = 10011;
		 public const ushort M2C_CreateUnits = 10012;
		 public const ushort M2C_CreateMyUnit = 10013;
		 public const ushort M2C_StartSceneChange = 10014;
		 public const ushort M2C_RemoveUnits = 10015;
		 public const ushort C2M_KeepMoveResult = 10016;
		 public const ushort M2C_KeepMoveResult = 10017;
		 public const ushort C2M_PathfindingResult = 10018;
		 public const ushort C2M_Stop = 10019;
		 public const ushort M2C_PathfindingResult = 10020;
		 public const ushort M2C_Stop = 10021;
		 public const ushort C2G_Ping = 10022;
		 public const ushort G2C_Ping = 10023;
		 public const ushort G2C_Test = 10024;
		 public const ushort C2M_Reload = 10025;
		 public const ushort M2C_Reload = 10026;
		 public const ushort C2R_Login = 10027;
		 public const ushort R2C_Login = 10028;
		 public const ushort C2G_LoginGate = 10029;
		 public const ushort G2C_LoginGate = 10030;
		 public const ushort G2C_TestHotfixMessage = 10031;
		 public const ushort C2M_TestRobotCase = 10032;
		 public const ushort M2C_TestRobotCase = 10033;
		 public const ushort C2M_TestRobotCase2 = 10034;
		 public const ushort M2C_TestRobotCase2 = 10035;
		 public const ushort C2M_TransferMap = 10036;
		 public const ushort M2C_TransferMap = 10037;
		 public const ushort C2M_ExitMap = 10038;
		 public const ushort M2C_ExitMap = 10039;
		 public const ushort C2G_Benchmark = 10040;
		 public const ushort G2C_Benchmark = 10041;
		 public const ushort C2G_UseItem = 10042;
		 public const ushort G2C_UseItem = 10043;
		 public const ushort C2G_SellItem = 10044;
		 public const ushort G2C_SellItem = 10045;
		 public const ushort C2G_ChangeMission = 10046;
		 public const ushort G2C_ChangeMission = 10047;
		 public const ushort Msg_MissionProcess = 10048;
		 public const ushort C2G_CreateRole = 10049;
		 public const ushort G2C_CreateRole = 10050;
		 public const ushort Msg_PlayerMails = 10051;
		 public const ushort Msg_UnlockSystems = 10052;
		 public const ushort Msg_SetMailState = 10053;
		 public const ushort Msg_RedPoint = 10054;
		 public const ushort Msg_BroadcastTip = 10055;
		 public const ushort Msg_BroadcastPlayer = 10056;
		 public const ushort Msg_BroadcastRewards = 10057;
		 public const ushort Msg_Item = 10058;
		 public const ushort KeyVal_Int = 10059;
		 public const ushort Msg_BroadCast = 10060;
	}
}
