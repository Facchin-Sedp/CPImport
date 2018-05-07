namespace CPImport
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.lblIDCampagna = new System.Windows.Forms.Label();
            this.grpIdCamp = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAttivaCamp = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnDelCampag = new MaterialSkin.Controls.MaterialRaisedButton();
            this.txtSearch = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.btnCerca = new MaterialSkin.Controls.MaterialFlatButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtFormatoCsv = new MaterialSkin.Controls.MaterialLabel();
            this.btnCopia = new MaterialSkin.Controls.MaterialRaisedButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.txtVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtServer = new System.Windows.Forms.ToolStripStatusLabel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.lblWaitSearch = new MaterialSkin.Controls.MaterialLabel();
            this.lblCampagna = new MaterialSkin.Controls.MaterialLabel();
            this.lblFile = new MaterialSkin.Controls.MaterialLabel();
            this.lblWait = new MaterialSkin.Controls.MaterialLabel();
            this.btnImport = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnExit = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnOpen = new MaterialSkin.Controls.MaterialRaisedButton();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.grpIdCamp.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "*.csv";
            this.openFileDialog1.Filter = "contatti|csv";
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Courier New", 8.064F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.ItemHeight = 17;
            this.listBox1.Location = new System.Drawing.Point(18, 426);
            this.listBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(597, 174);
            this.listBox1.TabIndex = 4;
            // 
            // lblIDCampagna
            // 
            this.lblIDCampagna.AutoSize = true;
            this.lblIDCampagna.Font = new System.Drawing.Font("Segoe UI", 16.128F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIDCampagna.Location = new System.Drawing.Point(39, 36);
            this.lblIDCampagna.Name = "lblIDCampagna";
            this.lblIDCampagna.Size = new System.Drawing.Size(47, 40);
            this.lblIDCampagna.TabIndex = 9;
            this.lblIDCampagna.Text = "ID";
            // 
            // grpIdCamp
            // 
            this.grpIdCamp.Controls.Add(this.lblIDCampagna);
            this.grpIdCamp.Location = new System.Drawing.Point(489, 75);
            this.grpIdCamp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpIdCamp.Name = "grpIdCamp";
            this.grpIdCamp.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpIdCamp.Size = new System.Drawing.Size(126, 111);
            this.grpIdCamp.TabIndex = 11;
            this.grpIdCamp.TabStop = false;
            this.grpIdCamp.Text = "ID Campagna";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAttivaCamp);
            this.groupBox1.Controls.Add(this.btnDelCampag);
            this.groupBox1.Controls.Add(this.txtSearch);
            this.groupBox1.Controls.Add(this.btnCerca);
            this.groupBox1.Location = new System.Drawing.Point(12, 75);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(469, 111);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Campagna";
            // 
            // btnAttivaCamp
            // 
            this.btnAttivaCamp.Depth = 0;
            this.btnAttivaCamp.Location = new System.Drawing.Point(256, 74);
            this.btnAttivaCamp.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAttivaCamp.Name = "btnAttivaCamp";
            this.btnAttivaCamp.Primary = true;
            this.btnAttivaCamp.Size = new System.Drawing.Size(205, 23);
            this.btnAttivaCamp.TabIndex = 22;
            this.btnAttivaCamp.Text = "Imposta come Attiva";
            this.btnAttivaCamp.UseVisualStyleBackColor = true;
            this.btnAttivaCamp.Click += new System.EventHandler(this.btnAttivaCamp_Click);
            // 
            // btnDelCampag
            // 
            this.btnDelCampag.Depth = 0;
            this.btnDelCampag.Location = new System.Drawing.Point(6, 74);
            this.btnDelCampag.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnDelCampag.Name = "btnDelCampag";
            this.btnDelCampag.Primary = true;
            this.btnDelCampag.Size = new System.Drawing.Size(183, 23);
            this.btnDelCampag.TabIndex = 21;
            this.btnDelCampag.Text = "Elimina Campagna";
            this.btnDelCampag.UseVisualStyleBackColor = true;
            this.btnDelCampag.Click += new System.EventHandler(this.btnDelCampag_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Depth = 0;
            this.txtSearch.Hint = "Nome Campagna...";
            this.txtSearch.Location = new System.Drawing.Point(6, 30);
            this.txtSearch.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PasswordChar = '\0';
            this.txtSearch.SelectedText = "";
            this.txtSearch.SelectionLength = 0;
            this.txtSearch.SelectionStart = 0;
            this.txtSearch.Size = new System.Drawing.Size(361, 28);
            this.txtSearch.TabIndex = 20;
            this.txtSearch.UseSystemPasswordChar = false;
            // 
            // btnCerca
            // 
            this.btnCerca.AutoSize = true;
            this.btnCerca.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCerca.Depth = 0;
            this.btnCerca.Location = new System.Drawing.Point(382, 22);
            this.btnCerca.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnCerca.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCerca.Name = "btnCerca";
            this.btnCerca.Primary = false;
            this.btnCerca.Size = new System.Drawing.Size(70, 36);
            this.btnCerca.TabIndex = 20;
            this.btnCerca.Text = "Cerca";
            this.btnCerca.UseVisualStyleBackColor = true;
            this.btnCerca.Click += new System.EventHandler(this.btnCerca_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtFormatoCsv);
            this.groupBox2.Controls.Add(this.btnCopia);
            this.groupBox2.Location = new System.Drawing.Point(12, 218);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(603, 114);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Formato CSV";
            // 
            // txtFormatoCsv
            // 
            this.txtFormatoCsv.AutoSize = true;
            this.txtFormatoCsv.Depth = 0;
            this.txtFormatoCsv.Font = new System.Drawing.Font("Roboto", 11F);
            this.txtFormatoCsv.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtFormatoCsv.Location = new System.Drawing.Point(4, 38);
            this.txtFormatoCsv.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtFormatoCsv.Name = "txtFormatoCsv";
            this.txtFormatoCsv.Size = new System.Drawing.Size(700, 25);
            this.txtFormatoCsv.TabIndex = 16;
            this.txtFormatoCsv.Text = "RIFTER;RIFPRA;NOME;PRIORITA\';NUMTELEFONI;TELEFONO1;TELEFONO2;.......";
            // 
            // btnCopia
            // 
            this.btnCopia.Depth = 0;
            this.btnCopia.Location = new System.Drawing.Point(436, 66);
            this.btnCopia.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCopia.Name = "btnCopia";
            this.btnCopia.Primary = true;
            this.btnCopia.Size = new System.Drawing.Size(161, 43);
            this.btnCopia.TabIndex = 14;
            this.btnCopia.Text = "Copia Formato";
            this.btnCopia.UseVisualStyleBackColor = true;
            this.btnCopia.Click += new System.EventHandler(this.btnCopia_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.Transparent;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(21, 21);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.txtVersion,
            this.txtServer});
            this.statusStrip1.Location = new System.Drawing.Point(0, 686);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(624, 26);
            this.statusStrip1.TabIndex = 15;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // txtVersion
            // 
            this.txtVersion.Name = "txtVersion";
            this.txtVersion.Size = new System.Drawing.Size(69, 21);
            this.txtVersion.Text = "versione";
            // 
            // txtServer
            // 
            this.txtServer.BackColor = System.Drawing.Color.Transparent;
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(55, 21);
            this.txtServer.Text = "Server";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(18, 606);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(214, 24);
            this.checkBox1.TabIndex = 16;
            this.checkBox1.Text = "Ignora la riga delle colonne";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // lblWaitSearch
            // 
            this.lblWaitSearch.AutoSize = true;
            this.lblWaitSearch.Depth = 0;
            this.lblWaitSearch.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblWaitSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblWaitSearch.Location = new System.Drawing.Point(263, 188);
            this.lblWaitSearch.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblWaitSearch.Name = "lblWaitSearch";
            this.lblWaitSearch.Size = new System.Drawing.Size(116, 25);
            this.lblWaitSearch.TabIndex = 20;
            this.lblWaitSearch.Text = "Attendere...";
            // 
            // lblCampagna
            // 
            this.lblCampagna.AutoSize = true;
            this.lblCampagna.Depth = 0;
            this.lblCampagna.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblCampagna.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblCampagna.Location = new System.Drawing.Point(236, 399);
            this.lblCampagna.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblCampagna.Name = "lblCampagna";
            this.lblCampagna.Size = new System.Drawing.Size(165, 25);
            this.lblCampagna.TabIndex = 21;
            this.lblCampagna.Text = "nome Campagna";
            // 
            // lblFile
            // 
            this.lblFile.AutoSize = true;
            this.lblFile.Depth = 0;
            this.lblFile.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblFile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblFile.Location = new System.Drawing.Point(13, 378);
            this.lblFile.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(40, 25);
            this.lblFile.TabIndex = 22;
            this.lblFile.Text = "file";
            // 
            // lblWait
            // 
            this.lblWait.AutoSize = true;
            this.lblWait.Depth = 0;
            this.lblWait.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblWait.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblWait.Location = new System.Drawing.Point(275, 495);
            this.lblWait.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblWait.Name = "lblWait";
            this.lblWait.Size = new System.Drawing.Size(116, 25);
            this.lblWait.TabIndex = 24;
            this.lblWait.Text = "Attendere...";
            // 
            // btnImport
            // 
            this.btnImport.Depth = 0;
            this.btnImport.Location = new System.Drawing.Point(411, 622);
            this.btnImport.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnImport.Name = "btnImport";
            this.btnImport.Primary = true;
            this.btnImport.Size = new System.Drawing.Size(114, 32);
            this.btnImport.TabIndex = 25;
            this.btnImport.Text = "Importa";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnExit
            // 
            this.btnExit.Depth = 0;
            this.btnExit.Location = new System.Drawing.Point(540, 622);
            this.btnExit.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnExit.Name = "btnExit";
            this.btnExit.Primary = true;
            this.btnExit.Size = new System.Drawing.Size(75, 31);
            this.btnExit.TabIndex = 26;
            this.btnExit.Text = "Esci";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Depth = 0;
            this.btnOpen.Location = new System.Drawing.Point(18, 352);
            this.btnOpen.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Primary = true;
            this.btnOpen.Size = new System.Drawing.Size(107, 23);
            this.btnOpen.TabIndex = 27;
            this.btnOpen.Text = "Apri CSV...";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(18, 659);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(597, 15);
            this.progressBar1.TabIndex = 28;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(624, 712);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.lblWait);
            this.Controls.Add(this.lblFile);
            this.Controls.Add(this.lblCampagna);
            this.Controls.Add(this.lblWaitSearch);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpIdCamp);
            this.Controls.Add(this.listBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.064F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Contact Provider Import";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grpIdCamp.ResumeLayout(false);
            this.grpIdCamp.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label lblIDCampagna;
        private System.Windows.Forms.GroupBox grpIdCamp;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel txtServer;
        private System.Windows.Forms.CheckBox checkBox1;
        private MaterialSkin.Controls.MaterialFlatButton btnCerca;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtSearch;
        private MaterialSkin.Controls.MaterialLabel lblWaitSearch;
        private MaterialSkin.Controls.MaterialLabel lblCampagna;
        private MaterialSkin.Controls.MaterialLabel lblFile;
        private MaterialSkin.Controls.MaterialLabel lblWait;
        private MaterialSkin.Controls.MaterialRaisedButton btnDelCampag;
        private MaterialSkin.Controls.MaterialRaisedButton btnCopia;
        private MaterialSkin.Controls.MaterialRaisedButton btnImport;
        private MaterialSkin.Controls.MaterialRaisedButton btnExit;
        private MaterialSkin.Controls.MaterialRaisedButton btnOpen;
        private MaterialSkin.Controls.MaterialLabel txtFormatoCsv;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ToolStripStatusLabel txtVersion;
        private MaterialSkin.Controls.MaterialRaisedButton btnAttivaCamp;
    }
}

