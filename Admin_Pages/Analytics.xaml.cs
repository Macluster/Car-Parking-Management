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
using LiveCharts;
namespace CarParker.Admin_Pages
{
    /// <summary>
    /// Interaction logic for Analytics.xaml
    /// </summary>
    public partial class Analytics : Page
    {
        public Analytics()
        {
            InitializeComponent();
            Load();
            LoadPieGraph();
        }



        public void Load()
        {
            CustomerDatabase CD = new CustomerDatabase();
            string []Dates = CD.GetFirstAndLastDAtes();


            // int[] NoOfDatesInMonths = { 31, 28, 31, 30, 31, 30, 31, 30, 31, 30, 31, 30 };

            int length=0;
            string []DatesData = CD.GetAllDates( ref length);
            double[] TotalFeeForEachMonth = new double[12];
            double TotalFee = 0;

            for(int i=0;i<length;i++)
            {

                if (DatesData[i].Split(' ')[1] == "January")
                {

                    int Fee = CD.GetTotalProfitInDate(DatesData[i]);
                    TotalFeeForEachMonth[0] += Fee;
                    TotalFee += Fee;
                }
                else  if (DatesData[i].Split(' ')[1] == "February")
                {

                    int Fee = CD.GetTotalProfitInDate(DatesData[i]);
                    TotalFeeForEachMonth[1] += Fee;
                    TotalFee += Fee;
                }
                else  if (DatesData[i].Split(' ')[1] == "March")
                {

                    int Fee = CD.GetTotalProfitInDate(DatesData[i]);
                    TotalFeeForEachMonth[2] += Fee;
                    TotalFee += Fee;
                }
                else    if (DatesData[i].Split(' ')[1] == "April")
                {

                    int Fee = CD.GetTotalProfitInDate(DatesData[i]);
                    TotalFeeForEachMonth[3] += Fee;
                    TotalFee += Fee;
                }
                else  if (DatesData[i].Split(' ')[1] == "May")
                {

                    int Fee = CD.GetTotalProfitInDate(DatesData[i]);
                    TotalFeeForEachMonth[4] += Fee;
                    TotalFee += Fee;
                }
                else if (DatesData[i].Split(' ')[1] == "June")
                {

                    int Fee = CD.GetTotalProfitInDate(DatesData[i]);
                    TotalFeeForEachMonth[5] += Fee;
                    TotalFee += Fee;
                }
                else if (DatesData[i].Split(' ')[1] == "July")
                {

                    int Fee = CD.GetTotalProfitInDate(DatesData[i]);
                    TotalFeeForEachMonth[6] += Fee;
                    TotalFee += Fee;
                }
                else if (DatesData[i].Split(' ')[1] == "August")
                {

                    int Fee = CD.GetTotalProfitInDate(DatesData[i]);
                    TotalFeeForEachMonth[7] += Fee;
                    TotalFee += Fee;
                }
                else   if (DatesData[i].Split(' ')[1] == "September")
                {

                    int Fee = CD.GetTotalProfitInDate(DatesData[i]);
                    TotalFeeForEachMonth[8] += Fee;
                    TotalFee += Fee;
                }
                else  if (DatesData[i].Split(' ')[1] == "October")
                {

                    int Fee = CD.GetTotalProfitInDate(DatesData[i]);
                    TotalFeeForEachMonth[9] += Fee;
                    TotalFee += Fee;
                }
                else   if (DatesData[i].Split(' ')[1] == "November")
                {

                    int Fee = CD.GetTotalProfitInDate(DatesData[i]);
                    TotalFeeForEachMonth[10] += Fee;
                    TotalFee += Fee;
                }
                else   if (DatesData[i].Split(' ')[1] == "December")
                {
                    int Fee = CD.GetTotalProfitInDate(DatesData[i]);
                    TotalFeeForEachMonth[11] += Fee;
                    TotalFee += Fee;
                }




            


            }



            // DebugBox.Text += "June Fee= " + TotalFeeForEachMonth[5].ToString()+"\n";
            DebugBox.Text += "Total Fee= " + TotalFee.ToString() + "\n";
            DebugBox.Text += "January Fee= " + TotalFeeForEachMonth[0].ToString() + "\n";
            
            double per = (TotalFeeForEachMonth[0] / TotalFee) * 100; DebugBox.Text += "Percentage of Fee for jan= " + per.ToString() + "\n";
            double amt = (per / 100) * 250; DebugBox.Text += "Height of jan= " + amt.ToString() + "\n";
            Jan.Margin = new Thickness(Jun.Margin.Left, 250 - amt, 0, 0);


            per = (TotalFeeForEachMonth[1] / TotalFee) * 100;
            amt = (per / 100) * 250;
            Feb.Margin = new Thickness(Jun.Margin.Left, 250 - amt, 0, 0);

            per = (TotalFeeForEachMonth[2] / TotalFee) * 100;
            amt = (per / 100) * 250;
            Mar.Margin = new Thickness(Jun.Margin.Left, 250 - amt, 0, 0);

            per = (TotalFeeForEachMonth[3] / TotalFee) * 100;
            amt = (per / 100) * 250;
            Apr.Margin = new Thickness(Jun.Margin.Left, 250 - amt, 0, 0);

            per = (TotalFeeForEachMonth[4] / TotalFee) * 100;
            amt = (per / 100) * 250;
            May.Margin = new Thickness(Jun.Margin.Left, 250 - amt, 0, 0);

            per = (TotalFeeForEachMonth[5] / TotalFee) * 100;
            amt = (per / 100) * 250;
            Jun.Margin = new Thickness(Jun.Margin.Left, 250 - amt, 0, 0);

            per = (TotalFeeForEachMonth[6] / TotalFee) * 100;
            amt = (per / 100) * 250;
            Jul.Margin = new Thickness(Jun.Margin.Left, 250 - amt, 0, 0);

            per = (TotalFeeForEachMonth[7] / TotalFee) * 100;
            amt = (per / 100) * 250;
            Aug.Margin = new Thickness(Jun.Margin.Left, 250 - amt, 0, 0);

            per = (TotalFeeForEachMonth[8] / TotalFee) * 100;
            amt = (per / 100) * 250;
            Sep.Margin = new Thickness(Jun.Margin.Left, 250 - amt, 0, 0);


            per = (TotalFeeForEachMonth[9] / TotalFee) * 100;
            amt = (per / 100) * 250;
            Oct.Margin = new Thickness(Jun.Margin.Left, 250 - amt, 0, 0);

            per = (TotalFeeForEachMonth[10] / TotalFee) * 100;
            amt = (per / 100) * 250;
            Nov.Margin = new Thickness(Jun.Margin.Left, 250 - amt, 0, 0);

            per = (TotalFeeForEachMonth[11] / TotalFee) * 100;
            amt = (per / 100) * 250;
            Dec.Margin = new Thickness(Jun.Margin.Left, 250 - amt, 0, 0);











        }


        public void  LoadPieGraph()
        {
            

            string path = "C:\\Users\\Admin\\Documents\\Carparker\\Settings.txt";


           string  CurrentMapName = System.IO.File.ReadAllText(path).Split('.')[1];


            ControlsDatabse CD = new ControlsDatabse();
            float TotalNoOfSlots = (float)CD.GetLength(CurrentMapName+"xxx");
            float FilledSlots =(float) CD.GetNoOfSlotsFilled(CurrentMapName+"xxx");
            float FreeSlots =(float) TotalNoOfSlots - FilledSlots;


            FilledPerentage.Values = new ChartValues<double> { ((FilledSlots / TotalNoOfSlots) * 100) };
            FreePercentage.Values= new ChartValues<double> { ((FreeSlots / TotalNoOfSlots) * 100) };

            Testlabel.Content = ((FreeSlots / TotalNoOfSlots) * 100);



        }








    }
}
