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
using System.Windows.Threading;

namespace AlborzAutomobile
{
    /// <summary>
    /// Interaction logic for Sell_Buy_01_Sabt.xaml
    /// </summary>
    public partial class Sell_Buy_01_Sabt : Window
    {
        SqlConnection objConnection = new SqlConnection(DB_Base.ConStr);
        SqlDataAdapter objDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();

        DB_Base Database = new DB_Base();
        U_Base u_set = new U_Base();

        public string selStatus;

        public string id_1_idshobe;
        public string id_2_idshobe;
        public string id_Contract;

        DispatcherTimer _timer;
        int amin1 = 1;

        public Sell_Buy_01_Sabt()
        {
            InitializeComponent();

            _timer = new DispatcherTimer();

            _timer.Tick += new EventHandler(delegate(object s, EventArgs a)
            {
                amin1 = amin1 * -1;
                if (amin1 > 0)
                    label19.Foreground = Brushes.Purple;
                else
                    label19.Foreground = Brushes.Yellow;
            });
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            button3.IsEnabled = false;

            Reg_Data_Amin();

            NewCar f1 = new NewCar();
            f1.Title = button3.Content.ToString() + " قرارداد شماره : " + id_Contract;
            f1.selkar = "5";
            f1.id_idshobe = id_1_idshobe;
            f1.id_Contract = id_Contract;
            f1.Show();
            this.Hide();

            button3.IsEnabled = true;
        }

        private void Reg_Data_Amin()
        {
            if (label6.Content.ToString() == "")
            {
                MessageBox.Show("لطفا فروشنده را انتخاب نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (label16.Content.ToString() == "")
            {
                MessageBox.Show("لطفا خریدار را انتخاب نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("لطفا نوع را انتخاب نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                comboBox1.Focus();
                return;
            }

            if (textBox7.Text == "")
            {
                MessageBox.Show("لطفا " + label25.Content + " را انتخاب نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                textBox7.Focus();
                return;
            }

            if (textBox8.Text == "")
            {
                MessageBox.Show("لطفا مبلغ را تکمیل نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                textBox8.Focus();
                return;
            }

            if (persianDatePicker1.Text == "")
            {
                MessageBox.Show("لطفا تاریخ را تکمیل نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                persianDatePicker1.Focus();
                return;
            }

            if (comboBox1.SelectedIndex >= 1)
            {
                if (comboBox2.SelectedIndex == -1)
                {
                    MessageBox.Show("لطفا بانک را انتخاب نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                    comboBox2.Focus();
                    return;
                }

                if (textBox9.Text == "")
                {
                    MessageBox.Show("لطفا شماره حساب را تکمیل نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                    textBox9.Focus();
                    return;
                }
            }

            if (selStatus == "New")
            {
                Database.Connection_Open();
                Database.Fill("SELECT ISNULL(MAX(id),0) AS rsmax FROM All_Sell_Buy", objDataSet, "All_Sell_Buy1", true);
                Database.Connection_Close();
                id_Contract = "4010" + (Convert.ToInt64(objDataSet.Tables["All_Sell_Buy1"].Rows[0]["rsmax"].ToString()) + 1).ToString();

                SqlCommand objCommand1 = new SqlCommand();
                objCommand1.Connection = objConnection;
                objCommand1.CommandText = "INSERT INTO All_Sell_Buy (idshobe,enseraf,rad,S1_idmen,S1_idmeli,S2_idmen,S2_idmeli,R_type,R_Number,R_money,R_date,R_bank,R_hesab) VALUES (@idshobe,@enseraf,@rad,@S1_idmen,@S1_idmeli,@S2_idmen,@S2_idmeli,@R_type,@R_Number,@R_money,@R_date,@R_bank,@R_hesab)";
                objCommand1.CommandType = CommandType.Text;

                objCommand1.Parameters.AddWithValue("@idshobe", id_1_idshobe);
                objCommand1.Parameters.AddWithValue("@enseraf", "ندارد");
                objCommand1.Parameters.AddWithValue("@rad", id_Contract);
                objCommand1.Parameters.AddWithValue("@S1_idmen", textBox2.Text);
                objCommand1.Parameters.AddWithValue("@S1_idmeli", textBox3.Text);
                objCommand1.Parameters.AddWithValue("@S2_idmen", textBox5.Text);
                objCommand1.Parameters.AddWithValue("@S2_idmeli", textBox6.Text);
                objCommand1.Parameters.AddWithValue("@R_type", comboBox1.Text);
                objCommand1.Parameters.AddWithValue("@R_Number", textBox7.Text);
                objCommand1.Parameters.AddWithValue("@R_money", Convert.ToDouble(textBox8.Text));
                objCommand1.Parameters.AddWithValue("@R_date", u_set.control_date_end(persianDatePicker1.Text));
                objCommand1.Parameters.AddWithValue("@R_bank", comboBox2.Text);
                objCommand1.Parameters.AddWithValue("@R_hesab", textBox9.Text);

                objConnection.Open();
                objCommand1.ExecuteNonQuery();
                objConnection.Close();

                u_set.u_amal_register("4", this.Title, id_Contract, "1", "جدید");

                MessageBox.Show("اطلاعات با موفقیت ثبت شد", "", MessageBoxButton.OK, MessageBoxImage.Information);
                selStatus = "Edit";

                _timer.Interval = TimeSpan.FromMilliseconds(80);
                _timer.Start();

                label19.Content = id_Contract;
                label19.Visibility = System.Windows.Visibility.Visible;
                label20.Visibility = System.Windows.Visibility.Visible;

                return;
            }

            if (selStatus == "Edit")
            {
                SqlCommand objCommand1 = new SqlCommand();
                objCommand1.Connection = objConnection;
                objCommand1.CommandText = "UPDATE All_Sell_Buy SET idshobe=@idshobe ,enseraf=@enseraf ,rad=@rad ,S1_idmen=@S1_idmen ,S1_idmeli=@S1_idmeli ,S2_idmen=@S2_idmen ,S2_idmeli=@S2_idmeli ,R_type=@R_type ,R_money=@R_money ,R_date=@R_date ,R_Number=@R_Number ,R_hesab=@R_hesab ,R_bank=@R_bank WHERE (rad = '" + id_Contract + "')";
                objCommand1.CommandType = CommandType.Text;

                objCommand1.Parameters.AddWithValue("@idshobe", id_1_idshobe);
                objCommand1.Parameters.AddWithValue("@enseraf", "ندارد");
                objCommand1.Parameters.AddWithValue("@rad", id_Contract);
                objCommand1.Parameters.AddWithValue("@S1_idmen", textBox2.Text);
                objCommand1.Parameters.AddWithValue("@S1_idmeli", textBox3.Text);
                objCommand1.Parameters.AddWithValue("@S2_idmen", textBox5.Text);
                objCommand1.Parameters.AddWithValue("@S2_idmeli", textBox6.Text);
                objCommand1.Parameters.AddWithValue("@R_type", comboBox1.Text);
                objCommand1.Parameters.AddWithValue("@R_Number", textBox7.Text);
                objCommand1.Parameters.AddWithValue("@R_money", Convert.ToDouble(textBox8.Text));
                objCommand1.Parameters.AddWithValue("@R_date", u_set.control_date_end(persianDatePicker1.Text));
                objCommand1.Parameters.AddWithValue("@R_bank", comboBox2.Text);
                objCommand1.Parameters.AddWithValue("@R_hesab", textBox9.Text);

                objConnection.Open();
                objCommand1.ExecuteNonQuery();
                objConnection.Close();

                u_set.u_amal_register("4", this.Title, id_Contract, "1", "ویرایش");

                MessageBox.Show("اطلاعات با موفقیت ویرایش شد", "", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            button1.IsEnabled = false;
            Reg_Data_Amin();
            button1.IsEnabled = true;
        }

        public void Alborz1_Selectmen()
        {
            if (((textBox1.Text != "") && (textBox2.Text != "")) && ((textBox1.Text != textBox4.Text) && (textBox2.Text != textBox5.Text)))
            {
                id_1_idshobe = textBox1.Text;

                Database.Connection_Open();
                Database.Fill("SELECT * FROM infomen WHERE (idmen = '" + textBox2.Text + "') AND (idshobe = '" + id_1_idshobe + "')", objDataSet, "ONE_All_Sell_Buy_1", true);
                Database.Connection_Close();

                if (objDataSet.Tables["ONE_All_Sell_Buy_1"].Rows.Count > 0)
                {
                    label4.Content = objDataSet.Tables["ONE_All_Sell_Buy_1"].Rows[0]["name"].ToString();
                    label6.Content = objDataSet.Tables["ONE_All_Sell_Buy_1"].Rows[0]["family"].ToString();
                    label9.Content = objDataSet.Tables["ONE_All_Sell_Buy_1"].Rows[0]["shsh"].ToString();
                    textBox3.Text = objDataSet.Tables["ONE_All_Sell_Buy_1"].Rows[0]["id"].ToString();
                }

                objDataSet.Clear();
                return;
            }
        }

        public void Alborz2_Selectmen()
        {
            if ((textBox3.Text != "") && (textBox3.Text != textBox6.Text))
            {
                Database.Connection_Open();
                Database.Fill("SELECT * FROM infomen WHERE (id = '" + textBox3.Text + "')", objDataSet, "ONE_All_Sell_Buy_1", true);
                Database.Connection_Close();

                if (objDataSet.Tables["ONE_All_Sell_Buy_1"].Rows.Count > 0)
                {
                    id_1_idshobe = objDataSet.Tables["ONE_All_Sell_Buy_1"].Rows[0]["idshobe"].ToString();
                    textBox1.Text = id_1_idshobe;

                    label4.Content = objDataSet.Tables["ONE_All_Sell_Buy_1"].Rows[0]["name"].ToString();
                    label6.Content = objDataSet.Tables["ONE_All_Sell_Buy_1"].Rows[0]["family"].ToString();
                    label9.Content = objDataSet.Tables["ONE_All_Sell_Buy_1"].Rows[0]["shsh"].ToString();
                    textBox2.Text = objDataSet.Tables["ONE_All_Sell_Buy_1"].Rows[0]["idmen"].ToString();
                }

                objDataSet.Clear();
                return;
            }
        }

        public void Alborz3_Selectmen()
        {
            if (((textBox4.Text != "") && (textBox5.Text != "")) && ((textBox1.Text != textBox4.Text) && (textBox2.Text != textBox5.Text)))
            {
                id_2_idshobe = textBox4.Text;

                Database.Connection_Open();
                Database.Fill("SELECT * FROM infomen WHERE (idmen = '" + textBox5.Text + "') AND (idshobe = '" + id_2_idshobe + "')", objDataSet, "ONE_All_Sell_Buy_2", true);
                Database.Connection_Close();

                if (objDataSet.Tables["ONE_All_Sell_Buy_2"].Rows.Count > 0)
                {
                    label14.Content = objDataSet.Tables["ONE_All_Sell_Buy_2"].Rows[0]["name"].ToString();
                    label16.Content = objDataSet.Tables["ONE_All_Sell_Buy_2"].Rows[0]["family"].ToString();
                    label18.Content = objDataSet.Tables["ONE_All_Sell_Buy_2"].Rows[0]["shsh"].ToString();
                    textBox6.Text = objDataSet.Tables["ONE_All_Sell_Buy_2"].Rows[0]["id"].ToString();
                }

                objDataSet.Clear();
                return;
            }
        }

        public void Alborz4_Selectmen()
        {
            if ((textBox6.Text != "") && (textBox3.Text != textBox6.Text))
            {
                Database.Connection_Open();
                Database.Fill("SELECT * FROM infomen WHERE (id = '" + textBox6.Text + "')", objDataSet, "ONE_All_Sell_Buy_2", true);
                Database.Connection_Close();

                if (objDataSet.Tables["ONE_All_Sell_Buy_2"].Rows.Count > 0)
                {
                    id_1_idshobe = objDataSet.Tables["ONE_All_Sell_Buy_2"].Rows[0]["idshobe"].ToString();
                    textBox4.Text = id_1_idshobe;

                    label14.Content = objDataSet.Tables["ONE_All_Sell_Buy_2"].Rows[0]["name"].ToString();
                    label16.Content = objDataSet.Tables["ONE_All_Sell_Buy_2"].Rows[0]["family"].ToString();
                    label18.Content = objDataSet.Tables["ONE_All_Sell_Buy_2"].Rows[0]["shsh"].ToString();
                    textBox5.Text = objDataSet.Tables["ONE_All_Sell_Buy_2"].Rows[0]["idmen"].ToString();
                }

                objDataSet.Clear();
                return;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            comboBox1.Items.Add("نقدی");
            comboBox1.Items.Add("فیش");
            comboBox1.Items.Add("چک");

            comboBox2.Items.Add("ملی");
            comboBox2.Items.Add("ملت");
            comboBox2.Items.Add("صادرات");
            comboBox2.Items.Add("سپه");
            comboBox2.Items.Add("تجارت");
            comboBox2.Items.Add("پارسیان");
            comboBox2.Items.Add("بانک شهر");

            textBox1.Text = id_1_idshobe;
            textBox4.Text = id_2_idshobe;

            if (selStatus == "Edit")
            {
                Database.Connection_Open();
                Database.Fill("SELECT * FROM All_Sell_Buy WHERE (rad = '" + id_Contract + "')", objDataSet, "All_Sell_Buy_Enter_Data", true);
                Database.Connection_Close();

                if (objDataSet.Tables["All_Sell_Buy_Enter_Data"].Rows.Count > 0)
                {
                    textBox7.Text = objDataSet.Tables["All_Sell_Buy_Enter_Data"].Rows[0]["R_Number"].ToString();
                    textBox8.Text = Convert.ToDouble(objDataSet.Tables["All_Sell_Buy_Enter_Data"].Rows[0]["R_money"].ToString()).ToString();

                    persianDatePicker1.Text = objDataSet.Tables["All_Sell_Buy_Enter_Data"].Rows[0]["R_date"].ToString();
                    comboBox2.Text = objDataSet.Tables["All_Sell_Buy_Enter_Data"].Rows[0]["R_bank"].ToString();
                    textBox9.Text = objDataSet.Tables["All_Sell_Buy_Enter_Data"].Rows[0]["R_hesab"].ToString();
                    comboBox1.Text = objDataSet.Tables["All_Sell_Buy_Enter_Data"].Rows[0]["R_type"].ToString();

                    string q1 = objDataSet.Tables["All_Sell_Buy_Enter_Data"].Rows[0]["S1_idmeli"].ToString();
                    string q2 = objDataSet.Tables["All_Sell_Buy_Enter_Data"].Rows[0]["S2_idmeli"].ToString();

                    textBox3.Text = q1;
                    textBox6.Text = q2;
                }
            }
        }

        private void textBox2_TextChanged(object sender, TextChangedEventArgs e)
        {
            Alborz1_Selectmen();
        }

        private void textBox3_TextChanged(object sender, TextChangedEventArgs e)
        {
            Alborz2_Selectmen();
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "Return") { Alborz1_Selectmen(); }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "Return") { Alborz2_Selectmen(); }
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "Return") { Alborz3_Selectmen(); }
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "Return") { Alborz4_Selectmen(); }
        }

        private void textBox5_TextChanged(object sender, TextChangedEventArgs e)
        {
            Alborz3_Selectmen();
        }

        private void textBox6_TextChanged(object sender, TextChangedEventArgs e)
        {
            Alborz4_Selectmen();
        }

        private void comboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBox1.SelectedIndex.ToString() == "0")
            {
                label25.Content = "صندوق";

                label21.Visibility = System.Windows.Visibility.Hidden;
                label22.Visibility = System.Windows.Visibility.Hidden;

                comboBox2.Visibility = System.Windows.Visibility.Hidden;
                textBox9.Visibility = System.Windows.Visibility.Hidden;
            }
            else if (comboBox1.SelectedIndex.ToString() == "1")
            {
                label25.Content = "شماره فیش";

                label21.Visibility = System.Windows.Visibility.Visible;
                label22.Visibility = System.Windows.Visibility.Visible;

                comboBox2.Visibility = System.Windows.Visibility.Visible;
                textBox9.Visibility = System.Windows.Visibility.Visible;
            }
            else if (comboBox1.SelectedIndex.ToString() == "2")
            {
                label25.Content = "شماره چک";

                label21.Visibility = System.Windows.Visibility.Visible;
                label22.Visibility = System.Windows.Visibility.Visible;

                comboBox2.Visibility = System.Windows.Visibility.Visible;
                textBox9.Visibility = System.Windows.Visibility.Visible;
            }
        }
    }
}
