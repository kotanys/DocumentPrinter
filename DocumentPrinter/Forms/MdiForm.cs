using DocumentPrinter.Models;

namespace DocumentPrinter.Forms
{
    public partial class MdiForm : Form
    {
        private readonly IDocumentsProvider _documentsProvider;
        private readonly IDocumentDataExtracter _documentDataExtracter;
        private readonly IPrinter _printer;
        private readonly IFileOpener _fileOpener;
        private readonly IConfiguration _configuration;
        private readonly DocumentData[] _documents;

        private ChooseDocumentsForm? _currentDocumentsForm;
        private readonly Dictionary<string, ChooseDocumentsForm> _documentForms = new();
        private readonly ChooseNameForm _nameForm;
        private readonly CheckedDocumentsListForm _checkedDocumentsListForm;

        public MdiForm(IDocumentsProvider documentsProvider, IDocumentDataExtracter documentDataExtracter, IPrinter printer, IFileOpener fileOpener, IConfiguration configuration)
        {
            _documentsProvider = documentsProvider;
            _documentDataExtracter = documentDataExtracter;
            _printer = printer;
            _fileOpener = fileOpener;
            _configuration = configuration;
            var files = _documentsProvider.GetDocumentFileNames();
            _documents = files.Select(_documentDataExtracter.Extract).ToArray();

            InitializeComponent();
            _nameForm = CreateChooseNameForm();
            _checkedDocumentsListForm = CreateCheckedDocumentsListForm();
            foreach (var documents in GetDatasDistinctByName(_documents))
            {
                var form = CreateChooseDocumentForm(documents);
                _documentForms[documents.First().OwnerName] = form;
            }
            _nameForm.Show();
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        private void DocumentCheckStateChangerHandler(object? sender, CheckStateChangedEventArgs e)
        {
            var path = _documents.Where(d => d.OwnerName == _nameForm.CurrentName && d.DocumentName == e.Value).Single().FileName;
            var file = Path.GetFileName(path);
            switch (e.NewState)
            {
                case CheckState.Unchecked:
                    _checkedDocumentsListForm.RemoveElement(file);
                    break;
                case CheckState.Checked:
                    _checkedDocumentsListForm.AddElement(file);
                    break;
                case CheckState.Indeterminate:
                default:
                    break;
            }
        }

        private void NameSwitchedHandler(object? sender, ChosenNameEditedEventArgs e)
        {
            var lastFormSettings = FormSettings.GetFrom(_currentDocumentsForm ?? _documentForms.First().Value);
            _currentDocumentsForm?.Hide();
            _currentDocumentsForm = _documentForms[e.Name];
            _currentDocumentsForm.Show();
            lastFormSettings?.SetTo(_currentDocumentsForm);
        }

        private ChooseNameForm CreateChooseNameForm()
        { 
            var form = new ChooseNameForm(_documents.Select(d => d.OwnerName).Distinct())
            {
                MdiParent = this
            };
            form.NameSwitched += NameSwitchedHandler;
            return form;
        }

        private ChooseDocumentsForm CreateChooseDocumentForm(IEnumerable<DocumentData> documents)
        {
            var form = new ChooseDocumentsForm(documents)
            {
                MdiParent = this
            };
            form.DocumentCheckStateChanged += DocumentCheckStateChangerHandler;
            return form;
        }

        private CheckedDocumentsListForm CreateCheckedDocumentsListForm()
        {
            var form = new CheckedDocumentsListForm()
            {
                MdiParent = this
            };
            form.DocumentClicked += CheckedDocumentsListFormElementClickedHandler;
            return form;
        }

        private void CheckedDocumentsListFormElementClickedHandler(object? sender, ListBoxElementClickedEventArgs e)
        {
            var file = _documents.Single(
                d => Path.GetFileName((ReadOnlySpan<char>) d.FileName).SequenceEqual(e.Element)).FileName;
            _fileOpener.Open(file);
        }

        private void ClearSelectionButtonClickHandler(object sender, EventArgs e)
        {
            _checkedDocumentsListForm.RemoveAll();
            foreach (var docsForm in _documentForms.Values)
            {
                docsForm.RemoveAllSelection();
            }
        }

        private void PrintButtonClickHandler(object sender, EventArgs e)
        {
            var toPrint = _documentForms.Values.SelectMany(f => f.ChosenDocuments);
            _printer.Print(toPrint);
        }

        private void ChosenDocumentsButtonClickHandler(object sender, EventArgs e)
        {
            _checkedDocumentsListForm.Show();
        }

        private static IEnumerable<IEnumerable<DocumentData>> GetDatasDistinctByName(IEnumerable<DocumentData> documents)
        {
            var dictionary = new Dictionary<string, List<DocumentData>>();
            foreach (var document in documents)
            {
                if (!dictionary.TryGetValue(document.OwnerName, out _))
                {
                    dictionary[document.OwnerName] = new List<DocumentData>();
                }
                dictionary[document.OwnerName].Add(document);
            }
            return dictionary.Values;
        }

        private record FormSettings(Point Location, Size Size)
        {
            public void SetTo(Form form)
            {
                form.Location = Location;
                form.Size = Size;
            }

            public static FormSettings GetFrom(Form form)
            {
                return new FormSettings(form.Location, form.Size);
            }
        }
    }
}
