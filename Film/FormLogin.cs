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
        public FormLogin()
        {
            InitializeComponent();
        }
        //SQLiteConnection connection= new SQLiteConnection();
        DataTable table;
        private void FormLogin_Load(object sender, EventArgs e)
        {

        }

        private void bLogin_Click(object sender, EventArgs e)
        {

            //DB dB = new DB();
            //dB.conetc();


            // эти три строчки осуществляют коннект к бд
            SQLiteConnection connection = new SQLiteConnection();
            connection.ConnectionString = @"Data Source = C:\Users\Vlad\Desktop\Film\FilmsBd.db";
            connection.Open();

            string sql = "SELECT * FROM users WHERE login = '" + tbLogin.Text + "' AND psw = '" + tbPsw.Text + "';"; //ввод запроса логина и пароля
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(sql, connection);
            table = new DataTable();
            adapter.Fill(table);


            if (table.Rows.Count == 1) //проверка регистрации пользователя
            {
                FormPage formPage = new FormPage();
                formPage.Show();
                this.Hide();
            }
            else
            {
               if (tbLogin.Text == "" || tbPsw.Text=="") //если одно из полей незаполнено
                {
                    MessageBox.Show("Enter password and login"); 
                }
               else
                {
                    MessageBox.Show("Incorrect user email or password "); //если не найдено совпадений
                }
            }
        }

        private void bReg_Click(object sender, EventArgs e)
        {
            //DB dB = new DB();
            //dB.conetc();

            SQLiteConnection connection = new SQLiteConnection();
            connection.ConnectionString = @"Data Source = C:\Users\Vlad\Desktop\Film\FilmsBd.db";
            connection.Open();

            string sql = "SELECT * FROM users WHERE login = '" + tbLogin.Text + "' AND psw = '" + tbPsw.Text + "';"; //проверка регистрации пользователя
            if (table.Rows.Count == 1)// существует,вывод ошибки
            {
                MessageBox.Show("This user already exists");
            }
            else //не существует,регестрируем
            {
                SQLiteCommand command = new SQLiteCommand("INSERT INTO users (login, psw) VALUES ('" + tbLogin.Text + "','" + tbPsw.Text + "')", connection);
                command.ExecuteNonQuery();
            }
        }

        private void button1_Click(object sender, EventArgs e) //тестовое, нужно для отображения содержмого таблицы
        {
            //DB dB = new DB();
            //dB.conetc();

            SQLiteConnection connection = new SQLiteConnection();
            connection.ConnectionString = @"Data Source = C:\Users\Vlad\Desktop\Film\FilmsBd.db";
            connection.Open();

            SQLiteDataAdapter adapter = new SQLiteDataAdapter("SELECT* FROM users;", connection);
            table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }
    }
}
