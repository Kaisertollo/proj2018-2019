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
using System.Windows.Forms;
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
    
    /// Class StaffL Allow to add a binding proprety(StaffL.boole) to my Checkbox'isChecked Method
    public class StaffL
    {
        public Staff Staff { get; set; }
        public Boolean boole { get; set; }
    }

  
    public partial class AjouterStore : System.Windows.Controls.UserControl
    {
        private int Manager_Id { get; set; }
        public IfundamentalsClient Client { get; set; }
        private List<StaffL> listL { get; set; }
        public AjouterStore()
        {

           /// List<int> cc = new List<int>();
           /// cc.int
            /// IfundamentalClient Still the Same Use allow me to interact with my services
            Client = new IfundamentalsClient();
            InitializeComponent();

            //2 List ListL is use to fill my table and ListS is use to fill List[i].Staff that's what i'm doing inside the foreach
             listL = new List<StaffL>();
            List<Staff> listS = Client.GetStaffs().ToList<Staff>();
            foreach(Staff k in listS)
            {
                StaffL v32 = new StaffL();
                v32.Staff = k;
              
                v32.boole=false;
                listL.Add(v32);
            }
            List1.ItemsSource = listL;

            //voir serveur pour definition des services
            //AllAddress me permet de remplir mon Combobox d'addresse 
            ICollection<Address> AllAddress = Client.GetAddresses();
            AdresseComboBox.ItemsSource = AllAddress;
            AdresseComboBox.DisplayMemberPath = "Address_Lib";


            //Create the Staff Profile Photo Inside A folder
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

      
        //Event:the List Selection Changed
        //outcome:Dispay the about the Selectionned Row for a better looking
        private void list1Changed(object sender, SelectionChangedEventArgs e)
        {
            if (List1.SelectedIndex != -1)
            {
                StaffL s = (StaffL)List1.SelectedItem;
                
                image_List1.ImageSource = new BitmapImage(new Uri(@"C:\Users\USER\Pictures\W3.CSS_files\"+s.Staff.Staff_ID +".jpg", UriKind.Relative));
                IdINfo.Text = ""+s.Staff.Staff_ID;
                Prenom.Text = s.Staff.FirstName;
                Nom.Text = s.Staff.LastName;
                List1.SelectedIndex = -1;
            }
        }

        //Choosing a Store's Manager
        private void Button_Click(object sender, RoutedEventArgs e)
        {
          
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = System.Windows.Forms.MessageBox.Show("Choisir Comme Manager Boutique", "Changer Managger", buttons);
            if (result == DialogResult.Yes)
            {
                Manager_Id = Int32.Parse(IdINfo.Text);
                ManagerButton.Visibility = Visibility.Collapsed;
                DeleteManager.Visibility = Visibility.Visible;
            }
        }
        //Delete the Choosen  Store's Manager
        private void DeleteManager_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = System.Windows.Forms.MessageBox.Show("Attention vous allez changer le manager deja choisi","Changer Manager",buttons);
            if (result == DialogResult.Yes)
            {
                Manager_Id = 0;
                ManagerButton.Visibility = Visibility.Visible;
                DeleteManager.Visibility = Visibility.Collapsed;
            }

             ;
        }

        //Add the Store And Update Staffs
        private void Valider_Click(object sender, RoutedEventArgs e)
        {
            Store st = new Store();
            st.Address_ID = ((Address)AdresseComboBox.SelectedItem).Address_ID;
            st.Manager_Staff_ID = Manager_Id;
            Client.AddStores(st);
            foreach (StaffL s in listL)
            {
                if (s.boole)
                    Client.UpdateStaff(s.Staff.Staff_ID, Client.LastId());
            }
        }
    }
}
