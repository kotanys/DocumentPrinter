#if DEBUG
using System.Diagnostics;

namespace DocumentPrinter.DebugClasses
{
    internal class DebugPrinter : IPrinter
    {
        public void Print(string file)
        {
            Debug.WriteLine($"On release mode would print {file}");
        }

        public void Print(IEnumerable<string> files)
        {
            Debug.WriteLine("On release mode would print these files:");
            foreach (var file in files)
            {
                Debug.WriteLine($"\t{file}");
            }
        }
    }
}
#endif