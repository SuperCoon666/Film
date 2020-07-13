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
        string nameuser; // переменная, в которую передаётся логин, под которым зашел юзер

        public void FormPage_Load(object sender, EventArgs e)
        {
            
        }


        public string textbox1value
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

                table = new DataTable();
                sql = "SELECT tags FROM films WHERE NameFilm = '" + tbShare.Text + "';";
                DB.usradapt(sql, 2);

                string[] words = table.Rows[0]["tags"].ToString().Split('/');
                
                foreach (var word in words)
                {
                    //label1.Text += $"\n{word}";
                    string sqlcom = "UPDATE users SET history = '" + $"{word}/" + "' WHERE login= '" + nameuser + "';";
                    DB.command(sqlcom);
                }




                table = new DataTable();
                sql = "SELECT NameFilm FROM films WHERE NameFilm = '" + tbShare.Text + "';";

                DB.usradapt(sql, 2);

                dgvResult.DataSource = table;

            }
            else //не существует,вывод ошибки
            {
                MessageBox.Show("This movie does not exist");
            }
            DB.connection.Close();
        }


        private void dgvResult_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            FormDialogRate1 formDialogRate1 = new FormDialogRate1();
            formDialogRate1.ShowDialog();
        }

        private void bReccomend_Click(object sender, EventArgs e)
        {
            label1.Text = nameuser;
        }
    }
}
