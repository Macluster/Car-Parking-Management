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
using System.IO;
using WpfAnimatedGif;

namespace CarParker
{
    /// <summary>
    /// Interaction logic for Parking.xaml
    /// </summary>
    public partial class Parking : Page
    {

        public UiElementsForParking Ui = new UiElementsForParking();
        public string CurrentMapName;
        public Frame COntentFrame;
        public Parking()
        {
            InitializeComponent();
            // Ui.Createworkspace(this,50,10,2000,2000);
            // PageAnimation();

            if (ReadSettings() != null)
            {
                Thread loadMapthread = new Thread(() => { LoadMap(ReadSettings()); });
                loadMapthread.Start();
            }
           
         
            Thread MapPathGeneratorthread = new Thread(() => { Thread.Sleep(5000); int slotId = FreeSlotFinder(); MapGenerator(slotId); });
            MapPathGeneratorthread.Start();

            Thread StateRefreshThread = new Thread(() => { Thread.Sleep(10000);  StateRefresh(); });
            StateRefreshThread.Start();


        }
        public Parking(int N)
        {
            InitializeComponent();
        }




        public string ReadSettings()
        {

            if (!System.IO.File.Exists("C:\\Users\\Admin\\Documents\\Carparker\\Settings.txt"))
            {
                //  OpenMapDailaouge();

            }
            else
            {
                string path = "C:\\Users\\Admin\\Documents\\Carparker\\Settings.txt";


                CurrentMapName = System.IO.File.ReadAllText(path).Split('.')[1];




            }
            return CurrentMapName;

        }











        public void PageAnimation()
        {


            this.Width = 0;
            Thread pageanimation = new Thread(() =>
            {

                for (int i = 0; i < 1366 * 4; i = i + 4)
                {

                    Thread.Sleep(1);
                    Dispatcher.Invoke(() =>
                    {
                        this.Width += 4;

                    });



                }
            });


            pageanimation.Start();




        }



        public int NoOFSlotsFREE = 0;
        Image MapLOCATOR = new Image();
        BitmapImage image = new BitmapImage();




        public void LoadMap(String FileName)
        {
            MySqlConnection con = new MySqlConnection("server = localhost; user id = root; database = carparking; password=Macluster@123");
            con.Open();

            // Extract Quad Data
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "select * from " + FileName + " where Id=-1";
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {

                Dispatcher.Invoke(() => { Ui.Createworkspace(this, reader.GetInt32(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(5)); });



            }
            reader.Close();


            cmd = con.CreateCommand();
            cmd.CommandText = "select * from " + FileName + " where Id=0";
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {

                Dispatcher.Invoke(() => { Ui.CreateQuad(this, reader.GetInt32(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(5), reader.GetInt32(6)); });



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
                Dispatcher.Invoke(() => { Ui.CreateRoad(this, reader.GetInt32(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(5), reader.GetInt32(6), reader.GetString(7)); });


            }
            reader.Close();



            //Extract HRod Data
            cmd = con.CreateCommand();
            cmd.CommandText = "select * from " + FileName + " where Id=3";
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Dispatcher.Invoke(() => { Ui.CreateHroad(this, reader.GetInt32(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(5), reader.GetInt32(6), reader.GetString(7)); });


            }
            reader.Close();


            //Extract Toll Data
            cmd = con.CreateCommand();
            cmd.CommandText = "select * from " + FileName + " where Id=4";
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Dispatcher.Invoke(() => { Ui.CreateTall(this, reader.GetInt32(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(5), reader.GetInt32(6), reader.GetString(7)); });


            }
            reader.Close();




            //Extract Arrow Data

            cmd = con.CreateCommand();
            cmd.CommandText = "select * from " + FileName + " where Id=5";
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Dispatcher.Invoke(() => { Ui.CreateConnector(this, reader.GetInt32(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(5), reader.GetInt32(6), reader.GetString(7)); });


            }
            reader.Close();



            //Extract Connector Data

            cmd = con.CreateCommand();
            cmd.CommandText = "select * from " + FileName + " where Id=6";
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Dispatcher.Invoke(() => { Ui.CreateConnector(this, reader.GetInt32(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(5), reader.GetInt32(6), reader.GetString(7)); });


            }
            reader.Close();

            con.Close();



            //Thread For Refreshing slot state
           // Thread StateRefreshThread = new Thread(() => { Thread.Sleep(10000); StateRefresh(); });
            //   StateRefreshThread.Start();



            //Map Locator
            Dispatcher.Invoke(() =>
            {
                MapLOCATOR.Width = 100;
                MapLOCATOR.Height = 100;

                image.BeginInit();
                image.UriSource = new Uri(BaseUriHelper.GetBaseUri(this), "Assets/locator.gif");
                image.EndInit();
                ImageBehavior.SetAnimatedSource(MapLOCATOR, image);

                Ui.Quad[0].Children.Add(MapLOCATOR);
            });
        



            ParkingDatabase P = new ParkingDatabase();

            // To count  no of free slots
            for (int i = 0; i < Ui.NoOfPakingSlot; i++)
            {
                if (P.isSlotFree(i, CurrentMapName + "XXX") == 0)
                {
                    NoOFSlotsFREE++;

                }

            }

            //To display no of free slots
            Dispatcher.Invoke(() =>
            {
                AvailabeSlotLabel.Content = NoOFSlotsFREE.ToString();
                FilledSlotLabel.Content = (Ui.NoOfPakingSlot - NoOFSlotsFREE).ToString();


            });







        }





        private void OpenMapBtn_Click(object sender, RoutedEventArgs e)
        {



            Scrol1Canvas.Opacity = 0.2;
            OpenMapBtn.Opacity = 0.2;
            FreeSlotInfoGrid.Opacity = 0.2;



            //Finding all files in  a path saving them in an array
            string[] files = Directory.EnumerateFiles("C:\\Users\\Admin\\Documents\\Carparker").ToArray();



            int NoRows = 3;
            if (files.Length > 9)
                NoRows = files.Length / 3;



            //Parent Grid
            GridAPI G = new GridAPI(0, 0, 0, 700);
            G.AddRowColumn(NoRows, 3, 165, 0);
            G.Grid1.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#194350"));


            //Close Button Image
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
            Borderr.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#194350"));
            Borderr.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#194350"));



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
                        Borderr.Margin = new Thickness(Borderr.Margin.Left - 1, Borderr.Margin.Top - 1, 0, 0);
                        Borderr.Height += 1.5;

                    });
                }
            });
            AnimationThread.Start();




            //Close Button
            Button MapDialogCloseBtn = new Button();
            MapDialogCloseBtn.Width = 30;
            MapDialogCloseBtn.Height = 30;
            MapDialogCloseBtn.Click += async (semder, args) => { MainGrid.Children.Remove(Borderr); Scrol1Canvas.Opacity = 1; OpenMapBtn.Opacity = 1; FreeSlotInfoGrid.Opacity = 1; };
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
                    CurrentMapName = ((Button)sender2).Content.ToString().Split('.')[0];
                    LoadMap(((Button)sender2).Content.ToString().Split('.')[0]);

                    Scrol1Canvas.Opacity = 1;
                    OpenMapBtn.Opacity = 1;
                    FreeSlotInfoGrid.Opacity = 1;
                 
                    Thread MapGeneratorthread = new Thread(() => { int slotId = FreeSlotFinder(); MapGenerator(slotId); });
                    MapGeneratorthread.Start();

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





        public void CurrentTimeDateShower()
        {
            DateTime date = DateTime.Now;
            TimeLabel.Content = date.ToLongTimeString();


            switch (date.Month)
            {
                case 1:
                    DateLabel.Content = "January " + date.Day.ToString();
                    break;
                case 2:
                    DateLabel.Content = "February " + date.Day.ToString();
                    break;
                case 3:
                    DateLabel.Content = "March " + date.Day.ToString();
                    break;
                case 4:
                    DateLabel.Content = "April " + date.Day.ToString();
                    break;
                case 5:
                    DateLabel.Content = "May " + date.Day.ToString();
                    break;
                case 6:
                    DateLabel.Content = "June " + date.Day.ToString();
                    break;
                case 7:
                    DateLabel.Content = "July " + date.Day.ToString();
                    break;
                case 8:
                    DateLabel.Content = "August " + date.Day.ToString();
                    break;
                case 9:
                    DateLabel.Content = "September " + date.Day.ToString();
                    break;
                case 10:
                    DateLabel.Content = "October " + date.Day.ToString();
                    break;
                case 11:
                    DateLabel.Content = "November " + date.Day.ToString();
                    break;
                case 12:
                    DateLabel.Content = "Decmeber " + date.Day.ToString();
                    break;


            }


        }

        public void StateRefresh()
        {


            MySqlConnection con2 = new MySqlConnection("server=localhost;user id=root;database=carparking;password=Macluster@123");
            MySqlCommand cmd;
            MySqlDataReader dr;



            int value = 0;
            string query;

            con2.Open();
            while (true)
            {



                Thread.Sleep(1000);
                Dispatcher.Invoke(() =>
                {


                    CurrentTimeDateShower();


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



        public double SCaleValue = 0.0;
        public ScaleTransform S = new ScaleTransform();
        int DebugBoxFlag = 0;
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
            if ((Keyboard.Modifiers == ModifierKeys.Control) && (e.Key == Key.D))
            {

                if (DebugBoxFlag == 0)
                {
                    DebugBox.Visibility = Visibility.Visible;
                    DebugBoxFlag = 1;
                }
                else
                {
                    DebugBox.Visibility = Visibility.Hidden;
                    DebugBoxFlag = 0;
                }


            }

        }




        private void AlotSlotBtn_Click(object sender, RoutedEventArgs e)
        {



            //Dialouge for confirming slot alot

            Scrol1Canvas.Opacity = 0.2;
            FreeSlotInfoGrid.Opacity = 0.2;
            OpenMapBtn.Opacity = 0.2;

            Grid G = new Grid();
            G.Height = 250;
            G.Width = 400;
            G.Margin = new Thickness(370, 250, 0, 0);
            G.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#435560"));
            MainGrid.Children.Add(G);

            Label lab = new Label();
            lab.Content = "Alot This Slot";
            lab.Foreground = new SolidColorBrush(Colors.White);
            lab.FontSize = 30;
            lab.VerticalAlignment = VerticalAlignment.Center;
            lab.HorizontalAlignment = HorizontalAlignment.Center;
            G.Children.Add(lab);


            Button Btn1 = new Button();
            Btn1.Height = 40;
            Btn1.Width = 90;
            Btn1.Content = "Yes";
            Btn1.Foreground = new SolidColorBrush(Colors.White);
            Btn1.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#28b5b5"));
            Btn1.Click += async (Senderr, args) =>
            {

                DateTime dt = DateTime.Now;

                CustomerDatabase CD = new CustomerDatabase();
                CD.Insert(Number_Box.Text, dt.ToLongTimeString().ToString(), " ", dt.ToLongDateString(), CurrentMapName, FreeSlotLabel.Content.ToString());

                MapShot();


                G.Children.Remove(Btn1);
                // G.Children.Remove(Btn2);
                G.Children.Remove(lab);
                MainGrid.Children.Remove(G);

                OpenMapBtn.Opacity = 1;
                Scrol1Canvas.Opacity = 1;
                FreeSlotInfoGrid.Opacity = 1;
                ParkingDatabase PD = new ParkingDatabase();

                AvailabeSlotLabel.Content = --NoOFSlotsFREE;
                FilledSlotLabel.Content = Ui.NoOfPakingSlot - NoOFSlotsFREE;

                SetRoadsBackToNormalState();
                int slotId = FreeSlotFinder();
                Thread MapGeneratorthread = new Thread(() => {
                    MapGenerator(slotId);

                    Thread.Sleep(1000);
                    Dispatcher.Invoke(() => { MapShot(); ShowTicket(); });


                });
                MapGeneratorthread.Start();







            };
            Btn1.VerticalAlignment = VerticalAlignment.Bottom;
            Btn1.Margin = new Thickness(0, 0, 170, 20);
            G.Children.Add(Btn1);


            Button Btn2 = new Button();
            Btn2.Height = 40;
            Btn2.Width = 90;
            Btn2.Content = "No";
            Btn2.Foreground = new SolidColorBrush(Colors.White);
            Btn2.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff8882"));
            Btn2.Click += async (sender, args) =>
            {
                G.Children.Remove(Btn1);
                G.Children.Remove(Btn2);
                G.Children.Remove(lab);
                MainGrid.Children.Remove(G);

                OpenMapBtn.Opacity = 1;
                Scrol1Canvas.Opacity = 1;
                FreeSlotInfoGrid.Opacity = 1;
            };
            Btn2.VerticalAlignment = VerticalAlignment.Bottom;
            Btn2.Margin = new Thickness(170, 0, 0, 20);
            G.Children.Add(Btn2);





        }

        public int ClosestSlotID = -1;
        public int FreeSlotFinder()
        {







            int tempx, tempy, tempsum;
            ParkingDatabase PD = new ParkingDatabase();

            int closestPslotLeft = 0;
            int closestPslotTop = 0;
            int PslotLeft = 0;
            int PslotTop = 0;
            int TollLeft = 0;
            int TollTop = 0;
            
            
            if (ClosestSlotID != -1)
            {
                PD.Update(ClosestSlotID, 0, CurrentMapName + "XXX");
                PD.isSlotFreeColorChanger(Ui.Pslot[ClosestSlotID], 0);
            }
            ClosestSlotID = 0;

            for (int i = 1; i < Ui.NoOfPakingSlot; i++)
            {

                Dispatcher.Invoke(() =>
                {
                    closestPslotLeft =Convert.ToInt32( Ui.Pslot[ClosestSlotID].Margin.Left);
                    closestPslotTop = Convert.ToInt32(Ui.Pslot[ClosestSlotID].Margin.Top);
                    PslotLeft = Convert.ToInt32(Ui.Pslot[i].Margin.Left);
                    PslotTop = Convert.ToInt32(Ui.Pslot[i].Margin.Top);
                    TollLeft = Convert.ToInt32(Ui.Toll[0].Margin.Left);
                    TollTop=Convert.ToInt32(Ui.Toll[0].Margin.Top);


                });

                if (PD.isSlotFree(i, CurrentMapName + "XXX") == 0)
                {
                    tempx = Convert.ToInt32(TollLeft - PslotLeft);

                    if (tempx < 0)
                    {
                        tempx = -tempx;
                    }

                    tempy = Convert.ToInt32(TollTop - PslotTop);
                    if (tempy < 0)
                    {
                        tempy = -tempy;
                    }

                    tempsum = tempx + tempy;
                    if (((TollTop - closestPslotTop) + (TollLeft -closestPslotLeft)) > tempsum)
                    {
                        ClosestSlotID = i;
                    }






                }

            }

            Dispatcher.Invoke(() => { FreeSlotLabel.Content = ((Label)Ui.Pslot[ClosestSlotID].Children[3]).Content; });
           
            return ClosestSlotID;





        }



        public Canvas DestinationPathCANVAS;
        public void MapGenerator(int slotId)
        {
          

            TSM_MetrixCreator();

            Canvas closest_Destination_Road = ClosestRoadForPslotFinder(slotId);

            Canvas closest_starting_Road = closestRoadForTollFinder();


            Dispatcher.Invoke(() => {
                closest_starting_Road.Background = new SolidColorBrush(Colors.Green);
                //closest_Destination_Road.Background = new SolidColorBrush(Colors.Red);
            });







            //TO Find TSM Metrix Destination index
            int MetrixDestinationIndex = 0;
            Dispatcher.Invoke(() =>
            {

                if (closest_Destination_Road.Tag.ToString().Split('.')[0] == "H")
                {
                    MetrixDestinationIndex = Ui.NoOfRoads + Convert.ToInt32(closest_Destination_Road.Tag.ToString().Split('.')[1]);
                }
                else
                    MetrixDestinationIndex = Convert.ToInt32(closest_Destination_Road.Tag.ToString().Split('.')[1]);

            });





            //To Find TSM Metrix Starting Index
            int MatrixStartingIndex = 0;
            Dispatcher.Invoke(() =>
            {

                if (closest_starting_Road.Tag.ToString().Split('.')[0] == "H")
                {
                    MatrixStartingIndex = Convert.ToInt32(closest_starting_Road.Tag.ToString().Split('.')[1]) + Ui.NoOfRoads;

                }
                else
                {
                    MatrixStartingIndex = Convert.ToInt32(closest_starting_Road.Tag.ToString().Split('.')[1]);

                }
            });





            // DebugBox.Text +="starting Road \t="+ Convert.ToInt32(closest_starting_Road.Tag.ToString().Split('.')[1]);
            // DebugBox.Text += "\nDestination Road\t"+Convert.ToInt32(closest_Destination_Road.Tag.ToString().Split('.')[1]);
            //closest_starting_Road.Background = new SolidColorBrush(Colors.Red);
            //closest_Destination_Road.Background = new SolidColorBrush(Colors.Green);






            //Finding PATH
            int[,] RecentState = new int[30, 2]; int RecentIndexI = 0;
            int[] TempPathOrder = new int[50]; int PathOrderIndex = 0; TempPathOrder[0] = MatrixStartingIndex;
            int[] RoadsCovered = new int[Ui.NoOfRoads + Ui.HNoOfRoads]; int RoadsCoveredIndex = 0; RoadsCovered[RoadsCoveredIndex] = MatrixStartingIndex; int RoadAlreadyCovered = 0;


            int IF_MetrixDestination_Found = 0;

            int i = MatrixStartingIndex;
            int j = 0;
            int jj = 0;
            RoadsCoveredIndex = 1;
            do
            {


                for (j = jj; j < Ui.NoOfRoads + Ui.HNoOfRoads - 1; j++)
                {


                    for (int rds = 0; rds < RoadsCoveredIndex; rds++)
                    {
                        if (RoadsCovered[rds] == j)
                        {
                            RoadAlreadyCovered = 1;
                        }

                    }

                    if (RoadAlreadyCovered != 1)
                    {


                        if (TSM_METRIX[i, MetrixDestinationIndex] == 1)
                        {

                            IF_MetrixDestination_Found = 1;
                            break;
                        }




                        if (TSM_METRIX[i, j] == 1)
                        {

                            //  DebugBox.Text +="\n J value "+ j;
                            TempPathOrder[++PathOrderIndex] = j;
                            RoadsCovered[RoadsCoveredIndex++] = j;

                            RecentState[RecentIndexI, 0] = i;
                            RecentState[RecentIndexI, 1] = j;
                            RecentIndexI++;
                            //   DebugBox.Text += "Check Recent State=" + RecentState[RecentIndexI-1, 0].ToString() + "," + RecentState[RecentIndexI-1, 1].ToString() + "|";






                            if (j == MetrixDestinationIndex)
                            {
                                IF_MetrixDestination_Found = 1;
                                break;

                            }

                            i = j - 1;
                            break;

                        }

                    }
                    else
                    {
                        RoadAlreadyCovered = 0;
                    }



                }
                if (IF_MetrixDestination_Found == 1)
                {
                    break;
                }

                if (j == Ui.NoOfRoads + Ui.HNoOfRoads - 1)
                {





                    //   DebugBox.Text += "\n\nCurrent Recent State\n";
                    for (int h = 0; h < RecentIndexI; h++)
                    {
                        //      DebugBox.Text += RecentState[h, 0].ToString() + ",";
                        //      DebugBox.Text += RecentState[h, 1].ToString() + "|";


                    }


                    //   DebugBox.Text += "\n\nCurrent Temp Path Order\n";
                    for (int h = 0; h <= PathOrderIndex; h++)
                    {
                        //      DebugBox.Text += TempPathOrder[h].ToString() + ",";



                    }


                    //   DebugBox.Text += "\n recent index Changed to"+ RecentState[RecentIndexI - 1, 0].ToString()+","+ RecentState[RecentIndexI - 1, 1].ToString();
                    i = RecentState[RecentIndexI - 1, 0] - 1;// -1 because i will inc rement below
                    jj = RecentState[RecentIndexI - 1, 1];
                    RecentIndexI--;

                    PathOrderIndex--;



                }


                i++;
                if (i == Ui.NoOfRoads + Ui.HNoOfRoads - 1)
                {
                    i = 0;
                }

            } while (i != MatrixStartingIndex);






            //DebugBox.Text += "\nTempPathOrder\n\n";
            for (int i1 = 0; i1 <= PathOrderIndex; i1++)
            {

                //DebugBox.Text += TempPathOrder[i1].ToString() + "\t";


            }

            //DebugBox.Text += "\nnoOfRoads"+Ui.NoOfRoads;
            //DebugBox.Text += "Temporderlength" + TempPathOrder.Length;

            //Coloring th Path
            for (int i2 = 0; i2 <= PathOrderIndex; i2++)
            {
                if (TempPathOrder[i2] >= Ui.NoOfRoads)
                {
                    Dispatcher.Invoke(() => { Ui.HRod[TempPathOrder[i2] - Ui.NoOfRoads].Background = new SolidColorBrush(Colors.DeepSkyBlue); });

                }
                else if (TempPathOrder[i2] < Ui.NoOfRoads)
                    Dispatcher.Invoke(() => { Ui.Rod[TempPathOrder[i2]].Background = new SolidColorBrush(Colors.DeepSkyBlue); });


            }



            //To deal with Destination road length and LOCATOR
            Dispatcher.Invoke(() =>
            {
                if (Ui.Pslot[slotId].Margin.Left - Ui.Rod[TempPathOrder[PathOrderIndex]].Margin.Left > 0)
                {
                    DestinationPathCANVAS = new Canvas();
                    DestinationPathCANVAS.Margin = new Thickness(closest_Destination_Road.Margin.Left, closest_Destination_Road.Margin.Top, 0, 0);
                    DestinationPathCANVAS.Height = closest_Destination_Road.Height;
                    DestinationPathCANVAS.Width = Ui.Pslot[slotId].Margin.Left - Ui.Rod[TempPathOrder[PathOrderIndex]].Margin.Left;
                    DestinationPathCANVAS.Background = new SolidColorBrush(Colors.DeepSkyBlue);
                    ((Canvas)closest_Destination_Road.Parent).Children.Add(DestinationPathCANVAS);

                }
                else
                {
                    DestinationPathCANVAS = new Canvas();
                    DestinationPathCANVAS.Margin = new Thickness(Ui.Pslot[slotId].Margin.Left, closest_Destination_Road.Margin.Top, 0, 0);
                    DestinationPathCANVAS.Height = closest_Destination_Road.Height;
                    DestinationPathCANVAS.Width = -(Ui.Pslot[slotId].Margin.Left - Ui.Rod[TempPathOrder[PathOrderIndex]].Margin.Left);
                    DestinationPathCANVAS.Background = new SolidColorBrush(Colors.DeepSkyBlue);
                    ((Canvas)closest_Destination_Road.Parent).Children.Add(DestinationPathCANVAS);
                }


                ((Canvas)closest_Destination_Road.Parent).Children.Remove(MapLOCATOR);
                MapLOCATOR.Margin = new Thickness(Ui.Pslot[slotId].Margin.Left - 30, DestinationPathCANVAS.Margin.Top - 75, 0, 0);
                ((Canvas)closest_Destination_Road.Parent).Children.Add(MapLOCATOR);

            });






        }

        public int[,] TSM_METRIX;
        public void TSM_MetrixCreator()
        {

            int MetrixI = 0;
            int MetrixJ = 0;
            int[,] TSM_Metrix = new int[Ui.NoOfRoads + Ui.HNoOfRoads, Ui.NoOfRoads + Ui.HNoOfRoads];




            int CurrentCONNECTOR_Left = 0;
            int CurrentCONNECTOR_Right = 0;
            int CurrentCONNECTOR_Top = 0;
            int CurrentCONNECTOR_Down = 0;

            int CurrentRoad_Left = 0;
            int CurrentRoad_Right = 0;
            int CurrentRoad_Top = 0;
            int CurrentRoad_Down = 0;


            int CurrentHrod_Left = 0;
            int CurrentHrod_Right = 0;
            int CurrentHrod_Top = 0;
            int CurrentHrod_Down = 0;





            int[] RoadsInConnector = new int[4]; int RoadsInContainerIndex = 0;
            int i, j, k;

            for (i = 0; i < Ui.NoOfConnector; i++)
            {

                Dispatcher.Invoke(() =>
                {
                    CurrentCONNECTOR_Left = Convert.ToInt32(Ui.Connector[i].Margin.Left);
                    CurrentCONNECTOR_Right = Convert.ToInt32(Ui.Connector[i].Margin.Left + Ui.Connector[i].Width);
                    CurrentCONNECTOR_Top = Convert.ToInt32(Ui.Connector[i].Margin.Top);
                    CurrentCONNECTOR_Down = Convert.ToInt32(Ui.Connector[i].Margin.Top + Ui.Connector[i].Height);

                });



                RoadsInContainerIndex = 0;


                for (j = 0; j < Ui.NoOfRoads; j++)
                {

                    Dispatcher.Invoke(() =>
                    {
                        CurrentRoad_Left = Convert.ToInt32(Ui.Rod[j].Margin.Left);
                        CurrentRoad_Right = Convert.ToInt32(Ui.Rod[j].Margin.Left + Ui.Rod[j].Width);
                        CurrentRoad_Top = Convert.ToInt32(Ui.Rod[j].Margin.Top);
                        CurrentRoad_Down = Convert.ToInt32(Ui.Rod[j].Margin.Top + Ui.Rod[j].Height);

                    });



                    if ((CurrentRoad_Right < CurrentCONNECTOR_Right) && (CurrentCONNECTOR_Right > CurrentCONNECTOR_Left) && (CurrentRoad_Top > CurrentCONNECTOR_Top) && (CurrentRoad_Down < CurrentCONNECTOR_Down))
                    {

                        RoadsInConnector[RoadsInContainerIndex++] = j;

                    }

                    else if ((CurrentCONNECTOR_Left < CurrentCONNECTOR_Right) && (CurrentRoad_Left > CurrentCONNECTOR_Left) && (CurrentRoad_Top > CurrentCONNECTOR_Top) && (CurrentRoad_Down < CurrentCONNECTOR_Down))
                    {

                        RoadsInConnector[RoadsInContainerIndex++] = j;

                    }
                    else if ((CurrentRoad_Right < CurrentCONNECTOR_Right) && (CurrentRoad_Left > CurrentCONNECTOR_Left) && (CurrentRoad_Top > CurrentCONNECTOR_Top) && (CurrentRoad_Top < CurrentCONNECTOR_Down))
                    {
                        RoadsInConnector[RoadsInContainerIndex++] = j;
                    }
                    else if ((CurrentRoad_Right < CurrentCONNECTOR_Right) && (CurrentRoad_Left > CurrentCONNECTOR_Left) && (CurrentRoad_Down > CurrentCONNECTOR_Top) && (CurrentRoad_Down < CurrentCONNECTOR_Down))
                    {
                        RoadsInConnector[RoadsInContainerIndex++] = j;
                    }





                }
                j = RoadsInContainerIndex;



                for (k = 0; k < Ui.HNoOfRoads; k++)
                {

                    Dispatcher.Invoke(() =>
                    {
                        CurrentHrod_Left = Convert.ToInt32(Ui.HRod[k].Margin.Left);
                        CurrentHrod_Right = Convert.ToInt32(Ui.HRod[k].Margin.Left + Ui.HRod[k].Width);
                        CurrentHrod_Top = Convert.ToInt32(Ui.HRod[k].Margin.Top);
                        CurrentHrod_Down = Convert.ToInt32(Ui.HRod[k].Margin.Top + Ui.HRod[k].Height);


                    });



                    if ((CurrentHrod_Right < CurrentCONNECTOR_Right) && (CurrentHrod_Right > CurrentCONNECTOR_Left) && (CurrentHrod_Top > CurrentCONNECTOR_Top) && (CurrentHrod_Down < CurrentCONNECTOR_Down))
                    {

                        RoadsInConnector[RoadsInContainerIndex++] = k;

                    }

                    else if ((CurrentHrod_Left < CurrentCONNECTOR_Right) && (CurrentHrod_Left > CurrentCONNECTOR_Left) && (CurrentHrod_Top > CurrentCONNECTOR_Top) && (CurrentHrod_Down < CurrentCONNECTOR_Down))
                    {

                        RoadsInConnector[RoadsInContainerIndex++] = k;

                    }
                    else if ((CurrentHrod_Right < CurrentCONNECTOR_Right) && (CurrentHrod_Left > CurrentCONNECTOR_Left) && (CurrentHrod_Top > CurrentCONNECTOR_Top) && (CurrentHrod_Top < CurrentCONNECTOR_Down))
                    {
                        RoadsInConnector[RoadsInContainerIndex++] = k;
                    }
                    else if ((CurrentHrod_Right < CurrentCONNECTOR_Right) && (CurrentHrod_Left > CurrentCONNECTOR_Left) && (CurrentHrod_Down > CurrentCONNECTOR_Top) && (CurrentHrod_Down < CurrentCONNECTOR_Down))
                    {
                        RoadsInConnector[RoadsInContainerIndex++] = k;
                    }


                }
                k = RoadsInContainerIndex;
                //DebugBox.Text += "\nConnector"+i.ToString() +" =";
                for (int m = 0; m < 4; m++)
                {
                    //DebugBox.Text+= RoadsInConnector[m].ToString()+"\t";
                }
                // DebugBox.Text += "\n";




                for (int m = 0; m < 4; m++)
                {

                    for (int n = 0; n < 4; n++)
                    {

                        if (!(m == n))
                        {

                            if (n < j && m < j)
                            {
                                TSM_Metrix[RoadsInConnector[m], RoadsInConnector[n]] = 1;
                                TSM_Metrix[RoadsInConnector[n], RoadsInConnector[m]] = 1;
                            }
                            else if (n < j && m >= j)
                            {
                                TSM_Metrix[RoadsInConnector[m] + Ui.NoOfRoads, RoadsInConnector[n]] = 1;
                                TSM_Metrix[RoadsInConnector[n], RoadsInConnector[m] + Ui.NoOfRoads] = 1;
                            }
                            else if (m >= j && n >= j)
                            {
                                TSM_Metrix[RoadsInConnector[m] + Ui.NoOfRoads, RoadsInConnector[n] + Ui.NoOfRoads] = 1;
                                TSM_Metrix[RoadsInConnector[n] + Ui.NoOfRoads, RoadsInConnector[m] + Ui.NoOfRoads] = 1;
                            }

                            else
                            {
                                TSM_Metrix[RoadsInConnector[m], RoadsInConnector[n] + Ui.NoOfRoads] = 1;
                                TSM_Metrix[RoadsInConnector[n] + Ui.NoOfRoads, RoadsInConnector[m]] = 1;

                            }
                        }


                    }



                }


                TSM_METRIX = TSM_Metrix;



                //DebugBox.Text += "\nTsmMetrix\n\n";
                for (int m = 0; m < Ui.NoOfRoads + Ui.HNoOfRoads; m++)
                {
                    for (int n = 0; n < Ui.HNoOfRoads + Ui.NoOfRoads; n++)
                    {

                        //  DebugBox.Text += TSM_METRIX[m, n]+"\t";
                    }
                    //  DebugBox.Text += "\n";

                }





            }





        }

        public void SetRoadsBackToNormalState()
        {
            ((Canvas)Ui.Pslot[ClosestSlotID].Parent).Children.Remove(DestinationPathCANVAS);

            for (int i = 0; i < Ui.NoOfRoads; i++)
            {
                Ui.Rod[i].Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#02475e"));
            }
            for (int i = 0; i < Ui.HNoOfRoads; i++)
            {
                Ui.HRod[i].Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#02475e"));
            }


        }








        public Canvas ClosestRoadForPslotFinder(int slotId)
        {



            int Heightdiff = 0;
            int LeastHeightDiff = 2000;
            int closestHrodID = 0;


            int CurrentPslot_Left = 0;
            int CurrentPlsot_Top = 0;
            int CurrentPslot_Right = 0;

            int CurrentHrod_Left = 0;
            int CurrentHrod_Top = 0;
            int CurrentHrod_Right = 0;




            for (int i = 0; i < Ui.HNoOfRoads; i++)
            {
                Dispatcher.Invoke(() =>
                {
                    CurrentHrod_Left = Convert.ToInt32(Ui.HRod[i].Margin.Left);
                    CurrentHrod_Right = Convert.ToInt32(Ui.HRod[i].Margin.Left + Ui.HRod[i].Width);
                    CurrentHrod_Top = Convert.ToInt32(Ui.HRod[i].Margin.Top);

                    CurrentPslot_Left = Convert.ToInt32(Ui.Pslot[slotId].Margin.Left);
                    CurrentPslot_Right = Convert.ToInt32(Ui.Pslot[slotId].Margin.Left + Ui.Pslot[i].Width);
                    CurrentPlsot_Top = Convert.ToInt32(Ui.Pslot[slotId].Margin.Top);
                });



                if ((CurrentPslot_Left > CurrentHrod_Left) && ((CurrentPslot_Right) < (CurrentHrod_Right)))
                {

                    Heightdiff = Convert.ToInt32(CurrentPlsot_Top - CurrentHrod_Top);
                    if (Heightdiff < 0)
                    {
                        Heightdiff = -Heightdiff;

                    }
                    if (Heightdiff < LeastHeightDiff)
                    {
                        LeastHeightDiff = Heightdiff;
                        closestHrodID = i;

                    }



                }



            }


            return Ui.HRod[closestHrodID];








        }

        public Canvas closestRoadForTollFinder()
        {


            int LeastDiff = 2000;
            int LeastDiffY = 2000;
            int ClosestRodID = 0;
            int tempDiff = 0;
            int tempDiffY = 0;
            int flag = 0;

            for (int i = 0; i < Ui.NoOfRoads; i++)
            {
                Dispatcher.Invoke(() =>
                {
                    tempDiff = Convert.ToInt32(Ui.Toll[0].Margin.Left - Ui.Rod[i].Margin.Left);
                    tempDiffY = Convert.ToInt32(Ui.Toll[0].Margin.Top - Ui.Rod[i].Margin.Top);
                });



                if (tempDiff < 0)
                {
                    tempDiff = -tempDiff;
                }

                if (tempDiffY < 0)
                {
                    tempDiffY = -tempDiffY;
                }

                if (tempDiff <= LeastDiff && tempDiffY < LeastDiffY)
                {
                    LeastDiff = tempDiff;
                    LeastDiffY = tempDiffY;
                    ClosestRodID = i;

                }
            }



            for (int i = 0; i < Ui.HNoOfRoads; i++)
            {

                Dispatcher.Invoke(() =>
                {

                    tempDiff = Convert.ToInt32(Ui.Toll[0].Margin.Left - Ui.HRod[i].Margin.Left);
                    tempDiffY = Convert.ToInt32(Ui.Toll[0].Margin.Top - Ui.HRod[i].Margin.Top);
                });





                if (tempDiff < 0)
                {
                    tempDiff = -tempDiff;
                }

                if (tempDiffY < 0)
                {
                    tempDiffY = -tempDiffY;
                }

                if (tempDiff < LeastDiff && tempDiffY < LeastDiffY)
                {
                    LeastDiff = tempDiff;
                    LeastDiffY = tempDiffY;
                    ClosestRodID = i;
                    flag = 1;
                }


            }

            if (flag == 1)
            {
                return Ui.HRod[ClosestRodID];

            }
            else
                return Ui.Rod[ClosestRodID];




        }



        public void MapShot()
        {





            PrintCanvas.Visibility = Visibility.Visible;

            RenderTargetBitmap renderTargetBitmap =
            new RenderTargetBitmap(Convert.ToInt32(Scrollview1.Width), Convert.ToInt32(Scrollview1.Height), 90, 80, PixelFormats.Pbgra32);
            renderTargetBitmap.Render(Ui.Workspace);
            PngBitmapEncoder pngImage = new PngBitmapEncoder();
            pngImage.Frames.Add(BitmapFrame.Create(renderTargetBitmap));

            PngBitmapEncoder pngImage2 = new PngBitmapEncoder();
            pngImage2.Frames.Add(BitmapFrame.Create(renderTargetBitmap));

            using (Stream fileStream = File.Create("C:\\Users\\Admin\\Documents\\Carparker\\aaa.png"))
            {
                pngImage.Save(fileStream);
            }
            
            using (Stream fileStream2 = File.Create("C:\\Users\\Admin\\Documents\\Carparker\\aaa1.png"))
            {
                pngImage2.Save(fileStream2);
            }
           

         

       
            

        



            PrintDialog print = new PrintDialog();
            print.MaxPage = 1;
            
           // print.PrintVisual(PrintCanvas, "Printing");

          

        }

        public void ShowTicket()
        {

            Scrol1Canvas.Opacity = 0.2;
            Scrollview1.Opacity = 0.2;
            FreeSlotInfoGrid.Opacity = 0.2;
            OpenMapBtn.Opacity = 0.2;
            SlotavailabelText.Opacity = 0.2;
            AvailabeSlotLabel.Opacity = 0.2;
            FilledSlotLabel.Opacity = 0.2;
            SlotFilledText.Opacity = 0.2;

            BitmapImage Imagebrush = new BitmapImage(new Uri("C:\\Users\\Admin\\Documents\\Carparker\\aaa1.png", UriKind.RelativeOrAbsolute));

            PrintMapImage.Source = Imagebrush;
            TicketEntranceTIme.Content = TimeLabel.Content.ToString();
            TicketslotID.Content = FreeSlotLabel.Content.ToString();

        }



        private void TicketOkButton_Click(object sender, RoutedEventArgs e)
        {

            Scrol1Canvas.Opacity = 1;
            Scrollview1.Opacity = 1;
            FreeSlotInfoGrid.Opacity = 1;
            OpenMapBtn.Opacity = 1;

            SlotavailabelText.Opacity = 1;
            AvailabeSlotLabel.Opacity = 1;
            FilledSlotLabel.Opacity = 1;
            SlotFilledText.Opacity = 1;

            PrintCanvas.Visibility = Visibility.Hidden;
            BitmapImage Imagebrush = new BitmapImage(new Uri("C:\\Users\\Admin\\Documents\\Carparker\\aaa2.png", UriKind.RelativeOrAbsolute));

            PrintMapImage.Source = Imagebrush;

        }
    }
}

