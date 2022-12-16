using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using Dapper;

namespace CodeGitz
{
    internal static class SQLiteOps
    {

        // Creates a Table From The String Parameter
        public static void CreateTable(String CreateStatement)
        {

            // Load Database
            using(IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
            {
                // Open Connection To Database
                conn.Open();

                // Create a Command Object For Use With Connection
                SQLiteCommand SqliteController = (SQLiteCommand)conn.CreateCommand();
                
                // Assign SQL Query
                SqliteController.CommandText = CreateStatement;
                
                // Execute Query
                SqliteController.ExecuteNonQuery();

                // Close The Connection
                conn.Close();
            }
        }

        public static List<Posts> ReadTable()
        {
            // Load Database
            using(IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
            {
                // SQL Query That Reads Everything From The Table "posts"
                var sql = "SELECT * FROM posts";

                // Execute Query and Convert it To Type List
                var output = conn.Query<Posts>(sql).ToList();

                // Return The List Of "posts" Objects
                return output;
            }
        } 

        public static void InsertRecords(List<String>InsertStatements)
        {
            // Load Database
            using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
            {
                // Open Connection To Database
                conn.Open();

                // Create a Command Object For Use With Connection
                SQLiteCommand SqliteController = (SQLiteCommand)conn.CreateCommand();

                // Loop Through Every Insert Statement
                foreach (String statement in InsertStatements)
                {
                    // Current Query
                    SqliteController.CommandText = statement;
                    
                    // Execute The SQL Query
                    SqliteController.ExecuteNonQuery();
                }

                // Close The Connection
                conn.Close();
            }
        }

        private static String LoadConnectionString()
        {
            return "Data Source=.\\codegitz.db;Version=3;";
        }
    }
}
