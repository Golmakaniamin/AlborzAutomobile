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

namespace AlborzAutomobile
{
    /// <summary>
    /// Interaction logic for BC_SEC.xaml
    /// </summary>
    public partial class BC_SEC : Window
    {
        public string sel_work;
        public string id_group;

        public BC_SEC()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            textBox1.Focus();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                if (sel_work == "1")
                {
                    if (textBox1.Text.Length == 10)
                    {
                        Customers f1 = new Customers();
                        f1.id_group = id_group;
                        f1.id_melli = textBox1.Text;
                        f1.label16.Content = "Add";
                        f1.Show();

                        this.Hide();
                    }
                }
            }
        }
    }
}

