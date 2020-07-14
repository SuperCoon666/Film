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
        public static void conetc() //функция соединения с бд
        {
            // SQLiteConnection connection = new SQLiteConnection();
            connection.ConnectionString = @"Data Source = C:\Users\Vlad\Desktop\Film\FilmsBd.db";
            connection.Open();
        }
        public static void usradapt(string sql, int f) //функция запроса для бд
        {
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(sql, DB.connection);
            if (f == 1) { adapter.Fill(FormLogin.table); }
            else if (f == 2) { adapter.Fill(FormPage.table); }

        }
        public static void command (string sqlcom) //функция команды для бд
        {
            SQLiteCommand command = new SQLiteCommand(sqlcom, DB.connection);
            command.ExecuteNonQuery();
        }
    }
}
