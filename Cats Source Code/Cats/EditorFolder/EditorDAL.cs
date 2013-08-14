using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Cats.EditorFolder
{
    public class EditorDAL
    {
        private static string GetConnectionString()
        {
            return "Data Source=KAKIFISH;Initial Catalog=CatsDB;Integrated Security=True";
        }

        public Editor GetEditor(string userName)
        {
            userName = userName.Trim();
            Editor editor = null;

            var conn = new SqlConnection(GetConnectionString());
            var sql = "SELECT * FROM Editors WHERE [Username] = '" + userName + "'";

            try
            {
                conn.Open();
                var cmd = new SqlCommand(sql, conn);
                var editorReader = cmd.ExecuteReader();
                if (editorReader.HasRows)
                {
                    editorReader.Read();
                    editor = new Editor(Convert.ToString(editorReader["First Name"]).Trim(),
                        Convert.ToString(editorReader["Last Name"]).Trim(),
                        Convert.ToString(editorReader["Username"]).Trim(),
                        Convert.ToString(editorReader["Password"]),
                        Convert.ToString(editorReader["Email"]).Trim(),
                        Convert.ToInt32(editorReader["Authorized"]));
                }
            }
            catch (SqlException ex)
            {
                var msg = "GetEditor Sql Error: ";
                msg += ex.Message;
                throw new Exception(msg);
            }
            finally
            {
                conn.Close();
            }
            return editor;
        }

        public void AddEditor(Editor editor)
        {
            var conn = new SqlConnection(GetConnectionString());
            var sql = "INSERT INTO Editors VALUES('" + editor.GetFirstName().Trim() + "','" + editor.GetLastName().Trim() + "','" + editor.GetUserName().Trim() + "','" + editor.GetPassword().Trim() + "','" + editor.GetEmail().Trim() + "','" + editor.GetAuthorized() + "')";
            try
            {
                conn.Open();
                var cmd = new SqlCommand(sql, conn);

                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                var msg = "AddEditor Sql Error: ";
                msg += ex.Message;
                throw new Exception(msg);
            }
            finally
            {
                conn.Close();
            }
        }

        public LinkedList<Editor> GetAllEditors()
        {
            var editorsList = new LinkedList<Editor>();

            var conn = new SqlConnection(GetConnectionString());
            const string sql = "SELECT * FROM Editors";

            try
            {
                conn.Open();
                var cmd = new SqlCommand(sql, conn);
                var editorsReader = cmd.ExecuteReader();
                if (editorsReader.HasRows)
                {
                    while (editorsReader.Read())
                    {
                        var editor = new Editor(Convert.ToString(editorsReader["First Name"]).Trim(),
                                             Convert.ToString(editorsReader["Last Name"]).Trim(),
                                             Convert.ToString(editorsReader["Username"]).Trim(),
                                             Convert.ToString(editorsReader["Password"]).Trim(),
                                             Convert.ToString(editorsReader["email"]).Trim(),
                                             Convert.ToInt32(editorsReader["Authorized"]));

                        if (editorsList.Count == 0)
                        {
                            editorsList.AddFirst(editor);
                        }
                        else
                        {
                            editorsList.AddAfter(editorsList.Last, editor);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                var msg = "GetAllEditors Sql Error: ";
                msg += ex.Message;
                throw new Exception(msg);
            }
            finally
            {
                conn.Close();
            }
            return editorsList;
        }

        public void DeleteEditor(string userName)
        {
            var conn = new SqlConnection(GetConnectionString());
            var sql = "DELETE FROM Editors WHERE [Username]='" + userName + "'";

            try
            {
                conn.Open();
                var cmd = new SqlCommand(sql, conn);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                var msg = "DeleteEditor Sql Error: ";
                msg += ex.Message;
                throw new Exception(msg);
            }
            finally
            {
                conn.Close();                
            }
        }
    }
}