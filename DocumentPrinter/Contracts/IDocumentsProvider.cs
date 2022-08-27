namespace DocumentPrinter.Contracts
{
    public interface IDocumentsProvider
    {
        IEnumerable<string> GetDocumentFileNames();
    }
}