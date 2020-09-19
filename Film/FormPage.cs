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
            table = new DataTable();
            string sql;

            sql = "SELECT * FROM films WHERE NameFilm = ' " + tbShare.Text + " ';";
            DB.usradapt(sql, 2);

            table = new DataTable();
            sql = "SELECT NameFilm FROM films WHERE NameFilm = '" + tbShare.Text + "';";
            DB.usradapt(sql, 2);

            if (tbShare.Text.Trim().Length!=0 && table.Rows.Count !=0 )// существует,вывод фильма
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
                List<string> newtag = new List<string>();
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

                //foreach(var rr in newtag) { label1.Text += rr + " "; };
                string sqlcom = "UPDATE users SET history ='" + $"{String.Join("/", histor) + String.Join("/", newtag)}" + "' WHERE login= '" + nameuser + "';";
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
            nameFilm = dgvResult.CurrentCell.Value.ToString();

            FormDialogRate1 formDialogRate1 = new FormDialogRate1();

            formDialogRate1.clickFilm = nameFilm;
            formDialogRate1.ShowDialog();
        }

        private void bReccomend_Click(object sender, EventArgs e) // показать рекомандации
        {
            DB.conetc();


            table = new DataTable(); // запрос истории поиска
            string sql = "SELECT history FROM users WHERE login= '" + nameuser + "';";
            DB.usradapt(sql, 2);
            string[] histor = table.Rows[0]["history"].ToString().Split('/');



            List<string> pruv = new List<string>();
            List<string> pruv2 = new List<string>();

            table = new DataTable();
            foreach (var word in histor)
            {
                pruv.Clear();

                sql = "SELECT NameFilm, srRate FROM films WHERE tags LIKE'" + $"%{word}%'";
                DB.usradapt(sql, 3);

                for (int i =0; i< tages.Rows.Count; i++) 
                {
                    string m = tages.Rows[i]["NameFilm"].ToString();
                    pruv.Add(m);
                }

                bool srw=false;
                string second="f";

                if (pruv2.Count() == 0) { pruv2.Add(pruv[0]); }

                foreach (var wr in pruv)
                {
                    if (Equals(wr, second) == false)
                    {
                        foreach (var l in pruv2.ToArray())
                        {
                            srw = Equals(wr, l);
                            if (srw == true) { break; };
                        };
                        if (srw == false) { pruv2.Add(wr); };
                    }
                    second = wr;
                };
            }

            //foreach (var x in pruv2) { label1.Text += x+" "; };

            dgvResult.ColumnCount = pruv2.Count();
            dgvResult.Columns[0].Name = "NameFilms";

            tages.Clear();
            int iii=0;
            foreach (var x in pruv2)
            {            
                sql = "SELECT srRate FROM films WHERE NameFilm = '" + x + "';";
                DB.usradapt(sql, 3);

                string m = tages.Rows[iii]["srRate"].ToString();
                iii++;
                dgvResult.Rows.Add(x,m);
            };
            //dataGridView1.DataSource = tages;

            DB.connection.Close();
        }
    }
}
