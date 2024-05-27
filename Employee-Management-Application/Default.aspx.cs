using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Employee_Management_Application
{
    public partial class _Default : Page
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=LAPTOP\SQLEXPRESS;Initial Catalog=Employee_Management_App;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();

            int empId = int.Parse(TextBox1.Text);
            string Employee_Name = TextBox2.Text;
            string Employee_Address = TextBox3.Text;
            int salary = int.Parse(TextBox4.Text);
            string role = DropDownList1.SelectedValue;

            SqlCommand insertCommand = new SqlCommand("exec usp_InsertIntoEmployeeTable " + empId + ", '" + Employee_Name + "', '" + Employee_Address + "', " + salary + ", '" + role + "'", sqlConnection);
            insertCommand.ExecuteNonQuery();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Inserted Data Successfully);",true);
            sqlConnection.Close();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();

            int empId = int.Parse(TextBox1.Text);
            string Employee_Name = TextBox2.Text;
            string Employee_Address = TextBox3.Text;
            int salary = int.Parse(TextBox4.Text);
            string role = DropDownList1.SelectedValue;

            SqlCommand updateCommand = new SqlCommand("exec usp_DeleteEmployee " + empId + ", '" + Employee_Name + "', '" + Employee_Address + "', " + salary + ", '" + role + "'", sqlConnection);
            updateCommand.ExecuteNonQuery();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Data Updated Successfully);", true);
            sqlConnection.Close();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            TextBox1.Text = TextBox2.Text = TextBox3.Text = TextBox4.Text = DropDownList1.SelectedValue= "";
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();
            SqlCommand getCommand = new SqlCommand("exec usp_GetAllEmployeeDetails", sqlConnection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(getCommand);
            DataTable dataTable = new DataTable();

            dataAdapter.Fill(dataTable);
            GridView1.DataSource = dataTable;
            GridView1.DataBind();
            //dataTable.Rows.Clear();
            sqlConnection.Close();
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();

            int empId = int.Parse(TextBox1.Text);

            SqlCommand deleteCommand = new SqlCommand("exec usp_DeleteEmployee " + empId, sqlConnection);
            deleteCommand.ExecuteNonQuery();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Data Deleted Successfully);", true);
            sqlConnection.Close();
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();
            SqlCommand getCommand = new SqlCommand("exec usp_GetDetails '"+ TextBox2.Text + "'", sqlConnection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(getCommand);
            DataTable dataTable = new DataTable();

            dataAdapter.Fill(dataTable);
            GridView2.DataSource = dataTable;
            GridView2.DataBind();
            sqlConnection.Close();
        }
    }
}