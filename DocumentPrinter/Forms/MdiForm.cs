﻿using DocumentPrinter.Models;

namespace DocumentPrinter.Forms
{
    public partial class MdiForm : Form
    {
        private readonly IDocumentsProvider _documentsProvider;
        private readonly IDocumentDataExtracter _documentDataExtracter;
        private readonly IPrinter _printer;
        private readonly IFileOpener _fileOpener;
        private readonly IFormsFactory _formsFactory;
        private readonly DocumentData[] _documents;

        private ChooseDocumentsForm? _currentDocumentsForm;
        private readonly Dictionary<string, ChooseDocumentsForm> _documentForms = new();
        private readonly ChooseNameForm _nameForm;
        private readonly CheckedDocumentsListForm _checkedDocumentsListForm;
        private readonly IConfiguration _configuration;

        public MdiForm(IDocumentsProvider documentsProvider, IDocumentDataExtracter documentDataExtracter, IPrinter printer, IFileOpener fileOpener, IFormsFactory formsFactory, IConfiguration configuration)
        {
            _documentsProvider = documentsProvider;
            _documentDataExtracter = documentDataExtracter;
            _printer = printer;
            _fileOpener = fileOpener;
            _formsFactory = formsFactory;
            var files = _documentsProvider.GetDocumentFileNames();
            _documents = files.Select(_documentDataExtracter.Extract).ToArray();

            InitializeComponent();
            _nameForm = _formsFactory.CreateChooseNameForm(_documents, mdiParent: this);
            _checkedDocumentsListForm = _formsFactory.CreateCheckedDocumentsListForm(mdiParent: this);
            foreach (var documents in GetDatasDistinctByName(_documents))
            {
                var form = _formsFactory.CreateChooseDocumentForm(documents, mdiParent: this);
                _documentForms[documents.First().OwnerName] = form;
            }
            ConfigureEventHandlers();
            _nameForm.Show();
            this._configuration = configuration;
        }

        private void ConfigureEventHandlers()
        {
            _nameForm.NameSwitched += NameSwitchedHandler;
            _checkedDocumentsListForm.DocumentClicked += DocumentClickedHandler;
            foreach (var form in _documentForms.Values)
            {
                form.DocumentCheckStateChanged += DocumentCheckStateChangedHandler;
            }
        }

        private void DocumentCheckStateChangedHandler(object? sender, DocumentCheckStateChangedEventArgs e)
        {
            var document = e.Document;
            switch (e.NewState)
            {
                case CheckState.Unchecked:
                    _checkedDocumentsListForm.RemoveDocument(document);
                    break;
                case CheckState.Checked:
                    _checkedDocumentsListForm.AddDocument(document);
                    break;
            }
        }

        private void NameSwitchedHandler(object? sender, ChosenNameEditedEventArgs e)
        {
            var lastFormSettings = FormSettings.GetFrom(_currentDocumentsForm ?? _documentForms.First().Value);
            _currentDocumentsForm?.Hide();
            _currentDocumentsForm = _documentForms[e.Name];
            _currentDocumentsForm.Show();
            lastFormSettings.SetTo(_currentDocumentsForm);
        }

        private void DocumentClickedHandler(object? sender, DocumentClickedEventArgs e)
        {
            var file = e.Document.FileName;
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

        private void OnFormClosingHandler(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void OnOpenDocumentsFolderButtonPressedHandler(object sender, EventArgs e)
        {
            var absolutePath = Path.GetFullPath(_configuration.RelativePathToDocuments);
            _fileOpener.OpenDirectory(absolutePath);
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
