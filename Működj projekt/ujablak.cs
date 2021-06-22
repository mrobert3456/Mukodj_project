using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Működj_projekt
{
    public partial class ujablak : Form
    {
        public ujablak()
        {
            InitializeComponent();
        }

        private void ujablak_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void ujablak_FormClosing(object sender, FormClosingEventArgs e)
        {
          //  form2 = new Form2();
           // form2.flowLayoutPanel1.Controls.Remove(form2.ujlap);
        }
    }
}
