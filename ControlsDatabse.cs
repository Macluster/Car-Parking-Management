using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using MySql.Data.MySqlClient;

namespace CarParker
{
    class ControlsDatabse
    {
        public int Id, x, y, h, w;
        string filename;
        
        public void CreateDatabse(string file)
        {

            MySqlConnection Con = new MySqlConnection("server=localhost;user id=root;password=Macluster@123");
            Con.Open();
            MySqlCommand cmd = new MySqlCommand("create Database " + file, Con);
            cmd.ExecuteNonQuery();
            Con.Close();
            filename = file;
          
       
        }

        public void CreateTable(string file)
        {

            filename = file;
            MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=carparking;password=Macluster@123");
 
            con.Open();
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "Create Table "+filename+"(ID int,Ind int,x int,y int,h int,w int,Rotation int,Parent varchar(20),Label varchar(20),Bgcolor varchar(20),BrColour varchar(20) )";
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void Insert(string Query)
        {
            MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=carparking;password=Macluster@123");

            con.Open();
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandText = Query;
            cmd.ExecuteNonQuery();
            con.Close();


        }
        
        public int GetLength(string mapname)
        {

            int length=0;
            MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=carparking;password=Macluster@123");

            con.Open();
            string Query = ("select Id from "+mapname);
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandText = Query;
            MySqlDataReader dr = cmd.ExecuteReader();

            while(dr.Read())
            {
                length++;
            }

            
            con.Close();
            return length;

        }

        public int GetNoOfSlotsFilled(string mapname)
        {
            int SlotsFilled = 0;
            MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=carparking;password=Macluster@123");

            con.Open();
            string Query = ("select Id from "+mapname+" where state=1");
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandText = Query;
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                SlotsFilled++;
            }


            con.Close();
            return SlotsFilled;

        }
        
        
        
        public ControlsDatabse Getdata(UIElements Ui,CarParker_Creator C,string filename)
        {

           
            MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=carparking;password=Macluster@123");
           
            con.Open();
            
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "select * from "+filename+" where Id=-1";
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {

                Ui.Createworkspace(C, reader.GetInt32(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(5));


            }
            reader.Close();
           
            cmd = con.CreateCommand();
            cmd.CommandText = "select * from "+filename+" where Id=0";
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {

                Ui.CreateQuad(C, reader.GetInt32(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(5),reader.GetInt32(6));


            }
            reader.Close();
            string[] spliter;
            cmd = con.CreateCommand();
            cmd.CommandText = "select * from "+filename+" where Id=1";
            reader = cmd.ExecuteReader();
            while ( reader.Read())
            {
                 spliter = reader.GetString(7).Split('.');
               
                
                Ui.CreatePslot(C,Ui.Quad[Convert.ToInt32(spliter[1])],reader.GetInt32(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(5), reader.GetString(8), reader.GetInt32(6));
               

            }
            reader.Close();
            cmd = con.CreateCommand();
            cmd.CommandText = "select * from "+filename+" where Id=2";
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                spliter = reader.GetString(7).Split('.');
                Ui.CreateRoad(C, Ui.Quad[Convert.ToInt32(spliter[1])], reader.GetInt32(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(5), reader.GetInt32(6));

            }
            reader.Close();
            cmd = con.CreateCommand();
            cmd.CommandText = "select * from "+filename+" where Id=3";
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                spliter = reader.GetString(7).Split('.');
                Ui.CreateHroad(C, Ui.Quad[Convert.ToInt32(spliter[1])], reader.GetInt32(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(5), reader.GetInt32(6));

            }
            reader.Close();
          
            cmd = con.CreateCommand();
            cmd.CommandText = "select * from " + filename + " where Id=4";
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                spliter = reader.GetString(7).Split('.');
                Ui.CreateToll(C, Ui.Quad[Convert.ToInt32(spliter[1])], reader.GetInt32(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(5), reader.GetInt32(6));

            }
            reader.Close();
            
     


            cmd = con.CreateCommand();
            cmd.CommandText = "select * from " + filename + " where Id=5";
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                spliter = reader.GetString(7).Split('.');
                Ui.CreateArrow(C, Ui.Quad[Convert.ToInt32(spliter[1])], reader.GetInt32(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(5), reader.GetInt32(6));

            }
            reader.Close();


            cmd = con.CreateCommand();
            cmd.CommandText = "select * from " + filename + " where Id=6";
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                spliter = reader.GetString(7).Split('.');
                Ui.CreateConnector(C, Ui.Quad[Convert.ToInt32(spliter[1])], reader.GetInt32(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(5), reader.GetInt32(6));

            }
            reader.Close();


            con.Close();
            return this;

        }




    }
}
