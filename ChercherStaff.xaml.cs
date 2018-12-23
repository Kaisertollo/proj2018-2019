using proj2018_2019.ServiceReference1;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Logique d'interaction pour ChercherStaff.xaml
    /// </summary>
  
    public partial class ChercherStaff : UserControl
    {
        public IfundamentalsClient Client { get; set; }
        private List<StaffL> listL { get; set; }
        public ChercherStaff()
        {
            InitializeComponent();
            Client = new IfundamentalsClient();
            listL = new List<StaffL>();
            List<Staff> listS = Client.GetStaffs().ToList<Staff>();
            foreach (Staff k in listS)
            {
                StaffL v32 = new StaffL();
                v32.Staff = k;

                v32.boole = false;
                listL.Add(v32);
            }
            List1.ItemsSource = listL;
            foreach (Staff s in listS)
            {
                if (s.Picture != null)
                {
                    FileStream fs = new FileStream(@"C:\Users\USER\Pictures\W3.CSS_files\" + s.Staff_ID + ".jpg", FileMode.Create);
                    fs.Write(s.Picture, 0, s.Picture.Length);
                    fs.Close();
                }
            }
        }
        private void list1Changed(object sender, SelectionChangedEventArgs e)
        {
            if (List1.SelectedIndex != -1)
            {
                StaffL s = (StaffL)List1.SelectedItem;

                image_List1.ImageSource = new BitmapImage(new Uri(@"C:\Users\USER\Pictures\W3.CSS_files\" + s.Staff.Staff_ID + ".jpg", UriKind.Relative));
                if (s.Staff.Active == 1)
                {
                    Debloquer.Visibility = Visibility.Collapsed;
                    Bloquer.Visibility = Visibility.Visible;
                }
                else
                {
                    Debloquer.Visibility = Visibility.Visible;
                    Bloquer.Visibility = Visibility.Collapsed;
                }
                IdINfo.Text = "" + s.Staff.Staff_ID;
                Prenom.Text = s.Staff.FirstName;
                Nom.Text = s.Staff.LastName;
                //List1.SelectedIndex = -1 ;
               
            }
        }

        private void Debloquer_Click(object sender, RoutedEventArgs e)
        {
            Client.DeBlock(Int32.Parse(IdINfo.Text));
            StaffL s = (StaffL)List1.SelectedItem;
            s.Staff.Active = 1;
            Debloquer.Visibility = Visibility.Collapsed;
            Bloquer.Visibility = Visibility.Visible;
          
        }

        private void Bloquer_Click(object sender, RoutedEventArgs e)
        {
            Client.Block(Int32.Parse(IdINfo.Text));
            StaffL s = (StaffL)List1.SelectedItem;
            s.Staff.Active = 0;
            Debloquer.Visibility = Visibility.Visible;
            Bloquer.Visibility = Visibility.Collapsed;
        }
    }
}
