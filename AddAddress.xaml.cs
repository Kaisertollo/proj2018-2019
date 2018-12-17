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
using proj2018_2019.ServiceReference1;
namespace proj2018_2019
{
    /// <summary>
    /// Logique d'interaction pour AddAddress.xaml
    /// </summary>
    public partial class AddAddress : UserControl
    {
         //* IFundamentalClient Client a travers laquelle je fait appel au service de IFundamentals
        IfundamentalsClient client = new IfundamentalsClient();
        public AddAddress()
        {
            InitializeComponent();
           
            //Remplir Ma comboBox
            //Maybe Create a Custom Class in Order to Have a better Style of view avec Country et tout Pas Urgent
            ICollection<City> Cities = client.GetCities();
            CityComboBox.ItemsSource = Cities;
            CityComboBox.DisplayMemberPath = "City_Lib";

        }

        //Event:valider Form
        //Outcome:enregistrement info si reussi reInit formulaire si rater show Message box
        private void Valider_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                Address a = new Address();
                a.Address_Lib = AddressTextBox.Text;
                a.Address_Lib2 = Address2TextBox.Text;
                a.District = DistrictTextBox.Text;
                a.Phone = phoneTextBox.Text;
                a.Postal_Code = PostalTextBox.Text;
                a.City_ID = ((City)CityComboBox.SelectedItem).City_ID;
                
                //Return or throw something
                client.AddAddress(a);
                AddressTextBox.Text = "";
                Address2TextBox.Text = "";
                DistrictTextBox.Text = "";
                PostalTextBox.Text = "";
                phoneTextBox.Text = "";
            }
            catch (Exception exep)
            {

                MessageBox.Show(exep.Message);
            }
        }
    }
}
