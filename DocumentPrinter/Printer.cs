using System.Drawing.Printing;
using DocumentPrinter.Models;

namespace DocumentPrinter
{
    public class Printer : IPrinter
    {
        public void Print(IEnumerable<DocumentData> files)
        {
            using var session = new PrintSession(files);
            session.Print();
        }

        private struct PrintSession : IDisposable
        {
            private readonly PrintDocument _document = new()
            {
                DocumentName = "Файлы DocumentPrinter"
            };
            private readonly IEnumerator<DocumentData> _fileEnumerator;

            public PrintSession(IEnumerable<DocumentData> files)
            {
                _fileEnumerator = files.ToList().GetEnumerator();

                _document.BeginPrint += BeginPrintHandler;
                _document.PrintPage += PrintPageHandler;
            }

            public void Print()
            {
                _fileEnumerator.Reset();
                if (!_fileEnumerator.MoveNext())
                {
                    return;
                }
                _document.Print();
            }

            private void PrintPageHandler(object sender, PrintPageEventArgs e)
            {
                e.Graphics?.Clear(Color.White);
                using var image = Image.FromFile(_fileEnumerator.Current.FileName);
                e.Graphics?.DrawImage(image, Point.Empty);
                e.HasMorePages = _fileEnumerator.MoveNext();
            }

            private void BeginPrintHandler(object sender, PrintEventArgs e)
            {
                using var printDialog = new PrintDialog
                {
                    Document = _document
                };
                var dialogResult = printDialog.ShowDialog();
                if (dialogResult != DialogResult.OK)
                {
                    e.Cancel = true;
                    return;
                }
                _document.PrinterSettings = printDialog.PrinterSettings;
            }

            public void Dispose()
            {
                _document.Dispose();
                _fileEnumerator.Dispose();
            }
        }
    }
}
