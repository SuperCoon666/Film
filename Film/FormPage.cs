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

            sql = "SELECT * FROM films WHERE NameFilm = ' " + tbShare.Text.Replace(" ", "") + " ';";
            DB.usradapt(sql, 2);

            if (table.Rows.Count >= 1)// существует,вывод фильма
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
                string sqlcom = "UPDATE users SET history ='" + $"{String.Join("/", histor) + String.Join("/", tags)}" + "' WHERE login= '" + nameuser + "';";
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
         //   pruv2.Add("0");

            table = new DataTable();
            foreach (var word in histor)
            {
                int counts = 0;

                sql = "SELECT NameFilm, srRate FROM films WHERE tags LIKE'" + $"%{word}%'";
                DB.usradapt(sql, 2);



                //sql = "SELECT NameFilm FROM films WHERE tags LIKE'" + $"%{word}%'";
                //DB.usradapt(sql, 3);

                // pruv.Add(tages.Rows[counts]["NameFilm"].ToString());


                //for (int j = 0; j < pruv2.Count; j++)
                //{
                //    if (pruv[counts] != pruv2[j])
                //    {
                //        sql = "SELECT NameFilm, srRate FROM films WHERE tags LIKE'" + $"%{word}%'";
                //        pruv2.Add(pruv[counts]);
                //        DB.usradapt(sql, 2);

                //    }
                //}





                //for (int i = 0; i < pruv.Count; i++)
                //{
                //    ProductA[] storeA = { new ProductA { Name = pruv[counts] } };
                //    ProductA[] storeB = { new ProductA { Name = pruv2[i] } };
                //    bool equalAB = storeA.SequenceEqual(storeB);

                //    if (equalAB!=true)
                //    {
                //pruv2.Add(pruv[counts]);
                //DB.usradapt(sql, 2);
                //    }
                //}

                counts++;

            }

            dgvResult.DataSource = table;
            dataGridView1.DataSource = tages;

            DB.connection.Close();
        }

        //public class ProductA : IEquatable<ProductA>
        //{
        //    public string Name { get; set; }
        //    public bool Equals(ProductA other)
        //    {
        //        if (other is null)
        //            return false;

        //        return this.Name == other.Name;
        //    }

        //    public override bool Equals(object obj) => Equals(obj as ProductA);
        //    public override int GetHashCode() => (Name).GetHashCode();
        //}

    }
}
