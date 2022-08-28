using System.Diagnostics;
#if DEBUG
using DocumentPrinter.DebugClasses;
#endif
using DocumentPrinter.Forms;
using Microsoft.Extensions.DependencyInjection;

namespace DocumentPrinter
{
    internal static class Program
    {
        private static readonly IServiceProvider _services = BuildServiceProvider();

        [STAThread]
        private static void Main()
        {
            ApplicationConfiguration.Initialize();
            var form = _services.GetRequiredService<MdiForm>();
            Application.Run(form);
        }
        
        private static IServiceProvider BuildServiceProvider()
        {
            var � = new ServiceCollection();

#if DEBUG
            �.AddSingleton<IDocumentsProvider, PseudoDocumentsProvider>();
            �.AddSingleton<IPrinter, DebugPrinter>();
#else
            �.AddSingleton<IDocumentsProvider, DocumentsProvider>();
            �.AddSingleton<IPrinter, Printer>();
#endif
            �.AddSingleton<IDocumentDataExtracter, DocumentDataExtracter>();
            �.AddSingleton<IFileValidator, FileValidator>();
            �.AddTransient<MdiForm>();

            return �.BuildServiceProvider();
        }
    }
}