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
    /// Interaction logic for Sell_Buy_03_received.xaml
    /// </summary>
    public partial class Sell_Buy_03_received : Window
    {
        SqlConnection objConnection = new SqlConnection(DB_Base.ConStr);
        SqlDataAdapter objDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();

        DB_Base Database = new DB_Base();
        U_Base u_set = new U_Base();

        public string id_idshobe;
        public string id_Contract;

        public Sell_Buy_03_received()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            comboBox2.Items.Add("ملی");
            comboBox2.Items.Add("ملت");
            comboBox2.Items.Add("صادرات");
            comboBox2.Items.Add("سپه");
            comboBox2.Items.Add("تجارت");
            comboBox2.Items.Add("پارسیان");
            comboBox2.Items.Add("بانک شهر");

            comboBox1.Items.Add("نقدی");
            comboBox1.Items.Add("فیش");
            comboBox1.Items.Add("چک");

            Database.Connection_Open();
            Database.Fill("SELECT * FROM All_Sell_Buy WHERE (rad = '" + id_Contract + "')", objDataSet, "All_Sell_Buy", true);
            Database.Connection_Close();

            textBox1.Text = objDataSet.Tables["All_Sell_Buy"].Rows[0]["R_Number"].ToString();

            textBox2.Text = objDataSet.Tables["All_Sell_Buy"].Rows[0]["R_money"].ToString();
            persianDatePicker1.Text = objDataSet.Tables["All_Sell_Buy"].Rows[0]["R_date"].ToString();
            comboBox2.Text = objDataSet.Tables["All_Sell_Buy"].Rows[0]["R_bank"].ToString();
            textBox3.Text = objDataSet.Tables["All_Sell_Buy"].Rows[0]["R_hesab"].ToString();

            comboBox1.Text = objDataSet.Tables["All_Sell_Buy"].Rows[0]["R_type"].ToString();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("لطفا نوع را انتخاب نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                comboBox1.Focus();
                return;
            }

            if (textBox1.Text == "")
            {
                MessageBox.Show("لطفا " + label7.Content + " را انتخاب نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                textBox1.Focus();
                return;
            }

            if (textBox2.Text == "")
            {
                MessageBox.Show("لطفا مبلغ را تکمیل نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                textBox2.Focus();
                return;
            }

            if (persianDatePicker1.Text == "")
            {
                MessageBox.Show("لطفا تاریخ را تکمیل نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                persianDatePicker1.Focus();
                return;
            }

            if (comboBox1.SelectedIndex >= 1)
            {
                if (comboBox2.SelectedIndex == -1)
                {
                    MessageBox.Show("لطفا بانک را انتخاب نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                    comboBox2.Focus();
                    return;
                }

                if (textBox3.Text == "")
                {
                    MessageBox.Show("لطفا شماره حساب را تکمیل نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                    textBox3.Focus();
                    return;
                }
            }

            SqlCommand objCommand1 = new SqlCommand();
            objCommand1.Connection = objConnection;
            objCommand1.CommandText = "UPDATE All_Sell_Buy SET R_type=@R_type ,R_money=@R_money ,R_date=@R_date ,R_Number=@R_Number ,R_hesab=@R_hesab ,R_bank=@R_bank WHERE (rad = '" + id_Contract + "')";
            objCommand1.CommandType = CommandType.Text;

            objCommand1.Parameters.AddWithValue("@R_type", comboBox1.Text);
            objCommand1.Parameters.AddWithValue("@R_Number", textBox1.Text);
            objCommand1.Parameters.AddWithValue("@R_money",Convert.ToDouble(textBox2.Text));
            objCommand1.Parameters.AddWithValue("@R_date", u_set.control_date_end(persianDatePicker1.Text));
            objCommand1.Parameters.AddWithValue("@R_bank", comboBox2.Text);
            objCommand1.Parameters.AddWithValue("@R_hesab", textBox3.Text);

            objConnection.Open();
            objCommand1.ExecuteNonQuery();
            objConnection.Close();

            u_set.u_amal_register("5", this.Title, id_Contract, "3", "ویرایش");

            MessageBox.Show("اطلاعات با موفقیت ویرایش شد", "", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void comboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBox1.SelectedIndex.ToString() == "0")
            {
                label7.Content = "صندوق";

                label2.Visibility = System.Windows.Visibility.Hidden;
                label3.Visibility = System.Windows.Visibility.Hidden;

                comboBox2.Visibility = System.Windows.Visibility.Hidden;
                textBox3.Visibility = System.Windows.Visibility.Hidden;
            }
            else if (comboBox1.SelectedIndex.ToString() == "1")
            {
                label7.Content = "شماره فیش";

                label2.Visibility = System.Windows.Visibility.Visible;
                label3.Visibility = System.Windows.Visibility.Visible;

                comboBox2.Visibility = System.Windows.Visibility.Visible;
                textBox3.Visibility = System.Windows.Visibility.Visible;
            }
            else if (comboBox1.SelectedIndex.ToString() == "2")
            {
                label7.Content = "شماره چک";

                label2.Visibility = System.Windows.Visibility.Visible;
                label3.Visibility = System.Windows.Visibility.Visible;

                comboBox2.Visibility = System.Windows.Visibility.Visible;
                textBox3.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
