using DocumentPrinter.Models;

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
                OwnerName = GetFirstPart(onlyFileName).ToString().Trim(),
                DocumentName = GetMiddlePart(onlyFileName).ToString().Trim(),
                FileName = fileName,
            };
        }

        private static ReadOnlySpan<char> GetFirstPart(ReadOnlySpan<char> onlyFileName)
        {
            return onlyFileName[..onlyFileName.IndexOf(Separator)];
        }

        private static ReadOnlySpan<char> GetMiddlePart(ReadOnlySpan<char> onlyFileName)
        {
            return onlyFileName[(onlyFileName.IndexOf(Separator) + 1)..onlyFileName.LastIndexOf(Separator)];
        }
    }
}
