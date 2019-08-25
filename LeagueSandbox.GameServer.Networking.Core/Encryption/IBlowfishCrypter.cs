namespace LeagueSandbox.GameServer.Networking.Core.Encryption
{
	public interface IBlowfishCrypter
	{
		void Initialize(string blowfishKey);
		byte[] Decipher(byte[] data);
        ulong Decipher(ulong key);
		byte[] Encipher(byte[] data);
    }
}
