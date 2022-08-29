#if DEBUG
namespace DocumentPrinter.DebugClasses
{
    internal class PseudoDocumentsProvider : IDocumentsProvider
    {
        public IEnumerable<string> GetDocumentFileNames()
        {
            yield return Path.GetFullPath("Вадим.Паспорт.jpg");
            yield return "Вадим.Снилс.jpeg";
            yield return "Наташа.Паспорт.jpg";
            yield return "Саша.Паспорт.jpeg";
            yield return "Аня.Свидетельство о Рождении.jpeg";
        }
    }
}
#endif