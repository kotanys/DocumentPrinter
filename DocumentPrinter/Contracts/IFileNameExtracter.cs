namespace DocumentPrinter.Contracts
{
    public interface IDocumentDataExtracter
    {
        DocumentData Extract(string fileName);
    }
}