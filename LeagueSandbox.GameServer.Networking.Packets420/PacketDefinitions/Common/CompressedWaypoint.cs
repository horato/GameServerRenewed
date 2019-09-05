using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions.Common
{
    internal class CompressedWaypoint
    {
        public short X { get; }
        public short Y { get; }

        public CompressedWaypoint(short x, short y)
        {
            X = x;
            Y = y;
        }
    }

    internal static class CompressedWaypointExtension
    {
        public static List<CompressedWaypoint> ReadCompressedWaypoints(this BinaryReader reader, uint size)
        {
            var data = new List<CompressedWaypoint>();
            BitArray flags;
            if (size > 1)
            {
                var flagsBuffer = reader.ReadBytes((int)((size - 2) / 4 + 1));
                flags = new BitArray(flagsBuffer);
            }
            else
            {
                flags = new BitArray(new byte[1]);
            }

            var lastX = reader.ReadInt16();
            var lastZ = reader.ReadInt16();
            data.Add(new CompressedWaypoint(lastX, lastZ));

            for (int i = 1, flag = 0; i < size; i++)
            {
                if (flags[flag])
                {
                    lastX += reader.ReadSByte();
                }
                else
                {
                    lastX = reader.ReadInt16();
                }

                flag++;

                if (flags[flag])
                {
                    lastZ += reader.ReadSByte();
                }
                else
                {
                    lastZ = reader.ReadInt16();
                }

                flag++;

                data.Add(new CompressedWaypoint(lastX, lastZ));
            }

            return data;
        }

        public static void WriteCompressedWaypoints(this BinaryWriter writer, IList<CompressedWaypoint> data)
        {
            if (data == null)
                data = new List<CompressedWaypoint>();

            var size = data.Count;
            if (size < 1)
                throw new InvalidOperationException("Need at least 1 waypoint!");

            byte[] flagsBuffer;
            if (size > 1)
            {
                flagsBuffer = new byte[(size - 2) / 4 + 1u];
            }
            else
            {
                flagsBuffer = new byte[0];
            }

            var flags = new BitArray(flagsBuffer);
            for (int i = 1, flag = 0; i < size; i++)
            {
                var relativeX = data[i].X - data[i - 1].X;
                flags[flag] = (relativeX <= sbyte.MaxValue && relativeX >= sbyte.MinValue);
                flag++;

                var relativeY = data[i].Y - data[i - 1].Y;
                flags[flag] = (relativeY <= sbyte.MaxValue && relativeY >= sbyte.MinValue);
                flag++;
            }

            flags.CopyTo(flagsBuffer, 0);
            writer.Write(flagsBuffer);
            writer.Write((short)data[0].X);
            writer.Write((short)data[0].Y);

            Console.WriteLine($"{data[0].X}:{data[0].Y}");
            for (int i = 1, flag = 0; i < size; i++)
            {
                if (flags[flag])
                {
                    writer.Write((sbyte)(data[i].X - data[i - 1].X));
                }
                else
                {
                    writer.Write((short)data[i].X);
                }

                flag++;

                if (flags[flag])
                {
                    writer.Write((sbyte)(data[i].Y - data[i - 1].Y));
                }
                else
                {
                    writer.Write((short)data[i].Y);
                }

                flag++;
            }
        }
    }
}
