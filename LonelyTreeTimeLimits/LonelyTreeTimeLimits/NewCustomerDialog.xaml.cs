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
using System.Windows.Shapes;
using Interfaces;
using Model;

namespace LonelyTreeTimeLimits
{
    /// <summary>
    /// Interaction logic for NewCustomerDialog.xaml
    /// </summary>
    public partial class NewCustomerDialog : Window
    {
        ModelFacade mf;

        public NewCustomerDialog(ModelFacade modface)
        {
            InitializeComponent();
            mf = modface;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if ( EmailTxtBox.Text !="" && FirstNameTxtbox.Text != "" && CustomerDatePicker.SelectedDate !=null || LastNameTxtbox.Text !="" 
                || EmailTxtBox.Text !="Email" || PhoneTextBox.Text !="Phone")
            {
              ICustomer Customer = mf.CreateCustomer();
              
              Customer.Email = EmailTxtBox.Text;
              Customer.FirstName = FirstNameTxtbox.Text;
              Customer.LastName = FirstNameTxtbox.Text;
              Customer.Skype = SkypeTxtBox.Text;
              if(CustomerDatePicker.SelectedDate != null)     
                {  Customer.BirthDate = (DateTime)CustomerDatePicker.SelectedDate; }
              FormFillErrorTxtbox.Content = "Customer added";

              mf.UpdateCustomer(Customer);

              

            }

            else
            { FormFillErrorTxtbox.Content = "Please complete email firstname and lastname"; }
        }
    }
}
