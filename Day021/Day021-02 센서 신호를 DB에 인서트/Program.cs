using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Day021_02_센서_신호를_DB에_인서트
{
    class Program
    {
        static void Main(string[] args)
        {
            String strConn = "Server=127.0.0.1;Uid=root;Pwd=1234;Database=sqlDB;CHARSET=UTF8";

            MySqlConnection conn = new MySqlConnection(strConn);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("", conn);

            String sql;
            sql = "CREATE TABLE IF NOT EXISTS sensorTBL (s_date DATETIME, temper INT, humi INT)";
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();

            Random r = new Random();
            while (true)
            {
                string s_date = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
                string temper = (r.Next(-100, 100)).ToString();
                string humi = (r.Next(0, 300)).ToString();

                sql = "INSERT INTO sensorTBL (s_date, temper, humi) VALUES('";
                sql += s_date + "', " + temper + "," + humi + ")";
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();

                Console.WriteLine(s_date + ", " + temper + ", " + humi);
                System.Threading.Thread.Sleep(500);
            }
        }
    }
}
