namespace DocumentPrinter.Forms
{
    public partial class ChooseDocumentsForm : Form
    {
        private const int ButtonHeight = 20;

        private readonly IEnumerable<string> _elements;

        public IEnumerable<string> Result
        {
            get
            {
                foreach (var checkedElement in docsListBox.CheckedItems)
                {
                    if (checkedElement is null)
                        continue;
                    yield return checkedElement.ToString()!;
                }
            }
        }

        public ChooseDocumentsForm(IEnumerable<string> elements)
        {
            InitializeComponent();
            _elements = elements;
        }

        private void FormLoadHandler(object sender, EventArgs e)
        {
            AddButtons(_elements);
            Height = ButtonHeight * (docsListBox.Items.Count + 2);
        }

        private void AddButtons(IEnumerable<string> names)
        {
            int heightForListBox = 0;
            foreach (var name in names)
            {
                docsListBox.Items.Add(name);
                heightForListBox += ButtonHeight;
            }
            docsListBox.Height = heightForListBox;
        }

        public void RemoveAllSelection()
        {
            for (int i = 0; i < docsListBox.Items.Count; i++)
            {
                docsListBox.SetItemChecked(i, false);
            }
        }
    }
}