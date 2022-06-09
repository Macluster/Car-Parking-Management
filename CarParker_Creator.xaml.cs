using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Data.SQLite;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Linq;
using System.IO;

namespace CarParker
{
    /// <summary>
    /// Interaction logic for CarParker_Creator.xaml
    /// </summary>
    public partial class CarParker_Creator : Page
    {


        UIElements Ui = new UIElements();
        public string FileName="";
       
        public int MouseDown_flag = 0;


        public MainWindow mainwindow;
        public CarParker_Creator(MainWindow m)
        {
            InitializeComponent();



            mainwindow = m;

           



        }




        public int FilebtnFlag = 0;
        StackPanel filedialog = new StackPanel();
        Button savebtn;
        Button saveASbtn;
        Button OpenBtn;
        Button NewBtn;
        private void Filebtn_Click(object sender, RoutedEventArgs e)
        {
             
            if (FilebtnFlag == 0)
            {
                filedialog = new StackPanel();
                filedialog.Margin = new Thickness(ToolBarBorder.Margin.Left +50, ToolBarBorder.Margin.Top+Filebtn.Height+10, 0, 0);
                filedialog.Width = 100;
                filedialog.Height = 100;
                MainGrid.Children.Add(filedialog);

                filedialog.Background = new SolidColorBrush(Colors.Gray);

                NewBtn = new Button();
                NewBtn.Content = "New";
                NewBtn.Background = new SolidColorBrush(Colors.DarkCyan);
                NewBtn.Click += async (sender1, args1) => 
                { 
                    Scrol1Canvas.Children.Remove(Ui.Workspace);
                    MainGrid.Children.Remove(filedialog);
                    
                    Ui.NoOfPakingSlot = 0;
                    Ui.NoOfQuad = 0;
                    Ui.NoOfRoads = 0;
                    Ui.HNoOfRoads = 0;
                    Ui.SlotPredictionX = 50;  
                    Ui.SlotPredictionXTemp = 0;
                    Ui.SlotPredictionY = 50;
                    Ui.slotPredictionHDIFF = 20;
                    Ui.slotPredictionVDIFF = 50;
                    Ui.SlotPredictionWidth = 50;
                    Ui.SlotPredictionHeight = 50;

                  

                    Ui.LabelSizePrediction = 11;
                    Ui. LabelTextPrediction = "A1";

                    Ui.Createworkspace(this, 100, 50, 1500, 1500);
                };
               
                NewBtn.BorderThickness = new Thickness(0, 0, 0, 1);
                NewBtn.BorderBrush = new SolidColorBrush(Colors.White);
                filedialog.Children.Add( NewBtn);


                OpenBtn = new Button();
                OpenBtn.Content = "Open";
                OpenBtn.Background = new SolidColorBrush(Colors.DarkCyan);
                OpenBtn.Click += async (sender1, args1) => { MainGrid.Children.Remove(filedialog); OpenMapBtn_Click(); };
                OpenBtn.BorderThickness = new Thickness(0, 0, 0, 1);
                OpenBtn.BorderBrush = new SolidColorBrush(Colors.White);
                filedialog.Children.Add(OpenBtn);

                savebtn = new Button();
                savebtn.Content = "Save";
                savebtn.Background = new SolidColorBrush(Colors.DarkCyan);
                savebtn.Click += async (sender1, args1) => { MainGrid.Children.Remove(filedialog); SaveBtn_Click(sender1, args1); };
                filedialog.Children.Add(savebtn);
                savebtn.BorderThickness = new Thickness(0, 0, 0, 1);
                savebtn.BorderBrush = new SolidColorBrush(Colors.White);

                saveASbtn = new Button();
                saveASbtn.Content = "SaveAs";
                saveASbtn.Background = new SolidColorBrush(Colors.DarkCyan);
                saveASbtn.Click += async (sender1, args1) => 
                {
                    MainGrid.Children.Remove(filedialog);
                    Window w = new Window();
                    w.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    Savepopup ss = new Savepopup(this, Ui, w);



                        w.Height = 250;
                        w.Width = 500;
                        w.Show();
                        w.Content = ss;
                    


                };
                saveASbtn.BorderThickness = new Thickness(0, 0, 0, 1);
                saveASbtn.BorderBrush = new SolidColorBrush(Colors.White);
                filedialog.Children.Add(saveASbtn);

             


                FilebtnFlag = 1;
            }
            else
            {
        
                MainGrid.Children.Remove(filedialog);
                filedialog.Children.Remove(saveASbtn);
                filedialog.Children.Remove(savebtn);
                
                filedialog.Children.Remove(OpenBtn);
                FilebtnFlag = 0;
            }

        }








        private void RectBtn_Click(object sender, RoutedEventArgs e)
        {
            if(Ui.WorkspaceCheckFlag==1)
            Ui.CreateQuad(this, 200, 200, 400, 400,0);


            
        



        }




        public  int NextRowCheckFlag = 0;
        private void SlotBtn_Click(object sender, RoutedEventArgs e)
        {
            Ui.SlotCheckFlag = 1;
            for (int i = 0; i < 1; i++)
            {
                if (Ui.QuadCheckFlag == 1)
                {

                    Ui.CreatePslot(this, Ui.CurrentQuad, Ui.SlotPredictionX, Ui.SlotPredictionY, Ui.SlotPredictionHeight, Ui.SlotPredictionWidth, Ui.LabelTextPrediction, 0);
                    Ui.SlotPredictionX += Ui.SlotPredictionWidth + Ui.slotPredictionHDIFF;


                    if (Ui.SlotPredictionX > Ui.CurrentQuad.Width - 50)
                    {
                        Ui.SlotPredictionY += Ui.SlotPredictionHeight + Ui.slotPredictionVDIFF;
                        Ui.SlotPredictionX = 50;
                        Ui.FirstElementInline = Ui.NoOfPakingSlot;

                    }
                    Ui.SlotLabelTextPredictor(Ui.Pslot, Ui.NoOfPakingSlot - 1);

                }
            }
        
        }



        private void RoadBtn_Click(object sender, RoutedEventArgs e)
        {
            if(Ui.QuadCheckFlag==1)
            Ui.CreateRoad(this, Ui.CurrentQuad, 200,300,100,50,0);

        }

        private void HRoadBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Ui.QuadCheckFlag == 1)
            Ui.CreateHroad(this, Ui.CurrentQuad, 200,300,50,100,0);


        }
        private void TollBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Ui.QuadCheckFlag == 1)
                Ui.CreateToll(this, Ui.CurrentQuad, 200, 300, 50, 50, 0);
        }

        private void Arrow_Click(object sender, RoutedEventArgs e)
        {
            if (Ui.QuadCheckFlag == 1)
                Ui.CreateArrow(this, Ui.CurrentQuad, 200, 300, 50, 50, 0);
        }


        private void Connector_Click(object sender, RoutedEventArgs e)
        {
            if (Ui.QuadCheckFlag == 1)
                Ui.CreateConnector(this, Ui.CurrentQuad, 200, 300, 50, 50, 0);
        }
        private void MainGrid_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            if (Cursor == Cursors.SizeWE)
                MouseDown_flag = 1;
            else if (Cursor == Cursors.SizeNS)
                MouseDown_flag = 2;
            else if (Cursor == Cursors.Hand)
                MouseDown_flag = 3;
            else if (Cursor == Cursors.ScrollAll)
                MouseDown_flag = 4;
        }






        private void MainGrid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
           if(Ui.WorkspaceCheckFlag==1)
            Ui.Workspace.Children.Remove(Ui.popup.st);
            MouseDown_flag = 0;
            Cursor = Cursors.Arrow;


            if (Ui.SlotCheckFlag == 1)
            {
                ((Line)Ui.CurrentQuad.Children[5]).Visibility = Visibility.Hidden;
                ((Line)Ui.CurrentQuad.Children[6]).Visibility = Visibility.Hidden;

            }


        }

       

        
        
        
        
        
        
        
        
        
        
        
       
        
        
        public double SCaleValue=0.0;
       public ScaleTransform S = new ScaleTransform();
        int DebugBOXFlag = 0;
        private void MainGrid_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if ((Keyboard.Modifiers == ModifierKeys.Control) && (e.Key == Key.S))
            {
              
                Ui.popup.PasteObject(Ui.TempObjectForCopying, Ui,this);
            }

            if ((Keyboard.Modifiers == ModifierKeys.Control) && (e.Key == Key.Z))
            {

                //S.CenterX = (Ui.CurrentQuad.Margin.Left + (Ui.CurrentQuad.Margin.Left + Ui.CurrentQuad.Width)) / 2;
                //S.CenterY = Ui.CurrentQuad.Margin.Top;
                S.ScaleX = S.ScaleX+0.1;
                S.ScaleY = S.ScaleY+0.1;
                Ui.Workspace.RenderTransform = S;

             
            }
            if ((Keyboard.Modifiers == ModifierKeys.Control) && (e.Key == Key.X))
            {

                //S.CenterX = (Ui.CurrentQuad.Margin.Right + (Ui.CurrentQuad.Margin.Right + Ui.CurrentQuad.Width)) / 2;
                //S.CenterY = Ui.CurrentQuad.Margin.Top;
                S.ScaleX = S.ScaleX-0.1;
                S.ScaleY = S.ScaleY-0.1;
                Ui.Workspace.RenderTransform = S;


            }

            //For DebugBOX
            if ((Keyboard.Modifiers == ModifierKeys.Control) && (e.Key == Key.D))
            {
                if (DebugBOXFlag == 0)
                {
                    DebugBox.Visibility = Visibility.Visible;
                    DebugBOXFlag = 1;
                }
                else
                {
                    DebugBox.Visibility = Visibility.Hidden;
                    DebugBOXFlag = 0;
                }


            }



        }


        private void MainGrid_MouseRightButtonUp(object sender, MouseButtonEventArgs e)//for maingrid popup flag
        {
            
    



        }

        
        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {

            Window w = new Window();
            w.Owner = mainwindow;
            w.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            Savepopup  ss= new Savepopup(this,Ui,w);



            if (FileName =="")
            {
                w.Height = 250;
                w.Width = 500;
                w.Show();
                w.Content = ss;
            }  
        
          else
            {
                ss.Save(FileName);
            }
            



        }


        private void OpenMapBtn_Click()
        {



            StackTOOLBAR.Opacity = 0.5;
            Scrol1Canvas.Opacity = 0.5;




            string[] files = Directory.EnumerateFiles("C:\\Users\\Admin\\Documents\\Carparker").ToArray();



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
            Scrol.Opacity = 1;




            ImageBrush brush = new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Assets/MapImage2.jpg")));



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
            MapDialogCloseBtn.Click += async (semder, args) => { MainGrid.Children.Remove(Borderr); Scrol1Canvas.Opacity = 1; StackTOOLBAR.Opacity = 1; Scrol1Canvas.Opacity = 1; };
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
                    MapBtn.VerticalContentAlignment = VerticalAlignment.Bottom;
                    MapBtn.Foreground = new SolidColorBrush(Colors.White);
                    MapBtn.Height = 130;
                    MapBtn.Width = 200;
                    MapBtn.Background = brush;
                    MapBtn.VerticalAlignment = VerticalAlignment.Bottom;
                    MapBtn.Click += async (sender2, args) =>
                    {


                       MainGrid.Children.Remove(Borderr);


                        ControlsDatabse da = new ControlsDatabse();

                        da.Getdata(Ui, this, ((Button)sender2).Content.ToString().Split('.')[0]);
               
                        Scrol1Canvas.Opacity = 1;
                        StackTOOLBAR.Opacity = 1;
                        Scrol1Canvas.Opacity = 1;
                        
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





       




        }
   

        private async  void MainGrid_MouseMove(object sender, MouseEventArgs e)
        {


            if (Ui.CurrentControl == -1)
            {
          //   WorkspaceMouseOperations MM = new WorkspaceMouseOperations();
          //     MM.MouseOperation(Ui.Workspace, this, Ui, e, 1, 0);
            }



            if (Ui.CurrentControl == 0)
            {
                if (Ui.QuadCheckFlag == 1)
                {
                    ((Line)Ui.CurrentQuad.Children[5]).Y1 = 10;
                    ((Line)Ui.CurrentQuad.Children[5]).Y2 = 10;

                }
                MouseOperations M = new MouseOperations();
                M.MouseOperation(Ui.Quad, this, Ui, e, Ui.NoOfQuad, 0);
            }

            if (Ui.CurrentControl == 1)
            {
                MouseOperations M1 = new MouseOperations();
                M1.MouseOperation(Ui.Pslot, this,Ui, e, Ui.NoOfPakingSlot, 1);
            }
            else if(Ui.CurrentControl==2)
            { 
        
                MouseOperations M2 = new MouseOperations();
                M2.MouseOperation(Ui.Rod, this,Ui, e, Ui.NoOfRoads, 2);
            }
            else if (Ui.CurrentControl == 3)
            {

                MouseOperations M3 = new MouseOperations();
                M3.MouseOperation(Ui.HRod, this,Ui, e,Ui.HNoOfRoads, 3);
            }

            else if (Ui.CurrentControl == 4)
            {

                MouseOperations M4 = new MouseOperations();
                M4.MouseOperation(Ui.Toll, this, Ui, e, Ui.NoOfToll, 4);
            }

            else if (Ui.CurrentControl == 5)
            {

                MouseOperations M5 = new MouseOperations();
                M5.MouseOperation(Ui.Arrow, this, Ui, e, Ui.NoOfArrow, 5);
            }


            else if (Ui.CurrentControl == 6)
            {

                MouseOperations M6 = new MouseOperations();
                M6.MouseOperation(Ui.Connector, this, Ui, e, Ui.NoOfConnector, 5);
            }


        }

        private void WorkspaceSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

            if (!(WorkspaceSlider.Value <= 2000))
            {
                Ui.Workspace.Width = WorkspaceSlider.Value;
                Ui.Workspace.Height = WorkspaceSlider.Value;
                ((Border)Ui.Workspace.Children[0]).Width = WorkspaceSlider.Value;
                ((Border)Ui.Workspace.Children[0]).Height = WorkspaceSlider.Value;
            }
        }

      
    }
}
