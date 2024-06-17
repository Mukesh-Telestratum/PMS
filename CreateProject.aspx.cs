using System;
using System.Data.SqlClient;
using System.Web.UI;

namespace ProjectManagementSystem
{
    public partial class CreateProject : Page
    {
        private readonly DatabaseHelper _dbHelper = new DatabaseHelper();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string description = txtDescription.Text;

            string query = "INSERT INTO Projects (Name, Description, CreatedAt, UpdatedAt) VALUES (@Name, @Description, GETDATE(), GETDATE())";
            SqlParameter[] parameters = {
                new SqlParameter("@Name", name),
                new SqlParameter("@Description", description)
            };

            _dbHelper.ExecuteNonQuery(query, parameters);
            Response.Redirect("ProjectList.aspx");
        }
    }
}
