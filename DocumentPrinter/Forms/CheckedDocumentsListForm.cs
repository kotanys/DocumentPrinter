using DocumentPrinter.Models;

namespace DocumentPrinter.Forms
{
    public partial class CheckedDocumentsListForm : Form
    {
        private const int MaximumSizeMultiplier = 3;

        private readonly List<DocumentData> _documents = new();
        private readonly LoopSwitcher<DocumentFormatter> _documentFormatterLoop = new(new[] { DocumentFormatter.UserFriendly, DocumentFormatter.FileName });

        public event EventHandler<DocumentClickedEventArgs>? DocumentClicked;

        public CheckedDocumentsListForm()
        {
            InitializeComponent();
            MinimumSize = Size;
            MaximumSize = Size * MaximumSizeMultiplier;
        }

        public void AddDocument(DocumentData document)
        {
            _documents.Add(document);
            UpdateListPresenter();
        }

        public void RemoveDocument(DocumentData document)
        {
            _documents.Remove(document);
            UpdateListPresenter();
        }

        public void RemoveAll()
        {
            listBox.Items.Clear();
            UpdateListPresenter();
        }

        private void UpdateListPresenter()
        {
            listBox.Items.Clear();
            listBox.Items.AddRange(_documents.Select(_documentFormatterLoop.Current.Format).ToArray());
        }

        private void CheckedDocumentsListFormClosingHandler(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        private void ListBoxClickHandler(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex == -1)
            {
                return;
            }
            var args = new DocumentClickedEventArgs
            {
                Document = _documents[listBox.SelectedIndex],
            };
            DocumentClicked?.Invoke(this, args);
        }

        private void ChangeDocumentFormatButtonClickHandler(object sender, EventArgs e)
        {
            _documentFormatterLoop.Next();
            UpdateListPresenter();
        }

        private class DocumentFormatter
        {
            public static DocumentFormatter FileName => new(data => data.FileName);
            public static DocumentFormatter UserFriendly => new(data => $"{data.OwnerName}: {data.DocumentName}");

            private readonly Func<DocumentData, string> _formatter;

            public DocumentFormatter(Func<DocumentData, string> formatter)
            {
                _formatter = formatter;
            }

            public string Format(DocumentData data) => _formatter(data);
        }

        private class LoopSwitcher<T>
        {
            private readonly IEnumerator<T> _enumerator;

            public LoopSwitcher(IEnumerable<T> values)
            {
                _enumerator = values.GetEnumerator();
                if (_enumerator.MoveNext() == false)
                    throw new ArgumentException("Enumerable was empty", nameof(values));
            }

            public T Current => _enumerator.Current;

            public T Next()
            {
                if (_enumerator.MoveNext() == false)
                {
                    _enumerator.Reset();
                    _enumerator.MoveNext();
                }
                return Current;
            }
        }
    }
}
