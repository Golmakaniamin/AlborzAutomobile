using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Principal;
using System.Globalization;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;

namespace AlborzAutomobile
{
    class U_Color_set
    {
        SqlConnection objConnection = new SqlConnection(DB_Base.ConStr);
        SqlDataAdapter objDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();

        DB_Base Database = new DB_Base();

        public int set_color_buttom(string sel_type)
        {
            Database.Connection_Open();
            Database.Fill("SELECT * FROM Tbl_set_color WHERE (tmpid = " + sel_type + ")", objDataSet, "Tbl_set_color", true);
            Database.Connection_Close();

            if (sel_type == "1")
            {
                TypeConverter tc3 = TypeDescriptor.GetConverter(typeof(Color));
                Color newColor3 = (Color)tc3.ConvertFromString(objDataSet.Tables["Tbl_set_color"].Rows[0]["q1"].ToString());
                return (1);
            }

            //LinearGradientBrush myBrush = new LinearGradientBrush();
            //myBrush.StartPoint = new Point(0.5, 0);
            //myBrush.EndPoint = new Point(0.5, 1);
            //myBrush.GradientStops.Add(new GradientStop(Colors.Gold, 0.0));
            //myBrush.GradientStops.Add(new GradientStop(Colors.DarkGoldenrod, 1.0));

            return (0);
        }
    }
}
