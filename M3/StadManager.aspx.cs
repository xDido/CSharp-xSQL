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
using System.Collections.Specialized;

namespace M3
{
    public partial class StadManager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String username = (String)Session["username"];
            String connstr = WebConfigurationManager.ConnectionStrings["Sports"].ToString();
            SqlConnection conn = new SqlConnection(connstr);

            SqlCommand showStadiumDetailsCommand = new SqlCommand("checkStadiumDetails", conn);
            showStadiumDetailsCommand.CommandType = CommandType.StoredProcedure;

            showStadiumDetailsCommand.Parameters.Add(new SqlParameter("@username", username));

            conn.Open();
            SqlDataReader rdr = showStadiumDetailsCommand.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                Panel pan = new Panel();
                Int32 StadiumID = rdr.GetInt32(rdr.GetOrdinal("ID"));
                String StadiumName = rdr.GetString(rdr.GetOrdinal("name"));
                String StadiumLocation = rdr.GetString(rdr.GetOrdinal("location"));
                Int32 StadiumCapacity = rdr.GetInt32(rdr.GetOrdinal("capacity"));



                Label ID = new Label();
                Label name = new Label();
                Label location = new Label();
                Label capacity = new Label();

                ID.CssClass = "label2";
                name.CssClass = "label2";
                location.CssClass = "label2";
                capacity.CssClass = "label2";


                ID.Text = StadiumID.ToString();
                name.Text = StadiumName;
                location.Text = StadiumLocation;
                capacity.Text = StadiumCapacity.ToString();

                pan.Controls.Add(ID);
                pan.Controls.Add(name);
                pan.Controls.Add(location);
                pan.Controls.Add(capacity);
                this.Controls.Add(pan);

            }
        }
        protected void ViewStadDet(object sender, EventArgs e)
        {
          

        }
        protected void ViewPenReq(object sender, EventArgs e)
        {
            string connstr = WebConfigurationManager.ConnectionStrings["Sports"].ToString();
            SqlConnection conn = new SqlConnection(connstr);

            String username = (String)Session["username"];

            SqlCommand pendReq = new SqlCommand("pendReq", conn);
            pendReq.CommandType = System.Data.CommandType.StoredProcedure;
            pendReq.Parameters.Add(new SqlParameter("@username", username));



            conn.Open();
            SqlDataReader rdr = pendReq.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                String cname = rdr.GetString(rdr.GetOrdinal("clubRepName"));
                Label cna = new Label();
                cna.Text = cname;
                form1.Controls.Add(cna);

                String hname = rdr.GetString(rdr.GetOrdinal("hostClub"));
                Label hna = new Label();
                hna.Text = hname;
                form1.Controls.Add(hna);

                String gname = rdr.GetString(rdr.GetOrdinal("guestClub"));
                Label gna = new Label();
                gna.Text = gname;
                form1.Controls.Add(gna);

                String sd = rdr.GetValue(3).ToString();
                Label sdd = new Label();
                sdd.Text = sd;
                form1.Controls.Add(sdd);

                String ed = rdr.GetValue(4).ToString();
                Label edd = new Label();
                edd.Text = ed;
                form1.Controls.Add(edd);

                String abc = rdr.GetString(rdr.GetOrdinal("status"));
                Label lala = new Label();
                lala.Text = abc;
                form1.Controls.Add(lala);

            }
            conn.Close();

        }
        protected void AcceptReq(object sender, EventArgs e)
        {
            string connstr = WebConfigurationManager.ConnectionStrings["Sports"].ToString();
            SqlConnection conn = new SqlConnection(connstr);

            string hName = Hname.Text;
            string gName = Gname.Text;
            string sD=Time.Text;
            String username = (String)Session["username"];

            SqlCommand addMproc = new SqlCommand("acceptRequest", conn);
            addMproc.CommandType = System.Data.CommandType.StoredProcedure;
            addMproc.Parameters.Add(new SqlParameter("@hostName", hName));
            addMproc.Parameters.Add(new SqlParameter("@guestName", gName));
            addMproc.Parameters.Add(new SqlParameter("@startTime", sD));
            addMproc.Parameters.Add(new SqlParameter("@stadiumManagerUserName", username));

            conn.Open();
            addMproc.ExecuteNonQuery();
            conn.Close();
            Response.Write("request is accepted");


        }
        protected void RejectReq(object sender, EventArgs e)
        {
            string connstr = WebConfigurationManager.ConnectionStrings["Sports"].ToString();
            SqlConnection conn = new SqlConnection(connstr);

            string hName = Hname.Text;
            string gName = Gname.Text;
            string sD = Time.Text;
            String username = (String)Session["username"];

            SqlCommand addMproc = new SqlCommand("rejectRequest", conn);
            addMproc.CommandType = System.Data.CommandType.StoredProcedure;
            addMproc.Parameters.Add(new SqlParameter("@hostName", hName));
            addMproc.Parameters.Add(new SqlParameter("@guestName", gName));
            addMproc.Parameters.Add(new SqlParameter("@startTime", sD));
            addMproc.Parameters.Add(new SqlParameter("@stadiumManagerUserName", username));

            conn.Open();
            addMproc.ExecuteNonQuery();
            conn.Close();
            Response.Write("request is rejected");


        }
    }
}