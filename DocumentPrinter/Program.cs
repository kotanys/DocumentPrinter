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
            var services = new ServiceCollection();
            
#if DEBUG
            services.AddSingleton<IDocumentsProvider, PseudoDocumentsProvider>();
            services.AddSingleton<IPrinter, DebugPrinter>();
            services.AddSingleton<IFileOpener, DebugFileOpener>();
#else
            services.AddSingleton<IDocumentsProvider, DocumentsProvider>();
            services.AddSingleton<IPrinter, Printer>();
            services.AddSingleton<IFileOpener, FileOpener>();
#endif
            services.AddSingleton<IDocumentDataExtracter, DocumentDataExtracter>();
            services.AddSingleton<IFileValidator, FileValidator>();
            services.AddTransient<MdiForm>();

            return services.BuildServiceProvider();
        }
    }
}