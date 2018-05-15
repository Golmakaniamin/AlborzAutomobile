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
    /// Interaction logic for Rusty_02_vekalatnameh.xaml
    /// </summary>
    public partial class Rusty_02_vekalatnameh : Window
    {
        SqlConnection objConnection = new SqlConnection(DB_Base.ConStr);
        SqlDataAdapter objDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();

        DB_Base Database = new DB_Base();
        U_Base u_set = new U_Base();

        public string id_idshobe;
        public string id_idmen;
        public string id_Contract;

        public Rusty_02_vekalatnameh()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Database.Connection_Open();
            Database.Fill("SELECT * FROM All_End_Farsode WHERE (S1_idshobe = '" + id_idshobe + "') AND (S1_idmen = '" + id_idmen + "') AND (S1_rad = '" + id_Contract + "')", objDataSet, "All_End_Farsode", true);
            Database.Connection_Close();

            persianDatePicker1.Text = objDataSet.Tables["All_End_Farsode"].Rows[0]["S3_datet"].ToString();
            textBox1.Text = objDataSet.Tables["All_End_Farsode"].Rows[0]["S3_numbervekalat"].ToString();
            textBox2.Text = objDataSet.Tables["All_End_Farsode"].Rows[0]["S3_Daftarkhane"].ToString();

            objDataSet.Tables["All_End_Farsode"].Clear();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (persianDatePicker1.Text == "")
            {
                MessageBox.Show("لطفا تاریخ تنظیم را تکمیل نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                persianDatePicker1.Focus();
                return;
            }

            if (textBox1.Text == "")
            {
                MessageBox.Show("لطفا شماره وکالت را تکمیل نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                textBox1.Focus();
                return;
            }

            if (textBox2.Text == "")
            {
                MessageBox.Show("لطفا دفترخانه را تکمیل نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                textBox2.Focus();
                return;
            }

            SqlCommand objCommand1 = new SqlCommand();
            objCommand1.Connection = objConnection;
            objCommand1.CommandText = "UPDATE All_End_Farsode SET S3_datet=@S3_datet ,S3_numbervekalat=@S3_numbervekalat ,S3_Daftarkhane=@S3_Daftarkhane WHERE (S1_idshobe = '" + id_idshobe + "') AND (S1_idmen = '" + id_idmen + "') AND (S1_rad = '" + id_Contract + "')";
            objCommand1.CommandType = CommandType.Text;

            objCommand1.Parameters.AddWithValue("@S3_datet", u_set.control_date_end(persianDatePicker1.Text));
            objCommand1.Parameters.AddWithValue("@S3_numbervekalat", textBox1.Text);
            objCommand1.Parameters.AddWithValue("@S3_Daftarkhane", textBox2.Text);

            objConnection.Open();
            objCommand1.ExecuteNonQuery();
            objConnection.Close();

            u_set.u_amal_register("1", this.Title, id_Contract, "2", "ویرایش");

            this.Hide();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
