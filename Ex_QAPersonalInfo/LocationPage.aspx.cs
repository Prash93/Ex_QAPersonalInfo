using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Ex_QAPersonalInfo
{
    public partial class LocationPage : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmdLoadLocation;
        SqlDataReader reader;

        string pickedAddress, personInLocation;

        protected void ButtonLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
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

            pickedAddress = Request["PerAddr"].ToString();

            Response.Write("<h1>List of people in " + pickedAddress + " are:</h1>");
            Response.Write("<br />");

            cmdLoadLocation = new SqlCommand();
            cmdLoadLocation.Connection = con;

            try
            {
                cmdLoadLocation.CommandText =
                    "SELECT * " +
                    "FROM PersonalInfo " +
                    "WHERE PersonalInfo.Address = '" + pickedAddress + "'";

                reader = cmdLoadLocation.ExecuteReader();
            }
            catch (Exception exCommandSQL)
            {
                Response.Write(exCommandSQL.ToString());
            }

            while (reader.Read())
            {
                personInLocation = reader["Name"].ToString();
                Response.Write(personInLocation);
                Response.Write("<br />");
            }

            reader.Close();

        }
    }
}