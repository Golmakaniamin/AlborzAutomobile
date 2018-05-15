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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace AlborzAutomobile
{
    /// <summary>
    /// Interaction logic for AllCustomers.xaml
    /// </summary>

    public partial class AllCustomers : Window
    {
        SqlConnection objConnection = new SqlConnection(DB_Base.ConStr);
        SqlDataAdapter objDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();

        DB_Base Database = new DB_Base();

        public string id_group;

        public string sel_id_idshobe;
        public string sel_id_idmen;

        public AllCustomers()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Customers f1 = new Customers();
            f1.id_group = id_group;
            f1.label16.Content = "Add";
            f1.Show();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Customers f1 = new Customers();
            f1.id_group = id_group;
            f1.sel_id_idshobe = sel_id_idshobe;
            f1.sel_id_idmen = sel_id_idmen;
            f1.label16.Content = "Edit";
            f1.Show();
        }

        private void dataGrid1_Loaded(object sender, RoutedEventArgs e)
        {
            //2
        }

        private void dataGrid1_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {
                DataRowView _DataView = dataGrid1.CurrentCell.Item as DataRowView;

                if (_DataView != null)
                {
                    sel_id_idshobe = _DataView.Row[0].ToString();
                    sel_id_idmen = _DataView.Row[3].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            id_group = "101";

            Database.Connection_Open();
            Database.Fill(label1.Content.ToString(), objDataSet, "infomen", true);
            Database.Connection_Close();

            dataGrid1.DataContext = objDataSet;
        }

        private void dataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            SqlCommand objCommand1 = new SqlCommand();
            objCommand1.Connection = objConnection;
            objCommand1.CommandText = "DELETE FROM infomen WHERE (idshobe = '" + sel_id_idshobe + "') AND (idmen = '" + sel_id_idmen + "')";
            objCommand1.CommandType = CommandType.Text;
            objConnection.Open();
            objCommand1.ExecuteNonQuery();
            objConnection.Close();

            MessageBox.Show("اطلاعات با موفقیت حذف شد", "پيغام", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            Customers_Search f1 = new Customers_Search();
            f1.Show();
            this.Close();
        }
    }
}
