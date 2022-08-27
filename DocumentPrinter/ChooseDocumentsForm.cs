namespace DocumentPrinter
{
    public partial class ChooseDocumentsForm : Form
    {
        private const int ButtonHeight = 20;

        private readonly IEnumerable<string> _elements;

        public IEnumerable<string> Results
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
            Height = (int)(ButtonHeight * (docsListBox.Items.Count + 3.5));
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

        private void ConfirmClickHandler(object sender, EventArgs e)
        {
            if (docsListBox.CheckedItems.Count == 0)
            {
                return;
            }
            Close();
        }
    }
}