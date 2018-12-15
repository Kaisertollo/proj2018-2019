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
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
          

        }
        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            int index = ListViewMenu.SelectedIndex;
            AddressMenu.Visibility = System.Windows.Visibility.Hidden;
            StaffMenu.Visibility = System.Windows.Visibility.Hidden;
            Mygrid1.Visibility = System.Windows.Visibility.Visible;
            Mygrid2.Visibility = System.Windows.Visibility.Visible;
            if (index==2)
            {
                StaffMenu.Visibility = System.Windows.Visibility.Visible;
               
                AddressMenu.SelectedIndex = -1;
            }
                
           if (index == 4)
            {
              
                StaffMenu.SelectedIndex = -1;
                AddressMenu.Visibility = System.Windows.Visibility.Visible;
            }

            if (index == 1)
            {
                Mygrid2.Visibility = System.Windows.Visibility.Collapsed;
                Mygrid1.Visibility = System.Windows.Visibility.Collapsed;
                main2Grid.Children.Add(new AjouterStore());
            }

        }
       private void StaffMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
       {
            int index = StaffMenu.SelectedIndex;
            switch(index)
            {
                case 0:
                    Mygrid1.Children.Clear();
                    Mygrid1.Children.Add(new AddStaff());
                    break;

            }
        }

        private void AddressMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = AddressMenu.SelectedIndex;
            switch (index)
            {
                case 0:
                    Mygrid1.Children.Clear();
                    Mygrid1.Children.Add(new AddAddress());
                    break;

            }
        }
    }
}
