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

        private void bLogin_Click(object sender, EventArgs e)
        {


            if (tdEmail.Text == useremail && tbPsw.Text == userpsw && tdEmail.Text!=null&& tbPsw.Text != null) // проверка регистрации пользователя
            {
                FormPage formPage = new FormPage();
                formPage.Show();
                this.Hide();
            }
            else
            {
               if (tdEmail.Text=="" && tbPsw.Text=="") 
                {
                    MessageBox.Show("Enter passwor and email"); 
                }
               else if (tdEmail.Text != useremail ) 
                {
                    MessageBox.Show("Incorrect user email");
                }
                else if (tbPsw.Text != userpsw) 
                {
                    MessageBox.Show("Incorrect user password "); 
                }
                else if (tdEmail.Text != useremail&& tbPsw.Text != userpsw) 
                {
                    MessageBox.Show("Incorrect user password ");
                }
               
            }
        }
    }
}
