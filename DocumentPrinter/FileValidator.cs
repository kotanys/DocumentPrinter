namespace DocumentPrinter
{
    public class FileValidator : IFileValidator
    {
        private const string Separator = ".";
        private static readonly string[] JpgExtensions = { ".jpg", ".jpeg" };
        public const string FileNameFormat = "{owner name}" + Separator + "{doc name}" + Separator + "{file extension}";

        public void Validate(string filePath)
        {
            ReadOnlySpan<char> onlyFileName = Path.GetFileName((ReadOnlySpan<char>)filePath);
            int firstDotIndex = onlyFileName.IndexOf(Separator);
            int lastDotIndex = onlyFileName.LastIndexOf(Separator);
            ThrowIf(firstDotIndex == -1, "No dots in file name");
            ThrowIf(firstDotIndex == 0, "Nothing before first dot");
            ThrowIf(Math.Abs(firstDotIndex - lastDotIndex) <= 1, "Nothing in between 2 dots");
            var extension = Path.GetExtension(onlyFileName);
            ThrowIf(!ExtensionArrayContains(extension), $"Unsupported extension {extension}");
        }

        private static void ThrowIf(bool condition, string message)
        {
            if (condition)
                throw new FileValidationException(message, FileNameFormat);
        }

        private static bool ExtensionArrayContains(ReadOnlySpan<char> extension)
        {
            foreach (ReadOnlySpan<char> allowed in JpgExtensions)
            {
                if (allowed.SequenceEqual(extension))
                {
                    return true;
                }
            }
            return false;
        }
    }

    public class FileValidationException : Exception
    {
        public FileValidationException(string message, string fileNameFormat) : base(message)
        {
            FileNameFormat = fileNameFormat;
        }

        public string FileNameFormat { get; }
    }
}
