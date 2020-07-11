using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Film
{
   public class DB
    {
        public static SQLiteConnection connection = new SQLiteConnection();
        public static void conetc() 
        {
           // SQLiteConnection connection = new SQLiteConnection();
            connection.ConnectionString = @"Data Source = C:\Users\Vlad\Desktop\Film\FilmsBd.db";
            connection.Open();

        }
    }
}
