using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace CarParker
{
    class CustomerDatabase
    {
        public MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=carparking;password=Macluster@123");



        public void Insert(string number, string Sdate, string Edate, string Date, string Mapname, string Slot)
        {
            con.Open();
            MySqlCommand cmd = new MySqlCommand("insert into customers(Number,Ptime,Etime,Date,Map,Slot,Fee)values('" + number + "','" + Sdate + "','" + Edate + "','" + Date + "','" + Mapname + "','" + Slot + "',0)", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public string GetParkingTime(string slot)
        {
            string parkingtime = "";
            con.Open();
            MySqlCommand cmd = new MySqlCommand("select Ptime from customers where Slot='" + slot + "'", con);

            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                parkingtime = dr.GetString(0);
            }
            con.Close();
            return parkingtime;


        }

        public string GetCustomerNumber(string slot)
        {
            string number = "";
            con.Open();
            MySqlCommand cmd = new MySqlCommand("select Number from customers where Slot='" + slot + "'",con);

            MySqlDataReader dr = cmd.ExecuteReader();

            int i = 0;
            while (dr.Read())
            {
                number = dr.GetString(0);
                i++;
            }
            con.Close();
            return number;


        }



        

        public void UpdateFee(string fee,string slot)
        {

            int ID;

            con.Open();

            MySqlCommand cmd = new MySqlCommand("select MAX(ID) from customers where Slot='" + slot + "'", con);
            ID = Convert.ToInt32(cmd.ExecuteScalar());

            cmd = new MySqlCommand("Update customers set Fee='" + fee + "' where ID ='" + ID + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();

        }


        public void UpdateEtime(string Etime, string slot)
        {
            int ID;

            con.Open();

            MySqlCommand cmd = new MySqlCommand("select MAX(ID) from customers where Slot='" + slot + "'", con);
            ID = Convert.ToInt32(cmd.ExecuteScalar());

            cmd = new MySqlCommand("Update customers set Etime='" + Etime + "' where ID ='" + ID + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();



        }



        public string[,] GetData(string Date = "0000")
        {

            string[,] Data = new string[100, 6];
            int i = 0;
            con.Open();
            MySqlCommand cmd;
            if (Date == "0000")
            { 
                cmd = new MySqlCommand("Select * from Customers", con);
            }
            else
            {
                cmd = new MySqlCommand("Select * from Customers where Date='" + Date + "'", con);
            }

            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Data[i, 0] = dr.GetString(1);
                Data[i, 1] = dr.GetString(2);
                Data[i, 2] = dr.GetString(3);
                Data[i, 3] = dr.GetString(4);
                Data[i, 4] = dr.GetString(5);
                Data[i, 5] = dr.GetString(6);


                i++;
            }

            con.Close();


            return Data;

        }





        public int GetLength(string Date = "0000")
        {
            int length;
            con.Open();
            MySqlCommand cmd;
            if (Date == "0000")
            {
                cmd = new MySqlCommand("select Count(*) from Customers", con);
            }
            else
                cmd = new MySqlCommand("select Count(*) from Customers where Date ='" + Date + "'", con);
            length = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();


            return length;


        }




        public string[] GetFirstRecord()
        {
            string[] Data = new string[6];

            con.Open();
            MySqlCommand cmd = new MySqlCommand("Select * from Customers where ID=1");
            MySqlDataReader dr = cmd.ExecuteReader();

            dr.Read();

            Data[0] = dr.GetString(1);
            Data[1] = dr.GetString(2);
            Data[2] = dr.GetString(3);
            Data[3] = dr.GetString(4);
            Data[4] = dr.GetString(5);
            Data[5] = dr.GetString(6);

            con.Close();


            return Data;
        }

        public int GetTotalProfitInDate(string date)
        {
            int TotalFee=0;
            int temp;
            con.Open();
            MySqlCommand cmd = new MySqlCommand("Select Fee from customers where Date='" + date + "'",con);
            MySqlDataReader dr = cmd.ExecuteReader();
            string temp2="";
            while(dr.Read())
            {

                temp2 = dr.GetString(0);
                if (temp2 != null)
                {
                    temp = Convert.ToInt32(dr.GetString(0));
                    TotalFee += temp;
                }

            }
            con.Close();
            return TotalFee;

        }



        public string[] GetFirstAndLastDAtes()
        {
            string[] Dates = new string[2];
            int Maxid ,Minid;
            con.Open();
            MySqlCommand cmd = new MySqlCommand("Select Max(ID) from customers",con);
            Maxid = Convert.ToInt32(cmd.ExecuteScalar()); 

            cmd = new MySqlCommand("Select Min(ID) from customers", con);
            Minid = Convert.ToInt32(cmd.ExecuteScalar());


            cmd = new MySqlCommand("Select Date from customers where ID="+Maxid+"", con);
            Dates[0] = cmd.ExecuteScalar().ToString();
            
            cmd = new MySqlCommand("Select Date from customers where ID=" + Minid+ "", con);
            Dates[1] = cmd.ExecuteScalar().ToString();
            con.Close();



            return Dates;

        }


        public string[] GetAllDates(ref int length)
        {
            string []dates=new string[1000];
            con.Open();
            MySqlCommand cmd = new MySqlCommand("Select Date from customers", con);
            MySqlDataReader dr = cmd.ExecuteReader();

            int i = 0;
            while(dr.Read())
            {
                dates[i] = dr.GetString(0);

                i++;
            }

            length = i - 1;
            con.Close();
            return dates;

        }







    }
}
