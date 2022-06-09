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

namespace CarParker.Admin_Pages
{
    /// <summary>
    /// Interaction logic for ReportPage.xaml
    /// </summary>
    public partial class ReportPage : Page
    {
        public ReportPage()
        {
            InitializeComponent();

            fun();
        }

        public void fun()
        {

            
            CustomerDatabase CD = new CustomerDatabase();
        
            string [,]Data= CD.GetData();

            
            int j = 0;



           
            
            for(int i=0;i<CD.GetLength();i++)
            {
                RowDefinition da = new RowDefinition();
                da.Height = new GridLength(40);
                ContentGrid.RowDefinitions.Add(da);

                for (int k = 0; k < 6; k++)
                {
                    Label La = new Label();
                    La.Background = new SolidColorBrush(Colors.Gray);
                    La.Margin = new Thickness(5,1,5,1);
                    La.HorizontalContentAlignment = HorizontalAlignment.Center;
                    La.VerticalContentAlignment = VerticalAlignment.Center;
                    La.Foreground = new  SolidColorBrush(Colors.White);
                  
                    La.Content = Data[i, k];
                    ContentGrid.Children.Add(La);
                    Grid.SetRow(La, i);
                    Grid.SetColumn(La, k);
                }


            }

            




        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {

            if(DateRangelabel.Content.ToString()== "Day Wise")
            {
                ShowDayWise();
            }
            else if(DateRangelabel.Content.ToString()== "Monthly")
            {
                ShowMonthWise();
            }

        }


        public void ShowDayWise()
        {

            CustomerDatabase CD = new CustomerDatabase();
            string[,] Data = CD.GetData(DateLabel.Content.ToString());
            ContentGrid.Children.Clear();
            ContentGrid.RowDefinitions.Clear();


            TestName.Content = DateLabel.Content.ToString();

            int j = 0;
            for (int i = 0; i < CD.GetLength(DateLabel.Content.ToString()); i++)
            {
                RowDefinition da = new RowDefinition();
                da.Height = new GridLength(40);
                ContentGrid.RowDefinitions.Add(da);

                for (int k = 0; k < 6; k++)
                {
                    Label La = new Label();
                    La.Background = new SolidColorBrush(Colors.Gray);
                    La.Margin = new Thickness(5, 1, 5, 1);
                    La.HorizontalContentAlignment = HorizontalAlignment.Center;
                    La.VerticalContentAlignment = VerticalAlignment.Center;
                    La.Foreground = new SolidColorBrush(Colors.White);

                    La.Content = Data[i, k];
                    ContentGrid.Children.Add(La);
                    Grid.SetRow(La, i);
                    Grid.SetColumn(La, k);
                }


            }



        }

        public void ShowMonthWise()
        {
            CustomerDatabase CD = new CustomerDatabase();

            string NeededMonth = DateLabel.Content.ToString().Split(' ')[1];
            string[,] Data = CD.GetData();
            ContentGrid.Children.Clear();
            ContentGrid.RowDefinitions.Clear();


            for(int i=0;i<CD.GetLength();i++)
            {
                Data[i, 3] = Data[i, 3].Split(' ')[1];

            }


            int j = 0;
            for (int i = 0; i < CD.GetLength(); i++)
            {
                if (Data[i, 3] == NeededMonth)
                {
                    
                    RowDefinition da = new RowDefinition();
                    da.Height = new GridLength(40);
                    ContentGrid.RowDefinitions.Add(da);

                    for (int k = 0; k < 6; k++)
                    {
                        Label La = new Label();
                        La.Background = new SolidColorBrush(Colors.Gray);
                        La.Margin = new Thickness(5, 1, 5, 1);
                        La.HorizontalContentAlignment = HorizontalAlignment.Center;
                        La.VerticalContentAlignment = VerticalAlignment.Center;
                        La.Foreground = new SolidColorBrush(Colors.White);

                        La.Content = Data[i, k];
                        ContentGrid.Children.Add(La);
                        Grid.SetRow(La, j);
                        Grid.SetColumn(La, k);
                    }


                    j++;
                }

            }





        }



        private void Calender_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {

            string date= Calender.SelectedDate.ToString().Split(' ')[0];

            string[] SplitedDates = date.Split('-');

            switch(SplitedDates[1])
            {
                

                case "01":
                    SplitedDates[1] = "January";
                    break;
                case "02":
                    SplitedDates[1] = "February";
                    break;

                case "03":
                    SplitedDates[1] = "March";
                    break;
                case "04":
                    SplitedDates[1] = "April";
                    break;
                case "05":
                    SplitedDates[1] = "May";
                    break;
                case "06":
                    SplitedDates[1] = "June";
                    break;
                case "07":
                    SplitedDates[1] = "July";
                    break;
                case "08":
                    SplitedDates[1] = "August";
                    break;
                case "09":
                    SplitedDates[1] = "September";
                    break;
                case "10":
                    SplitedDates[1] = "October";
                    break;
                case "11":
                    SplitedDates[1] = "November";
                    break;
                case "12":
                    SplitedDates[1] = "December";
                    break;


            }



            DateLabel.Content = SplitedDates[0] + " " + SplitedDates[1] + " " + SplitedDates[2];



        }

       
        int i = 0;
        private void DateRangeLeftBtn_Click(object sender, RoutedEventArgs e)
        {
           
            if(i==2)
            {
                i = 1;
                DateRangelabel.Content = "Day Wise";

            }
            else if(i==1)
            {
                i = 0;
                CalenderGrid.Visibility = Visibility.Hidden;
                DateRangelabel.Content = "All Records";
                fun();
                System.Threading.Thread AllRecordstableThread = new System.Threading.Thread(() =>
                {
                    Dispatcher.Invoke(() => { CalenderGrid.Visibility = Visibility.Hidden; });
                    ToAllRecordsAnimation();
                  

                });
                AllRecordstableThread.Start();


            }


        }

        private void DateRangeRightBtn_Click(object sender, RoutedEventArgs e)
        {
            if (i == 0)
            {
                i = 1;
                DateRangelabel.Content = "Day Wise";
              

                System.Threading.Thread DayWisetableThread = new System.Threading.Thread(() =>
                  {
                      ToDayWiseAnimation();
                      Dispatcher.Invoke(() => { CalenderGrid.Visibility = Visibility.Visible; });
                     
                  });
                DayWisetableThread.Start();


            }
           else if(i==1)
            {
                i = 2;
                DateRangelabel.Content = "Monthly";
                
            }

        }

        private void Calender_DisplayDateChanged(object sender, CalendarDateChangedEventArgs e)
        {
            string date= Calender.DisplayDate.ToString();

            string[] SplitedDates = date.Split('-');

            switch (SplitedDates[1])
            {


                case "01":
                    SplitedDates[1] = "January";
                    break;
                case "02":
                    SplitedDates[1] = "February";
                    break;

                case "03":
                    SplitedDates[1] = "March";
                    break;
                case "04":
                    SplitedDates[1] = "April";
                    break;
                case "05":
                    SplitedDates[1] = "May";
                    break;
                case "06":
                    SplitedDates[1] = "June";
                    break;
                case "07":
                    SplitedDates[1] = "July";
                    break;
                case "08":
                    SplitedDates[1] = "August";
                    break;
                case "09":
                    SplitedDates[1] = "September";
                    break;
                case "10":
                    SplitedDates[1] = "October";
                    break;
                case "11":
                    SplitedDates[1] = "November";
                    break;
                case "12":
                    SplitedDates[1] = "December";
                    break;


            }



            DateLabel.Content = SplitedDates[0] + " " + SplitedDates[1] + " " + SplitedDates[2].Split(' ')[0];
        }




        public void ToDayWiseAnimation()
        {
            
            
            
            for(int i=-40;i<191;i++)
            {
                System.Threading.Thread.Sleep(5);
                Dispatcher.Invoke(() =>
                {
                    GridTable.Margin = new Thickness(i, 50, 0, 0);
                });
              

            }


        }


        public void ToAllRecordsAnimation()
        {



            for (int i = 191; i > -41; i--)
            {
                System.Threading.Thread.Sleep(5);
                Dispatcher.Invoke(() =>
                {
                    GridTable.Margin = new Thickness(i, 50, 0, 0);
                });


            }


        }




    }
}
