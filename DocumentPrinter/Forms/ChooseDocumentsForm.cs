using DocumentPrinter.Models;

namespace DocumentPrinter.Forms
{
    public partial class ChooseDocumentsForm : Form
    {
        private const int ButtonHeight = 20;

        private readonly CheckState[] _selectedIndices;
        private readonly DocumentData[] _documents;

        public IEnumerable<DocumentData> ChosenDocuments
        {
            get
            {
                foreach (int i in documentNameListBox.CheckedIndices)
                {
                    yield return _documents[i];
                }
            }
        }

        public event EventHandler<DocumentCheckStateChangedEventArgs>? DocumentCheckStateChanged;

        public ChooseDocumentsForm(IEnumerable<DocumentData> documents)
        {
            InitializeComponent();
            _documents = documents.ToArray();
            _selectedIndices = new CheckState[_documents.Length];
            AddButtons();
            Height = ButtonHeight * (documentNameListBox.Items.Count + 2);
            MinimumSize = Size;
            MaximumSize = Size with { Width = Size.Width * 2 };
        }

        private void AddButtons()
        {
            int heightForListBox = 0;
            foreach (var data in _documents)
            {
                documentNameListBox.Items.Add(data.DocumentName);
                heightForListBox += ButtonHeight;
            }
            documentNameListBox.Height = heightForListBox;
        }

        public void RemoveAllSelection()
        {
            for (int i = 0; i < documentNameListBox.Items.Count; i++)
            {
                documentNameListBox.SetItemChecked(i, false);
                _selectedIndices[i] = CheckState.Unchecked;
            }
        }

        private void DocumentNameListBoxSelectedValueChangedHandler(object sender, EventArgs e)
        {
            for (int i = 0; i < documentNameListBox.Items.Count; i++)
            {
                CheckState checkStateOfCurrentButton = documentNameListBox.GetItemCheckState(i);
                if (checkStateOfCurrentButton != _selectedIndices[i])
                {
                    var eventArgs = new DocumentCheckStateChangedEventArgs
                    {
                        NewState = _selectedIndices[i] = checkStateOfCurrentButton,
                        Document = _documents[i]
                    };
                    DocumentCheckStateChanged?.Invoke(this, eventArgs);
                }
            }
        }

        /// <summary>
        /// для правильной работы курсора
        /// </summary>
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == 0x84) //WM_NCHITTEST
                m.Result = (HitTest)m.Result switch
                {
                    HitTest.Top or HitTest.Bottom => (nint)HitTest.Caption,
                    HitTest.TopLeft or HitTest.BottomLeft => (nint)HitTest.Left,
                    HitTest.TopRight or HitTest.BottomRight => (nint)HitTest.Right,
                    _ => m.Result
                };
        }
    }
}