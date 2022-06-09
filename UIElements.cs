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
using System.Windows.Shapes;


namespace CarParker
{
   public class UIElements
    {


        public Canvas Workspace;
        public int WorkspaceCheckFlag = 0;

        public Canvas CurrentQuad;


        public int CurrentControl = 0;
        public object TempObjectForCopying;
        public int Object_mainthread_distinguish_flag = 0;
        public int CurrentControl_index = 0;
        public PopupMenu popup = new PopupMenu();


        public double SlotPredictionX = 50; public double SlotPredictionXTemp=0;
        public double SlotPredictionY = 50;
        public double slotPredictionHDIFF = 20;
        public double slotPredictionVDIFF = 50;
        public double SlotPredictionWidth=50;
        public double SlotPredictionHeight = 50;
        public int FirstElementInline;
      

        public double LabelSizePrediction = 11;
        public string LabelTextPrediction="A1";



        public Canvas[] Quad = new Canvas[20]; 
        public int NoOfQuad = 0;
        public int QuadCheckFlag = 0;
     

        public Canvas[] Pslot = new Canvas[1000]; 
        public int NoOfPakingSlot = 0;
        public int SlotCheckFlag = 0;



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


        public void Createworkspace(CarParker_Creator C,int x,int y,int h,int w)
        {
            SolidColorBrush brush = new SolidColorBrush();
            brush.Color = Colors.White;





            Workspace = new Canvas();
            Workspace.Background = brush;
            Workspace.Height = h;
            Workspace.Width = w;
            Workspace.Margin = new Thickness(x, y, 0, 0);
            Workspace.Tag = "W.1";

             Workspace.PreviewMouseLeftButtonDown += async (Senderr, Argss) => { if (C.Cursor == Cursors.Arrow) CurrentControl = -1;   };
            Workspace.PreviewMouseRightButtonDown += async (Senderr, Argss) => { if (C.Cursor == Cursors.Arrow) CurrentControl = -1;   };
            C.Scrol1Canvas.Children.Add(Workspace);

            Border B = new Border();
            B.BorderThickness = new Thickness(5);
            B.BorderBrush = new SolidColorBrush(Colors.White);
            B.Width = Workspace.Width;
            B.Height = Workspace.Height;
            Workspace.Children.Add(B);
            B.Background = new SolidColorBrush(Colors.Transparent);
            
            BitmapImage Imagebrush = new BitmapImage(new Uri(" ", UriKind.Relative));
            Image img = new Image();
            img.Height =Workspace.Height;
            img.Width = Workspace.Width;
            img.Source = Imagebrush;
            img.Stretch = Stretch.Fill;
            Workspace.Children.Add(img);

            Canvas Resize = new Canvas();
            Resize.Background = new SolidColorBrush(Colors.Transparent);
            Resize.Height = 20;
            Resize.Width = 20;
            Workspace.Children.Add(Resize);

            Label Rlabel = new Label();
            Rlabel.Content = "A1";
            Rlabel.FontSize = 30;
            Rlabel.Background = new SolidColorBrush(Colors.White);
            Rlabel.Opacity = 0;
            Rlabel.Height = 80;
            Rlabel.Width = 40;
            Rlabel.Margin = new Thickness(5, 10, 0, 0);
            Workspace.Children.Add(Rlabel);

            Canvas Rotate = new Canvas();
            Rotate.Background = new SolidColorBrush(Colors.Transparent);
            Rotate.Height = 20;
            Rotate.Width = 20;
            Rotate.Margin = new Thickness(Workspace.Width - 20, 0, 0, 0);
            Rotate.HorizontalAlignment = HorizontalAlignment.Center;
            Workspace.Children.Add(Rotate);


            ScaleTransform S = new ScaleTransform();
            S.ScaleX = 0.3;
            S.ScaleY = 0.3;
       
            Workspace.RenderTransform = S;

            WorkspaceCheckFlag = 1;


        }

        public void CreateQuad(CarParker_Creator C, int x, int y, int h, int w,int angle=0)
        {
            SolidColorBrush brush = new SolidColorBrush();
            brush.Color = Colors.Transparent;

            Quad[NoOfQuad] = new Canvas();
            Quad[NoOfQuad].Background = brush;
            Quad[NoOfQuad].Height = h;
            Quad[NoOfQuad].Width = w;
            Quad[NoOfQuad].Margin = new Thickness(x, y, 0, 0);
            Quad[NoOfQuad].Tag = "Q." + NoOfQuad.ToString();
            Quad[NoOfQuad].PreviewMouseLeftButtonUp+= async (sender3, args3) =>{ if(C.Cursor==Cursors.Arrow)CurrentControl = 0; CurrentQuad = ((Canvas)sender3); ((Canvas)sender3).Children.Remove(popup.st);  };
            Quad[NoOfQuad].PreviewMouseRightButtonUp+= async (sender3, args3) =>{ if (C.Cursor == Cursors.Arrow) CurrentControl = 0; CurrentQuad = ((Canvas)sender3); CurrentQuad.Children.Remove(popup.st); Object_mainthread_distinguish_flag = 0; popup.MenuPopUp(sender3, Quad,this, C); };
            
         
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

            //Canvas for movement of quad
            Canvas Resize = new Canvas();
            Resize.Background = new SolidColorBrush(Colors.Transparent);
            Resize.Height = 20;
            Resize.Width = 20;
            Quad[NoOfQuad].Children.Add(Resize);
          

            //Label 
            Label Rlabel = new Label();
            Rlabel.Content = "A1";
            Rlabel.FontSize = 30;
            Rlabel.Background = new SolidColorBrush(Colors.White);
            Rlabel.Opacity = 0;
            Rlabel.Height = 80;
            Rlabel.Width = 40;
            Rlabel.Margin = new Thickness(5, 10, 0, 0);
            Quad[NoOfQuad].Children.Add(Rlabel);

            //Canvas for rotation
            Canvas Rotate = new Canvas();
            Rotate.Background = new SolidColorBrush(Colors.Transparent);
            Rotate.Height = 20;
            Rotate.Width = 20;
            Rotate.Margin = new Thickness(Quad[NoOfQuad].Width-20,0, 0, 0);
            Rotate.HorizontalAlignment = HorizontalAlignment.Center;
            Quad[NoOfQuad].Children.Add(Rotate);

            //HorzontalAlignLine
            Line Horizontal_Align_line = new Line()
            { Visibility = Visibility.Hidden,
                Stroke = new SolidColorBrush(Colors.Red),
                X1 = 0,
                X2 =  Quad[NoOfQuad].Width
                  
            };
            Quad[NoOfQuad].Children.Add(Horizontal_Align_line);

            Line Vertical_Align_line = new Line()
            {
                Visibility = Visibility.Hidden,
                Stroke = new SolidColorBrush(Colors.Blue),
                Y1 = 0,
                Y2 = Quad[NoOfQuad].Height

            };
            Quad[NoOfQuad].Children.Add(Vertical_Align_line);



            CurrentQuad = Quad[NoOfQuad]; 
            Workspace.Children.Add(Quad[NoOfQuad]);


            RotateTransform R = new RotateTransform();
            R.Angle = angle;
            Quad[NoOfQuad].RenderTransform = R;

            QuadCheckFlag = 1;
            NoOfQuad++;
        }


        public void CreatePslot(CarParker_Creator C, Canvas Parent, double  x,double y,double h,double w,string labeltext,int angle=0)
         {


           
            SolidColorBrush brush = new SolidColorBrush();
            brush.Color = Colors.Transparent;                            //(Color) ColorConverter.ConvertFromString("#435560");
         

            Pslot[NoOfPakingSlot] = new Canvas();
            Pslot[NoOfPakingSlot].Background = brush;
            Pslot[NoOfPakingSlot].Height = h;
            Pslot[NoOfPakingSlot].Width = w;
            Pslot[NoOfPakingSlot].Margin = new Thickness(x, y, 0, 0);
            Pslot[NoOfPakingSlot].Tag = "P." + NoOfPakingSlot.ToString(); 
            Pslot[NoOfPakingSlot].PreviewMouseLeftButtonUp += async (sender2, args2) => { if (C.Cursor == Cursors.Arrow) CurrentControl = 1; };
            Pslot[NoOfPakingSlot].PreviewMouseRightButtonUp += async (sender3, args3) => { if (C.Cursor == Cursors.Arrow) CurrentControl = 1; CurrentQuad.Children.Remove(popup.st); Object_mainthread_distinguish_flag = 1; popup.MenuPopUp(sender3, Pslot, this, C); };

            
            //Border
            Border border = new Border();
            border.Height = h;
            border.Width = w;
            border.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#435560"));
            border.BorderThickness = new Thickness(5);
            border.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#435560"));
            border.CornerRadius = new CornerRadius(10);
            Pslot[NoOfPakingSlot].Children.Add(border);
         

            //Image
            BitmapImage Imagebrush = new BitmapImage(new Uri("", UriKind.Relative));
            Image img = new Image();
            img.Height = Pslot[NoOfPakingSlot].Height;
            img.Width = Pslot[NoOfPakingSlot].Width;
            img.Source = Imagebrush;
            img.Stretch = Stretch.Fill;
            Pslot[NoOfPakingSlot].Children.Add(img);

            //canvas for movement of Pslot
            Canvas Resize = new Canvas();
            Resize.Background = brush;
            Resize.Height = 20;
            Resize.Width = 20;
            Pslot[NoOfPakingSlot].Children.Add(Resize);

            //Label
            Label Plabel = new Label();
            Plabel.Content = labeltext;
            LabelTextPrediction = labeltext;
            Plabel.Background = new SolidColorBrush(Colors.Transparent);
            Plabel.Height = Pslot[NoOfPakingSlot].Height-20;
            Plabel.Width = Pslot[NoOfPakingSlot].Width - 10;
           
           /* if (Plabel.Width<34)
            {
                LabelSizePrediction = 11;
            }*/

            Plabel.FontSize = 11;
            Plabel.Margin = new Thickness(5, 10, 0, 0);
            Plabel.HorizontalContentAlignment = HorizontalAlignment.Center;
            Plabel.VerticalContentAlignment = VerticalAlignment.Center;
            Plabel.Foreground = new SolidColorBrush(Colors.White);
            Plabel.FontFamily = new FontFamily("Franklin Gothic Heavy");
            Pslot[NoOfPakingSlot].Children.Add(Plabel);
            
        

            //Canvas Rotation
            Canvas Rotate = new Canvas();
            Rotate.Background = new SolidColorBrush(Colors.Transparent);
            Rotate.Height = 20;
            Rotate.Width = 20;
            Rotate.Margin = new Thickness(Pslot[NoOfPakingSlot].Width - 20, 0, 0, 0);
            Rotate.HorizontalAlignment = HorizontalAlignment.Center;
            Pslot[NoOfPakingSlot].Children.Add(Rotate);



            //adding pslot to current parent 
            Parent.Children.Add(Pslot[NoOfPakingSlot]);


            RotateTransform R = new RotateTransform();
            R.Angle = angle;
            Pslot[NoOfPakingSlot].RenderTransform = R;


            
            NoOfPakingSlot++;

          


        }



        public void CreateRoad(CarParker_Creator C, Canvas Parent, int x, int y, int h, int w,int angle=0)
        {
            SolidColorBrush brush = new SolidColorBrush();
            brush.Color = Colors.Wheat;
           // brush.Color = (Color)ColorConverter.ConvertFromString("#02475e");

            Rod[NoOfRoads] = new Canvas();
            Rod[NoOfRoads].Background = brush;
            Rod[NoOfRoads].Height = h;
            Rod[NoOfRoads].Width = w;
            Rod[NoOfRoads].Margin = new Thickness(x, y, 0, 0);
            Rod[NoOfRoads].Tag = "R." + NoOfRoads.ToString();
            Rod[NoOfRoads].PreviewMouseLeftButtonUp += async (sender3, args3) => { if (C.Cursor == Cursors.Arrow) CurrentControl = 2; };
            Rod[NoOfRoads].PreviewMouseRightButtonUp += async (sender4, args4) => { if (C.Cursor == Cursors.Arrow) CurrentControl = 2; CurrentQuad.Children.Remove(popup.st); Object_mainthread_distinguish_flag = 1; popup.MenuPopUp(sender4,Rod, this,C); };
           

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

            //Canvas for movement of Rod
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

            //Canvas for rotation
            Canvas Rotate = new Canvas();
            Rotate.Background = new SolidColorBrush(Colors.Transparent);
            Rotate.Height = 20;
            Rotate.Width = 20;
            Rotate.Margin = new Thickness(Rod[NoOfRoads].Width - 20, 0, 0, 0);
            Rotate.HorizontalAlignment = HorizontalAlignment.Center;
            Rod[NoOfRoads].Children.Add(Rotate);

            //adding Rod to current parent
            Parent.Children.Add(Rod[NoOfRoads]);

            //Rotation trasnformation
            RotateTransform R = new RotateTransform();
            R.Angle = angle;
            Rod[NoOfRoads].RenderTransform = R;

            roadResizeflag = 1;
         
            NoOfRoads++;
            
        }

        public void CreateHroad(CarParker_Creator C, Canvas Parent, int x, int y, int h, int w,int angle=0)
        {
            SolidColorBrush brush = new SolidColorBrush();
            brush.Color = Colors.Wheat;
            //brush.Color = (Color)ColorConverter.ConvertFromString("#02475e");

            HRod[HNoOfRoads] = new Canvas();
            HRod[HNoOfRoads].Background = brush;
            HRod[HNoOfRoads].Height =h;
            HRod[HNoOfRoads].Width = w;
            HRod[HNoOfRoads].Margin = new Thickness(x, y, 0, 0);
            HRod[HNoOfRoads].Tag = "H." + HNoOfRoads.ToString(); 
            HRod[HNoOfRoads].PreviewMouseLeftButtonUp += async (sender3, args3) => { if (C.Cursor == Cursors.Arrow) CurrentControl = 3; };
            HRod[HNoOfRoads].PreviewMouseRightButtonUp += async (sender4, args4) => { if (C.Cursor == Cursors.Arrow) CurrentControl = 3; CurrentQuad.Children.Remove(popup.st); Object_mainthread_distinguish_flag = 1; popup.MenuPopUp(sender4, HRod,this, C); };
          

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
            BitmapImage Imagebrush = new BitmapImage(new Uri("####Canvas/Hroad.png", UriKind.Relative));
            Image img = new Image();
            img.Height = HRod[HNoOfRoads].Height;
            img.Width = HRod[HNoOfRoads].Width;
            img.Source = Imagebrush;
            img.Stretch = Stretch.Fill;
            HRod[HNoOfRoads].Children.Add(img);

            //Canvas for Movement of Hrod
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


            //canvas for rotating Hrod 
            Canvas Rotate = new Canvas();
            Rotate.Background = new SolidColorBrush(Colors.Transparent);
            Rotate.Height = 20;
            Rotate.Width = 20;
            Rotate.Margin = new Thickness(HRod[HNoOfRoads].Width - 20, 0, 0, 0);
            Rotate.HorizontalAlignment = HorizontalAlignment.Center;
            HRod[HNoOfRoads].Children.Add(Rotate);

           
            //adding Hrod to current parent
            Parent.Children.Add(HRod[HNoOfRoads]);

            //Rotation tranform;
            RotateTransform R = new RotateTransform();
            R.Angle = angle;
            HRod[HNoOfRoads].RenderTransform = R;

            HroadResizeflag = 1;
            HNoOfRoads++;
        }

        public void CreateToll(CarParker_Creator C, Canvas Parent, int x, int y, int h, int w, int angle = 0)
        {
            SolidColorBrush brush = new SolidColorBrush();
            brush.Color = Colors.Transparent;

            Toll[NoOfToll] = new Canvas();
            Toll[NoOfToll].Background = brush;
            Toll[NoOfToll].Height = h;
            Toll[NoOfToll].Width = w;
            Toll[NoOfToll].Margin = new Thickness(x, y, 0, 0);
            Toll[NoOfToll].Tag = "T." + NoOfToll.ToString();
            Toll[NoOfToll].PreviewMouseLeftButtonUp += async (sender3, args3) => { if (C.Cursor == Cursors.Arrow) CurrentControl = 4; };
            Toll[NoOfToll].PreviewMouseRightButtonUp += async (sender4, args4) => { if (C.Cursor == Cursors.Arrow) CurrentControl = 4; CurrentQuad.Children.Remove(popup.st); Object_mainthread_distinguish_flag = 1; popup.MenuPopUp(sender4, Toll, this, C); };


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

            //Canvas for Movement of Toll
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


            //canvas for rotating Toll 
            Canvas Rotate = new Canvas();
            Rotate.Background = new SolidColorBrush(Colors.Transparent);
            Rotate.Height = 20;
            Rotate.Width = 20;
            Rotate.Margin = new Thickness(Toll[NoOfToll].Width - 20, 0, 0, 0);
            Rotate.HorizontalAlignment = HorizontalAlignment.Center;
            Toll[NoOfToll].Children.Add(Rotate);


            //adding Toll to current parent
            Parent.Children.Add(Toll[NoOfToll]);

            //Rotation tranform;
            RotateTransform R = new RotateTransform();
            R.Angle = angle;
            Toll[NoOfToll].RenderTransform = R;

            HroadResizeflag = 1;
            NoOfToll++;
        }


        public void CreateArrow(CarParker_Creator C, Canvas Parent, int x, int y, int h, int w, int angle = 0)
        {
            SolidColorBrush brush = new SolidColorBrush();
            brush.Color = Colors.Transparent;

            Arrow[NoOfArrow] = new Canvas();
            Arrow[NoOfArrow].Background = brush;
            Arrow[NoOfArrow].Height = h;
            Arrow[NoOfArrow].Width = w;
            Arrow[NoOfArrow].Margin = new Thickness(x, y, 0, 0);
            Arrow[NoOfArrow].Tag = "A." + NoOfArrow.ToString();
            Arrow[NoOfArrow].PreviewMouseLeftButtonUp += async (sender3, args3) => { if (C.Cursor == Cursors.Arrow) CurrentControl = 5; };
            Arrow[NoOfArrow].PreviewMouseRightButtonUp+= async (sender4, args4) => { if (C.Cursor == Cursors.Arrow) CurrentControl = 5; CurrentQuad.Children.Remove(popup.st); Object_mainthread_distinguish_flag = 1; popup.MenuPopUp(sender4, Arrow, this, C); };


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

            //Canvas for Movement of Arrow
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


            //canvas for rotating Arrow 
            Canvas Rotate = new Canvas();
            Rotate.Background = new SolidColorBrush(Colors.Transparent);
            Rotate.Height = 20;
            Rotate.Width = 20;
            Rotate.Margin = new Thickness(Arrow[NoOfArrow].Width - 20, 0, 0, 0);
            Rotate.HorizontalAlignment = HorizontalAlignment.Center;
            Arrow[NoOfArrow].Children.Add(Rotate);


            //adding Arrow to current parent
            Parent.Children.Add(Arrow[NoOfArrow]);

            //Rotation tranform;
            RotateTransform R = new RotateTransform();
            R.Angle = angle;
            Arrow[NoOfArrow].RenderTransform = R;

            HroadResizeflag = 1;
            NoOfArrow++;
        }


        public void CreateConnector(CarParker_Creator C, Canvas Parent, int x, int y, int h, int w, int angle = 0)
        {
            SolidColorBrush brush = new SolidColorBrush();
            brush.Color = Colors.Black;

           Connector[NoOfConnector] = new Canvas();
           Connector[NoOfConnector].Background = brush;
           Connector[NoOfConnector].Height = h;
           Connector[NoOfConnector].Width = w;
           Connector[NoOfConnector].Margin = new Thickness(x, y, 0, 0);
           Connector[NoOfConnector].Tag = "C." + NoOfConnector.ToString();
           Connector[NoOfConnector].PreviewMouseLeftButtonUp += async (sender3, args3) => { if (C.Cursor == Cursors.Arrow) CurrentControl = 6; };
           Connector[NoOfConnector].PreviewMouseRightButtonUp += async (sender4, args4) => { if (C.Cursor == Cursors.Arrow) CurrentControl = 6; CurrentQuad.Children.Remove(popup.st); Object_mainthread_distinguish_flag = 1; popup.MenuPopUp(sender4,Connector, this, C); };


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
            img.Height =Connector[NoOfConnector].Height;
            img.Width =Connector[NoOfConnector].Width;
            img.Source = Imagebrush;
            img.Stretch = Stretch.Fill;
           Connector[NoOfConnector].Children.Add(img);

            //Canvas for Movement ofConnector
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


            //canvas for rotatingConnector 
            Canvas Rotate = new Canvas();
            Rotate.Background = new SolidColorBrush(Colors.Transparent);
            Rotate.Height = 20;
            Rotate.Width = 20;
            Rotate.Margin = new Thickness(Connector[NoOfConnector].Width - 20, 0, 0, 0);
            Rotate.HorizontalAlignment = HorizontalAlignment.Center;
           Connector[NoOfConnector].Children.Add(Rotate);


            //addingConnector to current parent
            Parent.Children.Add(Connector[NoOfConnector]);

            //Rotation tranform;
            RotateTransform R = new RotateTransform();
            R.Angle = angle;
           Connector[NoOfConnector].RenderTransform = R;

            HroadResizeflag = 1;
            NoOfConnector++;
        }


        public void SlotLabelTextPredictor(Canvas []TempCanvasArray,int index)
        {


            string  Temptext = LabelTextPrediction;
            string [] textsplitter=new string[2];



            for (int i = 0; i < Temptext.Length; i++)
            {
                if (char.IsLetter(Temptext[i]))
                {
                    textsplitter[0] += Temptext[i].ToString();
                }

                if (char.IsNumber(Temptext[i]))
                {
                    textsplitter[1] += Temptext[i].ToString();
                }

            }

            int tempint = Convert.ToInt32(textsplitter[1]);

            if(Convert.ToInt32(SlotPredictionY)>Convert.ToInt32(TempCanvasArray[index].Margin.Top))
            {

                tempint = 0;
                char[] temp;
                temp = textsplitter[0].ToCharArray();

                for (int k = 0; k < temp.Length; k++)
                {

                    if (k + 1 < temp.Length)
                    {
                        if (temp[k + 1] == 'Z')        //if Z comes Incremet previous letter
                        {
                            temp[k]++;
                        }
                    }
                    else                               //in case if there is only one Letter
                    {
                        if (temp[k] == 'Z')
                        {
                            temp[k] = 'A';
                            temp[k + 1] = 'A';

                        }
                        temp[k]++;

                    }



                }
                textsplitter[0] = new string(temp);
          

            }


          
            LabelTextPrediction = textsplitter[0] + (++tempint).ToString();
         



        }









    }
}
