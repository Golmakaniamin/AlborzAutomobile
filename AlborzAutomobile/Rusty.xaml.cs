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
    /// Interaction logic for Rusty.xaml
    /// </summary>
    public partial class Rusty : Window
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

        public Rusty()
        {
            InitializeComponent();
        }

        private void Alborz_buttom_hideAll()
        {
            button1.Visibility = System.Windows.Visibility.Hidden;
            button2.Visibility = System.Windows.Visibility.Hidden;
            button3.Visibility = System.Windows.Visibility.Hidden;
            button4.Visibility = System.Windows.Visibility.Hidden;
            button5.Visibility = System.Windows.Visibility.Hidden;
            button6.Visibility = System.Windows.Visibility.Hidden;
            button7.Visibility = System.Windows.Visibility.Hidden;
            button8.Visibility = System.Windows.Visibility.Hidden;
            button9.Visibility = System.Windows.Visibility.Hidden;
            button10.Visibility = System.Windows.Visibility.Hidden;
            button12.Visibility = System.Windows.Visibility.Hidden;
            button13.Visibility = System.Windows.Visibility.Hidden;
            button14.Visibility = System.Windows.Visibility.Hidden;
            button15.Visibility = System.Windows.Visibility.Hidden;
            button16.Visibility = System.Windows.Visibility.Hidden;
            button17.Visibility = System.Windows.Visibility.Hidden;
            button19.Visibility = System.Windows.Visibility.Hidden;
            button22.Visibility = System.Windows.Visibility.Hidden;
        }

        private void Alborz_buttom_1()
        {
            objDataSet2.Clear();
            Database.Connection_Open();
            Database.Fill("SELECT * FROM All_End_Farsode WHERE (S1_rad = '" + id_Contract + "')", objDataSet2, "All_End_Farsode", true);
            Database.Connection_Close();

            Alborz_buttom_hideAll();
            button1.Visibility = System.Windows.Visibility.Visible;
            button12.Visibility = System.Windows.Visibility.Visible;
            button2.Visibility = System.Windows.Visibility.Visible;
            button11.Visibility = System.Windows.Visibility.Visible;
            button19.Visibility = System.Windows.Visibility.Visible;

            if ((objDataSet2.Tables["All_End_Farsode"].Rows[0]["S3_Daftarkhane"].ToString() != "") && (objDataSet2.Tables["All_End_Farsode"].Rows[0]["S3_datet"].ToString() == ""))
            {
                button3.Visibility = System.Windows.Visibility.Visible;
            }

            Database.Connection_Open();
            Database.Fill("SELECT * FROM infokhodromali WHERE (S1_rad = '" + id_Contract + "')", objDataSet2, "Suminfokhodromali", true);
            Database.Connection_Close();

            if ((objDataSet2.Tables["All_End_Farsode"].Rows[0]["S3_datet"].ToString() != "") && (objDataSet2.Tables["Suminfokhodromali"].Rows.Count == 0))
            {
                button3.Visibility = System.Windows.Visibility.Visible;
                button5.Visibility = System.Windows.Visibility.Visible;
            }

            if ((objDataSet2.Tables["Suminfokhodromali"].Rows.Count != 0) && (objDataSet2.Tables["All_End_Farsode"].Rows[0]["s3_2_1"].ToString() == ""))
            {
                button3.Visibility = System.Windows.Visibility.Visible;
                button5.Visibility = System.Windows.Visibility.Visible;
                button4.Visibility = System.Windows.Visibility.Visible;
            }

            if ((objDataSet2.Tables["All_End_Farsode"].Rows[0]["s3_2_1"].ToString() != "") && (objDataSet2.Tables["All_End_Farsode"].Rows[0]["S4_2_1"].ToString() == ""))
            {
                button3.Visibility = System.Windows.Visibility.Visible;
                button5.Visibility = System.Windows.Visibility.Visible;
                button4.Visibility = System.Windows.Visibility.Visible;
                button6.Visibility = System.Windows.Visibility.Visible;
            }

            if ((objDataSet2.Tables["All_End_Farsode"].Rows[0]["S4_2_1"].ToString() != "") && (objDataSet2.Tables["All_End_Farsode"].Rows[0]["S6_datefarakhan"].ToString() == ""))
            {
                button3.Visibility = System.Windows.Visibility.Visible;
                button5.Visibility = System.Windows.Visibility.Visible;
                button4.Visibility = System.Windows.Visibility.Visible;
                button6.Visibility = System.Windows.Visibility.Visible;
                button7.Visibility = System.Windows.Visibility.Visible;
            }

            if ((objDataSet2.Tables["All_End_Farsode"].Rows[0]["S6_datefarakhan"].ToString() != "") && (objDataSet2.Tables["All_End_Farsode"].Rows[0]["S4_3_1"].ToString() == ""))
            {
                button3.Visibility = System.Windows.Visibility.Visible;
                button5.Visibility = System.Windows.Visibility.Visible;
                button4.Visibility = System.Windows.Visibility.Visible;
                button6.Visibility = System.Windows.Visibility.Visible;
                button7.Visibility = System.Windows.Visibility.Visible;
                button8.Visibility = System.Windows.Visibility.Visible;
            }

            if ((objDataSet2.Tables["All_End_Farsode"].Rows[0]["S4_3_1"].ToString() != "") && (objDataSet2.Tables["All_End_Farsode"].Rows[0]["S4_4_1"].ToString() == ""))
            {
                button3.Visibility = System.Windows.Visibility.Visible;
                button5.Visibility = System.Windows.Visibility.Visible;
                button4.Visibility = System.Windows.Visibility.Visible;
                button6.Visibility = System.Windows.Visibility.Visible;
                button7.Visibility = System.Windows.Visibility.Visible;
                button8.Visibility = System.Windows.Visibility.Visible;
                button9.Visibility = System.Windows.Visibility.Visible;
            }

            if ((objDataSet2.Tables["All_End_Farsode"].Rows[0]["S4_4_1"].ToString() != "") && (objDataSet2.Tables["All_End_Farsode"].Rows[0]["S9_2_date1"].ToString() == ""))
            {
                button3.Visibility = System.Windows.Visibility.Visible;
                button5.Visibility = System.Windows.Visibility.Visible;
                button4.Visibility = System.Windows.Visibility.Visible;
                button6.Visibility = System.Windows.Visibility.Visible;
                button7.Visibility = System.Windows.Visibility.Visible;
                button8.Visibility = System.Windows.Visibility.Visible;
                button9.Visibility = System.Windows.Visibility.Visible;
                button16.Visibility = System.Windows.Visibility.Visible;
            }

            if ((objDataSet2.Tables["All_End_Farsode"].Rows[0]["S5_rgkhodro"].ToString() != "") && (objDataSet2.Tables["All_End_Farsode"].Rows[0]["S9_2_date1"].ToString() == ""))
            {
                button3.Visibility = System.Windows.Visibility.Visible;
                button5.Visibility = System.Windows.Visibility.Visible;
                button4.Visibility = System.Windows.Visibility.Visible;
                button6.Visibility = System.Windows.Visibility.Visible;
                button7.Visibility = System.Windows.Visibility.Visible;
                button8.Visibility = System.Windows.Visibility.Visible;
                button9.Visibility = System.Windows.Visibility.Visible;
                button16.Visibility = System.Windows.Visibility.Visible;
                button17.Visibility = System.Windows.Visibility.Visible;
            }

            if ((objDataSet2.Tables["All_End_Farsode"].Rows[0]["S9_2_date1"].ToString() != ""))
            {
                button3.Visibility = System.Windows.Visibility.Visible;
                button5.Visibility = System.Windows.Visibility.Visible;
                button4.Visibility = System.Windows.Visibility.Visible;
                button6.Visibility = System.Windows.Visibility.Visible;
                button7.Visibility = System.Windows.Visibility.Visible;
                button8.Visibility = System.Windows.Visibility.Visible;
                button9.Visibility = System.Windows.Visibility.Visible;
                button16.Visibility = System.Windows.Visibility.Visible;
                button17.Visibility = System.Windows.Visibility.Visible;
                button22.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void Alborz_buttom_2()
        {
            objDataSet2.Clear();
            Database.Connection_Open();
            Database.Fill("SELECT * FROM All_End_Farsode WHERE (S1_rad = '" + id_Contract + "')", objDataSet2, "All_End_Farsode", true);
            Database.Connection_Close();

            Alborz_buttom_hideAll();
            button1.Visibility = System.Windows.Visibility.Visible;
            button12.Visibility = System.Windows.Visibility.Visible;
            button2.Visibility = System.Windows.Visibility.Visible;
            button11.Visibility = System.Windows.Visibility.Visible;
            button19.Visibility = System.Windows.Visibility.Visible;

            if ((objDataSet2.Tables["All_End_Farsode"].Rows[0]["S3_Daftarkhane"].ToString() != "") && (objDataSet2.Tables["All_End_Farsode"].Rows[0]["S3_datet"].ToString() == ""))
            {
                button3.Visibility = System.Windows.Visibility.Visible;
            }

            Database.Connection_Open();
            Database.Fill("SELECT * FROM infokhodromali WHERE (S1_rad = '" + id_Contract + "')", objDataSet2, "Suminfokhodromali", true);
            Database.Connection_Close();

            if ((objDataSet2.Tables["All_End_Farsode"].Rows[0]["S3_datet"].ToString() != "") && (objDataSet2.Tables["Suminfokhodromali"].Rows.Count == 0))
            {
                button3.Visibility = System.Windows.Visibility.Visible;
                button5.Visibility = System.Windows.Visibility.Visible;
            }

            if ((objDataSet2.Tables["Suminfokhodromali"].Rows.Count != 0) && (objDataSet2.Tables["All_End_Farsode"].Rows[0]["s3_2_1"].ToString() == ""))
            {
                button3.Visibility = System.Windows.Visibility.Visible;
                button5.Visibility = System.Windows.Visibility.Visible;
                button4.Visibility = System.Windows.Visibility.Visible;
            }

            if ((objDataSet2.Tables["All_End_Farsode"].Rows[0]["s3_2_1"].ToString() != "") && (objDataSet2.Tables["All_End_Farsode"].Rows[0]["S4_2_1"].ToString() == ""))
            {
                button3.Visibility = System.Windows.Visibility.Visible;
                button5.Visibility = System.Windows.Visibility.Visible;
                button4.Visibility = System.Windows.Visibility.Visible;
                button6.Visibility = System.Windows.Visibility.Visible;
            }

            if ((objDataSet2.Tables["All_End_Farsode"].Rows[0]["S4_2_1"].ToString() != "") && (objDataSet2.Tables["All_End_Farsode"].Rows[0]["S6_datefarakhan"].ToString() == ""))
            {
                button3.Visibility = System.Windows.Visibility.Visible;
                button5.Visibility = System.Windows.Visibility.Visible;
                button4.Visibility = System.Windows.Visibility.Visible;
                button6.Visibility = System.Windows.Visibility.Visible;
                button7.Visibility = System.Windows.Visibility.Visible;
            }

            if ((objDataSet2.Tables["All_End_Farsode"].Rows[0]["S6_datefarakhan"].ToString() != "") && (objDataSet2.Tables["All_End_Farsode"].Rows[0]["S4_3_1"].ToString() == ""))
            {
                button3.Visibility = System.Windows.Visibility.Visible;
                button5.Visibility = System.Windows.Visibility.Visible;
                button4.Visibility = System.Windows.Visibility.Visible;
                button6.Visibility = System.Windows.Visibility.Visible;
                button7.Visibility = System.Windows.Visibility.Visible;
                button8.Visibility = System.Windows.Visibility.Visible;
            }

            if ((objDataSet2.Tables["All_End_Farsode"].Rows[0]["S4_3_1"].ToString() != "") && (objDataSet2.Tables["All_End_Farsode"].Rows[0]["S4_4_1"].ToString() == ""))
            {
                button3.Visibility = System.Windows.Visibility.Visible;
                button5.Visibility = System.Windows.Visibility.Visible;
                button4.Visibility = System.Windows.Visibility.Visible;
                button6.Visibility = System.Windows.Visibility.Visible;
                button7.Visibility = System.Windows.Visibility.Visible;
                button8.Visibility = System.Windows.Visibility.Visible;
                button9.Visibility = System.Windows.Visibility.Visible;
            }

            if ((objDataSet2.Tables["All_End_Farsode"].Rows[0]["S4_4_1"].ToString() != "") && (objDataSet2.Tables["All_End_Farsode"].Rows[0]["S9_date1"].ToString() == ""))
            {
                button3.Visibility = System.Windows.Visibility.Visible;
                button5.Visibility = System.Windows.Visibility.Visible;
                button4.Visibility = System.Windows.Visibility.Visible;
                button6.Visibility = System.Windows.Visibility.Visible;
                button7.Visibility = System.Windows.Visibility.Visible;
                button8.Visibility = System.Windows.Visibility.Visible;
                button9.Visibility = System.Windows.Visibility.Visible;
                button10.Visibility = System.Windows.Visibility.Visible;
            }

            if ((objDataSet2.Tables["All_End_Farsode"].Rows[0]["S9_date1"].ToString() != "") && (objDataSet2.Tables["All_End_Farsode"].Rows[0]["S5_rgkhodro"].ToString() == ""))
            {
                button3.Visibility = System.Windows.Visibility.Visible;
                button5.Visibility = System.Windows.Visibility.Visible;
                button4.Visibility = System.Windows.Visibility.Visible;
                button6.Visibility = System.Windows.Visibility.Visible;
                button7.Visibility = System.Windows.Visibility.Visible;
                button8.Visibility = System.Windows.Visibility.Visible;
                button9.Visibility = System.Windows.Visibility.Visible;
                button10.Visibility = System.Windows.Visibility.Visible;
                button13.Visibility = System.Windows.Visibility.Visible;
            }

            if ((objDataSet2.Tables["All_End_Farsode"].Rows[0]["S5_rgkhodro"].ToString() != "") && (objDataSet2.Tables["All_End_Farsode"].Rows[0]["S5_datevariz"].ToString() == ""))
            {
                button3.Visibility = System.Windows.Visibility.Visible;
                button5.Visibility = System.Windows.Visibility.Visible;
                button4.Visibility = System.Windows.Visibility.Visible;
                button6.Visibility = System.Windows.Visibility.Visible;
                button7.Visibility = System.Windows.Visibility.Visible;
                button8.Visibility = System.Windows.Visibility.Visible;
                button9.Visibility = System.Windows.Visibility.Visible;
                button10.Visibility = System.Windows.Visibility.Visible;
                button13.Visibility = System.Windows.Visibility.Visible;
                button14.Visibility = System.Windows.Visibility.Visible;
            }

            if (objDataSet2.Tables["All_End_Farsode"].Rows[0]["S5_datevariz"].ToString() != "")
            {
                button3.Visibility = System.Windows.Visibility.Visible;
                button5.Visibility = System.Windows.Visibility.Visible;
                button4.Visibility = System.Windows.Visibility.Visible;
                button6.Visibility = System.Windows.Visibility.Visible;
                button7.Visibility = System.Windows.Visibility.Visible;
                button8.Visibility = System.Windows.Visibility.Visible;
                button9.Visibility = System.Windows.Visibility.Visible;
                button10.Visibility = System.Windows.Visibility.Visible;
                button13.Visibility = System.Windows.Visibility.Visible;
                button14.Visibility = System.Windows.Visibility.Visible;
                button15.Visibility = System.Windows.Visibility.Visible;
            }
        }

        public void Alborz1_Selectmen()
        {
            if (textBox2.Text != "")
            {
                id_idshobe = textBox1.Text;
                id_idmen = textBox2.Text;

                Database.Connection_Open();
                Database.Fill("SELECT * FROM infomen WHERE (idmen = '" + id_idmen + "') AND (idshobe = '" + id_idshobe + "')", objDataSet, "ONE_All_End_Farsode", true);
                Database.Connection_Close();

                if (objDataSet.Tables["ONE_All_End_Farsode"].Rows.Count > 0)
                {
                    label4.Content = objDataSet.Tables["ONE_All_End_Farsode"].Rows[0]["name"].ToString();
                    label6.Content = objDataSet.Tables["ONE_All_End_Farsode"].Rows[0]["family"].ToString();
                    label9.Content = objDataSet.Tables["ONE_All_End_Farsode"].Rows[0]["shsh"].ToString();
                    textBox3.Text = objDataSet.Tables["ONE_All_End_Farsode"].Rows[0]["id"].ToString();
                }

                objDataSet.Clear();

                Database.Connection_Open();
                Database.Fill("SELECT * FROM All_End_Farsode WHERE ((S1_idmen = '" + id_idmen + "') AND (S1_idshobe = '" + id_idshobe + "'))", objDataSet, "ONE_All_End_Farsode_list", true);
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
                Database.Fill("SELECT * FROM infomen WHERE (id = '" + textBox3.Text + "')", objDataSet, "ONE_All_End_Farsode", true);
                Database.Connection_Close();

                if (objDataSet.Tables["ONE_All_End_Farsode"].Rows.Count > 0)
                {
                    id_idshobe = objDataSet.Tables["ONE_All_End_Farsode"].Rows[0]["idshobe"].ToString();
                    textBox1.Text = id_idshobe;

                    label4.Content = objDataSet.Tables["ONE_All_End_Farsode"].Rows[0]["name"].ToString();
                    label6.Content = objDataSet.Tables["ONE_All_End_Farsode"].Rows[0]["family"].ToString();
                    label9.Content = objDataSet.Tables["ONE_All_End_Farsode"].Rows[0]["shsh"].ToString();
                    textBox2.Text = objDataSet.Tables["ONE_All_End_Farsode"].Rows[0]["idmen"].ToString();
                }

                objDataSet.Clear();

                Database.Connection_Open();
                Database.Fill("SELECT * FROM All_End_Farsode WHERE (S1_idmeli = '" + textBox3.Text + "')", objDataSet, "ONE_All_End_Farsode_list", true);
                Database.Connection_Close();

                dataGrid1.DataContext = objDataSet;
                return;
            }
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
            Alborz_buttom_hideAll();
        }

        private void textBox2_TextChanged(object sender, TextChangedEventArgs e)
        {
            Alborz1_Selectmen();
        }

        private void textBox3_TextChanged(object sender, TextChangedEventArgs e)
        {
            Alborz2_Selectmen();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Rusty_01_KhodroFarsode f1 = new Rusty_01_KhodroFarsode();
            f1.Title = button2.Content.ToString() + " قرارداد شماره : " + id_Contract;
            f1.selStatus = "Edit";
            f1.id_idshobe = id_idshobe;
            f1.id_idmen = id_idmen;
            f1.id_Contract = id_Contract;
            f1.id_idmelli = textBox3.Text;
            f1.Show();
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            Rusty_05_sabtdarsetad13 f1 = new Rusty_05_sabtdarsetad13();
            f1.Title = button6.Content.ToString() + " قرارداد شماره : " + id_Contract;
            f1.id_idshobe = id_idshobe;
            f1.id_idmen = id_idmen;
            f1.id_Contract = id_Contract;
            f1.Show();
        }

        private void alborz_dataGrid1_Selected1(string amin)
        {
            id_Contract = amin;

            objDataSet2.Clear();
            Database.Connection_Open();
            Database.Fill("SELECT * FROM infokhodro WHERE (S1_rad = '" + id_Contract + "')", objDataSet2, "infokhodro", true);
            Database.Connection_Close();

            if (objDataSet2.Tables["infokhodro"].Rows.Count > 0)
            {
                if (objDataSet2.Tables["infokhodro"].Rows[0]["nahkharid"].ToString() == "وجه نقد")
                {
                    Alborz_buttom_1();
                }
                else if (objDataSet2.Tables["infokhodro"].Rows[0]["nahkharid"].ToString() == "جايگزين")
                {
                    Alborz_buttom_2();
                }
            }
            else
            {
                Alborz_buttom_hideAll();
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

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            Rusty_02_vekalatnameh f1 = new Rusty_02_vekalatnameh();
            f1.Title = button3.Content.ToString() + " قرارداد شماره : " + id_Contract;
            f1.id_idshobe = id_idshobe;
            f1.id_idmen = id_idmen;
            f1.id_Contract = id_Contract;
            f1.Show();
        }

        private void dataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            Rusty_03_sabtvarizi f1 = new Rusty_03_sabtvarizi();
            f1.Title = button5.Content.ToString() + " قرارداد شماره : " + id_Contract;
            f1.id_idshobe = id_idshobe;
            f1.id_idmen = id_idmen;
            f1.id_Contract = id_Contract;
            f1.Show();
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            Rusty_04_hesab f1 = new Rusty_04_hesab();
            f1.Title = button4.Content.ToString() + " قرارداد شماره : " + id_Contract;
            f1.id_idshobe = id_idshobe;
            f1.id_idmen = id_idmen;
            f1.id_Contract = id_Contract;
            f1.Show();
        }

        private void button8_Click(object sender, RoutedEventArgs e)
        {
            Rusty_07_pazireshvamoarefibeparking f1 = new Rusty_07_pazireshvamoarefibeparking();
            f1.Title = button8.Content.ToString() + " قرارداد شماره : " + id_Contract;
            f1.id_idshobe = id_idshobe;
            f1.id_idmen = id_idmen;
            f1.id_Contract = id_Contract;
            f1.Show();
        }

        private void button7_Click(object sender, RoutedEventArgs e)
        {
            Rusty_06_farakhan f1 = new Rusty_06_farakhan();
            f1.Title = button7.Content.ToString() + " قرارداد شماره : " + id_Contract;
            f1.id_idshobe = id_idshobe;
            f1.id_idmen = id_idmen;
            f1.id_Contract = id_Contract;
            f1.Show();
        }

        private void button9_Click(object sender, RoutedEventArgs e)
        {
            Rusty_08_daryafttaeednaja f1 = new Rusty_08_daryafttaeednaja();
            f1.Title = button9.Content.ToString() + " قرارداد شماره : " + id_Contract;
            f1.id_idshobe = id_idshobe;
            f1.id_idmen = id_idmen;
            f1.id_Contract = id_Contract;
            f1.Show();
        }

        private void button13_Click(object sender, RoutedEventArgs e)
        {
            Rusty_10_sodorpishfactor f1 = new Rusty_10_sodorpishfactor();
            f1.Title = button13.Content.ToString() + " قرارداد شماره : " + id_Contract;
            f1.id_idshobe = id_idshobe;
            f1.id_idmen = id_idmen;
            f1.id_Contract = id_Contract;
            f1.Show();
        }

        private void button14_Click(object sender, RoutedEventArgs e)
        {
            Rusty_11_varizvajhvaersal f1 = new Rusty_11_varizvajhvaersal();
            f1.Title = button14.Content.ToString() + " قرارداد شماره : " + id_Contract;
            f1.id_idshobe = id_idshobe;
            f1.id_idmen = id_idmen;
            f1.id_Contract = id_Contract;
            f1.Show();
        }

        private void button10_Click(object sender, RoutedEventArgs e)
        {
            Rusty_09_tashkilparvande f1 = new Rusty_09_tashkilparvande();
            f1.Title = button10.Content.ToString() + " قرارداد شماره : " + id_Contract;
            f1.id_idshobe = id_idshobe;
            f1.id_idmen = id_idmen;
            f1.id_Contract = id_Contract;
            f1.Show();
        }

        private void button11_Click(object sender, RoutedEventArgs e)
        {
            Rusty_01_KhodroFarsode f1 = new Rusty_01_KhodroFarsode();
            f1.Title = button2.Content.ToString();
            f1.selStatus = "New";
            f1.id_idshobe = id_idshobe;
            f1.id_idmen = id_idmen;
            f1.id_Contract = id_Contract;
            f1.id_idmelli = textBox3.Text;
            f1.Show();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            Alborz1_Selectmen();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            //SqlCommand objCommand1 = new SqlCommand();
            //objCommand1.Connection = objConnection;
            //objCommand1.CommandText = "DELETE FROM All_End_Farsode WHERE (S1_rad = '" + id_Contract + "')";
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
            //objCommand3.CommandText = "DELETE FROM infokhodro WHERE (S1_rad = '" + id_Contract + "')";
            //objCommand3.CommandType = CommandType.Text;

            //objConnection.Open();
            //objCommand3.ExecuteNonQuery();
            //objConnection.Close();

            //MessageBox.Show("قرارداد " + id_Contract + " با موفقیت حذف شد", "", MessageBoxButton.OK, MessageBoxImage.Information);

            //objDataSet.Clear();

            //Database.Connection_Open();
            //Database.Fill("SELECT * FROM All_End_Farsode WHERE (S1_idshobe = '" + id_idshobe + "') AND (S1_idmeli = '" + textBox3.Text + "')", objDataSet, "ONE_All_End_Farsode_list", true);
            //Database.Connection_Close();

            //dataGrid1.DataContext = objDataSet;
            
            //Alborz_buttom_hideAll();
        }

        private void button16_Click(object sender, RoutedEventArgs e)
        {
            Rusty_09_varizvajhsetad f1 = new Rusty_09_varizvajhsetad();
            f1.Title = button16.Content.ToString() + " قرارداد شماره : " + id_Contract;
            f1.id_idshobe = id_idshobe;
            f1.id_idmen = id_idmen;
            f1.id_Contract = id_Contract;
            f1.Show();
        }

        private void button15_Click(object sender, RoutedEventArgs e)
        {
            Rusty_12_Sodor f1 = new Rusty_12_Sodor();
            f1.Title = button15.Content.ToString() + " قرارداد شماره : " + id_Contract; ;
            f1.id_idshobe = id_idshobe;
            f1.id_idmen = id_idmen;
            f1.id_Contract = id_Contract;
            f1.Show();
        }

        private void button12_Click(object sender, RoutedEventArgs e)
        {
            objDataSet.Clear();
            Database.Connection_Open();
            Database.Fill("SELECT * FROM All_End_Farsode WHERE (S1_idshobe = '" + id_idshobe + "') AND (S1_idmeli = '" + textBox3.Text + "') AND (S1_rad = '" + id_Contract + "')", objDataSet, "All_End_Farsode", true);
            Database.Connection_Close();

            SqlCommand objCommand1 = new SqlCommand();
            objCommand1.Connection = objConnection;
            objCommand1.CommandText = "UPDATE All_End_Farsode SET s1_enseraf=@s1_enseraf WHERE (S1_rad = '" + id_Contract + "')";
            objCommand1.CommandType = CommandType.Text;
            if (objDataSet.Tables["All_End_Farsode"].Rows[0]["s1_enseraf"].ToString() == "ندارد")
                objCommand1.Parameters.AddWithValue("@s1_enseraf", "دارد");
            else
                objCommand1.Parameters.AddWithValue("@s1_enseraf", "ندارد");

            objConnection.Open();
            objCommand1.ExecuteNonQuery();
            objConnection.Close();

            SqlCommand objCommand3 = new SqlCommand();
            objCommand3.Connection = objConnection;
            objCommand3.CommandText = "INSERT INTO UserAmal (uuser,udate,utime,upc,id,place,Contract,rad,noe) VALUES (@uuser,@udate,@utime,@upc,@id,@place,@Contract,@rad,@noe)";
            objCommand3.CommandType = CommandType.Text;
            objCommand3.Parameters.AddWithValue("@uuser", u_set.u_user());
            objCommand3.Parameters.AddWithValue("@udate", u_set.u_date());
            objCommand3.Parameters.AddWithValue("@utime", u_set.u_time());
            objCommand3.Parameters.AddWithValue("@upc", u_set.u_pc());
            objCommand3.Parameters.AddWithValue("@id", "1");
            objCommand3.Parameters.AddWithValue("@place", button12.Content);
            objCommand3.Parameters.AddWithValue("@Contract", id_Contract);
            objCommand3.Parameters.AddWithValue("@rad", "0");
            objCommand3.Parameters.AddWithValue("@noe", "انصراف");

            objConnection.Open();
            objCommand3.ExecuteNonQuery();
            objConnection.Close();

            objDataSet.Clear();
            Database.Connection_Open();
            Database.Fill("SELECT * FROM All_End_Farsode WHERE (S1_idmeli = '" + textBox3.Text + "')", objDataSet, "ONE_All_End_Farsode_list", true);
            Database.Connection_Close();

            dataGrid1.DataContext = objDataSet;
        }

        private void button17_Click(object sender, RoutedEventArgs e)
        {
            Rusty_10_pardakhtvajhbemoshtari f1 = new Rusty_10_pardakhtvajhbemoshtari();
            f1.Title = button17.Content.ToString() + " قرارداد شماره : " + id_Contract;
            f1.id_idshobe = id_idshobe;
            f1.id_idmen = id_idmen;
            f1.id_Contract = id_Contract;
            f1.Show();
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "Return") { Alborz2_Selectmen(); }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "Return") { Alborz1_Selectmen(); }
        }

        private void button19_Click(object sender, RoutedEventArgs e)
        {
            CrystalReportWpf_AlborzAutomobile.Window1 f1 = new CrystalReportWpf_AlborzAutomobile.Window1();
            f1.Title = "چاپ روند کاری فرسوده شماره : " + id_Contract;
            f1.selkar = "Crystal_Rusty_All_Ravandkar";
            f1.id_Contract = id_Contract;
            f1.Show();
        }

        private void button22_Click(object sender, RoutedEventArgs e)
        {
            Rusty_11_varizvajbemoshtari f1 = new Rusty_11_varizvajbemoshtari();
            f1.Title = button22.Content.ToString() + " قرارداد شماره : " + id_Contract;
            f1.id_idshobe = id_idshobe;
            f1.id_idmen = id_idmen;
            f1.id_Contract = id_Contract;
            f1.Show();
        }

        private void button18_Click(object sender, RoutedEventArgs e)
        {
            CrystalReportWpf_AlborzAutomobile.Window1 f1 = new CrystalReportWpf_AlborzAutomobile.Window1();
            f1.Title = "عملکرد کاربران در قرارداد : " + id_Contract;
            f1.selkar = "Crystal_Rusty_User";
            f1.id_Contract = id_Contract;
            f1.Show();
        }

        private void button23_Click(object sender, RoutedEventArgs e)
        {
            Rusty_13_tahvihkhodro f1 = new Rusty_13_tahvihkhodro();
            f1.Title = button15.Content.ToString() + " قرارداد شماره : " + id_Contract; ;
            f1.id_idshobe = id_idshobe;
            f1.id_idmen = id_idmen;
            f1.id_Contract = id_Contract;
            f1.Show();
        }

        private void button25_Click(object sender, RoutedEventArgs e)
        {
            SqlCommand objCommand1 = new SqlCommand();
            objCommand1.Connection = objConnection;
            objCommand1.CommandText = "UPDATE All_End_Farsode SET S20_end=@S20_end WHERE (S1_idshobe = '" + id_idshobe + "') AND (S1_idmen = '" + id_idmen + "') AND (S1_rad = '" + id_Contract + "')";
            objCommand1.CommandType = CommandType.Text;

            objCommand1.Parameters.AddWithValue("@S20_end", true);

            objConnection.Open();
            objCommand1.ExecuteNonQuery();
            objConnection.Close();

            u_set.u_amal_register("1", "تسویه قرارداد", id_Contract, "12", "ویرایش");
        }

        private void button24_Click(object sender, RoutedEventArgs e)
        {
            SqlCommand objCommand1 = new SqlCommand();
            objCommand1.Connection = objConnection;
            objCommand1.CommandText = "UPDATE All_End_Farsode SET S20_end=@S20_end WHERE (S1_idshobe = '" + id_idshobe + "') AND (S1_idmen = '" + id_idmen + "') AND (S1_rad = '" + id_Contract + "')";
            objCommand1.CommandType = CommandType.Text;

            objCommand1.Parameters.AddWithValue("@S20_end", true);

            objConnection.Open();
            objCommand1.ExecuteNonQuery();
            objConnection.Close();

            u_set.u_amal_register("1", "تسویه قرارداد", id_Contract, "14", "ویرایش");
        }
    }
}
