using LeagueSandbox.GameServer.Networking.Packets420.Enums;

namespace LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.S2C
{
    internal class HandleTipUpdate : BasePacket
    {
        private readonly string _tipHeader;
        private readonly string _tipText;
        private readonly string _tipImagePath;
        private readonly TipCommand _tipCommand;
        private readonly uint _tipId;

        public HandleTipUpdate(string tipHeader, string tipText, string tipImagePath, TipCommand tipCommand, uint tipId, uint targetNetId) : base(PacketCmd.S2CHandleTipUpdate, targetNetId)
        {
            _tipHeader = tipHeader;
            _tipText = tipText;
            _tipImagePath = tipImagePath;
            _tipCommand = tipCommand;
            _tipId = tipId;

            WritePacket();
        }

        private void WritePacket()
        {
            WriteFixedString(_tipText, 128);
            WriteFixedString(_tipHeader, 128);
            WriteFixedString(_tipImagePath, 128);
            WriteByte((byte)_tipCommand);
            WriteUInt(_tipId);
        }
    }
}