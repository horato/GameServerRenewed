namespace LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.S2C
{
    internal class DestroyClientMissile : BasePacket
    {
        public DestroyClientMissile(uint netId) : base(PacketCmd.S2CDestroyClientMissile, netId)
        {

        }
    }
}