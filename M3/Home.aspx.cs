using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace M3
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void login(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
        protected void reg(object sender, EventArgs e)
        {
            Response.Redirect("Reg.aspx");
        }
    }
}