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
                foreach (int i in documentNameListBox.CheckedIndices)
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
            Height = ButtonHeight * (documentNameListBox.Items.Count + 2);
            MinimumSize = Size;
            MaximumSize = Size with { Width = Size.Width * 2 };
        }

        private void AddButtons(IEnumerable<DocumentData> datas)
        {
            int heightForListBox = 0;
            foreach (var data in datas)
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
            }
        }

        /// <summary>
        /// для правильной работы курсора
        /// </summary>
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == 0x84) //WM_NCHITTEST
                m.Result = (HitTest) m.Result switch
                {
                    HitTest.Top or HitTest.Bottom => (nint)HitTest.Caption,
                    HitTest.TopLeft or HitTest.BottomLeft => (nint)HitTest.Left,
                    HitTest.TopRight or HitTest.BottomRight => (nint)HitTest.Right,
                    _ => m.Result
                };
        }
    }
}