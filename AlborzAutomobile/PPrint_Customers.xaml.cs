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

namespace AlborzAutomobile
{
    /// <summary>
    /// Interaction logic for PPrint_Customers.xaml
    /// </summary>
    public partial class PPrint_Customers : Window
    {
        DB_Base Database = new DB_Base();
        U_Base u_set = new U_Base();

        public PPrint_Customers()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            string search_amin = "";

            if ((textBox1.Text != "") && (textBox2.Text != ""))
            {
                search_amin = search_amin + " ({Crystal_Rusty_Customers;1.S1_idshobe} >= '" + textBox1.Text + "') AND ({Crystal_Rusty_Customers;1.S1_idshobe} <= '" + textBox2.Text + "') AND ";
            }

            if ((persianDatePicker1.Text != "") && (persianDatePicker2.Text != ""))
            {
                search_amin = search_amin + " ({Crystal_Rusty_Customers;1.datesabt} >= '" + u_set.control_date_end(persianDatePicker1.Text) + "') AND ({Crystal_Rusty_Customers;1.datesabt} <= '" + u_set.control_date_end(persianDatePicker2.Text) + "') AND ";
            }

            if (search_amin != "")
            {
                search_amin = search_amin.Substring(1, search_amin.Length - 5);

                CrystalReportWpf_AlborzAutomobile.Window1 f1 = new CrystalReportWpf_AlborzAutomobile.Window1();
                f1.Title = "گزارش ایجاد مشتری";
                f1.selkar = "Crystal_Rusty_Customers";
                f1.rec_sel_for = search_amin;
                f1.Show();
            }
        }
    }
}
