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
using System.Net.Http.Headers;
using System.Net.Http;
using Newtonsoft.Json;
using System.Runtime.ExceptionServices;


namespace BaseCalendar
{
    //Making a class Holiday in order to be able to deserialize it later
    public class Holiday
    {
        public string date { get; set; }
        public string name { get; set; }

        }

    public partial class Form1 : Form
    {
        DateTime now;
        int month, year;
        
        //Maintaining a list of years that we fetched the holidays for, so we don't make unnessecary API calls
        List<int> yearsFetched = new List<int>();


        

        //Included in Part 2 of video tutorial, used as date variables
        public static int static_month, static_year;

        //Conncting to the Database in order to push the holidays to the calendar
        Database db = new Database("./Db.db");

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
       private async Task displayDays()
        {

            // DateTime now = DateTime.Now;
            now = DateTime.Now;
            month = now.Month;
            year = now.Year;

            //Included in Part 2
            static_month = month;
            static_year = year;

            //If we are starting out, populate the calendar with 10 years into the future
           /* if (yearsFetched.Count == 0)
            {
                int temp = static_year + 1;
                for (int i = 0; i < 10; i++)
                {
                    await getHolidays(temp);
                    temp++;
                }
            } */

            //If we have not fetched the current year's holidays then we fetch it
            if (!yearsFetched.Contains(static_year))
            {
                //Set the text to LOADING while we get the API data for the current year
                LBDATE.Text = "LOADING";
                //Wait to get all the holidays for the current year
                await getHolidays(static_year);
                //Show the calendar
                showDisplay();
            } else
            {
                //Show the calendar
                showDisplay();
            } 

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

        private async void btnprevious_Click(object sender, EventArgs e)
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
            //Included in Part 2
            static_month = month;
            static_year = year;


            //If we have not fetched the current year's holidays then we fetch it
            if (!yearsFetched.Contains(static_year))
            {
                //Set the header to LOADING while waiting for the API
                LBDATE.Text = "LOADING";
                //WAIT for the holidays to fetch
                await getHolidays(static_year);
                //Show the calendar for the desired year once the holidays are fetched
                showDisplay();
            } else
            {
                showDisplay();
            }


        }

        private async void btnnext_Click_1(object sender, EventArgs e)
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

            //Included in Part 2
            static_month = month;
            static_year = year;


            //If we have not fetched the current year's holidays then we fetch it
            if (!yearsFetched.Contains(static_year))
            {
                //Set the text to Loading while we wait to get the holidays for the new year
                LBDATE.Text = "LOADING";
                //Get the holidays for the year we are going to
                await getHolidays(static_year);
                //After that is done, display the holidays for the new year
                showDisplay();
            } else
            {
                showDisplay();
            }


        }


        //This method will fetch all the holidays for the current year

        private async Task getHolidays(int year)
        {

            //First we await the holidays to fetch successfully in the calendar
            await Task.Run(async() =>
            {
                //Make the request to the API with the current year that you are in
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://public-holiday.p.rapidapi.com/{year}/US"),
                    Headers =
                {
                    {"X-RapidAPI-Key", "89678678bfmsh4c17c52f6e82f5dp1f42cejsn4e6d09bb1060" },
                    {"X-RapidAPI-Host", "public-holiday.p.rapidapi.com" },
                },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();

                    var body = await response.Content.ReadAsStringAsync();

                    List<Holiday> holidays = JsonConvert.DeserializeObject<List<Holiday>>(body);

                    foreach (var holiday in holidays)
                    {
                        //Convert the date to DateTime
                        try
                        {
                            DateTime holidayDate = DateTime.Parse(holiday.date);

                            db.AddEvent(holiday.name, holidayDate);
                        }
                        catch (Exception e)
                        {
                            Console.Write("error adding holiday");
                        }

                    }

                    yearsFetched.Add(year);
                }
            });
            
        }
    }
}
