namespace ExtraSjaj
{
    partial class Form1
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
            this.musterijasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._TepisiBaza_2018DataSet = new ExtraSjaj._TepisiBaza_2018DataSet();
            this.musterijasTableAdapter = new ExtraSjaj._TepisiBaza_2018DataSetTableAdapters.MusterijasTableAdapter();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnDodaj = new System.Windows.Forms.Button();
            this.btnBrisiMusteriju = new System.Windows.Forms.Button();
            this.btnUpdateMusterija = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.kreirajMušterijuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.musterijasBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.musterijasBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this._TepisiBaza_2018DataSet1 = new ExtraSjaj._TepisiBaza_2018DataSet1();
            this.musterijasBindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this.musterijasTableAdapter1 = new ExtraSjaj._TepisiBaza_2018DataSet1TableAdapters.MusterijasTableAdapter();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imeIPrezimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.brojTepihaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.brojTelefonaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.adresaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.musterijasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._TepisiBaza_2018DataSet)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.musterijasBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.musterijasBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._TepisiBaza_2018DataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.musterijasBindingSource3)).BeginInit();
            this.SuspendLayout();
            // 
            // musterijasBindingSource
            // 
            this.musterijasBindingSource.DataMember = "Musterijas";
            this.musterijasBindingSource.DataSource = this._TepisiBaza_2018DataSet;
            // 
            // _TepisiBaza_2018DataSet
            // 
            this._TepisiBaza_2018DataSet.DataSetName = "_TepisiBaza_2018DataSet";
            this._TepisiBaza_2018DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // musterijasTableAdapter
            // 
            this.musterijasTableAdapter.ClearBeforeFill = true;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(182, 373);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(360, 95);
            this.listBox1.TabIndex = 1;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(124, 134);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(35, 21);
            this.comboBox1.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(574, 154);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Prikaži sve mušterije";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnDodaj
            // 
            this.btnDodaj.Location = new System.Drawing.Point(101, 312);
            this.btnDodaj.Name = "btnDodaj";
            this.btnDodaj.Size = new System.Drawing.Size(123, 23);
            this.btnDodaj.TabIndex = 4;
            this.btnDodaj.Text = "Dodaj mušteriju";
            this.btnDodaj.UseVisualStyleBackColor = true;
            this.btnDodaj.Click += new System.EventHandler(this.btnDodaj_Click);
            // 
            // btnBrisiMusteriju
            // 
            this.btnBrisiMusteriju.Location = new System.Drawing.Point(586, 419);
            this.btnBrisiMusteriju.Name = "btnBrisiMusteriju";
            this.btnBrisiMusteriju.Size = new System.Drawing.Size(123, 27);
            this.btnBrisiMusteriju.TabIndex = 5;
            this.btnBrisiMusteriju.Text = "Obriši mušteriju";
            this.btnBrisiMusteriju.UseVisualStyleBackColor = true;
            this.btnBrisiMusteriju.Click += new System.EventHandler(this.btnBrisiMusteriju_Click);
            // 
            // btnUpdateMusterija
            // 
            this.btnUpdateMusterija.Location = new System.Drawing.Point(574, 346);
            this.btnUpdateMusterija.Name = "btnUpdateMusterija";
            this.btnUpdateMusterija.Size = new System.Drawing.Size(123, 23);
            this.btnUpdateMusterija.TabIndex = 6;
            this.btnUpdateMusterija.Text = "Izmeni mušteriju";
            this.btnUpdateMusterija.UseVisualStyleBackColor = true;
            this.btnUpdateMusterija.Click += new System.EventHandler(this.btnUpdateMusterija_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kreirajMušterijuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1301, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // kreirajMušterijuToolStripMenuItem
            // 
            this.kreirajMušterijuToolStripMenuItem.Name = "kreirajMušterijuToolStripMenuItem";
            this.kreirajMušterijuToolStripMenuItem.Size = new System.Drawing.Size(105, 20);
            this.kreirajMušterijuToolStripMenuItem.Text = "Kreiraj mušteriju";
            // 
            // musterijasBindingSource1
            // 
            this.musterijasBindingSource1.DataMember = "Musterijas";
            this.musterijasBindingSource1.DataSource = this._TepisiBaza_2018DataSet;
            // 
            // musterijasBindingSource2
            // 
            this.musterijasBindingSource2.DataMember = "Musterijas";
            this.musterijasBindingSource2.DataSource = this._TepisiBaza_2018DataSet;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.imeIPrezimeDataGridViewTextBoxColumn,
            this.brojTepihaDataGridViewTextBoxColumn,
            this.brojTelefonaDataGridViewTextBoxColumn,
            this.adresaDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.musterijasBindingSource3;
            this.dataGridView1.Location = new System.Drawing.Point(715, 24);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(552, 495);
            this.dataGridView1.TabIndex = 8;
            // 
            // _TepisiBaza_2018DataSet1
            // 
            this._TepisiBaza_2018DataSet1.DataSetName = "_TepisiBaza_2018DataSet1";
            this._TepisiBaza_2018DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // musterijasBindingSource3
            // 
            this.musterijasBindingSource3.DataMember = "Musterijas";
            this.musterijasBindingSource3.DataSource = this._TepisiBaza_2018DataSet1;
            // 
            // musterijasTableAdapter1
            // 
            this.musterijasTableAdapter1.ClearBeforeFill = true;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // imeIPrezimeDataGridViewTextBoxColumn
            // 
            this.imeIPrezimeDataGridViewTextBoxColumn.DataPropertyName = "Ime i Prezime";
            this.imeIPrezimeDataGridViewTextBoxColumn.HeaderText = "Ime i Prezime";
            this.imeIPrezimeDataGridViewTextBoxColumn.Name = "imeIPrezimeDataGridViewTextBoxColumn";
            // 
            // brojTepihaDataGridViewTextBoxColumn
            // 
            this.brojTepihaDataGridViewTextBoxColumn.DataPropertyName = "Broj Tepiha";
            this.brojTepihaDataGridViewTextBoxColumn.HeaderText = "Broj Tepiha";
            this.brojTepihaDataGridViewTextBoxColumn.Name = "brojTepihaDataGridViewTextBoxColumn";
            // 
            // brojTelefonaDataGridViewTextBoxColumn
            // 
            this.brojTelefonaDataGridViewTextBoxColumn.DataPropertyName = "Broj Telefona";
            this.brojTelefonaDataGridViewTextBoxColumn.HeaderText = "Broj Telefona";
            this.brojTelefonaDataGridViewTextBoxColumn.Name = "brojTelefonaDataGridViewTextBoxColumn";
            // 
            // adresaDataGridViewTextBoxColumn
            // 
            this.adresaDataGridViewTextBoxColumn.DataPropertyName = "Adresa";
            this.adresaDataGridViewTextBoxColumn.HeaderText = "Adresa";
            this.adresaDataGridViewTextBoxColumn.Name = "adresaDataGridViewTextBoxColumn";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(124, 84);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 9;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(124, 181);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 10;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(124, 232);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Ime i Prezime";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Broj Tepiha";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 184);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Broj telefona";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(61, 236);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Adresa";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1301, 534);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnUpdateMusterija);
            this.Controls.Add(this.btnBrisiMusteriju);
            this.Controls.Add(this.btnDodaj);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.musterijasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._TepisiBaza_2018DataSet)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.musterijasBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.musterijasBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._TepisiBaza_2018DataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.musterijasBindingSource3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private _TepisiBaza_2018DataSet _TepisiBaza_2018DataSet;
        private System.Windows.Forms.BindingSource musterijasBindingSource;
        private _TepisiBaza_2018DataSetTableAdapters.MusterijasTableAdapter musterijasTableAdapter;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnDodaj;
        private System.Windows.Forms.Button btnBrisiMusteriju;
        private System.Windows.Forms.Button btnUpdateMusterija;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem kreirajMušterijuToolStripMenuItem;
        private System.Windows.Forms.BindingSource musterijasBindingSource1;
        private System.Windows.Forms.BindingSource musterijasBindingSource2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private _TepisiBaza_2018DataSet1 _TepisiBaza_2018DataSet1;
        private System.Windows.Forms.BindingSource musterijasBindingSource3;
        private _TepisiBaza_2018DataSet1TableAdapters.MusterijasTableAdapter musterijasTableAdapter1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn imeIPrezimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn brojTepihaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn brojTelefonaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn adresaDataGridViewTextBoxColumn;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

