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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
           
        }


     public int oszlopsz = 0;
        Form2 form = new Form2();
        int i = -1;
       public int tabladb=0;

   
       public string[] nev;
       public string[] tipus;
       public string  tablanev;
        private void Btnok_Click(object sender, EventArgs e)
        {
       
          oszlopsz = int.Parse(textBox2.Text);
          tablanev = textBox1.Text;
          tabladb++;
         
            panel1.Visible = false;
            panel2.Visible = true;
            nev = new string[oszlopsz];
            tipus = new string[oszlopsz];
            textBox1.Text = "";
            textBox2.Text = "";
           
           //form.oszlopok = new rekord[oszlopszam];

        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
            textBox3.Text = "";
            comboBox1.Text = "";
            this.Hide();
            
            
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel1.Visible = true;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            i++;
            if (i == (oszlopsz - 1))
            {
                button1.Enabled = false;
                button2.Enabled = true;
                button4.Enabled = true;
              
                nev[i] = textBox3.Text;
                tipus[i] = comboBox1.SelectedItem.ToString();
            }
            else
            {
               
                nev[i] = textBox3.Text;
                tipus[i] = comboBox1.SelectedItem.ToString();
            
               
                label4.Text = (i +2)+ ". oszlop";
                textBox3.Text = "";
                comboBox1.Text = "";
                button4.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            i--;

            if (i== -1)
            {
                button2.Enabled = false;
                button1.Enabled = true;
                i = 0;
            }
            else
            {
               
                textBox3.Text = nev[i];
                comboBox1.Text = tipus[i];
                label4.Text = (i +1)+ ". oszlop";
                button4.Enabled = false;
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            i = -1;
            panel1.Visible = true; //tovább
            panel2.Visible = false;
            label4.Text = "1. oszlop";
            button4.Enabled = false; //létrehoz gomb
            button2.Enabled = false; //vissza
            button3.Enabled = true;
            button1.Enabled = true;
            comboBox1.Text = "";
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }
    }
}
