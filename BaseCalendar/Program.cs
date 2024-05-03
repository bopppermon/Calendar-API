using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseCalendar
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Database db = new Database("./Db.db");
            db.AddEvent("Park", DateTime.Now);
            var entries = db.GetData();
            entries.ForEach((data) => Console.WriteLine($"Event: {data.Item1} Date: {data.Item2}"));

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
