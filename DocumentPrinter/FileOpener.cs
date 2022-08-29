using System.Diagnostics;

namespace DocumentPrinter
{
    internal class FileOpener : IFileOpener
    {
        public void Open(string file)
        {
            Process.Start(file);
        }
    }
}
