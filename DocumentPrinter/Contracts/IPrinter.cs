namespace DocumentPrinter.Contracts
{
    public interface IPrinter
    {
        void Print(string file);
        void Print(IEnumerable<string> files);
    }
}