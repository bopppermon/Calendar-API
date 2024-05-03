using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseCalendar
{
    public partial class Form1 : Form
    {
        DateTime now;
        int month, year;
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        } 
        private void label8_Click(object sender, EventArgs e)
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //Used this code from the tutorial
            displayDays();            
        }


        //THis method is from following a tutorial
        //https://www.youtube.com/watch?v=tY8_GE6NRYA
        private void displayDays()
        {

            // DateTime now = DateTime.Now;
            now = DateTime.Now;
            month = now.Month;
            year = now.Year;



            /* //Get the first day of the mnth
             String monthname = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
             LBDATE.Text = monthname + " " + year;

             //Get the first day of the month (from tutorial)

             DateTime startofthemonth = new DateTime(year, month,1);

             //Get the count of days of the month
             int days = DateTime.DaysInMonth(year, month);

             //convert the startofthemonth to integer
             int dayoftheweek = Convert.ToInt32(startofthemonth.DayOfWeek.ToString("d")) + 1;



             //first create a blank usercontrol 

             for(int i = 1; i<dayoftheweek;i++)
             {
                 UserControlBlank ucblank = new UserControlBlank();
                 daycontainer.Controls.Add(ucblank);
             }

             //Create usercontrol for days
             for(int i = 1; i <= days; i++)
             {
                 UserControlDays ucdays = new UserControlDays();
                 ucdays.days(i);
                 daycontainer.Controls.Add(ucdays);
             } */

            showDisplay();
        
        }


        //Function made to display the days of the month
        private void showDisplay()
        {
            //Get the first day of the mnth
            String monthname = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            LBDATE.Text = monthname + " " + year;

            //Get the first day of the month (from tutorial)

            DateTime startofthemonth = new DateTime(year, month, 1);

            //Get the count of days of the month
            int days = DateTime.DaysInMonth(year, month);

            //convert the startofthemonth to integer
            int dayoftheweek = Convert.ToInt32(startofthemonth.DayOfWeek.ToString("d")) + 1;



            //first create a blank usercontrol 

            for (int i = 1; i < dayoftheweek; i++)
            {
                UserControlBlank ucblank = new UserControlBlank();
                daycontainer.Controls.Add(ucblank);
            }

            //Create usercontrol for days
            for (int i = 1; i <= days; i++)
            {
                UserControlDays ucdays = new UserControlDays();
                ucdays.days(i);
                daycontainer.Controls.Add(ucdays);
            }
        }

       

        private void btnprevious_Click(object sender, EventArgs e)
        {
            
            //clear container
            daycontainer.Controls.Clear();

            //Decrement month to go to the previous month
            month--;
            if(month <= 0)
            {
                month = 12;
                year--;
            }

            /*//Get the first day of the mnth
            String monthname = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            LBDATE.Text = monthname + " " + year;

            DateTime now = DateTime.Now;
            Console.WriteLine("Date is" + now);
            //Get the first day of the month (from tutorial)

            DateTime startofthemonth = new DateTime(year, month, 1);
            Console.WriteLine("Start of the month is" + startofthemonth);
            //Get the count of days of the month
            int days = DateTime.DaysInMonth(year, month);
            Console.WriteLine("Num of days is " + days);
            //convert the startofthemonth to integer
            int dayoftheweek = Convert.ToInt32(startofthemonth.DayOfWeek.ToString("d")) + 1;
            Console.WriteLine("Day of week is" + dayoftheweek);


            //first create a blank usercontrol 

            for (int i = 1; i < dayoftheweek; i++)
            {
                UserControlBlank ucblank = new UserControlBlank();
                daycontainer.Controls.Add(ucblank);
            }

            //Create usercontrol for days
            for (int i = 1; i <= days; i++)
            {
                UserControlDays ucdays = new UserControlDays();
                ucdays.days(i);
                daycontainer.Controls.Add(ucdays);
            } */

            showDisplay();
        }

        private void btnnext_Click_1(object sender, EventArgs e)
        {
            //clear container
            daycontainer.Controls.Clear();

            //Increment month to go to the next month
            month++;
            if(month >= 13)
            {
                month = 1;
                year++;
            }
            /*

            //Get the first day of the mnth
            String monthname = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            LBDATE.Text = monthname + " " + year;

            DateTime now = DateTime.Now;
            Console.WriteLine("Date is" + now);
            //Get the first day of the month (from tutorial)

            DateTime startofthemonth = new DateTime(year, month, 1);
            Console.WriteLine("Start of the month is" + startofthemonth);
            //Get the count of days of the month
            int days = DateTime.DaysInMonth(year, month);
            Console.WriteLine("Num of days is " + days);
            //convert the startofthemonth to integer
            int dayoftheweek = Convert.ToInt32(startofthemonth.DayOfWeek.ToString("d")) + 1;
            Console.WriteLine("Day of week is" + dayoftheweek);


            //first create a blank usercontrol 

            for (int i = 1; i < dayoftheweek; i++)
            {
                UserControlBlank ucblank = new UserControlBlank();
                daycontainer.Controls.Add(ucblank);
            }

            //Create usercontrol for days
            for (int i = 1; i <= days; i++)
            {
                UserControlDays ucdays = new UserControlDays();
                ucdays.days(i);
                daycontainer.Controls.Add(ucdays);
            } */

            showDisplay();
        }
    }
}
