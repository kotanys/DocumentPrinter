namespace DocumentPrinter.Contracts
{
    public interface IPrinter
    {
        void Print(IEnumerable<string> files);
    }
}