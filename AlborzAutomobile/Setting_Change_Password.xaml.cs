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
    /// Interaction logic for Setting_Change_Password.xaml
    /// </summary>
    public partial class Setting_Change_Password : Window
    {
        SqlConnection objConnection = new SqlConnection(DB_Base.ConStr);
        SqlDataAdapter objDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();

        DB_Base Database = new DB_Base();
        U_Base U_set = new U_Base();

        public string id_idshobe;

        public Setting_Change_Password()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Database.Connection_Open();
            Database.Fill("SELECT tmpid , username FROM Tbl_User WHERE (id_Shobe = '" + id_idshobe + "')", objDataSet, "Tbl_User_ALL", true);
            Database.Connection_Close();

            comboBox1.DataContext = objDataSet.Tables["Tbl_User_ALL"];
            comboBox1.DisplayMemberPath = "username";
            comboBox1.SelectedValuePath = "tmpid";

            comboBox1.Focus();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("لطفا نام کاربر را انتخاب نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                comboBox1.Focus();
                return;
            }

            if (passwordBox1.Password.ToString() == "")
            {
                MessageBox.Show("لطفا رمز ورود قبلی را تکمیل نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                passwordBox1.Focus();
                return;
            }

            if (passwordBox2.Password.ToString() == "")
            {
                MessageBox.Show("لطفا رمز ورود جدید را تکمیل نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                passwordBox2.Focus();
                return;
            }

            Database.Connection_Open();
            Database.Fill("SELECT pwdcompare('" + passwordBox1.Password.ToString() + "',pass) AS passmainok FROM Tbl_User WHERE (tmpid = '" + comboBox1.SelectedValue.ToString() + "')", objDataSet, "Tbl_User", true);
            Database.Connection_Close();

            if (objDataSet.Tables["Tbl_User"].Rows[0]["passmainok"].ToString() == "1")
            {
                SqlCommand objCommand1 = new SqlCommand();
                objCommand1.Connection = objConnection;
                objCommand1.CommandText = "UPDATE Tbl_User SET pass = pwdencrypt('" + passwordBox2.Password.ToString() + "') WHERE (tmpid = '" + comboBox1.SelectedValue + "')";
                objCommand1.CommandType = CommandType.Text;

                objConnection.Open();
                objCommand1.ExecuteNonQuery();
                objConnection.Close();

                MessageBox.Show("رمز ورود با موفقیت تغییر پیدا کرد", "", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("لطفا رمز ورود قبلی را صحیح وارد نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                passwordBox1.Password = "";
                passwordBox1.Focus();
            }
        }
    }
}
