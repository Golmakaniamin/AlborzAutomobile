using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Principal;
using System.Globalization;
using System.Data;
using System.Data.SqlClient;

namespace CrystalReportWpf_AlborzAutomobile
{
    class U_Base
    {
        SqlConnection objConnection = new SqlConnection(DB_Base.ConStr);
        SqlDataAdapter objDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();

        DB_Base Database = new DB_Base();

        public string u_date()
        {
            Database.Connection_Open();
            Database.Fill("SELECT GETDATE() AS Expr1, DATEPART(HOUR, GETDATE()) AS Expr2, DATEPART(MINUTE, GETDATE()) AS Expr3, DATEPART(SECOND, GETDATE()) AS Expr4", objDataSet, "Server_Date1", true);
            Database.Connection_Close();

            int y, m, d;
            PersianCalendar pr = new PersianCalendar();
            string amin = objDataSet.Tables["Server_Date1"].Rows[0]["Expr1"].ToString();

            d = pr.GetDayOfMonth(Convert.ToDateTime(amin));
            m = pr.GetMonth(Convert.ToDateTime(amin));
            y = pr.GetYear(Convert.ToDateTime(amin));

            string date;
            date = y.ToString().PadLeft(2, '0') + "/" + m.ToString().PadLeft(2, '0') + "/" + d.ToString().PadLeft(2, '0');
            return (date);
        }

        public string u_time()
        {
            Database.Connection_Open();
            Database.Fill("SELECT GETDATE() AS Expr1, DATEPART(HOUR, GETDATE()) AS Expr2, DATEPART(MINUTE, GETDATE()) AS Expr3, DATEPART(SECOND, GETDATE()) AS Expr4", objDataSet, "Server_Date1", true);
            Database.Connection_Close();

            string time;
            time = objDataSet.Tables["Server_Date1"].Rows[0]["Expr2"].ToString().PadLeft(2, '0') + ":" + objDataSet.Tables["Server_Date1"].Rows[0]["Expr3"].ToString().PadLeft(2, '0') + ":" + objDataSet.Tables["Server_Date1"].Rows[0]["Expr4"].ToString().PadLeft(2, '0');
            return (time);
        }

        public string u_pc()
        {
            string Coumpute_name1 = "";
            Coumpute_name1 = WindowsIdentity.GetCurrent().Name.ToString();
            return (Coumpute_name1);
        }

        public string u_user()
        {
            string User_name1 = "";

            string file_name = "AlborzAutomobilea.vshost.application";

            string[] installs = new string[1];

            installs = System.IO.File.ReadAllLines(file_name, Encoding.Unicode);

            User_name1 = installs[0];
            return (User_name1);
        }

        public string control_date_end(string date1)
        {
            string date2_1 = date1.Substring(0, 4);
            int strindex1 = date1.IndexOf(@"/");
            int strindex2 = date1.IndexOf(@"/", strindex1 + 1);
            string date2_2 = date1.Substring(strindex1 + 1, (strindex2 - strindex1 - 1)).PadLeft(2, '0');
            string date2_3 = date1.Substring(strindex2 + 1, (date1.Length - strindex2 - 1)).PadLeft(2, '0');

            return (date2_1 + @"/" + date2_2 + @"/" + date2_3);
        }

        public void u_amal_register(string IN_id, string IN_place, string IN_Contract, string IN_rad, string IN_noe)
        {
            SqlCommand objCommand2 = new SqlCommand();
            objCommand2.Connection = objConnection;
            objCommand2.CommandText = "INSERT INTO UserAmal (uuser,udate,utime,upc,id,place,Contract,rad,noe) VALUES (@uuser,@udate,@utime,@upc,@id,@place,@Contract,@rad,@noe)";
            objCommand2.CommandType = CommandType.Text;

            objCommand2.Parameters.AddWithValue("@uuser", u_user());
            objCommand2.Parameters.AddWithValue("@udate", u_date());
            objCommand2.Parameters.AddWithValue("@utime", u_time());
            objCommand2.Parameters.AddWithValue("@upc", u_pc());
            objCommand2.Parameters.AddWithValue("@id", IN_id);
            objCommand2.Parameters.AddWithValue("@place", IN_place);
            objCommand2.Parameters.AddWithValue("@Contract", IN_Contract);
            objCommand2.Parameters.AddWithValue("@rad", IN_rad);
            objCommand2.Parameters.AddWithValue("@noe", IN_noe);

            objConnection.Open();
            objCommand2.ExecuteNonQuery();
            objConnection.Close();
        }
    }
}
