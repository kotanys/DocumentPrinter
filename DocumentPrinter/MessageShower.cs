using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentPrinter.Forms;

namespace DocumentPrinter
{
    public class MessageShower : IMessageShower
    {
        private readonly MdiForm _form;

        public MessageShower(MdiForm form)
        {
            _form = form;
        }

        public void Show(string message)
        {
            _form.ShowMessage(message);
        }
    }
}
