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
    /// Interaction logic for Rusty_11_varizvajhvaersal.xaml
    /// </summary>
    public partial class Rusty_11_varizvajhvaersal : Window
    {
        SqlConnection objConnection = new SqlConnection(DB_Base.ConStr);
        SqlDataAdapter objDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();

        DB_Base Database = new DB_Base();
        U_Base u_set = new U_Base();

        public string id_idshobe;
        public string id_idmen;
        public string id_Contract;

        public Rusty_11_varizvajhvaersal()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            comboBox1.Items.Add("ملی");
            comboBox1.Items.Add("ملت");
            comboBox1.Items.Add("صادرات");
            comboBox1.Items.Add("سپه");
            comboBox1.Items.Add("تجارت");
            comboBox1.Items.Add("پارسیان");
            comboBox1.Items.Add("بانک شهر");

            Database.Connection_Open();
            Database.Fill("SELECT * FROM All_End_Farsode WHERE (S1_idshobe = '" + id_idshobe + "') AND (S1_idmen = '" + id_idmen + "') AND (S1_rad = '" + id_Contract + "')", objDataSet, "All_End_Farsode", true);
            Database.Connection_Close();

            persianDatePicker1.Text = objDataSet.Tables["All_End_Farsode"].Rows[0]["S5_datevariz"].ToString();
            persianDatePicker2.Text = objDataSet.Tables["All_End_Farsode"].Rows[0]["S5_ersalkhodro"].ToString();

            textBox1.Text = objDataSet.Tables["All_End_Farsode"].Rows[0]["S5_rgkhodro"].ToString();
            comboBox1.Text = objDataSet.Tables["All_End_Farsode"].Rows[0]["S5_formkhodro"].ToString();
            textBox2.Text = objDataSet.Tables["All_End_Farsode"].Rows[0]["S5_moshtarikhodro"].ToString();
            textBox3.Text = objDataSet.Tables["All_End_Farsode"].Rows[0]["S5_barnameforosh"].ToString();
            textBox4.Text = objDataSet.Tables["All_End_Farsode"].Rows[0]["S10_shhesab"].ToString();
            persianDatePicker3.Text = objDataSet.Tables["All_End_Farsode"].Rows[0]["S5_datevariz"].ToString();
            persianDatePicker4.Text = objDataSet.Tables["All_End_Farsode"].Rows[0]["S5_datevariz1"].ToString();

            objDataSet.Tables["All_End_Farsode"].Clear();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (persianDatePicker1.Text == "")
            {
                MessageBox.Show("لطفا تاریخ واریز را تکمیل نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                persianDatePicker1.Focus();
                return;
            }

            if (persianDatePicker2.Text == "")
            {
                MessageBox.Show("لطفا تاریخ ارسال به خودرو ساز را تکمیل نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                persianDatePicker2.Focus();
                return;
            }

            if (textBox1.Text == "")
            {
                MessageBox.Show("لطفا شماره چک را تکمیل نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                textBox1.Focus();
                return;
            }

            if (textBox4.Text == "")
            {
                MessageBox.Show("لطفا شماره حساب مشتری را تکمیل نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                textBox1.Focus();
                return;
            }

            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("لطفا بانک را انتخاب نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                comboBox1.Focus();
                return;
            }

            if (textBox2.Text == "")
            {
                MessageBox.Show("لطفا شعبه را تکمیل نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                textBox2.Focus();
                return;
            }

            if (textBox3.Text == "")
            {
                MessageBox.Show("لطفا مبلغ را تکمیل نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                textBox3.Focus();
                return;
            }

            if (persianDatePicker3.Text == "")
            {
                MessageBox.Show("لطفا تاریخ صدور چک را تکمیل نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                persianDatePicker3.Focus();
                return;
            }

            if (persianDatePicker4.Text == "")
            {
                MessageBox.Show("لطفا تاریخ سر رسید چک را تکمیل نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                persianDatePicker4.Focus();
                return;
            }
            
            SqlCommand objCommand1 = new SqlCommand();
            objCommand1.Connection = objConnection;
            objCommand1.CommandText = "UPDATE All_End_Farsode SET S5_datevariz=@S5_datevariz ,S5_ersalkhodro=@S5_ersalkhodro ,S5_rgkhodro=@S5_rgkhodro ,S5_formkhodro=@S5_formkhodro ,S5_moshtarikhodro=@S5_moshtarikhodro ,S5_barnameforosh=@S5_barnameforosh ,S5_datevariz1=@S5_datevariz1 ,S10_shhesab=@S10_shhesab WHERE (S1_idshobe = '" + id_idshobe + "') AND (S1_idmen = '" + id_idmen + "') AND (S1_rad = '" + id_Contract + "')";
            objCommand1.CommandType = CommandType.Text;

            objCommand1.Parameters.AddWithValue("@S5_datevariz", u_set.control_date_end(persianDatePicker1.Text));
            objCommand1.Parameters.AddWithValue("@S5_ersalkhodro", u_set.control_date_end(persianDatePicker2.Text));

            objCommand1.Parameters.AddWithValue("@S5_rgkhodro", textBox1.Text);
            objCommand1.Parameters.AddWithValue("@S5_formkhodro", comboBox1.Text);
            objCommand1.Parameters.AddWithValue("@S5_moshtarikhodro", textBox2.Text);
            objCommand1.Parameters.AddWithValue("@S5_barnameforosh", textBox3.Text);
            objCommand1.Parameters.AddWithValue("@S10_shhesab", textBox4.Text);
            //,S5_datevariz=@S5_datevariz
            //objCommand1.Parameters.AddWithValue("@S5_datevariz", u_set.control_date_end(persianDatePicker3.Text));
            objCommand1.Parameters.AddWithValue("@S5_datevariz1", u_set.control_date_end(persianDatePicker4.Text));

            objConnection.Open();
            objCommand1.ExecuteNonQuery();
            objConnection.Close();

            u_set.u_amal_register("1", this.Title, id_Contract, "11", "ویرایش");

            this.Hide();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
