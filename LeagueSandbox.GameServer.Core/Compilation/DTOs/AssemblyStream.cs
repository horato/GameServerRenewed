namespace LeagueSandbox.GameServer.Core.Compilation.DTOs
{
    public class AssemblyStream
    {
        public byte[] AssemblyBytes { get; }
        public byte[] DebuggingInformationBytes { get; }
        public string AssemblyName { get; }

        public AssemblyStream(byte[] assemblyBytes, byte[] debuggingInformationBytes, string assemblyName)
        {
            AssemblyBytes = assemblyBytes;
            DebuggingInformationBytes = debuggingInformationBytes;
            AssemblyName = assemblyName;
        }
    }
}
