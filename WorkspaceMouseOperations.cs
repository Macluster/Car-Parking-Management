using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
namespace CarParker
{
    class WorkspaceMouseOperations
    {

        public Canvas HOLDERCANVAS;
        public double Angle;
        public void MouseOperation(Canvas TEMPCANVAS, CarParker_Creator C, UIElements U, MouseEventArgs e, int NoFCanvas, int flag)
        {







               HOLDERCANVAS = C.Scrol1Canvas;




            for (int i = 0; i < NoFCanvas; i++)
            {




                Canvas Resize;
                Canvas Rotate;


                Resize = (Canvas)(TEMPCANVAS.Children[2]);
                Rotate = (Canvas)(TEMPCANVAS.Children[4]);






                if (C.MouseDown_flag == 0)
                {

                    Point point2 = Mouse.GetPosition(TEMPCANVAS);

                    Point point = Mouse.GetPosition(HOLDERCANVAS);


                    if (point.X > TEMPCANVAS.Margin.Left+C.SCaleValue*100 + TEMPCANVAS.Width - 5 && point.X < TEMPCANVAS.Margin.Left + TEMPCANVAS.Width+C.SCaleValue*100 + 5 && point.Y > TEMPCANVAS.Margin.Top && point.Y < TEMPCANVAS.Margin.Top + TEMPCANVAS.Height)
                    {
                        C.Cursor = Cursors.SizeWE;

                    

                        break;
                    }
                    else if (point.Y > TEMPCANVAS.Margin.Top + TEMPCANVAS.Height - 5 && point.Y < TEMPCANVAS.Margin.Top + TEMPCANVAS.Height + 5 && point.X > TEMPCANVAS.Margin.Left && point.X < TEMPCANVAS.Margin.Left + TEMPCANVAS.Width)
                    {
                        C.Cursor = Cursors.SizeNS;
               

                        break;
                    }

                    else if (point2.X > 0 && point2.X < Resize.Width && point2.Y > 0 && point2.Y < Resize.Height)
                    {
                        C.Cursor = Cursors.Hand;

                        Resize.Background = new SolidColorBrush(Colors.Yellow);

             

                        break;

                    }
                    else if (point2.X > Rotate.Margin.Left && point2.X < Rotate.Margin.Left + Rotate.Width && point2.Y > 0 && point2.Y < Rotate.Height)
                    {
                        C.Cursor = Cursors.ScrollAll;

                        Rotate.Background = new SolidColorBrush(Colors.Green);


                        break;

                    }
                    else
                    {


                        Resize.Background = new SolidColorBrush(Colors.Transparent);
                        Rotate.Background = new SolidColorBrush(Colors.Transparent);
                        C.Cursor = Cursors.Arrow;
           
                    }
                }
                /////////////////////////

            }



            if (NoFCanvas > 0)
            {

                if (C.MouseDown_flag == 1 && C.Cursor == Cursors.SizeWE)
                {

                    C.DebugBox.Text = TEMPCANVAS.Width.ToString();

                    //To restrict The width of pslot to change less than 50
                  

                        TEMPCANVAS.Width = e.GetPosition(HOLDERCANVAS).X - TEMPCANVAS.Margin.Left;
                      


             
                   






                        ((Border)(TEMPCANVAS.Children[0])).Width = TEMPCANVAS.Width;

                    ((Image)(TEMPCANVAS.Children[1])).Width = TEMPCANVAS.Width;

                    ((Label)(TEMPCANVAS.Children[3])).Width = TEMPCANVAS.Width - 10; //label














                }
                else if (C.MouseDown_flag == 2 && C.Cursor == Cursors.SizeNS)
                {

                    TEMPCANVAS.Height = e.GetPosition(HOLDERCANVAS).Y - TEMPCANVAS.Margin.Top;




                    if (U.CurrentControl == 1)
                        U.SlotPredictionHeight = e.GetPosition(U.CurrentQuad).Y - TEMPCANVAS.Margin.Top;


                    ((Border)(TEMPCANVAS.Children[0])).Height = TEMPCANVAS.Height;

                    ((Image)(TEMPCANVAS.Children[1])).Height = TEMPCANVAS.Height;

                    ((Label)(TEMPCANVAS.Children[3])).Height = TEMPCANVAS.Height - 17; //label



                }
                else if (C.MouseDown_flag == 3 && C.Cursor == Cursors.Hand)
                {
                    TEMPCANVAS.Margin = new Thickness(e.GetPosition(HOLDERCANVAS).X, e.GetPosition(HOLDERCANVAS).Y, 0, 0);
                }


                else if (C.MouseDown_flag == 4 && C.Cursor == Cursors.ScrollAll)
                {
                    RotateTransform R = new RotateTransform();
                    Angle = Convert.ToInt32(e.GetPosition(U.Workspace).Y - TEMPCANVAS.Margin.Right);
                    R.Angle = Angle;
                    TEMPCANVAS.RenderTransform = R;


                }
            }



        }



    }
}
