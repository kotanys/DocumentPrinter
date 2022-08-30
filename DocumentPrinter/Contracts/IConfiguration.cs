using System.Diagnostics;

namespace DocumentPrinter.Contracts
{
    public interface IConfiguration
    {
        string RelativePathToDocuments { get; }
        string? ImageOpenerProgram { get; }
    }
}
