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
    public partial class FormPage : Form
    {
        public FormPage()
        {
            InitializeComponent();
        }
        public static DataTable table = new DataTable();
        public static DataTable tages = new DataTable();
        public static DataTable news = new DataTable();
        string nameuser; // переменная, в которую передаётся логин, под которым зашел юзер

        public void FormPage_Load(object sender, EventArgs e)
        {
            
        }


        public string textbox1value // получение логин пользователя
        {
            get { return nameuser; }
            set { nameuser = value; }
        }


        private void bShare_Click(object sender, EventArgs e)
        {
            DB.conetc();
            string sql;

            sql = "SELECT * FROM films WHERE NameFilm = '" + tbShare.Text.Replace(" ", "") + "';";
            DB.usradapt(sql, 2);

            if (table.Rows.Count == 1)// существует,вывод фильма
            {
                table = new DataTable(); // запрос истории поиска
                sql = "SELECT history FROM users WHERE login= '" + nameuser + "';";
                DB.usradapt(sql, 2);
                string[] histor = table.Rows[0]["history"].ToString().Split('/');

                table = new DataTable(); // запрос тегов фильма
                sql = "SELECT tags FROM films WHERE NameFilm = '" + tbShare.Text + "';";
                DB.usradapt(sql, 2);
                string[] tags = table.Rows[0]["tags"].ToString().Split('/');


                //функция Join объеденяет массив в одну строку, помещая между каждым елементом заданный разделитель
                string sqlcom = "UPDATE users SET history ='" + $"{String.Join("/", histor) + String.Join("/", tags)}/" + "' WHERE login= '" + nameuser + "';";
                DB.command(sqlcom);

                table = new DataTable();
                sql = "SELECT NameFilm FROM films WHERE NameFilm = '" + tbShare.Text + "';";
                DB.usradapt(sql, 2);

                dgvResult.DataSource = table; //вывод искомого результата в объект dataGridView

            }
            else //не существует,вывод ошибки
            {
                MessageBox.Show("This movie does not exist");
            }
            DB.connection.Close();
        }


        private void dgvResult_CellContentClick(object sender, DataGridViewCellEventArgs e) // вызов диалоговой формы для оценивания фильма
        {
            FormDialogRate1 formDialogRate1 = new FormDialogRate1();
            formDialogRate1.ShowDialog();
        }

        private void bReccomend_Click(object sender, EventArgs e) // показать рекомандации
        {
            DB.conetc();

            table = new DataTable(); // запрос истории поиска
            string sql = "SELECT history FROM users WHERE login= '" + nameuser + "';";
            DB.usradapt(sql, 2);
            string[] histor = table.Rows[0]["history"].ToString().Split('/');



            //List<string> pruv = new List<string>();
            //List<string> pruv2 = new List<string>();
            //pruv2.Add("0");

        //    bool first = false;
            foreach (var word in histor) 
            {
                table = new DataTable();
                sql = "SELECT NameFilm FROM films WHERE tags LIKE'" + $"%{word}%'";
                DB.usradapt(sql, 2);

                //if (first == false)
                //{
                //   // first = true;
                    

                //    //sql = "SELECT IdFilm FROM films WHERE tags LIKE'" + $"%{word}%'";
                //    //DB.usradapt(sql, 3);

                //         pruv.Add(word); //(tages.Rows[0]["IdFilm"].ToString());

                //    //sql = "SELECT IdFilm FROM films WHERE tags LIKE'" + $"%{word}%'";
                //    //DB.usradapt(sql, 4);

                //    // pruv2.Add(news.Rows[0]["IdFilm"].ToString());


                //}
                //else 
                //{
                //    //sql = "SELECT IdFilm FROM films WHERE tags LIKE'" + $"%{word}%'";
                //    //DB.usradapt(sql, 3);
                //    //pruv.Add(tages.Rows[0]["IdFilm"].ToString());

                //    //for (int i = 0; i < pruv2.Count;)
                //    //{
                //    //    for (int z = 0; z < pruv.Count;)
                //    //    {
                //    //        if (pruv2[i] != pruv[z])
                //    //        {
                //    //            sql = "SELECT IdFilm FROM films WHERE tags LIKE'" + $"%{word}%'";
                //    //            DB.usradapt(sql, 4);
                //    //            pruv2.Add(news.Rows[0]["IdFilm"].ToString());

                //    //            sql = "SELECT NameFilm FROM films WHERE tags LIKE'" + $"%{word}%'";
                //    //            DB.usradapt(sql, 2);

                //    //        }
                //    //        z++;
                //    //    }
                //    //    i++;
                //    //}
                //    for (int i=0; i< pruv.Count;) 
                //    {
                //        if (pruv[i] != word) 
                //        {
                //            pruv.Add(word);

                //            //sql = "SELECT IdFilm FROM films WHERE tags LIKE'" + $"%{word}%'";
                //            //DB.usradapt(sql, 4);
                //          //  pruv2.Add(news.Rows[0]["IdFilm"].ToString());

                //            sql = "SELECT NameFilm FROM films WHERE tags LIKE'" + $"%{word}%'";
                //            DB.usradapt(sql, 2);

                //        }
                //        i++;
                //    }

                //}

            }
            
            //dgvResult.DataSource = table;
            //dataGridView1.DataSource = tages;
            dataGridView2.DataSource = news;

            DB.connection.Close();
        }
    }
}
