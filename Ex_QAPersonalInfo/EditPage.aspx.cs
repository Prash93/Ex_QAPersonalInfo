using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Ex_QAPersonalInfo
{
    public partial class EditPage : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmdLoadPerson, cmdUpdatePerson, cmdAddQualification, cmdAddEmail;
        SqlDataReader reader;

        string updatedName, updatedAddress, newQualification, newEmail;

        protected void ButtonLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
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

            Response.Write("-------------------->" + IsPostBack.ToString());

            if (!IsPostBack)
            {
                Response.Write("<h1>Edit Personal Info</h1>");
                Response.Write("<br />");
                //Response.Write("<input type='hidden' name='a' value='" + Request["PerID"].ToString() + "'>");             

                Session["pickedPersonID"] = Request["PerID"].ToString();

                cmdLoadPerson = new SqlCommand();
                cmdLoadPerson.Connection = con;

                try
                {
                    cmdLoadPerson.CommandText = "SELECT * FROM PersonalInfo WHERE QAID = '" + Session["pickedPersonID"] + "'";

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
        }

        protected void ButtonAddQuali_Click(object sender, EventArgs e)
        {
            newQualification = TextBoxNewQuali.Text.ToString();

            cmdAddQualification = new SqlCommand();
            cmdAddQualification.Connection = con;

            cmdAddQualification.CommandText = "INSERT INTO Qualifications(Qualification, QAID) VALUES('" + newQualification + "', '" + Session["pickedPersonID"] +  "')";

            cmdAddQualification.ExecuteNonQuery();

            Response.Redirect("Home.aspx");

        }

        protected void ButtonAddEmail_Click(object sender, EventArgs e)
        {
            newEmail = TextBoxNewEmail.Text.ToString();

            cmdAddEmail = new SqlCommand();
            cmdAddEmail.Connection = con;

            cmdAddEmail.CommandText = "INSERT INTO Emails(Email, QAID) VALUES('" + newEmail + "', '" + Session["pickedPersonID"] + "')";

            cmdAddEmail.ExecuteNonQuery();

            Response.Redirect("Home.aspx");
        }


        protected void ButtonUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                updatedName = TextBoxName.Text.ToString();
                updatedAddress = TextBoxAddress.Text.ToString();

                cmdUpdatePerson = new SqlCommand();
                cmdUpdatePerson.Connection = con;
                cmdUpdatePerson.CommandText = "UPDATE PersonalInfo SET Name = '" + updatedName + "', Address = '" + updatedAddress + "' WHERE QAID = '" + Session["pickedPersonID"] + "'";
                
                cmdUpdatePerson.ExecuteNonQuery();

                Response.Redirect("Home.aspx");

            }
            catch (Exception exCommandSQL)
            {
                Response.Write(exCommandSQL.ToString());
            }
            
        }
    }
}