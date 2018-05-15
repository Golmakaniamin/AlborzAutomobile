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
    /// Interaction logic for Setting_Bureau.xaml
    /// </summary>
    public partial class Setting_Bureau : Window
    {
        SqlConnection objConnection = new SqlConnection(DB_Base.ConStr);
        SqlDataAdapter objDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();

        DB_Base Database = new DB_Base();
        U_Base u_set = new U_Base();

        public string id_Shobe;

        public Setting_Bureau()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (objDataSet.Tables["Daftar"] != null)
                objDataSet.Tables["Daftar"].Clear();

            objDataAdapter.SelectCommand = new SqlCommand();
            objDataAdapter.SelectCommand.Connection = objConnection;
            objDataAdapter.SelectCommand.CommandText = "SELECT * FROM Daftar WHERE (id_Shobe = " + id_Shobe + ") ORDER BY rad";
            objDataAdapter.SelectCommand.CommandType = CommandType.Text;
            objConnection.ConnectionString = DB_Base.ConStr;

            objConnection.Open();
            objDataAdapter.Fill(objDataSet, "Daftar");
            objConnection.Close();

            dataGrid1.DataContext = objDataSet;
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            if (objDataSet.HasChanges())
            {
                SqlCommandBuilder cb = new SqlCommandBuilder(objDataAdapter);
                if (objDataSet.Tables["Daftar"].Rows.Count > 0)
                {
                    for (int q = 0; q <= objDataSet.Tables["Daftar"].Rows.Count - 1; q++)
                    {
                        if (objDataSet.Tables["Daftar"].Rows[q].RowState.ToString() == "Added")
                        {
                            objDataSet.Tables["Daftar"].Rows[q]["id_Shobe"] = id_Shobe;
                        }
                    }
                    objConnection.Open();
                    cb.DataAdapter.Update(objDataSet, "Daftar");
                    objConnection.Close();
                }

                MessageBox.Show("اطلاعات با موفقیت ثبت شد", "", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
