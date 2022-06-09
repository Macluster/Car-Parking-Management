using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;


namespace CarParker
{
    /// <summary>
    /// Interaction logic for ParkingExitPage.xaml
    /// </summary>
    public partial class ParkingExitPage : Page
    {
       
        public int chargePerTime = 10;
        public int TotalCost = 0;
        public string ChargingTime = "";
        public string CurrentMapName;


        Thread StateRefreshThread; bool StateRefreshThreadState = false;
        public ParkingExitPage()
        {
            InitializeComponent();



            if (ReadSettings() != null)
            {
                Thread loadMapthread = new Thread(() => { this.LoadMap(ReadSettings()); });
                loadMapthread.Start();
            }



            StateRefreshThread = new Thread(() => { Thread.Sleep(3000); StateRefresh(); });
            StateRefreshThread.Start();



        }


        public string ReadSettings()
        {

            if (!System.IO.File.Exists("C:\\Users\\Admin\\Documents\\Carparker\\Settings.txt"))
            {
                OpenMapDailaouge();

            }
            else
            {
                string path = "C:\\Users\\Admin\\Documents\\Carparker\\Settings.txt";
                CurrentMapName = System.IO.File.ReadAllText(path).Split('.')[1];
                chargePerTime = Convert.ToInt32(System.IO.File.ReadAllText(path).Split('.')[3]);
                ChargingTime = System.IO.File.ReadAllText(path).Split('.')[2];



            }
            return CurrentMapName;

        }

        
        public UiElementsForParking Ui=new UiElementsForParking();
    

      

        public void LoadMap(String FileName)
        {

           string path ="C:\\Users\\Admin\\Documents\\Carparker\\Config.txt";
            System.IO.File.WriteAllText(path, CurrentMapName + "*");




            MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=carparking;password=Macluster@123");
            con.Open();

            // Extract Quad Data
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "select * from " + FileName + " where Id=-1 ";
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {

                Dispatcher.Invoke(() => 
                {
                    Ui.Createworkspace(this, reader.GetInt32(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(5));

                });
             


            }
            reader.Close();


            cmd = con.CreateCommand();
            cmd.CommandText = "select * from " + FileName + " where Id=0";
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {

                Dispatcher.Invoke(() => 
                {
                    Ui.CreateQuad(this, reader.GetInt32(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(5), reader.GetInt32(6));

                });
             

            }
            reader.Close();



            //Extract Pslot Data
            cmd = con.CreateCommand();
            cmd.CommandText = "select * from " + FileName + " where Id=1";
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {

                Dispatcher.Invoke(() => { Ui.CreatePslot(this, reader.GetInt32(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(5), reader.GetInt32(6), reader.GetString(7), reader.GetString(8), FileName + "XXX"); });
               


            }
            reader.Close();



            //Extract Rod Data
            cmd = con.CreateCommand();
            cmd.CommandText = "select * from " + FileName + " where Id=2";
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Dispatcher.Invoke(() =>
                {
                    Ui.CreateRoad(this, reader.GetInt32(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(5), reader.GetInt32(6), reader.GetString(7));
                });
              

            }
            reader.Close();



            //Extract HRod Data
            cmd = con.CreateCommand();
            cmd.CommandText = "select * from " + FileName + " where Id=3";
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Dispatcher.Invoke(() =>
                {
                    Ui.CreateHroad(this, reader.GetInt32(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(5), reader.GetInt32(6), reader.GetString(7));
                });
             

            }
            reader.Close();



            cmd = con.CreateCommand();
            cmd.CommandText = "select * from " + FileName + " where Id=4";
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Dispatcher.Invoke(() => 
                {
                    Ui.CreateTall(this, reader.GetInt32(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(5), reader.GetInt32(6), reader.GetString(7));
                });
            

            }
            reader.Close();

         

            cmd = con.CreateCommand();
            cmd.CommandText = "select * from " + FileName + " where Id=5";
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Dispatcher.Invoke(() =>
                {
                    Ui.CreateArrow(this, reader.GetInt32(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(5), reader.GetInt32(6), reader.GetString(7));
                });
              

            }
            reader.Close();

            cmd = con.CreateCommand();
            cmd.CommandText = "select * from " + FileName + " where Id=6";
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Dispatcher.Invoke(() => 
                {
                    Ui.CreateConnector(this, reader.GetInt32(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(5), reader.GetInt32(6), reader.GetString(7));
                });
               

            }
            reader.Close();

            con.Close();


          





        }


        private void OpenMapDailaouge()
        {



            Scrol1Canvas.Opacity = 0.2;
         ///   OpenMapBtn.Opacity = 0.2;
        //    FreeSlotInfoGrid.Opacity = 0.2;




            string[] files =System.IO. Directory.EnumerateFiles("C:\\Users\\Admin\\Documents\\Carparker").ToArray();



            int NoRows = 3;
            if (files.Length > 9)
                NoRows = files.Length / 3;




            GridAPI G = new GridAPI(0, 0, 0, 700);
            G.AddRowColumn(NoRows, 3, 165, 0);

            G.Grid1.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#194350"));

            BitmapImage btm2 = new BitmapImage(new Uri("Assets/Close.png", UriKind.Relative));
            Image img2 = new Image();
            img2.Source = btm2;
            img2.Stretch = Stretch.UniformToFill;




            ScrollViewer Scrol = new ScrollViewer();
            Scrol.Height = 500;
            Scrol.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#194350"));
            Scrol.Width = 700;
            Scrol.Content = G.Grid1;
            Scrol.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
            Scrol.Opacity = 0.5;



            Border Borderr = new Border();
            Borderr.CornerRadius = new CornerRadius(20);
            Borderr.BorderThickness = new Thickness(5);
            Borderr.Height = 515;
            Borderr.Width = 715;
            Borderr.Margin = new Thickness(250, 150, 0, 0);
            Borderr.Child = Scrol;
            Borderr.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#194350"));
            Borderr.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#194350"));

            Button MapDialogCloseBtn = new Button();
            MapDialogCloseBtn.Width = 30;
            MapDialogCloseBtn.Height = 30;
            MapDialogCloseBtn.Click += async (semder, args) => { MainGrid.Children.Remove(Borderr); Scrol1Canvas.Opacity = 1; };
            MapDialogCloseBtn.HorizontalAlignment = HorizontalAlignment.Right;
            MapDialogCloseBtn.VerticalAlignment = VerticalAlignment.Top;
            MapDialogCloseBtn.Content = img2;
            MapDialogCloseBtn.Background = new SolidColorBrush(Colors.Transparent);
            MapDialogCloseBtn.BorderThickness = new Thickness(0);
            G.AddControl(MapDialogCloseBtn, 0, 3);


            Button MapBtn;
            int j = 0, k = 0;
            for (int i = 0; i < files.Length; i++)
            {
                MapBtn = new Button();
                MapBtn.Content = files[i].Substring(35);
                MapBtn.Height = 130;
                MapBtn.Width = 200;
                MapBtn.Background = new SolidColorBrush(Colors.CadetBlue);
                MapBtn.VerticalAlignment = VerticalAlignment.Bottom;
                MapBtn.Click += async (sender2, args) =>
                {


                    MainGrid.Children.Remove(Borderr);
                    CurrentMapName = ((Button)sender2).Content.ToString().Split('.')[0];
                    LoadMap(((Button)sender2).Content.ToString().Split('.')[0]);
                 
                    Scrol1Canvas.Opacity = 1;
                   // OpenMapBtn.Opacity = 1;
                   // FreeSlotInfoGrid.Opacity = 1;
                   // FreeSlotFinder();

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
            Grid.SetColumnSpan(Borderr, 10);
            Grid.SetRowSpan(Borderr, 7);





            //  LoadMap(FileName);




        }
        public void StateRefresh()
        {


            MySqlConnection con2 = new MySqlConnection("server=localhost;user id=root;database=carparking;password=Macluster@123");
            MySqlCommand cmd;
            MySqlDataReader dr;


            int value = 0;
            string query;

            con2.Open();
            while (!StateRefreshThreadState)
            {

                Thread.Sleep(1000);
                Dispatcher.Invoke(() =>
                {
                    for (int i = 0; i < Ui.NoOfPakingSlot; i++)
                    {

                        value = 0;
                        query = "select state from " + CurrentMapName + "XXX" + " where id=" + i.ToString();
                        cmd = new MySqlCommand(query, con2);
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {

                            value = dr.GetInt32(0);
                        }


                        if (value == 1)
                        {
                            ((Border)Ui.Pslot[i].Children[0]).Background = new SolidColorBrush(Colors.Red);
                        }
                        else
                        {
                            ((Border)Ui.Pslot[i].Children[0]).Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#435560"));
                        }
                        dr.Close();
                    }
                });

            }

            con2.Close();



        }

        private void FreeTheSlotBtn_Click(object sender, RoutedEventArgs e)
        {

            ParkingDatabase Databse = new ParkingDatabase();

            for (int i = 0; i < Ui.NoOfPakingSlot; i++)
            {
                if ((string)((Label)(Ui.Pslot[i].Children[3])).Content == Sloteditor.Text)
                {
                    if (Databse.isSlotFree(i, CurrentMapName + "XXX") == 1)
                    {
                        
                        Databse.Update(i, 1, CurrentMapName + "XXX");
                        break;

                    }
                }

            }



            CustomerDatabase CD = new CustomerDatabase();
            CD.UpdateEtime(ExitTimeLabel.Content.ToString(), Sloteditor.Text);

            CD.UpdateFee(CostLabel.Content.ToString().Split(' ')[0], Sloteditor.Text);





        }


        public int ShowMapBtnFlag = 0;
        private void ShowMapBtn_Click(object sender, RoutedEventArgs e)
        {

           
             

                if (ShowMapBtnFlag == 0)
                {
                    ShowMapBtn.Content = "Hide Map";
                    System.Windows.Media.Animation.DoubleAnimation Anime = new System.Windows.Media.Animation.DoubleAnimation();
                    Anime.From = 0;
                    Anime.To = 650;
                    Anime.Duration = TimeSpan.FromSeconds(1);
                    ScrollView.BeginAnimation(HeightProperty, Anime);
                    ShowMapBtnFlag = 1;

                }
                else if (ShowMapBtnFlag == 1)
                {
                    ShowMapBtn.Content = "Show Map";
                    System.Windows.Media.Animation.DoubleAnimation Anime2 = new System.Windows.Media.Animation.DoubleAnimation();
                    Anime2.From = 650;
                    Anime2.To = 0;
                    Anime2.Duration = TimeSpan.FromSeconds(2);
                    ScrollView.BeginAnimation(HeightProperty, Anime2);
                    ShowMapBtnFlag = 0;

                }


         
         


        }
        public double SCaleValue = 0.0;
        public ScaleTransform S = new ScaleTransform();
        private void MainGrid_PreviewKeyDown(object sender, KeyEventArgs e)
        {

            if ((Keyboard.Modifiers == ModifierKeys.Control) && (e.Key == Key.Z))
            {

                //S.CenterX = (Ui.CurrentQuad.Margin.Left + (Ui.CurrentQuad.Margin.Left + Ui.CurrentQuad.Width)) / 2;
                //S.CenterY = Ui.CurrentQuad.Margin.Top;
                S.ScaleX = S.ScaleX + 0.1;
                S.ScaleY = S.ScaleY + 0.1;
                Ui.Workspace.RenderTransform = S;


            }
            if ((Keyboard.Modifiers == ModifierKeys.Control) && (e.Key == Key.X))
            {

                //S.CenterX = (Ui.CurrentQuad.Margin.Right + (Ui.CurrentQuad.Margin.Right + Ui.CurrentQuad.Width)) / 2;
                //S.CenterY = Ui.CurrentQuad.Margin.Top;
                S.ScaleX = S.ScaleX - 0.1;
                S.ScaleY = S.ScaleY - 0.1;
                Ui.Workspace.RenderTransform = S;


            }

        }

        string ParkingTime;
        string ExitTime;
        private void Sloteditor_TextChanged(object sender, TextChangedEventArgs e)

        {
            DateTime dt = DateTime.Now;

            CustomerDatabase CD = new CustomerDatabase();

               ParkingTime = CD.GetParkingTime(Sloteditor.Text).ToString();
               ExitTime = dt.ToLongTimeString().ToString();

            ParkedTimeLabel.Content = ParkingTime;
            ExitTimeLabel.Content = ExitTime;
            //CustomerNumberLabel.Content = CD.GetCustomerNumber(Sloteditor.Text).ToString(); 

            string[] Parray = ParkingTime.Split(':');

            string[] Earray = ExitTime.Split(':');




            int ChargeInHour = 0;
            int ChargeInHalfHour = 0;
            
            int HourHand;
            int MinuteHand;

            if (Parray[0] != "")
            {
                HourHand= Convert.ToInt32(Earray[0].ToString()) - Convert.ToInt32(Parray[0].ToString());
                MinuteHand = Convert.ToInt32(Earray[1].ToString()) - Convert.ToInt32(Parray[1].ToString());

                TimeTakeValue.Content = ""+HourHand + ":" + MinuteHand;
                if (ChargingTime == "Hour")
                    FindChargeInHour(HourHand, MinuteHand, 0);
                else
                    FindChargeInHalfHour(HourHand, MinuteHand, 0);


            }

            
             



        }


        public void FindChargeInHour(int H,int M,int ChargeOption)
        {
            //Charge in time
            if (ChargeOption == 0)
            TotalCost = (H + 1) * chargePerTime;
               
            
            //Charge in time exceeding
            if(ChargeOption==1)
            TotalCost = H * chargePerTime;

           
            
            CostLabel.Content = TotalCost+" Rs";


        }

        public void FindChargeInHalfHour(int H,int M,int ChargeOption)
        {
            int Minutescheck = 0;
            //charge in time
            if (ChargeOption == 0)
            {
                if (M < 30)
                {
                    Minutescheck = chargePerTime;
                }
                else
                {
                    Minutescheck = chargePerTime * 2;
                }

                TotalCost = H * 2 * chargePerTime + Minutescheck;
            }
            
            //charge in time Exeeding
            if(ChargeOption==1)
            {
                if (M > 30)
                    Minutescheck = chargePerTime;

                TotalCost = H * 2 * chargePerTime + Minutescheck;
            }
            
            
            CostLabel.Content = TotalCost+" Rs";
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {

            CustomerDatabase CD = new CustomerDatabase();
           CustomerNumeberValue.Content = CD.GetCustomerNumber(SearchEditor.Text);
            SearchPanelParkedTime.Content = CD.GetParkingTime(SearchEditor.Text);






        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {



        }
    }
}
