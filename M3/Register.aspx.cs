using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Principal;
using System.Security.Cryptography;

namespace M3
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void register(object sender, EventArgs e)
        {
            String connstr = WebConfigurationManager.ConnectionStrings["Sports"].ToString();
            SqlConnection conn = new SqlConnection(connstr);
            String name = "Default";
            String username = "Default";
            String password = "Default";
            String club_name = "Default";
            String std_name = "Default";
            if (!String.IsNullOrEmpty(Name_txt.Text)) { name = Name_txt.Text; }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('please fill in your name');window.location ='Register.aspx';", true);
            }
            if (!String.IsNullOrEmpty(Username_txt.Text)) { username = Username_txt.Text; }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('please fill in your username');window.location ='Register.aspx';", true);
            }
            if (!String.IsNullOrEmpty(Password_txt.Text)) { password = Password_txt.Text; }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('please fill in your password');window.location ='Register.aspx';", true);
            }

            if (DropDownList1.SelectedValue == "Account type")
            { Response.Write("<script>alert('please select an account type and fill the data')</script>"); }


            if (DropDownList1.SelectedValue == "Sports Association Manager")
            {
                SqlCommand addAssociationManagerCommand = new SqlCommand("addAssociationManager", conn);
                addAssociationManagerCommand.CommandType = CommandType.StoredProcedure;
                addAssociationManagerCommand.Parameters.Add(new SqlParameter("@name", name));
                addAssociationManagerCommand.Parameters.Add(new SqlParameter("@username", username));
                addAssociationManagerCommand.Parameters.Add(new SqlParameter("@password", password));
                conn.Open();
                addAssociationManagerCommand.ExecuteNonQuery();
                conn.Close();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('created your Sports Association Manager account successfully!');window.location ='Login.aspx';", true);
            }
            if (DropDownList1.SelectedValue == "Club Representative")
            {
                if (!String.IsNullOrEmpty(Club_txt.Text)) { club_name = Club_txt.Text; }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('please fill in your club name');window.location ='Register.aspx';", true);
                }
                SqlCommand addRepresentativeCommand = new SqlCommand("addRepresentative", conn);
                addRepresentativeCommand.CommandType = CommandType.StoredProcedure;
                addRepresentativeCommand.Parameters.Add(new SqlParameter("@name", name));
                addRepresentativeCommand.Parameters.Add(new SqlParameter("@clubname", club_name));
                addRepresentativeCommand.Parameters.Add(new SqlParameter("@username", username));
                addRepresentativeCommand.Parameters.Add(new SqlParameter("@password", password));
                conn.Open();
                addRepresentativeCommand.ExecuteNonQuery();
                conn.Close();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('created your Club Representative account successfully!');window.location ='Login.aspx';", true);

            }
            if (DropDownList1.SelectedValue == "Stadium Manager")
            {
                if (!String.IsNullOrEmpty(Stadium_txt.Text)) { std_name = Stadium_txt.Text; }
                else
                {
                    Response.Write("<script>alert('please fill in your stadium name')</script>");
                }
                SqlCommand addStadiumManager = new SqlCommand("addStadiumManager", conn);
                addStadiumManager.CommandType = CommandType.StoredProcedure;
                addStadiumManager.Parameters.Add(new SqlParameter("@name", name));
                addStadiumManager.Parameters.Add(new SqlParameter("@stadiumname", std_name));
                addStadiumManager.Parameters.Add(new SqlParameter("@username", username));
                addStadiumManager.Parameters.Add(new SqlParameter("@password", password));
                conn.Open();
                addStadiumManager.ExecuteNonQuery();
                conn.Close();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('created your Stadium Manager account successfully!');window.location ='Login.aspx';", true);
            }
            if (DropDownList1.SelectedValue == "Fan")
            {
                Int64 national_id = 404;
                String birthdate = "DEFAULT";
                Int64 phone_number = 404;
                String address = "DEFAULT";

                if (!String.IsNullOrEmpty(Nidnumber_txt.Text)) { national_id = Int64.Parse(Nidnumber_txt.Text); }
                else
                {
                    Response.Write("<script>alert('please fill in your national_id')</script>");
                }
                if (!String.IsNullOrEmpty(PhoneNumber_txt.Text)) { phone_number = Int64.Parse(PhoneNumber_txt.Text); }
                else
                {
                    Response.Write("<script>alert('please fill in your phone number')</script>");
                }
                if (!String.IsNullOrEmpty(address_txt.Text)) { address = address_txt.Text; }
                else
                {
                    Response.Write("<script>alert('please fill in your address')</script>");
                }
                if (!String.IsNullOrEmpty(Birth_txt.Text)) { birthdate = Birth_txt.Text; }
                else
                {
                    Response.Write("<script>alert('please fill in your birthdate CORRECTLY')</script>");
                }
                SqlCommand addFanCommand = new SqlCommand("addFan", conn);
                addFanCommand.CommandType = CommandType.StoredProcedure;
                addFanCommand.Parameters.Add(new SqlParameter("@name", name));
                addFanCommand.Parameters.Add(new SqlParameter("@nationalid", national_id));
                addFanCommand.Parameters.Add(new SqlParameter("@username", username));
                addFanCommand.Parameters.Add(new SqlParameter("@password", password));
                addFanCommand.Parameters.Add(new SqlParameter("@birthdate", birthdate));
                addFanCommand.Parameters.Add(new SqlParameter("@phonenumber ", phone_number));
                addFanCommand.Parameters.Add(new SqlParameter("@address", address));
                conn.Open();
                try { addFanCommand.ExecuteNonQuery(); }
                catch (Exception obj) { Response.Write("<script>alert('please enter your national id correctly')</script>"); }
                conn.Close();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('created your fan account successfully!');window.location ='Login.aspx';", true);
            }
        }

        protected void Name_txt_TextChanged(object sender, EventArgs e)
        {

        }
    }
}