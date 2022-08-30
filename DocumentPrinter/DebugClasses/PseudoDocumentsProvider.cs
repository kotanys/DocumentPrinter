#if DEBUG
namespace DocumentPrinter.DebugClasses
{
    internal class PseudoDocumentsProvider : IDocumentsProvider
    {
        public IEnumerable<string> GetDocumentFileNames()
        {
            yield return Path.GetFullPath("Documents\\Вадим.Паспорт.jpg");
            yield return Path.GetFullPath("Documents\\Вадим.Снилс.jpeg");
            yield return Path.GetFullPath("Documents\\Наташа.Паспорт.jpg");
            yield return Path.GetFullPath("Documents\\Саша.Паспорт.jpeg");
            yield return Path.GetFullPath("Documents\\Аня.Свидетельство о Рождении.jpeg");
        }
    }
}
#endif