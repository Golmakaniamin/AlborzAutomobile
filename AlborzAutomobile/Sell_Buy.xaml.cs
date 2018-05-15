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
    /// Interaction logic for Sell_Buy.xaml
    /// </summary>
    public partial class Sell_Buy : Window
    {
        SqlConnection objConnection = new SqlConnection(DB_Base.ConStr);
        SqlDataAdapter objDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();

        DB_Base Database = new DB_Base();
        U_Base u_set = new U_Base();

        public string id_idshobe;
        public string id_Contract;

        public Sell_Buy()
        {
            InitializeComponent();
        }

        private void Alborz_buttom_hideAll()
        {
            button2.Visibility = System.Windows.Visibility.Hidden;
            button3.Visibility = System.Windows.Visibility.Hidden;
            button5.Visibility = System.Windows.Visibility.Hidden;
            button6.Visibility = System.Windows.Visibility.Hidden;
        }

        private void Alborz_buttom_Show()
        {
            button2.Visibility = System.Windows.Visibility.Visible;
            button3.Visibility = System.Windows.Visibility.Visible;
            button5.Visibility = System.Windows.Visibility.Visible;
            button6.Visibility = System.Windows.Visibility.Visible;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Alborz_buttom_hideAll();

        }

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            Database.Connection_Open();
            Database.Fill("SELECT * FROM All_Sell_Buy WHERE (rad = '" + textBox1.Text + "')", objDataSet, "All_Sell_Buy", true);
            Database.Connection_Close();

            dataGrid1.DataContext = objDataSet;
        }

        private void button11_Click(object sender, RoutedEventArgs e)
        {
            Sell_Buy_01_Sabt f1 = new Sell_Buy_01_Sabt();
            f1.Title = button2.Content.ToString();
            f1.selStatus = "New";
            f1.id_1_idshobe = id_idshobe;
            f1.id_2_idshobe = id_idshobe;
            f1.id_Contract = id_Contract;
            f1.Show();
        }

        private void dataGrid1_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {
                DataRowView _DataView = dataGrid1.CurrentCell.Item as DataRowView;

                if (_DataView != null)
                {
                    id_Contract = _DataView.Row[3].ToString();
                    Alborz_buttom_Show();
                }
            }
            catch
            {

            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Sell_Buy_01_Sabt f1 = new Sell_Buy_01_Sabt();
            f1.Title = button2.Content.ToString() + " قرارداد شماره : " + id_Contract;
            f1.selStatus = "Edit";
            f1.id_1_idshobe = id_idshobe;
            f1.id_2_idshobe = id_idshobe;
            f1.id_Contract = id_Contract;
            f1.Show();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            NewCar f1 = new NewCar();
            f1.Title = button3.Content.ToString() + " قرارداد شماره : " + id_Contract;
            f1.selkar = "5";
            f1.id_idshobe = id_idshobe;
            f1.id_Contract = id_Contract;
            f1.Show();
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            Sell_Buy_04_Sodor_sanad_check f1 = new Sell_Buy_04_Sodor_sanad_check();
            f1.Show();
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            Sell_Buy_05_sodor_sanad_varizi f1 = new Sell_Buy_05_sodor_sanad_varizi();
            f1.Show();
        }
    }
}
