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
        DataTable table= new DataTable();
        private void FormLogin_Load(object sender, EventArgs e)
        {

        }

        private void bLogin_Click(object sender, EventArgs e)
        {
            // этo осуществляют коннект к бд
            DB.conetc();

            string sql = "SELECT * FROM users WHERE login = '" + tbLogin.Text + "' AND psw = '" + tbPsw.Text + "';"; //ввод запроса логина и пароля
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(sql, DB.connection);
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
            DB.conetc();

            string sql = "SELECT * FROM users WHERE login = '" + tbLogin.Text + "' AND psw = '" + tbPsw.Text + "';"; //проверка регистрации пользователя
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(sql, DB.connection);
            adapter.Fill(table);

            if (table.Rows.Count == 1)// существует,вывод ошибки
            {
                MessageBox.Show("This user already exists");
            }
            else //не существует,регестрируем
            {
                SQLiteCommand command = new SQLiteCommand("INSERT INTO users (login, psw) VALUES ('" + tbLogin.Text + "','" + tbPsw.Text + "')", DB.connection);
                command.ExecuteNonQuery();
            }
        }

        private void button1_Click(object sender, EventArgs e) //тестовое, нужно для отображения содержмого таблицы
        {
            DB.conetc();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter("SELECT* FROM users;", DB.connection);
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }
    }
}
