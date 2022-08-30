using DocumentPrinter.Forms;
using DocumentPrinter.Models;

namespace DocumentPrinter.Contracts
{
    public interface IFormsFactory
    {
        CheckedDocumentsListForm CreateCheckedDocumentsListForm(Form? mdiParent = null);
        ChooseDocumentsForm CreateChooseDocumentForm(IEnumerable<DocumentData> documents, Form? mdiParent = null);
        ChooseNameForm CreateChooseNameForm(IEnumerable<DocumentData> documents, Form? mdiParent = null);
    }
}