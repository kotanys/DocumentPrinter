namespace DocumentPrinter
{
    public class DocumentsProvider : IDocumentsProvider
    {
        private readonly IFileNameValidator _fileNameValidator;

        public DocumentsProvider(IFileNameValidator fileNameValidator)
        {
            _fileNameValidator = fileNameValidator;
        }

        public IEnumerable<string> GetDocumentFileNames()
        {
            foreach (var file in Directory.EnumerateFiles(Environment.CurrentDirectory))
            {
                try
                {
                    _fileNameValidator.Validate(file);
                }
                catch (FileNameValidationException)
                {
                    continue;
                }
                yield return file;
            }
        }
    }
}
