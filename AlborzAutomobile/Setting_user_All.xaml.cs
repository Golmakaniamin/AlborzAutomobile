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
using System.IO;
using System.Drawing.Imaging;

namespace AlborzAutomobile
{
    /// <summary>
    /// Interaction logic for Setting_user_All.xaml
    /// </summary>
    public partial class Setting_user_All : Window
    {
        SqlConnection objConnection = new SqlConnection(DB_Base.ConStr);
        SqlDataAdapter objDataAdapter = new SqlDataAdapter();

        DataSet objDataSet = new DataSet();
        DataSet objDataSet1 = new DataSet();

        DB_Base Database = new DB_Base();
        U_Base u_set = new U_Base();

        public string id_idshobe;
        string select_amal;
        string select_id;

        public Setting_user_All()
        {
            InitializeComponent();
        }

        private void textBox4_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            select_amal = "New";

            Database.Connection_Open();
            Database.Fill("SELECT * FROM Tbl_User WHERE (id_Shobe = '" + "101" + "')", objDataSet, "Tbl_User1", true);
            Database.Connection_Close();

            dataGrid1.DataContext = objDataSet;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "Return") { textBox2.Focus(); }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "Return") { textBox3.Focus(); }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "Return") { textBox4.Focus(); }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "Return") { textBox5.Focus(); }
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "Return") { textBox6.Focus(); }
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
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
            if (e.Key.ToString() == "Return") { button1.Focus(); }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("لطفا نام را تکمیل نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                textBox1.Focus();
                return;
            }

            if (textBox2.Text == "")
            {
                MessageBox.Show("لطفا نام خانوادگی را تکمیل نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                textBox2.Focus();
                return;
            }

            if (textBox3.Text == "")
            {
                MessageBox.Show("لطفا نام پدر را تکمیل نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                textBox3.Focus();
                return;
            }

            if (textBox4.Text == "")
            {
                MessageBox.Show("لطفا شماره شناسنامه را تکمیل نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                textBox4.Focus();
                return;
            }

            if (textBox5.Text == "")
            {
                MessageBox.Show("لطفا کد ملی را تکمیل نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                textBox5.Focus();
                return;
            }

            if (textBox6.Text == "")
            {
                MessageBox.Show("لطفا کد پستی را تکمیل نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                textBox6.Focus();
                return;
            }

            if (textBox12.Text == "")
            {
                MessageBox.Show("لطفا تحصیلات را تکمیل نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                textBox12.Focus();
                return;
            }

            if (textBox13.Text == "")
            {
                MessageBox.Show("لطفا تاهل را تکمیل نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                textBox13.Focus();
                return;
            }

            if (textBox14.Text == "")
            {
                MessageBox.Show("لطفا تعداد فرزند را تکمیل نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                textBox14.Focus();
                return;
            }

            if (textBox7.Text == "")
            {
                MessageBox.Show("لطفا تلفن همراه را تکمیل نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                textBox7.Focus();
                return;
            }

            if (textBox8.Text == "")
            {
                MessageBox.Show("لطفا تلفن منزل را تکمیل نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                textBox8.Focus();
                return;
            }

            if (textBox9.Text == "")
            {
                MessageBox.Show("لطفا تلفن دیگر را تکمیل نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                textBox9.Focus();
                return;
            }

            if (textBox10.Text == "")
            {
                MessageBox.Show("لطفا نشانی منزل را تکمیل نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                textBox10.Focus();
                return;
            }

            if (textBox11.Text == "")
            {
                MessageBox.Show("لطفا توضیحات را تکمیل نمایید", "", MessageBoxButton.OK, MessageBoxImage.Error);
                textBox11.Focus();
                return;
            }

            if (select_amal == "New")
            {
                SqlCommand objCommand1 = new SqlCommand();
                objCommand1.Connection = objConnection;
                objCommand1.CommandText = "INSERT INTO Tbl_User (id_Shobe,id,name,family,fathername,shsh,idmelli,idp,tahsilat,tahol,numberboy,mobile,phone,username,address,promp,endkar,administrator,pass) VALUES (@id_Shobe,@id,@name,@family,@fathername,@shsh,@idmelli,@idp,@tahsilat,@tahol,@numberboy,@mobile,@phone,@username,@address,@promp,@endkar,@administrator,@pass)";
                objCommand1.CommandType = CommandType.Text;

                Database.Connection_Open();
                Database.Fill("SELECT MAX(tmpid) AS rsmax FROM Tbl_User", objDataSet, "Tbl_User", true);
                Database.Connection_Close();
                select_id = (1390 + Convert.ToInt64(objDataSet.Tables["Tbl_User"].Rows[0]["rsmax"].ToString()) + 1).ToString();

                objCommand1.Parameters.AddWithValue("@id_Shobe", id_idshobe);
                objCommand1.Parameters.AddWithValue("@id", select_id);
                objCommand1.Parameters.AddWithValue("@name", textBox1.Text);
                objCommand1.Parameters.AddWithValue("@family", textBox2.Text);
                objCommand1.Parameters.AddWithValue("@fathername", textBox3.Text);
                objCommand1.Parameters.AddWithValue("@shsh", textBox4.Text);
                objCommand1.Parameters.AddWithValue("@idmelli", textBox5.Text);
                objCommand1.Parameters.AddWithValue("@idp", textBox6.Text);
                objCommand1.Parameters.AddWithValue("@tahsilat", textBox12.Text);
                objCommand1.Parameters.AddWithValue("@tahol", textBox13.Text);
                objCommand1.Parameters.AddWithValue("@numberboy", textBox14.Text);
                objCommand1.Parameters.AddWithValue("@mobile", textBox7.Text);
                objCommand1.Parameters.AddWithValue("@phone", textBox8.Text);
                objCommand1.Parameters.AddWithValue("@username", textBox9.Text);
                objCommand1.Parameters.AddWithValue("@address", textBox10.Text);
                objCommand1.Parameters.AddWithValue("@promp", textBox11.Text);
                objCommand1.Parameters.AddWithValue("@endkar", false);
                objCommand1.Parameters.AddWithValue("@administrator", false);
                objCommand1.Parameters.AddWithValue("@pass", "1");

                objConnection.Open();
                objCommand1.ExecuteNonQuery();
                objConnection.Close();

                SqlCommand objCommand2 = new SqlCommand();
                objCommand2.Connection = objConnection;
                objCommand2.CommandText = "INSERT INTO UserAmal (uuser,udate,utime,upc,id,place,Contract,rad,noe) VALUES (@uuser,@udate,@utime,@upc,@id,@place,@Contract,@rad,@noe)";
                objCommand2.CommandType = CommandType.Text;

                objCommand2.Parameters.AddWithValue("@uuser", u_set.u_user());
                objCommand2.Parameters.AddWithValue("@udate", u_set.u_date());
                objCommand2.Parameters.AddWithValue("@utime", u_set.u_time());
                objCommand2.Parameters.AddWithValue("@upc", u_set.u_pc());
                objCommand2.Parameters.AddWithValue("@id", "3");
                objCommand2.Parameters.AddWithValue("@place", this.Title);
                objCommand2.Parameters.AddWithValue("@Contract", select_id);
                objCommand2.Parameters.AddWithValue("@rad", "");
                objCommand2.Parameters.AddWithValue("@noe", "جدید");

                objConnection.Open();
                objCommand2.ExecuteNonQuery();
                objConnection.Close();

                MessageBox.Show("اطلاعات با موفقیت ثبت شد", "", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            if (select_amal == "Edit")
            {
                SqlCommand objCommand1 = new SqlCommand();
                objCommand1.Connection = objConnection;
                objCommand1.CommandText = "UPDATE Tbl_User SET name=@name ,family=@family ,fathername=@fathername ,shsh=@shsh ,idmelli=@idmelli ,idp=@idp ,tahsilat=@tahsilat ,tahol=@tahol ,numberboy=@numberboy ,mobile=@mobile ,phone=@phone ,username=@username ,address=@address ,promp=@promp WHERE (tmpid = '" + select_id + "')";
                objCommand1.CommandType = CommandType.Text;

                objCommand1.Parameters.AddWithValue("@name", textBox1.Text);
                objCommand1.Parameters.AddWithValue("@family", textBox2.Text);
                objCommand1.Parameters.AddWithValue("@fathername", textBox3.Text);
                objCommand1.Parameters.AddWithValue("@shsh", textBox4.Text);
                objCommand1.Parameters.AddWithValue("@idmelli", textBox5.Text);
                objCommand1.Parameters.AddWithValue("@idp", textBox6.Text);
                objCommand1.Parameters.AddWithValue("@tahsilat", textBox12.Text);
                objCommand1.Parameters.AddWithValue("@tahol", textBox13.Text);
                objCommand1.Parameters.AddWithValue("@numberboy", textBox14.Text);
                objCommand1.Parameters.AddWithValue("@mobile", textBox7.Text);
                objCommand1.Parameters.AddWithValue("@phone", textBox8.Text);
                objCommand1.Parameters.AddWithValue("@username", textBox9.Text);
                objCommand1.Parameters.AddWithValue("@address", textBox10.Text);
                objCommand1.Parameters.AddWithValue("@promp", textBox11.Text);

                objConnection.Open();
                objCommand1.ExecuteNonQuery();
                objConnection.Close();

                SqlCommand objCommand2 = new SqlCommand();
                objCommand2.Connection = objConnection;
                objCommand2.CommandText = "INSERT INTO UserAmal (uuser,udate,utime,upc,id,place,Contract,rad,noe) VALUES (@uuser,@udate,@utime,@upc,@id,@place,@Contract,@rad,@noe)";
                objCommand2.CommandType = CommandType.Text;

                objCommand2.Parameters.AddWithValue("@uuser", u_set.u_user());
                objCommand2.Parameters.AddWithValue("@udate", u_set.u_date());
                objCommand2.Parameters.AddWithValue("@utime", u_set.u_time());
                objCommand2.Parameters.AddWithValue("@upc", u_set.u_pc());
                objCommand2.Parameters.AddWithValue("@id", "3");
                objCommand2.Parameters.AddWithValue("@place", this.Title);
                objCommand2.Parameters.AddWithValue("@Contract", select_id);
                objCommand2.Parameters.AddWithValue("@rad", "");
                objCommand2.Parameters.AddWithValue("@noe", "ویرایش");

                objConnection.Open();
                objCommand2.ExecuteNonQuery();
                objConnection.Close();

                MessageBox.Show("اطلاعات با موفقیت ویرایش شد", "", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            Database.Connection_Open();
            Database.Fill("SELECT * FROM Tbl_User WHERE (id_Shobe = '" + id_idshobe + "')", objDataSet, "Tbl_User1", true);
            Database.Connection_Close();

            dataGrid1.DataContext = objDataSet;
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            select_amal = "Edit";

            Database.Connection_Open();
            Database.Fill("SELECT * FROM Tbl_User WHERE (tmpid=" + select_id + ")", objDataSet, "Tbl_User", true);
            Database.Connection_Close();
            if (objDataSet.Tables["Tbl_User"].Rows.Count > 0)
            {
                textBox1.Text = objDataSet.Tables["Tbl_User"].Rows[0]["name"].ToString();
                textBox2.Text = objDataSet.Tables["Tbl_User"].Rows[0]["family"].ToString();
                textBox3.Text = objDataSet.Tables["Tbl_User"].Rows[0]["fathername"].ToString();
                textBox4.Text = objDataSet.Tables["Tbl_User"].Rows[0]["shsh"].ToString();
                textBox5.Text = objDataSet.Tables["Tbl_User"].Rows[0]["idmelli"].ToString();
                textBox6.Text = objDataSet.Tables["Tbl_User"].Rows[0]["idp"].ToString();
                textBox12.Text = objDataSet.Tables["Tbl_User"].Rows[0]["tahsilat"].ToString();
                textBox13.Text = objDataSet.Tables["Tbl_User"].Rows[0]["tahol"].ToString();
                textBox14.Text = objDataSet.Tables["Tbl_User"].Rows[0]["numberboy"].ToString();
                textBox7.Text = objDataSet.Tables["Tbl_User"].Rows[0]["mobile"].ToString();
                textBox8.Text = objDataSet.Tables["Tbl_User"].Rows[0]["phone"].ToString();
                textBox9.Text = objDataSet.Tables["Tbl_User"].Rows[0]["username"].ToString();
                textBox10.Text = objDataSet.Tables["Tbl_User"].Rows[0]["address"].ToString();
                textBox11.Text = objDataSet.Tables["Tbl_User"].Rows[0]["promp"].ToString();

                //byte[] data = (byte[])objDataSet.Tables["Tbl_User"].Rows[0]["picture"];
                //MemoryStream strm = new MemoryStream();
                //strm.Write(data, 0, data.Length);
                //strm.Position = 0;
                //System.Drawing.Image img = System.Drawing.Image.FromStream(strm);

                //BitmapImage bi = new BitmapImage();
                //bi.BeginInit();
                //MemoryStream ms = new MemoryStream();
                //img.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                //ms.Seek(0, SeekOrigin.Begin);
                //bi.StreamSource = ms;
                //bi.EndInit();
                //image1.Source = bi;
            }
        }

        private void dataGrid1_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {
                DataRowView _DataView = dataGrid1.CurrentCell.Item as DataRowView;

                if (_DataView != null)
                {
                    select_id = _DataView.Row[0].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialogImage = new Microsoft.Win32.OpenFileDialog();
            openFileDialogImage.Title = "انتخاب عکس";
            openFileDialogImage.Filter = "JPG Format (*.jpg) |*.jpg| PNG Format (*.png) |*.png";
            openFileDialogImage.FilterIndex = 1;

            Nullable<bool> result = openFileDialogImage.ShowDialog();
            if (result == true)
            {
                string ImageName = openFileDialogImage.FileName;
                BitmapImage logo = new BitmapImage();
                logo.BeginInit();
                logo.UriSource = new Uri(ImageName);
                logo.EndInit();
                image1.Source = logo;

                //cmd.Parameters.Add("@Name", SqlDbType.Text).Value = FileName(TextBox1.Text.Trim)
                //cmd.Parameters.Add("@ImgData", SqlDbType.Binary, Stream.Length).Value = ImgData
            }
        }

        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }

        //public Image byteArrayToImage(byte[] byteArrayIn)
        //{
        //    MemoryStream ms = new MemoryStream(byteArrayIn);
        //    Image returnImage = Image.FromStream(ms);
        //    return returnImage;
        //}

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            Database.Connection_Open();
            Database.Fill("SELECT * FROM Tbl_User WHERE (tmpid = '" + select_id + "')", objDataSet, "Tbl_User2", true);
            Database.Connection_Close();

            if (objDataSet.Tables["Tbl_User2"].Rows[0]["endkar"].ToString() == "False")
            {
                SqlCommand objCommand1 = new SqlCommand();
                objCommand1.Connection = objConnection;
                objCommand1.CommandText = "UPDATE Tbl_User SET endkar=@endkar WHERE (tmpid = '" + select_id + "')";
                objCommand1.CommandType = CommandType.Text;

                objCommand1.Parameters.AddWithValue("@endkar", true);

                objConnection.Open();
                objCommand1.ExecuteNonQuery();
                objConnection.Close();

                SqlCommand objCommand2 = new SqlCommand();
                objCommand2.Connection = objConnection;
                objCommand2.CommandText = "INSERT INTO UserAmal (uuser,udate,utime,upc,id,place,Contract,rad,noe) VALUES (@uuser,@udate,@utime,@upc,@id,@place,@Contract,@rad,@noe)";
                objCommand2.CommandType = CommandType.Text;

                objCommand2.Parameters.AddWithValue("@uuser", u_set.u_user());
                objCommand2.Parameters.AddWithValue("@udate", u_set.u_date());
                objCommand2.Parameters.AddWithValue("@utime", u_set.u_time());
                objCommand2.Parameters.AddWithValue("@upc", u_set.u_pc());
                objCommand2.Parameters.AddWithValue("@id", "3");
                objCommand2.Parameters.AddWithValue("@place", this.Title);
                objCommand2.Parameters.AddWithValue("@Contract", select_id);
                objCommand2.Parameters.AddWithValue("@rad", "");
                objCommand2.Parameters.AddWithValue("@noe", "پایان کار");

                objConnection.Open();
                objCommand2.ExecuteNonQuery();
                objConnection.Close();
            }
            else
            {
                SqlCommand objCommand1 = new SqlCommand();
                objCommand1.Connection = objConnection;
                objCommand1.CommandText = "UPDATE Tbl_User SET endkar=@endkar WHERE (tmpid = '" + select_id + "')";
                objCommand1.CommandType = CommandType.Text;

                objCommand1.Parameters.AddWithValue("@endkar", false);

                objConnection.Open();
                objCommand1.ExecuteNonQuery();
                objConnection.Close();

                SqlCommand objCommand2 = new SqlCommand();
                objCommand2.Connection = objConnection;
                objCommand2.CommandText = "INSERT INTO UserAmal (uuser,udate,utime,upc,id,place,Contract,rad,noe) VALUES (@uuser,@udate,@utime,@upc,@id,@place,@Contract,@rad,@noe)";
                objCommand2.CommandType = CommandType.Text;

                objCommand2.Parameters.AddWithValue("@uuser", u_set.u_user());
                objCommand2.Parameters.AddWithValue("@udate", u_set.u_date());
                objCommand2.Parameters.AddWithValue("@utime", u_set.u_time());
                objCommand2.Parameters.AddWithValue("@upc", u_set.u_pc());
                objCommand2.Parameters.AddWithValue("@id", "3");
                objCommand2.Parameters.AddWithValue("@place", this.Title);
                objCommand2.Parameters.AddWithValue("@Contract", select_id);
                objCommand2.Parameters.AddWithValue("@rad", "");
                objCommand2.Parameters.AddWithValue("@noe", "پایان کار");

                objConnection.Open();
                objCommand2.ExecuteNonQuery();
                objConnection.Close();
            }
            MessageBox.Show("پرسنل با موفقیت پایان کار یافت", "", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            SqlCommand objCommand1 = new SqlCommand();
            objCommand1.Connection = objConnection;
            objCommand1.CommandText = "UPDATE Tbl_User SET pass=pwdencrypt(1) WHERE (tmpid = '" + select_id + "')";
            objCommand1.CommandType = CommandType.Text;

            objConnection.Open();
            objCommand1.ExecuteNonQuery();
            objConnection.Close();

            MessageBox.Show("رمز جدید با موفقیت صادر شد", "", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
