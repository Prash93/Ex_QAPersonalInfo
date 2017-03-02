using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Ex_QAPersonalInfo
{
    public partial class DeletePage : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmdLoadPerson, cmdDeletePerson;
        SqlDataReader reader;

        string pickedPersonID;

        protected void ButtonLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("<h1>Delete Person</h1>");
            Response.Write("<br />");

            //  **      CHANGE CONNECTION PATHS     **  //
            //con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename='c:\\users\\administrator\\documents\\visual studio 2015\\Projects\\Ex_QAPersonalInfo\\Ex_QAPersonalInfo\\App_Data\\Database1.mdf';Integrated Security=True");
            //con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename='C:\\Users\\Sa\\Documents\\QA Consulting\\Training\\C#\\Ex_QAPersonalInfo\\Ex_QAPersonalInfo\\App_Data\\Database1.mdf';Integrated Security=True");
            con = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = 'C:\\Users\\Sa\\Documents\\GitHub\\Ex_QAPersonalInfo\\Ex_QAPersonalInfo\\App_Data\\Database1.mdf'; Integrated Security = True");

            try
            {
                con.Open();
            }
            catch (Exception exConnection)
            {
                Response.Write(exConnection.ToString());
            }

            pickedPersonID = Request["PerID"].ToString();

            cmdLoadPerson = new SqlCommand();
            cmdLoadPerson.Connection = con;

            try
            {
                cmdLoadPerson.CommandText =
                    "SELECT * " +
                    "FROM PersonalInfo " +
                    "WHERE QAID = '" + pickedPersonID + "'";

                reader = cmdLoadPerson.ExecuteReader();
            }
            catch (Exception exCommandSQL)
            {
                Response.Write(exCommandSQL.ToString());
            }

            if (reader.Read())
            {
                TextBoxName.Text = reader["Name"].ToString();
                TextBoxAddress.Text = reader["Address"].ToString();
                reader.Close();
            }
            else
            {
                Response.Write("<p>There is no record for this ID. Something has gone wrong.</p>");
                reader.Close();
            }
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            try
            {
            cmdDeletePerson = new SqlCommand();
            cmdDeletePerson.Connection = con;

            cmdDeletePerson.CommandText = "DELETE FROM Qualifications WHERE QAID = '" + pickedPersonID + "'";
            cmdDeletePerson.ExecuteNonQuery();

            cmdDeletePerson.CommandText = "DELETE FROM Emails WHERE QAID = '" + pickedPersonID + "'";
            cmdDeletePerson.ExecuteNonQuery();

            cmdDeletePerson.CommandText = "DELETE FROM PersonalInfo WHERE QAID = '" + pickedPersonID + "'";
            cmdDeletePerson.ExecuteNonQuery();

            Response.Redirect("Home.aspx");

            }
            catch (Exception exCommandSQL)
            {
                Response.Write(exCommandSQL.ToString());
            }
      
        }



        protected void ButtonNoDel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }
    }
}