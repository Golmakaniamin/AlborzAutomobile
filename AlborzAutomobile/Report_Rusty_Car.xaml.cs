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
    /// Interaction logic for Report_Rusty_Car.xaml
    /// </summary>
    public partial class Report_Rusty_Car : Window
    {
        SqlConnection objConnection = new SqlConnection(DB_Base.ConStr);
        SqlDataAdapter objDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();

        DB_Base Database = new DB_Base();
        U_Base u_set = new U_Base();

        public string id_idshobe;

        public Report_Rusty_Car()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            comboBox3.Items.Add("سواری شخصی");
            comboBox3.Items.Add("سواری عمومی");
            comboBox3.Items.Add("وانت شخصی");
            comboBox3.Items.Add("وانت عمومی");
            comboBox3.Items.Add("مینی بوس");
            comboBox3.Items.Add("اتوبوس");
            comboBox3.Items.Add("کامیون");
            comboBox3.Items.Add("کامیونت");
            comboBox3.Items.Add("آمبولانس");

            comboBox7.Items.Add("1");
            comboBox7.Items.Add("2");

            comboBox8.Items.Add("2");
            comboBox8.Items.Add("3");
            comboBox8.Items.Add("4");
            comboBox8.Items.Add("6");
            comboBox8.Items.Add("8");
            comboBox8.Items.Add("12");

            for (int q = 1330; q <= 1366; q++)
            {
                comboBox6.Items.Add(q.ToString());
            }

            for (int q = 1950; q <= 1986; q++)
            {
                comboBox6.Items.Add(q.ToString());
            }

            Database.Connection_Open();
            Database.Fill("SELECT name,tmpid FROM Tbl_Rusty_Khodro ORDER BY name", objDataSet, "Tbl_Rusty_Khodro", true);
            Database.Connection_Close();

            comboBox5.DataContext = objDataSet.Tables["Tbl_Rusty_Khodro"];
            comboBox5.DisplayMemberPath = "name";
            comboBox5.SelectedValuePath = "tmpid";
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            string search_amin = "";

            if (comboBox5.SelectedIndex != -1)
                search_amin += " (nokhodro LIKE '%" + comboBox5.Text + "%') AND ";

            if (comboBox3.SelectedIndex != -1)
                search_amin += " (nokarbari LIKE '%" + comboBox3.Text + "%') AND ";

            if (comboBox7.SelectedIndex != -1)
                search_amin += " (numberdeff LIKE '%" + comboBox7.Text + "%') AND ";

            if (comboBox8.SelectedIndex != -1)
                search_amin += " (numbersilandr LIKE '%" + comboBox8.Text + "%') AND ";

            if (comboBox6.SelectedIndex != -1)
                search_amin += " (model LIKE '%" + comboBox6.Text + "%') AND ";

            if (textBox5.Text != "")
                search_amin += " (shshasi LIKE '%" + textBox5.Text + "%') AND ";

            if (textBox10.Text != "")
                search_amin += " (shsokhtcard LIKE '%" + textBox10.Text + "%') AND ";

            if (textBox9.Text != "")
                search_amin += " (idvin LIKE '%" + textBox9.Text + "%') AND ";

            if (textBox11.Text != "")
                search_amin += " (p1_1 LIKE '%" + textBox11.Text + "%') AND ";

            if (textBox12.Text != "")
                search_amin += " (p1_2 LIKE '%" + textBox12.Text + "%') AND ";

            if (textBox13.Text != "")
                search_amin += " (p1_3 LIKE '%" + textBox13.Text + "%') AND ";

            if (textBox14.Text != "")
                search_amin += " (p1_4 LIKE '%" + textBox14.Text + "%') AND ";

            if (textBox15.Text != "")
                search_amin += " (p2_1 LIKE '%" + textBox15.Text + "%') AND ";

            if (textBox16.Text != "")
                search_amin += " (p2_2 LIKE '%" + textBox16.Text + "%') AND ";

            if (textBox17.Text != "")
                search_amin += " (p2_3 LIKE '%" + textBox17.Text + "%') AND ";

            if (textBox18.Text != "")
                search_amin += " (p3_1 LIKE '%" + textBox18.Text + "%') AND ";

            if (textBox19.Text != "")
                search_amin += " (p3_2 LIKE '%" + textBox19.Text + "%') AND ";

            if (search_amin.Length == 0)
            {
                search_amin = "SELECT * FROM infokhodro";
            }
            else
            {
                search_amin = search_amin.Substring(1, search_amin.Length - 5);
                search_amin = "SELECT * FROM infokhodro WHERE " + search_amin;
            }

            Database.Connection_Open();
            Database.Fill(search_amin, objDataSet, "infokhodro", true);
            Database.Connection_Close();

            dataGrid1.DataContext = objDataSet;
        }
    }
}
