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
using System.Data.SQLite;
using MySql.Data.MySqlClient;
using System.IO;
namespace CarParker
{
    class GridAPI
    {
        public Grid Grid1;
        public int Height;
        public int Width;
        public int GridHeight=165;
        public int Gridwidth;
       
        public GridAPI(int x,int y,int h,int w)
        {
            Grid1 = new Grid();
            
            Grid1.Background = new SolidColorBrush(Colors.CadetBlue);
            Grid1.Height =h;
            Grid1.Width = w;
            Grid1.Margin = new Thickness(x, y, 0, 0);
     
        }
        public void AddRowColumn(int r,int c,int h,int w)
        {
            RowDefinition R;
            for (int i = 0; i < r; i++)  
            {
                R = new RowDefinition();
                R.Height = new GridLength(GridHeight);
              
                
                
                Grid1.Height += Convert.ToInt32(GridHeight);
                Grid1.RowDefinitions.Add(R);


            }
            ColumnDefinition C;

            for (int i = 0; i < c; i++)
            {
                C = new ColumnDefinition();
                C.Width= new GridLength(Grid1.Width/c);
                Grid1.ColumnDefinitions.Add(C);


            }



        }
        public void AddRow(int n)
        {
              RowDefinition R;
            for (int i = 0; i < n; i++)  
            {
                R = new RowDefinition();
                R.Height = new GridLength(GridHeight);
                Grid1.RowDefinitions.Add(R);
                Grid1.Height += GridHeight;


            }
          

        }

        public void AddControl(object control,int r,int c)
        {

            Grid1.Children.Add((Button)control);
            Grid.SetRow((Button)control, r);
            Grid.SetColumn((Button)control, c);

        }




    }
}
