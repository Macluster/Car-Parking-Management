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
using System.IO;

using System.Threading;

namespace CarParker
{
    /// <summary>
    /// Interaction logic for SettingsPage.xaml
    /// </summary>
    public partial class SettingsPage : Page
    {
        public int CostPerHour = 20;
        public SettingsPage()
        {

       

            InitializeComponent();

            ReadSettings();

        }

         
        public void ReadSettings()
        {
            if (File.Exists("C:\\Users\\Admin\\Documents\\Carparker\\Settings.txt") == true)
            {

                string str = File.ReadAllText("C:\\Users\\Admin\\Documents\\Carparker\\Settings.txt");
                string[] array = str.Split('.');

                if (array[0] == "1")
                {
                    EntranceCheckbox.IsChecked = true;
                }
                else
                    ExitCheckbox.IsChecked = true;

                CurrentmapName.Content = array[1];




                /////chargingTime///////
                ChargingTimeValue.Content = array[2];
                /////ChargePerTime////////
                ChargePerTimeValue.Content = array[3];




            }
            else
            {

                File.WriteAllText("C:\\Users\\Admin\\Documents\\Carparker\\Settings.txt", "1.Mapname.Hour.20");
            }
        }

        


        private void EntranceCheckbox_Checked(object sender, RoutedEventArgs e)
        {
            ExitCheckbox.IsChecked = false;




        }

        private void ExitCheckbox_Checked(object sender, RoutedEventArgs e)
        {
            EntranceCheckbox.IsChecked = false;

        }

        private void ChangeMapBtn_Click(object sender, RoutedEventArgs e)
        {
           MapDialouge();
        }



        private void MapDialouge()
        {



            


            //Finding all files in  a path saving them in an array
            string[] files = Directory.EnumerateFiles("C:\\Users\\Admin\\Documents\\Carparker").ToArray();



            int NoRows = 3;
            if (files.Length > 9)
                NoRows = files.Length / 3;



            //Parent Grid
            GridAPI G = new GridAPI(0, 0, 0, 700);
            G.AddRowColumn(NoRows, 3, 165, 0);
            G.Grid1.Background = new SolidColorBrush(Colors.White);


            //Close Button Image
            BitmapImage btm2 = new BitmapImage(new Uri("Assets/Close.png", UriKind.Relative));
            Image img2 = new Image();
            img2.Source = btm2;
            img2.Stretch = Stretch.UniformToFill;




            ScrollViewer Scrol = new ScrollViewer();
            Scrol.Height = 500;
            Scrol.Background = new SolidColorBrush(Colors.White);
            Scrol.Width = 700;
            Scrol.Content = G.Grid1;
            Scrol.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
            Scrol.Opacity = 1;




            ImageBrush brush = new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Assets/MapImage2.jpg")));


            //Border OF this window
            Border Borderr = new Border();
            Borderr.CornerRadius = new CornerRadius(20);
            Borderr.BorderThickness = new Thickness(5);
            Borderr.Height = 515;
            Borderr.Width = 715;
            Borderr.Margin = new Thickness(600, 500, 0, 0);
            Borderr.Child = Scrol;
            Borderr.Background = new SolidColorBrush(Colors.White);
            Borderr.BorderBrush = new SolidColorBrush(Colors.White);



            //Animation
            Borderr.Width = 0;
            Borderr.Height = 0;
            int TemBorderWidth = 0;
            Thread AnimationThread = new Thread(() =>
            {
                Dispatcher.Invoke(() => { TemBorderWidth = Convert.ToInt32(Borderr.Width); });
                for (int i = 0; TemBorderWidth < 715; i++)
                {
                    Thread.Sleep(1);
                    Dispatcher.Invoke(() =>
                    {
                        Borderr.Width += 2;
                        TemBorderWidth += 2;
                        Borderr.Margin = new Thickness(Borderr.Margin.Left - 2, Borderr.Margin.Top - 1.5, 0, 0);
                        Borderr.Height += 1.5;

                    });
                }
            });
            AnimationThread.Start();




            //Close Button
            Button MapDialogCloseBtn = new Button();
            MapDialogCloseBtn.Width = 30;
            MapDialogCloseBtn.Height = 30;
            MapDialogCloseBtn.Click += async (semder, args) => { MainGrid.Children.Remove(Borderr);};
            MapDialogCloseBtn.HorizontalAlignment = HorizontalAlignment.Right;
            MapDialogCloseBtn.VerticalAlignment = VerticalAlignment.Top;
            MapDialogCloseBtn.Content = img2;
            MapDialogCloseBtn.Background = new SolidColorBrush(Colors.Transparent);
            MapDialogCloseBtn.BorderThickness = new Thickness(0);
            G.AddControl(MapDialogCloseBtn, 0, 3);


            //Map Buttons
            Button MapBtn;
            int j = 0, k = 0;
            for (int i = 0; i < files.Length; i++)
            {
                MapBtn = new Button();
                MapBtn.Content = files[i].Substring(35);
                MapBtn.VerticalContentAlignment = VerticalAlignment.Bottom;
                MapBtn.Foreground = new SolidColorBrush(Colors.White);
                MapBtn.Height = 130;
                MapBtn.Width = 200;
                MapBtn.Background = brush;
                MapBtn.VerticalAlignment = VerticalAlignment.Bottom;
                MapBtn.Click += async (sender2, args) =>
                {


                    MainGrid.Children.Remove(Borderr);
                    CurrentmapName.Content = ((Button)sender2).Content.ToString().Split('.')[0];
                 

                   
               

                };
                G.AddControl(MapBtn, j, k);
                k++;
                if (k > 2)
                {
                    j++;
                    k = 0;
                }


            }


            MainGrid.Children.Add(Borderr);





            //  LoadMap(FileName);




        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            string TollSatus;
            if (EntranceCheckbox.IsChecked == true)
                TollSatus = "1";
             else
                TollSatus = "0";

            File.WriteAllText("C:\\Users\\Admin\\Documents\\Carparker\\Settings.txt", TollSatus + "." + CurrentmapName.Content+"."+ChargingTimeValue.Content+"."+ChargePerTimeValue.Content);

        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ChargePerTimeChangeButton_Click(object sender, RoutedEventArgs e)
        {

            TextBox TB = new TextBox();
            TB.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#495464"));
            TB.Height = 20;
            TB.Width = 70;
            TB.Margin = new Thickness(ChargePerTimeChangeButton.Margin.Left+ChargePerTimeChangeButton.Width+100, ChargePerTimeChangeButton.Margin.Top, 0, 0);
            TB.PreviewKeyUp += (sender1, args1) => { if (args1.Key == Key.Enter) { ChargePerTimeValue.Content = TB.Text; MainGrid.Children.Remove(TB); }  };
            MainGrid.Children.Add(TB);

        }

        private void ChargeUnitChangeButton_Click(object sender, RoutedEventArgs e)
        {
            string[] st = { "Hour", "HalfHour", "" };
            ListBox LB = new ListBox();
            LB.Background= new SolidColorBrush((Color)ColorConverter.ConvertFromString("#495464"));
            LB.Width = 70;
            LB.Height = 100;
            LB.ItemsSource = st;
            LB.Margin = new Thickness(ChargingTimeChangeButton.Margin.Left+ChargingTimeChangeButton.Width+100, ChargingTimeChangeButton.Margin.Top, 0, 0);
            LB.MouseLeftButtonUp += (sender1, args1) => { ChargingTimeValue.Content = LB.SelectedItem; MainGrid.Children.Remove(LB);  };
            MainGrid.Children.Add(LB);

        }




    }
}
