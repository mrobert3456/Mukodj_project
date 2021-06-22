using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Működj_projekt
{
    public partial class muveletek : UserControl
    {
        public muveletek(int b)
        {
            InitializeComponent();
           
            ((Form)form2).Controls["label1"].Text = b.ToString();

        }
        Form2 form2 = new Form2();
        private void btnujrek_Click(object sender, EventArgs e)
        {
            
            form2.RekordÚj();
        }

        private void btntorol_Click(object sender, EventArgs e)
        {
            form2.RekordTöröl();
        }

        private void btnmod_Click(object sender, EventArgs e)
        {
            form2.RekordSzerk();
        }

        private void btnfriss_Click(object sender, EventArgs e)
        {
            form2.ListaFrissítés();
        }
    }
}
