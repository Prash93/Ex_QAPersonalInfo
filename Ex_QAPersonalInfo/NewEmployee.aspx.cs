using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Ex_QAPersonalInfo
{
    public partial class NewEmployee : System.Web.UI.Page
    {

        SqlConnection con;
        SqlCommand cmdInsertEmployee;
        SqlDataReader reader;

        string newName, newAddress, personID;



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

            Response.Write("<h1>New Employee Page</h1>");
            Response.Write("<br />");
        }

        protected void ButtonAddEmployee_Click(object sender, EventArgs e)
        {
            newName = TextBoxNewName.Text.ToString();
            newAddress = TextBoxNewAddress.Text.ToString();

            cmdInsertEmployee = new SqlCommand();
            cmdInsertEmployee.Connection = con;

            //cmdInsertEmployee.CommandText = "INSERT INTO PersonalInfo(QAID, Name, Address) VALUES(FORMAT(COALESCE(MAX(QAID)+1, '1001'), '0000'), '" + newName + "', '" + newAddress + "')";
            //cmdInsertEmployee.CommandText = "INSERT INTO PersonalInfo VALUES(FORMAT(COALESCE(MAX(QAID)+1, '1001'), '0000'), '" + newName + "', '" + newAddress + "')";
            //cmdInsertEmployee.CommandText = "INSERT INTO PersonalInfo VALUES('" + newName + "', '" + newAddress + "')";
            cmdInsertEmployee.CommandText = "INSERT INTO PersonalInfo(Name, Address) VALUES('" + newName + "', '" + newAddress + "')";

            cmdInsertEmployee.ExecuteNonQuery();

            Response.Redirect("Home.aspx");
        }

    }
}