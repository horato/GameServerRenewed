namespace LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.Common
{
    public class TipConfig
    {
        public sbyte TipID { get; }
        public sbyte ColorID { get; }
        public sbyte DurationID { get; }
        public sbyte Flags { get; }

        public TipConfig(sbyte tipId, sbyte colorId, sbyte durationId, sbyte flags)
        {
            TipID = tipId;
            ColorID = colorId;
            DurationID = durationId;
            Flags = flags;
        }

        public TipConfig()
        {
        }
    }
}