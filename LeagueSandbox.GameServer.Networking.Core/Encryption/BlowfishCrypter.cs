using System;

namespace LeagueSandbox.GameServer.Networking.Core.Encryption
{
    public class BlowfishCrypter : IBlowfishCrypter
    {
        private Blowfish _blowfish;

        public void Initialize(string blowfishKey)
        {
            if (_blowfish != null)
                throw new InvalidOperationException("Blowfish already initialized");

            var key = Convert.FromBase64String(blowfishKey);
            if (key.Length == 0)
                throw new InvalidOperationException("Invalid blowfish key supplied");

            _blowfish = new Blowfish(key);
        }

        public byte[] Decipher(byte[] data)
        {
            if (_blowfish == null)
                throw new InvalidOperationException("Blowfish not initialized");

            var temp = new byte[data.Length + (8 - (data.Length % 8))];
            Array.Copy(data, temp, data.Length);

            _blowfish.Decipher(temp, temp.Length);

            return temp;
        }

        public byte[] Encipher(byte[] data)
        {
            if (_blowfish == null)
                throw new InvalidOperationException("Blowfish not initialized");

            var temp = new byte[data.Length + (8 - (data.Length % 8))];
            Array.Copy(data, temp, data.Length);

            _blowfish.Encipher(temp, temp.Length);

            return temp;
        }

        public ulong Decipher(ulong key)
        {
            var bytes = BitConverter.GetBytes(key);

            _blowfish.Decipher(bytes, bytes.Length);

            return BitConverter.ToUInt64(bytes, 0);
        }
    }
}