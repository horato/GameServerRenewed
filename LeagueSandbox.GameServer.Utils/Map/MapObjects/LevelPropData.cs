namespace LeagueSandbox.GameServer.Utils.Map.MapObjects
{
    public class LevelPropData
    {
        public string Name { get; }
        public string SkinName { get; }
        public uint NetId { get; }

        public LevelPropData(string name, string skinName, uint netId)
        {
            Name = name;
            SkinName = skinName;
            NetId = netId;
        }
    }
}
