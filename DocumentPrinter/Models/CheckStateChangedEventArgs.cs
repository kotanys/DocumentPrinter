namespace DocumentPrinter.Models
{
    public class CheckStateChangedEventArgs : EventArgs
    {
        public CheckState NewState { get; init; }
        public string Value { get; init; } = default!;
    }
}
