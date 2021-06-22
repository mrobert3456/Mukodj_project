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
using System.IO;
using System.Configuration;
using System.Windows.Forms.DataVisualization.Charting;


namespace Működj_projekt
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            mozgatas.WorkType = mozgatas.MoveOrResize.MoveAndResize;

        }
        Bitmap bitmap;
        public tabla objektumok; // rekord felvitelhez szükséges mezők
        public muveletek muv; // rekord műveletek
        public DataGridView tablak;
        public Button ujlap; // lap fülek
        public static DateTimePicker dtpic; // naptár
        public static TextBox txtbox; // szövegmező
        public static Chart diagramm; // diagramm
        public static TextBox text; // bevinni kivánt text
        public static tabla tb;  //adatbeviteli objektumokat tartalmazó usercontrol
        public static Label tbnev; //tábla neve
        public static Form tempChild; // aktualis gyerekablak
        Graphics vaszon;

        Form3 tablazat;
        public string ConnectionString = "";
        SqlCommand cmd = new SqlCommand();
        public static SqlConnection cnn;
        string sql = null;
        Form1 log;
      
       
        int mentettoldalakdb = 0;
    
        public int lapdb = 0; // lapok darabszáma
        public static int oszlopszam;  //egy tábla oszlopszáma
        int tabladb = 0;  //Táblák darabszáma
        int oldindex = 0;
        int top = 0; // tábla koordinátái
        int left = 0;//tábla koordinátái
        public static string[] oszloptipus; //egy tábla oszlopának adattipusa
        public static string[] oszlopnev;//egy tábla oszlopának neve
        public static int aktivf = 1;
        public int seged; //felhasználó által megnyomott gomb neve 
        public static string tablename = "";
        public static int oldalsz;
        public static int sorindex; //kiválasztott sor indexe
        int IDnev = 0; // sql tábla egyéni kulcsának a neve
        public static int kivsorID = 0; // kiválasztott sor ID-je
        public static string constring;
        public static bool betolt = false;
        public string adatbazisnev = "";
        static bool bezar = false;





        public void RekordTöröl()
        {

            //tempChild = (Form)this.MdiChildren[(aktivf - 1)];
            tbnev = new Label();
            tbnev = (Label)tempChild.Controls.Find("label" + tempChild.Name, false).FirstOrDefault();  //aktuális tábla nevének megkeresése

            using (SqlCommand command = new SqlCommand("DELETE FROM " + tbnev.Text + " WHERE ID= " + kivsorID, cnn))
            {
                command.ExecuteNonQuery();   // Rekord törlése
            }

            ListaFrissítés();

            tb = new tabla();
            tb = (tabla)tempChild.Controls.Find("obj" + tempChild.Name, false).FirstOrDefault();
            for (int i = 1; i <= oszlopszam; i++)
            {

                text = new TextBox();
                text = (TextBox)tb.Controls.Find("Textbox" + i, false).FirstOrDefault();   // lenulláza az adatfelviteli mezőket

                if (text == null)
                {
                    DateTimePicker date = new DateTimePicker();
                    date = (DateTimePicker)tb.Controls.Find("date" + i, false).FirstOrDefault();
                    date.Text = "";
                }
                else
                {

                    text.Text = "";

                }


            }

        }

        public void RekordSzerk()
        {
            try
            { /*tempChild = (Form)this.MdiChildren[(aktivf - 1)];*/


                SqlConnection mycon = new SqlConnection(constring);
                Label nev = new Label();
                nev = (Label)tempChild.Controls.Find("label" + tempChild.Name, false).FirstOrDefault();

                DataGridView dgv = new DataGridView();
                dgv = (DataGridView)tempChild.Controls.Find(nev.Text, false).FirstOrDefault();

                SqlCommand cmd = new SqlCommand("", mycon);
                cmd.CommandText = "UPDATE " + nev.Text + " SET ";


                for (int i = 0; i < (dgv.ColumnCount - 1); i++)
                {
                    cmd.CommandText += "[" + dgv.Columns[(i + 1)].HeaderText.ToString() + "] = @" + dgv.Columns[(i + 1)].HeaderText.ToString() + ",";
                }
                cmd.CommandText = cmd.CommandText.Substring(0, cmd.CommandText.Length - 1);
                cmd.CommandText += " WHERE ID=" + kivsorID;


                string[] adat = new string[100];
                tb = new tabla();
                tb = (tabla)tempChild.Controls.Find("obj" + tempChild.Name, false).FirstOrDefault();
                for (int i = 1; i <= oszlopszam; i++)
                {

                    text = new TextBox();
                    text = (TextBox)tb.Controls.Find("Textbox" + i, false).FirstOrDefault();
                    if (text == null)
                    {
                        DateTimePicker date = new DateTimePicker();
                        date = (DateTimePicker)tb.Controls.Find("date" + i, false).FirstOrDefault();
                        adat[i - 1] = date.Text;
                        date.Text = "";
                    }
                    else
                    {
                        adat[i - 1] = text.Text;
                        text.Text = "";

                    }

                }

                SqlCommand cm = new SqlCommand("SELECT* FROM " + nev.Text + "tip" + " ORDER BY ID ASC", cnn);

                SqlDataReader dr = cm.ExecuteReader();

                while (dr.Read())
                {

                    for (int i = 0; i < (dgv.ColumnCount - 1); i++)
                    {
                        if (dr[(i + 1)].ToString() == "INTEGER")
                        {

                            cmd.Parameters.Add("@" + dgv.Columns[(i + 1)].HeaderText, SqlDbType.Int).Value = adat[i];
                        }

                        else if (dr[(i + 1)].ToString() == "NVARCHAR(100)")
                        {
                            cmd.Parameters.Add("@" + dgv.Columns[(i + 1)].HeaderText, SqlDbType.NVarChar).Value = adat[i];

                        }
                        else if (dr[(i + 1)].ToString() == "SMALLDATETIME")
                        {
                            cmd.Parameters.Add("@" + dgv.Columns[(i + 1)].HeaderText, SqlDbType.SmallDateTime).Value = adat[i];

                        }
                        else if (dr[(i + 1)].ToString() == "NVARCHAR(100)")
                        {
                            cmd.Parameters.Add("@" + dgv.Columns[(i + 1)].HeaderText, SqlDbType.NVarChar).Value = adat[i];

                        }


                    }


                }
                dr.Close();
                cm.Cancel();




                mycon.Open();
                cmd.ExecuteNonQuery();
                ListaFrissítés();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Figyelmeztetés!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void RekordÚj()
        {
            try
            {
                //    tempChild = (Form)this.MdiChildren[(aktivf - 1)];

                Label nev = new Label();
                nev = (Label)tempChild.Controls.Find("label" + tempChild.Name, false).FirstOrDefault();
                tablename = nev.Text;

                oldalsz = int.Parse(label1.Text);
                string[] adat = new string[100];
                tb = new tabla();
                tb = (tabla)tempChild.Controls.Find("obj" + tempChild.Name, false).FirstOrDefault();
                for (int i = 1; i <= oszlopszam; i++)
                {

                    text = new TextBox();
                    text = (TextBox)tb.Controls.Find("Textbox" + i, false).FirstOrDefault();
                    if (text == null)
                    {
                        DateTimePicker date = new DateTimePicker();
                        date = (DateTimePicker)tb.Controls.Find("date" + i, false).FirstOrDefault();
                        adat[i - 1] = date.Text;
                    }
                    else
                    {
                        if (text.Text == "")
                        {
                            adat[101] = "asd";
                        }
                        else
                        {
                            adat[i - 1] = text.Text;
                            text.Text = "";
                        }
                    }
                    // MessageBox.Show(text.Name);


                }


                SqlCommand cm = new SqlCommand("SELECT* FROM " + nev.Text + "tip" + " ORDER BY ID ASC", cnn);

                DataGridView dgv = new DataGridView();
                dgv = (DataGridView)tempChild.Controls.Find(nev.Text, false).FirstOrDefault();

                SqlDataReader dr = cm.ExecuteReader();

                while (dr.Read())
                {
                    for (int i = 1; i < dgv.ColumnCount; i++)
                    {

                        //dgv.Rows[j].Cells[i].Value = dr[i].ToString();
                        oszloptipus[(i - 1)] = dr[i].ToString();
                        oszlopnev[(i - 1)] = dgv.Columns[i].HeaderText;

                    }


                }
                dr.Close();
                cm.Cancel();

                var cmd = cnn.CreateCommand();
                cmd.CommandText = "INSERT into " + tablename + "(";

                for (int i = 0; i < oszlopszam; i++)
                {
                    cmd.CommandText += oszlopnev[i] + ",";
                }
                cmd.CommandText = cmd.CommandText.Substring(0, cmd.CommandText.Length - 1);
                cmd.CommandText += ")";


                cmd.CommandText += " VALUES (";
                for (int i = 0; i < oszlopszam; i++)
                {
                    cmd.CommandText += "@" + oszlopnev[i] + ",";
                }
                cmd.CommandText = cmd.CommandText.Substring(0, cmd.CommandText.Length - 1);
                cmd.CommandText += ")";


                for (int i = 0; i < oszlopszam; i++)
                {
                    if (oszloptipus[i] == "INTEGER")
                    {

                        cmd.Parameters.Add("@" + oszlopnev[i], SqlDbType.Int).Value = adat[i];
                    }

                    else if (oszloptipus[i] == "NVARCHAR(100)")
                    {
                        cmd.Parameters.Add("@" + oszlopnev[i], SqlDbType.NVarChar).Value = adat[i];

                    }
                    else if (oszloptipus[i] == "SMALLDATETIME")
                    {
                        cmd.Parameters.Add("@" + oszlopnev[i], SqlDbType.SmallDateTime).Value = adat[i];

                    }
                    else if (oszloptipus[i] == "NVARCHAR(100)")
                    {
                        cmd.Parameters.Add("@" + oszlopnev[i], SqlDbType.NVarChar).Value = adat[i];

                    }

                }

                cmd.ExecuteNonQuery();
                ListaFrissítés();
            }
            catch (System.Data.ConstraintException)
            {
                MessageBox.Show("Ezzel az ID azonosítóval már szerepel egy dokumentum.", "Figyelmeztetés!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (System.Data.SqlClient.SqlException)
            {
                MessageBox.Show("Ezzel az ID azonosítóval már szerepel egy dokumentum.", "Figyelmeztetés!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Hibás kitöltés! Ellenőrizze a bevitt adatokat.", "Figyelmeztetés!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (NullReferenceException)
            {

                MessageBox.Show("Hibás kitöltés! Ellenőrizze a bevitt adatokat.", "Figyelmeztetés!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("Hibás kitöltés! Ellenőrizze a bevitt adatokat.", "Figyelmeztetés!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Figyelmeztetés!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        public void ListaFrissítés()
        {
            try
            {
                //tempChild = (Form)this.MdiChildren[(aktivf - 1)];
                Label nev = new Label();
                nev = (Label)tempChild.Controls.Find("label" + tempChild.Name, false).FirstOrDefault();

                DataGridView dgv = new DataGridView();
                dgv = (DataGridView)tempChild.Controls.Find(nev.Text, false).FirstOrDefault();
                dgv.Rows.Clear();



                SqlCommand cm = new SqlCommand("SELECT* FROM " + nev.Text + " ORDER BY ID ASC", cnn);

                SqlDataReader dr = cm.ExecuteReader();
                int j = 0;
                while (dr.Read())
                {
                    dgv.RowCount += 1;
                    for (int i = 0; i < dgv.ColumnCount; i++)
                    {

                        dgv.Rows[j].Cells[i].Value = dr[i].ToString();

                    }

                    j++;
                }
                dr.Close();
                cm.Cancel();
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Ilyen adatbázis nincs!", "Figyelmeztetés!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void ÚjTábla()
        {
            tablak = new DataGridView();
            mozgatas.Init(tablak);
            // tempChild = (Form)this.MdiChildren[(lapdb-1)];
            tablak.Location = new Point(323, 102);
            tempChild.Controls.Add(tablak);
            tbnev = new Label();
            tbnev.Text = tablename;
            tbnev.Name = "label" + tempChild.Name;
            tempChild.Controls.Add(tbnev);

            tablak.Name = tbnev.Text.ToString();
            tablak.MouseEnter += Tablak_MouseEnter;
            tablak.MouseLeave += Tablak_MouseLeave;
            tablak.CellClick += Tablak_CellClick;
            tablak.ContextMenuStrip = dgvmenu;
            tablak.AllowUserToAddRows = false;
            tablak.AllowUserToDeleteRows = false;
            tablak.AllowUserToOrderColumns = false;

            tablak.SelectionMode = DataGridViewSelectionMode.FullRowSelect;


        }

        private void Tablak_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                tempChild = (Form)this.MdiChildren[(aktivf - 1)];
                Label nev = new Label();
                nev = (Label)tempChild.Controls.Find("label" + tempChild.Name, false).FirstOrDefault();

                DataGridView dgv = new DataGridView();
                dgv = (DataGridView)tempChild.Controls.Find(nev.Text, false).FirstOrDefault();

                tabla obj = new tabla();
                obj = (tabla)tempChild.Controls.Find("obj" + (tempChild.Name), false).FirstOrDefault();



                muveletek muvelet = new muveletek(oszlopszam);
                muvelet = (muveletek)tempChild.Controls.Find("muv" + tempChild.Name, false).FirstOrDefault();

                sorindex = e.RowIndex;
                var kivalasztottsor = new DataGridViewRow();
                kivalasztottsor = dgv.Rows[sorindex];
                kivsorID = Convert.ToInt32(kivalasztottsor.Cells[0].Value);

                muvelet.Controls["btnujrek"].Enabled = false;
                muvelet.Controls["btnmod"].Enabled = true;
                muvelet.Controls["btntorol"].Enabled = true;
                for (int i = 1; i < dgv.ColumnCount; i++)
                {

                    text = new TextBox();
                    text = (TextBox)obj.Controls.Find("Textbox" + i, false).FirstOrDefault();
                    if (text == null)
                    {
                        DateTimePicker date = new DateTimePicker();
                        date = (DateTimePicker)tb.Controls.Find("date" + i, false).FirstOrDefault();
                        date.Text = kivalasztottsor.Cells[i].Value.ToString();
                    }
                    else
                    {

                        text.Text = kivalasztottsor.Cells[i].Value.ToString();
                    }

                }
            }
            catch
            {

            }

        }

        private void Táblákbet()
        {
            for (int i = 0; i < mentettoldalakdb; i++)
            {
                tempChild = (Form)this.MdiChildren[i];
                tbnev.Name = "label" + tempChild.Name;
                tablak.MouseEnter += Tablak_MouseEnter;
                tablak.MouseLeave += Tablak_MouseLeave;
                tablak.CellClick += Tablak_CellClick;
                tablak.BackgroundColor = DefaultBackColor;
                tablak.ContextMenuStrip = dgvmenu;
                tablak.AllowUserToAddRows = false;
                tablak.AllowUserToDeleteRows = false;
                tablak.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                tempChild.Controls.Add(tablak);
                tempChild.Controls.Add(tbnev);

            }
        }

        private void Oszlophozzáad()
        {

            tablak.Columns.Add("ID", "ID");
            for (int i = 0; i < oszlopszam; i++)
            {
                tablak.Columns.Add(tablazat.nev[i], tablazat.nev[i]);

            }

        }

        private void Táblákbetölt()
        {
            try
            {
                if (File.Exists(adatbazisnev + ".txt"))
                {
                    betolt = true;
                    StreamReader f = File.OpenText(adatbazisnev + ".txt");
                    tabladb = int.Parse(f.ReadLine());

                    while (!f.EndOfStream)
                    {
                        for (int k = 0; k < tabladb; k++)
                        {
                            mentettoldalakdb = int.Parse(f.ReadLine());
                            IDnev = tabladb;
                            tablename = f.ReadLine();
                            tbnev = new Label();
                            tbnev.Text = tablename;

                            ÚjLap();
                            tablak = new DataGridView();
                            mozgatas.Init(tablak);
                            muv = new muveletek(oszlopszam);
                            muv.Name = "muv" + (k + 1).ToString();
                            mozgatas.Init(muv);
                            objektumok = new tabla();
                            //tablaknyilv[k].oldal = k.ToString();
                            tempChild = (Form)this.MdiChildren[k];
                            tempChild.Text = tablename;
                            int gombindex = int.Parse(tempChild.Name);
                            flowLayoutPanel1.Controls[gombindex].Text = tablename;

                            oszlopszam = int.Parse(f.ReadLine());
                            oszloptipus = new string[oszlopszam];
                            oszlopnev = new string[oszlopszam];
                            top = int.Parse(f.ReadLine());
                            tablak.Top = top;
                            left = int.Parse(f.ReadLine());
                            tablak.Left = left;
                            tablak.Width = int.Parse(f.ReadLine());
                            tablak.Height = int.Parse(f.ReadLine());
                            tablak.Name = tablename;

                            Táblákbet();

                            tablak.Columns.Add("ID", "ID");

                            for (int i = 0; i < oszlopszam; i++)
                            {
                                string s = f.ReadLine();
                                oszlopnev[i] = s;
                                tablak.Columns.Add(s, s);
                            }

                            for (int j = 0; j < oszlopszam; j++)
                            {
                                string s = f.ReadLine();
                                oszloptipus[j] = s;

                            }

                            objektumok.Top = int.Parse(f.ReadLine());
                            objektumok.Left = int.Parse(f.ReadLine());
                            objektumok.Width = int.Parse(f.ReadLine());
                            objektumok.Height = int.Parse(f.ReadLine());
                            muv.Top = int.Parse(f.ReadLine());
                            muv.Left = int.Parse(f.ReadLine());
                            muv.Width = int.Parse(f.ReadLine());
                            muv.Height = int.Parse(f.ReadLine());



                            Adatbeviteliobjektumok();
                            tempChild.Controls.Add(muv);

                            objektumok.Name = "obj" + (k + 1).ToString();
                            ListaFrissítés();

                            Label nev = new Label();
                            nev = (Label)tempChild.Controls.Find("label" + tempChild.Name, false).FirstOrDefault();
                            Chart chart = new Chart();


                            if (f.ReadLine() == "Pie")
                            {
                                Újkördiagramm();
                                chart = (Chart)tempChild.Controls.Find("kor" + nev.Text, false).FirstOrDefault();
                                chart.Top = int.Parse(f.ReadLine());
                                chart.Left = int.Parse(f.ReadLine());
                                chart.Width = int.Parse(f.ReadLine());
                                chart.Height = int.Parse(f.ReadLine());
                            }
                            else if (f.ReadLine() == "Column")
                            {
                                Újoszlopdiagramm();
                                chart = (Chart)tempChild.Controls.Find("oszlop" + nev.Text, false).FirstOrDefault();
                                chart.Top = int.Parse(f.ReadLine());
                                chart.Left = int.Parse(f.ReadLine());
                                chart.Width = int.Parse(f.ReadLine());
                                chart.Height = int.Parse(f.ReadLine());
                            }



                        }

                    }


                    f.Close();
                }
            }
            catch
            {
                tabladb--;
                // MessageBox.Show(kiv.Message);
            }

        }

        private void Táblament()
        {
            StreamWriter f = File.CreateText(adatbazisnev + ".txt");
            try
            {

                f.WriteLine(tabladb.ToString());
                for (int l = 0; l < mentettoldalakdb; l++)
                {
                    tempChild = (Form)this.MdiChildren[l];

                    f.WriteLine(tempChild.Name.ToString()); //oldal száma

                    Label nev = new Label();
                    nev = (Label)tempChild.Controls.Find("label" + tempChild.Name, false).FirstOrDefault();
                    DataGridView dgv = new DataGridView();
                    dgv = (DataGridView)tempChild.Controls.Find(nev.Text, false).FirstOrDefault(); //egy tábla oszlopainak száma
                    f.WriteLine(dgv.Name);
                    f.WriteLine((dgv.ColumnCount - 1));
                    f.WriteLine(dgv.Top);// Tábla x koordinátája  
                    f.WriteLine(dgv.Left); //tábla y koordinátája
                    f.WriteLine(dgv.Width);//tábla szélessége    
                    f.WriteLine(dgv.Height); //tábla magassága

                    for (int j = 1; j < dgv.ColumnCount; j++)
                    {
                        f.WriteLine(dgv.Columns[j].HeaderText); //tábla oszlopainak a neve


                    }
                    SqlCommand cm = new SqlCommand("SELECT* FROM " + nev.Text + "tip ORDER BY ID ASC", cnn);

                    SqlDataReader dr = cm.ExecuteReader();

                    while (dr.Read())
                    {

                        for (int i = 1; i < dgv.ColumnCount; i++)
                        {

                            f.WriteLine(dr[i]);

                        }


                    }
                    dr.Close();
                    cm.Cancel();


                    tabla obj = new tabla();
                    obj = (tabla)tempChild.Controls.Find("obj" + (l + 1), false).FirstOrDefault();
                    f.WriteLine(obj.Top); //
                    f.WriteLine(obj.Left);//
                    f.WriteLine(obj.Width);///adatbeviteli mezők koordinátái illetve mérete
                    f.WriteLine(obj.Height);//

                    muveletek muvl = new muveletek(oszlopszam);
                    muvl = (muveletek)tempChild.Controls.Find("muv" + (l + 1), false).FirstOrDefault();
                    f.WriteLine(muvl.Top);  //
                    f.WriteLine(muvl.Left);//
                    f.WriteLine(muvl.Width);// funkció gombok koordinátái illetve mérete
                    f.WriteLine(muvl.Height);//


                    Chart chart = new Chart();
                    chart = (Chart)tempChild.Controls.Find("kor" + nev.Text, false).FirstOrDefault();
                    if (chart == null)
                    {
                        chart = (Chart)tempChild.Controls.Find("oszlop" + nev.Text, false).FirstOrDefault();
                    }
                    if (chart == null)
                    {

                    }
                    else
                    {
                        f.WriteLine(chart.Series[0].ChartType.ToString());
                        f.WriteLine(chart.Top);
                        f.WriteLine(chart.Left);
                        f.WriteLine(chart.Width);
                        f.WriteLine(chart.Height);
                    }
                    f.WriteLine(this.Width);
                    f.WriteLine(this.Height);


                }
                f.Close();

            }
            catch
            {
                //MessageBox.Show(kiv.Message);
                f.Close();
            }
        }

        private void Felhleírás()

        {
            try
            {
                var applicationWord = new Microsoft.Office.Interop.Word.Application();
                applicationWord.Visible = true;
                applicationWord.Documents.Open(@"C:\Users\Robi\Desktop\Működj projekt\Felhasználói leírás.docx");
            }
            catch
            {

            }
        }

        private void Újkördiagramm()

        {
            try
            {
                //tempChild = (Form)this.MdiChildren[(aktivf - 1)];
                Label nev = new Label();
                nev = (Label)tempChild.Controls.Find("label" + tempChild.Name, false).FirstOrDefault();

                DataGridView dgv = new DataGridView();
                dgv = (DataGridView)tempChild.Controls.Find(nev.Text, false).FirstOrDefault();

                diagramm = new Chart();
                diagramm.ChartAreas.Add("chartarea");
                diagramm.ContextMenuStrip = chartmenu;
                diagramm.Name = "kor" + nev.Text;

                DataTable dataTable = new DataTable();

                for (int i = 1; i < dgv.ColumnCount; i++)
                {
                    dataTable.Columns.Add(dgv.Columns[i].HeaderText);


                }

                for (int i = 0; i < dgv.RowCount; i++)
                {
                    var sor = dataTable.NewRow();
                    for (int j = 1; j < dgv.ColumnCount; j++)
                    {
                        sor[dgv.Columns[j].HeaderText] = dgv.Rows[i].Cells[j].Value;
                    }
                    dataTable.Rows.Add(sor);
                }


                diagramm.Legends.Add("l");
                diagramm.Series.Add(dgv.Columns[1].HeaderText);
                diagramm.Series[dgv.Columns[1].HeaderText].ChartType = SeriesChartType.Pie;
                // diagramm.Series[dgv.Columns[1].HeaderText].XValueMember = dgv.Columns[1].HeaderText;

                for (int i = 0; i < dgv.RowCount; i++)
                {
                    diagramm.Series[dgv.Columns[1].HeaderText].Points.AddY(dgv.Rows[i].Cells[2].Value);
                    diagramm.Series[dgv.Columns[1].HeaderText].Points[i].LegendText = dgv.Rows[i].Cells[1].Value.ToString();
                    diagramm.Series[dgv.Columns[1].HeaderText].Points[i].AxisLabel = dgv.Rows[i].Cells[2].Value.ToString();

                }
                diagramm.DataSource = dataTable;
                diagramm.DataBind();

                tempChild.Controls.Add(diagramm);
                mozgatas.Init(diagramm);



            }
            catch
            {

            }
        }

        private void Újoszlopdiagramm()
        {
            try
            {
                Label nev = new Label();
                nev = (Label)tempChild.Controls.Find("label" + tempChild.Name, false).FirstOrDefault();

                DataGridView dgv = new DataGridView();
                dgv = (DataGridView)tempChild.Controls.Find(nev.Text, false).FirstOrDefault();

                diagramm = new Chart();
                diagramm.ChartAreas.Add("chartarea");

                diagramm.Name = "oszlop" + nev.Text;
                diagramm.ContextMenuStrip = chartmenu;
                DataTable dataTable = new DataTable();


                for (int i = 1; i < dgv.ColumnCount; i++)
                {
                    dataTable.Columns.Add(dgv.Columns[i].HeaderText);


                }

                for (int i = 0; i < dgv.RowCount; i++)
                {
                    var sor = dataTable.NewRow();
                    for (int j = 1; j < dgv.ColumnCount; j++)
                    {
                        sor[dgv.Columns[j].HeaderText] = dgv.Rows[i].Cells[j].Value;
                    }
                    dataTable.Rows.Add(sor);
                }


                for (int i = 1; i < dgv.ColumnCount; i++)
                {
                    diagramm.Series.Add(dgv.Columns[i].HeaderText);
                    diagramm.Series[dgv.Columns[i].HeaderText].ChartType = SeriesChartType.Column;
                    for (int j = 0; j < dgv.RowCount; j++)
                    {

                        diagramm.Series[(i - 1)].Points.AddXY(dgv.Columns[i].HeaderText, dgv.Rows[j].Cells[i].Value);
                        //diagramm.Series[dgv.Columns[1].HeaderText].Points.AddY(Convert.ToDouble(dgv.Rows[j].Cells[i].Value));
                        diagramm.Series[(i - 1)].Points[j].AxisLabel = dgv.Rows[j].Cells[i].Value.ToString();
                    }
                    diagramm.Legends.Add(dgv.Columns[i].HeaderText);


                }
                diagramm.DataSource = dataTable;
                diagramm.DataBind();
                //diagramm.DataBindTable(dataTable.DefaultView, "");
                tempChild.Controls.Add(diagramm);
                mozgatas.Init(diagramm);
            }
            catch
            {

            }
        }

        private void TáblákSQLbe()
        {
            try
            {
                // Open the connection
                IDnev++;
                if (cnn.State == ConnectionState.Open)
                    cnn.Close();
                cnn.ConnectionString = ConnectionString;
                cnn.Open();

                sql = "CREATE TABLE " + tablename +
               "(ID INTEGER CONSTRAINT KeyID" + IDnev + " PRIMARY KEY IDENTITY(1,1),";
                for (int i = 0; i < oszlopszam; i++)
                {
                    sql += oszlopnev[i] + " " + oszloptipus[i] + ",";

                }
                sql = sql.Substring(0, sql.Length - 1);
                sql += ")";

                //oldalsz = oszlopszam;
                label1.Text = oszlopszam.ToString();
                cmd = new SqlCommand(sql, cnn);
                cmd.ExecuteNonQuery();


                sql = "CREATE TABLE " + tablename + "tip" + "(ID INTEGER, ";
                for (int i = 0; i < oszlopszam; i++)
                {
                    sql += oszlopnev[i] + " NVARCHAR(100), ";

                }
                sql = sql.Substring(0, sql.Length - 1);
                sql += ")";
                cmd = new SqlCommand(sql, cnn);
                cmd.ExecuteNonQuery();



                sql = "INSERT INTO " + tablename + "tip(ID,";
                for (int i = 0; i < oszlopszam; i++)
                {
                    sql += oszlopnev[i] + ",";

                }

                sql = sql.Substring(0, sql.Length - 1);
                sql += ") VALUES ( '1',";

                for (int i = 0; i < oszlopszam; i++)
                {
                    sql += "'" + oszloptipus[i] + "',";
                }
                sql = sql.Substring(0, sql.Length - 1);
                sql += ")";

                cmd = new SqlCommand(sql, cnn);
                cmd.ExecuteNonQuery();




            }
            catch
            {
                // MessageBox.Show(ae.Message.ToString());
                IDnev++;
                TáblákSQLbe();
            }
        }

        private void Adatbeviteliobjektumok()
        {
            // tempChild = (Form)this.MdiChildren[(aktivf - 1)];
            if (betolt == true)
            {

            }
            else
            {
                objektumok = new tabla();
            }

            objektumok.Name = "obj" + tabladb.ToString();
            objektumok.MouseEnter += Objektumok_MouseEnter;
            objektumok.MouseLeave += Objektumok_MouseLeave;
            objektumok.BackColor = DefaultBackColor;
            mozgatas.Init(objektumok);
            int kord = 5;
            int seg = oszlopnev[0].Length;
            for (int i = 1; i < oszlopnev.Length; i++)
            {
                if (oszlopnev[i].Length > seg)
                {
                    seg = oszlopnev[i].Length;
                }


            }
            for (int i = 0; i < oszlopszam; i++) //oszlopnevek.Length
            {
                if (oszloptipus[i] == "INTEGER")
                {
                    txtbox = new TextBox();
                    txtbox.Name = "Textbox" + (i + 1);

                    txtbox.Top = 15 + kord;
                    txtbox.Left = 40;

                    objektumok.Controls.Add(txtbox);
                    Label label = new Label();
                    label.Name += i;

                    label.Top = txtbox.Top;
                    label.Left = txtbox.Left - 30;
                    label.Text = oszlopnev[i] + ":";

                    objektumok.Controls.Add(label);

                    kord += 25;
                }

                else if (oszloptipus[i] == "NVARCHAR(100)")
                {
                    txtbox = new TextBox();
                    txtbox.Name = "Textbox" + (i + 1);

                    txtbox.Top = 15 + kord;
                    txtbox.Left = 40;

                    objektumok.Controls.Add(txtbox);
                    Label label = new Label();
                    label.Name += i;

                    label.Top = txtbox.Top;
                    label.Left = txtbox.Left - 30;
                    label.Text = oszlopnev[i] + ":";
                    // objektumok.panel1.Controls.Add(txtbox);
                    objektumok.Controls.Add(label);
                    //objektumok.panel1.Controls.Add(label);
                    kord += 25;
                }

                else if (oszloptipus[i] == "SMALLDATETIME")
                {
                    dtpic = new DateTimePicker();
                    dtpic.Name += "date" + (i + 1);
                    dtpic.Top = 15 + kord;
                    dtpic.Left = 40;


                    objektumok.Controls.Add(dtpic);
                    Label label = new Label();
                    label.Name += i;
                    label.Top = dtpic.Top;
                    label.Left = dtpic.Left - 30;
                    label.Text = oszlopnev[i] + ":";
                    kord += 25;
                    objektumok.Controls.Add(label);

                }

                else
                {
                    txtbox = new TextBox();
                    txtbox.Name += "Textbox" + (i + 1);

                    txtbox.Top = 15 + kord;
                    txtbox.Left = 40;

                    objektumok.Controls.Add(txtbox);
                    Label label = new Label();
                    label.Name += i;

                    label.Top = txtbox.Top;
                    label.Left = txtbox.Left - 30;
                    label.Text = oszlopnev[i] + ":";

                    objektumok.Controls.Add(label);
                    //objektumok.panel1.Controls.Add(label);
                    kord += 25;

                }
            }


            //objektumok.Top = 50;
            //objektumok.Left = 20;
            objektumok.Location = new Point(12, 100);
            tempChild.Controls.Add(objektumok);


        }

        private void Nyomtatás()
        {
            try
            {
                tempChild = (Form)this.MdiChildren[(aktivf - 1)];

                Label nev = new Label();
                nev = (Label)tempChild.Controls.Find("label" + tempChild.Name, false).FirstOrDefault();

                DataGridView dgv = new DataGridView();
                dgv = (DataGridView)tempChild.Controls.Find(nev.Text, false).FirstOrDefault();


                dgv.ClearSelection();
                int magass = dgv.Height;
                dgv.Height = (dgv.RowCount + 1) * dgv.RowTemplate.Height;
                dgv.ScrollBars = ScrollBars.None;
                bitmap = new Bitmap(dgv.Width, dgv.Height);
                dgv.DrawToBitmap(bitmap, new Rectangle(0, 0, dgv.Width, dgv.Height));
                dgv.Height = magass;
                dgv.ScrollBars = ScrollBars.Both;
                printPreviewDialog1.Document = printDocument1;
                printPreviewDialog1.PrintPreviewControl.Zoom = 1;
                printPreviewDialog1.ShowDialog();
            }
            catch (Exception kivetel)
            {
                MessageBox.Show(kivetel.Message, "Figyelmeztetés", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ÚjTáblalétrehozása()
        {
            try
            {
                //tempChild = (Form)this.MdiChildren[(aktivf - 1)];

                Label nev = new Label();
                nev = (Label)tempChild.Controls.Find("labeleldont" + tempChild.Name, false).FirstOrDefault();

                if (nev.Text == "Nincs")
                {
                    nev.Text = "van";
                    tabladb++;
                    muv = new muveletek(oszlopszam);
                    muv.Name = "muv" + tabladb.ToString();
                    mozgatas.Init(muv);


                    tablazat.ShowDialog();
                    oszlopszam = tablazat.oszlopsz;
                    tablazat.oszlopsz = 0;
                    oszloptipus = new string[oszlopszam];
                    oszlopnev = new string[oszlopszam];

                    tablename = tablazat.tablanev;

                    for (int i = 0; i < oszlopszam; i++)
                    {
                        if (tablazat.tipus[i] == "Egész szám")
                        {
                            oszloptipus[i] = "INTEGER";

                        }

                        else if (tablazat.tipus[i] == "Szöveg")
                        {
                            oszloptipus[i] = "NVARCHAR(100)";

                        }
                        else if (tablazat.tipus[i] == "Idő")
                        {
                            oszloptipus[i] = "SMALLDATETIME";

                        }
                        else if (tablazat.tipus[i] == "Szám és szöveg")
                        {
                            oszloptipus[i] = "NVARCHAR(100)";

                        }


                        oszlopnev[i] = tablazat.nev[i];

                    }
                    TáblákSQLbe();
                    ÚjTábla();
                    Oszlophozzáad();
                    Adatbeviteliobjektumok();
                    muv.Location = new Point(12, 357);
                    tempChild.Controls.Add(muv);
                    tempChild.Text = tablename;
                    int gombindex = int.Parse(tempChild.Name);
                    flowLayoutPanel1.Controls[gombindex].Text = tablename;
                    for (int i = 0; i < oszlopszam; i++)
                    {
                        tablazat.nev[i] = null;
                        tablazat.tipus[i] = null;
                    }

                    mentettoldalakdb++;

                }
                else
                {

                }
            }
            catch
            {
                tempChild.Controls.Clear();
            }
        }

        private void Táblamegnyitás()
        {
            try
            {
                string x = Microsoft.VisualBasic.Interaction.InputBox("Tábla neve", "Megnyitás");
                if (x == null)
                { }
                else
                {

                    //tablak = new DataGridView();


                    SqlCommand cm = new SqlCommand("SELECT* FROM " + x + " ORDER BY ID ASC", cnn);
                    tablename = x;
                    ÚjTábla();

                    int gombindex = int.Parse(tempChild.Name);
                    flowLayoutPanel1.Controls[gombindex].Text = tablename;

                    DataGridView dgv = new DataGridView();
                    dgv = (DataGridView)tempChild.Controls.Find(x, false).FirstOrDefault();


                    SqlDataReader dr = cm.ExecuteReader();
                    dgv.ColumnCount = dr.FieldCount;

                    int j = 0;
                    while (dr.Read())
                    {
                        dgv.RowCount += 1;
                        for (int i = 0; i < dr.FieldCount; i++)
                        {

                            dgv.Rows[j].Cells[i].Value = dr[i].ToString();


                        }

                        j++;
                    }
                    //oszlopok elnevezése
                    oszlopnev = new string[(dr.FieldCount - 1)];
                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        dgv.Columns[i].HeaderText = dr.GetName(i);



                    }
                    for (int i = 1; i < dr.FieldCount; i++)
                    {

                        oszlopnev[(i - 1)] = dr.GetName(i);

                    }

                    oszloptipus = new string[(dr.FieldCount - 1)];
                    oszlopszam = (dr.FieldCount - 1);

                    dr.Close();
                    cm.Cancel();

                    SqlCommand cmm = new SqlCommand("SELECT* FROM " + x + "tip ORDER BY ID ASC", cnn);

                    SqlDataReader drr = cmm.ExecuteReader();

                    while (drr.Read())
                    {

                        for (int i = 1; i < dgv.ColumnCount; i++)
                        {

                            oszloptipus[(i - 1)] = drr[i].ToString();

                        }


                    }
                    drr.Close();
                    cmm.Cancel();

                    tabladb++;
                    muv = new muveletek(oszlopszam);
                    muv.Name = "muv" + tabladb.ToString();
                    mozgatas.Init(muv);
                    muv.MouseEnter += Muv_MouseEnter;
                    muv.MouseLeave += Muv_MouseLeave;
                    muv.BackColor = DefaultBackColor;
                    tempChild.Controls.Add(muv);
                    Adatbeviteliobjektumok();

                    mentettoldalakdb++;



                }

            }
            catch
            {
                tempChild.Controls.Clear();
            }
        }

        private void ÚjLap()
        {
            if (lapdb == 10)
            {

            }
            else
            {


                lapdb++;

                ujlap = new Button();


                this.flowLayoutPanel1.Controls.Add(ujlap);
                ujlap.Text = lapdb.ToString() + ". ablak";
                ujlap.Name = lapdb.ToString();


                ujlap.Click += new EventHandler(ujlap_Clicked);


                ujablak ujablakk = new ujablak();
                ujablakk.MdiParent = this;
                ujablakk.Show();
                ujablakk.Top = 25;


                Label label = new Label();
                label.Name = "labeleldont" + lapdb;
                if (betolt == true)
                {
                    label.Text = "VaN";
                }
                else
                {
                    label.Text = "Nincs";
                }
                label.Visible = false;



                ujablakk.Name = lapdb.ToString();
                seged = lapdb;
                ujablakk.Location = new Point(3, 20);
                ujablakk.FormClosed += new FormClosedEventHandler(ujablakkk_Closed);
                ujablakk.Click += new EventHandler(ujablakkk_Click);
                ujablakk.MaximizeBox = false;
                ujablakk.MinimizeBox = false;
                ujablakk.Move += Ujablakk_Move;

                ujablakk.Width = this.Width - 30;
                ujablakk.Height = this.Height - 30;

                tempChild = (Form)this.MdiChildren[(lapdb - 1)];
                tempChild.Controls.Add(label);

                ujablakk.Text = lapdb + ". ablak ";
                //   oldalak[lapdb] = oldindex;

                oldindex++;

                ////oldalak rendezése
                //for (int i = 1; i <= lapdb; i++)
                //{
                //    if (oldalak[i] == 0)
                //    {
                //        int seg = oldalak[i + 1];
                //        oldalak[i] = seg;
                //        oldalak[i + 1] = 0;
                //    }

                //}
            }
        }

        private void Ujablakk_Move(object sender, EventArgs e)
        {
            try
            {
                tempChild = (Form)this.MdiChildren[(aktivf - 1)];
                tempChild.Location = new Point(3, 20);
            }
            catch
            {

            }
        }

        private void Objektumok_MouseLeave(object sender, EventArgs e)
        {
            tabla ob = (sender as tabla);
            ob.Focus();
            ob.BackColor = DefaultBackColor;
        }

        private void Objektumok_MouseEnter(object sender, EventArgs e)
        {
            tabla ob = (sender as tabla);
            ob.Focus();
            ob.BackColor = Color.LightGray;
        }


        private void Tablak_MouseLeave(object sender, EventArgs e)
        {
            DataGridView dataGrid = (sender as DataGridView);
            dataGrid.Focus();
            dataGrid.BackgroundColor = DefaultBackColor;
        }

        private void Tablak_MouseEnter(object sender, EventArgs e)
        {
            DataGridView dataGrid = (sender as DataGridView);
            dataGrid.Focus();
            dataGrid.BackgroundColor = Color.LightGray;
        }


        private void Form2_Load(object sender, EventArgs e)
        {

            this.ControlBox = false;
            tablazat = new Form3();
            vaszon = this.CreateGraphics();
            log = new Form1();
            cnn = new SqlConnection(ConnectionString);
            constring = ConnectionString;

            try
            {
                cnn.Open();
                MessageBox.Show("Sikeres csatlakozás!", "Csatlakozva", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Táblákbetölt();
                betolt = false;
                ÚjLap();



            }
            catch (System.Data.SqlClient.SqlException)
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Figyelem!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void méretezésToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void Muv_MouseEnter(object sender, EventArgs e)
        {
            muveletek muveletek = (sender as muveletek);
            muveletek.Focus();
            muveletek.BackColor = Color.LightGray;

        }

        private void Muv_MouseLeave(object sender, EventArgs e)
        {
            muveletek muveletek = (sender as muveletek);
            muveletek.Focus();
            muveletek.BackColor = DefaultBackColor;
        }

        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ÚjTáblalétrehozása();

        }



        private void Form2_Click(object sender, EventArgs e)
        {
            this.objektumok.vaszon.Clear(Color.LightGray);
        }

        private void btnuj_Click(object sender, EventArgs e)
        {
            ÚjLap();
        }

        private void ujablakkk_Click(object sender, EventArgs e)
        {
            try
            {

                Label nev = new Label();
                nev = (Label)tempChild.Controls.Find("label" + tempChild.Name, false).FirstOrDefault();

                DataGridView dgv = new DataGridView();
                dgv = (DataGridView)tempChild.Controls.Find(nev.Text, false).FirstOrDefault();

                dgv.ClearSelection();
                muveletek muvelet = new muveletek(oszlopszam);
                muvelet = (muveletek)tempChild.Controls.Find("muv" + tempChild.Name, false).FirstOrDefault();

                seged = int.Parse((sender as Form).Name);
                muvelet.Controls["btnujrek"].Enabled = true;
                muvelet.Controls["btnmod"].Enabled = false;
                muvelet.Controls["btntorol"].Enabled = false;

            }
            catch
            {

            }
        }

        private void ujablakkk_Closed(object sender, EventArgs e)
        {
            try
            {
                if (bezar == false)
                {
                    if (lapdb == 1)
                    {
                        flowLayoutPanel1.Controls.RemoveAt(1);
                        lapdb--;
                        oldindex--;
                        ÚjLap();

                    }
                    else
                    {
                        for (int i = 0; i < this.MdiChildren.Length; i++)
                        {
                            Form tempChild = (Form)this.MdiChildren[i];
                            if (int.Parse(tempChild.Name) == seged)
                            {
                                lapdb--;
                                oldindex--;
                                flowLayoutPanel1.Controls.RemoveAt(i + 1);

                            }
                        }
                    }


                }
                else
                {

                }
            }
            catch
            {

            }


        }

        private void ujlap_Clicked(object sender, EventArgs e)
        {
            try
            {
                seged = int.Parse((sender as Button).Name);
                Form aktivform = Form.ActiveForm;

                for (int i = 0; i < this.MdiChildren.Length; i++)
                {
                    Form tempChild = (Form)this.MdiChildren[i];
                    if (int.Parse(tempChild.Name) == seged)
                    {
                        tempChild.Visible = true;
                        tempChild.Location = new Point(3, 20);
                        tempChild.Width = this.Width - 30;
                        tempChild.Height = this.Height - 30;
                        aktivf = seged;

                    }
                    else
                    {
                        tempChild.Visible = false;
                        tempChild.Location = new Point(3, 20);
                    }

                }
                tempChild = (Form)this.MdiChildren[(aktivf - 1)];

            }
            catch
            {

            }

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {


            Táblament();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bezar = true;
            Application.Exit();
        }

        private void flowLayoutPanel1_ControlAdded(object sender, ControlEventArgs e)
        {

        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Nyomtatás();

        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            ÚjTáblalétrehozása();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            Táblament();
        }

        private void törlésToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                tempChild = (Form)this.MdiChildren[seged - 1];
                Label nev = new Label();
                nev = (Label)tempChild.Controls.Find("label" + tempChild.Name, false).FirstOrDefault();

                Label nevt = new Label();
                nevt = (Label)tempChild.Controls.Find("labeleldont" + tempChild.Name, false).FirstOrDefault();
                nevt.Text = "Nincs";

                tabladb--;

                SqlCommand sqlCommand = new SqlCommand("DROP TABLE " + nev.Text, cnn);
                sqlCommand.ExecuteNonQuery();
                sqlCommand.Cancel();

                sqlCommand = new SqlCommand("DROP TABLE " + nev.Text + "tip", cnn);
                sqlCommand.ExecuteNonQuery();
                sqlCommand.Cancel();

                tempChild.Controls.Clear();

            }
            catch
            {
                tempChild.Controls.Clear();
            }


        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Nyomtatás();
        }

        private void Form2_ResizeEnd(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < MdiChildren.Length; i++)
                {
                    tempChild = (Form)this.MdiChildren[i];
                    tempChild.Width = this.Width - 30;
                    tempChild.Height = this.Height - 30;
                }
            }
            catch
            { }
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bitmap, 0, 0);
        }

        private void printToolStripButton_Click(object sender, EventArgs e)
        {
            Nyomtatás();
        }

        private void Form2_ResizeBegin(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {

                tempChild = (Form)this.MdiChildren[(aktivf - 1)];
                Label nev = new Label();
                nev = (Label)tempChild.Controls.Find("label" + tempChild.Name, false).FirstOrDefault();

                DataGridView dgv = new DataGridView();
                dgv = (DataGridView)tempChild.Controls.Find(nev.Text, false).FirstOrDefault();

                dgv.ClearSelection();
                string x;
                x = Microsoft.VisualBasic.Interaction.InputBox("Írja be a keresendő szöveget!", "Keresés a táblázatban");
                int db = 0;

                for (int i = 0; i < dgv.ColumnCount; i++)
                {
                    for (int j = 0; j < dgv.RowCount; j++)
                    {
                        if (dgv.Rows[j].Cells[i].Value.ToString() == x)
                        {
                            dgv.Rows[j].Selected = true;

                        }
                        else
                        {
                            db++;
                        }
                    }


                }

                if (db == (dgv.ColumnCount * dgv.RowCount))
                {
                    MessageBox.Show("Ilyen adat nincs!", "Keresés", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Ilyen adatbázis nincs!", "Figyelmeztetés!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

        }

        private void kördiagrammToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Újkördiagramm();
        }

        private void oszlopdiagrammToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Újoszlopdiagramm();
        }

        private void törölToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                tempChild = (Form)this.MdiChildren[(aktivf - 1)];
                Label nev = new Label();
                nev = (Label)tempChild.Controls.Find("label" + tempChild.Name, false).FirstOrDefault();

                Chart chart = new Chart();
                chart = (Chart)tempChild.Controls.Find("kor" + nev.Text, false).FirstOrDefault();
                if (chart == null)
                {
                    chart = (Chart)tempChild.Controls.Find("oszlop" + nev.Text, false).FirstOrDefault();
                }

                tempChild.Controls.Remove(chart);
            }
            catch
            {

            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Táblamegnyitás();

        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            Táblamegnyitás();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void újCsatlakozásToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            log.ShowDialog();
            this.Close();

        }

        private void dgvmenu_Opening(object sender, CancelEventArgs e)
        {

        }

        private void helpToolStripButton_Click(object sender, EventArgs e)
        {
            Felhleírás();

        }

        private void contentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Felhleírás();
        }
    }
}
