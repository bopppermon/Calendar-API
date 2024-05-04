using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Data.SqlTypes;
using System.IO;
using System.Globalization;


//Used Part 2 of video as a point of reference
namespace BaseCalendar
{
    public partial class EventForm : Form
    {
        Database db = new Database("./Db.db");

        public EventForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Parses through the date information to correctly store in database
            DateTime enteredDate = DateTime.Parse(dateBox.Text);

            db.AddEvent(eventBox.Text, enteredDate);

            MessageBox.Show("Event Saved");

        }

        //This sets the date textbox to the specific date chosen
        private void EventForm_Load_1(object sender, EventArgs e)
        {
            dateBox.Text = Form1.static_year + "/" + Form1.static_month + "/" + UserControlDays.static_day;
        }
    }
}
