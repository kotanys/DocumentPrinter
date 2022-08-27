namespace DocumentPrinter
{
    public class DocumentDataExtracter : IDocumentDataExtracter
    {
        private const string Separator = ".";

        private readonly IFileValidator _validator;

        public DocumentDataExtracter(IFileValidator validator)
        {
            _validator = validator;
        }

        public DocumentData Extract(string fileName)
        {
            _validator.Validate(fileName);
            ReadOnlySpan<char> fileNameSpan = fileName;
            var onlyFileName = Path.GetFileName(fileNameSpan);
            return new DocumentData
            {
                OwnerName = onlyFileName[..onlyFileName.IndexOf(Separator)].ToString(),
                DocumentName = onlyFileName[(onlyFileName.IndexOf(Separator) + 1)..onlyFileName.LastIndexOf(Separator)].ToString(),
                FileName = fileName,
            };
        }
    }
}
