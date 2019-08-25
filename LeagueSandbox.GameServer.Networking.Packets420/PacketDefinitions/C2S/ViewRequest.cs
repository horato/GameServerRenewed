using System.IO;
using LeagueSandbox.GameServer.Networking.Packets420.Attributes;

namespace LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.C2S
{
	[Packet(PacketCmd.C2SViewReq)]
	internal class ViewRequest : IRequestPacketDefinition
	{
		public PacketCmd Cmd { get; }
		public int NetId { get; }
		public float X { get; }
		public float Zoom { get; }
		public float Y { get; }
		public float Y2 { get; }   //Unk
		public int Width { get; }  //Unk
		public int Height { get; } //Unk
		public int Unk2 { get; }   //Unk
		public byte RequestNo { get; }

		public ViewRequest(byte[] data)
		{
			using (var reader = new BinaryReader(new MemoryStream(data)))
			{
				Cmd = (PacketCmd)reader.ReadByte();
				NetId = reader.ReadInt32();
				X = reader.ReadSingle();
				Zoom = reader.ReadSingle();
				Y = reader.ReadSingle();
				Y2 = reader.ReadSingle();
				Width = reader.ReadInt32();
				Height = reader.ReadInt32();
				Unk2 = reader.ReadInt32();
				RequestNo = reader.ReadByte();
			}
		}
	}
}