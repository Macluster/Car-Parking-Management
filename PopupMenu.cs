using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows;
using System.Windows.Media.Imaging;
namespace CarParker
{
    public class PopupMenu
    {


        public int MenuPopUp_flag = 0;
        public StackPanel st;
        public Canvas HolderLayo;
        public void  MenuPopUp(object sender, object []obj ,UIElements U, CarParker_Creator C)
        {

            //putting the control that clicked into temprorry canvas
            Canvas TempCanvas = new Canvas();
            TempCanvas = (Canvas)sender;

            //if current cuntrol is zero then it is Quad make its parent has workspace 
            if (U.CurrentControl == 0)
                HolderLayo = U.Workspace;
            else
                HolderLayo = U.CurrentQuad;


            //location in cuurent quad for popup location
            Point point = Mouse.GetPosition(U.CurrentQuad);
            
            

            SolidColorBrush brush = new SolidColorBrush();
            brush.Color = Colors.White;
            st = new StackPanel();
            st.Background = brush;



            // to distinguish btw current quad and other controls to display popup
            if (U.CurrentControl != 0)
            {


                st.Margin = new Thickness(TempCanvas.Margin.Left, TempCanvas.Margin.Top + 20, 0, 0);


            }
            else
            {
                st.Margin = new Thickness(point.X, point.Y, 0, 0);
            }

           

            //DeleteLabel
            Label DeleteLabel = new Label();
            DeleteLabel.Content = "Delete";
            DeleteLabel.PreviewMouseLeftButtonUp += async (senderr2, argss2) =>
            {


              U.CurrentQuad.Children.Remove(st);
              Rearrange(U, (Canvas)sender,obj,C);
              GC.SuppressFinalize(TempCanvas);
              U.CurrentControl = 1;


            };
            st.Children.Add(DeleteLabel);


            //Rename
            if(Convert.ToChar(TempCanvas.Tag.ToString().Substring(0,1))=='P')
            {


                Label RenameLabel = new Label();
                RenameLabel.Content = "Rename";
                RenameLabel.PreviewMouseLeftButtonUp+= async (sender3, args3) =>
                {
                    int k;// to find current index of currnet object
                    for (k = 0; k < obj.Length; k++)
                    {


                        if (TempCanvas == obj[k])
                        {
                            break;
                        }


                    }
                 

                    if (k==U.NoOfPakingSlot)                   //condition for n th slot object
                    {
                        U.CurrentQuad.Children.Remove(st);
                        TextBox renameBox = new TextBox();
                        renameBox.Height = 20;
                        renameBox.Width = 50;
                        renameBox.Margin= new Thickness(TempCanvas.Margin.Left, TempCanvas.Margin.Top + 20, 0, 0);
                        renameBox.PreviewKeyDown += async (Sender, args2) => { if (args2.Key == Key.Enter) { ((Label)TempCanvas.Children[3]).Content = renameBox.Text; U.LabelTextPrediction = renameBox.Text;  U.CurrentQuad.Children.Remove(renameBox);  }    };
                        U.CurrentQuad.Children.Add(renameBox);
                        U.Pslot[0].Background = new SolidColorBrush(Colors.Red);

                    }
                    else                                        // Condition for other slot objects
                    {

                        U.CurrentQuad.Children.Remove(st);
                        TextBox renameBox = new TextBox();
                        renameBox.Height = 20;
                        renameBox.Width = 50;
                        renameBox.Margin = new Thickness(TempCanvas.Margin.Left, TempCanvas.Margin.Top + 20, 0, 0);
                        renameBox.PreviewKeyDown += async (Sender, args2) => { if (args2.Key == Key.Enter) { ((Label)TempCanvas.Children[3]).Content = renameBox.Text; U.CurrentQuad.Children.Remove(renameBox); RenameRearrange(obj, sender, U); } };
                        U.CurrentQuad.Children.Add(renameBox);
                    }







                };
                st.Children.Add(RenameLabel);



            }


            //for restricting pslot to have copy and paste option in pslot
            if (U.CurrentControl != 1&&U.CurrentControl!=0) 
            {
               
                //CopyLabel
                Label CopyLabel = new Label();
                    CopyLabel.Content = "Copy";
                    CopyLabel.MouseDown += async (sender3, args3)=>
                    {
                        U.Workspace.Children.Remove(st);
                        U.TempObjectForCopying = sender;


                    };
                    st.Children.Add(CopyLabel);


                    Label PasteLabel = new Label();
                    PasteLabel.Content = "Paste";
                    PasteLabel.MouseDown += async (sender4, args4) =>
                    {

                        U.Workspace.Children.Remove(st);
                        PasteObject(U.TempObjectForCopying, U, C);


                    };
                    st.Children.Add(PasteLabel);
            }
            


            U.CurrentQuad.Children.Add(st);
            MenuPopUp_flag = 1;

           

           

        }




        public void PasteObject(object sender, UIElements U,CarParker_Creator C)
        {


            Point point = Mouse.GetPosition(U.Workspace);
            Canvas TempCanvas = new Canvas();
            TempCanvas = (Canvas)sender;

     


      

            if (U.CurrentControl==2)
            {
                U.CreateRoad(C,U.CurrentQuad ,Convert.ToInt32(point.X), Convert.ToInt32(point.X), Convert.ToInt32( TempCanvas.Height),Convert.ToInt32( TempCanvas.Width),0);
            }


            if (U.CurrentControl == 3)
            {
                U.CreateHroad(C,U.CurrentQuad ,Convert.ToInt32(point.X), Convert.ToInt32(point.X), Convert.ToInt32(TempCanvas.Height), Convert.ToInt32(TempCanvas.Width),0);

            }







        }
        public void Rearrange(UIElements UI, Canvas can,object[]obj,CarParker_Creator C) //Rearange occured when control is Deleted
        {


            int k;// to find current index of currnet object
            for ( k = 0; k < obj.Length; k++) 
            {


                if(can==obj[k])
                {
                    break;
                }


            }

            C.DebugBox.Text = "\nDelete Debug Info\n\n";
            C.DebugBox.Text += "UI Index=" + k.ToString()+"\n";
            string s = can.Tag.ToString();
            
            

            


            if (Convert.ToChar( s.Substring(0,1)) == 'P')        //checking control tag to know wich control is that 

            {

                C.DebugBox.Text += "UI Type = Pslot\n";

                for (int i = k; i <UI.NoOfPakingSlot-1; i++)
                {
                    ((Label)UI.Pslot[i].Children[3]).Content = ((Label)UI.Pslot[i+1].Children[3]).Content;
                    
                   
                }
                for (int i = k; i < UI.NoOfPakingSlot-1; i++)
                {
                   
                    UI.Pslot[i].Margin = UI.Pslot[i+1 ].Margin;

                }

                HolderLayo.Children.Remove((Canvas)obj[UI.NoOfPakingSlot - 1]);
                UI.NoOfPakingSlot--;
            }

            if( Convert.ToChar(s.Substring(0, 1)) == 'R')        //checking control tag to know wich control is that 
            {

                for (int i = k; i < UI.NoOfRoads- 1; i++)
                {

                    UI.Rod[i].Margin = UI.Rod[i + 1].Margin;

                }

                HolderLayo.Children.Remove((Canvas)obj[UI.NoOfRoads - 1]);
                UI.NoOfRoads--;

            }


            if (Convert.ToChar(s.Substring(0, 1)) == 'H')        //checking control tag to know wich control is that 
            {

                for (int i = k; i < UI.HNoOfRoads - 1; i++)
                {

                    UI.HRod[i].Margin = UI.HRod[i + 1].Margin;

                }

                HolderLayo.Children.Remove((Canvas)obj[UI.HNoOfRoads - 1]);
                UI.HNoOfRoads--;
            }

            if (Convert.ToChar(s.Substring(0, 1)) == 'T')        //checking control tag to know wich control is that 
            {

                for (int i = k; i < UI.NoOfToll - 1; i++)
                {

                    UI.Toll[i].Margin = UI.Toll[i + 1].Margin;

                }

                HolderLayo.Children.Remove((Canvas)obj[UI.NoOfToll - 1]);
                UI.NoOfToll--;
            }


            if (Convert.ToChar(s.Substring(0, 1)) == 'A')        //checking control tag to know wich control is that 
            {

                for (int i = k; i < UI.NoOfArrow - 1; i++)
                {

                    UI.Arrow[i].Margin = UI.Arrow[i + 1].Margin;

                }

                HolderLayo.Children.Remove((Canvas)obj[UI.NoOfArrow - 1]);
                UI.NoOfArrow--;
            }




        }



        public void RenameRearrange(object[] ob, object can,UIElements U)
        {

                Canvas[] tempCanvasArray = (Canvas[])ob;
                Canvas TempCanvas = (Canvas)can;

                Label TempCanvasLabel;
                string TempCanvasLabelText;

                string[] TextSplitter = new string[2];
                int tempint=0;



            for (int j = Convert.ToInt32(TempCanvas.Tag.ToString().Split('.')[1]); j < U.NoOfPakingSlot - 1; j++)
                {
                        TextSplitter[0] = ""; TextSplitter[1] = "";

                        TempCanvasLabel = ((Label)tempCanvasArray[j].Children[3]);
                        TempCanvasLabelText = TempCanvasLabel.Content.ToString();


                        for (int i = 0; i < TempCanvasLabelText.Length; i++)
                        {
                            if (char.IsLetter(TempCanvasLabelText[i]))
                            {
                                TextSplitter[0] += TempCanvasLabelText[i].ToString();
                            }

                            if (char.IsNumber(TempCanvasLabelText[i]))
                            {
                                TextSplitter[1] += TempCanvasLabelText[i].ToString();
                            }

                        }




                         tempint = Convert.ToInt32(TextSplitter[1]);
                        if (tempCanvasArray[j + 1].Margin.Top > tempCanvasArray[j].Margin.Top)
                        {

                            tempint = 0;
                            char[] temp;
                            temp = TextSplitter[0].ToCharArray();

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
                            TextSplitter[0] = new string(temp);


                        }

                
                    ((Label)tempCanvasArray[j + 1].Children[3]).Content = TextSplitter[0] + (++tempint).ToString();
                    



            }
             U.LabelTextPrediction= TextSplitter[0] + (++tempint).ToString();

        }


            


        







        










        
        



    }
}
