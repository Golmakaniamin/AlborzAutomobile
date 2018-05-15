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
    /// Interaction logic for Leasing_02_vekalatnameh.xaml
    /// </summary>
    public partial class Sales_04_vekalatnameh : Window
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

        public Sales_04_vekalatnameh()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Database.Connection_Open();
            Database.Fill("SELECT namemarkaz,rad FROM Daftar ORDER BY rad", objDataSet1, "Daftar", true);
            Database.Connection_Close();

            comboBox1.DataContext = objDataSet1.Tables["Daftar"];
            comboBox1.DisplayMemberPath = "namemarkaz";
            comboBox1.SelectedValuePath = "rad";

            Database.Connection_Open();
            Database.Fill("SELECT * FROM All_End_Cash_and_installment_sales WHERE (S1_idshobe = '" + id_idshobe + "') AND (S1_idmen = '" + id_idmen + "') AND (S1_rad = '" + id_Contract + "')", objDataSet, "All_End_Cash_and_installment_sales", true);
            Database.Connection_Close();

            comboBox1.SelectedValue = objDataSet.Tables["All_End_Cash_and_installment_sales"].Rows[0]["S2_Daftarkhane"].ToString();
            persianDatePicker1.Text = objDataSet.Tables["All_End_Cash_and_installment_sales"].Rows[0]["S4_datet"].ToString();
            textBox1.Text = objDataSet.Tables["All_End_Cash_and_installment_sales"].Rows[0]["S4_numbervekalat"].ToString();

            objDataSet.Tables["All_End_Cash_and_installment_sales"].Clear();
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

            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("لطفا دفترخانه را تکمیل نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                comboBox1.Focus();
                return;
            }

            SqlCommand objCommand1 = new SqlCommand();
            objCommand1.Connection = objConnection;
            objCommand1.CommandText = "UPDATE All_End_Cash_and_installment_sales SET S2_Daftarkhane=@S2_Daftarkhane ,S4_datet=@S4_datet ,S4_numbervekalat=@S4_numbervekalat WHERE (S1_idshobe = '" + id_idshobe + "') AND (S1_idmen = '" + id_idmen + "') AND (S1_rad = '" + id_Contract + "')";
            objCommand1.CommandType = CommandType.Text;

            objCommand1.Parameters.AddWithValue("@S2_Daftarkhane", comboBox1.SelectedValue.ToString());
            objCommand1.Parameters.AddWithValue("@S4_datet", u_set.control_date_end(persianDatePicker1.Text));
            objCommand1.Parameters.AddWithValue("@S4_numbervekalat", textBox1.Text);

            objConnection.Open();
            objCommand1.ExecuteNonQuery();
            objConnection.Close();

            u_set.u_amal_register("5", this.Title, id_Contract, "3", "ویرایش");

            this.Hide();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
