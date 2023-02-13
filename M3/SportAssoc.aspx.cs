using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace M3
{
    public partial class SportAssoc : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void NewMatch(object sender, EventArgs e)
        {
            string connstr = WebConfigurationManager.ConnectionStrings["Sports"].ToString();
            SqlConnection conn = new SqlConnection(connstr);

            string hName = host.Text;
            string gName = guest.Text;
            DateTime sD = DateTime.Parse(startD.Text);
            DateTime eD = DateTime.Parse(endD.Text);

            SqlCommand addMproc = new SqlCommand("addNewMatch", conn);
            addMproc.CommandType = System.Data.CommandType.StoredProcedure;
            addMproc.Parameters.Add(new SqlParameter("@nameofhost",hName));
            addMproc.Parameters.Add(new SqlParameter("@nameofguest", gName));
            addMproc.Parameters.Add(new SqlParameter("@starttime", sD));
            addMproc.Parameters.Add(new SqlParameter("@endtime", eD));

            conn.Open();
            addMproc.ExecuteNonQuery();
            conn.Close();

            Response.Write("Match was added Successfully");


        }
        protected void DeleteMatch(object sender, EventArgs e)
        {
            string connstr = WebConfigurationManager.ConnectionStrings["Sports"].ToString();
            SqlConnection conn = new SqlConnection(connstr);

            string hName = host.Text;
            string gName = guest.Text;
            DateTime sD = DateTime.Parse(startD.Text);
            DateTime eD = DateTime.Parse(endD.Text);

            SqlCommand delMproc = new SqlCommand("deleteMatch", conn);
            delMproc.CommandType = System.Data.CommandType.StoredProcedure;
            delMproc.Parameters.Add(new SqlParameter("@nameofhost", hName));
            delMproc.Parameters.Add(new SqlParameter("@nameofguest", gName));
            delMproc.Parameters.Add(new SqlParameter("@starttime", sD));
            delMproc.Parameters.Add(new SqlParameter("@endtime", eD));

            conn.Open();
            delMproc.ExecuteNonQuery();
            conn.Close();
            Response.Write("match was deleted Successfully");


        }
        protected void ViewAllUp(object sender, EventArgs e)
        {
            string connstr = WebConfigurationManager.ConnectionStrings["Sports"].ToString();
            SqlConnection conn = new SqlConnection(connstr);


            SqlCommand allUM = new SqlCommand("allUpcomingMatches", conn);
            allUM.CommandType = System.Data.CommandType.StoredProcedure;


            conn.Open();
            SqlDataReader rdr = allUM.ExecuteReader(CommandBehavior.CloseConnection);
            while(rdr.Read())
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
        protected void ViewAllPlayed(object sender, EventArgs e)
        {
            string connstr = WebConfigurationManager.ConnectionStrings["Sports"].ToString();
            SqlConnection conn = new SqlConnection(connstr);


            SqlCommand allPla = new SqlCommand("allplayedMatches", conn);
            allPla.CommandType = System.Data.CommandType.StoredProcedure;


            conn.Open();
            SqlDataReader rdr = allPla.ExecuteReader(CommandBehavior.CloseConnection);
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
        protected void NeverPlayed(object sender, EventArgs e)
        {
            string connstr = WebConfigurationManager.ConnectionStrings["Sports"].ToString();
            SqlConnection conn = new SqlConnection(connstr);


            SqlCommand allPla = new SqlCommand("neverMatched", conn);
            allPla.CommandType = System.Data.CommandType.StoredProcedure;


            conn.Open();
            SqlDataReader rdr = allPla.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                String hname = rdr.GetString(rdr.GetOrdinal("Club_1"));
                Label hna = new Label();
                hna.Text = hname;

                form1.Controls.Add(hna);
                String gname = rdr.GetString(rdr.GetOrdinal("2ndClub"));
                Label gna = new Label();
                gna.Text = gname;
                form1.Controls.Add(hna);
            }
            conn.Close();

        }


    }
}