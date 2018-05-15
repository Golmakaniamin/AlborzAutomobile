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
    /// Interaction logic for Rusty_12_Sodor.xaml
    /// </summary>
    public partial class Rusty_12_Sodor : Window
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

        public Rusty_12_Sodor()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Database.Connection_Open();
            Database.Fill("SELECT * FROM All_End_Farsode WHERE (S1_idshobe = '" + id_idshobe + "') AND (S1_idmen = '" + id_idmen + "') AND (S1_rad = '" + id_Contract + "')", objDataSet, "All_End_Farsode", true);
            Database.Connection_Close();

            persianDatePicker1.Text = objDataSet.Tables["All_End_Farsode"].Rows[0]["S5_Dateend"].ToString();

            objDataSet.Tables["All_End_Farsode"].Clear();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            SqlCommand objCommand1 = new SqlCommand();
            objCommand1.Connection = objConnection;
            objCommand1.CommandText = "UPDATE All_End_Farsode SET S5_Dateend=@S5_Dateend WHERE (S1_idshobe = '" + id_idshobe + "') AND (S1_idmen = '" + id_idmen + "') AND (S1_rad = '" + id_Contract + "')";
            objCommand1.CommandType = CommandType.Text;

            objCommand1.Parameters.AddWithValue("@S5_Dateend", u_set.control_date_end(persianDatePicker1.Text));

            objConnection.Open();
            objCommand1.ExecuteNonQuery();
            objConnection.Close();

            u_set.u_amal_register("1", this.Title, id_Contract, "12", "ویرایش");

            NewCar f1 = new NewCar();
            f1.Title = "اطلاعات خودرو جایگزین فرسوده قرارداد شماره : " + id_Contract;
            f1.selkar = "3";
            f1.id_idshobe = id_idshobe;
            f1.id_idmen = id_idmen;
            f1.id_Contract = id_Contract;
            f1.expander2.Visibility = button2.Visibility = System.Windows.Visibility.Hidden;
            f1.expander3.Visibility = button2.Visibility = System.Windows.Visibility.Hidden;
            f1.Show();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            CrystalReportWpf_AlborzAutomobile.Window1 f1 = new CrystalReportWpf_AlborzAutomobile.Window1();
            f1.Title = "حواله تحویل خودرو فرسوده شماره : " + id_Contract;
            f1.selkar = "Crystal_Rusty_12_Havalehe_Tahvil";
            f1.id_Contract = id_Contract;
            f1.Show();
        }
    }
}
