using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Controls;
using System.Windows.Media;
namespace CarParker
{
   public  class ParkingDatabase
    {

        MySqlConnection con;
        MySqlDataReader dr;


        public   ParkingDatabase()
        {

            
            con = new MySqlConnection("server=localhost;user id=root;database=carparking;password=Macluster@123");
            con.Open();

        }

        ~ParkingDatabase()
        {

            con.Close();
        }


        public void CreateTable(string filename)
        {
          //  con.Open();
            MySqlCommand cmd = new MySqlCommand("create table " + filename + " (Id int,slot int,state int)",con);
            cmd.ExecuteNonQuery();
         //   con.Close();


        }
        
        
        public void Insert(string Query)
        {
           // con.Open();
           

            MySqlCommand cmd = new MySqlCommand(Query, con);
          
            cmd.ExecuteNonQuery();
           // con.Close();

        }

        public void Update(int id,int value,string TableName)
        {

            if (value == 1)
                value = 0;
            else
                value = 1;

        //    con.Open();
            string query = "update "+TableName+" set state="+value+" where Id=" + id + "";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.ExecuteNonQuery();
        //    con.Close();


        }
        
        public int isSlotFree(int id,string TabelName)
        {
          //  con.Open();
            int value=0;
            string query = "select state from "+TabelName+" where id=" + id + "";
            MySqlCommand cmd = new MySqlCommand(query, con);
             dr = cmd.ExecuteReader();
            while(dr.Read())
            {
               
                value = dr.GetInt32(0);
            }
            // con.Close();
            dr.Close();
            return value;
           
          

        }

        public  void isSlotFreeColorChanger(Canvas slot,int value)
        {

            if(value==1)
            {
                ((Border)slot.Children[0]).Background= new SolidColorBrush((Color)ColorConverter.ConvertFromString("#435560"));
            }
            else
            {
                ((Border)slot.Children[0]).Background = new SolidColorBrush(Colors.Red);
            }

        }

         








    }
}
