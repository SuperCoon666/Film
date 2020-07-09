using Microsoft.Data.Sqlite;
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

namespace Film
{
    public partial class FormLogin : Form
    {
        //
        string useremail ="em"; // переменная в которую передаем почту 
        string userpsw="ps"; // переменная в которую передаем пароль 
        public FormLogin()
        {
            InitializeComponent();
        }
        SQLiteConnection connection= new SQLiteConnection();
        DataTable table;
        private void FormLogin_Load(object sender, EventArgs e)
        {

        }

        private void bLogin_Click(object sender, EventArgs e)
        {

            SQLiteConnection connection = new SQLiteConnection();
            connection.ConnectionString = @"Data Source = C:\Users\Vlad\Desktop\Film\FilmsBd.db";
            //connection.ConnectionString = @"Data Source = D:\Базы данных\SchoolDB.db";
            connection.Open();


            string sql = "SELECT * FROM users WHERE login = '" + tbLogin.Text + "' AND psw = '" + tbPsw.Text + "';";

            SQLiteDataAdapter adapter = new SQLiteDataAdapter(sql, connection);
            table = new DataTable();
            adapter.Fill(table);


            if (table.Rows.Count == 1)//tbLogin.Text == useremail && tbPsw.Text == userpsw && tbLogin.Text != null&& tbPsw.Text != null) // проверка регистрации пользователя
            {
                FormPage formPage = new FormPage();
                formPage.Show();
                this.Hide();
            }
            else
            {
               if (tbLogin.Text == "" && tbPsw.Text=="") 
                {
                    MessageBox.Show("Enter password and login"); 
                }
               else
                {
                    MessageBox.Show("Incorrect user email or password ");
                }
            }
        }

        private void bReg_Click(object sender, EventArgs e)
        {
            SQLiteConnection connection = new SQLiteConnection();
            connection.ConnectionString = @"Data Source = C:\Users\Vlad\Desktop\Film\FilmsBd.db";
            //connection.ConnectionString = @"Data Source = D:\Базы данных\SchoolDB.db";
            connection.Open();
            MessageBox.Show("Connect ");

            //string sql = "INSERT users (login, psw) VALUES ('" + tbLogin.Text+"','"+ tbPsw.Text +"')";
            SQLiteCommand command = new SQLiteCommand("INSERT INTO users (login, psw) VALUES ('" + tbLogin.Text + "','" + tbPsw.Text + "')", connection);
            command.ExecuteNonQuery();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            SQLiteConnection connection = new SQLiteConnection();
            connection.ConnectionString = @"Data Source = C:\Users\Vlad\Desktop\Film\FilmsBd.db";
            //connection.ConnectionString = @"Data Source = D:\Базы данных\SchoolDB.db";
            connection.Open();

            SQLiteDataAdapter adapter = new SQLiteDataAdapter("SELECT* FROM users;", connection);
            table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }
    }
}
