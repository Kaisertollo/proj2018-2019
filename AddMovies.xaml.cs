using proj2018_2019.ServiceReference2;
using proj2018_2019.ServiceReference1;
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

namespace proj2018_2019
{
    /// <summary>
    /// Logique d'interaction pour AddMovies.xaml
    /// </summary>
    public partial class AddMovies : UserControl
    {
        public class ActorsL
        {
            public Actor Actor { get; set; }
            public Boolean boole { get; set; }
            
        }
        public class CategoryL
        {
            public Category Category { get; set; }
            public Boolean boole { get; set; }

        }
        public class StoreL
        {
            public Store Store { get; set; }
            public Address Address { get; set; }
            public Boolean boole { get; set; }
        }

        ThiouneServiceClient Client = new ThiouneServiceClient();
        private List<CategoryL> listcL { get; set; }
        private List<ActorsL> listAL { get; set; }
        public AddMovies()
        {
            InitializeComponent();
           
            OriginalLanguageComboBox.ItemsSource = Client.GetLang();
            OriginalLanguageComboBox.DisplayMemberPath = "Name";

            LanguageComboBox.ItemsSource = Client.GetLang();
            LanguageComboBox.DisplayMemberPath = "Name";
            string[] array = {"Trailer","BehuindScene","Game","AdditionalCd","Interactif"};
            List<Category> listCat = Client.GetCat().ToList<Category>();
            List<Actor> ListAct = Client.GetActor().ToList<Actor>();

            listcL = new List<CategoryL>();
            listAL = new List<ActorsL>();
            foreach (Category C in listCat)
            {
                CategoryL v32 = new CategoryL();
                v32.Category = C;

                v32.boole = false;
                listcL.Add(v32);
            }
            foreach (Actor a in ListAct)
            {
                ActorsL v32 = new ActorsL();
                v32.Actor = a;
                MessageBox.Show(""+a.Firstname);
                v32.boole = false;
                listAL.Add(v32);
            }
            List1.ItemsSource = listAL;
            List1C.ItemsSource = listcL;
            SpecialFeatures.ItemsSource = array;
        }

        private void LanguageComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Yearslider.Value = (int)Yearslider.Value;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ServiceReference2.Film F = new ServiceReference2.Film();
            F.Description = Description.Text;
            F.Lenght = Int32.Parse(Lenght.Text);
            F.Release_year = "" + Yearslider.Value;
            F.Title = TitleTextBox.Text;
            F.Rental_duration = Int32.Parse(RentalDuration.Text);
            F.Rental_rate = Decimal.Parse(RentalRate.Text);
            F.Replacement_cost= Decimal.Parse(ReplacementCost.Text);
            F.Special_features = (string)SpecialFeatures.SelectedItem;
            F.Original_Language_ID = (int)((Language)OriginalLanguageComboBox.SelectedItem).LanguageID;
            F.LanguageID = (int)((Language)LanguageComboBox.SelectedItem).LanguageID;
            F.Rating = "" + Rating_Slider.Value;
            listcL = listcL.Where(X => X.boole == true).ToList();
            listAL = listAL.Where(X => X.boole == true).ToList();
            List<Actor> finalA = new List<Actor>();
            List<Category> finalC = new List<Category>();
            foreach (CategoryL C in listcL )
            {
                finalC.Add(C.Category);
            }
            foreach (ActorsL A in listAL)
            {
                finalA.Add(A.Actor);
            }
            Client.AddFilms(F, finalA.ToArray(), finalC.ToArray());
        }

        private void Rating_Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Rating_Slider.Value = (int)Rating_Slider.Value;
            switch(Rating_Slider.Value)
            {
                case 0:
                    Uno.Visibility = Visibility.Collapsed;
                    tres.Visibility = Visibility.Collapsed;
                    quatro.Visibility = Visibility.Collapsed;
                    cinquo.Visibility = Visibility.Collapsed;
                    des.Visibility = Visibility.Collapsed;
                    break;
                case 1:
                Uno.Visibility = Visibility.Visible;
                    tres.Visibility = Visibility.Collapsed;
                    quatro.Visibility = Visibility.Collapsed;
                    cinquo.Visibility = Visibility.Collapsed;
                    des.Visibility = Visibility.Collapsed;
                    break;
                case 2:
                    des.Visibility = Visibility.Visible;
                    Uno.Visibility = Visibility.Visible;
                    tres.Visibility = Visibility.Collapsed;
                    quatro.Visibility = Visibility.Collapsed;
                    cinquo.Visibility = Visibility.Collapsed;
                    break;
                    case 3:
                  tres.Visibility = Visibility.Visible;
                    des.Visibility = Visibility.Visible;
                    Uno.Visibility = Visibility.Visible;
                    quatro.Visibility = Visibility.Collapsed;
                    cinquo.Visibility = Visibility.Collapsed;

                    break;
                case 4:
                    quatro.Visibility = Visibility.Visible;
                    des.Visibility = Visibility.Visible;
                    tres.Visibility = Visibility.Visible;
                    Uno.Visibility = Visibility.Visible;
                    cinquo.Visibility = Visibility.Collapsed;
                    break;
                case 5:
                    cinquo.Visibility = Visibility.Visible;
                    quatro.Visibility = Visibility.Visible;
                    des.Visibility = Visibility.Visible;
                    tres.Visibility = Visibility.Visible;
                    Uno.Visibility = Visibility.Visible;
                    
                    break;

            }    
            
        }

        

        private void RentalRate_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(RentalRate.Text, "^[0-9]*$"))
            {
                MessageBox.Show("Please enter only numbers.");
                RentalRate.Text = RentalRate.Text.Remove(RentalRate.Text.Length - 1);
            }
        }
    }
}
