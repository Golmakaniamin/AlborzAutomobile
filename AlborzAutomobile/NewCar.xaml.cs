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
    /// Interaction logic for NewCar.xaml
    /// </summary>
    public partial class NewCar : Window
    {
        SqlConnection objConnection = new SqlConnection(DB_Base.ConStr);
        SqlDataAdapter objDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();
        DataSet objDataSet1 = new DataSet();

        DB_Base Database = new DB_Base();
        U_Base u_set = new U_Base();

        public string selkar;
        public string selvaz;

        public string id_idshobe;
        public string id_idmen;
        public string id_Contract;

        public NewCar()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            selvaz = "New";
            if ((selkar == "3") || (selkar == "4") || (selkar == "5"))
            {
                objDataSet.Clear();
                Database.Connection_Open();
                Database.Fill("SELECT * FROM InfoKhodro_Under WHERE (idshobe = '" + id_idshobe + "') AND (id1 = '" + selkar + "') AND (id_Contract = '" + id_Contract + "')", objDataSet, "InfoKhodro_Under", true);
                Database.Connection_Close();

                if (objDataSet.Tables["InfoKhodro_Under"].Rows.Count > 0)
                {
                    textBox1.Text = objDataSet.Tables["InfoKhodro_Under"].Rows[0]["nokhodro"].ToString();
                    textBox2.Text = objDataSet.Tables["InfoKhodro_Under"].Rows[0]["nokarbari"].ToString();
                    textBox3.Text = objDataSet.Tables["InfoKhodro_Under"].Rows[0]["model"].ToString();
                    textBox4.Text = objDataSet.Tables["InfoKhodro_Under"].Rows[0]["shmotor"].ToString();
                    textBox5.Text = objDataSet.Tables["InfoKhodro_Under"].Rows[0]["shshasi"].ToString();
                    textBox6.Text = objDataSet.Tables["InfoKhodro_Under"].Rows[0]["numbersilandr"].ToString();
                    textBox7.Text = objDataSet.Tables["InfoKhodro_Under"].Rows[0]["numberdeff"].ToString();
                    textBox8.Text = objDataSet.Tables["InfoKhodro_Under"].Rows[0]["shsokhtcard"].ToString();
                    textBox9.Text = objDataSet.Tables["InfoKhodro_Under"].Rows[0]["idvin"].ToString();

                    textBox11.Text = objDataSet.Tables["InfoKhodro_Under"].Rows[0]["p1_1"].ToString();
                    textBox12.Text = objDataSet.Tables["InfoKhodro_Under"].Rows[0]["p1_2"].ToString();
                    textBox13.Text = objDataSet.Tables["InfoKhodro_Under"].Rows[0]["p1_3"].ToString();
                    textBox14.Text = objDataSet.Tables["InfoKhodro_Under"].Rows[0]["p1_4"].ToString();
                    textBox15.Text = objDataSet.Tables["InfoKhodro_Under"].Rows[0]["p2_1"].ToString();
                    textBox16.Text = objDataSet.Tables["InfoKhodro_Under"].Rows[0]["p2_2"].ToString();
                    textBox17.Text = objDataSet.Tables["InfoKhodro_Under"].Rows[0]["p2_3"].ToString();
                    textBox18.Text = objDataSet.Tables["InfoKhodro_Under"].Rows[0]["p3_1"].ToString();
                    textBox19.Text = objDataSet.Tables["InfoKhodro_Under"].Rows[0]["p3_2"].ToString();
                    selvaz = "Edit";
                }
                else
                {
                    selvaz = "New";
                }
                objDataSet.Tables["InfoKhodro_Under"].Clear();
            }
            if (selkar == "5")
            {
                button4.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (selvaz == "New")
            {
                SqlCommand objCommand1 = new SqlCommand();
                objCommand1.Connection = objConnection;
                objCommand1.CommandText = "INSERT INTO InfoKhodro_Under (idshobe,id1,id_Contract,nokhodro,model,shmotor,shshasi,shsokhtcard,idvin,nokarbari,numberdeff,numbersilandr,p1_1,p1_2,p1_3,p1_4,p2_1,p2_2,p2_3,p3_1,p3_2) VALUES (@idshobe,@id1,@id_Contract,@nokhodro,@model,@shmotor,@shshasi,@shsokhtcard,@idvin,@nokarbari,@numberdeff,@numbersilandr,@p1_1,@p1_2,@p1_3,@p1_4,@p2_1,@p2_2,@p2_3,@p3_1,@p3_2)";
                objCommand1.CommandType = CommandType.Text;

                objCommand1.Parameters.AddWithValue("@idshobe", id_idshobe);
                objCommand1.Parameters.AddWithValue("@id1", selkar);
                objCommand1.Parameters.AddWithValue("@id_Contract", id_Contract);

                objCommand1.Parameters.AddWithValue("@nokhodro", textBox1.Text);
                objCommand1.Parameters.AddWithValue("@nokarbari", textBox2.Text);
                objCommand1.Parameters.AddWithValue("@model", textBox3.Text);
                objCommand1.Parameters.AddWithValue("@shmotor", textBox4.Text);
                objCommand1.Parameters.AddWithValue("@shshasi", textBox5.Text);
                objCommand1.Parameters.AddWithValue("@numbersilandr", textBox6.Text);
                objCommand1.Parameters.AddWithValue("@numberdeff", textBox7.Text);
                objCommand1.Parameters.AddWithValue("@shsokhtcard", textBox8.Text);
                objCommand1.Parameters.AddWithValue("@idvin", textBox9.Text);
                objCommand1.Parameters.AddWithValue("@p1_1", textBox11.Text);
                objCommand1.Parameters.AddWithValue("@p1_2", textBox12.Text);
                objCommand1.Parameters.AddWithValue("@p1_3", textBox13.Text);
                objCommand1.Parameters.AddWithValue("@p1_4", textBox14.Text);
                objCommand1.Parameters.AddWithValue("@p2_1", textBox15.Text);
                objCommand1.Parameters.AddWithValue("@p2_2", textBox16.Text);
                objCommand1.Parameters.AddWithValue("@p2_3", textBox17.Text);
                objCommand1.Parameters.AddWithValue("@p3_1", textBox18.Text);
                objCommand1.Parameters.AddWithValue("@p3_2", textBox19.Text);

                objConnection.Open();
                objCommand1.ExecuteNonQuery();
                objConnection.Close();

                if (selkar == "4")
                    u_set.u_amal_register("2", this.Title, id_Contract, "6", "جدید");
                else if (selkar == "3")
                    u_set.u_amal_register("1", this.Title, id_Contract, "13", "جدید");
                else if (selkar == "5")
                    u_set.u_amal_register("4", this.Title, id_Contract, "2", "جدید");

                this.Hide();
            }

            if (selvaz == "Edit")
            {
                SqlCommand objCommand1 = new SqlCommand();
                objCommand1.Connection = objConnection;
                objCommand1.CommandText = "UPDATE InfoKhodro_Under SET idshobe=@idshobe ,id1=@id1 ,id_Contract=@id_Contract ,nokhodro=@nokhodro ,model=@model ,shmotor=@shmotor ,shshasi=@shshasi ,shsokhtcard=@shsokhtcard ,idvin=@idvin ,nokarbari=@nokarbari ,numberdeff=@numberdeff ,numbersilandr=@numbersilandr ,p1_1=@p1_1 ,p1_2=@p1_2 ,p1_3=@p1_3 ,p1_4=@p1_4 ,p2_1=@p2_1 ,p2_2=@p2_2 ,p2_3=@p2_3 ,p3_1=@p3_1 ,p3_2=@p3_2 WHERE (idshobe = '" + id_idshobe + "') AND (id1 = '" + selkar + "') AND (id_Contract = '" + id_Contract + "')";
                objCommand1.CommandType = CommandType.Text;

                objCommand1.Parameters.AddWithValue("@idshobe", id_idshobe);
                objCommand1.Parameters.AddWithValue("@id1", selkar);
                objCommand1.Parameters.AddWithValue("@id_Contract", id_Contract);

                objCommand1.Parameters.AddWithValue("@nokhodro", textBox1.Text);
                objCommand1.Parameters.AddWithValue("@nokarbari", textBox2.Text);
                objCommand1.Parameters.AddWithValue("@model", textBox3.Text);
                objCommand1.Parameters.AddWithValue("@shmotor", textBox4.Text);
                objCommand1.Parameters.AddWithValue("@shshasi", textBox5.Text);
                objCommand1.Parameters.AddWithValue("@numbersilandr", textBox6.Text);
                objCommand1.Parameters.AddWithValue("@numberdeff", textBox7.Text);
                objCommand1.Parameters.AddWithValue("@shsokhtcard", textBox8.Text);
                objCommand1.Parameters.AddWithValue("@idvin", textBox9.Text);
                objCommand1.Parameters.AddWithValue("@p1_1", textBox11.Text);
                objCommand1.Parameters.AddWithValue("@p1_2", textBox12.Text);
                objCommand1.Parameters.AddWithValue("@p1_3", textBox13.Text);
                objCommand1.Parameters.AddWithValue("@p1_4", textBox14.Text);
                objCommand1.Parameters.AddWithValue("@p2_1", textBox15.Text);
                objCommand1.Parameters.AddWithValue("@p2_2", textBox16.Text);
                objCommand1.Parameters.AddWithValue("@p2_3", textBox17.Text);
                objCommand1.Parameters.AddWithValue("@p3_1", textBox18.Text);
                objCommand1.Parameters.AddWithValue("@p3_2", textBox19.Text);

                objConnection.Open();
                objCommand1.ExecuteNonQuery();
                objConnection.Close();

                if (selkar == "4")
                    u_set.u_amal_register("2", this.Title, id_Contract, "6", "جدید");
                else if (selkar == "3")
                    u_set.u_amal_register("1", this.Title, id_Contract, "13", "جدید");
                else if (selkar == "5")
                    u_set.u_amal_register("4", this.Title, id_Contract, "2", "جدید");

                this.Hide();
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return) { textBox2.Focus(); }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return) { textBox3.Focus(); }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return) { textBox4.Focus(); }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return) { textBox5.Focus(); }
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return) { textBox6.Focus(); }
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return) { textBox7.Focus(); }
        }

        private void textBox7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return) { textBox8.Focus(); }
        }

        private void textBox8_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return) { textBox9.Focus(); }
        }

        private void textBox9_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                expander1.IsExpanded = true;
                textBox11.Focus();
            }
        }

        private void textBox11_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return) { textBox12.Focus(); }
        }

        private void textBox12_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return) { textBox13.Focus(); }
        }

        private void textBox13_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return) { textBox14.Focus(); }
        }

        private void textBox14_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return) { button1.Focus(); }
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            if (selkar == "5")
            {
                CrystalReportWpf_AlborzAutomobile.Window1 f1 = new CrystalReportWpf_AlborzAutomobile.Window1();
                f1.Title = "قرارداد خرید و فروش نقدی شماره : " + id_Contract;
                f1.selkar = "Crystal_Sell_Buy_01_Gholnameh";
                f1.id_Contract = id_Contract;
                f1.Show();
            }
        }
    }
}
