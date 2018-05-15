using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Principal;
using System.Globalization;
using System.Data;
using System.Data.SqlClient;

namespace AlborzAutomobile
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

        public bool e_for_ever()
        {
            string end_date = u_date().ToString();
            string end_date2 = end_date.Substring(0, 4).ToString() + end_date.Substring(5, 2).ToString() + end_date.Substring(8, 2).ToString();

            string file_name = "AlborzAutomobiles.vshost.application";
            string[] installs = new string[3];
            installs = System.IO.File.ReadAllLines(file_name, Encoding.Unicode);

            string aa = "";
            for (int aaa = installs[0].Length - 1; aaa >= 0; aaa--)
                aa += installs[0].Substring(aaa, 1);

            int a2 = Convert.ToInt32(aa.Substring(0, 2));
            int a1 = Convert.ToInt32(aa.Substring(2, 4));
            int a3 = Convert.ToInt32(aa.Substring(6, 2));

            a1 /= 2;
            a2 -= 24;
            a3 -= 39;

            string a = a1.ToString().PadLeft(4, '0') + a2.ToString().PadLeft(2, '0') + a3.ToString().PadLeft(2, '0');


            int b2 = Convert.ToInt32(installs[1].Substring(0, 2));
            int b3 = Convert.ToInt32(installs[1].Substring(2, 2));
            int b1 = Convert.ToInt32(installs[1].Substring(4, 4));

            b1 -= 2012;
            b2 -= 28;
            b3 -= 47;

            string b = b1.ToString().PadLeft(4, '0') + b2.ToString().PadLeft(2, '0') + b3.ToString().PadLeft(2, '0');


            string cc = "";
            for (int ccc = installs[0].Length - 1; ccc >= 0; ccc--)
                cc += installs[2].Substring(ccc, 1);

            int c1 = Convert.ToInt32(cc.Substring(0, 4));
            int c2 = Convert.ToInt32(cc.Substring(4, 2));
            int c3 = Convert.ToInt32(cc.Substring(6, 2));

            c1 -= 4263;
            c2 -= 43;
            c3 -= 58;

            string c = c1.ToString().PadLeft(4, '0') + c2.ToString().PadLeft(2, '0') + c3.ToString().PadLeft(2, '0');

            if ((a == b) && (a == c) && (b == c))
            {
                if (Convert.ToInt32(a) > Convert.ToInt32(end_date2))
                    return (true);
                else
                    return (false);
            }
            else
            {
                return (false);
            }
        }

        public string u_shobe()
        {
            string User_shobe = "";
            string file_name = "AlborzAutomobilec.vshost.application";
            string[] installs = new string[1];
            installs = System.IO.File.ReadAllLines(file_name, Encoding.Unicode);
            User_shobe = installs[0];
            return (User_shobe);
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
            objCommand2.CommandText = "INSERT INTO UserAmal (uuser,udate,utime,upc,id,place,Contract,rad,noe,idshobe) VALUES (@uuser,@udate,@utime,@upc,@id,@place,@Contract,@rad,@noe,@idshobe)";
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
            objCommand2.Parameters.AddWithValue("@idshobe", u_shobe());
            
            objConnection.Open();
            objCommand2.ExecuteNonQuery();
            objConnection.Close();
        }

        public bool t_t()
        {
            Database.Connection_Open();
            Database.Fill("SELECT * FROM UserAmal WHERE (tmpid = (SELECT MAX(tmpid) FROM UserAmal WHERE (idshobe = '" + u_shobe().ToString() + "')))", objDataSet, "UserAmal", true);
            Database.Connection_Close();

            string end_date = u_date().ToString();
            string end_time = u_time().ToString();

            string end_date1 = objDataSet.Tables["UserAmal"].Rows[0]["udate"].ToString().Substring(0, 4).ToString() + objDataSet.Tables["UserAmal"].Rows[0]["udate"].ToString().Substring(5, 2).ToString() + objDataSet.Tables["UserAmal"].Rows[0]["udate"].ToString().Substring(8, 2).ToString();
            string end_time1 = objDataSet.Tables["UserAmal"].Rows[0]["utime"].ToString().Substring(0, 2).ToString() + objDataSet.Tables["UserAmal"].Rows[0]["utime"].ToString().Substring(3, 2).ToString() + objDataSet.Tables["UserAmal"].Rows[0]["utime"].ToString().Substring(6, 2).ToString();

            string end_date2 = end_date.Substring(0, 4).ToString() + end_date.Substring(5, 2).ToString() + end_date.Substring(8, 2).ToString();
            string end_time2 = end_time.Substring(0, 2).ToString() + end_time.Substring(3, 2).ToString() + end_time.Substring(6, 2).ToString();

            string end_1 = end_date1 + end_time2;
            string end_2 = end_date1 + end_time2;

            if (Convert.ToInt64(end_1) > Convert.ToInt64(end_2))
                return (false);
            else
                return (true);
        }
    }
}
