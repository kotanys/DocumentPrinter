namespace DocumentPrinter
{
    public class DocumentsProvider : IDocumentsProvider
    {
        private readonly IFileValidator _fileNameValidator;
        private readonly IConfiguration _configuration;
        private readonly IMessageShower _messageShower;

        public DocumentsProvider(IFileValidator fileNameValidator, IConfiguration configuration, IMessageShower messageShower)
        {
            _fileNameValidator = fileNameValidator;
            _configuration = configuration;
            _messageShower = messageShower;
        }

        public IEnumerable<string> GetDocumentFileNames()
        {
            IEnumerable<string> files;
            string path = Environment.CurrentDirectory + @"\" + _configuration.RelativePathToDocuments;
            try
            {
                files = Directory.EnumerateFiles(path);
            }
            catch (IOException)
            {
                _messageShower.Show($"Не удалось получить документы из папки {path}");
                yield break;
            }
            foreach (var file in files)
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
