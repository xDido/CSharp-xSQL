using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace M3
{
    public partial class Fan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void ViewAvaMatches(object sender, EventArgs e)
        {
            string connstr = WebConfigurationManager.ConnectionStrings["Sports"].ToString();
            SqlConnection conn = new SqlConnection(connstr);


            SqlCommand avaM = new SqlCommand("avaMTA", conn);
            avaM.CommandType = System.Data.CommandType.StoredProcedure;
           


            conn.Open();
            SqlDataReader rdr = avaM.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {


                String hname = rdr.GetString(rdr.GetOrdinal("hostName"));
                Label hna = new Label();
                hna.Text = hname;
                form1.Controls.Add(hna);

                String gname = rdr.GetString(rdr.GetOrdinal("guestName"));
                Label gna = new Label();
                gna.Text = gname;
                form1.Controls.Add(gna);

                String sd = rdr.GetString(rdr.GetOrdinal("stadiumName"));
                Label sdd = new Label();
                sdd.Text = sd;
                form1.Controls.Add(sdd);

                String ed = rdr.GetString(rdr.GetOrdinal("stadiumLocation"));
                Label edd = new Label();
                edd.Text = ed;
                form1.Controls.Add(edd);

            }
            conn.Close();

        }
        protected void Purchase(object sender, EventArgs e)
        {
            string connstr = WebConfigurationManager.ConnectionStrings["Sports"].ToString();
            SqlConnection conn = new SqlConnection(connstr);
            int fid = (int) Session["fID"];

            string hName = host.Text;
            string gName = guest.Text;
            string sD =date.Text;

            SqlCommand addMproc = new SqlCommand("purchaseTicket", conn);
            addMproc.CommandType = System.Data.CommandType.StoredProcedure;
            addMproc.Parameters.Add(new SqlParameter("@hostName", hName));
            addMproc.Parameters.Add(new SqlParameter("@guestName", gName));
            addMproc.Parameters.Add(new SqlParameter("@startTime", sD));
            addMproc.Parameters.Add(new SqlParameter("@nationalID",fid));

            conn.Open();
            addMproc.ExecuteNonQuery();
            conn.Close();
            Response.Write("Ticket was bought Successfully");


        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}