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
            this.btnDodaj = new System.Windows.Forms.Button();
            this.btnBrisiMusteriju = new System.Windows.Forms.Button();
            this.btnUpdateMusterija = new System.Windows.Forms.Button();
            this.musterijasBindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this._TepisiBaza_2018DataSet1 = new ExtraSjaj._TepisiBaza_2018DataSet1();
            this.musterijasTableAdapter1 = new ExtraSjaj._TepisiBaza_2018DataSet1TableAdapters.MusterijasTableAdapter();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.musterijasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.musterijasBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.musterijasBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.arhivaMusterijaControl1 = new ExtraSjaj.Forme.ArhivaMusterijaControl();
            this.dodavanjeMusterijeControl1 = new ExtraSjaj.Forme.DodavanjeMusterijeControl();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.musterijasBindingSource3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._TepisiBaza_2018DataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            // btnDodaj
            // 
            this.btnDodaj.FlatAppearance.BorderSize = 0;
            this.btnDodaj.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDodaj.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDodaj.ForeColor = System.Drawing.Color.White;
            this.btnDodaj.Image = ((System.Drawing.Image)(resources.GetObject("btnDodaj.Image")));
            this.btnDodaj.Location = new System.Drawing.Point(3, 2);
            this.btnDodaj.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDodaj.Name = "btnDodaj";
            this.btnDodaj.Size = new System.Drawing.Size(178, 119);
            this.btnDodaj.TabIndex = 4;
            this.btnDodaj.Text = "Dodaj mušteriju";
            this.btnDodaj.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDodaj.UseVisualStyleBackColor = true;
            this.btnDodaj.Click += new System.EventHandler(this.btnDodaj_Click);
            // 
            // btnBrisiMusteriju
            // 
            this.btnBrisiMusteriju.FlatAppearance.BorderSize = 0;
            this.btnBrisiMusteriju.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrisiMusteriju.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrisiMusteriju.ForeColor = System.Drawing.Color.White;
            this.btnBrisiMusteriju.Image = ((System.Drawing.Image)(resources.GetObject("btnBrisiMusteriju.Image")));
            this.btnBrisiMusteriju.Location = new System.Drawing.Point(3, 119);
            this.btnBrisiMusteriju.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnBrisiMusteriju.Name = "btnBrisiMusteriju";
            this.btnBrisiMusteriju.Size = new System.Drawing.Size(178, 119);
            this.btnBrisiMusteriju.TabIndex = 5;
            this.btnBrisiMusteriju.Text = "Obriši mušteriju";
            this.btnBrisiMusteriju.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBrisiMusteriju.UseVisualStyleBackColor = true;
            this.btnBrisiMusteriju.Click += new System.EventHandler(this.btnBrisiMusteriju_Click);
            // 
            // btnUpdateMusterija
            // 
            this.btnUpdateMusterija.FlatAppearance.BorderSize = 0;
            this.btnUpdateMusterija.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateMusterija.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateMusterija.ForeColor = System.Drawing.Color.White;
            this.btnUpdateMusterija.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdateMusterija.Image")));
            this.btnUpdateMusterija.Location = new System.Drawing.Point(3, 233);
            this.btnUpdateMusterija.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnUpdateMusterija.Name = "btnUpdateMusterija";
            this.btnUpdateMusterija.Size = new System.Drawing.Size(178, 119);
            this.btnUpdateMusterija.TabIndex = 6;
            this.btnUpdateMusterija.Text = "Izmeni mušteriju";
            this.btnUpdateMusterija.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnUpdateMusterija.UseVisualStyleBackColor = true;
            this.btnUpdateMusterija.Click += new System.EventHandler(this.btnUpdateMusterija_Click);
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
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(191, 145);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.Size = new System.Drawing.Size(1036, 537);
            this.dataGridView1.TabIndex = 17;
            this.dataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
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
            this.panel1.Controls.Add(this.button2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1246, 48);
            this.panel1.TabIndex = 19;
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(1109, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(103, 49);
            this.button2.TabIndex = 3;
            this.button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 48);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1246, 73);
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
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(498, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(167, 63);
            this.button1.TabIndex = 2;
            this.button1.Text = "Istorija mušterija";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
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
            this.panel3.Controls.Add(this.button4);
            this.panel3.Controls.Add(this.btnDodaj);
            this.panel3.Controls.Add(this.btnBrisiMusteriju);
            this.panel3.Controls.Add(this.btnUpdateMusterija);
            this.panel3.Controls.Add(this.listBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 121);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(184, 603);
            this.panel3.TabIndex = 21;
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
            // arhivaMusterijaControl1
            // 
            this.arhivaMusterijaControl1.Location = new System.Drawing.Point(187, 130);
            this.arhivaMusterijaControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.arhivaMusterijaControl1.Name = "arhivaMusterijaControl1";
            this.arhivaMusterijaControl1.Size = new System.Drawing.Size(1047, 581);
            this.arhivaMusterijaControl1.TabIndex = 23;
            // 
            // dodavanjeMusterijeControl1
            // 
            this.dodavanjeMusterijeControl1.Location = new System.Drawing.Point(187, 145);
            this.dodavanjeMusterijeControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dodavanjeMusterijeControl1.Name = "dodavanjeMusterijeControl1";
            this.dodavanjeMusterijeControl1.Size = new System.Drawing.Size(1040, 588);
            this.dodavanjeMusterijeControl1.TabIndex = 22;
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
            // frmPocetna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1246, 724);
            this.Controls.Add(this.arhivaMusterijaControl1);
            this.Controls.Add(this.dodavanjeMusterijeControl1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmPocetna";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.musterijasBindingSource3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._TepisiBaza_2018DataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
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
        private System.Windows.Forms.Button btnDodaj;
        private System.Windows.Forms.Button btnBrisiMusteriju;
        private System.Windows.Forms.Button btnUpdateMusterija;
        private System.Windows.Forms.BindingSource musterijasBindingSource1;
        private System.Windows.Forms.BindingSource musterijasBindingSource2;
        private _TepisiBaza_2018DataSet1 _TepisiBaza_2018DataSet1;
        private System.Windows.Forms.BindingSource musterijasBindingSource3;
        private _TepisiBaza_2018DataSet1TableAdapters.MusterijasTableAdapter musterijasTableAdapter1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private Forme.DodavanjeMusterijeControl dodavanjeMusterijeControl1;
        private System.Windows.Forms.Button button3;
        private Forme.ArhivaMusterijaControl arhivaMusterijaControl1;
        private System.Windows.Forms.Button button4;
    }
}

