namespace DocumentPrinter.Models
{
    public class DocumentClickedEventArgs : EventArgs
    {
        public DocumentData Document { get; init; }
    }
}