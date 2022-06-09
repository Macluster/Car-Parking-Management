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
using System.Windows.Media.Animation;

namespace CarParker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ContentFrame.Content = new HomePage();
            if (!System.IO.Directory.Exists("C:\\Users\\Admin\\Documents\\Carparker")) 
            System.IO.Directory.CreateDirectory("C:\\Users\\Admin\\Documents\\Carparker");


            HomeClickFlag = 1;
            HomeImage.ImageSource = new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Icons/HomeWhite.png"));

        }








       

      



      


        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
           

            this.Close();

        }

        int HomeClickFlag = 0;
        private void HomeBtn_Click(object sender, RoutedEventArgs e)
        {
           
            HomeClickFlag = 1;
            MapCreatorBtnClickFlag = 0;
            ParkingBtnClickFlag = 0;
            SettingsBtnFlag = 0;
            UserBtnFlag = 0;

            HomeImage.ImageSource = new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Icons/HomeWhite.png"));
            UserImage.ImageSource = new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Icons/User.png"));
            MapCreatorImage.ImageSource = new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Icons/Edit.png"));
            ParkingImage.ImageSource = new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Icons/Parking.png"));
            SettingsBtnImage.ImageSource = new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Icons/Settings.png"));


            //BagroundGrid.SetResourceReference(BackgroundProperty, "BagroundImage");
            Main_Grid.Background = new SolidColorBrush(Colors.White);
        

            ContentFrame.Content = new HomePage();
            //AdminBOX.Visibility = Visibility.Visible;
           // UpperFrame.Visibility = Visibility.Visible;
        }

       int  MapCreatorBtnClickFlag=0;
        private void MapCreatorBtn_Click(object sender, RoutedEventArgs e)
        {
            
            MapCreatorBtnClickFlag = 1;
            ParkingBtnClickFlag = 0;
            HomeClickFlag = 0;
             SettingsBtnFlag = 0;
            UserBtnFlag = 0;

            MapCreatorImage.ImageSource = new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Icons/EditRename.png"));
            UserImage.ImageSource = new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Icons/User.png"));
            HomeImage.ImageSource = new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Icons/Home.png"));
            ParkingImage.ImageSource = new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Icons/Parking.png"));
            SettingsBtnImage.ImageSource = new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Icons/Settings.png"));




          
            ContentFrame.Content = new CarParker_Creator(this);
        }

        int ParkingBtnClickFlag = 0;
        private void ParkingBtn_Click(object sender, RoutedEventArgs e)
        {

            ParkingBtnClickFlag = 1;
            MapCreatorBtnClickFlag = 0;
            HomeClickFlag = 0;
             SettingsBtnFlag = 0;
            UserBtnFlag = 0;

            ParkingImage.ImageSource = new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Icons/ParkingWhite.png"));
            UserImage.ImageSource = new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Icons/User.png"));
            HomeImage.ImageSource = new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Icons/Home.png"));
            MapCreatorImage.ImageSource = new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Icons/Edit.png"));
            SettingsBtnImage.ImageSource = new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Icons/Settings.png"));

            //UpperFrame.Visibility = Visibility.Hidden;

           string EntranceORExit= System.IO.File.ReadAllText("C:\\Users\\Admin\\Documents\\Carparker\\Settings.txt").Split('.')[0];

            if(EntranceORExit=="1")
            ContentFrame.Content = new Parking();
            else
            ContentFrame.Content = new ParkingExitPage();
        
        
        
        }

        int SettingsBtnFlag = 0;
        private void SettingsBtn_Click(object sender, RoutedEventArgs e)
        {
            SettingsBtnFlag = 1;
            ParkingBtnClickFlag = 0;
            MapCreatorBtnClickFlag = 0;
            HomeClickFlag = 0;
            UserBtnFlag = 0;

            SettingsBtnImage.ImageSource = new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Icons/SettingsWhite.png"));
            UserImage.ImageSource = new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Icons/User.png"));
            ParkingImage.ImageSource = new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Icons/Parking.png"));
            HomeImage.ImageSource = new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Icons/Home.png"));
            MapCreatorImage.ImageSource = new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Icons/Edit.png"));

            ContentFrame.Content = new SettingsPage();

        }

        int UserBtnFlag = 0;
        private void UserBtn_Click(object sender, RoutedEventArgs e)
        {
            UserBtnFlag = 1;
            SettingsBtnFlag = 0;
            ParkingBtnClickFlag = 0;
            MapCreatorBtnClickFlag = 0;
            HomeClickFlag = 0;

            UserImage.ImageSource = new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Icons/UserWhite.png"));
            SettingsBtnImage.ImageSource = new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Icons/Settings.png"));
            ParkingImage.ImageSource = new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Icons/Parking.png"));
            HomeImage.ImageSource = new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Icons/Home.png"));
            MapCreatorImage.ImageSource = new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Icons/Edit.png"));

            ContentFrame.Content = new AdminLoginPage(this);


        }

       

        private void HomeBtn_MouseEnter(object sender, MouseEventArgs e)
        {
            HomeImage.ImageSource=new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Icons/HomeWhite.png"));

        }

        private void HomeBtn_MouseLeave(object sender, MouseEventArgs e)
        {
            if(HomeClickFlag==0)
            HomeImage.ImageSource = new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Icons/Home.png"));
        }

        private void MapCreatorBtn_MouseEnter(object sender, MouseEventArgs e)
        {
     
            MapCreatorImage.ImageSource = new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Icons/EditRename.png"));
        }

        private void MapCreatorBtn_MouseLeave(object sender, MouseEventArgs e)
        {
            if (MapCreatorBtnClickFlag == 0)
                MapCreatorImage.ImageSource = new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Icons/Edit.png"));
        }

        private void ParkingBtn_MouseEnter(object sender, MouseEventArgs e)
        {
            ParkingImage.ImageSource = new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Icons/ParkingWhite.png"));
        }

        private void ParkingBtn_MouseLeave(object sender, MouseEventArgs e)
        {
            if(ParkingBtnClickFlag==0)
            ParkingImage.ImageSource = new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Icons/Parking.png"));
        }

      
        private void SettingsBtn_MouseEnter(object sender, MouseEventArgs e)
        {
            SettingsBtnImage.ImageSource = new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Icons/SettingsWhite.png"));
        }

        private void SettingsBtn_MouseLeave(object sender, MouseEventArgs e)
        {
            if(SettingsBtnFlag==0)
            SettingsBtnImage.ImageSource = new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Icons/Settings.png"));



        }


        private void UserBtn_MouseEnter(object sender, MouseEventArgs e)
        {
            UserImage.ImageSource = new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Icons/UserWhite.png"));
        }

        private void UserBtn_MouseLeave(object sender, MouseEventArgs e)
        {
            if (UserBtnFlag == 0)
                UserImage.ImageSource = new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Icons/User.png"));

        }
    }
}
