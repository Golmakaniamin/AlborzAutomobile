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
    /// Interaction logic for Rusty_PPrint_03_sabtvarizi.xaml
    /// </summary>
    public partial class Rusty_PPrint_03_sabtvarizi : Window
    {
        DB_Base Database = new DB_Base();
        U_Base u_set = new U_Base();

        public Rusty_PPrint_03_sabtvarizi()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            string search_amin = "";

            if ((persianDatePicker1.Text != "") && (persianDatePicker2.Text != ""))
            {
                search_amin = search_amin + " ({Crystal_Rusty_02_vekalatnameh;1.eachdate} >= '" + u_set.control_date_end(persianDatePicker1.Text) + "') AND ({Crystal_Rusty_02_vekalatnameh;1.eachdate} <= '" + u_set.control_date_end(persianDatePicker2.Text) + "') AND ";
            }

            if (search_amin != "")
            {
                search_amin = search_amin.Substring(1, search_amin.Length - 5);

                CrystalReportWpf_AlborzAutomobile.Window1 f1 = new CrystalReportWpf_AlborzAutomobile.Window1();
                f1.Title = this.Title;
                f1.selkar = "Rusty_PPrint_03_sabtvarizi";
                f1.rec_sel_for = search_amin;
                f1.date1 = u_set.control_date_end(persianDatePicker1.Text);
                f1.date2 = u_set.control_date_end(persianDatePicker2.Text);
                f1.Show();
            }
        }
    }
}
