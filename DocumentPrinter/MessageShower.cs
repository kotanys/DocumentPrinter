namespace DocumentPrinter
{
    public class MessageShower : IMessageShower
    {
        public void Show(string message)
        {
            MessageBox.Show(message);
        }
    }
}
