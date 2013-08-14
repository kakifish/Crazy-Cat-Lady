using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cats.EditorFolder
{
    public class EditorBL
    {
        private readonly EditorDAL _editorDal = new EditorDAL();

        public Editor GetEditor(string userName)
        {
            return _editorDal.GetEditor(userName);
        }

        public Boolean IsEditorExist(string userName)
        {
            return _editorDal.GetEditor(userName) != null;
        }

        //We can add an existing product too
        public Boolean AddEditor(Editor editor)
        {
            var editorBl = new EditorBL();
            if (editorBl.IsEditorExist(editor.GetUserName()))
            {
                return false;
            }
            _editorDal.AddEditor(editor);
            return true;
        }

        public LinkedList<Editor> GetAllEditors()
        {
            return _editorDal.GetAllEditors();
        }

        public void DeleteEditor(string userName)
        {
            _editorDal.DeleteEditor(userName);
        }
    }
}