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
using Interfaces;



namespace LonelyTreeTimeLimits
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int SelectedCustomer;
        ModelFacade Mf;
        List<int> custID;
        List<ICustomer> custList;
        List<string> customernames;
        public MainWindow()
        {
              InitializeComponent();
              Mf = new ModelFacade();
              custList = new List<ICustomer>();
              custList = Mf.GetCustomers();
              custID = new List<int>();
              foreach (ICustomer c in custList)
              {
                  custID.Add((int)c.Id);
              }
              
              customernames = new List<string>();
              foreach (ICustomer c in custList)
              {
                  customernames.Add(c.FirstName + " " + c.LastName + " " + c.Email);

              }
              
             
              
              SalesListBox.ItemsSource = customernames;
              SalesListBox.Items.Refresh();
            
              
              
        }

        private void removecustomer(int Id)
        {

        }

        private void salesDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (ICustomer c in custList)
	{   
		 if (c.Id == custID[SelectedCustomer])
	{
        Mf.DeleteCustomer(c);
        SalesListBox.Items.Refresh();
	}
	}
            
           
            
        }

        private void saleNewButton_Click(object sender, RoutedEventArgs e)
        {
         
             NewSaleWindow NewSaleWindow = new NewSaleWindow(Mf);
             NewSaleWindow.Show();
             Mf.CreateSale();
             SalesListBox.Items.Refresh();


        }

        private void SalesListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
          SelectedCustomer = SalesListBox.SelectedIndex;

        }
    }
}
