namespace DocumentPrinter.Models
{
    public class DocumentCheckStateChangedEventArgs : EventArgs
    {
        public CheckState NewState { get; init; }
        public DocumentData Document { get; init; }
    }
}
