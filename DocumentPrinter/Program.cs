using System.Diagnostics;
using DocumentPrinter.DebugClasses;
using Microsoft.Extensions.DependencyInjection;

namespace DocumentPrinter
{
    internal static class Program
    {
        private static readonly IServiceProvider _services = BuildServiceProvider();
        private static IEnumerable<DocumentData> _documents = GetDocumentsData();

        [STAThread]
        private static int Main()
        {
            ApplicationConfiguration.Initialize();

            var chosenName = GetOwnerName();
            if (chosenName is null)
            {
                Debug.WriteLine("No name was chosen. Exiting app.");
                return 1;
            }

            var chosenDocuments = GetDocumentNames(chosenName);
            if (!chosenDocuments.Any())
            {
                Debug.WriteLine("No document was chosen. Exiting app.");
                return 1;
            }

            var filesToPrint = _documents.Where(d => chosenDocuments.Contains(d.DocumentName));
            Print(filesToPrint.Select(f => f.FileName));
            return 0;
        }

        private static string? GetOwnerName()
        {
            var choiceForm = new ChooseNameForm(_documents.Select(d => d.OwnerName).Distinct());
            Application.Run(choiceForm);
            choiceForm.Dispose();
            return choiceForm.Result;
        }

        private static IEnumerable<string> GetDocumentNames(string chosenName)
        {
            _documents = _documents.Where(d => d.OwnerName == chosenName);
            var choiceForm = new ChooseDocumentsForm(
                _documents.Select(d => d.DocumentName).Distinct());
            Application.Run(choiceForm);
            choiceForm.Dispose();
            return choiceForm.Results;
        }

        private static void Print(IEnumerable<string> filesToPrint)
        {
#if DEBUG
            foreach (var file in filesToPrint)
            {
                Debug.WriteLine($"On Release mode, would print {file}");
            }
#else
            var printer = _services.GetRequiredService<IPrinter>();
            printer.Print(filesToPrint);
#endif
        }

        private static IEnumerable<DocumentData> GetDocumentsData()
        {
            var documentsProvider = _services.GetRequiredService<IDocumentsProvider>();
            var documentsDataExtracter = _services.GetRequiredService<IDocumentDataExtracter>();
            var documents = documentsProvider.GetDocumentFileNames().Select(f => documentsDataExtracter.Extract(f))
                .OrderBy(d => d.OwnerName).ThenBy(d => d.DocumentName);
            return documents;
        }

        private static IServiceProvider BuildServiceProvider()
        {
            var ñ = new ServiceCollection();

#if DEBUG
            ñ.AddSingleton<IDocumentsProvider, PseudoDocumentsProvider>();
#else
            ñ.AddSingleton<IDocumentsProvider, DocumentsProvider>();
#endif
            ñ.AddSingleton<IDocumentDataExtracter, FileNameExtracter>();
            ñ.AddSingleton<IPrinter, Printer>();
            ñ.AddSingleton<IFileNameValidator, FileNameValidator>();

            return ñ.BuildServiceProvider();
        }
    }
}