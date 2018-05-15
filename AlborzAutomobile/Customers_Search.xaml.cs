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
    /// Interaction logic for Customers_Search.xaml
    /// </summary>
    public partial class Customers_Search : Window
    {
        SqlConnection objConnection = new SqlConnection(DB_Base.ConStr);
        SqlDataAdapter objDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();

        DB_Base Database = new DB_Base();
        U_Base u_set = new U_Base();

        public string sel_noe;

        public Customers_Search()
        {
            InitializeComponent();
        }

        private void btn_Clc()
        {
            string search_amin = "";

            if (sel_noe == "1")
            {
                if (textBox1.Text != "" && textBox17.Text != "")
                {
                    search_amin = search_amin + " (idshobe >= '" + textBox1.Text + "') AND (idshobe <= '" + textBox17.Text + "') AND ";
                }

                if (textBox2.Text != "" && textBox19.Text != "")
                {
                    search_amin = search_amin + " (idmen >= '" + textBox2.Text + "') AND (idmen <= '" + textBox19.Text + "') AND ";
                }

                if (persianDatePicker1.Text != "" && persianDatePicker1.Text != "")
                {
                    search_amin = search_amin + " (datesabt >= '" + u_set.control_date_end(persianDatePicker1.Text) + "') AND (datesabt <= '" + u_set.control_date_end(persianDatePicker2.Text) + "') AND ";
                }

                if (textBox3.Text != "")
                {
                    search_amin = search_amin + " (name LIKE '%" + textBox3.Text + "%') AND ";
                }

                if (textBox4.Text != "")
                {
                    search_amin = search_amin + " (family LIKE '%" + textBox4.Text + "%') AND ";
                }

                if (textBox5.Text != "")
                {
                    search_amin = search_amin + " (fathername LIKE '%" + textBox5.Text + "%') AND ";
                }

                if (textBox6.Text != "")
                {
                    search_amin = search_amin + " (shsh LIKE '%" + textBox6.Text + "%') AND ";
                }

                if (textBox7.Text != "")
                {
                    search_amin = search_amin + " (id LIKE '" + textBox7.Text + "') AND ";
                }

                if (textBox8.Text != "")
                {
                    search_amin = search_amin + " (sadereh LIKE '%" + textBox8.Text + "%') AND ";
                }

                if (textBox9.Text != "")
                {
                    search_amin = search_amin + " (idp LIKE '" + textBox9.Text + "') AND ";
                }

                if (textBox10.Text != "")
                {
                    search_amin = search_amin + " (brithdate LIKE '" + textBox10.Text + "') AND ";
                }

                if (textBox11.Text != "")
                {
                    search_amin = search_amin + " (mobile LIKE '%" + textBox11.Text + "%') AND ";
                }

                if (textBox12.Text != "")
                {
                    search_amin = search_amin + " (phone LIKE '%" + textBox12.Text + "%') AND ";
                }

                if (textBox13.Text != "")
                {
                    search_amin = search_amin + " (phonework LIKE '%" + textBox13.Text + "%') AND ";
                }

                if (textBox14.Text != "")
                {
                    search_amin = search_amin + " (addresshome LIKE '%" + textBox14.Text + "%') AND ";
                }

                if (textBox15.Text != "")
                {
                    search_amin = search_amin + " (addresswork LIKE '%" + textBox15.Text + "%') AND ";
                }

                if (search_amin.Length == 0)
                {
                    AllCustomers f1 = new AllCustomers();
                    f1.label1.Content = "SELECT * FROM infomen";
                    f1.Show();
                }
                else
                {
                    search_amin = search_amin.Substring(1, search_amin.Length - 5);
                    AllCustomers f1 = new AllCustomers();
                    f1.label1.Content = "SELECT * FROM infomen WHERE " + search_amin;
                    f1.Show();
                }
            }

            if (sel_noe == "2")
            {
                if (textBox1.Text != "" && textBox17.Text != "")
                {
                    search_amin = search_amin + " (S1_idshobe >= '" + textBox1.Text + "') AND (S1_idshobe <= '" + textBox17.Text + "') AND ";
                }

                if (textBox2.Text != "" && textBox19.Text != "")
                {
                    search_amin = search_amin + " (S1_idmen >= '" + textBox2.Text + "') AND (S1_idmen <= '" + textBox19.Text + "') AND ";
                }

                if (persianDatePicker1.Text != "" && persianDatePicker1.Text != "")
                {
                    search_amin = search_amin + " (datesabt >= '" + u_set.control_date_end(persianDatePicker1.Text) + "') AND (datesabt <= '" + u_set.control_date_end(persianDatePicker2.Text) + "') AND ";
                }

                if (textBox3.Text != "")
                {
                    search_amin = search_amin + " (name1 LIKE '%" + textBox3.Text + "%') AND ";
                }

                if (textBox4.Text != "")
                {
                    search_amin = search_amin + " (name1 LIKE '%" + textBox4.Text + "%') AND ";
                }

                if (textBox5.Text != "")
                {
                    search_amin = search_amin + " (fathername LIKE '%" + textBox5.Text + "%') AND ";
                }

                if (textBox6.Text != "")
                {
                    search_amin = search_amin + " (shsh LIKE '%" + textBox6.Text + "%') AND ";
                }

                if (textBox7.Text != "")
                {
                    search_amin = search_amin + " (id LIKE '" + textBox7.Text + "') AND ";
                }

                if (textBox8.Text != "")
                {
                    search_amin = search_amin + " (sadereh LIKE '%" + textBox8.Text + "%') AND ";
                }

                if (textBox9.Text != "")
                {
                    search_amin = search_amin + " (idp LIKE '" + textBox9.Text + "') AND ";
                }

                if (textBox10.Text != "")
                {
                    search_amin = search_amin + " (brithdate LIKE '" + textBox10.Text + "') AND ";
                }

                if (textBox11.Text != "")
                {
                    search_amin = search_amin + " (mobile LIKE '%" + textBox11.Text + "%') AND ";
                }

                if (textBox12.Text != "")
                {
                    search_amin = search_amin + " (phone LIKE '%" + textBox12.Text + "%') AND ";
                }

                if (textBox13.Text != "")
                {
                    search_amin = search_amin + " (phonework LIKE '%" + textBox13.Text + "%') AND ";
                }

                if (textBox14.Text != "")
                {
                    search_amin = search_amin + " (addresshome LIKE '%" + textBox14.Text + "%') AND ";
                }

                if (textBox15.Text != "")
                {
                    search_amin = search_amin + " (addresswork LIKE '%" + textBox15.Text + "%') AND ";
                }

                if (search_amin.Length == 0)
                {
                    Report_Contract_All f1 = new Report_Contract_All();
                    f1.search_string = "";
                    f1.Show();
                }
                else
                {
                    search_amin = search_amin.Substring(1, search_amin.Length - 5);
                    Report_Contract_All f1 = new Report_Contract_All();
                    f1.search_string = search_amin;
                    f1.Show();
                }

                u_set.u_amal_register("0", this.Title, "", "0", "جستجو");
            }

            this.Hide();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            btn_Clc();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "Return") { textBox17.Focus(); }
        }

        private void textBox17_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "Return") { button3.Focus(); }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "Return") { textBox19.Focus(); }
        }

        private void textBox19_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "Return") { button3.Focus(); }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "Return") { button3.Focus(); }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "Return") { button3.Focus(); }
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "Return") { button3.Focus(); }
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "Return") { button3.Focus(); }
        }

        private void textBox7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "Return") { button3.Focus(); }
        }

        private void textBox8_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "Return") { button3.Focus(); }
        }

        private void textBox9_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "Return") { button3.Focus(); }
        }

        private void textBox10_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "Return") { button3.Focus(); }
        }

        private void textBox11_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "Return") { button3.Focus(); }
        }

        private void textBox12_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "Return") { button3.Focus(); }
        }

        private void textBox13_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "Return") { button3.Focus(); }
        }

        private void textBox14_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "Return") { button3.Focus(); }
        }

        private void textBox15_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "Return") { button3.Focus(); }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            textBox16.Focus();
            //Database.Connection_Open();
            //Database.Fill("SELECT DISTINCT name FROM infomen", objDataSet, "infomen", true);
            //Database.Connection_Close();

            //textBox6.AutoCompleteCustomSource.Clear();

            //string[] installs = new string[objDataSet2.Tables["sandogh"].Rows.Count];
            //for (int q = 0; q <= objDataSet2.Tables["sandogh"].Rows.Count - 1; q++)
            //{
            //    installs[q] = objDataSet2.Tables["sandogh"].Rows[q]["name1"].ToString();
            //}
            //textBox6.AutoCompleteCustomSource.AddRange(installs);
        }

        private void persianDatePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return) { persianDatePicker2.Focus(); }
        }

        private void persianDatePicker2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return) { button3.Focus(); }
        }

        private void textBox16_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return) 
            {
                if (textBox16.Text.Substring(0, 1).ToString() == "R")
                {

                }
                else if (textBox16.Text.Substring(0, 1).ToString() == "S")
                {
                    textBox1.Text = textBox16.Text.Substring(1, 3).ToString();
                    textBox17.Text = textBox16.Text.Substring(1, 3).ToString();

                    textBox2.Text = textBox16.Text.Substring(4, 10).ToString();
                    textBox19.Text = textBox16.Text.Substring(4, 10).ToString();

                    textBox16.Text = "";
                    btn_Clc();
                }
                else if (textBox16.Text.Substring(0, 1).ToString() == "C")
                {
                    textBox7.Text = textBox16.Text.Substring(1, textBox16.Text.Length-1).ToString();

                    textBox16.Text = "";
                    btn_Clc();
                }
            }
        }

        private void textBox16_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
