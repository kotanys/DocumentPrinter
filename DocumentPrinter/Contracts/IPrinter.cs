using DocumentPrinter.Models;

namespace DocumentPrinter.Contracts
{
    public interface IPrinter
    {
        void Print(IEnumerable<DocumentData> files);
    }
}