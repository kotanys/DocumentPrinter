using DocumentPrinter.Contracts;
using DocumentPrinter.Models;

namespace DocumentPrinter.Tests
{
    public class FileNameExtracterTests
    {
        private readonly DocumentDataExtracter _sut = new(Substitute.For<IFileValidator>());

        [Theory]
        [InlineData("�����.�������.jpg", "�����", "�������")]
        [InlineData("����.������������� � ��������.jpg", "����", "������������� � ��������")]
        [InlineData("������.�����-�� ��������.� ������.jpeg", "������", "�����-�� ��������.� ������")]
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
            string filePath = @"D:\directory.\����� �� ������� � ���������\�����.�������.jpeg";
            var expected = new DocumentData
            {
                DocumentName = "�������",
                OwnerName = "�����",
                FileName = filePath,
            };
            var actual = _sut.Extract(filePath);
            actual.Should().Be(expected);
        }
    }
}