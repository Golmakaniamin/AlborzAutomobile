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
    /// Interaction logic for Report_Contract_All.xaml
    /// </summary>
    public partial class Report_Contract_All : Window
    {
        SqlConnection objConnection = new SqlConnection(DB_Base.ConStr);
        SqlDataAdapter objDataAdapter = new SqlDataAdapter();

        DataSet objDataSet = new DataSet();
        DataSet objDataSet1 = new DataSet();

        DB_Base Database = new DB_Base();
        U_Base u_set = new U_Base();

        public string id_idshobe;
        public string search_string = "";

        public string sel_id_shobe = "";
        public string sel_id_men = "";
        public string sel_id_meli = "";
        public string sel_id_contract = "";
        public string sel_id_noe = "";

        public Report_Contract_All()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            textBox1.Text = id_idshobe;

            Database.Connection_Open();
            Database.Fill("SELECT * FROM All_Marahel ORDER BY tmpid", objDataSet, "All_Marahel", true);
            Database.Connection_Close();

            dataGrid2.DataContext = objDataSet;

            if (search_string != "")
            {
                Database.Connection_Open();
                Database.Fill("SELECT * FROM View_ALL_END_Ravand WHERE (" + search_string + ") ORDER BY S1_rad", objDataSet, "View_ALL_END_Ravand", true);
                Database.Connection_Close();
            }

            dataGrid1.DataContext = objDataSet;
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Customers_Search f1 = new Customers_Search();
            f1.sel_noe = "2";
            f1.Show();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            search_string = "";

            if ((persianDatePicker1.Text != "") && (persianDatePicker2.Text != ""))
            {
                search_string = search_string + " (datesabt >= '" + u_set.control_date_end(persianDatePicker1.Text) + "') AND (datesabt <= '" + u_set.control_date_end(persianDatePicker2.Text) + "') AND ";
            }

            if (textBox1.Text != "")
            {
                search_string = search_string + " (S1_idshobe = '" + textBox1.Text + "') AND ";
            }

            if (textBox2.Text != "")
            {
                search_string = search_string + " (S1_idmen = '" + textBox2.Text + "') AND ";
            }

            string search_string_under = "";
            for (int q = 0; q < objDataSet.Tables["All_Marahel"].Rows.Count; q++)
                if (objDataSet.Tables["All_Marahel"].Rows[q]["sel"].ToString() == "True")
                    search_string_under = search_string_under + objDataSet.Tables["All_Marahel"].Rows[q]["tmpid"].ToString() + ",";

            search_string_under = search_string_under.Substring(0, search_string_under.Length - 1);
            search_string = search_string + "(tmpid IN (" + search_string_under + ")) AND ";

            search_string = search_string.Substring(0, search_string.Length - 4);

            if (search_string == "")
            {
                Database.Connection_Open();
                Database.Fill("SELECT * FROM View_ALL_END_Ravand ORDER BY S1_rad", objDataSet, "View_ALL_END_Ravand", true);
                Database.Connection_Close();
            }
            else
            {
                Database.Connection_Open();
                Database.Fill("SELECT * FROM View_ALL_END_Ravand WHERE (" + search_string + ") ORDER BY S1_rad", objDataSet, "View_ALL_END_Ravand", true);
                Database.Connection_Close();
            }
            dataGrid1.DataContext = objDataSet;
        }

        private void dataGrid1_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            if (objDataSet.Tables["View_ALL_END_Ravand"].Rows.Count != e.Row.GetIndex())
                objDataSet.Tables["View_ALL_END_Ravand"].Rows[Convert.ToInt32(e.Row.GetIndex())][23] = (e.Row.GetIndex() + 1).ToString();
        }

        private void checkBox1_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                for (int q = 0; q < objDataSet.Tables["All_Marahel"].Rows.Count; q++)
                    objDataSet.Tables["All_Marahel"].Rows[q]["sel"] = true;
            }
            catch
            {
            }
        }

        private void checkBox1_Unchecked(object sender, RoutedEventArgs e)
        {
            for (int q = 0; q < objDataSet.Tables["All_Marahel"].Rows.Count; q++)
                objDataSet.Tables["All_Marahel"].Rows[q]["sel"] = false;
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            if (sel_id_noe != "")
            {
                Customers f1 = new Customers();
                f1.id_group = sel_id_shobe;
                f1.sel_id_idshobe = sel_id_shobe;
                f1.sel_id_idmen = sel_id_men;
                f1.label16.Content = "Edit";
                f1.Show();
            }
        }

        private void dataGrid1_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {
                DataRowView _DataView = dataGrid1.CurrentCell.Item as DataRowView;

                if (_DataView != null)
                {
                    sel_id_noe = _DataView.Row[0].ToString();
                    sel_id_men= _DataView.Row[3].ToString();
                    sel_id_meli = _DataView.Row[4].ToString();
                    sel_id_contract = _DataView.Row[5].ToString();
                    sel_id_shobe = _DataView.Row[6].ToString();
                }
            }
            catch
            {
            }
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            if (sel_id_noe != "")
            {
                if (sel_id_noe == "1")
                {
                    Rusty f2 = new Rusty();
                    f2.id_idshobe = sel_id_shobe;
                    f2.id_idmen = sel_id_men;
                    f2.Show();
                }

                if (sel_id_noe == "2")
                {
                    Leasing f3 = new Leasing();
                    f3.id_idshobe = sel_id_shobe;
                    f3.id_idmen = sel_id_men;
                    f3.Show();
                }
            }
        }
    }
}
