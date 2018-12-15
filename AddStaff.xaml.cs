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
        IfundamentalsClient client = new IfundamentalsClient();
        OpenFileDialog dlg = new OpenFileDialog();
        public AddStaff()
        {
            InitializeComponent();
            elipse.Name = "image_profile";
            // 
           ICollection<Address> fff = client.GetAddresses();
            AdresseComboBox.ItemsSource = fff;
            AdresseComboBox.DisplayMemberPath ="Address_Lib";
        }

        private void FirstNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
           
        }

        private void Valider_Click(object sender, RoutedEventArgs e)
        {
            /*GridIF.RenderTransform = new ScaleTransform(1.2, 1.2);
            FirstNameTextBox.RenderTransform= new ScaleTransform(1.2, 1.2);*/
            FileStream fileStream = new FileStream(dlg.FileName, FileMode.Open, FileAccess.Read);
            byte[] bytes = new byte[fileStream.Length];
            fileStream.Read(bytes, 0, (int)fileStream.Length);
            fileStream.Close();
            Staff s = new Staff();
            s.FirstName = FirstNameTextBox.Text;
            s.LastName = LastNameTextBox.Text;
            s.Email = MailTextBox.Text;
            s.Address_ID = ((Address)AdresseComboBox.SelectedItem).Address_ID;
            s.UserName = UseNameTextBox.Text;
            s.Password = PasswordTextBox.Password.ToString();
            s.Picture = bytes;
            string v= client.AddStaff2(s);
           MessageBox.Show(v);
        }

        private void Image_Click(object sender, MouseButtonEventArgs e)
        {
            
            dlg.DefaultExt = ".png";
            dlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                image_profile.ImageSource = new BitmapImage(new Uri(dlg.FileName, UriKind.Relative));
                elipse.RenderTransform = new ScaleTransform(1.1, 1.1);
                elipse.Name = "ddd";
            }    

        }

     
        private void Image_Leave(object sender, MouseEventArgs e)
        {
            if(elipse.Name.Equals("image_profile"))
            {
                image_profile.ImageSource = new BitmapImage(new Uri(@"C:\Users\USER\source\repos\proj2018-2019\proj2018-2019\man (2).png", UriKind.Relative));
                elipse.RenderTransform = new ScaleTransform(1.1, 1.1);
            }
            
        }

        public void AddAddress(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Ow Noooooo");
        }

        private void image_Hover(object sender, MouseEventArgs e)
        {

             if(elipse.Name.Equals("image_profile"))
            {
                image_profile.ImageSource = new BitmapImage(new Uri(@"C:\Users\USER\source\repos\proj2018-2019\proj2018-2019\add-user (2).png", UriKind.Relative));
                elipse.RenderTransform = new ScaleTransform(1.1, 1.1);
            }
        }
    }
}
