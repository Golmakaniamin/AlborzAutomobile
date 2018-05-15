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
    /// Interaction logic for All_Company_Car.xaml
    /// </summary>
    public partial class All_Company_Car : Window
    {
        SqlConnection objConnection = new SqlConnection(DB_Base.ConStr);
        SqlDataAdapter objDataAdapter = new SqlDataAdapter();

        DataSet objDataSet = new DataSet();
        DataSet objDataSet1 = new DataSet();

        DB_Base Database = new DB_Base();
        U_Base u_set = new U_Base();

        string sel_idsherkat_ALL = "0";
        string sel_namesherkat_ALL = "";

        public All_Company_Car()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Database.Connection_Open();
            Database.Fill("SELECT idsherkat,namesherkat FROM infonewall GROUP BY idsherkat,namesherkat ORDER BY idsherkat", objDataSet, "infonewall", true);
            Database.Connection_Close();

            dataGrid1.DataContext = objDataSet;
        }

        private void sel_idkhodro()
        {
            Database.Connection_Open();
            Database.Fill("SELECT * FROM infonewall WHERE (idsherkat = " + sel_idsherkat_ALL + ") ORDER BY idsherkat", objDataSet1, "infonewall1", true);
            Database.Connection_Close();

            dataGrid2.DataContext = objDataSet1;
        }

        private void dataGrid1_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {
                DataRowView _DataView = dataGrid1.CurrentCell.Item as DataRowView;

                if (_DataView != null)
                {
                    sel_idsherkat_ALL = _DataView.Row[0].ToString();
                    sel_namesherkat_ALL = _DataView.Row[1].ToString();
                    sel_idkhodro();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return) { button1.Focus(); }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return) { button2.Focus(); }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("لطفا نام شرکت سازنده را تکمیل نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                textBox1.Focus();
                return;
            }

            SqlCommand objCommand2 = new SqlCommand();
            objCommand2.Connection = objConnection;
            objCommand2.CommandText = "INSERT INTO infonewall (idsherkat,namesherkat,idkhodro,namekhodro) VALUES (@idsherkat,@namesherkat,@idkhodro,@namekhodro)";
            objCommand2.CommandType = CommandType.Text;

            Database.Connection_Open();
            Database.Fill("SELECT ISNULL(MAX(idsherkat),0) AS rsmax FROM infonewall", objDataSet, "infonewall_1", true);
            Database.Connection_Close();

            objCommand2.Parameters.AddWithValue("@idsherkat", (Convert.ToInt64(objDataSet.Tables["infonewall_1"].Rows[0]["rsmax"].ToString()) + 1).ToString());
            objCommand2.Parameters.AddWithValue("@namesherkat", textBox1.Text);
            objCommand2.Parameters.AddWithValue("@idkhodro", "0");
            objCommand2.Parameters.AddWithValue("@namekhodro", "-");

            objConnection.Open();
            objCommand2.ExecuteNonQuery();
            objConnection.Close();

            MessageBox.Show("اطلاعات با موفقیت ثبت شد", "", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            if (sel_idsherkat_ALL == "0")
            {
                MessageBox.Show("لطفا نام شرکت سازنده را انتخاب نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                dataGrid1.Focus();
                return;
            }

            if (textBox2.Text == "")
            {
                MessageBox.Show("لطفا نام شرکت سازنده را تکمیل نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                textBox2.Focus();
                return;
            }

            SqlCommand objCommand2 = new SqlCommand();
            objCommand2.Connection = objConnection;
            objCommand2.CommandText = "INSERT INTO infonewall (idsherkat,namesherkat,idkhodro,namekhodro) VALUES (@idsherkat,@namesherkat,@idkhodro,@namekhodro)";
            objCommand2.CommandType = CommandType.Text;

            Database.Connection_Open();
            Database.Fill("SELECT ISNULL(MAX(idkhodro),0) AS rsmax FROM infonewall WHERE (idsherkat = " + sel_idsherkat_ALL + ")", objDataSet, "infonewall_2", true);
            Database.Connection_Close();

            objCommand2.Parameters.AddWithValue("@idsherkat", sel_idsherkat_ALL);
            objCommand2.Parameters.AddWithValue("@namesherkat", sel_namesherkat_ALL);
            objCommand2.Parameters.AddWithValue("@idkhodro", (Convert.ToInt64(objDataSet.Tables["infonewall_2"].Rows[0]["rsmax"].ToString()) + 1).ToString());
            objCommand2.Parameters.AddWithValue("@namekhodro", textBox2.Text);

            objConnection.Open();
            objCommand2.ExecuteNonQuery();
            objConnection.Close();

            MessageBox.Show("اطلاعات با موفقیت ثبت شد", "", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void dataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
