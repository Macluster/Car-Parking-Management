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
using System.Threading;
namespace CarParker
{
    /// <summary>
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Page
    {
        public Admin()
        {

            InitializeComponent();
            AdminContentFrame.Source = new Uri("Admin_Pages/Analytics.xaml", UriKind.RelativeOrAbsolute);
        }


        public void MenuControlTabMove(Button NextButton)
        {

            int MenuTabLeft = Convert.ToInt32(MenuTabControlBorder.Margin.Left);
            int NextButtonLeft = Convert.ToInt32(NextButton.Margin.Left);
            System.Threading.Thread movethread = new System.Threading.Thread(() =>
            {
                int i = 0;

                if (MenuTabLeft < NextButtonLeft)
                {

                    i = MenuTabLeft;
                    while (i < NextButtonLeft - 7)
                    {
                        Thread.Sleep(1);
                        i = i + 2;
                        Dispatcher.Invoke(() => { MenuTabControlBorder.Margin = new Thickness(i, 58, 0, 0); });

                    }
                }
                else
                {

                    i = MenuTabLeft;
                    while (i > NextButtonLeft - 4)
                    {
                        Thread.Sleep(1);
                        i = i - 2;
                        Dispatcher.Invoke(() => { MenuTabControlBorder.Margin = new Thickness(i, 58, 0, 0); });

                    }


                }



            });
            movethread.Start();

        }

        private void AnalyticsBtn_Click(object sender, RoutedEventArgs e)
        {
            MenuControlTabMove(AnalyticsBtn);
            AdminContentFrame.Source = new Uri("Admin_Pages/Analytics.xaml", UriKind.RelativeOrAbsolute);
        }

        private void ReportBtn_Click(object sender, RoutedEventArgs e)
        {


            MenuControlTabMove(ReportBtn);
            AdminContentFrame.Source = new Uri("Admin_Pages/ReportPage.xaml", UriKind.RelativeOrAbsolute);


        }

        private void ProfileBtn_Click(object sender, RoutedEventArgs e)
        {
            MenuControlTabMove(ProfileBtn);
        }
    }
}
