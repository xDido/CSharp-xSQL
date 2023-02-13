using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace M3
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void login(object sender, EventArgs e)
        {
            String connstr = WebConfigurationManager.ConnectionStrings["Sports"].ToString();
            SqlConnection conn = new SqlConnection(connstr);

            String username = txt_Username.Text;
            String password = txt_password.Text;
            SqlCommand logincommand = new SqlCommand("Login", conn);
            logincommand.CommandType = CommandType.StoredProcedure;
            logincommand.Parameters.Add(new SqlParameter("@username", username));
            logincommand.Parameters.Add(new SqlParameter("@password", password));
            SqlParameter loginstatus = logincommand.Parameters.Add("@status", SqlDbType.Int);
            loginstatus.Direction = ParameterDirection.Output;
            conn.Open();
            logincommand.ExecuteNonQuery();
            conn.Close();
            if ((int)loginstatus.Value == 1)
            {
                SqlCommand logincheckcommand = new SqlCommand("checkLogin", conn);
                logincheckcommand.CommandType = CommandType.StoredProcedure;
                logincheckcommand.Parameters.Add(new SqlParameter("@username", username));
                SqlParameter checkLoginStatus = logincheckcommand.Parameters.Add("@status", SqlDbType.Int);
                checkLoginStatus.Direction = ParameterDirection.Output;
                conn.Open();
                logincheckcommand.ExecuteNonQuery();
                conn.Close();
                switch ((int)checkLoginStatus.Value)
                {
                    case 1:
                        Session["username"] = username; Response.Redirect("Fan.aspx");
                        break;
                    case 2:
                        Session["username"] = username; Response.Redirect("StadiumManger.aspx");
                        break;
                    case 3:
                        Session["username"] = username; ; Response.Redirect("SportsAssociationManager.aspx");
                        break;
                    case 4:
                        Session["username"] = username; ; Response.Redirect("ClubRep.aspx");
                        break;
                    case 5:
                        Session["username"] = username; Response.Redirect("System admin.aspx");
                        break;
                    default:
                        Response.Write("<script>alert('username is not registered')</script>");
                        break;
                }
            }
            else { Response.Write("<script>alert('username is not registered or incorrect password!')</script>"); }
        }
        protected void register(object sender, EventArgs e)
        {

            Response.Redirect("Register.aspx");

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("System admin.aspx");
        }
    }
}