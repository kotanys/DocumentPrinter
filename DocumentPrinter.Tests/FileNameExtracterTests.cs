using DocumentPrinter.Contracts;
using DocumentPrinter.Models;

namespace DocumentPrinter.Tests
{
    public class FileNameExtracterTests
    {
        private readonly DocumentDataExtracter _sut = new(Substitute.For<IFileValidator>());

        [Theory]
        [InlineData("Вадим.Паспорт.jpg", "Вадим", "Паспорт")]
        [InlineData("Анна.Свидетельство о рождении.jpg", "Анна", "Свидетельство о рождении")]
        [InlineData("Наташа.Какой-то документ.с точкой.jpeg", "Наташа", "Какой-то документ.с точкой")]
        public void TestOnlyFileName(string fileName, string ownerName, string documentName)
        {
            var expected = new DocumentData
            {
                FileName = fileName,
                OwnerName = ownerName,
                DocumentName = documentName
            };
            var actual = _sut.Extract(fileName);
            actual.Should().Be(expected);
        }

        [Fact]
        public void TestFileNameWithPath()
        {
            string filePath = @"D:\directory.\папка на русском с пробелами\Вадим.Паспорт.jpeg";
            var expected = new DocumentData
            {
                DocumentName = "Паспорт",
                OwnerName = "Вадим",
                FileName = filePath,
            };
            var actual = _sut.Extract(filePath);
            actual.Should().Be(expected);
        }
    }
}