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
        private void FormPage_Load(object sender, EventArgs e)
        {
            
        }

        private void bShare_Click(object sender, EventArgs e)
        {
            DB.conetc();

            string sql = "SELECT * FROM films WHERE NameFilm = '" + tbShare.Text.Replace(" ", "") + "';";
            DB.usradapt(sql,2);

            if (table.Rows.Count == 1)// существует,вывод фильма
            {
                table = new DataTable();
                string sql2 = "SELECT NameFilm FROM films WHERE NameFilm = '" + tbShare.Text + "';";

                DB.usradapt(sql2,2);

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
    }
}
