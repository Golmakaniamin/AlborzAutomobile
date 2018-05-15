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
using System.Globalization;

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
        U_Base U_set = new U_Base();

        public string id_group;

        public string sel_id_idshobe = "";
        public string sel_id_idmen = "";

        public AllCustomers()
        {
            InitializeComponent();
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
            catch
            {
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (U_set.e_for_ever() == true)
            {
                Database.Connection_Open();
                Database.Fill(label1.Content.ToString(), objDataSet, "infomen", true);
                Database.Connection_Close();

                dataGrid1.DataContext = objDataSet;
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Customers_Search f1 = new Customers_Search();
            f1.sel_noe = "1";
            f1.Show();
            this.Close();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            //if (sel_id_idshobe != "")
            //{
            //    SqlCommand objCommand1 = new SqlCommand();
            //    objCommand1.Connection = objConnection;
            //    objCommand1.CommandText = "DELETE FROM infomen WHERE (idshobe = '" + sel_id_idshobe + "') AND (idmen = '" + sel_id_idmen + "')";
            //    objCommand1.CommandType = CommandType.Text;
            //    objConnection.Open();
            //    objCommand1.ExecuteNonQuery();
            //    objConnection.Close();
            //    u_set.u_amal_register("0", this.Title, "", "0", "حذف");
            //    MessageBox.Show("اطلاعات مشتری با موفقیت حذف شد", "پيغام", MessageBoxButton.OK, MessageBoxImage.Information);
            //}
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            if (sel_id_idshobe != "")
            {
                Customers f1 = new Customers();
                f1.id_group = id_group;
                f1.sel_id_idshobe = sel_id_idshobe;
                f1.sel_id_idmen = sel_id_idmen;
                f1.label16.Content = "Edit";
                f1.Show();
            }
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            BC_SEC f1 = new BC_SEC();
            f1.id_group = id_group;
            f1.sel_work = "1";
            f1.Show();
        }

        private void dataGrid1_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            if (objDataSet.Tables["infomen"].Rows.Count != e.Row.GetIndex())
                objDataSet.Tables["infomen"].Rows[Convert.ToInt32(e.Row.GetIndex())][21] = (e.Row.GetIndex() + 1).ToString();
        }

        private void MenuItem_Click_6(object sender, RoutedEventArgs e)
        {

        }

        private void mnu18_Click(object sender, RoutedEventArgs e)
        {

        }

        private void mnu22_Click(object sender, RoutedEventArgs e)
        {
            Sales_01_Main f3 = new Sales_01_Main();
            f3.id_idshobe = sel_id_idshobe;
            f3.id_idmen = sel_id_idmen;
            f3.Show();
        }

        private void mnu4_Click(object sender, RoutedEventArgs e)
        {
            Leasing f3 = new Leasing();
            f3.id_idshobe = sel_id_idshobe;
            f3.id_idmen = sel_id_idmen;
            f3.Show();
        }

        private void mnu3_Click(object sender, RoutedEventArgs e)
        {
            Rusty f2 = new Rusty();
            f2.id_idshobe = sel_id_idshobe;
            f2.id_idmen = sel_id_idmen;
            f2.Show();
        }

        private void dataGrid1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton.ToString() == "Pressed")
            {
                try
                {
                    DataRowView _DataView = dataGrid1.CurrentCell.Item as DataRowView;

                    if (_DataView != null)
                    {
                        sel_id_idshobe = _DataView.Row[0].ToString();
                        sel_id_idmen = _DataView.Row[3].ToString();

                        Customers f1 = new Customers();
                        f1.id_group = id_group;
                        f1.sel_id_idshobe = sel_id_idshobe;
                        f1.sel_id_idmen = sel_id_idmen;
                        f1.label16.Content = "Edit";
                        f1.Show();
                    }
                }
                catch
                {
                }
            }
        }
    }
}
