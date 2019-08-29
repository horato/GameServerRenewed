using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using LeagueSandbox.GameServer.Networking.Core;

namespace LeagueSandbox.GameServer.Networking.Packets420.PacketDefinitions
{
    internal class Packet : IPacket
    {
        private MemoryStream _stream;
        private BinaryWriter _writer;

        public Packet(PacketCmd cmd)
        {
            _stream = new MemoryStream();
            _writer = new BinaryWriter(_stream);

            WriteByte((byte)cmd);
        }

        public byte[] GetBytes() => _stream.GetBuffer();
        protected void WriteBool(bool b) => _writer.Write(b);
        protected void WriteByte(byte b) => _writer.Write(b);
        protected void WriteSByte(sbyte b) => _writer.Write(b);
        protected void WriteBytes(byte[] b) => _writer.Write(b);
        protected void WriteShort(short s) => _writer.Write(s);
        protected void WriteUShort(ushort s) => _writer.Write(s);
        protected void WriteInt(int n) => _writer.Write(n);
        protected void WriteUInt(uint n) => _writer.Write(n);
        protected void WriteLong(long l) => _writer.Write(l);
        protected void WriteULong(ulong l) => _writer.Write(l);
        protected void WriteFloat(float f) => _writer.Write(f);
        protected void WriteDouble(double d) => _writer.Write(d);
        protected void WriteString(string s) => WriteBytes(Encoding.UTF8.GetBytes(s));

        protected void Clear()
        {
            _stream = new MemoryStream();
            _writer = new BinaryWriter(_stream);
        }

        protected void WriteZero(int count)
        {
            if (count < 0)
                throw new InvalidOperationException("Count must be greater or equal to 0");

            WriteBytes(new byte[count]);
        }

        protected void WriteFixedString(string str, int maxLength)
        {
            var data = string.IsNullOrEmpty(str) ? new byte[0] : Encoding.UTF8.GetBytes(str);
            var count = data.Length;
            if (count > maxLength)
                throw new IOException("Too much data!");

            WriteBytes(data);
            WriteZero(maxLength - count);
        }

        //protected void WriteStringHash(string str)
        //{
        //    Write(HashFunctions.HashString(str));
        //}

        //protected void WriteNetId(IGameObject obj)
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
