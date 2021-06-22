using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Működj_projekt
{
    public partial class tabla : UserControl
    {
        public tabla()
        {
            InitializeComponent();
          
        }

        private static tabla _instance;
        public Graphics vaszon;
        

        public static tabla Instance
        {
              get
            {
                if (_instance == null)
                    _instance = new tabla();
                return _instance;

                  
            }
        }

        private void tabla_Load(object sender, EventArgs e)
        {
            
        }

        private void tabla_Click(object sender, EventArgs e)
        {
            
        }
    }
}
