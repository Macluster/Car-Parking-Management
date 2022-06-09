using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Data.SQLite;


namespace CarParker
{
    public class UiElementsForParking
    {



        public Canvas Workspace;
        public Canvas[] Quad = new Canvas[20];
        public int NoOfQuad = 0;
        public int RectResizeflag = 0;


        public Canvas[] Pslot = new Canvas[1000];
        public int NoOfPakingSlot = 0;
        public int slotResizeflag = 0;



        public Canvas[] Rod = new Canvas[100];
        public int NoOfRoads = 0;
        public int roadResizeflag = 0;


        public Canvas[] HRod = new Canvas[100];
        public int HNoOfRoads = 0;
        public int HroadResizeflag = 0;

        public Canvas[] Toll = new Canvas[100];
        public int NoOfToll = 0;


        public Canvas[] Arrow = new Canvas[100];
        public int NoOfArrow = 0;

        public Canvas[] Connector = new Canvas[100];
        public int NoOfConnector = 0;




        public void Createworkspace(Object obj,int x,int y,int h,int w)
        {
            SolidColorBrush brush = new SolidColorBrush(Colors.White);
       





            Workspace = new Canvas();
            Workspace.Background = brush;
            Workspace.Height = h;
            Workspace.Width = w;
            Workspace.Margin = new Thickness(x, y, 0, 0);
            Workspace.Tag= "W.1";
            Workspace.PreviewMouseLeftButtonDown += async (Senderr, Argss) =>
            {

              
            };  
            
            Workspace.PreviewMouseRightButtonDown += async (Senderr, Argss) => {  };



            Parking p = new Parking(1);
            if (obj.GetType() == p.GetType())
            {
              ((Parking)obj).Scrol1Canvas.Children.Add(Workspace);
            }
            else
             ((ParkingExitPage)obj).Scrol1Canvas.Children.Add(Workspace);




            //Border
            Border B = new Border();
            B.BorderThickness = new Thickness(5);
            B.BorderBrush = new SolidColorBrush(Colors.White);
            B.Width = Workspace.Width;
            B.Height = Workspace.Height;
            Workspace.Children.Add(B);
            B.Background = new SolidColorBrush(Colors.Transparent);


            //Image
            BitmapImage Imagebrush = new BitmapImage(new Uri(" ", UriKind.Relative));
            Image img = new Image();
            img.Height = Workspace.Height;
            img.Width = Workspace.Width;
            img.Source = Imagebrush;
            img.Stretch = Stretch.Fill;
            Workspace.Children.Add(img);

            //Canvas for movement but not used much
            Canvas Resize = new Canvas();
            Resize.Background = new SolidColorBrush(Colors.Transparent);
            Resize.Height = 20;
            Resize.Width = 20;
            Workspace.Children.Add(Resize);

            //label
            Label Rlabel = new Label();
            Rlabel.Content = "A1";
            Rlabel.FontSize = 30;
            Rlabel.Background = new SolidColorBrush(Colors.White);
            Rlabel.Opacity = 0;
            Rlabel.Height = 80;
            Rlabel.Width = 40;
            Rlabel.Margin = new Thickness(5, 10, 0, 0);
            Workspace.Children.Add(Rlabel);

            //canvas for Rotate
            Canvas Rotate = new Canvas();
            Rotate.Background = new SolidColorBrush(Colors.Transparent);
            Rotate.Height = 20;
            Rotate.Width = 20;
            Rotate.Margin = new Thickness(Workspace.Width - 20, 0, 0, 0);
            Rotate.HorizontalAlignment = HorizontalAlignment.Center;
            Workspace.Children.Add(Rotate);


            //scale tranformation
            ScaleTransform S = new ScaleTransform();
            S.ScaleX = 0.1;
            S.ScaleY = 0.1;

            Workspace.RenderTransform = S;




        }



        public void CreateQuad(Object obj, int x, int y, int h, int w,int angle)
        {
            SolidColorBrush brush = new SolidColorBrush();
            brush.Color = Colors.Transparent;

            Quad[NoOfQuad] = new Canvas();
            Quad[NoOfQuad].Background = brush;
            Quad[NoOfQuad].Height = h;
            Quad[NoOfQuad].Width = w;
            Quad[NoOfQuad].Margin = new Thickness(x, y, 0, 0);
            Quad[NoOfQuad].Tag = "Q" + NoOfQuad.ToString();
            Quad[NoOfQuad].PreviewMouseLeftButtonDown += async (sender3, args3) => {  };
            Quad[NoOfQuad].PreviewMouseRightButtonDown += async (sender3, args3) => {  };
           

            //Border
            Border border = new Border();
            border.Height = h;
            border.Width = w;
            border.Background = new SolidColorBrush(Colors.Transparent);
            border.BorderThickness = new Thickness(5);
            border.BorderBrush = new SolidColorBrush(Colors.Black);
            Quad[NoOfQuad].Children.Add(border);



            //Image
            BitmapImage Imagebrush = new BitmapImage(new Uri(" ", UriKind.Relative));
            Image img = new Image();
            img.Height = Quad[NoOfQuad].Height;
            img.Width = Quad[NoOfQuad].Width;
            img.Source = Imagebrush;
            img.Stretch = Stretch.Fill;
            Quad[NoOfQuad].Children.Add(img);

            //canvas for Movement but not used in this
            Canvas Resize = new Canvas();
            Resize.Background = new SolidColorBrush(Colors.Transparent);
            Resize.Height = 20;
            Resize.Width = 20;
            Quad[NoOfQuad].Children.Add(Resize);
            Workspace.Children.Add(Quad[NoOfQuad]);

            //label
            Label Rlabel = new Label();
            Rlabel.Content = "A1";
            Rlabel.FontSize = 30;
            Rlabel.Background = new SolidColorBrush(Colors.White);
            Rlabel.Opacity = 0;
            Rlabel.Height = 80;
            Rlabel.Width = 40;
            Rlabel.Margin = new Thickness(5, 10, 0, 0);
            Quad[NoOfQuad].Children.Add(Rlabel);

            //canvas for rotation but not used
            Canvas Rotate = new Canvas();
            Rotate.Background = new SolidColorBrush(Colors.Transparent);
            Rotate.Height = 20;
            Rotate.Width = 20;
            Rotate.Margin = new Thickness(Quad[NoOfQuad].Width - 20, 0, 0, 0);
            Rotate.HorizontalAlignment = HorizontalAlignment.Center;
            Quad[NoOfQuad].Children.Add(Rotate);


            // CurrentQuad = Quad[NoOfQuad];
            RotateTransform R = new RotateTransform();
            R.Angle = angle;
            Quad[NoOfQuad].RenderTransform = R;



            RectResizeflag = 1;
            NoOfQuad++;
        }

        public void CreatePslot(Object obj, double x, double y, double h, double w,int angle ,string ParentTag, string labeltext,string XXXFile_name)
        {

          

            SolidColorBrush brush = new SolidColorBrush();
            brush.Color = Colors.Transparent;                            //(Color) ColorConverter.ConvertFromString("#435560");


            Pslot[NoOfPakingSlot] = new Canvas();
            Pslot[NoOfPakingSlot].Background = brush;
            Pslot[NoOfPakingSlot].Height = h;
            Pslot[NoOfPakingSlot].Width = w;
            Pslot[NoOfPakingSlot].Margin = new Thickness(x, y, 0, 0);
            Pslot[NoOfPakingSlot].Tag = "P." + NoOfPakingSlot.ToString();
            Pslot[NoOfPakingSlot].PreviewMouseLeftButtonDown += async (sender2, args2) => 
            {
                Canvas CurrentSlot = ((Canvas)sender2);

                int id;
                int value;
                id = Convert.ToInt32(((Canvas)sender2).Tag.ToString().Split('.')[1]);

                ParkingDatabase PD = new ParkingDatabase();

                value= PD.isSlotFree(id,XXXFile_name);
              
                PD.Update(id,value,XXXFile_name);
                PD.isSlotFreeColorChanger(CurrentSlot, value);



            };
            Pslot[NoOfPakingSlot].PreviewMouseRightButtonDown += async (sender3, args3) => { };

            //Border
            Border border = new Border();
            border.Height = h;
            border.Width = w;
            border.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#435560"));
            border.BorderThickness = new Thickness(5);
            border.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#435560"));
            border.CornerRadius = new CornerRadius(10);
            Pslot[NoOfPakingSlot].Children.Add(border);


            ParkingDatabase PD = new ParkingDatabase();
            if (PD.isSlotFree(NoOfPakingSlot,XXXFile_name) == 1)
            {
                ((Border)Pslot[NoOfPakingSlot].Children[0]).Background = new SolidColorBrush(Colors.Red);
               
            }
            else
            {
                ((Border)Pslot[NoOfPakingSlot].Children[0]).Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#435560"));
            }





            //Image
            BitmapImage Imagebrush = new BitmapImage(new Uri("", UriKind.Relative));
            Image img = new Image();
            img.Height = Pslot[NoOfPakingSlot].Height;
            img.Width = Pslot[NoOfPakingSlot].Width;
            img.Source = Imagebrush;
            img.Stretch = Stretch.Fill;
            Pslot[NoOfPakingSlot].Children.Add(img);


            //Canvas for moving pslot but not used in this class
            Canvas Resize = new Canvas();
            Resize.Background = brush;
            Resize.Height = 20;
            Resize.Width = 20;
            Pslot[NoOfPakingSlot].Children.Add(Resize);

            //Label
            Label Plabel = new Label();
            Plabel.Content = labeltext;
            Plabel.Background = new SolidColorBrush(Colors.Transparent);
            Plabel.Height = Pslot[NoOfPakingSlot].Height - 20;
            Plabel.Width = Pslot[NoOfPakingSlot].Width - 10;

            //  if (Plabel.Width < 34)
            //{
            //     Plabel.FontSize = 11;
            // }
            //  else
            //    Plabel.FontSize = 20;
            Plabel.FontSize = 11;
            Plabel.Margin = new Thickness(5, 10, 0, 0);
            Plabel.HorizontalContentAlignment = HorizontalAlignment.Center;
            Plabel.VerticalContentAlignment = VerticalAlignment.Center;
            Plabel.Foreground = new SolidColorBrush(Colors.White);
            Plabel.FontFamily = new FontFamily("Franklin Gothic Heavy");
            Pslot[NoOfPakingSlot].Children.Add(Plabel);




           
          
            //Canvas for rotatinf but not used
            Canvas Rotate = new Canvas();
            Rotate.Background = new SolidColorBrush(Colors.Transparent);
            Rotate.Height = 20;
            Rotate.Width = 20;
            Rotate.Margin = new Thickness(Pslot[NoOfPakingSlot].Width - 20, 0, 0, 0);
            Rotate.HorizontalAlignment = HorizontalAlignment.Center;
            Pslot[NoOfPakingSlot].Children.Add(Rotate);

            //adding plsot to its parent quad
            string[] str = new string[20];
            str = ParentTag.Split('.');
            Quad[Convert.ToInt32(str[1])].Children.Add(Pslot[NoOfPakingSlot]);

            //rotation Transform
            RotateTransform R = new RotateTransform();
            R.Angle = angle;
            Pslot[NoOfPakingSlot].RenderTransform = R;

            slotResizeflag = 1;
            NoOfPakingSlot++;




        }



        public void CreateRoad(object obj, int x, int y, int h, int w,int angle,string ParentTag )
        {
            SolidColorBrush brush = new SolidColorBrush();
            // brush.Color = (Color)ColorConverter.ConvertFromString("#02475e");
            brush.Color = Colors.Wheat;

            Rod[NoOfRoads] = new Canvas();
            Rod[NoOfRoads].Background = brush;
            Rod[NoOfRoads].Height = h;
            Rod[NoOfRoads].Width = w;
            Rod[NoOfRoads].Margin = new Thickness(x, y, 0, 0);
            Rod[NoOfRoads].Tag = "R." + NoOfRoads.ToString(); ;
            Rod[NoOfRoads].PreviewMouseLeftButtonDown += async (sender3, args3) => { };
            Rod[NoOfRoads].PreviewMouseRightButtonDown += async (sender4, args4) => { };


            //Border
            Border border = new Border();
            border.Height = h;
            border.Width = w;
            border.Background = new SolidColorBrush(Colors.Transparent);
            border.BorderThickness = new Thickness(5);
            border.BorderBrush = new SolidColorBrush(Colors.Transparent);
            border.CornerRadius = new CornerRadius(10);
            Rod[NoOfRoads].Children.Add(border);


            //Image
            BitmapImage Imagebrush = new BitmapImage(new Uri("###Canvas/road.png", UriKind.Relative));
            Image img = new Image();
            img.Height = Rod[NoOfRoads].Height;
            img.Width = Rod[NoOfRoads].Width;
            img.Source = Imagebrush;
            img.Stretch = Stretch.Fill;
            Rod[NoOfRoads].Children.Add(img);


            ////Canvas for moving Rod but not used
            Canvas Resize = new Canvas();
            Resize.Background = new SolidColorBrush(Colors.Transparent);
            Resize.Height = 20;
            Resize.Width = 20;
            Rod[NoOfRoads].Children.Add(Resize);

            
            //Label
            Label Rlabel = new Label();
            Rlabel.Content = "A1";
            Rlabel.FontSize = 30;
            Rlabel.Background = new SolidColorBrush(Colors.White);
            Rlabel.Opacity = 0;
            Rlabel.Height = 80;
            Rlabel.Width = 40;
            Rlabel.Margin = new Thickness(5, 10, 0, 0);
            Rod[NoOfRoads].Children.Add(Rlabel);
            
            //Canvas for rotate  but not used
            Canvas Rotate = new Canvas();
            Rotate.Background = new SolidColorBrush(Colors.Transparent);
            Rotate.Height = 20;
            Rotate.Width = 20;
            Rotate.Margin = new Thickness(Rod[NoOfRoads].Width - 20, 0, 0, 0);
            Rotate.HorizontalAlignment = HorizontalAlignment.Center;
            Rod[NoOfRoads].Children.Add(Rotate);


            //adding rod to its parent quad
            string[] str = new string[20];
            str = ParentTag.Split('.');
            Quad[Convert.ToInt32(str[1])].Children.Add(Rod[NoOfRoads]);

            
            //Rotation trasnformation
            RotateTransform R = new RotateTransform();
            R.Angle = angle;
            Rod[NoOfRoads].RenderTransform = R;

            roadResizeflag = 1;
            NoOfRoads++;
        }



        public void CreateHroad(object obj, int x, int y, int h, int w,int angle,string ParentTag)
        {
            SolidColorBrush brush = new SolidColorBrush();
            //brush.Color = (Color)ColorConverter.ConvertFromString("#02475e");
            brush.Color = Colors.Wheat;

            HRod[HNoOfRoads] = new Canvas();
            HRod[HNoOfRoads].Background = brush;
            HRod[HNoOfRoads].Height = h;
            HRod[HNoOfRoads].Width = w;
            HRod[HNoOfRoads].Margin = new Thickness(x, y, 0, 0);
            HRod[HNoOfRoads].Tag = "H." + HNoOfRoads.ToString(); 
            HRod[HNoOfRoads].PreviewMouseLeftButtonDown += async (sender3, args3) => { };
            HRod[HNoOfRoads].PreviewMouseRightButtonDown += async (sender4, args4) => {  };
       

            //Border
            Border border = new Border();
            border.Height = h;
            border.Width = w;
            border.Background = new SolidColorBrush(Colors.Transparent);
            border.BorderThickness = new Thickness(5);
            border.BorderBrush = new SolidColorBrush(Colors.Transparent);
            border.CornerRadius = new CornerRadius(10);
            HRod[HNoOfRoads].Children.Add(border);


            //Image
            BitmapImage Imagebrush = new BitmapImage(new Uri("###Canvas/Hroad.png", UriKind.Relative));
            Image img = new Image();
            img.Height = HRod[HNoOfRoads].Height;
            img.Width = HRod[HNoOfRoads].Width;
            img.Source = Imagebrush;
            img.Stretch = Stretch.Fill;
            HRod[HNoOfRoads].Children.Add(img);

            //Canvas for moving Hrod but not used here
            Canvas Resize = new Canvas();
            Resize.Background = new SolidColorBrush(Colors.Transparent);
            Resize.Height = 20;
            Resize.Width = 20;
            HRod[HNoOfRoads].Children.Add(Resize);
            
            //Label
            Label Rlabel = new Label();
            Rlabel.Content = "A1";
            Rlabel.FontSize = 30;
            Rlabel.Background = new SolidColorBrush(Colors.White);
            Rlabel.Opacity = 0;
            Rlabel.Height = 80;
            Rlabel.Width = 40;
            Rlabel.Margin = new Thickness(5, 10, 0, 0);
            HRod[HNoOfRoads].Children.Add(Rlabel);


            //canvas for rotation but  not used here
            Canvas Rotate = new Canvas();
            Rotate.Background = new SolidColorBrush(Colors.Transparent);
            Rotate.Height = 20;
            Rotate.Width = 20;
            Rotate.Margin = new Thickness(HRod[HNoOfRoads].Width - 20, 0, 0, 0);
            Rotate.HorizontalAlignment = HorizontalAlignment.Center;
            HRod[HNoOfRoads].Children.Add(Rotate);


            //adding hrod to its parent
            string[] str = new string[20];
            str = ParentTag.Split('.');
            Quad[Convert.ToInt32(str[1])].Children.Add(HRod[HNoOfRoads]);


            //Rotation tranform;
            RotateTransform R = new RotateTransform();
            R.Angle = angle;
            HRod[HNoOfRoads].RenderTransform = R;


            HroadResizeflag = 1;
            HNoOfRoads++;
        }

        public void CreateTall(object obj,int x,int y,int h,int w,int angle,string ParentTag)
        {
            SolidColorBrush brush = new SolidColorBrush();
            brush.Color = Colors.Transparent;

            Toll[NoOfToll] = new Canvas();
            Toll[NoOfToll].Background = brush;
            Toll[NoOfToll].Height = h;
            Toll[NoOfToll].Width = w;
            Toll[NoOfToll].Margin = new Thickness(x, y, 0, 0);
            Toll[NoOfToll].Tag = "H." + NoOfToll.ToString();
            Toll[NoOfToll].PreviewMouseLeftButtonDown += async (sender3, args3) => { };
            Toll[NoOfToll].PreviewMouseRightButtonDown += async (sender4, args4) => { };


            //Border
            Border border = new Border();
            border.Height = h;
            border.Width = w;
            border.Background = new SolidColorBrush(Colors.Transparent);
            border.BorderThickness = new Thickness(5);
            border.BorderBrush = new SolidColorBrush(Colors.Transparent);
            border.CornerRadius = new CornerRadius(10);
            Toll[NoOfToll].Children.Add(border);


            //Image
            BitmapImage Imagebrush = new BitmapImage(new Uri("Canvas/toll.png", UriKind.Relative));
            Image img = new Image();
            img.Height = Toll[NoOfToll].Height;
            img.Width = Toll[NoOfToll].Width;
            img.Source = Imagebrush;
            img.Stretch = Stretch.Fill;
            Toll[NoOfToll].Children.Add(img);

            //Canvas for moving Toll but not used here
            Canvas Resize = new Canvas();
            Resize.Background = new SolidColorBrush(Colors.Transparent);
            Resize.Height = 20;
            Resize.Width = 20;
            Toll[NoOfToll].Children.Add(Resize);

            //Label
            Label Rlabel = new Label();
            Rlabel.Content = "A1";
            Rlabel.FontSize = 30;
            Rlabel.Background = new SolidColorBrush(Colors.White);
            Rlabel.Opacity = 0;
            Rlabel.Height = 80;
            Rlabel.Width = 40;
            Rlabel.Margin = new Thickness(5, 10, 0, 0);
            Toll[NoOfToll].Children.Add(Rlabel);


            //canvas for rotation but  not used here
            Canvas Rotate = new Canvas();
            Rotate.Background = new SolidColorBrush(Colors.Transparent);
            Rotate.Height = 20;
            Rotate.Width = 20;
            Rotate.Margin = new Thickness(Toll[NoOfToll].Width - 20, 0, 0, 0);
            Rotate.HorizontalAlignment = HorizontalAlignment.Center;
            Toll[NoOfToll].Children.Add(Rotate);


            //adding Toll to its parent
            string[] str = new string[20];
            str = ParentTag.Split('.');
            Quad[Convert.ToInt32(str[1])].Children.Add(Toll[NoOfToll]);


            //Rotation tranform;
            RotateTransform R = new RotateTransform();
            R.Angle = angle;
            Toll[NoOfToll].RenderTransform = R;


            HroadResizeflag = 1;
            NoOfToll++;
        }
        public void CreateArrow(object obj, int x, int y, int h, int w, int angle, string ParentTag)
        {
            SolidColorBrush brush = new SolidColorBrush();
            brush.Color = Colors.Transparent;

            Arrow[NoOfArrow] = new Canvas();
            Arrow[NoOfArrow].Background = brush;
            Arrow[NoOfArrow].Height = h;
            Arrow[NoOfArrow].Width = w;
            Arrow[NoOfArrow].Margin = new Thickness(x, y, 0, 0);
            Arrow[NoOfArrow].Tag = "H." + NoOfArrow.ToString();
            Arrow[NoOfArrow].PreviewMouseLeftButtonDown += async (sender3, args3) => { };
            Arrow[NoOfArrow].PreviewMouseRightButtonDown += async (sender4, args4) => { };


            //Border
            Border border = new Border();
            border.Height = h;
            border.Width = w;
            border.Background = new SolidColorBrush(Colors.Transparent);
            border.BorderThickness = new Thickness(5);
            border.BorderBrush = new SolidColorBrush(Colors.Transparent);
            border.CornerRadius = new CornerRadius(10);
            Arrow[NoOfArrow].Children.Add(border);


            //Image
            BitmapImage Imagebrush = new BitmapImage(new Uri("Canvas/Arrow.png", UriKind.Relative));
            Image img = new Image();
            img.Height = Arrow[NoOfArrow].Height;
            img.Width = Arrow[NoOfArrow].Width;
            img.Source = Imagebrush;
            img.Stretch = Stretch.Fill;
            Arrow[NoOfArrow].Children.Add(img);

            //Canvas for moving Arrow but not used here
            Canvas Resize = new Canvas();
            Resize.Background = new SolidColorBrush(Colors.Transparent);
            Resize.Height = 20;
            Resize.Width = 20;
            Arrow[NoOfArrow].Children.Add(Resize);

            //Label
            Label Rlabel = new Label();
            Rlabel.Content = "A1";
            Rlabel.FontSize = 30;
            Rlabel.Background = new SolidColorBrush(Colors.White);
            Rlabel.Opacity = 0;
            Rlabel.Height = 80;
            Rlabel.Width = 40;
            Rlabel.Margin = new Thickness(5, 10, 0, 0);
            Arrow[NoOfArrow].Children.Add(Rlabel);


            //canvas for rotation but  not used here
            Canvas Rotate = new Canvas();
            Rotate.Background = new SolidColorBrush(Colors.Transparent);
            Rotate.Height = 20;
            Rotate.Width = 20;
            Rotate.Margin = new Thickness(Arrow[NoOfArrow].Width - 20, 0, 0, 0);
            Rotate.HorizontalAlignment = HorizontalAlignment.Center;
            Arrow[NoOfArrow].Children.Add(Rotate);


            //adding Arrow to its parent
            string[] str = new string[20];
            str = ParentTag.Split('.');
            Quad[Convert.ToInt32(str[1])].Children.Add(Arrow[NoOfArrow]);


            //Rotation tranform;
            RotateTransform R = new RotateTransform();
            R.Angle = angle;
            Arrow[NoOfArrow].RenderTransform = R;


            HroadResizeflag = 1;
            NoOfArrow++;
        }
        public void CreateConnector(object obj, int x, int y, int h, int w, int angle, string ParentTag)
        {
            SolidColorBrush brush = new SolidColorBrush();
            brush.Color = Colors.Black;

            Connector[NoOfConnector] = new Canvas();
            Connector[NoOfConnector].Background = brush;
            Connector[NoOfConnector].Height = h;
            Connector[NoOfConnector].Width = w;
            Connector[NoOfConnector].Margin = new Thickness(x, y, 0, 0);
            Connector[NoOfConnector].Tag = "H." + NoOfConnector.ToString();
            Connector[NoOfConnector].PreviewMouseLeftButtonDown += async (sender3, args3) => { };
            Connector[NoOfConnector].PreviewMouseRightButtonDown += async (sender4, args4) => { };


            //Border
            Border border = new Border();
            border.Height = h;
            border.Width = w;
            border.Background = new SolidColorBrush(Colors.Transparent);
            border.BorderThickness = new Thickness(5);
            border.BorderBrush = new SolidColorBrush(Colors.Transparent);
            border.CornerRadius = new CornerRadius(10);
            Connector[NoOfConnector].Children.Add(border);


            //Image
            BitmapImage Imagebrush = new BitmapImage(new Uri("Canvas/Connector.png", UriKind.Relative));
            Image img = new Image();
            img.Height = Connector[NoOfConnector].Height;
            img.Width = Connector[NoOfConnector].Width;
            img.Source = Imagebrush;
            img.Stretch = Stretch.Fill;
            Connector[NoOfConnector].Children.Add(img);

            //Canvas for moving Connector but not used here
            Canvas Resize = new Canvas();
            Resize.Background = new SolidColorBrush(Colors.Transparent);
            Resize.Height = 20;
            Resize.Width = 20;
            Connector[NoOfConnector].Children.Add(Resize);

            //Label
            Label Rlabel = new Label();
            Rlabel.Content = "A1";
            Rlabel.FontSize = 30;
            Rlabel.Background = new SolidColorBrush(Colors.White);
            Rlabel.Opacity = 0;
            Rlabel.Height = 80;
            Rlabel.Width = 40;
            Rlabel.Margin = new Thickness(5, 10, 0, 0);
            Connector[NoOfConnector].Children.Add(Rlabel);


            //canvas for rotation but  not used here
            Canvas Rotate = new Canvas();
            Rotate.Background = new SolidColorBrush(Colors.Transparent);
            Rotate.Height = 20;
            Rotate.Width = 20;
            Rotate.Margin = new Thickness(Connector[NoOfConnector].Width - 20, 0, 0, 0);
            Rotate.HorizontalAlignment = HorizontalAlignment.Center;
            Connector[NoOfConnector].Children.Add(Rotate);


            //adding Connector to its parent
            string[] str = new string[20];
            str = ParentTag.Split('.');
            Quad[Convert.ToInt32(str[1])].Children.Add(Connector[NoOfConnector]);


            //Rotation tranform;
            RotateTransform R = new RotateTransform();
            R.Angle = angle;
            Connector[NoOfConnector].RenderTransform = R;


            HroadResizeflag = 1;
            NoOfConnector++;
        }

    }
}
