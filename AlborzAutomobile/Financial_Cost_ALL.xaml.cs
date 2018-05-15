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
    /// Interaction logic for Financial_Cost_ALL.xaml
    /// </summary>
    public partial class Financial_Cost_ALL : Window
    {
        SqlConnection objConnection = new SqlConnection(DB_Base.ConStr);
        SqlDataAdapter objDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();

        DB_Base Database = new DB_Base();

        public string id_group;
        public string Txt_search;

        public string sel_tmpid = "";

        public Financial_Cost_ALL()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Database.Connection_Open();
            Database.Fill(Txt_search, objDataSet, "Sherkat_hazineh", true);
            Database.Connection_Close();

            dataGrid1.DataContext = objDataSet;
        }

        private void dataGrid1_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {
                DataRowView _DataView = dataGrid1.CurrentCell.Item as DataRowView;

                if (_DataView != null)
                {
                    sel_tmpid = _DataView.Row[0].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Financial_Cost f1 = new Financial_Cost();
            f1.idshobe = id_group;
            f1.sel_work = "New";
            f1.Show();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            Financial_Cost f1 = new Financial_Cost();
            f1.idshobe = id_group;
            f1.sel_work = "Edit";
            f1.sel_tmpid = sel_tmpid;
            f1.Show();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            Financial_Cost_Search f1 = new Financial_Cost_Search();
            f1.idshobe = id_group;
            f1.Show();
            this.Close();
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            CrystalReportWpf_AlborzAutomobile.Window1 f1 = new CrystalReportWpf_AlborzAutomobile.Window1();
            f1.Title = "چاپ رسید هزینه";
            f1.selkar = "Crystal_Financial_Cost";
            f1.id_Contract = sel_tmpid;
            f1.Show();
        }
    }
}
