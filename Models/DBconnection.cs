using Org.BouncyCastle.Asn1.X500;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class DBconnection
    {
        public  List<FoodCourt> DBconnect(string locationid,string salesdate)
        {
            List<FoodCourt> customer = new List<FoodCourt> ();
            string connectionString = ConfigurationManager.ConnectionStrings["connect"].ToString();
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            string cmd1 = "USE FoodCourt;";
            string cmd2 = "";
            string cmd3 = "Select Card_No,Tran_Date,Location_Id,Tran_Amount from Card_Tran";

            if (locationid != "" && locationid != "Location")
                cmd2 = "Select Tran_Date, Location_Id, sum(Tran_Amount) * -1 as Tran_Amount from Card_Tran where location_id='"+ locationid + "' and Tran_Date = '" + salesdate + "' group by Tran_Date, Location_Id";
            else
                cmd2 = "Select Tran_Date, Location_Id, sum(Tran_Amount) * -1 as Tran_Amount from Card_Tran where location_id != '001' and Tran_Date = '" + salesdate + "' group by Tran_Date, Location_Id";

            //string cmd3 = "select location_id, location_name from location_master";

            SqlCommand sqlCommand = new SqlCommand(cmd1, sqlConnection);
            SqlCommand sqlCommand1 = new SqlCommand(cmd2, sqlConnection);
            SqlCommand sqlCommand2 = new SqlCommand(cmd3, sqlConnection);

            DataTable dt = new DataTable();
            dt = getLocationMaster(sqlConnection);

            SqlDataReader sqlDataReader = sqlCommand1.ExecuteReader();
            //SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();

            
            while (sqlDataReader.Read())
            {
                customer.Add(new FoodCourt
                {
                    Sales_Date = Convert.ToDateTime(sqlDataReader["Tran_date"]),
                    DateTime = DateTime.Now.ToString(),
                    Location_Id = sqlDataReader["Location_Id"].ToString() + " - " + getLocationName(dt, sqlDataReader["Location_Id"].ToString()),
                    Tran_Amount = Convert.ToDouble(sqlDataReader["Tran_Amount"])
                });
            }

            return customer;
        }

        public List<Transactions> DBconnectCardTran(string cardno, string salesdate)
        {
            List<Transactions> customer = new List<Transactions>();
            string connectionString = ConfigurationManager.ConnectionStrings["connect"].ToString();
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            string cmd1 = "USE FoodCourt;";

            //string cmd3 = "Select Card_No,Tran_Date,Location_Id,Tran_Amount from Card_Tran where Card_No = '" + cardno +  "' and Tran_Date = '" + salesdate + "' ";

            //string cmd3 = "SELECT Card_Tran.Card_No, Card_Tran.Tran_Date, Card_Tran.Tran_Amount, Card_Tran.Location_Id, Location_Master.Location_Name FROM Card_Tran, Location_Master where Card_No = '" + cardno +  "' and Tran_Date = '" + salesdate + "' ";​

            string cmd3 = "SELECT T.Card_No, T.Tran_Date, T.Tran_Amount, (select Location_Name from Location_Master where Location_id = T.Location_Id ) as Location_name, T.Location_Id,T.Tran_Type FROM Card_Tran T where Card_No = '" + cardno + "' and Tran_date ='" + salesdate + "'";

            //string cmd3 = "select location_id, location_name from location_master";

            SqlCommand sqlCommand = new SqlCommand(cmd1, sqlConnection);
            SqlCommand sqlCommand2 = new SqlCommand(cmd3, sqlConnection);

            DataTable dt = new DataTable();
            dt = getLocationMaster(sqlConnection);

            
            SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();


            while (sqlDataReader2.Read())
            {
                customer.Add(new Transactions
                {
                    Card_No = sqlDataReader2["Card_No"].ToString(),
                    Tran_Date = sqlDataReader2["Tran_date"].ToString(),
                    Tran_Amount = sqlDataReader2["Tran_Amount"].ToString(),
                    Location_Id = sqlDataReader2["Location_Id"].ToString(),
                    Location_Name = sqlDataReader2["Location_Name"].ToString(),
                    Tran_Type = sqlDataReader2["Tran_Type"].ToString()
                });
            }

            return customer;
        }

        private DataTable getLocationMaster(SqlConnection con)
        { 
            DataTable locationMaster = new DataTable();
            using (var da = new SqlDataAdapter("select location_id, location_name from location_master", con))
                da.Fill(locationMaster);
                return locationMaster; 
        }

        private string getLocationName(DataTable dt,string location_id)
        {
            string name = "";
            string selection = "location_id =" + location_id;
            DataRow[] dr = dt.Select(selection);
            name = dr[0]["location_name"].ToString();
            return name;
        }
    }
}