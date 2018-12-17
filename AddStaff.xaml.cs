using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.IO;

namespace proj2018_2019
{
    /// <summary>
    /// Logique d'interaction pour AddStaff.xaml
    /// </summary>
    public partial class AddStaff : UserControl
    {
        /*
         *2 Variable globale 
         * IFundamentalClient Client a travers laquelle je fait appel au service de IFundamentals
         * et OPenDialog qui permet d'ouvir une boite de dialogue pour choisir une photo
         */ 
        IfundamentalsClient client = new IfundamentalsClient();
        OpenFileDialog dlg = new OpenFileDialog();
        public AddStaff()
        {
            InitializeComponent();
            elipse.Name = "image_profile";//Me permet de savoir si le user a choisi une PP voir event,function Image_Click

            //voir serveur pour definition des services
            //AllAddress me permet de remplir mon Combobox d'addresse 
            ICollection<Address> AllAddress = client.GetAddresses();
            AdresseComboBox.ItemsSource = AllAddress;
            AdresseComboBox.DisplayMemberPath ="Address_Lib";
        }

        //Event:valider Form
        //Outcome:enregistrement info si reussi reInit formulaire si rater show Message box
        private void Valider_Click(object sender, RoutedEventArgs e)
        {
            //je recupere la photo de profil et je convert en tableau de byte afin de stocker sur la base
            FileStream fileStream = new FileStream(dlg.FileName, FileMode.Open, FileAccess.Read);
            byte[] bytes = new byte[fileStream.Length];
            fileStream.Read(bytes, 0, (int)fileStream.Length);
            fileStream.Close();

            //je recuperer les donnees du Formulaire
            Staff s = new Staff();
            s.FirstName = FirstNameTextBox.Text;
            s.LastName = LastNameTextBox.Text;
            s.Email = MailTextBox.Text;
            s.Address_ID = ((Address)AdresseComboBox.SelectedItem).Address_ID;
            s.UserName = UseNameTextBox.Text;
            s.Password = PasswordTextBox.Password.ToString();
            s.Picture = bytes;

            //Appel du service Client
            string v= client.AddStaff2(s);
           MessageBox.Show(v);
        }

        //Evenemet click sur la photo de profil
        /*
         *Outcome==ouverture boite de dialogue pour choisir Photo
         */
        private void Image_Click(object sender, MouseButtonEventArgs e)
        {
            
            dlg.DefaultExt = ".png";//Default extension
            dlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";//filter Extension
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                image_profile.ImageSource = new BitmapImage(new Uri(dlg.FileName, UriKind.Relative));
                elipse.RenderTransform = new ScaleTransform(1.1, 1.1);
                elipse.Name = "Image-Choisi";//le user a choisi
            }    

        }

        //event Image Hoover
        //Outcome:Nice Animation Scallimg picture change etc
        private void image_Hover(object sender, MouseEventArgs e)
        {

            if (elipse.Name.Equals("image_profile"))
            {
                image_profile.ImageSource = new BitmapImage(new Uri(@"C:\Users\USER\source\repos\proj2018-2019\proj2018-2019\add-user (2).png", UriKind.Relative));
                elipse.RenderTransform = new ScaleTransform(1.1, 1.1);
            }
        }

        //event image lost Focus 
        //Outcome: reset default imagge size and Source
        private void Image_Leave(object sender, MouseEventArgs e)
        {
            if(elipse.Name.Equals("image_profile"))
            {
                image_profile.ImageSource = new BitmapImage(new Uri(@"C:\Users\USER\source\repos\proj2018-2019\proj2018-2019\man (2).png", UriKind.Relative));
                elipse.RenderTransform = new ScaleTransform(1, 1);
            }
            
        }

        //A gerer Pas Urgent
        public void AddAddress(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Ow Noooooo");
        }

        
    }
}
