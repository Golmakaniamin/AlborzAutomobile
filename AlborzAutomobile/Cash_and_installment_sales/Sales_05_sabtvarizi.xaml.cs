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
    /// Interaction logic for Leasing_03_sabtvarizi.xaml
    /// </summary>
    public partial class Sales_05_sabtvarizi : Window
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

        public string Sel_Fish;

        public Sales_05_sabtvarizi()
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

            comboBox2.Items.Add("پذیرش");
            comboBox2.Items.Add("پیش قرارداد");
            comboBox2.Items.Add("پیش پرداخت");
            comboBox2.Items.Add("کسری واریزی");
            comboBox2.Items.Add("اخذ پلاک مجازی");
            comboBox2.Items.Add("حمل خودرو");
            comboBox2.Items.Add("سایر هزینه ها");

            Database.Connection_Open();
            Database.Fill("SELECT * FROM infokhodromali WHERE (S1_rad = '" + id_Contract + "')", objDataSet, "ONE_All_End_Farsode_list", true);
            Database.Connection_Close();

            dataGrid1.DataContext = objDataSet;

            alborz_calc_money();
        }

        private void alborz_calc_money()
        {
            objDataSet1.Clear();
            Database.Connection_Open();
            Database.Fill("SELECT * FROM All_End_EzareBeShartTamlik WHERE (S1_rad = '" + id_Contract + "')", objDataSet1, "All_End_EzareBeShartTamlik", true);
            Database.Connection_Close();

            label7.Content = objDataSet1.Tables["All_End_EzareBeShartTamlik"].Rows[0]["s2_money"].ToString();

            objDataSet1.Clear();
            Database.Connection_Open();
            Database.Fill("SELECT ISNULL(SUM(moneyvariz),0) AS rssum FROM infokhodromali WHERE (S1_rad = '" + id_Contract + "')", objDataSet1, "ONE_All_End_Farsode_list", true);
            Database.Connection_Close();

            if (objDataSet1.Tables["ONE_All_End_Farsode_list"].Rows.Count > 0)
                label9.Content = Convert.ToDouble(objDataSet1.Tables["ONE_All_End_Farsode_list"].Rows[0]["rssum"].ToString()).ToString();
            else
                label9.Content = "0";

            label11.Content = Convert.ToDouble(label7.Content) - Convert.ToDouble(label9.Content);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (persianDatePicker1.Text == "")
            {
                MessageBox.Show("لطفا تاریخ واریز را تکمیل نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                persianDatePicker1.Focus();
                return;
            }

            if (textBox2.Text == "")
            {
                MessageBox.Show("لطفا مبلغ را تکمیل نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                textBox2.Focus();
                return;
            }

            if (Convert.ToInt32(textBox2.Text) < 1000000)
            {
                MessageBox.Show("لطفا مبلغ را صحیح وارد نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                textBox2.Focus();
                return;
            }

            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("لطفا بانک را انتخاب نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                comboBox1.Focus();
                return;
            }

            if (textBox3.Text == "")
            {
                MessageBox.Show("لطفا شماره فیش را تکمیل نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                textBox3.Focus();
                return;
            }

            if (comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("لطفا بابت را انتخاب نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                comboBox2.Focus();
                return;
            }

            SqlCommand objCommand1 = new SqlCommand();
            objCommand1.Connection = objConnection;
            objCommand1.CommandText = "INSERT INTO infokhodromali (idshobe,idkhodro,eachdate,bank1,prompt,shfish,moneyvariz,S1_rad) VALUES (@idshobe,@idkhodro,@eachdate,@bank1,@prompt,@shfish,@moneyvariz,@S1_rad)";
            objCommand1.CommandType = CommandType.Text;

            objCommand1.Parameters.AddWithValue("@idshobe", id_idshobe);
            objCommand1.Parameters.AddWithValue("@idkhodro", id_idmen);
            objCommand1.Parameters.AddWithValue("@eachdate", u_set.control_date_end(persianDatePicker1.Text));
            objCommand1.Parameters.AddWithValue("@bank1", comboBox1.Text);
            objCommand1.Parameters.AddWithValue("@prompt", comboBox2.Text);
            objCommand1.Parameters.AddWithValue("@shfish", textBox3.Text);
            objCommand1.Parameters.AddWithValue("@moneyvariz", Convert.ToInt32(textBox2.Text));
            objCommand1.Parameters.AddWithValue("@S1_rad", id_Contract);

            objConnection.Open();
            objCommand1.ExecuteNonQuery();
            objConnection.Close();

            u_set.u_amal_register("2", this.Title, id_Contract, "3", "ویرایش");

            objDataSet.Clear();
            Database.Connection_Open();
            Database.Fill("SELECT * FROM infokhodromali WHERE (S1_rad = '" + id_Contract + "')", objDataSet, "ONE_All_End_Farsode_list", true);
            Database.Connection_Close();

            dataGrid1.DataContext = objDataSet;

            alborz_calc_money();

            MessageBox.Show("اطلاعات با موفقیت ثبت شد", "", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            SqlCommand objCommand1 = new SqlCommand();
            objCommand1.Connection = objConnection;
            objCommand1.CommandText = "DELETE FROM infokhodromali WHERE (tmpid = '" + Sel_Fish + "')";
            objCommand1.CommandType = CommandType.Text;
            objConnection.Open();
            objCommand1.ExecuteNonQuery();
            objConnection.Close();

            u_set.u_amal_register("2", this.Title, id_Contract, "3", "حذف");

            objDataSet.Clear();
            Database.Connection_Open();
            Database.Fill("SELECT * FROM infokhodromali WHERE (S1_rad = '" + id_Contract + "')", objDataSet, "ONE_All_End_Farsode_list", true);
            Database.Connection_Close();

            dataGrid1.DataContext = objDataSet;

            alborz_calc_money();

            MessageBox.Show("اطلاعات با موفقیت حذف شد", "پيغام", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void dataGrid1_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {
                DataRowView _DataView = dataGrid1.CurrentCell.Item as DataRowView;

                if (_DataView != null)
                {
                    Sel_Fish = _DataView.Row[14].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
