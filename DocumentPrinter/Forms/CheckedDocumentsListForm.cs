namespace DocumentPrinter.Forms
{
    public partial class CheckedDocumentsListForm : Form
    {
        public event EventHandler<ListBoxElementClickedEventArgs>? DocumentClicked;

        public CheckedDocumentsListForm()
        {
            InitializeComponent();
            MinimumSize = Size;
            MaximumSize = Size with { Height = Size.Height * 2, Width = Size.Width * 2 };
        }

        public void AddElement(string element)
        {
            listBox.Items.Add(element);
        }

        public void RemoveElement(string element)
        {
            listBox.Items.Remove(element);
        }

        private void CheckedDocumentsListForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        private void ListBoxClickHandler(object sender, EventArgs e)
        {
            if (listBox.SelectedItem is not { } selected)
            {
                return;
            }
            var args = new ListBoxElementClickedEventArgs
            {
                Element = selected.ToString()!,
            };
            DocumentClicked?.Invoke(this, args);
        }
    }
}
