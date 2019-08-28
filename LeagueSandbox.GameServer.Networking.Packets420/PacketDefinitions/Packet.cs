using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using LeagueSandbox.GameServer.Networking.Core;

namespace LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions
{
	internal class Packet : IPacket
    {
        protected List<byte> Bytes = new List<byte>();

        public Packet(PacketCmd cmd)
        {
            WriteByte((byte)cmd);
        }

        public byte[] GetBytes()
        {
            return Bytes.ToArray();
        }

        public void Fill(byte data, int length)
        {
            if (length <= 0)
            {
                return;
            }

            var arr = new byte[length];
            for (var i = 0; i < length; ++i)
            {
                arr[i] = data;
            }

            WriteBytes(arr);
        }

        public void WriteBool(bool b)
        {
            WriteByte((byte)(b ? 1u : 0u));
        }

        public void WriteByte(byte b)
        {
            Bytes.Add(b);
        }

        public void WriteSByte(sbyte b)
        {
            WriteByte((byte)b);
        }

        public void WriteBytes(byte[] b)
        {
            Bytes.AddRange(b);
        }

        public void WriteShort(short s)
        {
            var arr = new byte[2];
            for (var i = 0; i < 2; i++)
            {
                arr[i] = (byte)(s >> (i * 8));
            }

            WriteBytes(arr);
        }

        public void WriteUShort(ushort s)
        {
            var arr = new byte[2];
            for (var i = 0; i < 2; i++)
            {
                arr[i] = (byte)(s >> (i * 8));
            }

            WriteBytes(arr);
        }

        public void WriteInt(int n)
        {
            var arr = new byte[4];
            for (var i = 0; i < 4; i++)
            {
                arr[i] = (byte)(n >> (i * 8));
            }

            WriteBytes(arr);
        }

        public void WriteUInt(uint n)
        {
            var arr = new byte[4];
            for (var i = 0; i < 4; i++)
            {
                arr[i] = (byte)(n >> (i * 8));
            }

            WriteBytes(arr);
        }

        public void WriteLong(long l)
        {
            var arr = new byte[8];
            for (var i = 0; i < 8; i++)
            {
                arr[i] = (byte)(l >> (i * 8));
            }

            WriteBytes(arr);
        }

        public void WriteULong(ulong l)
        {
            var arr = new byte[8];
            for (var i = 0; i < 8; i++)
            {
                arr[i] = (byte)(l >> (i * 8));
            }

            WriteBytes(arr);
        }

        public void WriteFloat(float f)
        {
            WriteBytes(BitConverter.GetBytes(f));
        }

        public void WriteDouble(double d)
        {
            WriteBytes(BitConverter.GetBytes(d));
        }

        public void WriteString(string s)
        {
            WriteBytes(Encoding.UTF8.GetBytes(s));
        }

        public void WriteFixedString(string str, int maxLength)
        {
            var data = string.IsNullOrEmpty(str) ? new byte[0] : Encoding.UTF8.GetBytes(str);
            var count = data.Length;
            if (count >= (maxLength - 1))
                throw new IOException("Too much data!");

            WriteBytes(data);
            Fill(0, maxLength - count);
        }

        //public void WriteStringHash(string str)
        //{
        //    Write(HashFunctions.HashString(str));
        //}

        //public void WriteNetId(IGameObject obj)
        //{
        //    if (obj == null)
        //    {
        //        Write(0u);
        //    }
        //    else
        //    {
        //        Write(obj.NetId);
        //    }
        //}
    }
}
