namespace DocumentPrinter.Models
{
    public class ChosenNameEditedEventArgs : EventArgs
    {
        public string Name { get; }

        public ChosenNameEditedEventArgs(string name)
        {
            Name = name;
        }
    }
}