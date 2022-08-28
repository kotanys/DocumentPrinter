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
            var ñ = new ServiceCollection();

#if DEBUG
            ñ.AddSingleton<IDocumentsProvider, PseudoDocumentsProvider>();
            ñ.AddSingleton<IPrinter, DebugPrinter>();
#else
            ñ.AddSingleton<IDocumentsProvider, DocumentsProvider>();
            ñ.AddSingleton<IPrinter, Printer>();
#endif
            ñ.AddSingleton<IDocumentDataExtracter, DocumentDataExtracter>();
            ñ.AddSingleton<IFileValidator, FileValidator>();
            ñ.AddTransient<MdiForm>();

            return ñ.BuildServiceProvider();
        }
    }
}