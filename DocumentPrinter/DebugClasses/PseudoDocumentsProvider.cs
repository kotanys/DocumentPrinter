namespace DocumentPrinter.DebugClasses
{
    public class PseudoDocumentsProvider : IDocumentsProvider
    {
        public IEnumerable<string> GetDocumentFileNames()
        {
            yield return "Вадим.Паспорт.jpg";
            yield return "Вадим.Снилс.jpeg";
            yield return "Наташа.Паспорт.jpg";
            yield return "Саша.Паспорт.jpeg";
            yield return "Аня.Свидетельство о Рождении.jpeg";
        }
    }
}
