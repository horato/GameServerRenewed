using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Text;
using LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.Common;

namespace LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.S2C
{
    internal class OnEnterVisiblityClient : BasePacket
    {
        private readonly IList<BasePacket> _packets;
        private readonly IList<ItemData> _items;
        private readonly ShieldValues _shieldValues;
        private readonly IList<CharacterStackData> _characterDataStack;
        private readonly uint _lookAtNetId;
        private readonly byte _lookAtType;
        private readonly Vector3 _lookAtPosition;
        private readonly IList<KeyValuePair<byte, int>> _buffCount;
        private readonly bool _unknownIsHero;
        private readonly MovementData _movementData;

        public OnEnterVisiblityClient(uint senderNetId, IList<BasePacket> packets, IList<ItemData> items, ShieldValues shieldValues, IList<CharacterStackData> characterDataStack, uint lookAtNetId, byte lookAtType, Vector3 lookAtPosition, IList<KeyValuePair<byte, int>> buffCount, bool unknownIsHero, MovementData movementData)
            : base(PacketCmd.S2COnEnterVisibilityClient, senderNetId)
        {
            _packets = packets;
            _items = items;
            _shieldValues = shieldValues;
            _characterDataStack = characterDataStack;
            _lookAtNetId = lookAtNetId;
            _lookAtType = lookAtType;
            _lookAtPosition = lookAtPosition;
            _buffCount = buffCount;
            _unknownIsHero = unknownIsHero;
            _movementData = movementData;

            WritePacket();
        }

        private void WritePacket()
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream))
            {
                foreach (var packet in _packets)
                {
                    var data = packet.GetBytes();
                    if (data.Length > 0x1FFF)
                        throw new InvalidOperationException("Packet is too large");

                    writer.Write((ushort)data.Length);
                    writer.Write(data);
                }

                var buffer = stream.ToArray();
                if (buffer.Length > 0x1FFF)
                    throw new InvalidOperationException("Packet data are too large");

                WriteUShort((ushort)(buffer.Length & 0x1FFF));
                WriteBytes(buffer);
            }

            var itemCount = _items.Count;
            if (itemCount > 0xFF)
                throw new InvalidOperationException("More than 255 items");

            WriteByte((byte)itemCount);
            foreach (var item in _items)
            {
                WriteByte(item.Slot);
                WriteByte(item.ItemsInSlot);
                WriteByte(item.SpellCharges);
                WriteUInt(item.ItemID);
            }

            if (_shieldValues != null)
            {
                WriteBool(true);
                WriteFloat(_shieldValues.Magical);
                WriteFloat(_shieldValues.Phyisical);
                WriteFloat(_shieldValues.MagicalAndPhysical);
            }
            else
            {
                WriteBool(false);
            }

            WriteInt(_characterDataStack.Count);
            foreach (var data in _characterDataStack)
            {
                WriteSizedString(data.SkinName);
                WriteUInt(data.SkinID);
                byte bitfield = 0;
                if (data.OverrideSpells)
                    bitfield |= 1;
                if (data.ModelOnly)
                    bitfield |= 2;
                if (data.ReplaceCharacterPackage)
                    bitfield |= 4;

                WriteByte(bitfield);
                WriteUInt(data.ID);
            }

            WriteUInt(_lookAtNetId);
            WriteByte(_lookAtType);
            WriteFloat(_lookAtPosition.X);
            WriteFloat(_lookAtPosition.Y);
            WriteFloat(_lookAtPosition.Z);

            WriteInt(_buffCount.Count);
            foreach (var kvp in _buffCount)
            {
                WriteByte(kvp.Key);
                WriteInt(kvp.Value);
            }

            WriteBool(_unknownIsHero);

            WriteByte((byte)_movementData.Type);
            WriteUInt(_movementData.SyncID);
            WriteBytes(_movementData.GetData());
        }
    }
}
