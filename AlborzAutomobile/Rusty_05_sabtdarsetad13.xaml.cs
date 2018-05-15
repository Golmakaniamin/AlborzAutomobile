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
    /// Interaction logic for Rusty_05_sabtdarsetad13.xaml
    /// </summary>
    public partial class Rusty_05_sabtdarsetad13 : Window
    {
        SqlConnection objConnection = new SqlConnection(DB_Base.ConStr);
        SqlDataAdapter objDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();

        DB_Base Database = new DB_Base();
        U_Base u_set = new U_Base();

        public string id_idshobe;
        public string id_idmen;
        public string id_Contract;

        public Rusty_05_sabtdarsetad13()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Database.Connection_Open();
            Database.Fill("SELECT * FROM All_End_Farsode WHERE (S1_idshobe = '" + id_idshobe + "') AND (S1_idmen = '" + id_idmen + "') AND (S1_rad = '" + id_Contract + "')", objDataSet, "All_End_Farsode", true);
            Database.Connection_Close();

            persianDatePicker1.Text = objDataSet.Tables["All_End_Farsode"].Rows[0]["S4_2_1"].ToString();
            textBox1.Text = objDataSet.Tables["All_End_Farsode"].Rows[0]["S4_3_2"].ToString();
            textBox2.Text = objDataSet.Tables["All_End_Farsode"].Rows[0]["S4_2_2"].ToString();

            objDataSet.Clear();

            Database.Connection_Open();
            Database.Fill("SELECT * FROM parking ORDER BY rad", objDataSet, "parking", true);
            Database.Connection_Close();

            dataGrid1.DataContext = objDataSet;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (persianDatePicker1.Text == "")
            {
                MessageBox.Show("لطفا تاریخ ثبت نام را تکمیل نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                persianDatePicker1.Focus();
                return;
            }

            if (textBox1.Text == "")
            {
                MessageBox.Show("لطفا کد مرکز اسقاط را تکمیل نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                textBox1.Focus();
                return;
            }

            if (textBox2.Text == "")
            {
                MessageBox.Show("لطفا کد رهگیری را تکمیل نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                textBox2.Focus();
                return;
            }

            SqlCommand objCommand1 = new SqlCommand();
            objCommand1.Connection = objConnection;
            objCommand1.CommandText = "UPDATE All_End_Farsode SET S4_2_1=@S4_2_1 ,S4_3_2=@S4_3_2 ,S4_2_2=@S4_2_2 WHERE (S1_idshobe = '" + id_idshobe + "') AND (S1_idmen = '" + id_idmen + "') AND (S1_rad = '" + id_Contract + "')";
            objCommand1.CommandType = CommandType.Text;

            objCommand1.Parameters.AddWithValue("@S4_2_1",u_set.control_date_end(persianDatePicker1.Text));
            objCommand1.Parameters.AddWithValue("@S4_3_2", textBox1.Text);
            objCommand1.Parameters.AddWithValue("@S4_2_2", textBox2.Text);

            objConnection.Open();
            objCommand1.ExecuteNonQuery();
            objConnection.Close();

            u_set.u_amal_register("1", this.Title, id_Contract, "5", "ویرایش");

            this.Hide();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void dataGrid1_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {
                DataRowView _DataView = dataGrid1.CurrentCell.Item as DataRowView;

                if (_DataView != null)
                {
                    textBox1.Text = _DataView.Row[2].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void persianDatePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return) { textBox1.Focus(); }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return) { textBox2.Focus(); }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return) { button1.Focus(); }
        }
    }
}
