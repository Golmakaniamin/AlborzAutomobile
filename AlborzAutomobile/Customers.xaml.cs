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
using System.Data;
using System.Globalization;

namespace AlborzAutomobile
{
    /// <summary>
    /// Interaction logic for Customers.xaml
    /// </summary>
    public partial class Customers : Window
    {
        SqlConnection objConnection = new SqlConnection(DB_Base.ConStr);
        SqlDataAdapter objDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();

        DB_Base Database = new DB_Base();
        U_Base u_set = new U_Base();

        public string id_group;
        public string id_melli;
        
        public string sel_id_idshobe;
        public string sel_id_idmen;

        public Customers()
        {
            InitializeComponent();
        }

        private void Alborz_new_idmoshtari()
        {
            int y, m, d;
            PersianCalendar pr = new PersianCalendar();
            d = pr.GetDayOfMonth(DateTime.Now);
            m = pr.GetMonth(DateTime.Now);
            y = pr.GetYear(DateTime.Now);
            String date;
            date = y.ToString().Substring(2, 2) + m.ToString().PadLeft(2, '0') + d.ToString().PadLeft(2, '0');

            Database.Connection_Open();
            Database.Fill("SELECT * FROM infomen WHERE (LEFT(idmen,6) = '" + date + "')", objDataSet, "infomenCount", true);
            Database.Connection_Close();

            label17.Content = date + (objDataSet.Tables["infomenCount"].Rows.Count + 1).ToString().PadLeft(4, '0');

            objDataSet.Tables["infomenCount"].Clear();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            textBox1.Background = Brushes.White;
            textBox3.Background = Brushes.White;
            textBox4.Background = Brushes.White;
            textBox5.Background = Brushes.White;
            textBox6.Background = Brushes.White;
            textBox7.Background = Brushes.White;
            textBox8.Background = Brushes.White;
            textBox9.Background = Brushes.White;
            textBox10.Background = Brushes.White;
            textBox11.Background = Brushes.White; 
            textBox12.Background = Brushes.White; 
            textBox13.Background = Brushes.White;
            textBox14.Background = Brushes.White;
            textBox15.Background = Brushes.White;

            if (textBox1.Text == "")
            {
                MessageBox.Show("لطفا کد شعبه را تکمیل نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                textBox1.Background = Brushes.Yellow;
                textBox1.Focus();
                return;
            }

            if (textBox3.Text == "")
            {
                MessageBox.Show("لطفا نام را تکمیل نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                textBox3.Background = Brushes.Yellow;
                textBox3.Focus();
                return;
            }

            if (textBox4.Text == "")
            {
                MessageBox.Show("لطفا نام خانوادگی را تکمیل نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                textBox4.Background = Brushes.Yellow;
                textBox4.Focus();
                return;
            }

            if (textBox5.Text == "")
            {
                MessageBox.Show("لطفا نام پدر را تکمیل نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                textBox5.Background = Brushes.Yellow;
                textBox5.Focus();
                return;
            }

            if (textBox6.Text == "")
            {
                MessageBox.Show("لطفا شماره شناسنامه را تکمیل نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                textBox6.Background = Brushes.Yellow;
                textBox6.Focus();
                return;
            }

            if (textBox7.Text == "")
            {
                MessageBox.Show("لطفا کد ملی را تکمیل نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                textBox7.Background = Brushes.Yellow;
                textBox7.Focus();
                return;
            }

            if (textBox8.Text == "")
            {
                MessageBox.Show("لطفا محل صدور را تکمیل نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                textBox8.Background = Brushes.Yellow;
                textBox8.Focus();
                return;
            }

            if (textBox9.Text == "")
            {
                MessageBox.Show("لطفا کد پستی را تکمیل نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                textBox9.Background = Brushes.Yellow;
                textBox9.Focus();
                return;
            }

            if (textBox10.Text == "")
            {
                MessageBox.Show("لطفا تاریخ تولد را تکمیل نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                textBox10.Background = Brushes.Yellow;
                textBox10.Focus();
                return;
            }

            if (textBox11.Text == "")
            {
                MessageBox.Show("لطفا تلفن همراه را تکمیل نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                textBox11.Background = Brushes.Yellow;
                textBox11.Focus();
                return;
            }

            if (textBox12.Text == "")
            {
                MessageBox.Show("لطفا تلفن منزل را تکمیل نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                textBox12.Background = Brushes.Yellow;
                textBox12.Focus();
                return;
            }

            if (textBox13.Text == "")
            {
                MessageBox.Show("لطفا تلفن محل کار را تکمیل نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                textBox13.Background = Brushes.Yellow;
                textBox13.Focus();
                return;
            }

            if (textBox14.Text == "")
            {
                MessageBox.Show("لطفا نشانی منزل را تکمیل نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                textBox14.Background = Brushes.Yellow;
                textBox14.Focus();
                return;
            }

            if (textBox15.Text == "")
            {
                MessageBox.Show("لطفا توضیحات را تکمیل نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                textBox15.Background = Brushes.Yellow;
                textBox15.Focus();
                return;
            }

            if (label16.Content.ToString() == "Add")
            {
                Database.Connection_Open();
                Database.Fill("SELECT * FROM infomen WHERE (id = '" + textBox7.Text + "')", objDataSet, "infomenCount", true);
                Database.Connection_Close();

                if (objDataSet.Tables["infomenCount"].Rows.Count > 0)
                {
                    MessageBox.Show("کد ملی وارد شده تکراری می باشد", "", MessageBoxButton.OK, MessageBoxImage.Error);
                    textBox7.Background = Brushes.Yellow;
                    textBox7.Focus();
                    return;
                }

                objDataSet.Tables["infomenCount"].Clear();

                Alborz_new_idmoshtari();

                SqlCommand objCommand1 = new SqlCommand();
                objCommand1.Connection = objConnection;
                objCommand1.CommandText = "INSERT INTO infomen (idshobe,id,datesabt,idmen,name,family,fathername,shsh,brithdate,idp,mobile,phone,phonework,addresshome,addresswork,sadereh,uuser,udate,utime,upc) VALUES (@idshobe,@id,@datesabt,@idmen,@name,@family,@fathername,@shsh,@brithdate,@idp,@mobile,@phone,@phonework,@addresshome,@addresswork,@sadereh,@uuser,@udate,@utime,@upc)";
                objCommand1.CommandType = CommandType.Text;
                objCommand1.Parameters.AddWithValue("@idshobe", textBox1.Text);
                objCommand1.Parameters.AddWithValue("@id", textBox7.Text);
                objCommand1.Parameters.AddWithValue("@datesabt", u_set.u_date());
                objCommand1.Parameters.AddWithValue("@idmen", label17.Content);
                objCommand1.Parameters.AddWithValue("@name", textBox3.Text);
                objCommand1.Parameters.AddWithValue("@family", textBox4.Text);
                objCommand1.Parameters.AddWithValue("@fathername", textBox5.Text);
                objCommand1.Parameters.AddWithValue("@shsh", textBox6.Text);
                objCommand1.Parameters.AddWithValue("@brithdate", textBox10.Text);
                objCommand1.Parameters.AddWithValue("@idp", textBox9.Text);
                objCommand1.Parameters.AddWithValue("@mobile", textBox11.Text);
                objCommand1.Parameters.AddWithValue("@phone", textBox12.Text);
                objCommand1.Parameters.AddWithValue("@phonework", textBox13.Text);
                objCommand1.Parameters.AddWithValue("@addresshome", textBox14.Text);
                objCommand1.Parameters.AddWithValue("@addresswork", textBox15.Text);
                objCommand1.Parameters.AddWithValue("@sadereh", textBox8.Text);
                objCommand1.Parameters.AddWithValue("@uuser", u_set.u_user());
                objCommand1.Parameters.AddWithValue("@udate", u_set.u_date());
                objCommand1.Parameters.AddWithValue("@utime", u_set.u_time());
                objCommand1.Parameters.AddWithValue("@upc", u_set.u_pc());
                objConnection.Open();
                objCommand1.ExecuteNonQuery();
                objConnection.Close();

                u_set.u_amal_register("0", this.Title, label17.Content.ToString(), "0", "جدید");
                MessageBox.Show("اطلاعات با موفقیت ثبت شد", "پيغام", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            if (label16.Content.ToString() == "Edit")
            {
                SqlCommand objCommand1 = new SqlCommand();
                objCommand1.Connection = objConnection;
                objCommand1.CommandText = "UPDATE infomen SET name=@name ,family=@family ,fathername=@fathername ,shsh=@shsh ,brithdate=@brithdate ,idp=@idp ,addresshome=@addresshome ,addresswork=@addresswork ,sadereh=@sadereh ,uuser=@uuser ,udate=@udate ,utime=@utime ,upc=@upc WHERE (idshobe = '" + sel_id_idshobe + "') AND (idmen = '" + sel_id_idmen + "')";
                objCommand1.CommandType = CommandType.Text;
                objCommand1.Parameters.AddWithValue("@idshobe", textBox1.Text);
                //objCommand1.Parameters.AddWithValue("@id", textBox7.Text);
                objCommand1.Parameters.AddWithValue("@idmen", label17.Content);
                objCommand1.Parameters.AddWithValue("@name", textBox3.Text);
                objCommand1.Parameters.AddWithValue("@family", textBox4.Text);
                objCommand1.Parameters.AddWithValue("@fathername", textBox5.Text);
                objCommand1.Parameters.AddWithValue("@shsh", textBox6.Text);
                objCommand1.Parameters.AddWithValue("@brithdate", textBox10.Text);
                objCommand1.Parameters.AddWithValue("@idp", textBox9.Text);
                //objCommand1.Parameters.AddWithValue("@mobile", textBox11.Text);
                //objCommand1.Parameters.AddWithValue("@phone", textBox12.Text);
                //objCommand1.Parameters.AddWithValue("@phonework", textBox13.Text);
                objCommand1.Parameters.AddWithValue("@addresshome", textBox14.Text);
                objCommand1.Parameters.AddWithValue("@addresswork", textBox15.Text);
                objCommand1.Parameters.AddWithValue("@sadereh", textBox8.Text);
                objCommand1.Parameters.AddWithValue("@uuser", u_set.u_pc());
                objCommand1.Parameters.AddWithValue("@udate", u_set.u_date());
                objCommand1.Parameters.AddWithValue("@utime", u_set.u_time());
                objCommand1.Parameters.AddWithValue("@upc", u_set.u_pc());
                objConnection.Open();
                objCommand1.ExecuteNonQuery();
                objConnection.Close();

                u_set.u_amal_register("0", this.Title, label17.Content.ToString(), "0", "ویرایش");

                MessageBox.Show("اطلاعات با موفقیت ویرایش شد", "پيغام", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            for (int q = 1; q <= 22; q++)
            {
                comboBox3.Items.Add(q.ToString());
            }

            if (label16.Content.ToString() == "Add")
            {
                textBox1.Text = id_group;
                textBox3.Text = string.Empty;
                textBox4.Text = string.Empty;
                textBox5.Text = string.Empty;
                textBox6.Text = string.Empty;
                textBox7.Text = id_melli;
                textBox8.Text = string.Empty;
                textBox9.Text = string.Empty;
                textBox10.Text = string.Empty;
                textBox11.Text = string.Empty;
                textBox12.Text = string.Empty;
                textBox13.Text = string.Empty;
                textBox14.Text = string.Empty;
                textBox15.Text = string.Empty;
            }

            if (label16.Content.ToString() == "Edit")
            {
                Database.Connection_Open();
                Database.Fill("SELECT * FROM infomen WHERE (idshobe = '" + sel_id_idshobe + "') AND (idmen = '" + sel_id_idmen + "')", objDataSet, "infomen", true);
                Database.Connection_Close();

                textBox1.Text = objDataSet.Tables["infomen"].Rows[0]["idshobe"].ToString();
                label17.Content = objDataSet.Tables["infomen"].Rows[0]["idmen"].ToString();
                textBox3.Text = objDataSet.Tables["infomen"].Rows[0]["name"].ToString();
                textBox4.Text = objDataSet.Tables["infomen"].Rows[0]["family"].ToString();
                textBox5.Text = objDataSet.Tables["infomen"].Rows[0]["fathername"].ToString();
                textBox6.Text = objDataSet.Tables["infomen"].Rows[0]["shsh"].ToString();
                textBox7.Text = objDataSet.Tables["infomen"].Rows[0]["id"].ToString();
                textBox8.Text = objDataSet.Tables["infomen"].Rows[0]["sadereh"].ToString();
                textBox9.Text = objDataSet.Tables["infomen"].Rows[0]["idp"].ToString();
                textBox10.Text = objDataSet.Tables["infomen"].Rows[0]["brithdate"].ToString();
                textBox11.Text = objDataSet.Tables["infomen"].Rows[0]["mobile"].ToString();
                textBox12.Text = objDataSet.Tables["infomen"].Rows[0]["phone"].ToString();
                textBox13.Text = objDataSet.Tables["infomen"].Rows[0]["phonework"].ToString();
                textBox14.Text = objDataSet.Tables["infomen"].Rows[0]["addresshome"].ToString();
                textBox15.Text = objDataSet.Tables["infomen"].Rows[0]["addresswork"].ToString();
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "Return") { textBox3.Focus(); }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "Return") { textBox4.Focus(); }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "Return") { textBox3.Focus(); }
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "Return") { textBox6.Focus(); }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "Return") { textBox5.Focus(); }
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "Return") { textBox7.Focus(); }
        }

        private void textBox7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "Return") { textBox8.Focus(); }
        }

        private void textBox8_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "Return") { textBox9.Focus(); }
        }

        private void textBox9_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "Return") { textBox10.Focus(); }
        }

        private void textBox10_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "Return") { textBox11.Focus(); }
        }

        private void textBox11_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "Return") { textBox12.Focus(); }
        }

        private void textBox12_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "Return") { textBox13.Focus(); }
        }

        private void textBox13_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "Return") { textBox14.Focus(); }
        }

        private void textBox14_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "Return") { textBox15.Focus(); }
        }

        private void textBox15_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "Return") { button3.Focus(); }
        }
    }
}
