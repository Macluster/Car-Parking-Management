using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
namespace CarParker
{
    class MouseOperations
    {
        public Canvas[] TEMPCANVAS;
        public Canvas HOLDERCANVAS;
        public int Limtflag = 0;
        public int Angle = 30;
        public void  MouseOperation(object CanvasObject,CarParker_Creator C,UIElements U, MouseEventArgs e ,int NoFCanvas,int flag)
        {

            //putting the control that clicked, into temprorry canvas
            TEMPCANVAS = ((Canvas[])CanvasObject);


            //if current cuntrol is zero then it is Quad make its parent has workspace 
            if (U.CurrentControl == 0)
                HOLDERCANVAS = U.Workspace;
            else
                HOLDERCANVAS = U.CurrentQuad;


          



                for (int i = 0; i < NoFCanvas; i++)
                {




                    Canvas Resize;
                    Canvas Rotate;

              
                    Resize = (Canvas)(TEMPCANVAS[i].Children[2]);
                    Rotate = (Canvas)(TEMPCANVAS[i].Children[4]);
                
              




                    if (  C.MouseDown_flag == 0)
                    {
                   
                        Point point2 = Mouse.GetPosition(TEMPCANVAS[i]);

                        Point point = Mouse.GetPosition(HOLDERCANVAS);
                   
            
                        if (point.X > TEMPCANVAS[i].Margin.Left +TEMPCANVAS[i].Width - 5 && point.X <TEMPCANVAS[i].Margin.Left +TEMPCANVAS[i].Width + 5 && point.Y >TEMPCANVAS[i].Margin.Top && point.Y <TEMPCANVAS[i].Margin.Top +TEMPCANVAS[i].Height)
                        {
                            C.Cursor = Cursors.SizeWE;

                            U.CurrentControl_index = i;

                            break;
                        }
                        else if (point.Y >TEMPCANVAS[i].Margin.Top +TEMPCANVAS[i].Height - 5 && point.Y <TEMPCANVAS[i].Margin.Top +TEMPCANVAS[i].Height + 5 && point.X >TEMPCANVAS[i].Margin.Left && point.X <TEMPCANVAS[i].Margin.Left +TEMPCANVAS[i].Width)
                        {
                            C.Cursor = Cursors.SizeNS;
                            U.CurrentControl_index = i;

                            break;
                        }

                        else if (point2.X > 0 && point2.X < Resize.Width && point2.Y > 0 && point2.Y < Resize.Height)
                        {
                            C.Cursor = Cursors.Hand;

                            Resize.Background = new SolidColorBrush(Colors.Yellow);

                            U.CurrentControl_index = i;

                            break;

                        }
                        else if (point2.X >Rotate.Margin.Left && point2.X < Rotate.Margin.Left+Rotate.Width && point2.Y > 0 && point2.Y < Rotate.Height)
                        {
                            C.Cursor = Cursors.ScrollAll;

                            Rotate.Background = new SolidColorBrush(Colors.Green);

                            U.CurrentControl_index = i;

                            break;

                        }
                        else
                        {


                            Resize.Background = new SolidColorBrush(Colors.Transparent);
                            Rotate.Background = new SolidColorBrush(Colors.Transparent);
                            C.Cursor = Cursors.Arrow;
                            U.CurrentControl_index = i;
                     



                        }
                    }
                    

                }

//////////////////////////////////////////////////////////////////////////////////////////////////////////////

            if (NoFCanvas > 0)
            {

                if (C.MouseDown_flag == 1 && C.Cursor == Cursors.SizeWE)
                {

                    C.DebugBox.Text = TEMPCANVAS[U.CurrentControl_index].Width.ToString();

                    //To restrict The width of pslot to change less than 50
                    if (TEMPCANVAS[U.CurrentControl_index].Width < 40 && e.GetPosition(U.CurrentQuad).X < TEMPCANVAS[U.CurrentControl_index].Margin.Left + TEMPCANVAS[U.CurrentControl_index].Width)
                    {

                    }
                    else
                    {

                        TEMPCANVAS[U.CurrentControl_index].Width = e.GetPosition(HOLDERCANVAS).X - TEMPCANVAS[U.CurrentControl_index].Margin.Left;
                        ((Canvas)TEMPCANVAS[U.CurrentControl_index].Children[4]).Margin = new Thickness(TEMPCANVAS[U.CurrentControl_index].Width - 20, 0, 0, 0);


                        if (U.CurrentControl == 1)
                            U.SlotPredictionWidth = e.GetPosition(U.CurrentQuad).X - TEMPCANVAS[U.CurrentControl_index].Margin.Left;
                    }





                    //changing children controls to same width as parrent
                    ((Border)(TEMPCANVAS[U.CurrentControl_index].Children[0])).Width = TEMPCANVAS[U.CurrentControl_index].Width;

                    ((Image)(TEMPCANVAS[U.CurrentControl_index].Children[1])).Width = TEMPCANVAS[U.CurrentControl_index].Width;

                    ((Label)(TEMPCANVAS[U.CurrentControl_index].Children[3])).Width = TEMPCANVAS[U.CurrentControl_index].Width - 10; //label

                    if (((Label)(TEMPCANVAS[U.CurrentControl_index].Children[3])).Width < 50) //To restrict redce the label size  after the limit
                    {
                        ((Label)(TEMPCANVAS[U.CurrentControl_index].Children[3])).FontSize = 11;
                        U.LabelSizePrediction = 11;

                    }


                    else
                    {
                        ((Label)(TEMPCANVAS[U.CurrentControl_index].Children[3])).FontSize = 25;
                        U.LabelSizePrediction = 25;
                    }



                    // To Resize the HorizontalAlignLine of current quad
                    if(U.CurrentControl==0)
                    {
                        ((Line)TEMPCANVAS[U.CurrentControl_index].Children[5]).X2 = TEMPCANVAS[U.CurrentControl_index].Width;
                    }







                }
                else if (C.MouseDown_flag == 2 && C.Cursor == Cursors.SizeNS)
                {

                    TEMPCANVAS[U.CurrentControl_index].Height = e.GetPosition(HOLDERCANVAS).Y - TEMPCANVAS[U.CurrentControl_index].Margin.Top;




                    if (U.CurrentControl == 1)
                        U.SlotPredictionHeight = e.GetPosition(U.CurrentQuad).Y - TEMPCANVAS[U.CurrentControl_index].Margin.Top;

                    //changing children controls to same height as parrent
                    ((Border)(TEMPCANVAS[U.CurrentControl_index].Children[0])).Height = TEMPCANVAS[U.CurrentControl_index].Height;

                    ((Image)(TEMPCANVAS[U.CurrentControl_index].Children[1])).Height = TEMPCANVAS[U.CurrentControl_index].Height;

                    ((Label)(TEMPCANVAS[U.CurrentControl_index].Children[3])).Height = TEMPCANVAS[U.CurrentControl_index].Height - 17; //label


                    // To Resize the VerticalAlignLine of current quad
                    if (U.CurrentControl == 0)
                    {
                        ((Line)TEMPCANVAS[U.CurrentControl_index].Children[6]).Y2 = TEMPCANVAS[U.CurrentControl_index].Height;
                    }



                }
                else if (C.MouseDown_flag == 3 && C.Cursor == Cursors.Hand)
                {


                    TEMPCANVAS[U.CurrentControl_index].Margin = new Thickness(e.GetPosition(HOLDERCANVAS).X, e.GetPosition(HOLDERCANVAS).Y, 0, 0);

                    //To posiition the linw as same as pslot
                    if(U.CurrentControl==1)
                    {
                        ((Line)U.CurrentQuad.Children[5]).Y1 = e.GetPosition(HOLDERCANVAS).Y;
                        ((Line)U.CurrentQuad.Children[5]).Y2 = e.GetPosition(HOLDERCANVAS).Y;
                        ((Line)U.CurrentQuad.Children[5]).Visibility = Visibility.Visible;

                        ((Line)U.CurrentQuad.Children[6]).X1 = e.GetPosition(HOLDERCANVAS).X;
                        ((Line)U.CurrentQuad.Children[6]).X2 = e.GetPosition(HOLDERCANVAS).X;
                        ((Line)U.CurrentQuad.Children[6]).Visibility = Visibility.Visible;

                    }




                    // To Handle slot
                    if (U.CurrentControl == 1)
                        U.SlotPredictionX = U.Pslot[U.NoOfPakingSlot - 1].Margin.Left + U.SlotPredictionWidth + U.slotPredictionHDIFF;

                    if (C.NextRowCheckFlag == 1)
                    {
                        U.SlotPredictionY = e.GetPosition(U.CurrentQuad).Y;
                    }

                    if (U.CurrentControl == 1 && U.CurrentControl_index == U.FirstElementInline)// here U.CurrentControl_index == U.NoOfPakingSlot-1 because height can be changed with last slot made only
                    {

                        U.SlotPredictionY = Convert.ToInt32(e.GetPosition(U.CurrentQuad).Y);
                    }

                    if (U.CurrentControl == 1 && U.CurrentControl_index == 1)
                    {
                        // U.slotPredictionHDIFF = e.GetPosition(U.CurrentQuad).X - (U.Pslot[U.NoOfPakingSlot-2].Margin.Left + U.Pslot[U.NoOfPakingSlot-2].Width); //to provide prediction of next pslot
                        // U.SlotPredictionX = U.Pslot[U.NoOfPakingSlot-1].Margin.Left + U.SlotPredictionWidth + U.slotPredictionHDIFF;

                        U.slotPredictionHDIFF = e.GetPosition(U.CurrentQuad).X - (U.Pslot[0].Margin.Left + U.Pslot[0].Width); //to provide prediction of next pslot
                        U.SlotPredictionX = U.Pslot[1].Margin.Left + U.SlotPredictionWidth + U.slotPredictionHDIFF;

                        C.DebugBox.Text = U.slotPredictionHDIFF.ToString();
                    }



                }


                else if (C.MouseDown_flag == 4 && C.Cursor == Cursors.ScrollAll)
                {
                    RotateTransform R = new RotateTransform();
                    Angle = Convert.ToInt32(e.GetPosition(U.Workspace).Y-TEMPCANVAS[U.CurrentControl_index].Margin.Right);
                    R.Angle=Angle ;
                    TEMPCANVAS[U.CurrentControl_index].RenderTransform = R;
                    ((Border)TEMPCANVAS[U.CurrentControl_index].Children[0]).Tag = Angle;

                }
            }

           

        }


    }
}
