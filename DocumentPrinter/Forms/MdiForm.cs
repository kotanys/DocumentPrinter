using DocumentPrinter.Models;

namespace DocumentPrinter.Forms
{
    public partial class MdiForm : Form
    {
        private readonly IDocumentsProvider _documentsProvider;
        private readonly IDocumentDataExtracter _documentDataExtracter;
        private readonly IPrinter _printer;
        private readonly IEnumerable<DocumentData> _documents;

        private ChooseDocumentsForm? _currentdocumentsForm;
        private readonly Dictionary<string, ChooseDocumentsForm> _documentForms = new();
        private readonly ChooseNameForm _nameForm;


        public MdiForm(IDocumentsProvider documentsProvider, IDocumentDataExtracter documentDataExtracter, IPrinter printer)
        {
            _documentsProvider = documentsProvider;
            _documentDataExtracter = documentDataExtracter;
            _printer = printer;
            var files = _documentsProvider.GetDocumentFileNames();
            _documents = files.Select(_documentDataExtracter.Extract);

            InitializeComponent();
            _nameForm = CreateChooseNameForm();
            foreach (var documents in GetDatasDistinctByName(_documents))
            {
                var form = CreateChooseDocumentForm(documents.Select(d => d.DocumentName));
                _documentForms[documents.First().OwnerName] = form;
            }
            _nameForm.Show();
            _nameForm.OnNameSwitched += OnNameSwitchedHandler;
        }

        private void OnNameSwitchedHandler(object? sender, ChosenNameEditedEventArgs e)
        {
            Point? lastLocation = null;
            if (_currentdocumentsForm is not null)
            {
                _currentdocumentsForm.Hide();
                lastLocation = _currentdocumentsForm.Location;
            }
            _currentdocumentsForm = _documentForms[e.Name];
            _currentdocumentsForm.Show();
            if (lastLocation is not null)
            {
                _currentdocumentsForm.Location = lastLocation.Value;
            }
        }

        private ChooseNameForm CreateChooseNameForm()
        { 
            return new ChooseNameForm(_documents.Select(d => d.OwnerName).Distinct())
            {
                MdiParent = this
            };
        }

        private ChooseDocumentsForm CreateChooseDocumentForm(IEnumerable<string> documentNames)
        {
            return new ChooseDocumentsForm(documentNames)
            {
                MdiParent = this
            };
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

        private void ClearSelectionButtonClickHandler(object sender, EventArgs e)
        {
            foreach (var docsForm in _documentForms.Values)
            {
                docsForm.RemoveAllSelection();
            }
        }

        private void PrintButtonClickHandler(object sender, EventArgs e)
        {
            //TODO
        }
    }
}
