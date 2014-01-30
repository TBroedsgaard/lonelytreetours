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
        ModelFacade modelFacade;
      
        public MainWindow()
        {
            InitializeComponent();
            modelFacade = new ModelFacade();
            List<ISale> sales = modelFacade.GetSales();
            salesListView.ItemsSource = getActiveSales();
        }

        private List<ISale> getActiveSales()
        {
            List<ISale> activeSales = new List<ISale>();

            List<ISale> allSales = modelFacade.GetSales();

            foreach (ISale sale in allSales)
            {
                if (sale.Deleted == false)
                {
                    activeSales.Add(sale);
                }
            }

            return activeSales;
        }

        private void salesDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            ISale sale = salesListView.SelectedItem as ISale;
            modelFacade.DeleteSale(sale);
        }

        private void saleNewButton_Click(object sender, RoutedEventArgs e)
        {
             NewSaleWindow NewSaleWindow = new NewSaleWindow(modelFacade);
             NewSaleWindow.Show();
             NewSaleWindow.Closed += NewSaleWindow_Closed;
        }

        void NewSaleWindow_Closed(object sender, EventArgs e)
        {
             salesListView.ItemsSource = getActiveSales();
        }

        private void salesEditButton_Click(object sender, RoutedEventArgs e)
        {
            NewSaleWindow editSaleWindow = new NewSaleWindow(modelFacade, (ISale)salesListView.SelectedItem);
            editSaleWindow.Show();

        }
    }
}
