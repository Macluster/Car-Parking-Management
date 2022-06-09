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

namespace CarParker
{
    /// <summary>
    /// Interaction logic for AdminLoginPage.xaml
    /// </summary>
    public partial class AdminLoginPage : Page
    {
        string Username = "User";
        string Password = "password";

        MainWindow MainOBJ;
        public AdminLoginPage()
        {
            InitializeComponent();
        }

        public AdminLoginPage(MainWindow MainOBJ)
        {
            this.MainOBJ = MainOBJ;
            InitializeComponent();
        }

        private void AdminLoginButton_Click(object sender, RoutedEventArgs e)
        {
           
           if(AdminUsername.Text==Username)
           {

                if (AdminPassword.Text.ToString() == Password)
                {
                    MainOBJ.ContentFrame.Content = new Admin();
                }
                else
                    MessageBox.Show("Incorrect Password");


            }
           else
           {

                MessageBox.Show("Incorrect Username");
           }
            
           
        }
    }
}
