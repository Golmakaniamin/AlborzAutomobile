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
    /// Interaction logic for Financial_Cost.xaml
    /// </summary>
    public partial class Financial_Cost : Window
    {
        SqlConnection objConnection = new SqlConnection(DB_Base.ConStr);
        SqlDataAdapter objDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();

        DB_Base Database = new DB_Base();
        U_Base u_set = new U_Base();

        public string idshobe;
        public string sel_work;
        public string sel_tmpid = "";
        
        public Financial_Cost()
        {
            InitializeComponent();
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
            comboBox1.Items.Add("صندوق شرکت");

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
            comboBox2.Items.Add("خرید خودرو");
            comboBox2.Items.Add("واریز وجه فرسوده");
            comboBox2.Items.Add("واریز وجه خرید جایگزین");

            if (sel_work == "New")
            {
                textBox1.Text = string.Empty;
                textBox2.Text = string.Empty;
                textBox3.Text = string.Empty;
                textBox4.Text = string.Empty;
                textBox5.Text = string.Empty;
                textBox6.Text = string.Empty;
            }

            if (sel_work == "Edit")
            {
                Database.Connection_Open();
                Database.Fill("SELECT * FROM Sherkat_hazineh WHERE (tmpid = '" + sel_tmpid + "')", objDataSet, "Sherkat_hazineh", true);
                Database.Connection_Close();

                comboBox1.Text = objDataSet.Tables["Sherkat_hazineh"].Rows[0]["bank"].ToString();
                textBox1.Text = objDataSet.Tables["Sherkat_hazineh"].Rows[0]["vajhe"].ToString();
                textBox2.Text = objDataSet.Tables["Sherkat_hazineh"].Rows[0]["serialcheck"].ToString();
                textBox3.Text = objDataSet.Tables["Sherkat_hazineh"].Rows[0]["babat"].ToString();
                comboBox2.Text = objDataSet.Tables["Sherkat_hazineh"].Rows[0]["mozo"].ToString();
                textBox4.Text = objDataSet.Tables["Sherkat_hazineh"].Rows[0]["prompt"].ToString();
                persianDatePicker1.Text = objDataSet.Tables["Sherkat_hazineh"].Rows[0]["datesodor"].ToString();
                persianDatePicker2.Text = objDataSet.Tables["Sherkat_hazineh"].Rows[0]["datesarresid"].ToString();
                textBox5.Text = objDataSet.Tables["Sherkat_hazineh"].Rows[0]["money1"].ToString();
                textBox6.Text = objDataSet.Tables["Sherkat_hazineh"].Rows[0]["reciver_men"].ToString();
            }
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            textBox1.Background = Brushes.White;
            textBox2.Background = Brushes.White;
            textBox3.Background = Brushes.White;
            textBox4.Background = Brushes.White;
            textBox5.Background = Brushes.White;
            textBox6.Background = Brushes.White;
            comboBox1.Background = Brushes.White;
            comboBox2.Background = Brushes.White;

            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("لطفا بانک را انتخاب نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                comboBox1.Background = Brushes.Yellow; 
                comboBox1.Focus();
                return;
            }

            if (textBox1.Text == "")
            {
                MessageBox.Show("لطفا در وجه را تکمیل نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                textBox1.Background = Brushes.Yellow;
                textBox1.Focus();
                return;
            }

            if (textBox2.Text == "")
            {
                MessageBox.Show("لطفا بابت را تکمیل نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                textBox3.Background = Brushes.Yellow;
                textBox3.Focus();
                return;
            }

            if (textBox3.Text == "")
            {
                MessageBox.Show("لطفا شماره سریال چک را تکمیل نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                textBox3.Background = Brushes.Yellow;
                textBox3.Focus();
                return;
            }

            if (comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("لطفا موضوع را انتخاب نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                comboBox2.Background = Brushes.Yellow;
                comboBox2.Focus();
                return;
            }

            if (textBox5.Text == "")
            {
                MessageBox.Show("لطفا مبلغ را تکمیل نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                textBox5.Background = Brushes.Yellow;
                textBox5.Focus();
                return;
            }

            if (textBox6.Text == "")
            {
                MessageBox.Show("لطفا دریافت کننده چک را تکمیل نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                textBox6.Background = Brushes.Yellow;
                textBox6.Focus();
                return;
            }

            if (persianDatePicker1.Text == "")
            {
                MessageBox.Show("لطفا تاریخ صدور چک را تکمیل نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                persianDatePicker1.Focus();
                return;
            }

            if (persianDatePicker2.Text == "")
            {
                MessageBox.Show("لطفا تاریخ سر رسید چک را تکمیل نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                persianDatePicker2.Focus();
                return;
            }

            if (textBox4.Text == "")
            {
                MessageBox.Show("لطفا توضیحات را تکمیل نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                textBox4.Background = Brushes.Yellow;
                textBox4.Focus();
                return;
            }


            if (sel_work == "New")
            {
                SqlCommand objCommand1 = new SqlCommand();
                objCommand1.Connection = objConnection;
                objCommand1.CommandText = "INSERT INTO Sherkat_hazineh (bank,vajhe,serialcheck,babat,mozo,prompt,datesodor,datesarresid,money1,reciver_men,idshobe) VALUES (@bank,@vajhe,@serialcheck,@babat,@mozo,@prompt,@datesodor,@datesarresid,@money1,@reciver_men,@idshobe)";
                objCommand1.CommandType = CommandType.Text;
                objCommand1.Parameters.AddWithValue("@bank", comboBox1.Text);
                objCommand1.Parameters.AddWithValue("@vajhe", textBox1.Text);
                objCommand1.Parameters.AddWithValue("@serialcheck", textBox2.Text);
                objCommand1.Parameters.AddWithValue("@babat", textBox3.Text);
                objCommand1.Parameters.AddWithValue("@mozo", comboBox2.Text);
                objCommand1.Parameters.AddWithValue("@prompt", textBox4.Text);
                objCommand1.Parameters.AddWithValue("@datesodor",u_set.control_date_end(persianDatePicker1.Text));
                objCommand1.Parameters.AddWithValue("@datesarresid", u_set.control_date_end(persianDatePicker2.Text));
                objCommand1.Parameters.AddWithValue("@money1",Convert.ToInt32(textBox5.Text));
                objCommand1.Parameters.AddWithValue("@reciver_men", textBox6.Text);
                objCommand1.Parameters.AddWithValue("@idshobe", Convert.ToInt32(idshobe));
                objConnection.Open();
                objCommand1.ExecuteNonQuery();
                objConnection.Close();

                u_set.u_amal_register("10", this.Title, textBox2.Text, "0", "جدید");
                MessageBox.Show("اطلاعات با موفقیت ثبت شد", "پيغام", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            if (sel_work == "Edit")
            {
                SqlCommand objCommand1 = new SqlCommand();
                objCommand1.Connection = objConnection;
                objCommand1.CommandText = "UPDATE Sherkat_hazineh SET bank=@bank, vajhe=@vajhe, serialcheck=@serialcheck, babat=@babat, mozo=@mozo, prompt=@prompt, datesodor=@datesodor, datesarresid=@datesarresid, money1=@money1, reciver_men=@reciver_men, idshobe=@idshobe WHERE (tmpid = '" + sel_tmpid + "')";
                objCommand1.CommandType = CommandType.Text;
                objCommand1.Parameters.AddWithValue("@bank", comboBox1.Text);
                objCommand1.Parameters.AddWithValue("@vajhe", textBox1.Text);
                objCommand1.Parameters.AddWithValue("@serialcheck", textBox2.Text);
                objCommand1.Parameters.AddWithValue("@babat", textBox3.Text);
                objCommand1.Parameters.AddWithValue("@mozo", comboBox2.Text);
                objCommand1.Parameters.AddWithValue("@prompt", textBox4.Text);
                objCommand1.Parameters.AddWithValue("@datesodor", u_set.control_date_end(persianDatePicker1.Text));
                objCommand1.Parameters.AddWithValue("@datesarresid", u_set.control_date_end(persianDatePicker2.Text));
                objCommand1.Parameters.AddWithValue("@money1", Convert.ToInt32(textBox5.Text));
                objCommand1.Parameters.AddWithValue("@reciver_men", textBox6.Text);
                objCommand1.Parameters.AddWithValue("@idshobe", Convert.ToInt32(idshobe));
                objConnection.Open();
                objCommand1.ExecuteNonQuery();
                objConnection.Close();

                u_set.u_amal_register("10", this.Title, textBox2.Text, "1", "ویرایش");
                MessageBox.Show("اطلاعات با موفقیت ویرایش شد", "پيغام", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
