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
    /// Interaction logic for Financial_Cost_Search.xaml
    /// </summary>
    public partial class Financial_Cost_Search : Window
    {
        SqlConnection objConnection = new SqlConnection(DB_Base.ConStr);
        SqlDataAdapter objDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();

        DB_Base Database = new DB_Base();
        U_Base u_set = new U_Base();

        public string idshobe;

        public Financial_Cost_Search()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            string search_amin = "";

            if (comboBox1.SelectedIndex != -1)
            {
                search_amin = search_amin + " (bank LIKE '%" + comboBox1.Text + "%') AND ";
            }

            if (textBox1.Text != "")
            {
                search_amin = search_amin + " (vajhe LIKE '%" + textBox1.Text + "%') AND ";
            }

            if (textBox2.Text != "")
            {
                search_amin = search_amin + " (serialcheck LIKE '%" + textBox2.Text + "%') AND ";
            }

            if (textBox3.Text != "")
            {
                search_amin = search_amin + " (babat LIKE '%" + textBox3.Text + "%') AND ";
            }

            if (comboBox2.SelectedIndex != -1)
            {
                search_amin = search_amin + " (mozo LIKE '%" + comboBox2.Text + "%') AND ";
            }

            if (textBox5.Text != "")
            {
                search_amin = search_amin + " (money1 LIKE '%" + textBox5.Text + "%') AND ";
            }

            if (textBox6.Text != "")
            {
                search_amin = search_amin + " (reciver_men LIKE '%" + textBox6.Text + "%') AND ";
            }

            if (persianDatePicker1.Text != "" && persianDatePicker1.Text != "")
            {
                search_amin = search_amin + " (datesodor >= '" + u_set.control_date_end(persianDatePicker1.Text) + "') AND (datesodor <= '" + u_set.control_date_end(persianDatePicker2.Text) + "') AND ";
            }

            if (persianDatePicker3.Text != "" && persianDatePicker4.Text != "")
            {
                search_amin = search_amin + " (datesarresid >= '" + u_set.control_date_end(persianDatePicker3.Text) + "') AND (datesarresid <= '" + u_set.control_date_end(persianDatePicker4.Text) + "') AND ";
            }

            if (textBox4.Text != "")
            {
                search_amin = search_amin + " (prompt LIKE '%" + textBox4.Text + "%') AND ";
            }

            if (search_amin.Length == 0)
            {
                Financial_Cost_ALL f1 = new Financial_Cost_ALL();
                f1.Txt_search = "SELECT * FROM Sherkat_hazineh";
                f1.id_group = idshobe;
                f1.Title = "هزینه";
                f1.Show();
            }
            else
            {
                search_amin = search_amin + " (idshobe = '" + idshobe + "')";
                Financial_Cost_ALL f1 = new Financial_Cost_ALL();
                f1.Txt_search = "SELECT * FROM Sherkat_hazineh WHERE " + search_amin;
                f1.id_group = idshobe;
                f1.Title = "هزینه";
                f1.Show();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            comboBox1.Items.Add("ملی");
            comboBox1.Items.Add("ملت");
            comboBox1.Items.Add("صادرات");
            comboBox1.Items.Add("سپه");
            comboBox1.Items.Add("تجارت");
            comboBox1.Items.Add("پارسیان");
            comboBox1.Items.Add("بانک شهر");

            comboBox2.Items.Add("سوخت جرثقیل");
            comboBox2.Items.Add("تعمیرات جرثقیل");
            comboBox2.Items.Add("پشتیبانی ماشین های اداری");
            comboBox2.Items.Add("پشتیبانی و برنامه نویسی IT");
            comboBox2.Items.Add("حقوق و مزایای پرسنل");
            comboBox2.Items.Add("مساعده پرسنل");
            comboBox2.Items.Add("ایاب و ذهاب");
            comboBox2.Items.Add("هزینه های جاری");
            comboBox2.Items.Add("هزینه آگهی و تبلیغات");
            comboBox2.Items.Add("حق بیمه پرسنل");
        }
    }
}
