using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace J7p5
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
           
        }


        private void FormMain_Load(object sender, EventArgs e)
        {

        }

        private void Student_click(object sender, EventArgs e)
        {
           FormStudent form = new FormStudent();
            form.ShowDialog();
            //MessageBox.Show("Heeeeeelooooooooooooooo");
        }

        private void Proof_click(object sender, EventArgs e)
        {
            FormProof form = new FormProof();
            form.ShowDialog();    
        }
    }
}
