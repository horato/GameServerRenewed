using System.IO;
using System.Numerics;
using LeagueSandbox.GameServer.Networking.Packets420.Enums;

namespace LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.Common
{
    internal class MovementDataStop : MovementData
    {
        public override MovementDataType Type => MovementDataType.Stop;

        public Vector2 Position { get; set; }
        public Vector2 Forward { get; set; }

        public MovementDataStop(int syncId, Vector2 position, Vector2 forward) : base(syncId)
        {
            Position = position;
            Forward = forward;
        }

        public override byte[] GetData()
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream))
            {
                writer.Write(Position.X);
                writer.Write(Position.Y);
                writer.Write(Forward.X);
                writer.Write(Forward.Y);

                return stream.ToArray();
            }
        }
    }
}