#if DEBUG
using System.Diagnostics;
using DocumentPrinter.Models;

namespace DocumentPrinter.DebugClasses
{
    internal class DebugPrinter : IPrinter
    {
        public void Print(IEnumerable<DocumentData> files)
        {
            Debug.WriteLine("On release mode would print these files:");
            foreach (var file in files)
            {
                Debug.WriteLine($"\t{file.FileName}");
            }
        }
    }
}
#endif