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
    /// Interaction logic for Leasing.xaml
    /// </summary>
    public partial class Sales_01_Main : Window
    {
        SqlConnection objConnection = new SqlConnection(DB_Base.ConStr);
        SqlDataAdapter objDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();
        DataSet objDataSet1 = new DataSet();
        DataSet objDataSet2 = new DataSet();

        DB_Base Database = new DB_Base();
        U_Base u_set = new U_Base();

        public string id_idshobe;
        public string id_idmen;
        public string id_Contract;

        public Sales_01_Main()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (id_idshobe != "")
            {
                textBox1.Text = id_idshobe;
            }

            if (id_idmen != "")
            {
                textBox2.Text = id_idmen;
            }
        }

        public void Alborz1_Selectmen()
        {
            if (textBox2.Text != "")
            {
                id_idshobe = textBox1.Text;
                id_idmen = textBox2.Text;

                Database.Connection_Open();
                Database.Fill("SELECT * FROM infomen WHERE ((idmen = '" + id_idmen + "') AND (idshobe = '" + id_idshobe + "'))", objDataSet, "ONE_infomen", true);
                Database.Connection_Close();

                if (objDataSet.Tables["ONE_infomen"].Rows.Count > 0)
                {
                    label4.Content = objDataSet.Tables["ONE_infomen"].Rows[0]["name"].ToString();
                    label6.Content = objDataSet.Tables["ONE_infomen"].Rows[0]["family"].ToString();
                    label9.Content = objDataSet.Tables["ONE_infomen"].Rows[0]["shsh"].ToString();
                    textBox3.Text = objDataSet.Tables["ONE_infomen"].Rows[0]["id"].ToString();
                }

                objDataSet.Clear();

                Database.Connection_Open();
                Database.Fill("SELECT * FROM All_End_Cash_and_installment_sales WHERE ((S1_idmen = '" + id_idmen + "') AND (S1_idshobe = '" + id_idshobe + "'))", objDataSet, "ONE_All_End_Cash_and_installment_sales_list", true);
                Database.Connection_Close();

                dataGrid1.DataContext = objDataSet;
                return;
            }
        }

        public void Alborz2_Selectmen()
        {
            if (textBox3.Text != "")
            {
                Database.Connection_Open();
                Database.Fill("SELECT * FROM infomen WHERE (id = '" + textBox3.Text + "')", objDataSet, "ONE_infomen", true);
                Database.Connection_Close();

                if (objDataSet.Tables["ONE_infomen"].Rows.Count > 0)
                {
                    id_idshobe = objDataSet.Tables["ONE_infomen"].Rows[0]["idshobe"].ToString();
                    textBox1.Text = id_idshobe;

                    label4.Content = objDataSet.Tables["ONE_infomen"].Rows[0]["name"].ToString();
                    label6.Content = objDataSet.Tables["ONE_infomen"].Rows[0]["family"].ToString();
                    label9.Content = objDataSet.Tables["ONE_infomen"].Rows[0]["shsh"].ToString();
                    textBox2.Text = objDataSet.Tables["ONE_infomen"].Rows[0]["idmen"].ToString();
                }

                objDataSet.Clear();

                Database.Connection_Open();
                Database.Fill("SELECT * FROM All_End_Cash_and_installment_sales WHERE (S1_idmeli = '" + textBox3.Text + "')", objDataSet, "ONE_All_End_Cash_and_installment_sales_list", true);
                Database.Connection_Close();

                dataGrid1.DataContext = objDataSet;
                return;
            }
        }

        private void textBox2_TextChanged(object sender, TextChangedEventArgs e)
        {
            Alborz1_Selectmen();
        }

        private void textBox3_TextChanged(object sender, TextChangedEventArgs e)
        {
            Alborz2_Selectmen();
        }

        private void alborz_dataGrid1_Selected1(string amin)
        {
            id_Contract = amin;

            SqlCommand myCommand = new SqlCommand("SEL_Level_All_End_Cash_and_installment_sales");
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Connection = objConnection;
            myCommand.Parameters.AddWithValue("@id_gharardad", id_Contract);
            SqlDataAdapter da = new SqlDataAdapter(myCommand);

            if (objDataSet.Tables["All_End_Cash_and_installment_sales_Level"] != null)
                objDataSet.Tables["All_End_Cash_and_installment_sales_Level"].Clear();
            da.Fill(objDataSet, "All_End_Cash_and_installment_sales_Level");

            dataGrid2.DataContext = objDataSet;
        }

        private void alborz_dataGrid1_Selected2(string amin,string name_amin)
        {
            switch (amin)
            {
                case "1" :
                    {
                        Sales_02_sabtdarkhast f1 = new Sales_02_sabtdarkhast();
                        f1.selStatus = "Edit";
                        f1.Title = name_amin + " قرارداد شماره : " + id_Contract;
                        f1.id_idshobe = id_idshobe;
                        f1.id_idmen = id_idmen;
                        f1.id_Contract = id_Contract;
                        f1.Show();

                        break;
                    }

                case "2":
                    {
                        break;
                    }

                case "3":
                    {
                        Sales_04_vekalatnameh f1 = new Sales_04_vekalatnameh();
                        f1.Title = name_amin + " قرارداد شماره : " + id_Contract; ;
                        f1.id_idshobe = id_idshobe;
                        f1.id_idmen = id_idmen;
                        f1.id_Contract = id_Contract;
                        f1.Show();

                        break;
                    }

                case "4":
                    {
                        Sales_05_sabtvarizi f1 = new Sales_05_sabtvarizi();
                        f1.Title = name_amin + " قرارداد شماره : " + id_Contract; ;
                        f1.id_idshobe = id_idshobe;
                        f1.id_idmen = id_idmen;
                        f1.id_Contract = id_Contract;
                        f1.Show();

                        break;
                    }

                case "5":
                    {
                        Sales_06_Datetakmil f1 = new Sales_06_Datetakmil();
                        f1.Title = name_amin + " قرارداد شماره : " + id_Contract; ;
                        f1.id_idshobe = id_idshobe;
                        f1.id_idmen = id_idmen;
                        f1.id_Contract = id_Contract;
                        f1.Show();

                        break;
                    }

                case "6":
                    {
                        Sales_07_Sodorcheckkharid f1 = new Sales_07_Sodorcheckkharid();
                        f1.Title = name_amin + " قرارداد شماره : " + id_Contract; ;
                        f1.id_idshobe = id_idshobe;
                        f1.id_idmen = id_idmen;
                        f1.id_Contract = id_Contract;
                        f1.Show();

                        break;
                    }

                case "7":
                    {
                        break;
                    }

                case "8":
                    {
                        Sales_09_Sodor f1 = new Sales_09_Sodor();
                        f1.Title = name_amin + " قرارداد شماره : " + id_Contract; ;
                        f1.id_idshobe = id_idshobe;
                        f1.id_idmen = id_idmen;
                        f1.id_Contract = id_Contract;
                        f1.Show();

                        break;
                    }

                case "9":
                    {
                        Sales_10_Tahvil f1 = new Sales_10_Tahvil();
                        f1.Title = name_amin + " قرارداد شماره : " + id_Contract; ;
                        f1.id_idshobe = id_idshobe;
                        f1.id_idmen = id_idmen;
                        f1.id_Contract = id_Contract;
                        f1.Show();

                        break;
                    }

                case "10":
                    {
                        break;
                    }

            }
        }

        private void dataGrid1_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {
                DataRowView _DataView = dataGrid1.CurrentCell.Item as DataRowView;

                if (_DataView != null)
                {
                    alborz_dataGrid1_Selected1(_DataView.Row[3].ToString());
                }
            }
            catch
            {

            }
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            if (label6.Content != null)
            {
                Sales_02_sabtdarkhast f1 = new Sales_02_sabtdarkhast();
                f1.selStatus = "New";
                f1.Title = "درخواست جدید";
                f1.id_idshobe = id_idshobe;
                f1.id_idmen = id_idmen;
                f1.id_Contract = textBox3.Text;
                f1.Show();
            }
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            Alborz1_Selectmen();
        }

        private void button9_Click(object sender, RoutedEventArgs e)
        {
            Database.Connection_Open();
            Database.Fill("SELECT * FROM All_End_Cash_and_installment_sales WHERE (S1_idmeli = '" + textBox3.Text + "') AND (S1_rad = '" + id_Contract + "')", objDataSet, "All_End_Cash_and_installment_sales", true);
            Database.Connection_Close();

            SqlCommand objCommand1 = new SqlCommand();
            objCommand1.Connection = objConnection;
            objCommand1.CommandText = "UPDATE All_End_Cash_and_installment_sales SET s1_enseraf=@s1_enseraf WHERE (S1_idmeli = '" + textBox3.Text + "') AND (S1_rad = '" + id_Contract + "')";
            objCommand1.CommandType = CommandType.Text;

            if (objDataSet.Tables["All_End_Cash_and_installment_sales"].Rows[0]["s1_enseraf"].ToString() == "جاری")
                objCommand1.Parameters.AddWithValue("@s1_enseraf", "غیر فعال");
            else
                objCommand1.Parameters.AddWithValue("@s1_enseraf", "جاری");

            objConnection.Open();
            objCommand1.ExecuteNonQuery();
            objConnection.Close();

            u_set.u_amal_register("5", this.Title, id_Contract, "0", "غیر فعال");

            Alborz1_Selectmen();
        }

        private void button8_Click(object sender, RoutedEventArgs e)
        {
            Database.Connection_Open();
            Database.Fill("SELECT * FROM All_End_Cash_and_installment_sales WHERE (S1_idmeli = '" + textBox3.Text + "') AND (S1_rad = '" + id_Contract + "')", objDataSet, "All_End_Cash_and_installment_sales", true);
            Database.Connection_Close();

            SqlCommand objCommand1 = new SqlCommand();
            objCommand1.Connection = objConnection;
            objCommand1.CommandText = "UPDATE All_End_Cash_and_installment_sales SET s1_enseraf=@s1_enseraf WHERE (S1_idmeli = '" + textBox3.Text + "') AND (S1_rad = '" + id_Contract + "')";
            objCommand1.CommandType = CommandType.Text;

            if (objDataSet.Tables["All_End_Cash_and_installment_sales"].Rows[0]["s1_enseraf"].ToString() == "جاری")
                objCommand1.Parameters.AddWithValue("@s1_enseraf", "انصراف");
            else
                objCommand1.Parameters.AddWithValue("@s1_enseraf", "جاری");

            objConnection.Open();
            objCommand1.ExecuteNonQuery();
            objConnection.Close();

            u_set.u_amal_register("5", this.Title, id_Contract, "0", "انصراف");

            Alborz1_Selectmen();
        }

        private void button7_Click(object sender, RoutedEventArgs e)
        {
            //SqlCommand objCommand1 = new SqlCommand();
            //objCommand1.Connection = objConnection;
            //objCommand1.CommandText = "DELETE FROM All_End_EzareBeShartTamlik WHERE (S1_rad = '" + id_Contract + "')";
            //objCommand1.CommandType = CommandType.Text;

            //objConnection.Open();
            //objCommand1.ExecuteNonQuery();
            //objConnection.Close();


            //SqlCommand objCommand2 = new SqlCommand();
            //objCommand2.Connection = objConnection;
            //objCommand2.CommandText = "DELETE FROM infokhodromali WHERE (S1_rad = '" + id_Contract + "')";
            //objCommand2.CommandType = CommandType.Text;

            //objConnection.Open();
            //objCommand2.ExecuteNonQuery();
            //objConnection.Close();

            //SqlCommand objCommand3 = new SqlCommand();
            //objCommand3.Connection = objConnection;
            //objCommand3.CommandText = "INSERT INTO UserAmal (uuser,udate,utime,upc,id,place,Contract,rad,noe) VALUES (@uuser,@udate,@utime,@upc,@id,@place,@Contract,@rad,@noe)";
            //objCommand3.CommandType = CommandType.Text;

            //objCommand3.Parameters.AddWithValue("@uuser", u_set.u_user());
            //objCommand3.Parameters.AddWithValue("@udate", u_set.u_date());
            //objCommand3.Parameters.AddWithValue("@utime", u_set.u_time());
            //objCommand3.Parameters.AddWithValue("@upc", u_set.u_pc());
            //objCommand3.Parameters.AddWithValue("@id", "2");
            //objCommand3.Parameters.AddWithValue("@place", button7.Content);
            //objCommand3.Parameters.AddWithValue("@Contract", id_Contract);
            //objCommand3.Parameters.AddWithValue("@rad", "0");
            //objCommand3.Parameters.AddWithValue("@noe", "حذف");

            //objConnection.Open();
            //objCommand3.ExecuteNonQuery();
            //objConnection.Close();

            //MessageBox.Show("قرارداد " + id_Contract + " با موفقیت حذف شد", "", MessageBoxButton.OK, MessageBoxImage.Information);

            //objDataSet.Clear();

            //Database.Connection_Open();
            //Database.Fill("SELECT * FROM All_End_EzareBeShartTamlik WHERE (S1_idshobe = '" + id_idshobe + "') AND (S1_idmeli = '" + textBox3.Text + "')", objDataSet, "ONE_All_End_Farsode_list", true);
            //Database.Connection_Close();

            //dataGrid1.DataContext = objDataSet;

            //alborz_hide_all();
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "Return") 
            {  }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "Return") { Alborz1_Selectmen(); }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "Return") { Alborz2_Selectmen(); }
        }

        private void dataGrid2_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            //try
            //{
            //    DataRowView _DataView = dataGrid2.CurrentCell.Item as DataRowView;

            //    if (_DataView != null)
            //    {
            //        alborz_dataGrid1_Selected2(_DataView.Row[0].ToString(), _DataView.Row[1].ToString());
            //    }
            //}
            //catch
            //{

            //}
        }

        private void dataGrid2_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton.ToString() == "Pressed")
            {
                try
                {
                    DataRowView _DataView = dataGrid2.CurrentCell.Item as DataRowView;

                    if (_DataView != null)
                    {
                        alborz_dataGrid1_Selected2(_DataView.Row[0].ToString(), _DataView.Row[1].ToString());
                    }
                }
                catch
                {

                }
            }
        }
    }
}
