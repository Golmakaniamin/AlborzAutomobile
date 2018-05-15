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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Globalization;
using System.Windows.Threading;
using System.IO;

using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace AlborzAutomobile
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection objConnection = new SqlConnection(DB_Base.ConStr);
        SqlDataAdapter objDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();
        DataSet objDataSet1 = new DataSet();

        DB_Base Database = new DB_Base();
        U_Base u_set = new U_Base();

        public string id_idshobe;
        public string id_user;

        DispatcherTimer _timer;

        public MainWindow()
        {
            InitializeComponent();

            _timer = new DispatcherTimer();

            _timer.Tick += new EventHandler(delegate(object s, EventArgs a)
            {
                string file_name1 = u_set.u_time().ToString().Replace(":", "-");
                string file_name2 = @"E:\AlborzKhodro\" + u_set.u_date().ToString().Replace("/", "-");

                if (Directory.Exists(file_name2) == false)
                {
                    Directory.CreateDirectory(file_name2);
                }

                SqlCommand objCommand1 = new SqlCommand();
                objCommand1.Connection = objConnection;
                objCommand1.CommandText = "BACKUP DATABASE [Alborz] TO DISK ='" + file_name2 + @"\" + file_name1 + ".Bak' WITH MEDIAPASSWORD='AminGolmakani'";
                objCommand1.CommandType = CommandType.Text;

                objConnection.Open();
                objCommand1.ExecuteNonQuery();
                objConnection.Close();

                listBox1.Items.Add("Makeing Backup " + file_name1);
            });
        }

        private void Window_Unloaded(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            id_idshobe = "101";
            _timer.Interval = TimeSpan.FromHours(2);
            _timer.Start();
        }

        private void mnu1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void mnu2_Click(object sender, RoutedEventArgs e)
        {
            //لیست مشتریان
            AllCustomers f1 = new AllCustomers();
            int y, m, d;
            PersianCalendar pr = new PersianCalendar();
            d = pr.GetDayOfMonth(DateTime.Now);
            m = pr.GetMonth(DateTime.Now);
            y = pr.GetYear(DateTime.Now);
            String date;
            date = y.ToString().Substring(2, 2) + m.ToString().PadLeft(2, '0');
           
            f1.label1.Content = "SELECT * FROM infomen WHERE (idmen Like '" + date + "%')";
            f1.id_group = id_idshobe;
            f1.Show();
        }

        private void mnu3_Click(object sender, RoutedEventArgs e)
        {
            Rusty f2 = new Rusty();
            f2.Title = "فرسوده";
            f2.id_idshobe = id_idshobe;
            f2.Show();
        }

        private void mnu4_Click(object sender, RoutedEventArgs e)
        {
            Leasing f3 = new Leasing();
            f3.Title = "اجاره به شرط تملیک";
            f3.id_idshobe = id_idshobe;
            f3.Show();
        }

        private void mnu5_Click(object sender, RoutedEventArgs e)
        {
            Setting_user_All f5 = new Setting_user_All();
            f5.Title = "پرسنل شعبه : " + id_idshobe;
            f5.id_idshobe = id_idshobe;
            f5.Show();
        }

        private void mnu6_Click(object sender, RoutedEventArgs e)
        {
            PPrint_farsode_Ravandkar_Main f6 = new PPrint_farsode_Ravandkar_Main();
            f6.Title = "گزارش پیشرفت روند فرسوده";
            f6.Show();
        }

        private void mnu7_Click(object sender, RoutedEventArgs e)
        {
            Setting_user_All f2 = new Setting_user_All();
            f2.id_idshobe = id_idshobe;
            f2.Show();
        }

        private void mnu8_Click(object sender, RoutedEventArgs e)
        {
            All_Company_Car f2 = new All_Company_Car();
            f2.Show();
        }

        private void mnu9_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void mnu10_Click(object sender, RoutedEventArgs e)
        {
            Report_Contract_All f1 = new Report_Contract_All();
            f1.id_idshobe = id_idshobe;
            f1.Show();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void mnu11_Click(object sender, RoutedEventArgs e)
        {
            PPrint_Customers f1 = new PPrint_Customers();
            f1.Title = "گزارش ایجاد مشتریان";
            f1.Show();
        }

        private void mnu12_Click(object sender, RoutedEventArgs e)
        {
            Rusty_PPrint_02_vekalatnameh f1 = new Rusty_PPrint_02_vekalatnameh();
            f1.Title = "گزارش به تفکیک فرسوده مشخصات وکالت نامه";
            f1.Show();
        }

        private void mnu13_Click(object sender, RoutedEventArgs e)
        {
            Rusty_PPrint_04_hesab f1 = new Rusty_PPrint_04_hesab();
            f1.Title = "گزارش به تفکیک فرسوده نوع تسهیلات";
            f1.Show();
        }

        private void mnu14_Click(object sender, RoutedEventArgs e)
        {
            Rusty_PPrint_05_sabtdarsetad13 f1 = new Rusty_PPrint_05_sabtdarsetad13();
            f1.Title = "گزارش به تفکیک فرسوده ثبت نام در ستاد تبصره 13";
            f1.Show();
        }

        private void mnu15_Click(object sender, RoutedEventArgs e)
        {
            Rusty_PPrint_06_farakhan f1 = new Rusty_PPrint_06_farakhan();
            f1.Title = "گزارش به تفکیک فرسوده فراخوان مرکز اسقاط";
            f1.Show();
        }

        private void mnu16_Click(object sender, RoutedEventArgs e)
        {
            Rusty_PPrint_03_sabtvarizi f1 = new Rusty_PPrint_03_sabtvarizi();
            f1.Title = "گزارش به تفکیک فرسوده ثبت فرسوده";
            f1.Show();
        }

        private void mnu17_Click(object sender, RoutedEventArgs e)
        {
            int y, m, d;
            PersianCalendar pr = new PersianCalendar();
            d = pr.GetDayOfMonth(DateTime.Now);
            m = pr.GetMonth(DateTime.Now);
            y = pr.GetYear(DateTime.Now);
            String date;
            date = y.ToString() + "/" + m.ToString().PadLeft(2, '0');

            Financial_Cost_ALL f1 = new Financial_Cost_ALL();
            f1.Txt_search = "SELECT * FROM Sherkat_hazineh WHERE (datesodor Like '" + date + "%')";
            f1.id_group = id_idshobe;
            f1.Title = "مالی";
            f1.Show();
        }

        private void mnu18_Click(object sender, RoutedEventArgs e)
        {
            Sell_Buy f2 = new Sell_Buy();
            f2.Title = "خرید و فروش نقدی";
            f2.id_idshobe = id_idshobe;
            f2.Show();
        }

        private void mnu19_Click(object sender, RoutedEventArgs e)
        {
            Setting_Change_Password f2 = new Setting_Change_Password();
            f2.Title = "تغییر رمز عبور";
            f2.id_idshobe = id_idshobe;
            f2.Show();
        }

        private void mnu20_Click(object sender, RoutedEventArgs e)
        {
            Setting_Bureau f2 = new Setting_Bureau();
            f2.Title = "لیست دفتر خانه";
            f2.id_Shobe = id_idshobe;
            f2.Show();
        }

        private void mnu21_Click(object sender, RoutedEventArgs e)
        {
            Setting_Dismantled_Center f2 = new Setting_Dismantled_Center();
            f2.Title = "لیست مرکز اسقاط";
            f2.id_Shobe = id_idshobe;
            f2.Show();
        }

        private void mnu22_Click(object sender, RoutedEventArgs e)
        {
            Sales_01_Main f2 = new Sales_01_Main();
            f2.Title = "فروش نقد و اقساط";
            f2.id_idshobe = id_idshobe;
            f2.Show();
        }

        private void mnu23_Click(object sender, RoutedEventArgs e)
        {
            Report_Rusty_Car f2 = new Report_Rusty_Car();
            f2.Title = "جستجوی خودرو فرسوده";
            f2.id_idshobe = id_idshobe;
            f2.Show();
        }
    }
}
