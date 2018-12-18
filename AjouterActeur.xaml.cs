using proj2018_2019.ServiceReference2;
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
    /// Logique d'interaction pour AjouterActeur.xaml
    /// </summary>
    /// 
    public class FilmF
    {
        public Film Film { get; set; }
        public Boolean boole { get; set; }
    }
    public partial class AjouterActeur : UserControl
    {
        public ThiouneServiceClient Client=new ThiouneServiceClient();
        private List<FilmF> listF { get; set; }
        public AjouterActeur()
        {
            InitializeComponent();
            listF = new List<FilmF>();

            foreach(Film F in Client.GetFilms())
            {
                FilmF V32 = new FilmF();
                V32.boole = false;
                V32.Film = F;

                listF.Add(V32);
            }
            List1.ItemsSource=listF;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Actor A = new Actor();
            A.Firstname = FirstNameTextBox.Text;
            A.Lastname = LastNameTextBox.Text;
            List<Film> f = new List<Film>();
            listF=listF.Where(X => X.boole == true).ToList();
            foreach(FilmF f1 in listF)
            {
                f.Add(f1.Film);
            }
            Client.AddActors(A,f.ToArray());
            

        }
    }
}
