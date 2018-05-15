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

//using System.ComponentModel;
//using System.Windows.Forms;

namespace AlborzAutomobile
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        SqlConnection objConnection = new SqlConnection(DB_Base.ConStr);
        SqlDataAdapter objDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();
        DataSet objDataSet1 = new DataSet();

        DB_Base Database = new DB_Base();
        U_Base U_set = new U_Base();

        public Login()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (U_set.t_t() == true)
            {
                objDataSet.Clear();

                Database.Connection_Open();
                Database.Fill("SELECT rad, nameshobe FROM namayande", objDataSet, "namayande", true);
                Database.Connection_Close();

                comboBox3.DataContext = objDataSet.Tables["namayande"];
                comboBox3.DisplayMemberPath = "nameshobe";
                comboBox3.SelectedValuePath = "rad";
            }
        }

        private void comboBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "Return") { comboBox1.Focus(); }
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "Return") { passwordBox1.Focus();}
        }

        private void comboBox3_DropDownClosed(object sender, EventArgs e)
        {
            if (comboBox3.SelectedIndex != -1)
            {
                objDataSet1.Clear();
                Database.Connection_Open();
                Database.Fill("SELECT tmpid , username FROM Tbl_User WHERE (id_Shobe = '" + comboBox3.SelectedValue.ToString() + "')", objDataSet1, "namayande", true);
                Database.Connection_Close();

                comboBox1.DataContext = objDataSet1.Tables["namayande"];
                comboBox1.DisplayMemberPath = "username";
                comboBox1.SelectedValuePath = "tmpid";
            }
        }

        private void passwordBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "Return") { button1.Focus(); }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (comboBox3.SelectedIndex == -1)
            {
                MessageBox.Show("لطفا شعبه را انتخاب نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                comboBox3.Focus();
                return;
            }

            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("لطفا نام کاربر را انتخاب نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                comboBox1.Focus();
                return;
            }

            if (passwordBox1.Password == "")
            {
                MessageBox.Show("لطفا کلمه عبور را تکمیل نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                passwordBox1.Focus();
                return;
            }

            button1.IsEnabled = false;

            Database.Connection_Open();
            Database.Fill("SELECT pwdcompare('" + passwordBox1.Password.ToString() + "',pass) AS passmainok FROM Tbl_User WHERE (tmpid = '" + comboBox1.SelectedValue.ToString() + "')", objDataSet, "account1", true);
            Database.Connection_Close();

            if (objDataSet.Tables["account1"].Rows[0]["passmainok"].ToString() == "1")
            {
                Database.Connection_Open();
                Database.Fill("SELECT * FROM Tbl_User WHERE (tmpid = '" + comboBox1.SelectedValue.ToString() + "')", objDataSet, "Sel_Tbl_User", true);
                Database.Connection_Close();
                
                MainWindow f1 = new MainWindow();
                f1.Title = "  سیستم فروش نمایندگی ( " + comboBox3.Text + " ) کاربر ( " + objDataSet.Tables["Sel_Tbl_User"].Rows[0]["name"].ToString() + " " + objDataSet.Tables["Sel_Tbl_User"].Rows[0]["family"].ToString() + " ) شرکت تولیدی خودرو البرز  249024 خوش آمدید .";
                f1.id_idshobe = comboBox3.SelectedValue.ToString();
                f1.id_user = objDataSet.Tables["Sel_Tbl_User"].Rows[0]["name"].ToString() + " " + objDataSet.Tables["Sel_Tbl_User"].Rows[0]["family"].ToString();

                string file_name = "AlborzAutomobilea.vshost.application";
                string[] installs = new string[1];
                installs[0] = objDataSet.Tables["Sel_Tbl_User"].Rows[0]["name"].ToString() + " " + objDataSet.Tables["Sel_Tbl_User"].Rows[0]["family"].ToString();
                System.IO.File.WriteAllLines(file_name, installs, Encoding.Unicode);

                string file_name1 = "AlborzAutomobilec.vshost.application";
                string[] installs1 = new string[1];
                installs1[0] = comboBox3.SelectedValue.ToString();
                System.IO.File.WriteAllLines(file_name1, installs1, Encoding.Unicode);

                U_set.u_amal_register("0","ورود به سیستم", "0", "0", "ویرایش");

                f1.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("کلمه عبور صحیح نمی باشد", "", MessageBoxButton.OK, MessageBoxImage.Error);
                passwordBox1.Focus();
            }

            button1.IsEnabled = true;
        }

        private void passwordBox1_PasswordChanged(object sender, RoutedEventArgs e)
        {
            InputLanguageManager.SetInputLanguage(passwordBox1, System.Globalization.CultureInfo.CreateSpecificCulture("fa-IR"));
        }

        private void comboBox3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBox3.SelectedIndex != -1)
            {
                objDataSet1.Clear();
                Database.Connection_Open();
                Database.Fill("SELECT tmpid , username FROM Tbl_User WHERE (id_Shobe = '" + comboBox3.SelectedValue.ToString() + "')", objDataSet1, "namayande", true);
                Database.Connection_Close();

                comboBox1.DataContext = objDataSet1.Tables["namayande"];
                comboBox1.DisplayMemberPath = "username";
                comboBox1.SelectedValuePath = "tmpid";
            }
        }
    }
}
