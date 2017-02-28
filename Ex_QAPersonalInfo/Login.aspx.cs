using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Ex_QAPersonalInfo
{
    public partial class Login : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmdCheckUser;
        SqlDataReader reader;

        string username, password, role;

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("<h1>Login Page</h1>");
            Response.Write("<br />");

            //  **      CHANGE CONNECTION PATHS     **  //
            con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename='c:\\users\\administrator\\documents\\visual studio 2015\\Projects\\Ex_QAPersonalInfo\\Ex_QAPersonalInfo\\App_Data\\Database1.mdf';Integrated Security=True");
            //con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename='C:\\Users\\Sa\\Documents\\QA Consulting\\Training\\C#\\Ex_QAPersonalInfo\\Ex_QAPersonalInfo\\App_Data\\Database1.mdf';Integrated Security=True");

            try
            {
                con.Open();
            }
            catch (Exception exConnection)
            {
                Response.Write(exConnection.ToString());
            }

        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            username = TextBoxUsername.Text.ToString();
            password = TextBoxPassword.Text.ToString();

            cmdCheckUser = new SqlCommand();
            cmdCheckUser.Connection = con;

            try
            {
                cmdCheckUser.CommandText = "SELECT * FROM Users WHERE Username = '" + username + "' AND Password = '" + password + "'";
                reader = cmdCheckUser.ExecuteReader();
            }
            catch(Exception exCommandSQL)
            {
                Response.Write(exCommandSQL.ToString());
            }

            if (reader.Read())
            {
                Session["Username"] = reader["Username"].ToString();
                Session["Role"] = reader["Role"].ToString();
                Response.Redirect("Home.aspx");
            }
            else
            {
                Response.Write("<p>Incorrect credentials. Please re-enter.</p>");
                TextBoxUsername.Text = "";
                TextBoxPassword.Text = "";
            }
        }
    }
}