using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Ex_QAPersonalInfo
{
    public partial class PersonalInfoPage : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmdLoadPersonInfo;
        SqlDataReader reader;

        string pickedPersonID, personName, personAddress, qualifications, emails;

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

            Response.Write("<h1>Personal Info</h1>");
            Response.Write("<br />");

            pickedPersonID = Request["PerID"].ToString();

            cmdLoadPersonInfo = new SqlCommand();
            cmdLoadPersonInfo.Connection = con;

            try
            {
                cmdLoadPersonInfo.CommandText =
                    "SELECT * " +
                    "FROM PersonalInfo " +
                    "WHERE PersonalInfo.QAID = '" + pickedPersonID + "'";

                reader = cmdLoadPersonInfo.ExecuteReader();
            }
            catch (Exception exCommandSQL)
            {
                Response.Write(exCommandSQL.ToString());
            }

            if (reader.Read())
            {
                personName = reader["Name"].ToString();
                Response.Write("Name: " + personName);
                Response.Write("<br />");
                Response.Write("<br />");
                Response.Write("<br />");

                personAddress = reader["Address"].ToString();
                Response.Write("Address: <a href='LocationPage.aspx?PerAddr=" + personAddress + "'>" + personAddress + "</a>");
                Response.Write("<br />");
                Response.Write("<br />");
                Response.Write("<br />");
            }
            else
            {
                Response.Write("There are no records. Something has gone wrong.");
            }

            reader.Close();

            try
            {
                cmdLoadPersonInfo.CommandText =
                    "SELECT * " +
                    "FROM PersonalInfo " +
                        "INNER JOIN Qualifications " +
                            "ON PersonalInfo.QAID = Qualifications.QAID " +
                    "WHERE PersonalInfo.QAID = '" + pickedPersonID + "'";

                /*
                "SELECT * " + 
                "FROM PersonalInfo " +
                    "INNER JOIN Qualifications " + 
                        "ON PersonalInfo.QAID = Qualifications.QAID " + 
                    "INNER JOIN Emails " + 
                        "ON Emails.QAID = Qualifications.QAID " + 
                "WHERE PersonalInfo.QAID = '" + pickedPersonID  + "'";
                */

                reader = cmdLoadPersonInfo.ExecuteReader();
            }
            catch (Exception exCommandSQL)
            {
                Response.Write(exCommandSQL.ToString());
            }

            Response.Write("Qualifications: ");
            //Response.Write("Button ID='ButtonAddQuali' runat='server' Text='Add' />");
            Response.Write("<input type='button' name='AddQualiBtn' value='Add'> ");
            Response.Write("<br />");

            while (reader.Read())
            {
                qualifications = reader["Qualification"].ToString();
                Response.Write(qualifications);
                Response.Write("<br />");
            }

            reader.Close();

            Response.Write("<br />");
            Response.Write("<br />");

            try
            {
                cmdLoadPersonInfo.CommandText =
                    "SELECT * " +
                    "FROM PersonalInfo " +
                        "INNER JOIN Emails " +
                            "ON PersonalInfo.QAID = Emails.QAID " +
                    "WHERE PersonalInfo.QAID = '" + pickedPersonID + "'";

                reader = cmdLoadPersonInfo.ExecuteReader();
            }
            catch (Exception exCommandSQL)
            {
                Response.Write(exCommandSQL.ToString());
            }

            Response.Write("Emails: ");
            //Response.Write("Button ID='ButtonAddEmail' runat='server' Text='Add' />");
            Response.Write("<input type='button' name='AddEmailBtn' value='Add'> ");
            Response.Write("<br />");

            while (reader.Read())
            {
                emails = reader["Email"].ToString();
                Response.Write(emails);
                Response.Write("<br />");
            }

            reader.Close(); 
        }
    }
}