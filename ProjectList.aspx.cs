using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectManagementSystem
{
    public partial class ProjectList : Page
    {
        private readonly DatabaseHelper _dbHelper = new DatabaseHelper();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadProjects();
            }
        }

        private void LoadProjects()
        {
            string query = "SELECT * FROM Projects";
            DataTable dt = _dbHelper.ExecuteQuery(query);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            string query = "DELETE FROM Projects WHERE Id = @Id";
            SqlParameter[] parameters = { new SqlParameter("@Id", id) };
            _dbHelper.ExecuteNonQuery(query, parameters);
            LoadProjects();
        }

        protected void btnCreateProject_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateProject.aspx");
        }
    }
}
