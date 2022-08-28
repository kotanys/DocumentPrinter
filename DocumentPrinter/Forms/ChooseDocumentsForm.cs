using DocumentPrinter.Models;

namespace DocumentPrinter.Forms
{
    public partial class ChooseDocumentsForm : Form
    {
        private const int ButtonHeight = 20;

        private readonly DocumentData[] _elements;

        public IEnumerable<DocumentData> Result
        {
            get
            {
                foreach (int i in docsListBox.CheckedIndices)
                {
                    yield return _elements[i];
                }
            }
        }

        public ChooseDocumentsForm(IEnumerable<DocumentData> elements)
        {
            InitializeComponent();
            _elements = elements.ToArray();
        }

        private void FormLoadHandler(object sender, EventArgs e)
        {
            AddButtons(_elements);
            Height = ButtonHeight * (docsListBox.Items.Count + 2);
        }

        private void AddButtons(IEnumerable<DocumentData> datas)
        {
            int heightForListBox = 0;
            foreach (var data in datas)
            {
                docsListBox.Items.Add(data.DocumentName);
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