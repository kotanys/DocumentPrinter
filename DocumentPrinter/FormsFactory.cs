using DocumentPrinter.Forms;
using DocumentPrinter.Models;

namespace DocumentPrinter
{
    internal class FormsFactory : IFormsFactory
    {
        public ChooseNameForm CreateChooseNameForm(IEnumerable<DocumentData> documents, Form? mdiParent = null)
        {
            var form = new ChooseNameForm(documents.Select(d => d.OwnerName).Distinct())
            {
                MdiParent = mdiParent
            };
            return form;
        }

        public ChooseDocumentsForm CreateChooseDocumentForm(IEnumerable<DocumentData> documents, Form? mdiParent = null)
        {
            var form = new ChooseDocumentsForm(documents)
            {
                MdiParent = mdiParent
            };
            return form;
        }

        public CheckedDocumentsListForm CreateCheckedDocumentsListForm(Form? mdiParent = null)
        {
            var form = new CheckedDocumentsListForm()
            {
                MdiParent = mdiParent
            };
            return form;
        }
    }
}
