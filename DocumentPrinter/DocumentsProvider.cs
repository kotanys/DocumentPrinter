namespace DocumentPrinter
{
    public class DocumentsProvider : IDocumentsProvider
    {
        private readonly IFileValidator _fileNameValidator;

        public DocumentsProvider(IFileValidator fileNameValidator)
        {
            _fileNameValidator = fileNameValidator;
        }

        public IEnumerable<string> GetDocumentFileNames()
        {
            foreach (var file in Directory.EnumerateFiles(Environment.CurrentDirectory + @"\Documents"))
            {
                try
                {
                    _fileNameValidator.Validate(file);
                }
                catch (FileValidationException)
                {
                    continue;
                }
                yield return file;
            }
        }
    }
}
