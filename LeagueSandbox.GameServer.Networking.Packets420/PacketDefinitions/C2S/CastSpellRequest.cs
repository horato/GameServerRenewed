using System.IO;
using LeagueSandbox.GameServer.Networking.Packets420.Attributes;

namespace LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.C2S
{
	[Packet(PacketCmd.C2SCastSpell)]
	internal class CastSpellRequest : IRequestPacketDefinition
	{
		public PacketCmd Cmd { get; }
		public int NetId { get; }
		public byte SpellSlotType { get; } // 4.18 [deprecated? . 2 first(highest) bits: 10 - ability or item, 01 - summoner spell]
		public byte SpellSlot { get; } // 0-3 [0-1 if spellSlotType has summoner spell bits set]
		public float X { get; } // Initial point
		public float Y { get; } // (e.g. Viktor E laser starting point)
		public float X2 { get; } // Final point
		public float Y2 { get; } // (e.g. Viktor E laser final point)
		public uint TargetNetId { get; } // If 0, use coordinates, else use target net id

		public CastSpellRequest(byte[] data)
		{
			using (var reader = new BinaryReader(new MemoryStream(data)))
			{
				Cmd = (PacketCmd)reader.ReadByte();
				NetId = reader.ReadInt32();
				SpellSlotType = reader.ReadByte();
				SpellSlot = reader.ReadByte();
				X = reader.ReadSingle();
				Y = reader.ReadSingle();
				X2 = reader.ReadSingle();
				Y2 = reader.ReadSingle();
				TargetNetId = reader.ReadUInt32();
			}
		}
	}
}