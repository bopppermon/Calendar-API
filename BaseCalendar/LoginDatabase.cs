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
        }        

        public void AddUser(string username, string password)
        {
           using (var db = new SQLiteConnection($"Data Source={_dataSource}"))
            {                
                db.Open();

                // check if username is unique
                string checkExisitingUser = @"SELECT COUNT(*) FROM Users WHERE Username = @Username";
                using (var checkCommand = new SQLiteCommand(checkUsernameQuery, db))
                {
                    checkCommand.Parameters.AddWithValue("@Username", username);
                    int matchingUsers = Convert.ToInt32(checkCommand.ExecuteScalar());
                    if (matchingUsers != 0)
                    {
                        // Username already exists
                        Console.WriteLine("Try again: User already exists.");
                    }
                }
                string insertQuery = @"INSERT INTO Users (Username, Password) VALUES (@Username, @Password)"
                using (var insertCommand = new SQLiteCommand(insertQuery, db))
                {
                    insertCommand.Parameters.AddWithValue("@Username", username);
                    insertCommand.Parameters.AddWithValue("@Password", password);
                }
                Console.WriteLine("User added!");
            } 
        }
        public bool VerifyUser(string username, string password)
        {
            using (var db = new SQLiteConnection($"Data Source={_dataSource}"))
            {                
                db.Open();

                string insertQuery = @"SELECT COUNT(*) FROM Users WHERE Username = @Username AND Password = @Password"
                using (var checkCommand = new SQLiteCommand(insertQuery, db))
                {
                    checkCommand.Parameters.AddWithValue("@Username", username);
                    checkCommand.Parameters.AddWithValue("@Password", password);
                    int count = Convert.ToInt32(checkCommand.ExecuteScalar)
                }
                if (count == 1)
                {
                    Console.WriteLine("Login Correct!");
                }
                else 
                {
                    Console.WriteLine("User does not exist. Please signup");
                }
            }
        }
    }
} 
