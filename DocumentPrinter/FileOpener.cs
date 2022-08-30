using System.Diagnostics;

namespace DocumentPrinter
{
    internal class FileOpener : IFileOpener
    {
        private readonly IConfiguration _configuration;

        public FileOpener(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Open(string file)
        {
            if (_configuration.ImageOpenerProgram is { } opener)
            {
                Process.Start(opener, @$"""{file}""");
            }
        }
    }
}
