using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Day021_03_센서차트_그리기
{
    public partial class Form1 : Form
    {
        String strConn = "Server=127.0.0.1;Uid=root;Pwd=1234;Database=sqlDB;CHARSET=UTF8";
        MySqlConnection conn;
        MySqlCommand cmd;
        MySqlDataReader reader;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            conn = new MySqlConnection(strConn);
            conn.Open();
            cmd = new MySqlCommand("", conn);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Close();
        }

        int[] tempAry = new int[30];
        int[] humiAry = new int[30];
        string sql = "SELECT s_date, temper, humi FROM sensorTBL ORDER BY s_date DESC LIMIT 1";
        int temper, humi;

        private void timer1_Tick(object sender, EventArgs e)
        {
            cmd.CommandText = sql;
            reader = cmd.ExecuteReader();
            reader.Read();

            temper = (int)reader["temper"];
            humi = (int)reader["humi"];
            reader.Close();

            for (int i = 0; i < tempAry.Length - 1; i++)
            {
                tempAry[i] = tempAry[i + 1];
                humiAry[i] = humiAry[i + 1];
            }
            tempAry[tempAry.Length - 1] = temper;
            humiAry[humiAry.Length - 1] = humi;
            
            chart1.Series[0].ChartType
                = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series[1].ChartType
                = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            for (int i = 0; i < tempAry.Length; i++)
            {
                chart1.Series[0].Points.AddXY(i, tempAry[i]);
                chart1.Series[1].Points.AddXY(i, humiAry[i]);
            }
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void btn_stop_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

    }
}
