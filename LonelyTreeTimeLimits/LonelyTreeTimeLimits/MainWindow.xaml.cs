using System;
using System.Collections.Generic;
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
using Model;



namespace LonelyTreeTimeLimits
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {   
        ModelFacade Mf;
      
        public MainWindow()
        {
 InitializeComponent();
              Mf = new ModelFacade();
              SalesListBox.ItemsSource = Mf.GetSales();

              
              
        }

        private void salesDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            

        }

        private void saleNewButton_Click(object sender, RoutedEventArgs e)
        {
         
             NewSaleWindow NewSaleWindow = new NewSaleWindow(Mf);
             NewSaleWindow.Show();
             Mf.CreateSale();
             SalesListBox.Items.Refresh();


        }
    }
}
