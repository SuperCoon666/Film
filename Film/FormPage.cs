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
    public partial class FormPage : Form
    {
        public FormPage()
        {
            InitializeComponent();
        }

        private void FormPage_Load(object sender, EventArgs e)
        {

        }

        private void bShare_Click(object sender, EventArgs e)
        {
            DB dB = new DB();
            dB.share();
            //if есть результаты поиска
        }
    }
}
