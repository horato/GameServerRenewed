using System.Numerics;
using LeagueSandbox.GameServer.Utils.Map.MapObjects;

namespace LeagueSandbox.GameServer.Core.Map.MapObjects
{
    public interface IMapObject
    {
        string Name { get; }
        int SkinId { get; }
        Vector3 Position { get; }
        Vector3 Rotation { get; }
        Vector3 Scale { get; }
        ObjectType ObjectType { get; }
        IHqData HqData { get; }
        IBarracksData BarracksData { get; }
        ITurretData TurretData { get; }
        ILevelPropData LevelPropData { get; }
        IShopData ShopData { get; }
        INavPointData NavPointData { get; }
        IBarrackSpawnData BarrackSpawnData { get; }
    }
}