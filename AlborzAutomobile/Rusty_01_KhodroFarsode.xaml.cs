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
    /// Interaction logic for Rusty_01_KhodroFarsode.xaml
    /// </summary>
    public partial class Rusty_01_KhodroFarsode : Window
    {
        SqlConnection objConnection = new SqlConnection(DB_Base.ConStr);
        SqlDataAdapter objDataAdapter = new SqlDataAdapter();

        DataSet objDataSet = new DataSet();
        DataSet objDataSet1 = new DataSet();
        DataSet objDataSet2 = new DataSet();

        DB_Base Database = new DB_Base();
        U_Base u_set = new U_Base();
        U_Color_set u_color = new U_Color_set();

        public string selStatus;

        public string id_idshobe;
        public string id_idmen;
        public string id_Contract;
        public string id_idmelli;

        DispatcherTimer _timer;
        int amin1 = 1;

        public Rusty_01_KhodroFarsode()
        {
            InitializeComponent();

            _timer = new DispatcherTimer();

            _timer.Tick += new EventHandler(delegate(object s, EventArgs a)
            {
                amin1 = amin1 * -1;
                if (amin1 > 0)
                    label15.Foreground = Brushes.Purple;
                else
                    label15.Foreground = Brushes.Yellow;
            });
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LinearGradientBrush myBrush = new LinearGradientBrush();
            myBrush.StartPoint = new Point(0.5, 0);
            myBrush.EndPoint = new Point(0.5, 1);
            myBrush.GradientStops.Add(new GradientStop(Colors.DarkGoldenrod, 0.0));
            myBrush.GradientStops.Add(new GradientStop(Colors.Gold, 1.0));

            button1.Background = myBrush;

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

            objDataSet1.Clear();

            Database.Connection_Open();
            Database.Fill("SELECT idsherkat,namesherkat FROM infonewall GROUP by idsherkat,namesherkat ORDER BY idsherkat", objDataSet1, "infonewall", true);
            Database.Connection_Close();

            comboBox1.DataContext = objDataSet1.Tables["infonewall"];
            comboBox1.DisplayMemberPath = "namesherkat";
            comboBox1.SelectedValuePath = "idsherkat";

            Database.Connection_Open();
            Database.Fill("SELECT namemarkaz,rad FROM Daftar ORDER BY rad", objDataSet1, "Daftar", true);
            Database.Connection_Close();

            comboBox4.DataContext = objDataSet1.Tables["Daftar"];
            comboBox4.DisplayMemberPath = "namemarkaz";
            comboBox4.SelectedValuePath = "rad";

            Database.Connection_Open();
            Database.Fill("SELECT name,tmpid FROM Tbl_Rusty_Khodro ORDER BY name", objDataSet1, "Tbl_Rusty_Khodro", true);
            Database.Connection_Close();

            comboBox5.DataContext = objDataSet1.Tables["Tbl_Rusty_Khodro"];
            comboBox5.DisplayMemberPath = "name";
            comboBox5.SelectedValuePath = "tmpid";


            for (int q = 1330; q <= 1366; q++)
            {
                comboBox6.Items.Add(q.ToString());
            }

            for (int q = 1950; q <= 1986; q++)
            {
                comboBox6.Items.Add(q.ToString());
            }

            if (selStatus == "Edit")
            {
                label15.Content = id_Contract;
                Database.Connection_Open();
                Database.Fill("SELECT * FROM All_End_Farsode WHERE (S1_idshobe = '" + id_idshobe + "') AND (S1_idmen = '" + id_idmen + "') AND (S1_rad = '" + id_Contract + "')", objDataSet, "All_End_Farsode", true);
                Database.Connection_Close();

                if (objDataSet.Tables["All_End_Farsode"].Rows.Count > 0)
                {
                    if (objDataSet.Tables["All_End_Farsode"].Rows[0]["S4_1_1"].ToString() == "1")
                        checkBox1.IsChecked = true;
                    else
                        checkBox1.IsChecked = false;

                    if (objDataSet.Tables["All_End_Farsode"].Rows[0]["S4_1_5"].ToString() == "1")
                        checkBox2.IsChecked = true;
                    else
                        checkBox2.IsChecked = false;

                    if (objDataSet.Tables["All_End_Farsode"].Rows[0]["S4_1_2"].ToString() == "1")
                        checkBox3.IsChecked = true;
                    else
                        checkBox3.IsChecked = false;

                    if (objDataSet.Tables["All_End_Farsode"].Rows[0]["S4_1_6"].ToString() == "1")
                        checkBox4.IsChecked = true;
                    else
                        checkBox4.IsChecked = false;

                    if (objDataSet.Tables["All_End_Farsode"].Rows[0]["S4_1_3"].ToString() == "1")
                        checkBox5.IsChecked = true;
                    else
                        checkBox5.IsChecked = false;

                    if (objDataSet.Tables["All_End_Farsode"].Rows[0]["S4_1_7"].ToString() == "1")
                        checkBox6.IsChecked = true;
                    else
                        checkBox6.IsChecked = false;

                    if (objDataSet.Tables["All_End_Farsode"].Rows[0]["S4_1_8"].ToString() == "1")
                        checkBox7.IsChecked = true;
                    else
                        checkBox7.IsChecked = false;

                    if (objDataSet.Tables["All_End_Farsode"].Rows[0]["S4_1_4"].ToString() == "1")
                        checkBox8.IsChecked = true;
                    else
                        checkBox8.IsChecked = false;

                    string myStr = objDataSet.Tables["All_End_Farsode"].Rows[0]["S3_Daftarkhane"].ToString();
                    int myInt = int.MinValue;

                    if (!int.TryParse(myStr, out myInt))
                        textBox23.Text = "";
                    else
                        textBox23.Text = myStr;
                }

                Database.Connection_Open();
                Database.Fill("SELECT * FROM infokhodro WHERE (idshobe = '" + id_idshobe + "') AND (idkhodro = '" + id_idmelli + "') AND (S1_rad = '" + id_Contract + "')", objDataSet, "infokhodro", true);
                Database.Connection_Close();

                if (objDataSet.Tables["infokhodro"].Rows.Count > 0)
                {
                    textBox1.Text = objDataSet.Tables["infokhodro"].Rows[0]["shmotor"].ToString();
                    comboBox3.Text = objDataSet.Tables["infokhodro"].Rows[0]["nokarbari"].ToString();
                    comboBox7.Text = objDataSet.Tables["infokhodro"].Rows[0]["numberdeff"].ToString();

                    string myStr1 = objDataSet.Tables["infokhodro"].Rows[0]["nokhodro"].ToString();
                    int myInt1 = int.MinValue;

                    if (!int.TryParse(myStr1, out myInt1))
                        comboBox5.SelectedValue = -1;
                    else
                        comboBox5.SelectedValue = objDataSet.Tables["infokhodro"].Rows[0]["nokhodro"].ToString();

                    textBox5.Text = objDataSet.Tables["infokhodro"].Rows[0]["shshasi"].ToString();
                    comboBox6.Text = objDataSet.Tables["infokhodro"].Rows[0]["model"].ToString();
                    comboBox8.Text = objDataSet.Tables["infokhodro"].Rows[0]["numbersilandr"].ToString();
                    textBox8.Text = objDataSet.Tables["infokhodro"].Rows[0]["S2_money"].ToString();
                    textBox9.Text = objDataSet.Tables["infokhodro"].Rows[0]["idvin"].ToString();
                    textBox10.Text = objDataSet.Tables["infokhodro"].Rows[0]["shsokhtcard"].ToString();

                    textBox11.Text = objDataSet.Tables["infokhodro"].Rows[0]["p1_1"].ToString();
                    textBox12.Text = objDataSet.Tables["infokhodro"].Rows[0]["p1_2"].ToString();
                    textBox13.Text = objDataSet.Tables["infokhodro"].Rows[0]["p1_3"].ToString();
                    textBox14.Text = objDataSet.Tables["infokhodro"].Rows[0]["p1_4"].ToString();
                    if (textBox11.Text != "-")
                        expander1.IsExpanded = true;

                    textBox15.Text = objDataSet.Tables["infokhodro"].Rows[0]["p2_1"].ToString();
                    textBox16.Text = objDataSet.Tables["infokhodro"].Rows[0]["p2_2"].ToString();
                    textBox17.Text = objDataSet.Tables["infokhodro"].Rows[0]["p2_3"].ToString();
                    if (textBox15.Text != "-")
                        expander2.IsExpanded = true;

                    textBox18.Text = objDataSet.Tables["infokhodro"].Rows[0]["p3_1"].ToString();
                    textBox19.Text = objDataSet.Tables["infokhodro"].Rows[0]["p3_2"].ToString();
                    if (textBox18.Text != "-")
                        expander3.IsExpanded = true;

                    if (objDataSet.Tables["infokhodro"].Rows[0]["nahkharid"].ToString() == "جايگزين")
                    {
                        radioButton1.IsChecked = true;

                        if (objDataSet.Tables["infokhodro"].Rows[0]["nodarkhast"].ToString() == "نقد")
                        {
                            radioButton4.IsChecked = true;
                        }
                        else
                        {
                            radioButton3.IsChecked = true;
                        }

                        textBox20.Text = objDataSet.Tables["infokhodro"].Rows[0]["S2_idkhodro1"].ToString();

                        objDataSet2.Clear();
                        Database.Connection_Open();
                        Database.Fill("SELECT idkhodro, namekhodro FROM infonewall WHERE (idsherkat = '" + textBox20.Text + "') ORDER BY idkhodro", objDataSet2, "infonewall", true);
                        Database.Connection_Close();

                        comboBox2.DataContext = objDataSet2.Tables["infonewall"];
                        comboBox2.DisplayMemberPath = "namekhodro";
                        comboBox2.SelectedValuePath = "idkhodro";

                        textBox21.Text = objDataSet.Tables["infokhodro"].Rows[0]["S2_idkhodro2"].ToString();
                    }
                    else
                    {
                        radioButton2.IsChecked = true;
                        textBox22.Text = objDataSet.Tables["infokhodro"].Rows[0]["S2_money1"].ToString();
                    }
                }

                button3.Visibility = System.Windows.Visibility.Visible;
                button4.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (comboBox5.SelectedIndex == -1)
            {
                MessageBox.Show("لطفا سیستم را انتخاب نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                comboBox5.Focus();
                return;
            }

            if (comboBox3.SelectedIndex == -1)
            {
                MessageBox.Show("لطفا نوع کاربری را انتخاب نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                comboBox3.Focus();
                return;
            }

            if (comboBox7.SelectedIndex == -1)
            {
                MessageBox.Show("لطفا تعداد دیفرانسیل را انتخاب نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                comboBox7.Focus();
                return;
            }

            if (textBox1.Text == "")
            {
                MessageBox.Show("لطفا شماره موتور را تکمیل نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                textBox1.Focus();
                return;
            }

            if (textBox5.Text == "")
            {
                MessageBox.Show("لطفا شماره شاسی را تکمیل نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                textBox5.Focus();
                return;
            }

            if (comboBox6.SelectedIndex == -1)
            {
                MessageBox.Show("لطفا مدل را انتخاب نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                comboBox6.Focus();
                return;
            }

            if (comboBox8.SelectedIndex == -1)
            {
                MessageBox.Show("لطفا تعداد سیلندر را انتخاب نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                comboBox8.Focus();
                return;
            }

            if (textBox8.Text == "")
            {
                MessageBox.Show("لطفا مبلغ حق العمل کاری را تکمیل نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                textBox8.Focus();
                return;
            }

            if (Convert.ToInt32(textBox8.Text) < 4000000)
            {
                MessageBox.Show("لطفا مبلغ حق العمل کاری را صحیح وارد نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                textBox8.Focus();
                return;
            }

            if (textBox9.Text == "")
            {
                MessageBox.Show("لطفا شماره وین را تکمیل نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                textBox9.Focus();
                return;
            }

            if (textBox10.Text == "")
            {
                MessageBox.Show("لطفا رنگ خودرو را تکمیل نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                textBox10.Focus();
                return;
            }

            if (textBox11.Text == "")
            {
                MessageBox.Show("لطفا شماره انتظامی ملی را تکمیل نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                textBox11.Focus();
                return;
            }

            if (textBox12.Text == "")
            {
                MessageBox.Show("لطفا شماره انتظامی ملی را تکمیل نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                textBox12.Focus();
                return;
            }

            if (textBox13.Text == "")
            {
                MessageBox.Show("لطفا شماره انتظامی ملی را تکمیل نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                textBox13.Focus();
                return;
            }

            if (textBox14.Text == "")
            {
                MessageBox.Show("لطفا شماره انتظامی ملی را تکمیل نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                textBox13.Focus();
                return;
            }

            if (textBox15.Text == "")
            {
                MessageBox.Show("لطفا شماره انتظامی عددی یا حروف را تکمیل نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                textBox15.Focus();
                return;
            }

            if (textBox16.Text == "")
            {
                MessageBox.Show("لطفا شماره انتظامی عددی یا حروف را تکمیل نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                textBox16.Focus();
                return;
            }

            if (textBox17.Text == "")
            {
                MessageBox.Show("لطفا شماره انتظامی عددی یا حروف را تکمیل نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                textBox17.Focus();
                return;
            }

            if (textBox18.Text == "")
            {
                MessageBox.Show("لطفا شماره انتظامی قدیمی را تکمیل نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                textBox18.Focus();
                return;
            }

            if (textBox19.Text == "")
            {
                MessageBox.Show("لطفا شماره انتظامی قدیمی را تکمیل نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                textBox19.Focus();
                return;
            }

            if (comboBox4.SelectedIndex == -1)
            {
                MessageBox.Show("لطفا دفتر خانه را انتخاب نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                comboBox4.Focus();
                return;
            }

            if (checkBox1.IsChecked == false) 
                if (checkBox2.IsChecked == false) 
                    if (checkBox3.IsChecked == false) 
                        if (checkBox4.IsChecked == false) 
                            if (checkBox5.IsChecked == false) 
                                if (checkBox6.IsChecked == false) 
                                    if  (checkBox7.IsChecked == false)
                                        if (checkBox8.IsChecked == false)
                                        {
                                            MessageBox.Show("شما حتما باید یکی از موارد مدارک را انتخاب نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                                            return;
                                        }

            if (radioButton1.IsChecked == true)
            {
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
            }
            else
            {
                if (textBox22.Text == "")
                {
                    MessageBox.Show("لطفا مبلغ قرارداد را تکمیل نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                    textBox22.Focus();
                    return;
                }

                if (Convert.ToInt64(textBox22.Text) > 8000000)
                {
                    MessageBox.Show("لطفا مبلغ قرارداد را صحیح وارد نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                    textBox22.Focus();
                    return;
                }
            }

            button1.IsEnabled = false;

            if (selStatus == "New")
            {
                Database.Connection_Open();
                Database.Fill("SELECT * FROM infokhodro WHERE (shmotor = '"+textBox1.Text+"')", objDataSet, "test_khodro_1", true);
                Database.Connection_Close();

                if (objDataSet.Tables["test_khodro_1"].Rows.Count > 0)
                {
                    MessageBox.Show("این شماره موتور برای خودرو دیگری ثبت شده است", "", MessageBoxButton.OK, MessageBoxImage.Error);
                    textBox1.Focus();
                    button1.IsEnabled = true;
                    return;
                }

                Database.Connection_Open();
                Database.Fill("SELECT * FROM infokhodro WHERE (shshasi = '" + textBox5.Text + "')", objDataSet, "test_khodro_2", true);
                Database.Connection_Close();

                if (objDataSet.Tables["test_khodro_2"].Rows.Count > 0)
                {
                    MessageBox.Show("این شماره شانسی برای خودرو دیگری ثبت شده است", "", MessageBoxButton.OK, MessageBoxImage.Error);
                    textBox5.Focus();
                    button1.IsEnabled = true;
                    return;
                }

                Database.Connection_Open();
                Database.Fill("SELECT ISNULL(MAX(id),0) AS rsmax FROM All_End_Farsode", objDataSet, "All_End_Farsode1", true);
                Database.Connection_Close();
                label15.Content = "2010" + (Convert.ToInt64(objDataSet.Tables["All_End_Farsode1"].Rows[0]["rsmax"].ToString()) + 1).ToString();
                id_Contract = label15.Content.ToString();

                SqlCommand objCommand1 = new SqlCommand();
                objCommand1.Connection = objConnection;
                objCommand1.CommandText = "INSERT INTO All_End_Farsode (S1_idmen,S1_idmeli,S1_rad,S1_idshobe,s1_enseraf,S4_1_1,S4_1_2,S4_1_3,S4_1_4,S4_1_5,S4_1_6,S4_1_7,S4_1_8,S4_1_9,S3_Daftarkhane) VALUES (@S1_idmen,@S1_idmeli,@S1_rad,@S1_idshobe,@s1_enseraf,@S4_1_1,@S4_1_2,@S4_1_3,@S4_1_4,@S4_1_5,@S4_1_6,@S4_1_7,@S4_1_8,@S4_1_9,@S3_Daftarkhane)";
                objCommand1.CommandType = CommandType.Text;

                objCommand1.Parameters.AddWithValue("@S1_rad", id_Contract);
                objCommand1.Parameters.AddWithValue("@S1_idmen", id_idmen);
                objCommand1.Parameters.AddWithValue("@S1_idmeli", id_idmelli);
                objCommand1.Parameters.AddWithValue("@S1_idshobe", id_idshobe);
                objCommand1.Parameters.AddWithValue("@s1_enseraf", "ندارد");

                if (checkBox1.IsChecked == true)
                    objCommand1.Parameters.AddWithValue("@S4_1_1", "1");
                else
                    objCommand1.Parameters.AddWithValue("@S4_1_1", "0");

                if (checkBox2.IsChecked == true)
                    objCommand1.Parameters.AddWithValue("@S4_1_2", "1");
                else
                    objCommand1.Parameters.AddWithValue("@S4_1_2", "0");

                if (checkBox3.IsChecked == true)
                    objCommand1.Parameters.AddWithValue("@S4_1_3", "1");
                else
                    objCommand1.Parameters.AddWithValue("@S4_1_3", "0");

                if (checkBox4.IsChecked == true)
                    objCommand1.Parameters.AddWithValue("@S4_1_4", "1");
                else
                    objCommand1.Parameters.AddWithValue("@S4_1_4", "0");

                if (checkBox5.IsChecked == true)
                    objCommand1.Parameters.AddWithValue("@S4_1_5", "1");
                else
                    objCommand1.Parameters.AddWithValue("@S4_1_5", "0");

                if (checkBox6.IsChecked == true)
                    objCommand1.Parameters.AddWithValue("@S4_1_6", "1");
                else
                    objCommand1.Parameters.AddWithValue("@S4_1_6", "0");

                if (checkBox7.IsChecked == true)
                    objCommand1.Parameters.AddWithValue("@S4_1_7", "1");
                else
                    objCommand1.Parameters.AddWithValue("@S4_1_7", "0");

                if (checkBox8.IsChecked == true)
                    objCommand1.Parameters.AddWithValue("@S4_1_8", "1");
                else
                    objCommand1.Parameters.AddWithValue("@S4_1_8", "0");

                objCommand1.Parameters.AddWithValue("@S4_1_9", u_set.u_date());

                objCommand1.Parameters.AddWithValue("@S3_Daftarkhane", textBox23.Text);

                objConnection.Open();
                objCommand1.ExecuteNonQuery();
                objConnection.Close();


                SqlCommand objCommand2 = new SqlCommand();
                objCommand2.Connection = objConnection;
                objCommand2.CommandText = "INSERT INTO infokhodro (idshobe,idkhodro,S1_rad,shmotor,nokarbari,numberdeff,nokhodro,shshasi,model,numbersilandr,S2_money,idvin,shsokhtcard,p1_1,p1_2,p1_3,p1_4,p2_1,p2_2,p2_3,p3_1,p3_2,nahkharid,nodarkhast,S2_idkhodro1,S2_idkhodro2,S2_money1,udate) VALUES (@idshobe,@idkhodro,@S1_rad,@shmotor,@nokarbari,@numberdeff,@nokhodro,@shshasi,@model,@numbersilandr,@S2_money,@idvin,@shsokhtcard,@p1_1,@p1_2,@p1_3,@p1_4,@p2_1,@p2_2,@p2_3,@p3_1,@p3_2,@nahkharid,@nodarkhast,@S2_idkhodro1,@S2_idkhodro2,@S2_money1,@udate)";
                objCommand2.CommandType = CommandType.Text;

                objCommand2.Parameters.AddWithValue("@idshobe", id_idshobe);
                objCommand2.Parameters.AddWithValue("@idkhodro", id_idmelli);
                objCommand2.Parameters.AddWithValue("@S1_rad", id_Contract);
                objCommand2.Parameters.AddWithValue("@shmotor", textBox1.Text);
                objCommand2.Parameters.AddWithValue("@nokarbari", comboBox3.Text);
                objCommand2.Parameters.AddWithValue("@numberdeff", comboBox7.Text);
                objCommand2.Parameters.AddWithValue("@nokhodro", comboBox5.SelectedValue);
                objCommand2.Parameters.AddWithValue("@shshasi", textBox5.Text);
                objCommand2.Parameters.AddWithValue("@model", comboBox6.Text);
                objCommand2.Parameters.AddWithValue("@numbersilandr", comboBox8.Text);
                objCommand2.Parameters.AddWithValue("@S2_money", textBox8.Text);
                objCommand2.Parameters.AddWithValue("@idvin", textBox9.Text);
                objCommand2.Parameters.AddWithValue("@shsokhtcard", textBox10.Text);
                objCommand2.Parameters.AddWithValue("@p1_1", textBox11.Text);
                objCommand2.Parameters.AddWithValue("@p1_2", textBox12.Text);
                objCommand2.Parameters.AddWithValue("@p1_3", textBox13.Text);
                objCommand2.Parameters.AddWithValue("@p1_4", textBox14.Text);
                objCommand2.Parameters.AddWithValue("@p2_1", textBox15.Text);
                objCommand2.Parameters.AddWithValue("@p2_2", textBox16.Text);
                objCommand2.Parameters.AddWithValue("@p2_3", textBox17.Text);
                objCommand2.Parameters.AddWithValue("@p3_1", textBox18.Text);
                objCommand2.Parameters.AddWithValue("@p3_2", textBox19.Text);
                objCommand2.Parameters.AddWithValue("@udate", u_set.u_date());

                if (radioButton1.IsChecked == true)
                {
                    objCommand2.Parameters.AddWithValue("@nahkharid", "جايگزين");

                    if (radioButton4.IsChecked == true)
                        objCommand2.Parameters.AddWithValue("@nodarkhast", "نقد");
                    else
                        objCommand2.Parameters.AddWithValue("@nodarkhast", "اجاره به شرط تمليک");

                    objCommand2.Parameters.AddWithValue("@S2_idkhodro1", textBox20.Text);
                    objCommand2.Parameters.AddWithValue("@S2_idkhodro2", textBox21.Text);

                    objCommand2.Parameters.AddWithValue("@S2_money1", 0);
                }
                else
                {
                    objCommand2.Parameters.AddWithValue("@nahkharid", "وجه نقد");

                    objCommand2.Parameters.AddWithValue("@nodarkhast", "-");
                    objCommand2.Parameters.AddWithValue("@S2_idkhodro1", 0);
                    objCommand2.Parameters.AddWithValue("@S2_idkhodro2", 0);

                    objCommand2.Parameters.AddWithValue("@S2_money1", Convert.ToDecimal(textBox22.Text));
                }

                objConnection.Open();
                objCommand2.ExecuteNonQuery();
                objConnection.Close();


                u_set.u_amal_register("1", this.Title, id_Contract, "1", "جدید");

                MessageBox.Show("اطلاعات با موفقیت ثبت شد", "", MessageBoxButton.OK, MessageBoxImage.Information);
                selStatus = "Edit";

                _timer.Interval = TimeSpan.FromMilliseconds(80);
                _timer.Start();

                label15.Visibility = System.Windows.Visibility.Visible;
                label16.Visibility = System.Windows.Visibility.Visible;

                button3.Visibility = System.Windows.Visibility.Visible;
                button4.Visibility = System.Windows.Visibility.Visible;

                button1.IsEnabled = true;
                return;
            }

            if (selStatus == "Edit")
            {
                SqlCommand objCommand1 = new SqlCommand();
                objCommand1.Connection = objConnection;
                objCommand1.CommandText = "UPDATE infokhodro SET idshobe=@idshobe ,idkhodro=@idkhodro ,S1_rad=@S1_rad ,shmotor=@shmotor ,nokarbari=@nokarbari ,numberdeff=@numberdeff ,nokhodro=@nokhodro ,shshasi=@shshasi ,model=@model ,numbersilandr=@numbersilandr ,S2_money=@S2_money ,idvin=@idvin ,shsokhtcard=@shsokhtcard ,p1_1=@p1_1 ,p1_2=@p1_2 ,p1_3=@p1_3 ,p1_4=@p1_4 ,p2_1=@p2_1 ,p2_2=@p2_2 ,p2_3=@p2_3 ,p3_1=@p3_1 ,p3_2=@p3_2 ,nahkharid=@nahkharid ,nodarkhast=@nodarkhast ,S2_idkhodro1=@S2_idkhodro1 ,S2_idkhodro2=@S2_idkhodro2 ,S2_money1=@S2_money1 ,udate=@udate  WHERE (S1_rad = '" + id_Contract + "')";
                objCommand1.CommandType = CommandType.Text;

                objCommand1.Parameters.AddWithValue("@idshobe", id_idshobe);
                objCommand1.Parameters.AddWithValue("@idkhodro", id_idmelli);
                objCommand1.Parameters.AddWithValue("@S1_rad", id_Contract);
                objCommand1.Parameters.AddWithValue("@shmotor", textBox1.Text);
                objCommand1.Parameters.AddWithValue("@nokarbari", comboBox3.Text);
                objCommand1.Parameters.AddWithValue("@numberdeff", comboBox7.Text);
                objCommand1.Parameters.AddWithValue("@nokhodro", comboBox5.SelectedValue);
                objCommand1.Parameters.AddWithValue("@shshasi", textBox5.Text);
                objCommand1.Parameters.AddWithValue("@model", comboBox6.Text);
                objCommand1.Parameters.AddWithValue("@numbersilandr", comboBox8.Text);
                objCommand1.Parameters.AddWithValue("@S2_money", textBox8.Text);
                objCommand1.Parameters.AddWithValue("@idvin", textBox9.Text);
                objCommand1.Parameters.AddWithValue("@shsokhtcard", textBox10.Text);
                objCommand1.Parameters.AddWithValue("@p1_1", textBox11.Text);
                objCommand1.Parameters.AddWithValue("@p1_2", textBox12.Text);
                objCommand1.Parameters.AddWithValue("@p1_3", textBox13.Text);
                objCommand1.Parameters.AddWithValue("@p1_4", textBox14.Text);
                objCommand1.Parameters.AddWithValue("@p2_1", textBox15.Text);
                objCommand1.Parameters.AddWithValue("@p2_2", textBox16.Text);
                objCommand1.Parameters.AddWithValue("@p2_3", textBox17.Text);
                objCommand1.Parameters.AddWithValue("@p3_1", textBox18.Text);
                objCommand1.Parameters.AddWithValue("@p3_2", textBox19.Text);
                objCommand1.Parameters.AddWithValue("@udate", u_set.u_date());

                if (radioButton1.IsChecked == true)
                {
                    objCommand1.Parameters.AddWithValue("@nahkharid", "جايگزين");

                    if (radioButton4.IsChecked == true)
                        objCommand1.Parameters.AddWithValue("@nodarkhast", "نقد");
                    else
                        objCommand1.Parameters.AddWithValue("@nodarkhast", "اجاره به شرط تمليک");

                    objCommand1.Parameters.AddWithValue("@S2_idkhodro1", textBox20.Text);
                    objCommand1.Parameters.AddWithValue("@S2_idkhodro2", textBox21.Text);

                    objCommand1.Parameters.AddWithValue("@S2_money1", 0);
                }
                else
                {
                    objCommand1.Parameters.AddWithValue("@nahkharid", "وجه نقد");

                    objCommand1.Parameters.AddWithValue("@nodarkhast", "-");
                    objCommand1.Parameters.AddWithValue("@S2_idkhodro1", 0);
                    objCommand1.Parameters.AddWithValue("@S2_idkhodro2", 0);

                    objCommand1.Parameters.AddWithValue("@S2_money1", Convert.ToDecimal(textBox22.Text));
                }

                objConnection.Open();
                objCommand1.ExecuteNonQuery();
                objConnection.Close();

                SqlCommand objCommand2 = new SqlCommand();
                objCommand2.Connection = objConnection;
                objCommand2.CommandText = "UPDATE All_End_Farsode SET S4_1_1=@S4_1_1, S4_1_2=@S4_1_2, S4_1_3=@S4_1_3, S4_1_4=@S4_1_4, S4_1_5=@S4_1_5, S4_1_6=@S4_1_6, S4_1_7=@S4_1_7, S4_1_8=@S4_1_8, S4_1_9=@S4_1_9, S3_Daftarkhane=@S3_Daftarkhane WHERE (S1_idshobe = '" + id_idshobe + "') AND (S1_idmen = '" + id_idmen + "')";
                objCommand2.CommandType = CommandType.Text;

                objCommand2.Parameters.AddWithValue("@S3_Daftarkhane", textBox23.Text);

                if (checkBox1.IsChecked == true)
                    objCommand2.Parameters.AddWithValue("@S4_1_1", "1");
                else
                    objCommand2.Parameters.AddWithValue("@S4_1_1", "0");

                if (checkBox2.IsChecked == true)
                    objCommand2.Parameters.AddWithValue("@S4_1_2", "1");
                else
                    objCommand2.Parameters.AddWithValue("@S4_1_2", "0");

                if (checkBox3.IsChecked == true)
                    objCommand2.Parameters.AddWithValue("@S4_1_3", "1");
                else
                    objCommand2.Parameters.AddWithValue("@S4_1_3", "0");

                if (checkBox4.IsChecked == true)
                    objCommand2.Parameters.AddWithValue("@S4_1_4", "1");
                else
                    objCommand2.Parameters.AddWithValue("@S4_1_4", "0");

                if (checkBox5.IsChecked == true)
                    objCommand2.Parameters.AddWithValue("@S4_1_5", "1");
                else
                    objCommand2.Parameters.AddWithValue("@S4_1_5", "0");

                if (checkBox6.IsChecked == true)
                    objCommand2.Parameters.AddWithValue("@S4_1_6", "1");
                else
                    objCommand2.Parameters.AddWithValue("@S4_1_6", "0");

                if (checkBox7.IsChecked == true)
                    objCommand2.Parameters.AddWithValue("@S4_1_7", "1");
                else
                    objCommand2.Parameters.AddWithValue("@S4_1_7", "0");

                if (checkBox8.IsChecked == true)
                    objCommand2.Parameters.AddWithValue("@S4_1_8", "1");
                else
                    objCommand2.Parameters.AddWithValue("@S4_1_8", "0");

                objCommand2.Parameters.AddWithValue("@S4_1_9", u_set.u_date());

                objConnection.Open();
                objCommand2.ExecuteNonQuery();
                objConnection.Close();

                u_set.u_amal_register("1", this.Title, id_Contract, "1", "ویرایش");

                MessageBox.Show("اطلاعات با موفقیت ویرایش شد", "", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            button1.IsEnabled = true;
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            CrystalReportWpf_AlborzAutomobile.Window1 f1 = new CrystalReportWpf_AlborzAutomobile.Window1();
            f1.Title = "قرارداد حق العمل کاری فرسوده شماره : " + id_Contract;
            f1.selkar = "Crystal_Rusty_01_hagholamal_kari";
            f1.id_Contract = id_Contract;
            f1.Show();
        }

        private void comboBox1_DropDownClosed(object sender, EventArgs e)
        {
            textBox20.Text = comboBox1.SelectedValue.ToString();

            objDataSet2.Clear();
            Database.Connection_Open();
            Database.Fill("SELECT idkhodro, namekhodro FROM infonewall WHERE (idsherkat = '" + textBox20.Text + "') ORDER BY idkhodro", objDataSet2, "infonewall", true);
            Database.Connection_Close();

            comboBox2.DataContext = objDataSet2.Tables["infonewall"];
            comboBox2.DisplayMemberPath = "namekhodro";
            comboBox2.SelectedValuePath = "idkhodro";
        }

        private void comboBox2_DropDownClosed(object sender, EventArgs e)
        {
            if ((comboBox2.Items.Count > 0) && (comboBox2.SelectedIndex != -1))
                textBox21.Text = comboBox2.SelectedValue.ToString();
        }

        private void textBox20_TextChanged(object sender, TextChangedEventArgs e)
        {
            comboBox1.SelectedValue = textBox20.Text;
        }

        private void radioButton1_Checked(object sender, RoutedEventArgs e)
        {
            groupBox2.Visibility = System.Windows.Visibility.Visible;
            groupBox3.Visibility = System.Windows.Visibility.Visible;

            groupBox4.Visibility = System.Windows.Visibility.Hidden;
        }

        private void radioButton2_Checked(object sender, RoutedEventArgs e)
        {
            groupBox2.Visibility = System.Windows.Visibility.Hidden;
            groupBox3.Visibility = System.Windows.Visibility.Hidden;

            groupBox4.Visibility = System.Windows.Visibility.Visible;
        }

        private void comboBox4_DropDownClosed(object sender, EventArgs e)
        {
            if ((comboBox4.Items.Count > 0) && (comboBox4.SelectedIndex != -1))
                textBox23.Text = comboBox4.SelectedValue.ToString();
        }

        private void textBox23_TextChanged(object sender, TextChangedEventArgs e)
        {
            comboBox4.SelectedValue = textBox23.Text;
        }

        private void textBox21_TextChanged(object sender, TextChangedEventArgs e)
        {
            comboBox2.SelectedValue = textBox21.Text;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "Return") { textBox5.Focus(); }
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "Return") { comboBox6.Focus(); }
        }

        private void textBox7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "Return") { textBox9.Focus(); }
        }

        private void textBox8_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "Return")
            {
                expander1.IsExpanded = true;
                textBox11.Focus();
            }
        }

        private void textBox9_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "Return") { textBox10.Focus(); }
        }

        private void textBox10_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "Return") { textBox8.Focus(); }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "Return") { textBox5.Focus(); }
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
            if (e.Key.ToString() == "Return")
            {
                expander2.IsExpanded = true;
                textBox15.Focus();
            }
        }

        private void textBox15_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "Return") { textBox16.Focus(); }
        }

        private void textBox16_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "Return") { textBox17.Focus(); }
        }

        private void textBox17_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "Return")
            {
                expander3.IsExpanded = true;
                textBox18.Focus();
            }
        }

        private void textBox18_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "Return") { textBox19.Focus(); }
        }

        private void textBox19_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "Return") { textBox23.Focus(); }
        }

        private void textBox23_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "Return") { radioButton1.Focus(); }
        }

        private void comboBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "Return") { comboBox3.Focus(); }
        }

        private void comboBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "Return") { comboBox7.Focus(); }
        }

        private void comboBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "Return") { comboBox8.Focus(); }
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            if (radioButton1.IsChecked == true)
            {
                CrystalReportWpf_AlborzAutomobile.Window1 f1 = new CrystalReportWpf_AlborzAutomobile.Window1();
                f1.Title = "قرارداد اقرارنامه فرسوده شماره : " + id_Contract;
                f1.selkar = "Crystal_Rusty_01_Eghrar1";
                f1.id_Contract = id_Contract;
                f1.Show();
            }

            if (radioButton2.IsChecked == true)
            {
                CrystalReportWpf_AlborzAutomobile.Window1 f1 = new CrystalReportWpf_AlborzAutomobile.Window1();
                f1.Title = "قرارداد اقرارنامه فرسوده شماره : " + id_Contract;
                f1.selkar = "Crystal_Rusty_01_Eghrar2";
                f1.id_Contract = id_Contract;
                f1.Show();
            }
        }

        private void Window_Activated(object sender, EventArgs e)
        {

        }

        private void comboBox7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "Return") { textBox1.Focus(); }
        }

        private void comboBox8_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "Return") { textBox9.Focus(); }
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            CrystalReportWpf_AlborzAutomobile.Window1 f1 = new CrystalReportWpf_AlborzAutomobile.Window1();
            f1.Title = "برچسب قرارداد شماره : " + id_Contract;
            f1.selkar = "Crystal_Rusty_01_Lablel";
            f1.id_Contract = id_Contract;
            f1.Show();
        }
    }
}
