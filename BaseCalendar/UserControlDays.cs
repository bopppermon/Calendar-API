using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseCalendar
{
    public partial class UserControlDays : UserControl
    {
        //Included in Part 2
        public static string static_day;

        public UserControlDays()
        {
            InitializeComponent();
        }

        private void UserControlDays_Load(object sender, EventArgs e)
        {

        }
        public void days(int numday)
        {
            lbdays.Text = numday + "";
            displayEvent();
        }


        private void UserControlDays_Click(object sender, EventArgs e)
        {
            static_day = lbdays.Text;
            timer1.Start();
            EventForm eventForm = new EventForm();
            eventForm.Show();
        }

        //Displays Events
        private void displayEvent()
        {
            Database db = new Database("./Db.db");

            var entries = db.GetData();

            //Date is parsed and formatted in the way that it is stored in the database
            DateTime enteredDate = DateTime.Parse(Form1.static_year + "-" + Form1.static_month + "-" + lbdays.Text);
            string sqlizedDate = enteredDate.ToString("yyyy-MM-dd HH:mm:ss");
             
            //For each element in the database
            for (int i = 0; i < entries.Count; i++)
            {
                //If element date matches with date on calender, it adds event name to calender
                //This will include events that are in the database before opening the calender program
                if (entries.ElementAt(i).Item2.Equals(sqlizedDate.ToString()))
                {
                    eventName.Text = entries.ElementAt(i).Item1.ToString();
                }

            }

        }

        //From Part 3, a timer that automatically refreshes event info
        private void timer1_Tick(object sender, EventArgs e)
        {
            displayEvent();
        }
    }
}
