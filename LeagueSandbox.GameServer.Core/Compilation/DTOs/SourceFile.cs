namespace LeagueSandbox.GameServer.Core.Compilation.DTOs
{
    public class SourceFile
    {
        public string FileFullPath { get; }
        public string FileName { get; }
        public string Content { get; }

        public SourceFile(string fileFullPath, string fileName, string content)
        {
            FileFullPath = fileFullPath;
            FileName = fileName;
            Content = content;
        }
    }
}
