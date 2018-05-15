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
    /// Interaction logic for PPrint_farsode_Ravandkar_Main.xaml
    /// </summary>
    public partial class PPrint_farsode_Ravandkar_Main : Window
    {
        SqlConnection objConnection = new SqlConnection(DB_Base.ConStr);
        SqlDataAdapter objDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();

        DB_Base Database = new DB_Base();
        U_Base u_set = new U_Base();

        public PPrint_farsode_Ravandkar_Main()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Database.Connection_Open();
            Database.Fill("SELECT rad, nameshobe FROM namayande", objDataSet, "namayande", true);
            Database.Connection_Close();

            comboBox3.DataContext = objDataSet.Tables["namayande"];
            comboBox3.DisplayMemberPath = "nameshobe";
            comboBox3.SelectedValuePath = "rad";

            comboBox2.Items.Add("");
            comboBox2.Items.Add("ندارد");
            comboBox2.Items.Add("دارد");

            comboBox4.Items.Add("");
            comboBox4.Items.Add("البرز خودرو");
            comboBox4.Items.Add("تسهيلات بانکي");
            comboBox4.Items.Add("ايران خودرو");
            comboBox4.Items.Add("سايپا");

            comboBox5.Items.Add("جايگزين");
            comboBox5.Items.Add("وجه نقد");
            comboBox5.SelectedIndex = 0;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            string search_amin = "";

            if (comboBox3.SelectedIndex != -1)
            {
                search_amin = search_amin + " ({Crystal_Rusty_All_Ravandkar_Main;1.S1_idshobe} = '" + comboBox3.SelectedValue + "') AND ";
            }

            if (comboBox1.SelectedIndex != -1)
            {
                if (persianDatePicker1.Text == "")
                {
                    MessageBox.Show("لطفا تاریخ از را تکمیل نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                    persianDatePicker1.Focus();
                    return;
                }

                if (persianDatePicker2.Text == "")
                {
                    MessageBox.Show("لطفا تاریخ تا را تکمیل نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                    persianDatePicker2.Focus();
                    return;
                }

                if (comboBox5.SelectedIndex == 0)
                {
                    if (comboBox1.SelectedIndex == 0)
                        search_amin = search_amin + " ({Crystal_Rusty_All_Ravandkar_Main;1.udate(1)} >= '" + u_set.control_date_end(persianDatePicker1.Text) + "') AND ({Crystal_Rusty_All_Ravandkar_Main;1.udate(1)} <= '" + u_set.control_date_end(persianDatePicker2.Text) + "') AND (ISNull({Crystal_Rusty_All_Ravandkar_Main;1.S3_datet})) AND ";

                    if (comboBox1.SelectedIndex == 1)
                        search_amin = search_amin + " ({Crystal_Rusty_All_Ravandkar_Main;1.S3_datet} >= '" + u_set.control_date_end(persianDatePicker1.Text) + "') AND ({Crystal_Rusty_All_Ravandkar_Main;1.S3_datet} <= '" + u_set.control_date_end(persianDatePicker2.Text) + "') AND (ISNull({Crystal_Rusty_All_Ravandkar_Main;1.s3_2_3})) AND ";

                    //if (comboBox1.SelectedIndex == 2)
                    //    search_amin = search_amin + " ({Crystal_Rusty_All_Ravandkar_Main;1.s3_2_1} >= '" + u_set.control_date_end(persianDatePicker1.Text) + "') AND ({Crystal_Rusty_All_Ravandkar_Main;1.s3_2_1} <= '" + u_set.control_date_end(persianDatePicker2.Text) + "') AND (ISNull({Crystal_Rusty_All_Ravandkar_Main;1.S4_2_1})) AND ";

                    //if (comboBox1.SelectedIndex == 3)
                    //    search_amin = search_amin + " ({Crystal_Rusty_All_Ravandkar_Main;1.s3_2_1} >= '" + u_set.control_date_end(persianDatePicker1.Text) + "') AND ({Crystal_Rusty_All_Ravandkar_Main;1.s3_2_1} <= '" + u_set.control_date_end(persianDatePicker2.Text) + "') AND (ISNull({Crystal_Rusty_All_Ravandkar_Main;1.S4_2_1})) AND ";

                    if (comboBox1.SelectedIndex == 4)
                        search_amin = search_amin + " ({Crystal_Rusty_All_Ravandkar_Main;1.S4_2_1} >= '" + u_set.control_date_end(persianDatePicker1.Text) + "') AND ({Crystal_Rusty_All_Ravandkar_Main;1.S4_2_1} <= '" + u_set.control_date_end(persianDatePicker2.Text) + "') AND (ISNull({Crystal_Rusty_All_Ravandkar_Main;1.S6_datefarakhan})) AND ";

                    if (comboBox1.SelectedIndex == 5)
                        search_amin = search_amin + " ({Crystal_Rusty_All_Ravandkar_Main;1.S6_datefarakhan} >= '" + u_set.control_date_end(persianDatePicker1.Text) + "') AND ({Crystal_Rusty_All_Ravandkar_Main;1.S6_datefarakhan} <= '" + u_set.control_date_end(persianDatePicker2.Text) + "') AND (ISNull({Crystal_Rusty_All_Ravandkar_Main;1.S4_3_1})) AND ";

                    if (comboBox1.SelectedIndex == 6)
                        search_amin = search_amin + " ({Crystal_Rusty_All_Ravandkar_Main;1.S4_3_1} >= '" + u_set.control_date_end(persianDatePicker1.Text) + "') AND ({Crystal_Rusty_All_Ravandkar_Main;1.S4_3_1} <= '" + u_set.control_date_end(persianDatePicker2.Text) + "') AND (ISNull({Crystal_Rusty_All_Ravandkar_Main;1.S4_4_1})) AND ";

                    if (comboBox1.SelectedIndex == 7)
                        search_amin = search_amin + " ({Crystal_Rusty_All_Ravandkar_Main;1.S4_4_1} >= '" + u_set.control_date_end(persianDatePicker1.Text) + "') AND ({Crystal_Rusty_All_Ravandkar_Main;1.S4_4_1} <= '" + u_set.control_date_end(persianDatePicker2.Text) + "') AND (ISNull({Crystal_Rusty_All_Ravandkar_Main;1.S9_date2})) AND ";

                    if (comboBox1.SelectedIndex == 8)
                        search_amin = search_amin + " ({Crystal_Rusty_All_Ravandkar_Main;1.S9_date2} >= '" + u_set.control_date_end(persianDatePicker1.Text) + "') AND ({Crystal_Rusty_All_Ravandkar_Main;1.S9_date2} <= '" + u_set.control_date_end(persianDatePicker2.Text) + "') AND (ISNull({Crystal_Rusty_All_Ravandkar_Main;1.S5_datemoshtari})) AND ";

                    if (comboBox1.SelectedIndex == 9)
                        search_amin = search_amin + " ({Crystal_Rusty_All_Ravandkar_Main;1.S5_datemoshtari} >= '" + u_set.control_date_end(persianDatePicker1.Text) + "') AND ({Crystal_Rusty_All_Ravandkar_Main;1.S5_datemoshtari} <= '" + u_set.control_date_end(persianDatePicker2.Text) + "') AND (ISNull({Crystal_Rusty_All_Ravandkar_Main;1.S5_ersalkhodro})) AND ";

                    if (comboBox1.SelectedIndex == 10)
                        search_amin = search_amin + " ({Crystal_Rusty_All_Ravandkar_Main;1.S5_ersalkhodro} >= '" + u_set.control_date_end(persianDatePicker1.Text) + "') AND ({Crystal_Rusty_All_Ravandkar_Main;1.S5_ersalkhodro} <= '" + u_set.control_date_end(persianDatePicker2.Text) + "') AND (ISNull({Crystal_Rusty_All_Ravandkar_Main;1.S5_Dateend})) AND ";

                    if (comboBox1.SelectedIndex == 11)
                        search_amin = search_amin + " ({Crystal_Rusty_All_Ravandkar_Main;1.S5_Dateend} >= '" + u_set.control_date_end(persianDatePicker1.Text) + "') AND ({Crystal_Rusty_All_Ravandkar_Main;1.S5_Dateend} <= '" + u_set.control_date_end(persianDatePicker2.Text) + "') AND ";
                }
                else
                {
                    if (comboBox1.SelectedIndex == 0)
                        search_amin = search_amin + " ({Crystal_Rusty_All_Ravandkar_Main;1.udate(1)} >= '" + u_set.control_date_end(persianDatePicker1.Text) + "') AND ({Crystal_Rusty_All_Ravandkar_Main;1.udate(1)} <= '" + u_set.control_date_end(persianDatePicker2.Text) + "') AND (ISNull({Crystal_Rusty_All_Ravandkar_Main;1.S3_datet})) AND ";

                    if (comboBox1.SelectedIndex == 1)
                        search_amin = search_amin + " ({Crystal_Rusty_All_Ravandkar_Main;1.S3_datet} >= '" + u_set.control_date_end(persianDatePicker1.Text) + "') AND ({Crystal_Rusty_All_Ravandkar_Main;1.S3_datet} <= '" + u_set.control_date_end(persianDatePicker2.Text) + "') AND (ISNull({Crystal_Rusty_All_Ravandkar_Main;1.s3_2_3})) AND ";

                    //if (comboBox1.SelectedIndex == 2)
                    //    search_amin = search_amin + " ({Crystal_Rusty_All_Ravandkar_Main;1.s3_2_1} >= '" + u_set.control_date_end(persianDatePicker1.Text) + "') AND ({Crystal_Rusty_All_Ravandkar_Main;1.s3_2_1} <= '" + u_set.control_date_end(persianDatePicker2.Text) + "') AND (ISNull({Crystal_Rusty_All_Ravandkar_Main;1.S4_2_1})) AND ";

                    //if (comboBox1.SelectedIndex == 3)
                    //    search_amin = search_amin + " ({Crystal_Rusty_All_Ravandkar_Main;1.s3_2_1} >= '" + u_set.control_date_end(persianDatePicker1.Text) + "') AND ({Crystal_Rusty_All_Ravandkar_Main;1.s3_2_1} <= '" + u_set.control_date_end(persianDatePicker2.Text) + "') AND (ISNull({Crystal_Rusty_All_Ravandkar_Main;1.S4_2_1})) AND ";

                    if (comboBox1.SelectedIndex == 4)
                        search_amin = search_amin + " ({Crystal_Rusty_All_Ravandkar_Main;1.S4_2_1} >= '" + u_set.control_date_end(persianDatePicker1.Text) + "') AND ({Crystal_Rusty_All_Ravandkar_Main;1.S4_2_1} <= '" + u_set.control_date_end(persianDatePicker2.Text) + "') AND (ISNull({Crystal_Rusty_All_Ravandkar_Main;1.S6_datefarakhan})) AND ";

                    if (comboBox1.SelectedIndex == 5)
                        search_amin = search_amin + " ({Crystal_Rusty_All_Ravandkar_Main;1.S6_datefarakhan} >= '" + u_set.control_date_end(persianDatePicker1.Text) + "') AND ({Crystal_Rusty_All_Ravandkar_Main;1.S6_datefarakhan} <= '" + u_set.control_date_end(persianDatePicker2.Text) + "') AND (ISNull({Crystal_Rusty_All_Ravandkar_Main;1.S4_3_1})) AND ";

                    if (comboBox1.SelectedIndex == 6)
                        search_amin = search_amin + " ({Crystal_Rusty_All_Ravandkar_Main;1.S4_3_1} >= '" + u_set.control_date_end(persianDatePicker1.Text) + "') AND ({Crystal_Rusty_All_Ravandkar_Main;1.S4_3_1} <= '" + u_set.control_date_end(persianDatePicker2.Text) + "') AND (ISNull({Crystal_Rusty_All_Ravandkar_Main;1.S4_4_1})) AND ";

                    if (comboBox1.SelectedIndex == 7)
                        search_amin = search_amin + " ({Crystal_Rusty_All_Ravandkar_Main;1.S4_4_1} >= '" + u_set.control_date_end(persianDatePicker1.Text) + "') AND ({Crystal_Rusty_All_Ravandkar_Main;1.S4_4_1} <= '" + u_set.control_date_end(persianDatePicker2.Text) + "') AND (ISNull({Crystal_Rusty_All_Ravandkar_Main;1.S9_2_date1})) AND ";

                    if (comboBox1.SelectedIndex == 8)
                        search_amin = search_amin + " ({Crystal_Rusty_All_Ravandkar_Main;1.S9_2_date1} >= '" + u_set.control_date_end(persianDatePicker1.Text) + "') AND ({Crystal_Rusty_All_Ravandkar_Main;1.S9_2_date1} <= '" + u_set.control_date_end(persianDatePicker2.Text) + "') AND (ISNull({Crystal_Rusty_All_Ravandkar_Main;1.S5_datevariz})) AND ";

                    if (comboBox1.SelectedIndex == 9)
                        search_amin = search_amin + " ({Crystal_Rusty_All_Ravandkar_Main;1.S5_datevariz} >= '" + u_set.control_date_end(persianDatePicker1.Text) + "') AND ({Crystal_Rusty_All_Ravandkar_Main;1.S5_datevariz} <= '" + u_set.control_date_end(persianDatePicker2.Text) + "') AND ";
                }
            }

            if (textBox3.Text != "" && textBox4.Text != "")
            {
                search_amin += " ({Crystal_Rusty_All_Ravandkar_Main;1.model} >= '" + textBox3.Text + "') AND ({Crystal_Rusty_All_Ravandkar_Main;1.model} <= '" + textBox4.Text + "') AND ";
            }

            if (textBox5.Text != "" && textBox6.Text != "")
            {
                search_amin += " ({Crystal_Rusty_All_Ravandkar_Main;1.S4_3_2} >= '" + textBox5.Text + "') AND ({Crystal_Rusty_All_Ravandkar_Main;1.S4_3_2} <= '" + textBox6.Text + "') AND ";
            }

            if (comboBox2.SelectedIndex > 0)
            {
                search_amin += " ({Crystal_Rusty_All_Ravandkar_Main;1.s1_enseraf} = '" + comboBox2.Text + "') AND ";
            }

            if (comboBox4.SelectedIndex > 0)
            {
                search_amin += " ({Crystal_Rusty_All_Ravandkar_Main;1.s3_2_3} = '" + comboBox4.Text + "') AND ";
            }

            if (search_amin != "")
            {
                search_amin = search_amin.Substring(1, search_amin.Length - 5);
                if (comboBox5.SelectedIndex == 0)
                {
                    CrystalReportWpf_AlborzAutomobile.Window1 f1 = new CrystalReportWpf_AlborzAutomobile.Window1();
                    f1.Title = "گزارش پیشرفت روند فرسوده";
                    f1.selkar = "Crystal_Rusty_All_Ravandkar_Main";
                    f1.rec_sel_for = search_amin;
                    f1.prompt = comboBox1.Text;
                    f1.Show();
                }
                else
                {
                    CrystalReportWpf_AlborzAutomobile.Window1 f1 = new CrystalReportWpf_AlborzAutomobile.Window1();
                    f1.Title = "گزارش پیشرفت روند فرسوده";
                    f1.selkar = "Crystal_Rusty_All_Ravandkar_Main_naghd";
                    f1.rec_sel_for = search_amin;
                    f1.prompt = comboBox1.Text;
                    f1.Show();
                }
            }
        }

        private void comboBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return) { button1.Focus(); }
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return) { button1.Focus(); }
        }

        private void comboBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return) { button1.Focus(); }
        }

        private void comboBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return) { button1.Focus(); }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return) { textBox4.Focus(); }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return) { button1.Focus(); }
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return) { textBox6.Focus(); }
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return) { button1.Focus(); }
        }

        private void persianDatePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return) { persianDatePicker2.Focus(); }
        }

        private void persianDatePicker2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return) { button1.Focus(); }
        }

        private void comboBox5_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBox5.SelectedIndex == 0)
            {
                Database.Connection_Open();
                Database.Fill("SELECT id, name FROM All_End_Farsode_Level", objDataSet, "All_End_Farsode_Level", true);
                Database.Connection_Close();

                comboBox1.DataContext = objDataSet.Tables["All_End_Farsode_Level"];
                comboBox1.DisplayMemberPath = "name";
                comboBox1.SelectedValuePath = "id";
            }
            else
            {
                Database.Connection_Open();
                Database.Fill("SELECT id, name FROM All_End_Farsode_Level_naghd", objDataSet, "All_End_Farsode_Level", true);
                Database.Connection_Close();

                comboBox1.DataContext = objDataSet.Tables["All_End_Farsode_Level"];
                comboBox1.DisplayMemberPath = "name";
                comboBox1.SelectedValuePath = "id";
            }
        }

        private void comboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if ((Convert.ToInt32(comboBox1.SelectedValue.ToString()) == 3) || (Convert.ToInt32(comboBox1.SelectedValue.ToString()) == 4))
                {
                    label1.IsEnabled = false;
                    label16.IsEnabled = false;
                    label20.IsEnabled = false;
                    persianDatePicker1.IsEnabled = false;
                    persianDatePicker2.IsEnabled = false;
                }
                else
                {
                    label1.IsEnabled = true;
                    label16.IsEnabled = true;
                    label20.IsEnabled = true;
                    persianDatePicker1.IsEnabled = true;
                    persianDatePicker2.IsEnabled = true;
                }

                if (Convert.ToInt32(comboBox1.SelectedValue.ToString()) <= 3)
                {
                    label8.IsEnabled = false;
                    comboBox4.IsEnabled = false;
                }
                else
                {
                    label8.IsEnabled = true;
                    comboBox4.IsEnabled = true;
                }

                if (Convert.ToInt32(comboBox1.SelectedValue.ToString()) <= 4)
                {
                    label9.IsEnabled = false;
                    label10.IsEnabled = false;
                    label11.IsEnabled = false;
                    textBox5.IsEnabled = false;
                    textBox6.IsEnabled = false;
                }
                else
                {
                    label9.IsEnabled = true;
                    label10.IsEnabled = true;
                    label11.IsEnabled = true;
                    textBox5.IsEnabled = true;
                    textBox6.IsEnabled = true;
                }
            }
            catch
            {
            }
        }
    }
}
