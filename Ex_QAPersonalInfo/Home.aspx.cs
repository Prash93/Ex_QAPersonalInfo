using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Ex_QAPersonalInfo
{
    public partial class Home : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmdLoadPeople;
        SqlDataReader reader;

        string name, address, personID;

        protected void ButtonAddPerson_Click(object sender, EventArgs e)
        {
            Response.Redirect("NewEmployee.aspx");
        }

        protected void ButtonLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //  **      CHANGE CONNECTION PATHS!!!      **  //
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

            if (Int32.Parse(Session["Role"].ToString()) == 1)
            {             
                Response.Write("<h1>Home Page</h1>");
                Response.Write("<br />");
                Response.Write("<input type='button' name='AddEntryBtn' value='Add Entry' > ");
                Response.Write("<br />");
                ButtonAddPerson.Enabled = true;

                Response.Write("Name    Address     Operations");
                Response.Write("<br />");

                cmdLoadPeople = new SqlCommand();
                cmdLoadPeople.Connection = con;

                cmdLoadPeople.CommandText = "SELECT * FROM PersonalInfo";

                reader = cmdLoadPeople.ExecuteReader();

                while (reader.Read())
                {
                    personID = reader["QAID"].ToString();
                    name = reader["Name"].ToString();
                    address = reader["Address"].ToString();

                    Response.Write("<a href='PersonalInfoPage.aspx?PerID=" + personID + "'>" + name + "        </a>" + "<a href='LocationPage.aspx?PerAddr=" + address + "'>" + address + "     </a>" + "<a href='EditPage.aspx?PerID=" + personID + "'>Edit      </a>" + "<a href='DeletePage.aspx?PerID=" + personID + "'>Delete       </a>");
                    Response.Write("<br />");
                }

                reader.Close();

            }
            else
            {
                if (Int32.Parse(Session["Role"].ToString()) == 2)
                {
                    Response.Write("<h1>Home Page</h1>");
                    Response.Write("<br />");
                    Response.Write("<input type='button' name='AddEntryBtn' value='Add Entry' disabled='disabled'> ");
                    Response.Write("<br />");
                    ButtonAddPerson.Enabled = false;

                    Response.Write("<h2>Name    Address     Operations</h2>");
                    Response.Write("<br />");

                    cmdLoadPeople = new SqlCommand();
                    cmdLoadPeople.Connection = con;

                    cmdLoadPeople.CommandText = "SELECT * FROM PersonalInfo";

                    reader = cmdLoadPeople.ExecuteReader();

                    while (reader.Read())
                    {
                        personID = reader["QAID"].ToString();
                        name = reader["Name"].ToString();
                        address = reader["Address"].ToString();

                        Response.Write("<a href='PersonalInfoPage.aspx?PerID=" + personID + "'>" + name + "        </a>" + "<a href='LocationPage.aspx?PerAddr=" + address + "'>" + address + "     </a>" + "Edit      " + "Delete       </a>");
                        Response.Write("<br />");
                    }

                    reader.Close();
                }
            }
        }
    }
}