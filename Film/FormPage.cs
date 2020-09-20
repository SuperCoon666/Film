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
        string nameuser; // переменная, в которую передаётся логин, под которым зашел юзер
        string nameFilm = "x"; // переменная, в которую передаём название фильма, на который нажали

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

            //запрос для проверки сущствования искомых фильмов
            table = new DataTable();
            sql = "SELECT NameFilm FROM films WHERE NameFilm LIKE '%" + tbShare.Text.Trim(' ') + "%';";
            DB.usradapt(sql, 2);

            if (tbShare.Text.Trim(' ').Length!=0 && table.Rows.Count !=0 )// существует,вывод фильма
            {
                // запрос истории поиска
                table = new DataTable();
                sql = "SELECT history FROM users WHERE login= '" + nameuser + "';";
                DB.usradapt(sql, 2);
                string[] histor = table.Rows[0]["history"].ToString().Split('/');

                // запрос тегов фильма
                table = new DataTable(); 
                sql = "SELECT tags FROM films WHERE NameFilm LIKE '%" + tbShare.Text.Trim(' ') + "%';";
                DB.usradapt(sql, 2);
                string[] tags = table.Rows[0]["tags"].ToString().Split('/');
                
                List<string> newtag = new List<string>();//список для тегов,которых нет в истории

                //сравнение тегов фильмов и истории пользователя
                bool gothcha = false;
                foreach (var tag in tags) 
                {
                    foreach (var tag2 in histor) 
                    {
                        gothcha = Equals(tag, tag2);
                        if (gothcha == true) { break; };
                    };
                    if (gothcha==false) 
                    {
                        newtag.Add(tag);
                    };
                };

                //записывание в историю новых тегов
                string sqlcom = "UPDATE users SET history ='" + $"{String.Join("/", histor) + String.Join("/", newtag)}" + "' WHERE login= '" + nameuser + "';";
                //функция Join объеденяет массив в одну строку, помещая между каждым елементом заданный разделитель
                DB.command(sqlcom);

                //вывод искомых фильмов
                table = new DataTable();
                sql = "SELECT NameFilm, srRate FROM films WHERE NameFilm LIKE '%" + tbShare.Text.Trim(' ') + "%';";
                DB.usradapt(sql, 2);

                dgvResult.DataSource = table; //вывод искомого результата в объект dataGridView

            }
            else //не существует,вывод ошибки
            {
                MessageBox.Show("This movie does not exist");
                tbShare.Text = "";
            }
            DB.connection.Close();
        }


        private void dgvResult_CellContentClick(object sender, DataGridViewCellEventArgs e) // вызов диалоговой формы для оценивания фильма
        {
            nameFilm = dgvResult.CurrentCell.Value.ToString();

            FormDialogRate1 formDialogRate1 = new FormDialogRate1();

            formDialogRate1.clickFilm = nameFilm;
            formDialogRate1.ShowDialog();
        }

        private void bReccomend_Click(object sender, EventArgs e) // показать рекомандации
        {
            DB.conetc();

            //очиста dgv
            if (dgvResult.DataSource != null)
            {
                dgvResult.DataSource = null;
            }
            else
            {
                dgvResult.Rows.Clear();
            }

            // запрос истории поиска
            table = new DataTable(); 
            string sql = "SELECT history FROM users WHERE login= '" + nameuser + "';";
            DB.usradapt(sql, 2);
            string[] histor = table.Rows[0]["history"].ToString().Split('/');


            //создание список для записывания имён фильмов
            List<string> pruv = new List<string>();
            List<string> pruv2 = new List<string>();

            table = new DataTable();
            foreach (var word in histor) //поиск фильм с тега истории
            {
                pruv.Clear();

                sql = "SELECT NameFilm, srRate FROM films WHERE tags LIKE'" + $"%{word}%'";
                DB.usradapt(sql, 3);

                for (int i =0; i< tages.Rows.Count; i++)  //записывание фильмов с совпадающим тегом word
                {
                    string m = tages.Rows[i]["NameFilm"].ToString();
                    pruv.Add(m);
                }

                bool srw=false;
                string second="f"; //переменная для хранения прошлого названия фильма

                if (pruv2.Count() == 0) { pruv2.Add(pruv[0]); }//добавление первого фильма

                foreach (var wr in pruv) //берём имя фильма из списка совпадений
                {
                    if (Equals(wr, second) == false) //проверка, если этот фильм сравнивался прошлым
                    {
                        foreach (var l in pruv2.ToArray())//сравнение имение с уже выведенными
                        {
                            srw = Equals(wr, l);
                            if (srw == true) { break; };
                        };
                        if (srw == false) { pruv2.Add(wr); }; //добавлям в список вывода
                    }
                    second = wr;//запоминаем имя, которое только что сравнивали
                };
            }

            dgvResult.ColumnCount = pruv2.Count();//создание стобцов под вывод
            dgvResult.Columns[0].Name = "NameFilms";//оглавление

            tages.Clear();//очиста таблицы совпадений

            //вывод списка без повторок
            int iii =0;
            foreach (var x in pruv2)
            {            
                sql = "SELECT srRate FROM films WHERE NameFilm = '" + x + "';";
                DB.usradapt(sql, 3);

                string m = tages.Rows[iii]["srRate"].ToString();
                iii++;
                dgvResult.Rows.Add(x,m);
            };

            DB.connection.Close();
        }
    }
}
