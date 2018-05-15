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
    /// Interaction logic for Leasing_01_sabtdarkhast.xaml
    /// </summary>
    public partial class Leasing_01_sabtdarkhast : Window
    {
        SqlConnection objConnection = new SqlConnection(DB_Base.ConStr);
        SqlDataAdapter objDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();
        DataSet objDataSet1 = new DataSet();

        DB_Base Database = new DB_Base();
        U_Base u_set = new U_Base();

        public string selStatus;

        public string id_idshobe;
        public string id_idmen;
        public string id_Contract;

        public Leasing_01_sabtdarkhast()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            comboBox3.Items.Add("ایران خودرو");
            comboBox3.Items.Add("بانک ملی");
            comboBox3.Items.Add("ایرانیان");
            comboBox3.Items.Add("آریا دانا");
            comboBox3.Items.Add("ملت");
            comboBox3.Items.Add("پارسیان");
            comboBox3.Items.Add("صدرا");
            comboBox3.Items.Add("پاک زیست خودرو");
            comboBox3.Items.Add("تجارت");
            comboBox3.Items.Add("رایان سایپا");
            comboBox3.Items.Add("صنعت و معدن");
            comboBox3.Items.Add("کار آفرین");
            comboBox3.Items.Add("فرهنگیان");

            objDataSet.Clear();
            Database.Connection_Open();
            Database.Fill("SELECT idsherkat,namesherkat FROM infonewall GROUP by idsherkat,namesherkat ORDER BY idsherkat", objDataSet, "infonewall", true);
            Database.Connection_Close();

            comboBox1.DataContext = objDataSet.Tables["infonewall"];
            comboBox1.DisplayMemberPath = "namesherkat";
            comboBox1.SelectedValuePath = "idsherkat";

            Database.Connection_Open();
            Database.Fill("SELECT namemarkaz,rad FROM Daftar ORDER BY rad", objDataSet, "Daftar", true);
            Database.Connection_Close();

            comboBox4.DataContext = objDataSet.Tables["Daftar"];
            comboBox4.DisplayMemberPath = "namemarkaz";
            comboBox4.SelectedValuePath = "rad";

            if (selStatus == "Edit")
            {
                Database.Connection_Open();
                Database.Fill("SELECT * FROM All_End_EzareBeShartTamlik WHERE (S1_idshobe = '" + id_idshobe + "') AND (S1_idmen = '" + id_idmen + "') AND (S1_rad = '" + id_Contract + "')", objDataSet, "All_End_EzareBeShartTamlik", true);
                Database.Connection_Close();

                comboBox3.Text = objDataSet.Tables["All_End_EzareBeShartTamlik"].Rows[0]["S2_tarafgharardad"].ToString();
                textBox20.Text = objDataSet.Tables["All_End_EzareBeShartTamlik"].Rows[0]["S2_idkhodro1"].ToString();

                objDataSet1.Clear();
                Database.Connection_Open();
                Database.Fill("SELECT idkhodro, namekhodro FROM infonewall WHERE (idsherkat = '" + textBox20.Text + "') ORDER BY idkhodro", objDataSet1, "infonewall", true);
                Database.Connection_Close();

                comboBox2.DataContext = objDataSet1.Tables["infonewall"];
                comboBox2.DisplayMemberPath = "namekhodro";
                comboBox2.SelectedValuePath = "idkhodro";

                textBox21.Text = objDataSet.Tables["All_End_EzareBeShartTamlik"].Rows[0]["S2_idkhodro2"].ToString();
                textBox1.Text = objDataSet.Tables["All_End_EzareBeShartTamlik"].Rows[0]["s2_money"].ToString();
                textBox2.Text = objDataSet.Tables["All_End_EzareBeShartTamlik"].Rows[0]["S3_Daftarkhane"].ToString();
                objDataSet.Tables["All_End_EzareBeShartTamlik"].Clear();
                button3.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (comboBox3.SelectedIndex == -1)
            {
                MessageBox.Show("لطفا لیزینگ طرف قرارداد را انتخاب نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                comboBox3.Focus();
                return;
            }

            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("لطفا شرکت سازنده را انتخاب نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                comboBox1.Focus();
                return;
            }

            if (comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("لطفا محصول را انتخاب نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                comboBox2.Focus();
                return;
            }

            if (textBox1.Text == "")
            {
                MessageBox.Show("لطفا مبلغ قرارداد را تکمیل نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                textBox1.Focus();
                return;
            }

            if (textBox1.Text.Length < 8)
            {
                MessageBox.Show("لطفا مبلغ قرارداد را صحیح وارد نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                textBox1.Focus();
                return;
            }

            if (comboBox4.SelectedIndex == -1)
            {
                MessageBox.Show("لطفا دفتر خانه را انتخاب نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                comboBox4.Focus();
                return;
            }

            if (selStatus == "New")
            {
                SqlCommand objCommand1 = new SqlCommand();
                objCommand1.Connection = objConnection;
                objCommand1.CommandText = "INSERT INTO All_End_EzareBeShartTamlik (S1_idmen,S1_idmeli,S1_rad,S1_idshobe,s1_enseraf,S2_tarafgharardad,S2_idkhodro1,S2_idkhodro2,s2_money,S3_Daftarkhane,udate) VALUES (@S1_idmen,@S1_idmeli,@S1_rad,@S1_idshobe,@s1_enseraf,@S2_tarafgharardad,@S2_idkhodro1,@S2_idkhodro2,@s2_money,@S3_Daftarkhane,@udate)";
                objCommand1.CommandType = CommandType.Text;

                Database.Connection_Open();
                Database.Fill("SELECT ISNULL(MAX(id),0) AS rsmax FROM All_End_EzareBeShartTamlik", objDataSet, "All_End_EzareBeShartTamlik1", true);
                Database.Connection_Close();
                label4.Content = "3010" + (Convert.ToInt64(objDataSet.Tables["All_End_EzareBeShartTamlik1"].Rows[0]["rsmax"].ToString()) + 1).ToString();

                objCommand1.Parameters.AddWithValue("@S1_rad", label4.Content);
                objCommand1.Parameters.AddWithValue("@S1_idmen", id_idmen);
                objCommand1.Parameters.AddWithValue("@S1_idmeli", id_Contract);
                objCommand1.Parameters.AddWithValue("@S1_idshobe", id_idshobe);
                objCommand1.Parameters.AddWithValue("@s1_enseraf", "ندارد");
                objCommand1.Parameters.AddWithValue("@S2_tarafgharardad", comboBox3.Text);
                objCommand1.Parameters.AddWithValue("@S2_idkhodro1", textBox20.Text);
                objCommand1.Parameters.AddWithValue("@S2_idkhodro2", textBox21.Text);
                objCommand1.Parameters.AddWithValue("@s2_money", textBox1.Text);
                objCommand1.Parameters.AddWithValue("@S3_Daftarkhane", textBox2.Text);
                objCommand1.Parameters.AddWithValue("@udate", u_set.u_date());
                
                objConnection.Open();
                objCommand1.ExecuteNonQuery();
                objConnection.Close();

                id_Contract = label4.Content.ToString();

                u_set.u_amal_register("2", this.Title, id_Contract, "1", "جدید");

                selStatus = "Edit";
                MessageBox.Show("اطلاعات با موفقیت ثبت شد", "", MessageBoxButton.OK, MessageBoxImage.Information);
                
                label4.Visibility = System.Windows.Visibility.Visible;
                label6.Visibility = System.Windows.Visibility.Visible;

                button3.Visibility = System.Windows.Visibility.Visible;
                return;
            }

            if (selStatus == "Edit")
            {
                SqlCommand objCommand1 = new SqlCommand();
                objCommand1.Connection = objConnection;
                objCommand1.CommandText = "UPDATE All_End_EzareBeShartTamlik SET S2_tarafgharardad=@S2_tarafgharardad ,S2_idkhodro1=@S2_idkhodro1 ,S2_idkhodro2=@S2_idkhodro2 ,s2_money=@s2_money ,S3_Daftarkhane=@S3_Daftarkhane WHERE (S1_idshobe = '" + id_idshobe + "') AND (S1_idmen = '" + id_idmen + "') AND (S1_rad = '" + id_Contract + "')";
                objCommand1.CommandType = CommandType.Text;

                objCommand1.Parameters.AddWithValue("@S2_tarafgharardad", comboBox3.Text);
                objCommand1.Parameters.AddWithValue("@S2_idkhodro1", textBox20.Text);
                objCommand1.Parameters.AddWithValue("@S2_idkhodro2", textBox21.Text);
                objCommand1.Parameters.AddWithValue("@s2_money", textBox1.Text);
                objCommand1.Parameters.AddWithValue("@S3_Daftarkhane", textBox2.Text);

                objConnection.Open();
                objCommand1.ExecuteNonQuery();
                objConnection.Close();

                u_set.u_amal_register("2", this.Title, id_Contract, "1", "ویرایش");

                MessageBox.Show("اطلاعات با موفقیت ویرایش شد", "", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            this.Hide();
        }

        private void comboBox1_DropDownClosed(object sender, EventArgs e)
        {
            textBox20.Text = comboBox1.SelectedValue.ToString();
            
            objDataSet1.Clear();
            Database.Connection_Open();
            Database.Fill("SELECT idkhodro, namekhodro FROM infonewall WHERE (idsherkat = '" + textBox20.Text + "') ORDER BY idkhodro", objDataSet1, "infonewall", true);
            Database.Connection_Close();

            comboBox2.DataContext = objDataSet1.Tables["infonewall"];
            comboBox2.DisplayMemberPath = "namekhodro";
            comboBox2.SelectedValuePath = "idkhodro";
        }

        private void comboBox2_DropDownClosed(object sender, EventArgs e)
        {
            if ((comboBox2.Items.Count > 0) && (comboBox2.SelectedIndex != -1))
                textBox21.Text = comboBox2.SelectedValue.ToString();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            CrystalReportWpf_AlborzAutomobile.Window1 f1 = new CrystalReportWpf_AlborzAutomobile.Window1();
            f1.Title = "قرارداد حق العمل کاری اجاره به شرط تملیک شماره : " + id_Contract;
            f1.selkar = "Crystal_Leasing_01_Haghol_Vekaleh"; 
            f1.id_Contract = id_Contract;
            f1.Show();
        }

        private void comboBox4_DropDownClosed(object sender, EventArgs e)
        {
            if ((comboBox4.Items.Count > 0) && (comboBox4.SelectedIndex != -1))
                textBox2.Text = comboBox4.SelectedValue.ToString();
        }

        private void textBox20_TextChanged(object sender, TextChangedEventArgs e)
        {
            comboBox1.SelectedValue = textBox20.Text;
        }

        private void textBox21_TextChanged(object sender, TextChangedEventArgs e)
        {
            comboBox2.SelectedValue = textBox21.Text;
        }

        private void textBox2_TextChanged(object sender, TextChangedEventArgs e)
        {
            comboBox4.SelectedValue = textBox2.Text;
        }

        private void comboBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "Return") { textBox20.Focus(); }
        }

        private void textBox20_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "Return") { comboBox1.Focus(); }
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "Return") { textBox21.Focus(); }
        }

        private void textBox21_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "Return") { comboBox2.Focus(); }
        }

        private void comboBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "Return") { textBox1.Focus(); }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "Return") { textBox2.Focus(); }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "Return") { comboBox4.Focus(); }
        }

        private void comboBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "Return") { button1.Focus(); }
        }
    }
}
