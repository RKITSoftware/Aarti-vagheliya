using System;
using System.Configuration;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace Web_form_Demo
{
    /// <summary>
    /// Code-behind class for the default page of the web form demo.
    /// </summary>
    public partial class Default : Page
    {
        /// <summary>
        /// Handles the page load event.
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Bind the grid on initial page load
                BindGrid();
            }
        }

        /// <summary>
        /// Handles the row editing event of the GridView.
        /// </summary>
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindGrid();
        }

        /// <summary>
        /// Handles the row canceling edit event of the GridView.
        /// </summary>
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindGrid();
        }

        /// <summary>
        /// Handles the row updating event of the GridView.
        /// </summary>
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            string name = ((TextBox)row.FindControl("txtEditName")).Text;
            string email = ((TextBox)row.FindControl("txtEditEmail")).Text;
            string country = ((DropDownList)row.FindControl("ddlEditCountry")).SelectedValue;
            DateTime dob = DateTime.Parse(((TextBox)row.FindControl("txtEditDOB")).Text); // Parse DOB from TextBox

            string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "UPDATE People SET Name = @Name, Email = @Email, Country = @Country, DOB = @DOB WHERE Id = @Id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Country", country);
                command.Parameters.AddWithValue("@DOB", dob); // Add DOB parameter
                command.Parameters.AddWithValue("@Id", id);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Response.Write($"An error occurred: {ex.Message}");
                }
            }

            GridView1.EditIndex = -1;
            BindGrid();
        }

        /// <summary>
        /// Handles the row deleting event of the GridView.
        /// </summary>
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "DELETE FROM People WHERE Id = @Id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Response.Write($"An error occurred: {ex.Message}");
                }
            }

            BindGrid();
        }

        /// <summary>
        /// Handles the click event of the "Add" button.
        /// </summary>
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string email = txtEmail.Text;
            DateTime dob = Convert.ToDateTime(txtDOB.Text); // Assuming txtDOB is the TextBox for Date of Birth
            string country = ddlCountry.SelectedValue; // Assuming ddlCountry is the DropDownList for Country

            string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "INSERT INTO People (Name, Email, DOB, Country) VALUES (@Name, @Email, @DOB, @Country)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@DOB", dob);
                command.Parameters.AddWithValue("@Country", country);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Response.Write($"An error occurred: {ex.Message}");
                }
            }

            // Clear the form fields after adding
            txtName.Text = "";
            txtEmail.Text = "";
            txtDOB.Text = "";
            ddlCountry.SelectedValue = "";

            BindGrid();
        }

        /// <summary>
        /// Binds data to the GridView.
        /// </summary>
        private void BindGrid()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM People";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();

                adapter.Fill(dataTable);
                GridView1.DataSource = dataTable;
                GridView1.DataBind();
            }
        }
    }
}

