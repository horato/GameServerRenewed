using System.Numerics;
using LeagueSandbox.GameServer.Networking.Packets420.Enums;

namespace LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.S2C
{
    internal class SpawnMinion : BasePacket
    {
        public uint NetID { get; }
        public uint OwnerNetID { get; }
        public NetNodeID NetNodeID { get; }
        public Vector3 Position { get; }
        public int SkinID { get; }
        public uint CloneNetID { get; }
        public TeamId Team { get; }
        public bool IgnoreCollision { get; }
        public bool IsWard { get; }
        public bool IsLaneMinion { get; }
        public bool IsBot { get; }
        public bool IsTargetable { get; }

        public SpellFlags IsTargetableToTeam { get; }
        public float VisibilitySize { get; }
        public string Name { get; }
        public string SkinName { get; }
        public ushort InitialLevel { get; }
        public uint OnlyVisibleToNetID { get; }

        public SpawnMinion(uint netId, uint ownerNetId, NetNodeID netNodeId, Vector3 position, int skinId, uint cloneNetId, TeamId team, bool ignoreCollision, bool isWard, bool isLaneMinion, bool isBot, bool isTargetable, SpellFlags isTargetableToTeam, float visibilitySize, string name, string skinName, ushort initialLevel, uint onlyVisibleToNetId)
            : base(PacketCmd.S2CSpawnMinion, netId)
        {
            NetID = netId;
            OwnerNetID = ownerNetId;
            NetNodeID = netNodeId;
            Position = position;
            SkinID = skinId;
            CloneNetID = cloneNetId;
            Team = team;
            IgnoreCollision = ignoreCollision;
            IsWard = isWard;
            IsLaneMinion = isLaneMinion;
            IsBot = isBot;
            IsTargetable = isTargetable;
            IsTargetableToTeam = isTargetableToTeam;
            VisibilitySize = visibilitySize;
            Name = name;
            SkinName = skinName;
            InitialLevel = initialLevel;
            OnlyVisibleToNetID = onlyVisibleToNetId;

            WritePacket();
        }
        
        private void WritePacket()
        {
            WriteUInt(NetID);
            WriteUInt(OwnerNetID);
            WriteByte((byte)NetNodeID);
            WriteVector3(Position);
            WriteInt(SkinID);
            WriteUInt(CloneNetID);
            WriteUShort((ushort)Team);

            byte bitfield = 0;
            if (IgnoreCollision)
                bitfield |= 0x01;
            if (IsWard)
                bitfield |= 0x02;
            if (IsLaneMinion)
                bitfield |= 0x04;
            if (IsBot)
                bitfield |= 0x08;
            if (IsTargetable)
                bitfield |= 0x10;
            WriteByte(bitfield);

            WriteUInt((uint)IsTargetableToTeam);
            WriteFloat(VisibilitySize);
            WriteFixedString(Name, 64);
            WriteFixedString(SkinName, 64);
            WriteUShort(InitialLevel);
            WriteUInt(OnlyVisibleToNetID);
        }
    }
}