using System.Diagnostics;

namespace DocumentPrinter
{
    internal class FileOpener : IFileOpener
    {
        public void Open(string file)
        {
            //var processStartInfo = new ProcessStartInfo(@"Documents\\" +Path.GetFileName(file))
            //{
            //    WorkingDirectory = Environment.CurrentDirectory + @"\Documents"
            //};
            //Process.Start(processStartInfo);
        }
    }
}
