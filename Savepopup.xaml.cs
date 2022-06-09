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

namespace CarParker
{
   
    public partial class Savepopup : Page
    {
       
      
        public CarParker_Creator Car;
        public UIElements Ui;
        public Window W;

        public string InsertQueryString ;
        public string InsertPslotIndexQuery;
        public Savepopup(CarParker_Creator C ,UIElements U,Window w)
        {
            
            InitializeComponent();
            Car = C;
            Ui = U;
            W = w;
        }


        private void SaveAsbtn_Click(object sender, RoutedEventArgs e)
        {
            Car.FileName = TextBox1.Text;
            
        }

        private void Savebtn_Click(object sender, RoutedEventArgs e)
        {
            Car.FileName = TextBox1.Text;
            Save(Car.FileName);
            W.Close();
       
        }
        public void Save(string filename)
        {
            InsertQueryString = "Insert into " + filename + " values";
            InsertPslotIndexQuery = "Insert into " + filename + "XXX values";
           
        
           
            System.IO.File.Delete(@"C:\Users\Admin\Documents\Carparker\" + filename);
            






            Convert_To_QueryString(-1, 0,
                   Convert.ToInt32(Ui.Workspace.Margin.Left),
                   Convert.ToInt32(Ui.Workspace.Margin.Top),
                   Convert.ToInt32(Ui.Workspace.Height),
                   Convert.ToInt32(Ui.Workspace.Width),
                   0,
                   "",

                   "",
                   ((SolidColorBrush)Ui.Workspace.Background).Color.ToString(),
                   ((SolidColorBrush)(((Border)Ui.Workspace.Children[0]).Background)).Color.ToString());



            for (int i = 0; i < Ui.NoOfQuad; i++)
                {

                Convert_To_QueryString(0, i,
                    Convert.ToInt32(Ui.Quad[i].Margin.Left),
                    Convert.ToInt32(Ui.Quad[i].Margin.Top),
                    Convert.ToInt32(Ui.Quad[i].Height),
                    Convert.ToInt32(Ui.Quad[i].Width),
                    Convert.ToInt32(((Border)Ui.Quad[i].Children[0]).Tag),
                    ((Canvas)Ui.Quad[i].Parent).Tag.ToString(),

                    ((Label)(Ui.Quad[i].Children[3])).Content.ToString(),
                    ((SolidColorBrush)Ui.Quad[i].Background).Color.ToString(),
                    ((SolidColorBrush)(((Border)Ui.Quad[i].Children[0]).Background)).Color.ToString());
                }


                 for (int i = 0; i < Ui.NoOfPakingSlot; i++)
                 {


                Convert_PslotIndex_To_Query(i, i, 0);
                Convert_To_QueryString(1, i,
                        Convert.ToInt32(Ui.Pslot[i].Margin.Left),
                        Convert.ToInt32(Ui.Pslot[i].Margin.Top),
                        Convert.ToInt32(Ui.Pslot[i].Height),
                        Convert.ToInt32(Ui.Pslot[i].Width),
                        Convert.ToInt32(((Border)Ui.Pslot[i].Children[0]).Tag),
                        ((Canvas)Ui.Pslot[i].Parent).Tag.ToString(),

                        ((Label)(Ui.Pslot[i].Children[3])).Content.ToString(),
                        ((SolidColorBrush)Ui.Pslot[i].Background).Color.ToString(),
                       ((SolidColorBrush)(((Border)Ui.Pslot[i].Children[0]).Background)).Color.ToString()) ;
                 }

            

                for (int i = 0; i < Ui.NoOfRoads; i++)
                {



                Convert_To_QueryString(2, i,
                        Convert.ToInt32(Ui.Rod[i].Margin.Left),
                        Convert.ToInt32(Ui.Rod[i].Margin.Top),
                        Convert.ToInt32(Ui.Rod[i].Height),
                        Convert.ToInt32(Ui.Rod[i].Width),
                        Convert.ToInt32(((Border)Ui.Rod[i].Children[0]).Tag),
                        ((Canvas)Ui.Rod[i].Parent).Tag.ToString(),

                        ((Label)(Ui.Rod[i].Children[3])).Content.ToString(),
                        ((SolidColorBrush)Ui.Rod[i].Background).Color.ToString(),
                        ((SolidColorBrush)(((Border)Ui.Rod[i].Children[0]).Background)).Color.ToString());
                 }
                 for (int i = 0; i < Ui.HNoOfRoads; i++)
                 {


                     

                        Convert_To_QueryString(3, i,
                         Convert.ToInt32(Ui.HRod[i].Margin.Left),
                         Convert.ToInt32(Ui.HRod[i].Margin.Top),
                         Convert.ToInt32(Ui.HRod[i].Height),
                         Convert.ToInt32(Ui.HRod[i].Width),
                         Convert.ToInt32(((Border)Ui.HRod[i].Children[0]).Tag),
                         ((Canvas)Ui.HRod[i].Parent).Tag.ToString(),

                         ((Label)(Ui.HRod[i].Children[3])).Content.ToString(),
                         ((SolidColorBrush)Ui.HRod[i].Background).Color.ToString(),
                        ((SolidColorBrush)(((Border)Ui.HRod[i].Children[0]).Background)).Color.ToString());
                 }

                for (int i = 0; i < Ui.NoOfToll; i++)
                {




                        Convert_To_QueryString(4, i,
                        Convert.ToInt32(Ui.Toll[i].Margin.Left),
                        Convert.ToInt32(Ui.Toll[i].Margin.Top),
                        Convert.ToInt32(Ui.Toll[i].Height),
                        Convert.ToInt32(Ui.Toll[i].Width),
                        Convert.ToInt32(((Border)Ui.Toll[i].Children[0]).Tag),
                        ((Canvas)Ui.Toll[i].Parent).Tag.ToString(),

                        ((Label)(Ui.Toll[i].Children[3])).Content.ToString(),
                        ((SolidColorBrush)Ui.Toll[i].Background).Color.ToString(),
                        ((SolidColorBrush)(((Border)Ui.Toll[i].Children[0]).Background)).Color.ToString());
                }

               for (int i = 0; i < Ui.NoOfArrow; i++)
               {




                Convert_To_QueryString(5, i,
                Convert.ToInt32(Ui.Arrow[i].Margin.Left),
                Convert.ToInt32(Ui.Arrow[i].Margin.Top),
                Convert.ToInt32(Ui.Arrow[i].Height),
                Convert.ToInt32(Ui.Arrow[i].Width),
                Convert.ToInt32(((Border)Ui.Arrow[i].Children[0]).Tag),
                ((Canvas)Ui.Arrow[i].Parent).Tag.ToString(),

                ((Label)(Ui.Arrow[i].Children[3])).Content.ToString(),
                ((SolidColorBrush)Ui.Arrow[i].Background).Color.ToString(),
                ((SolidColorBrush)(((Border)Ui.Arrow[i].Children[0]).Background)).Color.ToString());
               }


            for (int i = 0; i < Ui.NoOfConnector; i++)
            {




                Convert_To_QueryString(6, i,
                Convert.ToInt32(Ui.Connector[i].Margin.Left),
                Convert.ToInt32(Ui.Connector[i].Margin.Top),
                Convert.ToInt32(Ui.Connector[i].Height),
                Convert.ToInt32(Ui.Connector[i].Width),
                Convert.ToInt32(((Border)Ui.Connector[i].Children[0]).Tag),
                ((Canvas)Ui.Connector[i].Parent).Tag.ToString(),

                ((Label)(Ui.Connector[i].Children[3])).Content.ToString(),
                ((SolidColorBrush)Ui.Connector[i].Background).Color.ToString(),
                ((SolidColorBrush)(((Border)Ui.Connector[i].Children[0]).Background)).Color.ToString());
            }

            if (!System.IO.Directory.Exists("C:\\Users\\Admin\\Documents\\Carparker\\" + filename + ".txt"))
            {
                File.WriteAllText("C:\\Users\\Admin\\Documents\\Carparker\\" + filename + ".txt", filename + "*" + filename + "XXX");

                ControlsDatabse DA = new ControlsDatabse();
                DA.CreateTable(filename);
                DA.Insert(InsertQueryString.Substring(0, InsertQueryString.Length - 1));

                ParkingDatabase PD = new ParkingDatabase();
                PD.CreateTable(filename + "XXX");
                PD.Insert(InsertPslotIndexQuery.Substring(0, InsertPslotIndexQuery.Length - 1));

            }


        }

       
        public void Convert_To_QueryString(int id, int index, int X, int Y, int h, int w, int Rotation, string Parent, string label, string bgcolor, string brcolour)
        {
           

            InsertQueryString += "(" + id.ToString() + ", " + index.ToString() + ", " + X.ToString() + ", " + Y.ToString() + ", " + h.ToString() + ", " + w.ToString() + ", " + Rotation.ToString() + ", '" + Parent + "', '" + label + "', '" + bgcolor + "', '" + brcolour + "'),";

        }
        public void  Convert_PslotIndex_To_Query(int id, int slot, int state)
        {

            InsertPslotIndexQuery += "(" + id + "," + slot + "," + state + "),";

        }

    }
}
