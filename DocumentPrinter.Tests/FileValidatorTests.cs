namespace DocumentPrinter.Tests
{
    public class FileValidatorTests
    {
        private readonly FileValidator _sut = new();

        [Fact]
        public void ShouldCorrectlyValidateFile()
        {
            Action validation = () =>
            {
                const string correctFile = "Вадим.Документ с. точками..jpg";
                _sut.Validate(correctFile);
            };
            validation.Should().NotThrow();
        }

        [Fact]
        public void ShouldCorrectlyValidateFileWithPath()
        {
            Action validation = () =>
            {
                const string correctFile = @"C:\directory\папка на русском с точкой.\Вадим.Документ с. точками..jpg";
                _sut.Validate(correctFile);
            };
            validation.Should().NotThrow();
        }

        [Theory]
        [InlineData(".Паспорт.jpg", "Nothing before first dot")]
        [InlineData("Вадим,Паспорт", "No dots in file name")]
        [InlineData("Вадим..jpeg", "Nothing in between 2 dots")]
        [InlineData("Вадим.Паспорт.exe", "Unsupported extension .exe")]
        public void ShouldThrowFileValidationException(string incorrect, string exceptionMessage)
        {
            Action validation = () => _sut.Validate(incorrect);
            validation.Should().Throw<FileValidationException>()
                .WithMessage(exceptionMessage);
        }
    }
}
