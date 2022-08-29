namespace DocumentPrinter.Forms
{
    public class ListBoxElementClickedEventArgs : EventArgs
    {
        public string Element { get; init; } = default!;
    }
}