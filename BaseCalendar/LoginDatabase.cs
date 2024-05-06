//using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data.SqlTypes;
using System.IO;

namespace BaseCalendar
{
    internal class LoginDatabase
    {
        private string _dataSource;

        public LoginDatabase(string dataSource) {
            _dataSource = dataSource;

            using (var db = new SQLiteConnection($"Data Source={_dataSource}"))
            {
                db.Open();


                string tableCommand = "CREATE TABLE IF NOT EXISTS " +
                    "Users (id INTEGER PRIMARY KEY, username TEXT, password TEXT);";

                SQLiteCommand createTable = new SQLiteCommand(tableCommand, db);

                createTable.ExecuteReader();
                string insertQuery = "INSERT INTO Users (Username, Password) VALUES (@Username, @Password)";

                using (var insertCommand = new SQLiteCommand(insertQuery, db))
                {
                    // Hardcoded username and password
                    insertCommand.Parameters.AddWithValue("@Username", "admin");
                    insertCommand.Parameters.AddWithValue("@Password", "password");
                    insertCommand.ExecuteNonQuery();
                }
            }
        }        

        public void AddUser(string username, string password)
        {
           using (var db = new SQLiteConnection($"Data Source={_dataSource}"))
           {                
                db.Open();

                // check if username is unique
                string checkExistingUser = @"SELECT COUNT(*) FROM Users WHERE Username = @Username";
                using (var checkCommand = new SQLiteCommand(checkExistingUser, db))
                {
                    checkCommand.Parameters.AddWithValue("@Username", username);
                    int matchingUsers = Convert.ToInt32(checkCommand.ExecuteScalar());
                    if (matchingUsers != 0)
                    {
                        // Username already exists
                        Console.WriteLine("Try again: User already exists.");
                    }
                    else
                    {
                        string insertQuery = @"INSERT INTO Users (Username, Password) VALUES (@Username, @Password)";

                        using (var insertCommand = new SQLiteCommand(insertQuery, db))
                        {
                            insertCommand.Parameters.AddWithValue("@Username", username);
                            insertCommand.Parameters.AddWithValue("@Password", password);
                            insertCommand.ExecuteNonQuery();
                        }
                        Console.WriteLine("User added!");
                    }
                }
                
           } 
        }
        public bool VerifyUser(string username, string password)
        {
            int count = 0;
            using (var db = new SQLiteConnection($"Data Source={_dataSource}"))
            {                
                db.Open();

                string selectQuery = @"SELECT COUNT(*) FROM Users WHERE Username = @Username AND Password = @Password";
                using (var checkCommand = new SQLiteCommand(selectQuery, db))
                {
                    checkCommand.Parameters.AddWithValue("@Username", username);
                    checkCommand.Parameters.AddWithValue("@Password", password);
                    count = Convert.ToInt32(checkCommand.ExecuteScalar());
                }
            }
            if (count == 1)
            {
                Console.WriteLine("Login Correct!");
                return true;
            }
            else
            {
                Console.WriteLine("User does not exist. Please signup");
                return false;
            }
        }
    }
} 
