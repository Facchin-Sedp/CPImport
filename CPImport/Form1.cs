using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using MySql.Data;
using System.Windows.Forms;
using MySql.Data.Common;
using MySql.Data.MySqlClient;
using System.IO;
using MaterialSkin.Controls;
using MaterialSkin;
using System.Reflection;
using System.Diagnostics;

namespace CPImport
{
    public partial class Form1 : MaterialForm
    {
        public String CString= Properties.Settings.Default.CString;
     
        public String Id_Campagna = String.Empty;
        public String Campagna = String.Empty;
        public String CompleteFileName = String.Empty;
        public Boolean riga_Colonne = false;
        //                <value>Server=168.100.100.5;Database=csfil;Uid=csfil;Pwd=S1.fa</value>


        public Form1()
        {
            InitializeComponent();

            var skinManager = MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            set_Color_Scheme(skinManager);

            // SERVER
            String Server = CString.Split(';')[0];
            txtServer.Text = Server.Replace("=",":");
            ////

            lblFile.Text = "";
            grpIdCamp.Visible = true;
            lblIDCampagna.Visible = false;
            lblCampagna.Visible = false;
            lblWait.Visible = false;
            lblWaitSearch.Visible = false;
            btnDelCampag.Visible = false;
            btnAttivaCamp.Visible = false;
            checkBox1.Checked = true;

            // versione del file dall'assembly
            Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fvi.FileVersion;
            txtVersion.Text = "Versione: " + version;
            /////

        }
        public void set_Color_Scheme(MaterialSkinManager skinManager)
        {
            Random rnd = new Random();
            int th = rnd.Next(1, 6); // creates a number between 1 and 12

            switch (th)
            {
                case 1:
                    {
                        skinManager.ColorScheme = new ColorScheme(Primary.Blue700, Primary.BlueGrey300,
                            Primary.Red500, Accent.Blue200, TextShade.WHITE);
                        break;
                    }
                case 2:
                    {
                        skinManager.ColorScheme = new ColorScheme(Primary.Cyan500, Primary.Cyan700,
                            Primary.Cyan500, Accent.Cyan200, TextShade.WHITE);
                        break;
                    }
                    
                case 3:
                    {
                        skinManager.ColorScheme = new ColorScheme(Primary.LightGreen800, Primary.LightGreen900,
                            Primary.LightGreen500, Accent.LightGreen200, TextShade.WHITE);
                        break;
                    }
                   
                case 4:
                    {
                        skinManager.ColorScheme = new ColorScheme(Primary.Teal600, Primary.Teal700,
                            Primary.Teal400, Accent.Teal400, TextShade.WHITE);
                        break;
                    }
                    
                case 5:
                    {

                        skinManager.ColorScheme = new ColorScheme(Primary.LightBlue600, Primary.LightBlue700,
                            Primary.LightBlue300, Accent.LightBlue200, TextShade.WHITE);
                        break;
                    }
                default:
                    break;
                    
            }










        }

        protected override CreateParams CreateParams
        {
            get
            {
                const int CS_DROPSHADOW = 0x39000;
                var cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

        private String Get_Campagna()
        {
            String nomeCampagna = String.Empty;

            MySqlConnection cn = new MySqlConnection(CString);
            MySqlCommand command = new MySqlCommand();
            cn.Open();
            command.Connection = cn;

            string query = "SELECT cpg_id,cpg_campag FROM cpcamp where cpg_campag = 'Kruk_OUT'";
            try
            {

                command.CommandText = query;

                MySqlDataReader rd = command.ExecuteReader();

                rd.Read();
                Id_Campagna = rd.GetValue(0).ToString();
                nomeCampagna = Id_Campagna + " - " + rd.GetValue(1).ToString();

                cn.Close();
                return nomeCampagna;
            }
            catch (Exception e)
            {

                if (cn.State ==  ConnectionState.Open)
                    cn.Close();
                return "Errore: " + e.Message;
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            DialogResult d = openFileDialog1.ShowDialog();
            if (d == DialogResult.OK)
            {
                CompleteFileName = this.openFileDialog1.FileName;
                lblFile.Text = Path.GetFileName(CompleteFileName);
                this.Text +=" <-- "+ Path.GetFileName(CompleteFileName);

            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (Id_Campagna != String.Empty &&  CompleteFileName != String.Empty)                 
            {
                read_CSV();
            }
            else
            {
                MessageBox.Show("Cercare o Creare la Campagna ed aprire un File CSV","Errore",MessageBoxButtons.OK,MessageBoxIcon.Error);


            }
        }
        private void btnCerca_Click(object sender, EventArgs e)
        {

            Application.DoEvents();
            lblWaitSearch.Visible = true;
            Application.DoEvents();
            Boolean trovata= Cerca_Campagna();
            Application.DoEvents();
            lblWaitSearch.Visible = false;
            Application.DoEvents();


            DialogResult res;
            if (trovata)
            {
                this.Text = "Campagna: " + Campagna + ", ID: "  +Id_Campagna;
                lblIDCampagna.Text = Id_Campagna;
                lblIDCampagna.Visible = true;
                btnDelCampag.Visible = true;
                btnAttivaCamp.Visible = true;
                btnDelCampag.Text = "Elimina " + Campagna;
                lblCampagna.Visible = true;
                lblCampagna.Text = Campagna;


                Application.DoEvents();

                res = MessageBox.Show("Ho trovato la campagna '"+Campagna.ToUpper()+"'.\n vuoi cancellare tutti i suoi contatti associati?"
                     , "Campagna", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {

                    Delete_Contatti_Campagna();

                }
            }
            else
            {


                res = MessageBox.Show("Nessun Risultato.\n vuoi Creare la campagna '"+Campagna.ToUpper()+"' ?"
                                        , "Campagna", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {

                    Create_Campagna();

                }



            }

        }

        private void Create_Campagna()
        {
            String res = String.Empty;
            MySqlConnection cn = new MySqlConnection(CString);
            MySqlCommand command = new MySqlCommand();
            cn.Open();
            command.Connection = cn;

            Campagna = txtSearch.Text;

            string query = @"INSERT INTO cpcamp (cpg_campag,cpg_descri,cpg_type,cpg_maxcal,cpg_calitv,cpg_status)
                                VALUES(@CPG_CAMPAG,@CPG_DESCRI,@CPG_TYPE,@CPG_MAXCAL,@CPG_CALITV,@CPG_STATUS)";
            try
            {
                command.CommandText = query;
                command.Parameters.Add("@CPG_CAMPAG", MySqlDbType.VarChar).Value = Campagna;
                command.Parameters.Add("@CPG_DESCRI", MySqlDbType.VarChar).Value = Campagna;
                command.Parameters.Add("@CPG_TYPE", MySqlDbType.VarChar).Value = "I";
                command.Parameters.Add("@CPG_MAXCAL", MySqlDbType.Int32).Value = 1;
                command.Parameters.Add("@CPG_CALITV", MySqlDbType.Int32).Value = 1;
                command.Parameters.Add("@CPG_STATUS", MySqlDbType.Int32).Value = 0;
                command.ExecuteNonQuery();

                query = @"select max(cpg_id) from cpcamp";
                command.CommandText = query;
                Int64 maxId= (Int64)command.ExecuteScalar();
                Id_Campagna = maxId.ToString();

                Application.DoEvents();

                this.Text = "Campagna: " + Campagna + ", ID: " + Id_Campagna;
                lblIDCampagna.Text = Id_Campagna;
                lblIDCampagna.Visible = true;
                btnDelCampag.Visible = true;
                btnAttivaCamp.Visible = true;
                btnDelCampag.Text = "Elimina " + Campagna;
                lblCampagna.Visible = true;
                lblCampagna.Text = Campagna;
                cn.Close();



            }
            catch (Exception e)
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close();
                MessageBox.Show("Errore: " + e.Message + "\n" + e.InnerException, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Delete_Contatti_Campagna()
        {
            String res = String.Empty;
            MySqlConnection cn = new MySqlConnection(CString);
            MySqlCommand command = new MySqlCommand();
            cn.Open();
            command.Connection = cn;
            String nomeCampagna = txtSearch.Text;

            string query_phones = @"
                        delete ph
                        from cpanagra an,cpcamp cp,cpphones  ph
                        where
                        cpa_cpgid=cpg_id
                        and
                        cpp_cpaid=cpa_id
                        and cpg_id="+Id_Campagna;

            string query_cpcall = @"delete ca from cpcalls ca,cpanagra an,cpcamp cp where cpa_id=cpl_cpaid and cpg_id= " + Id_Campagna;

            string query_anagra = @"delete cpa from cpanagra cpa LEFT JOIN cpcamp on  cpa_cpgid=cpg_id where cpg_id=" + Id_Campagna;
            try
            {
                command.CommandText = query_cpcall;
                command.ExecuteNonQuery();

                command.CommandText = query_phones;
                command.ExecuteNonQuery();

                command.CommandText = query_anagra;
                command.ExecuteNonQuery();

                cn.Close();

                MessageBox.Show("Contatti Cancellati!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception e)
            {

                if (cn.State == ConnectionState.Open)
                    cn.Close();
                MessageBox.Show("Errore: " + e.Message + "\n" + e.InnerException, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 
            }
        }

        private bool Cerca_Campagna()
        {
            String res = String.Empty;
            MySqlConnection cn = new MySqlConnection(CString);
            MySqlCommand command = new MySqlCommand();
            cn.Open();
            command.Connection = cn;
            String nomeCampagna = txtSearch.Text;

            string query = @"SELECT cpg_id,cpg_campag from cpcamp where cpg_campag='"+nomeCampagna+"' ";
            try
            {
                command.CommandText = query;
                MySqlDataReader rd = command.ExecuteReader();

                if (rd.HasRows)
                {
                    rd.Read();

                    Id_Campagna = rd.GetValue(0).ToString();
                    Campagna = rd.GetValue(1).ToString();
                    cn.Close();
                    return true;
                }
                else
                    return false;

                
            }
            catch(Exception e) {

                if (cn.State == ConnectionState.Open)
                    cn.Close();
                MessageBox.Show("Errore: " + e.Message + "\n" + e.InnerException, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }



            }

        private void read_CSV()
        {

            Application.DoEvents();
            lblWait.Visible = true;
            Application.DoEvents();


            List <Row_CpAnagra> ls_Anag = new List<Row_CpAnagra> { };
            List<Row_CpPhones> ls_Phones = new List<Row_CpPhones> { };

            listBox1.Items.Clear();


            StreamReader sr = new StreamReader(CompleteFileName);
            int count = 0;
            String l = String.Empty;
            
            var file=sr.ReadToEnd(); // big string
            var lines = file.Split(new char[] { '\n' });           // big array
            int lineCount = lines.Count();


            
            progressBar1.Maximum = lineCount-1;
            progressBar1.Minimum = 0;
            progressBar1.Value = 0;

            sr.Close();

            sr = new StreamReader(CompleteFileName);

            while (!sr.EndOfStream)
            {
              
                if(riga_Colonne && count==0)
                sr.ReadLine();

                l=sr.ReadLine();
                List<String> line_split = l.Split(';').ToList();


                if (line_split[0].Trim() != String.Empty)
                {
                    count++;
                    Row_CpAnagra r_anag = new Row_CpAnagra {

                        cpa_cpgid = Id_Campagna,
                        cpa_rifter = line_split[0],
                        cpa_rifpra = line_split[1],
                        cpa_nome = line_split[2].Trim(),
                        cpa_numpty = line_split[3],
                        cpa_numpho = line_split[4]

                    };
                    String cpa_id = insert_Anagrafica(r_anag);

                    // per tutti i teleono che partono dalla colonna 6
                    int cnt = 0;
                    String res = String.Empty;
                    for (int i = 5; i < line_split.Count; i++)
                    {
                        if (line_split[i] != string.Empty)
                        {
                            String tel = line_split[i].Replace(" ",string.Empty);

                            cnt++;
                            Row_CpPhones ph= new Row_CpPhones
                            {

                                cpp_cpaid = cpa_id,
                                cpp_numpho=cnt.ToString(),
                                cpp_phonum=tel,
                                cpp_calsts="1",
                                cpp_censts="0",
                                cpp_calcnt="0"

                            };


                            res+=insert_Phones(ph); 
                        }
                    }


                    if (res != String.Empty) MessageBox.Show(res);



                    #region CONTROLLO
                    String comp = String.Empty;
                    foreach (String campi in line_split)
                    {

                        comp += campi + "\t";



                    }
                    listBox1.Items.Add(comp);
                   
                    Application.DoEvents();
                    #endregion


                }

                progressBar1.Value++;
            }

            sr.Close();
            progressBar1.Value = progressBar1.Maximum;
            MessageBox.Show("Importazione terminata!\nSono stati caricati " 
                + listBox1.Items.Count.ToString() + " Contatti");

            Application.DoEvents();
            lblWait.Visible = false;
            // resetto gli elementi
            Campagna = String.Empty;
            Id_Campagna = String.Empty;
            lblIDCampagna.Visible = false;
            txtSearch.Text = String.Empty;
            lblCampagna.Visible = false;
            lblCampagna.Text = "Nome Campagna";
            btnDelCampag.Visible = false;
            btnAttivaCamp.Visible = false;
            ///
            Application.DoEvents();

            
        }

        private string insert_Phones(Row_CpPhones ph)
        {
            String res = String.Empty;
            MySqlConnection cn = new MySqlConnection(CString);
            MySqlCommand command = new MySqlCommand();
            cn.Open();
            command.Connection = cn;

            string query = @"insert into cpphones(cpp_cpaid,cpp_numpho,cpp_phonum,cpp_calsts,cpp_censts,cpp_calcnt) 
                             VALUES(@CPP_CPAID,@CPP_NUMPHO,@CPP_PHONUM,@CPP_CALSTS,@CPP_CENSTS,@CPP_CALCNT)
                            ";
            try
            {

                command.CommandText = query;
                command.Parameters.Add("@CPP_CPAID", MySqlDbType.Int64).Value = ph.cpp_cpaid;
                command.Parameters.Add("@CPP_NUMPHO", MySqlDbType.VarChar).Value = ph.cpp_numpho;
                command.Parameters.Add("@CPP_PHONUM", MySqlDbType.VarChar).Value = ph.cpp_phonum;           
                command.Parameters.Add("@CPP_CALSTS", MySqlDbType.Int32).Value = 1;
                command.Parameters.Add("@CPP_CENSTS", MySqlDbType.Int32).Value = 0;
                command.Parameters.Add("@CPP_CALCNT", MySqlDbType.Int32).Value = 0;
 

                command.ExecuteNonQuery(); 


                cn.Close();


                return String.Empty;

            }
            catch (Exception e)
            {

                if (cn.State == ConnectionState.Open)
                    cn.Close();
                return "Errore: " + e.Message + "\n" + e.InnerException;
            }


        }

        private string insert_Anagrafica(Row_CpAnagra r_anag)
        {

            MySqlConnection cn = new MySqlConnection(CString);
            MySqlCommand command = new MySqlCommand();
            cn.Open();
            command.Connection = cn;

            string query = @"insert into cpanagra(cpa_cpgid,cpa_rifter,cpa_rifpra,cpa_nome,cpa_numpty,cpa_calsts,cpa_calcnt,cpa_numpho,cpa_curpho) 
                                               VALUES(@CPA_CPGID,@CPA_RIFTER,@CPA_RIFPRA,@CPA_NOME,@CPA_NUMPTY,@CPA_CALSTS,@CPA_CALCNT,@CPA_NUMPHO,@CPA_CURPHO)
";
            try
            {

                command.CommandText = query;
                command.Parameters.Add("@CPA_CPGID", MySqlDbType.Int64).Value = r_anag.cpa_cpgid;
                command.Parameters.Add("@CPA_RIFTER", MySqlDbType.VarChar).Value = r_anag.cpa_rifter;
                command.Parameters.Add("@CPA_RIFPRA", MySqlDbType.VarChar).Value = r_anag.cpa_rifpra;
                command.Parameters.Add("@CPA_NOME", MySqlDbType.VarChar).Value = r_anag.cpa_nome;
                command.Parameters.Add("@CPA_NUMPTY", MySqlDbType.Int32).Value = r_anag.cpa_numpty;
                command.Parameters.Add("@CPA_CALSTS", MySqlDbType.Int32).Value = 1;
                command.Parameters.Add("@CPA_CALCNT", MySqlDbType.Int32).Value = 0;
                command.Parameters.Add("@CPA_NUMPHO", MySqlDbType.Int32).Value = r_anag.cpa_numpho;
                command.Parameters.Add("@CPA_CURPHO", MySqlDbType.Int32).Value = 0;


                command.ExecuteNonQuery();

                // estraggo il max id ovvero l'ultimo inserito
                query = "select max(cpa_id) from cpanagra  ";
                command.CommandText = query;

                Int64 res = (Int64)command.ExecuteScalar();




                cn.Close();


                return res.ToString();
            }
            catch (Exception e)
            {

                if (cn.State == ConnectionState.Open)
                    cn.Close();

                MessageBox.Show("Errore: " + e.Message + "\n" + e.InnerException, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "Errore: " + e.Message + "\n" + e.InnerException;
            }

            
        }

        private void btnCopia_Click(object sender, EventArgs e)
        {
            Clipboard.Clear();
            Clipboard.SetText(txtFormatoCsv.Text);
            MessageBox.Show("Formato Copiato nella ClipBoard", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                riga_Colonne = true;
            else
                riga_Colonne = false;
        } 

        private void Delete_Campagna()
        {
            String res = String.Empty;
            MySqlConnection cn = new MySqlConnection(CString);
            MySqlCommand command = new MySqlCommand();
            cn.Open();
            command.Connection = cn;
            String nomeCampagna = txtSearch.Text;

            string query = @"
                        delete  
                        from cpcamp 
                        where 
                        cpg_id=" + Id_Campagna;


            
            try
            {
                command.CommandText = query;
                command.ExecuteNonQuery();

                cn.Close();
                btnDelCampag.Visible = false;
                btnAttivaCamp.Visible = false;
                btnDelCampag.Text = "Elimina ";

                // resetto gli elementi
                Campagna = String.Empty;
                Id_Campagna = String.Empty;
                lblIDCampagna.Visible = false;
                lblCampagna.Visible = false;
                lblCampagna.Text = "Nome Campagna";
                btnDelCampag.Visible = false;
                btnAttivaCamp.Visible = false;
                ///

                MessageBox.Show("Campagna Cancellata!", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {

                if (cn.State == ConnectionState.Open)
                    cn.Close();
                MessageBox.Show("Errore: " + e.Message + "\n" + e.InnerException, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void Attiva_Campagna()
        {
            String res = String.Empty;
            MySqlConnection cn = new MySqlConnection(CString);
            MySqlCommand command = new MySqlCommand();
            cn.Open();
            command.Connection = cn;
            String nomeCampagna = txtSearch.Text;

            string query = @"
                        update  
                          cpcamp
                        set cpg_Status=1
                        where 
                        cpg_id=" + Id_Campagna;



            try
            {
                command.CommandText = query;
                command.ExecuteNonQuery();

                cn.Close();
               

                MessageBox.Show("Campagna Attivata sul Database!", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {

                if (cn.State == ConnectionState.Open)
                    cn.Close();
                MessageBox.Show("Errore: " + e.Message + "\n" + e.InnerException, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnDelCampag_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Vuoi cancellare la Campagna '"+Campagna.ToUpper()+"' e tutti i suoi contatti associati?"
            , "Eliminazione Campagna", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {

                Delete_Contatti_Campagna();
                Delete_Campagna();

            }
        }

        private void btnAttivaCamp_Click(object sender, EventArgs e)
        {
            Attiva_Campagna();

        }
    }

    public class Row_CpAnagra
    {
        public String cpa_cpgid;
        public String cpa_rifter;
        public String cpa_rifpra;
        public String cpa_nome;
        public String cpa_numpty;
        public String cpa_calsts;
        public String cpa_calcnt;
        public String cpa_numpho;
        public String cpa_curpho;

    }
    public class Row_CpPhones
    {
        public String cpp_cpaid;
        public String cpp_numpho;
        public String cpp_phonum;
        public String cpp_calsts;
        public String cpp_censts;
        public String cpp_calcnt;

    }
}
