namespace DocumentPrinter.Contracts
{
    public interface IFileOpener
    {
        void Open(string file);
        void OpenDirectory(string directory);
    }
}