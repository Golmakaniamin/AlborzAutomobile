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
    /// Interaction logic for Leasing_05_Sodor.xaml
    /// </summary>
    public partial class Sales_09_Sodor : Window
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

        public Sales_09_Sodor()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Database.Connection_Open();
            Database.Fill("SELECT * FROM All_End_EzareBeShartTamlik WHERE (S1_idshobe = '" + id_idshobe + "') AND (S1_idmen = '" + id_idmen + "') AND (S1_rad = '" + id_Contract + "')", objDataSet, "All_End_EzareBeShartTamlik", true);
            Database.Connection_Close();

            persianDatePicker1.Text = objDataSet.Tables["All_End_EzareBeShartTamlik"].Rows[0]["S6_Datesodor"].ToString();

            objDataSet.Tables["All_End_EzareBeShartTamlik"].Clear();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            SqlCommand objCommand1 = new SqlCommand();
            objCommand1.Connection = objConnection;
            objCommand1.CommandText = "UPDATE All_End_EzareBeShartTamlik SET S6_Datesodor=@S6_Datesodor WHERE (S1_idshobe = '" + id_idshobe + "') AND (S1_idmen = '" + id_idmen + "') AND (S1_rad = '" + id_Contract + "')";
            objCommand1.CommandType = CommandType.Text;

            objCommand1.Parameters.AddWithValue("@S6_Datesodor", u_set.control_date_end(persianDatePicker1.Text));

            objConnection.Open();
            objCommand1.ExecuteNonQuery();
            objConnection.Close();

            u_set.u_amal_register("2", this.Title, id_Contract, "5", "ویرایش");

            NewCar f1 = new NewCar();
            f1.Title = "اطلاعات خودرو جایگزین اجاره به شرط تملیک قرارداد شماره : " + id_Contract;
            f1.selkar = "4";
            f1.id_idshobe = id_idshobe;
            f1.id_idmen = id_idmen;
            f1.id_Contract = id_Contract;
            f1.expander2.Visibility = button2.Visibility = System.Windows.Visibility.Hidden;
            f1.expander3.Visibility = button2.Visibility = System.Windows.Visibility.Hidden;
            f1.Show();

            this.Hide();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            CrystalReportWpf_AlborzAutomobile.Window1 f1 = new CrystalReportWpf_AlborzAutomobile.Window1();
            f1.Title = "صدور حواله تحویل خودرو قرارداد شماره : " + id_Contract;
            f1.selkar = "Crystal_Leasing_02_Havalehe_Tahvil";
            f1.id_Contract = id_Contract;
            f1.Show();
        }
    }
}
