using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace AlborzAutomobile
{
    /// <summary>
    /// Interaction logic for Leasing_04_Datetakmil.xaml
    /// </summary>
    public partial class Leasing_04_Datetakmil : Window
    {
        SqlConnection objConnection = new SqlConnection(DB_Base.ConStr);
        SqlDataAdapter objDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();
        DataSet objDataSet1 = new DataSet();

        DB_Base Database = new DB_Base();
        U_Base u_set = new U_Base();

        public string id_idshobe;
        public string id_idmen;
        public string id_Contract;

        public Leasing_04_Datetakmil()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Database.Connection_Open();
            Database.Fill("SELECT * FROM All_End_EzareBeShartTamlik WHERE (S1_idshobe = '" + id_idshobe + "') AND (S1_idmen = '" + id_idmen + "') AND (S1_rad = '" + id_Contract + "')", objDataSet, "All_End_EzareBeShartTamlik", true);
            Database.Connection_Close();

            persianDatePicker1.Text = objDataSet.Tables["All_End_EzareBeShartTamlik"].Rows[0]["S5_DateSet"].ToString();
            persianDatePicker2.Text = objDataSet.Tables["All_End_EzareBeShartTamlik"].Rows[0]["S5_DateLising"].ToString();

            objDataSet.Tables["All_End_EzareBeShartTamlik"].Clear();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (persianDatePicker1.Text == "")
            {
                MessageBox.Show("لطفا تاریخ تکمیل پرونده را تکمیل نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                persianDatePicker1.Focus();
                return;
            }

            if (persianDatePicker2.Text == "")
            {
                MessageBox.Show("لطفا تاریخ ارسال به لیزینگ را تکمیل نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                persianDatePicker2.Focus();
                return;
            }

            SqlCommand objCommand1 = new SqlCommand();
            objCommand1.Connection = objConnection;
            objCommand1.CommandText = "UPDATE All_End_EzareBeShartTamlik SET S5_DateSet=@S5_DateSet ,S5_DateLising=@S5_DateLising WHERE (S1_idshobe = '" + id_idshobe + "') AND (S1_idmen = '" + id_idmen + "') AND (S1_rad = '" + id_Contract + "')";
            objCommand1.CommandType = CommandType.Text;

            objCommand1.Parameters.AddWithValue("@S5_DateSet", u_set.control_date_end(persianDatePicker1.Text));
            objCommand1.Parameters.AddWithValue("@S5_DateLising", u_set.control_date_end(persianDatePicker2.Text));

            objConnection.Open();
            objCommand1.ExecuteNonQuery();
            objConnection.Close();

            u_set.u_amal_register("2", this.Title, id_Contract, "4", "ویرایش");

            this.Hide();
        }
    }
}
