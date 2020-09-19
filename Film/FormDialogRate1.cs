using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Film
{
    public partial class FormDialogRate1 : Form
    {
        public FormDialogRate1()
        {
            InitializeComponent();
        }
        string name;
        public string clickFilm // получение названия фильма
        {
            get { return name; }
            set { name = value; }
        }

        private void FormDialogRate1_Load(object sender, EventArgs e)
        {
            
        }

        private void bRate_Click(object sender, EventArgs e)
        {
            //label1.Text = name;
            if (Convert.ToInt32(tbRate.Text) <= 100 && Convert.ToInt32(tbRate.Text)>0)
            {
                DB.conetc();

                string sqlcom = "UPDATE films SET countRates = countRates+1 WHERE NameFilm= '" + name + "';";
                DB.command(sqlcom);

                sqlcom = "UPDATE films SET rate = rate+" + Convert.ToInt32(tbRate.Text) + " WHERE NameFilm= '" + name + "';";
                DB.command(sqlcom);

                sqlcom = "UPDATE films SET srRate = rate/countRates WHERE NameFilm= '" + name + "';";
                DB.command(sqlcom);

                DB.connection.Close();
                this.Close();
            }
            else { MessageBox.Show("You can only bet points from 0 to 100"); }
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
