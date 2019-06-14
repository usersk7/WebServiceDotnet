using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        DataSet ds = new DataSet();

        private void Button_Click_loadObj(object sender, RoutedEventArgs e)
        {
            localhost.WebService1 obj = new localhost.WebService1();

            var loadobj = obj.GetmyclassObj();

            lbl1.Content = loadobj.No;
            lbl2.Content = loadobj.Name;
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            localhost.WebService1 obj = new localhost.WebService1();

            ds = obj.GetDs();
            dgr.ItemsSource = ds.Tables["Emps"].DefaultView;


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            localhost.WebService1 obj = new localhost.WebService1();
            obj.UpdateDs(ds);

        }
    }
}

