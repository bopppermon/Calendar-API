//using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data.SqlTypes;
using System.IO;

namespace BaseCalendar
{
    internal class Database
    {
        private string _dataSource;

        public Database(string dataSource) {
            _dataSource = dataSource;

            using (var db = new SQLiteConnection($"Data Source={_dataSource}"))
            {
                db.Open();


                string tableCommand = "CREATE TABLE IF NOT EXISTS " +
                    "EventTable (id INTEGER PRIMARY KEY, event TEXT, date DATE);";

                SQLiteCommand createTable = new SQLiteCommand(tableCommand, db);

                createTable.ExecuteReader();
                Console.WriteLine("Create Database Table");
            }
        }        

        public void AddEvent(string eventName, DateTime date)
        {
            using (var db = new SQLiteConnection($"Data Source={_dataSource}"))
            {                
                db.Open();

                SQLiteCommand insertCommand = new SQLiteCommand();
                insertCommand.Connection = db;

                string sqlizedDate = date.ToString("yyyy-MM-dd HH:mm:ss.fff");

                insertCommand.CommandText = "INSERT INTO EventTable VALUES(NULL, @Event, @Date);";
                insertCommand.Parameters.AddWithValue("@Event", eventName);
                insertCommand.Parameters.AddWithValue("@Date", date);

                insertCommand.ExecuteReader();

                Console.WriteLine("Inserted data!");
            }
        }

        public List<(String, String)> GetData()
        {
            List<(String, String)> entries = new List<(string, string)>();

            using (var db = new SQLiteConnection($"Data Source={_dataSource}"))
            {
                db.Open();

                SQLiteCommand selectCommand = new SQLiteCommand("SELECT event, date FROM EventTable", db);

                SQLiteDataReader query = selectCommand.ExecuteReader();

                while (query.Read())
                {                                        
                    entries.Add((query.GetString(0), query.GetString(1)));
                }
            }

            return entries;
        }
    }
}
