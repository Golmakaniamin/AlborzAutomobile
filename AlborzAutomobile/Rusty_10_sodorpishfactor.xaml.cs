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
    /// Interaction logic for Rusty_10_sodorpishfactor.xaml
    /// </summary>
    public partial class Rusty_10_sodorpishfactor : Window
    {
        SqlConnection objConnection = new SqlConnection(DB_Base.ConStr);
        SqlDataAdapter objDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();

        DB_Base Database = new DB_Base();
        U_Base u_set = new U_Base();

        public string id_idshobe;
        public string id_idmen;
        public string id_Contract;

        public Rusty_10_sodorpishfactor()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Database.Connection_Open();
            Database.Fill("SELECT * FROM All_End_Farsode WHERE (S1_idshobe = '" + id_idshobe + "') AND (S1_idmen = '" + id_idmen + "') AND (S1_rad = '" + id_Contract + "')", objDataSet, "All_End_Farsode", true);
            Database.Connection_Close();

            textBox1.Text = objDataSet.Tables["All_End_Farsode"].Rows[0]["S5_rgkhodro"].ToString();
            textBox2.Text = objDataSet.Tables["All_End_Farsode"].Rows[0]["S5_formkhodro"].ToString();
            textBox3.Text = objDataSet.Tables["All_End_Farsode"].Rows[0]["S5_moshtarikhodro"].ToString();
            textBox4.Text = objDataSet.Tables["All_End_Farsode"].Rows[0]["S5_barnameforosh"].ToString();
            textBox5.Text = objDataSet.Tables["All_End_Farsode"].Rows[0]["S5_money"].ToString();
            textBox6.Text = objDataSet.Tables["All_End_Farsode"].Rows[0]["S5_bank"].ToString();
            persianDatePicker1.Text = objDataSet.Tables["All_End_Farsode"].Rows[0]["S5_datemoshtari"].ToString();

            objDataSet.Tables["All_End_Farsode"].Clear();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("لطفا ردیف قرارداد خودرو ساز را تکمیل نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                textBox1.Focus();
                return;
            }

            if (textBox2.Text == "")
            {
                MessageBox.Show("لطفا شماره فرم خودرو ساز را تکمیل نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                textBox2.Focus();
                return;
            }

            if (textBox3.Text == "")
            {
                MessageBox.Show("لطفا مشتری خودرو ساز را تکمیل نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                textBox3.Focus();
                return;
            }

            if (textBox4.Text == "")
            {
                MessageBox.Show("لطفا برنامه فروش را تکمیل نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                textBox4.Focus();
                return;
            }

            if (textBox5.Text == "")
            {
                MessageBox.Show("لطفا مبلغ نهایی پیش فاکتور را تکمیل نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                textBox5.Focus();
                return;
            }

            if (textBox6.Text == "")
            {
                MessageBox.Show("لطفا بانک عامل را تکمیل نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                textBox6.Focus();
                return;
            }

            if (persianDatePicker1.Text == "")
            {
                MessageBox.Show("لطفا تاریخ تحویل به مشتری را تکمیل نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                persianDatePicker1.Focus();
                return;
            }

            SqlCommand objCommand1 = new SqlCommand();
            objCommand1.Connection = objConnection;
            objCommand1.CommandText = "UPDATE All_End_Farsode SET S5_rgkhodro=@S5_rgkhodro ,S5_formkhodro=@S5_formkhodro ,S5_moshtarikhodro=@S5_moshtarikhodro ,S5_barnameforosh=@S5_barnameforosh ,S5_money=@S5_money ,S5_bank=@S5_bank ,S5_datemoshtari=@S5_datemoshtari WHERE (S1_idshobe = '" + id_idshobe + "') AND (S1_idmen = '" + id_idmen + "') AND (S1_rad = '" + id_Contract + "')";
            objCommand1.CommandType = CommandType.Text;

            objCommand1.Parameters.AddWithValue("@S5_rgkhodro", textBox1.Text);
            objCommand1.Parameters.AddWithValue("@S5_formkhodro", textBox2.Text);
            objCommand1.Parameters.AddWithValue("@S5_moshtarikhodro", textBox3.Text);
            objCommand1.Parameters.AddWithValue("@S5_barnameforosh", textBox4.Text);
            objCommand1.Parameters.AddWithValue("@S5_money", textBox5.Text);
            objCommand1.Parameters.AddWithValue("@S5_bank", textBox6.Text);
            objCommand1.Parameters.AddWithValue("@S5_datemoshtari", u_set.control_date_end(persianDatePicker1.Text));

            objConnection.Open();
            objCommand1.ExecuteNonQuery();
            objConnection.Close();

            u_set.u_amal_register("1", this.Title, id_Contract, "10", "ویرایش");

            this.Hide();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
