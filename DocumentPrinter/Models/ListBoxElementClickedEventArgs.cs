namespace DocumentPrinter.Models
{
    public class ListBoxElementClickedEventArgs : EventArgs
    {
        public string Element { get; init; } = default!;
    }
}