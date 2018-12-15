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
    /// Logique d'interaction pour AjouterStore.xaml
    /// </summary>
    public class StaffL
    {
        public Staff Staff { get; set; }
        public CheckBox boole { get; set; }
    }
    public partial class AjouterStore : UserControl
    {
        private string Manager_Id { get; set; }
        public int compteur { get; set; }
        public IfundamentalsClient Client { get; set; }
        public AjouterStore()
        {
            Client = new IfundamentalsClient();
            InitializeComponent();
            List<StaffL> listL = new List<StaffL>();

            List<Staff> listS = Client.GetStaffs().ToList<Staff>();

            foreach(Staff k in listS)
            {
                StaffL v32 = new StaffL();
                v32.Staff = k;
                v32.boole = new CheckBox();
                v32.boole.IsChecked=true;
                listL.Add(v32);
            }

            DeleteManager.Visibility = Visibility.Collapsed;
            List1.ItemsSource = listL;
           foreach(Staff s in listS)
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
                
                image_List1.ImageSource = new BitmapImage(new Uri(@"C:\Users\USER\Pictures\W3.CSS_files\"+s.Staff.Staff_ID +".jpg", UriKind.Relative));
                List1.SelectedIndex = -1;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Manager_Id = IdINfo.Text;
            ManagerButton.Visibility = Visibility.Collapsed;
            DeleteManager.Visibility = Visibility.Visible;
        }

        private void DeleteManager_Click(object sender, RoutedEventArgs e)
        {
            ManagerButton.Visibility = Visibility.Visible;
            DeleteManager.Visibility = Visibility.Collapsed;
        }

        private void Valider_Click(object sender, RoutedEventArgs e)
        {
            for(int i=0; i< Client.GetStaffs().ToList<Staff>().Count;i++)
            {
                ItemCollection vv=List1.Items;
                vv.GetItemAt(i);
                   
            }
        }
    }
}
