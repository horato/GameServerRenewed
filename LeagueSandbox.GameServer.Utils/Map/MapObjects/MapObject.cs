using System.Numerics;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace LeagueSandbox.GameServer.Utils.Map.MapObjects
{
    public class MapObject
    {
        public string Name { get; }
        public int SkinId { get; }
        public Vector3 Position { get; }
        public Vector3 Rotation { get; }
        public Vector3 Scale { get; }

        [JsonConverter(typeof(StringEnumConverter))]
        public ObjectType ObjectType { get; }

        public HqData HqData { get; }
        public BarracksData BarracksData { get; }
        public TurretData TurretData { get; }
        public LevelPropData LevelPropData { get; }
        public ShopData ShopData { get; }

        public MapObject(string name, int skinId, Vector3 position, Vector3 rotation, Vector3 scale, ObjectType objectType, HqData hqData, BarracksData barracksData, TurretData turretData, LevelPropData levelPropData, ShopData shopData)
        {
            Name = name;
            SkinId = skinId;
            Position = position;
            Rotation = rotation;
            Scale = scale;
            ObjectType = objectType;
            HqData = hqData;
            BarracksData = barracksData;
            TurretData = turretData;
            LevelPropData = levelPropData;
            ShopData = shopData;
        }
    }
}
