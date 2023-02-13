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
    public partial class ClubRep : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void ViewClubDet(object sender, EventArgs e)
        {

            string connstr = WebConfigurationManager.ConnectionStrings["Sports"].ToString();
            SqlConnection conn = new SqlConnection(connstr);
            String username = (String)Session["username"];

            SqlCommand clubD = new SqlCommand("checkClubDetails", conn);
            clubD.CommandType = CommandType.StoredProcedure;
            clubD.Parameters.Add(new SqlParameter("@username", username));

            conn.Open();
            SqlDataReader rdr = clubD.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                String cid = rdr.GetString(rdr.GetOrdinal("name"));
                Session["clubName"] = cid;
                Label ccid = new Label();
                ccid.Text = cid;
                form1.Controls.Add(ccid);

                String gname = rdr.GetString(rdr.GetOrdinal("location"));
                Label gna = new Label();
                gna.Text = gname;
                form1.Controls.Add(gna);

            }
            conn.Close();
        }
        protected void ViewUpMatches(object sender, EventArgs e)
        {
            string connstr = WebConfigurationManager.ConnectionStrings["Sports"].ToString();
            SqlConnection conn = new SqlConnection(connstr);

            String c = (String)Session["clubName"];

            SqlCommand upMatches = new SqlCommand("crUpmatches", conn);
            upMatches.CommandType = System.Data.CommandType.StoredProcedure;
            upMatches.Parameters.Add(new SqlParameter("@clubname", c));



            conn.Open();
            SqlDataReader rdr = upMatches.ExecuteReader(CommandBehavior.CloseConnection);
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

                String sd = rdr.GetValue(2).ToString();
                Label sdd = new Label();
                sdd.Text = sd;
                form1.Controls.Add(sdd);

                String ed = rdr.GetValue(3).ToString();
                Label edd = new Label();
                edd.Text = ed;
                form1.Controls.Add(edd);

            }
            conn.Close();
        }
        protected void ViewAvailbleS(object sender, EventArgs e)
        {
            string connstr = WebConfigurationManager.ConnectionStrings["Sports"].ToString();
            SqlConnection conn = new SqlConnection(connstr);

            string d = dateTime.Text;


            SqlCommand avaS = new SqlCommand("avaStad", conn);
            avaS.CommandType = System.Data.CommandType.StoredProcedure;
            avaS.Parameters.Add(new SqlParameter("@date", d));



            conn.Open();
            SqlDataReader rdr = avaS.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                String hname = rdr.GetString(rdr.GetOrdinal("name"));
                Label hna = new Label();
                hna.Text = hname;
                form1.Controls.Add(hna);

                String gname = rdr.GetString(rdr.GetOrdinal("location"));
                Label gna = new Label();
                gna.Text = gname;
                form1.Controls.Add(gna);

                Int32 sd = rdr.GetInt32(rdr.GetOrdinal("capacity"));
                Label sdd = new Label();
                sdd.Text = sd + "";
                form1.Controls.Add(sdd);

            }
            conn.Close();
        }
        protected void HostReq(object sender, EventArgs e)
        {
            string connstr = WebConfigurationManager.ConnectionStrings["Sports"].ToString();
            SqlConnection conn = new SqlConnection(connstr);

            string date =dateTime.Text;

            string sname = sName.Text;
            String c = (String)Session["clubName"];


            SqlCommand hostProc = new SqlCommand("addHostRequest", conn);
            hostProc.CommandType = System.Data.CommandType.StoredProcedure;
            hostProc.Parameters.Add(new SqlParameter("@starttime", date));
            hostProc.Parameters.Add(new SqlParameter("@stadiumname", sname));
            hostProc.Parameters.Add(new SqlParameter("@clubname", c));


            conn.Open();
            hostProc.ExecuteNonQuery();
            conn.Close();
            Response.Write("request is sent Successfully");


        }

        protected void gName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}