using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Text;

namespace LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.Common
{
    public class SpeedParams
    {
        public float PathSpeedOverride { get; }
        public float ParabolicGravity { get; }
        public Vector2 ParabolicStartPoint { get; }
        public bool Facing { get; }
        public uint FollowNetId { get; }
        public float FollowDistance { get; }
        public float FollowBackDistance { get; }
        public float FollowTravelTime { get; }

        public SpeedParams(float pathSpeedOverride, float parabolicGravity, Vector2 parabolicStartPoint, bool facing, uint followNetId, float followDistance, float followBackDistance, float followTravelTime)
        {
            PathSpeedOverride = pathSpeedOverride;
            ParabolicGravity = parabolicGravity;
            ParabolicStartPoint = parabolicStartPoint;
            Facing = facing;
            FollowNetId = followNetId;
            FollowDistance = followDistance;
            FollowBackDistance = followBackDistance;
            FollowTravelTime = followTravelTime;
        }
    }

    public static class SpeedParamsExtension
    {
        public static SpeedParams ReadWaypointSpeedParams(this BinaryReader reader)
        {
            var pathSpeedOverride = reader.ReadSingle();
            var parabolicGravity = reader.ReadSingle();
            var parabolicStartPoint = new Vector2(reader.ReadSingle(), reader.ReadSingle());
            var facing = reader.ReadBoolean();
            var followNetId = reader.ReadUInt32();
            var followDistance = reader.ReadSingle();
            var followBackDistance = reader.ReadSingle();
            var followTravelTime = reader.ReadSingle();

            return new SpeedParams(pathSpeedOverride, parabolicGravity, parabolicStartPoint, facing, followNetId, followDistance, followBackDistance, followTravelTime);
        }

        public static void WriteWaypointSpeedParams(this BinaryWriter writer, SpeedParams data)
        {
            writer.Write((float)data.PathSpeedOverride);
            writer.Write((float)data.ParabolicGravity);
            writer.Write((float)data.ParabolicStartPoint.X);
            writer.Write((float)data.ParabolicStartPoint.Y);
            writer.Write((bool)data.Facing);
            writer.Write((uint)data.FollowNetId);
            writer.Write((float)data.FollowDistance);
            writer.Write((float)data.FollowBackDistance);
            writer.Write((float)data.FollowTravelTime);
        }
    }
}
