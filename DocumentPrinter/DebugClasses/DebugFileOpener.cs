#if DEBUG
using System.Diagnostics;

namespace DocumentPrinter.DebugClasses
{
    internal class DebugFileOpener : IFileOpener
    {
        public void Open(string file)
        {
            Debug.WriteLine($"On Release mode would open {file}");
        }
    }
}
#endif
