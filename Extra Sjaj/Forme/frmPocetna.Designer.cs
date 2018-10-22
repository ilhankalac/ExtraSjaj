namespace ExtraSjaj
{
    partial class frmPocetna
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPocetna));
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btnMusterije = new System.Windows.Forms.Button();
            this.btnBrisiMusteriju = new System.Windows.Forms.Button();
            this.btnUpdateMusterija = new System.Windows.Forms.Button();
            this.musterijasBindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this._TepisiBaza_2018DataSet1 = new ExtraSjaj._TepisiBaza_2018DataSet1();
            this.musterijasTableAdapter1 = new ExtraSjaj._TepisiBaza_2018DataSet1TableAdapters.MusterijasTableAdapter();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.closeButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.btnStatistikaFirme = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnRacuni = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.musterijasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.musterijasBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.musterijasBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.listaRacuna = new System.Windows.Forms.ListView();
            this.button6 = new System.Windows.Forms.Button();
            this.cmbBrojaRacuna = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.dodavanjeTepihaControl1 = new ExtraSjaj.Forme.DodavanjeTepihaControl();
            this.btnHomePage = new ExtraSjaj.Forme.ArhivaMusterijaControl();
            this.dodavanjeMusterijeControl1 = new ExtraSjaj.Forme.DodavanjeMusterijeControl();
            ((System.ComponentModel.ISupportInitialize)(this.musterijasBindingSource3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._TepisiBaza_2018DataSet1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.musterijasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.musterijasBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.musterijasBindingSource2)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(927, 27);
            this.listBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(156, 20);
            this.listBox1.TabIndex = 1;
            // 
            // btnMusterije
            // 
            this.btnMusterije.FlatAppearance.BorderSize = 0;
            this.btnMusterije.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMusterije.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMusterije.ForeColor = System.Drawing.Color.White;
            this.btnMusterije.Image = ((System.Drawing.Image)(resources.GetObject("btnMusterije.Image")));
            this.btnMusterije.Location = new System.Drawing.Point(1, 1);
            this.btnMusterije.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnMusterije.Name = "btnMusterije";
            this.btnMusterije.Size = new System.Drawing.Size(178, 119);
            this.btnMusterije.TabIndex = 4;
            this.btnMusterije.Text = "Mušterije";
            this.btnMusterije.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMusterije.UseVisualStyleBackColor = true;
            this.btnMusterije.Click += new System.EventHandler(this.prikaziOpcijeSaMusterijama);
            // 
            // btnBrisiMusteriju
            // 
            this.btnBrisiMusteriju.Location = new System.Drawing.Point(0, 0);
            this.btnBrisiMusteriju.Name = "btnBrisiMusteriju";
            this.btnBrisiMusteriju.Size = new System.Drawing.Size(75, 23);
            this.btnBrisiMusteriju.TabIndex = 8;
            // 
            // btnUpdateMusterija
            // 
            this.btnUpdateMusterija.Location = new System.Drawing.Point(0, 0);
            this.btnUpdateMusterija.Name = "btnUpdateMusterija";
            this.btnUpdateMusterija.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateMusterija.TabIndex = 9;
            // 
            // musterijasBindingSource3
            // 
            this.musterijasBindingSource3.DataMember = "Musterijas";
            this.musterijasBindingSource3.DataSource = this._TepisiBaza_2018DataSet1;
            // 
            // _TepisiBaza_2018DataSet1
            // 
            this._TepisiBaza_2018DataSet1.DataSetName = "_TepisiBaza_2018DataSet1";
            this._TepisiBaza_2018DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // musterijasTableAdapter1
            // 
            this.musterijasTableAdapter1.ClearBeforeFill = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1070, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 25);
            this.label1.TabIndex = 18;
            this.label1.Text = "label1";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.panel1.Controls.Add(this.closeButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1243, 48);
            this.panel1.TabIndex = 19;
            // 
            // closeButton
            // 
            this.closeButton.FlatAppearance.BorderSize = 0;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeButton.Image = ((System.Drawing.Image)(resources.GetObject("closeButton.Image")));
            this.closeButton.Location = new System.Drawing.Point(1109, 0);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(103, 49);
            this.closeButton.TabIndex = 3;
            this.closeButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeForm);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.btnStatistikaFirme);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 48);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1243, 73);
            this.panel2.TabIndex = 20;
            // 
            // button3
            // 
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(278, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(214, 63);
            this.button3.TabIndex = 3;
            this.button3.Text = "Prikaži mušterije ovog mjeseca";
            this.button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.homePageButton);
            // 
            // btnStatistikaFirme
            // 
            this.btnStatistikaFirme.FlatAppearance.BorderSize = 0;
            this.btnStatistikaFirme.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStatistikaFirme.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStatistikaFirme.Location = new System.Drawing.Point(498, 6);
            this.btnStatistikaFirme.Name = "btnStatistikaFirme";
            this.btnStatistikaFirme.Size = new System.Drawing.Size(167, 63);
            this.btnStatistikaFirme.TabIndex = 2;
            this.btnStatistikaFirme.Text = "Statistika";
            this.btnStatistikaFirme.UseVisualStyleBackColor = true;
            this.btnStatistikaFirme.Click += new System.EventHandler(this.prikaziStatistikuFirme);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Monotype Corsiva", 27.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(217)))));
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 45);
            this.label2.TabIndex = 1;
            this.label2.Text = "Extra Sjaj";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.panel3.Controls.Add(this.btnRacuni);
            this.panel3.Controls.Add(this.button4);
            this.panel3.Controls.Add(this.btnMusterije);
            this.panel3.Controls.Add(this.btnBrisiMusteriju);
            this.panel3.Controls.Add(this.btnUpdateMusterija);
            this.panel3.Controls.Add(this.listBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 121);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(182, 583);
            this.panel3.TabIndex = 21;
            // 
            // btnRacuni
            // 
            this.btnRacuni.FlatAppearance.BorderSize = 0;
            this.btnRacuni.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRacuni.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRacuni.ForeColor = System.Drawing.Color.White;
            this.btnRacuni.Image = ((System.Drawing.Image)(resources.GetObject("btnRacuni.Image")));
            this.btnRacuni.Location = new System.Drawing.Point(3, 138);
            this.btnRacuni.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRacuni.Name = "btnRacuni";
            this.btnRacuni.Size = new System.Drawing.Size(178, 119);
            this.btnRacuni.TabIndex = 10;
            this.btnRacuni.Text = "Računi";
            this.btnRacuni.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRacuni.UseVisualStyleBackColor = true;
            this.btnRacuni.Click += new System.EventHandler(this.btnRacuni_Click);
            // 
            // button4
            // 
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
            this.button4.Location = new System.Drawing.Point(3, 360);
            this.button4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(178, 119);
            this.button4.TabIndex = 7;
            this.button4.Text = "Podešavanja";
            this.button4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button4.UseVisualStyleBackColor = true;
            // 
            // musterijasBindingSource
            // 
            this.musterijasBindingSource.DataMember = "Musterijas";
            // 
            // musterijasBindingSource1
            // 
            this.musterijasBindingSource1.DataMember = "Musterijas";
            // 
            // musterijasBindingSource2
            // 
            this.musterijasBindingSource2.DataMember = "Musterijas";
            // 
            // listaRacuna
            // 
            this.listaRacuna.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.listaRacuna.Dock = System.Windows.Forms.DockStyle.Left;
            this.listaRacuna.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listaRacuna.ForeColor = System.Drawing.SystemColors.Info;
            this.listaRacuna.Location = new System.Drawing.Point(182, 121);
            this.listaRacuna.Name = "listaRacuna";
            this.listaRacuna.Size = new System.Drawing.Size(490, 583);
            this.listaRacuna.TabIndex = 25;
            this.listaRacuna.UseCompatibleStateImageBehavior = false;
            this.listaRacuna.View = System.Windows.Forms.View.Tile;
            this.listaRacuna.DoubleClick += new System.EventHandler(this.listaRacuna_DoubleClick);
            // 
            // button6
            // 
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Location = new System.Drawing.Point(725, 171);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(79, 94);
            this.button6.TabIndex = 26;
            this.button6.Text = "Računi ovog mjeseca";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // cmbBrojaRacuna
            // 
            this.cmbBrojaRacuna.FormattingEnabled = true;
            this.cmbBrojaRacuna.Items.AddRange(new object[] {
            "50",
            "100",
            "200"});
            this.cmbBrojaRacuna.Location = new System.Drawing.Point(745, 300);
            this.cmbBrojaRacuna.Name = "cmbBrojaRacuna";
            this.cmbBrojaRacuna.Size = new System.Drawing.Size(59, 24);
            this.cmbBrojaRacuna.TabIndex = 27;
            this.cmbBrojaRacuna.Text = "50";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(742, 281);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 16);
            this.label3.TabIndex = 28;
            this.label3.Text = "Broj računa za pregled:";
            // 
            // timer1
            // 
            this.timer1.Interval = 5;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // dodavanjeTepihaControl1
            // 
            this.dodavanjeTepihaControl1.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dodavanjeTepihaControl1.Location = new System.Drawing.Point(393, 120);
            this.dodavanjeTepihaControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dodavanjeTepihaControl1.Name = "dodavanjeTepihaControl1";
            this.dodavanjeTepihaControl1.Size = new System.Drawing.Size(850, 604);
            this.dodavanjeTepihaControl1.TabIndex = 24;
            // 
            // btnHomePage
            // 
            this.btnHomePage.Location = new System.Drawing.Point(185, 122);
            this.btnHomePage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnHomePage.Name = "btnHomePage";
            this.btnHomePage.Size = new System.Drawing.Size(1689, 1116);
            this.btnHomePage.TabIndex = 23;
            // 
            // dodavanjeMusterijeControl1
            // 
            this.dodavanjeMusterijeControl1.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dodavanjeMusterijeControl1.Location = new System.Drawing.Point(203, 120);
            this.dodavanjeMusterijeControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dodavanjeMusterijeControl1.Name = "dodavanjeMusterijeControl1";
            this.dodavanjeMusterijeControl1.Size = new System.Drawing.Size(1043, 616);
            this.dodavanjeMusterijeControl1.TabIndex = 22;
            // 
            // frmPocetna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1243, 704);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbBrojaRacuna);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.listaRacuna);
            this.Controls.Add(this.dodavanjeTepihaControl1);
            this.Controls.Add(this.btnHomePage);
            this.Controls.Add(this.dodavanjeMusterijeControl1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmPocetna";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Extra Sjaj";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.musterijasBindingSource3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._TepisiBaza_2018DataSet1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.musterijasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.musterijasBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.musterijasBindingSource2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
     
        private System.Windows.Forms.BindingSource musterijasBindingSource;
     
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btnMusterije;
        private System.Windows.Forms.Button btnBrisiMusteriju;
        private System.Windows.Forms.Button btnUpdateMusterija;
        private System.Windows.Forms.BindingSource musterijasBindingSource1;
        private System.Windows.Forms.BindingSource musterijasBindingSource2;
        private _TepisiBaza_2018DataSet1 _TepisiBaza_2018DataSet1;
        private System.Windows.Forms.BindingSource musterijasBindingSource3;
        private _TepisiBaza_2018DataSet1TableAdapters.MusterijasTableAdapter musterijasTableAdapter1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnStatistikaFirme;
        private System.Windows.Forms.Button closeButton;
        private Forme.DodavanjeMusterijeControl dodavanjeMusterijeControl1;
        private System.Windows.Forms.Button button4;
        private Forme.DodavanjeTepihaControl dodavanjeTepihaControl1;
        private System.Windows.Forms.ListView listaRacuna;
        private System.Windows.Forms.Button btnRacuni;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button3;
        private Forme.ArhivaMusterijaControl btnHomePage;
        private System.Windows.Forms.ComboBox cmbBrojaRacuna;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer timer1;
    }
}

