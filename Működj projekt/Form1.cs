using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.IO;

namespace Működj_projekt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public string constring = "";
        string felhaszn;
        string jelszo;
        string szervernev;
       public  string adatbnev;
      public    string szerver, user, pw, nev;
        public Form2 form;
        int panelnumber;
        SqlConnection kapcs;
        public int oszlopsz = 0;

        private void adatokment()
        {
            FileStream fs = File.Create("adatok.txt");
            TripleDESCryptoServiceProvider tc = new TripleDESCryptoServiceProvider();
            CryptoStream cs = new CryptoStream(fs, tc.CreateEncryptor(), CryptoStreamMode.Write);
            StreamWriter sw = new StreamWriter(cs);
            sw.WriteLine(servername.Text);
            sw.WriteLine(txtadatbnev.Text);
            sw.WriteLine(username.Text);
            sw.WriteLine(password.Text);
            if (SqlLog.Checked == true)
            {
                sw.WriteLine("2");
            }
            else
            {
                sw.WriteLine("1");
            }

            sw.Flush();
            sw.Close();
            FileStream fsKey = File.Create("key.txt");
            BinaryWriter bw = new BinaryWriter(fsKey);
            bw.Write(tc.Key);
            bw.Write(tc.IV);
            bw.Flush();
            bw.Close();

        }      

        private void ExecuteSQLStmt(string sql)
        {
            SqlCommand cmd;
            SqlConnection conn = new SqlConnection(constring);
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            conn.ConnectionString = constring;
            conn.Open();
            cmd = new SqlCommand(sql, conn);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ae)
            {
                MessageBox.Show(ae.Message.ToString());
            }
        }

        private void Ujadatbazis()
        {
            try
            {
                SqlConnection conn;
                szerver = txtujserver.Text;
                user = txtujuser.Text;
                pw = txtujpw.Text;
                nev = txtujdb.Text;
             
                if (WinLog.Checked == true || ujwinlog.Checked == true)
                {
                    constring = @"Data Source=" + szerver + ";Initial Catalog = master;Integrated Security = True";
                }
                else if (SqlLog.Checked == true || ujsqllog.Checked == true)
                {

                    constring = @"Server=" + szerver + ";Database=master;User Id=" + user + ";password=" + pw;
                }

                conn = new SqlConnection(constring);

                if (conn.State != ConnectionState.Open)
                    conn.Open();
                string path = txtpath.Text;
                string sql = "CREATE DATABASE " + nev + " ON PRIMARY"
                + @"(Name=" + nev + @"_data, filename = '" + path + nev + "_data.mdf', size=5120kb,"
                + "maxsize=5, filegrowth=10%)log on"
                + @"(name=" + nev + @"_log, filename='" + path + nev + "_log.ldf',size=512kb,"
                + "maxsize=20,filegrowth=10%)";
                ExecuteSQLStmt(sql);

                SqlLog.Checked = true;
                WinLog.Checked = false;
                adatbnev = nev;
                username.Text = user;
                password.Text = pw;

                Csatlakozas();
            }
            catch (System.Data.SqlClient.SqlException)
            {
                MessageBox.Show("Hiányzó adatok", "Figyelmeztetés!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            catch (System.InvalidOperationException)
            {
                MessageBox.Show("Hiányzó adatok", "Figyelmeztetés!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Figyelmeztetés!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Csatlakozas()
        {
            try
            {
                if (WinLog.Checked == true || ujwinlog.Checked == true)
                {
                    constring = @"Data Source=" + szervernev + ";Initial Catalog = " + adatbnev + "; Integrated Security = True";
                    kapcs = new SqlConnection(constring);
                    kapcs.Open();
                    kapcs.Close();
                    adatokment();

                    form.ConnectionString = constring;
                    form.adatbazisnev = adatbnev;
                    this.Hide();
                    form.ShowDialog();
                    this.Close();
                }
                else if (SqlLog.Checked == true || ujsqllog.Checked == true)
                {
                    if (username.Text == "" || password.Text == "")
                    {
                        MessageBox.Show("Hiányzó adatok", "Figyelmeztetés!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {

                        felhaszn = username.Text;
                        jelszo = password.Text;
                        constring = @"Server=" + szervernev + ";Database=" + adatbnev + ";User Id=" + felhaszn + ";password=" + jelszo;
                        kapcs = new SqlConnection(constring);
                        kapcs.Open();
                        kapcs.Close();
                        adatokment();
                        form.adatbazisnev = adatbnev;
                        form.ConnectionString = constring;
                        this.Hide();
                        form.ShowDialog();
                        this.Close();
                    }
                }

                else
                {
                    MessageBox.Show("Válassz egy bejelentkezési módot!", "Figyelmeztetés!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }


            }
            catch (System.InvalidOperationException)
            {
                MessageBox.Show("Érvénytelen adatok", "Figyelmeztetés", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (System.Data.SqlClient.SqlException)
            {
                MessageBox.Show("Érvénytelen adatok", "Figyelmeztetés", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Figyelmeztetés!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void btnok_Click(object sender, EventArgs e)
        {
            try
            {


                switch (panelnumber)
                {
                    case 1:
                        szervernev = servername.Text;
                        adatbnev = txtadatbnev.Text; Csatlakozas(); break;
                    case 3: adatbnev = txtujdb.Text; szervernev = txtujserver.Text; felhaszn = txtujuser.Text; jelszo = txtujpw.Text; Ujadatbazis(); break;
                }

            }

            catch (InvalidOperationException)
            {
                MessageBox.Show("Ilyen adatbázis nem létezik!", "Figyelmeztetés", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void vissza2_Click(object sender, EventArgs e)
        {
            this.Text = "Kapcsolódás";
            panelnumber = 2;

            panel1.Visible = false;
            panel2.Visible = true;
            panel3.Visible = false;
            btnok.Enabled = false;
        }

        private void btnmegse_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void csat_Click_1(object sender, EventArgs e)
        {
            this.Text = "Kapcsolódás meglévő adatbázishoz";
            panelnumber = 1;

            panel1.Visible = true;
            panel2.Visible = false;
            btnok.Enabled = true;

            if (File.Exists("adatok.txt"))
            {

                try
                {
                    FileStream fsFile = File.OpenRead("adatok.txt");
                    FileStream fsKey = File.OpenRead("key.txt");
                    FileStream fsSave = File.Create("adatok2.txt");
                    TripleDESCryptoServiceProvider csAlgo = new TripleDESCryptoServiceProvider();
                    BinaryReader br = new BinaryReader(fsKey);
                    csAlgo.Key = br.ReadBytes(24);
                    csAlgo.IV = br.ReadBytes(8);
                    CryptoStream cs = new CryptoStream(fsFile, csAlgo.CreateDecryptor(), CryptoStreamMode.Read);
                    StreamReader srCleanStream = new StreamReader(cs);
                    StreamWriter swCleanStream = new StreamWriter(fsSave);
                    swCleanStream.Write(srCleanStream.ReadToEnd());
                    swCleanStream.Close();
                    fsSave.Close();
                    srCleanStream.Close();
                    StreamReader f = File.OpenText("adatok2.txt");
                    while (!f.EndOfStream)
                    {
                        servername.Text = f.ReadLine();
                        txtadatbnev.Text = f.ReadLine();
                        username.Text = f.ReadLine();
                        password.Text = f.ReadLine();
                        if (f.ReadLine() == "2")
                        {
                            SqlLog.Checked = true;
                        }
                        else
                        {
                            WinLog.Checked = true;
                        }

                    }

                    f.Close();
                    File.Delete("adatok2.txt");
                    fsKey.Close();

                }
                catch
                {

                }

            }
        }

        private void uj_Click(object sender, EventArgs e)
        {
            this.Text = "Új adatbázis";
            panelnumber = 3;

            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = true;
            btnok.Enabled = true;
        }

        private void vissza_Click(object sender, EventArgs e)
        {
            this.Text = "Kapcsolódás";
            panelnumber = 2;

            panel1.Visible = false;
            panel2.Visible = true;
            panel3.Visible = false;
            btnok.Enabled = false;
        }

        private void WinLog_CheckedChanged(object sender, EventArgs e)
        {
            if (WinLog.Checked == true)
            {
                username.Enabled = false;
                password.Enabled = false;
            }
            else
            {
                username.Enabled = true;
                password.Enabled = true;
            }
        }

        private void SqlLog_CheckedChanged(object sender, EventArgs e)
        {
            if (SqlLog.Checked == true)
            {
                username.Enabled = true;
                password.Enabled = true;
            }
            else
            {
                username.Enabled = false;
                password.Enabled = false;
            }
        }

        private void helpToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                var applicationWord = new Microsoft.Office.Interop.Word.Application();
                applicationWord.Visible = true;
                applicationWord.Documents.Open(@"D:\Működj projekt\Felhasználói leírás.docx");
            }
            catch
            {

            }

        }

        private void ujwinlog_CheckedChanged(object sender, EventArgs e)
        {
            if (ujwinlog.Checked == true)
            {
                txtujpw.Enabled = false;
                txtujuser.Enabled = false;
                label6.Enabled = false;
                label7.Enabled = false;
            }
            else
            {
                txtujpw.Enabled = true;
                txtujuser.Enabled = true;
                label6.Enabled = true;
                label7.Enabled = true;
            }
        }

        private void ujsqllog_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panelnumber = 2;
            form = new Form2();
            this.BackColor = Color.White;

            panel1.BackColor = Color.White;
            panel1.Visible = false;

            panel2.BackColor = Color.White;
            panel2.Visible = true;

            panel3.BackColor = Color.White;
            panel3.Visible = false;

            btnok.Enabled = false;

            label8.BackColor = System.Drawing.Color.Transparent;
        }
    }
}
