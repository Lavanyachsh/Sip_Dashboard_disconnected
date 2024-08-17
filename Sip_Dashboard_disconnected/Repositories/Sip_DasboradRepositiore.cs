using Microsoft.Data.SqlClient;
using Sip_Dashboard_disconnected.Entities;
using Sip_Dashboard_disconnected.Interfcaes;
using System.Data;

namespace Sip_Dashboard_disconnected.Repositories
{
    public class Sip_DasboradRepositiore : ISipDashboardRepositiories
    {
        string connectionString = "data source=DESKTOP-OLCB1UC;integrated security=yes;Encrypt=True;TrustServerCertificate=True;initial catalog=hotelmanagement";
       // string connectionString = "data source=DESKTOP-OLCB1UC;user id=sa;password=S@12345;intial catalog=hotelmanagement";
       public Sip_DasboradRepositiore() { }
        public async Task<bool> AddSip_dashboard(Sip_Dashboard sip_dashboarddetail)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Usp_AddSipDashboard", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", sip_dashboarddetail.name);
                cmd.Parameters.AddWithValue("@weight", sip_dashboarddetail.weight);
                cmd.Parameters.AddWithValue("@symbol", sip_dashboarddetail.symbol);
                cmd.Parameters.AddWithValue("@location", sip_dashboarddetail.location);
                SqlDataAdapter da=new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "Sip_Dashboard");
               
            }
            return true;
        }

        public async Task<bool> DeleteSip_dashboard(int position)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Usp_deleteSipDashboard", con);
                cmd.CommandType= CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@position", position);
                SqlDataAdapter da= new SqlDataAdapter(cmd);
                DataSet ds=new DataSet();
                da.Fill(ds, "Sip_Dashboard");
            }
            return true;
        }

        public async Task<List<Sip_Dashboard>> GetSip_dashboard()
        {
            List<Sip_Dashboard> lstdashboard = new List<Sip_Dashboard>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Usp_GetSipDashboard", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "Sip_Dashboard");


                foreach (DataRow row in ds.Tables["Sip_Dashboard"].Rows)
                //foreach (DataRow row in ds.Tables["Booking"].Rows)
                {
                    Sip_Dashboard objsip = new Sip_Dashboard();
                    objsip.name = Convert.ToString(row["Name"]);
                    objsip.position = Convert.ToInt16(row["position"]);
                    objsip.symbol = Convert.ToString(row["symbol"]);
                    objsip.weight = Convert.ToDecimal(row["weight"]);
                    objsip.location = Convert.ToString(row["location"]);
                    lstdashboard.Add(objsip);
                }
                return lstdashboard;
            }
        }

        public async Task<Sip_Dashboard> GetSip_dashboardByPosition(int position)
        {
            Sip_Dashboard sipobj = new Sip_Dashboard();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Usp_GetSipDashboardByPosition", con);
                cmd.CommandType= CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@position", position);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "Sip_Dashboard");
                foreach(DataRow row in ds.Tables["Sip_Dashboard"].Rows)
                {
                    sipobj.name = Convert.ToString(row["name"]);
                    sipobj.position = Convert.ToInt16(row["position"]);
                    sipobj.weight = Convert.ToDecimal(row["weight"]);
                    sipobj.symbol = Convert.ToString(row["symbol"]);
                    sipobj.location = Convert.ToString(row["location"]);
                }
            }
            return sipobj;
        }

        public async Task<bool> UpdateSip_dashboard(Sip_Dashboard sip_dashboarddetail)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Usp_UpdateSipDashboard", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@position",sip_dashboarddetail.position);
                cmd.Parameters.AddWithValue("@name", sip_dashboarddetail.name);
                cmd.Parameters.AddWithValue("@weight", sip_dashboarddetail.weight);
                cmd.Parameters.AddWithValue("@location", sip_dashboarddetail.location);
                cmd.Parameters.AddWithValue("@symbol", sip_dashboarddetail.symbol);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "Sip_Dashboard");

            }
            return true;
        }
    }
}
