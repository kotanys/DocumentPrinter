using System.Drawing.Printing;

namespace DocumentPrinter
{
    public class Printer : IPrinter
    {
        public void Print(string file)
        {
            if (GetPrinterSettings() is not { } settings)
            {
                return;
            }
            Print(file, settings);
        }

        public void Print(IEnumerable<string> files)
        {
            if (GetPrinterSettings() is not { } settings)
            {
                return;
            }
            foreach (var file in files)
            {
                Print(file, settings);
            }
        }

        private static void Print(string file, PrinterSettings settings)
        {
            using var document = new PrintDocument();
            document.PrintPage += (sender, e) =>
            {
                using var image = Image.FromFile(file);
                e.Graphics!.DrawImage(image, Point.Empty);
            };
            document.PrinterSettings = settings;
            document.Print();
        }

        private static PrinterSettings? GetPrinterSettings()
        {
            using var printDialog = new PrintDialog();
            var dialogResult = printDialog.ShowDialog();
            if (dialogResult != DialogResult.OK)
            {
                return null;
            }
            return printDialog.PrinterSettings;
        }
    }
}
