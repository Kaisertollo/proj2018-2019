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

        /*la circulationn au niveau du menu la visibilite des sous menus
        * UseCase Si je Selectionne le champs Staff je dois voir le sous Menu Staff only les autre doivent disparaitre   
        */
        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // index indique l'option selectionne
            int index = ListViewMenu.SelectedIndex;

            //Tous les sous-menus doivent etre invisble
            StoreMenu.Visibility = Visibility.Collapsed;
            StaffMenu.Visibility = Visibility.Collapsed;
            MovieMenu.Visibility = Visibility.Collapsed;
            // now selon l'option selectionne dans le MainMenu un sous-menu va apparaitre or stay collapsed
            // Mygrid1.Visibility = System.Windows.Visibility.Visible;
            //Mygrid2.Visibility = System.Windows.Visibility.Visible;
            switch(index)
            {
                case 1:
                    StoreMenu.Visibility = Visibility.Visible;
                    StoreMenu.SelectedIndex = -1;
                    break;
                case 2:
                    StaffMenu.Visibility = System.Windows.Visibility.Visible;
                    StaffMenu.SelectedIndex = -1;
                    break;
                case 3:
                    MovieMenu.Visibility = System.Windows.Visibility.Visible;
                    MovieMenu.SelectedIndex = -1;
                    break;
                case 4:
                    main2Grid.Children.Clear();
                    main2Grid.Children.Add(new AddAddress());
                    break;

            }
        }
        /// <summary>
        /// //Staff,Store,Movuie subMenu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void StaffMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
       {
            int index = StaffMenu.SelectedIndex;
            switch(index)
            {
                case 0:
                    main2Grid.Children.Clear();
                    main2Grid.Children.Add(new AddStaff());
                    break;
            }
       }

      

        private void MovieMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = MovieMenu.SelectedIndex;
            switch (index)
            {
                case 0:
                    main2Grid.Children.Clear();
                    main2Grid.Children.Add(new AddMovies());
                    break;
                case 1:
                    main2Grid.Children.Clear();
                    main2Grid.Children.Add(new AjouterActeur());
                    break;
            }

        }

        private void StoreMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = StoreMenu.SelectedIndex;
            switch (index)
            {
                case 0:
                    main2Grid.Children.Clear();
                    main2Grid.Children.Add(new AjouterStore());
                    break;
            }
        }
    }
}
