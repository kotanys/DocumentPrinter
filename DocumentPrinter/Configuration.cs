using System.Text.Json;

namespace DocumentPrinter
{
    internal class Configuration : IConfiguration
    {
        public static readonly Configuration Empty = new();
        public string RelativePathToDocuments { get; set; } = "";
        public string? ImageOpenerProgram { get; set; }
    }
}
