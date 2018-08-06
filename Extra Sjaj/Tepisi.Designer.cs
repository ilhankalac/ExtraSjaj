namespace ExtraSjaj
{
    partial class Tepisi
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.musterijaIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.duzinaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sirinaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kvadraturaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tepisiBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._TepisiBaza_2018DataSet1 = new ExtraSjaj._TepisiBaza_2018DataSet1();
            this.tepisiTableAdapter = new ExtraSjaj._TepisiBaza_2018DataSet1TableAdapters.TepisiTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tepisiBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._TepisiBaza_2018DataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.musterijaIdDataGridViewTextBoxColumn,
            this.duzinaDataGridViewTextBoxColumn,
            this.sirinaDataGridViewTextBoxColumn,
            this.kvadraturaDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.tepisiBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(90, 24);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(547, 285);
            this.dataGridView1.TabIndex = 0;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // musterijaIdDataGridViewTextBoxColumn
            // 
            this.musterijaIdDataGridViewTextBoxColumn.DataPropertyName = "MusterijaId";
            this.musterijaIdDataGridViewTextBoxColumn.HeaderText = "MusterijaId";
            this.musterijaIdDataGridViewTextBoxColumn.Name = "musterijaIdDataGridViewTextBoxColumn";
            // 
            // duzinaDataGridViewTextBoxColumn
            // 
            this.duzinaDataGridViewTextBoxColumn.DataPropertyName = "Duzina";
            this.duzinaDataGridViewTextBoxColumn.HeaderText = "Duzina";
            this.duzinaDataGridViewTextBoxColumn.Name = "duzinaDataGridViewTextBoxColumn";
            // 
            // sirinaDataGridViewTextBoxColumn
            // 
            this.sirinaDataGridViewTextBoxColumn.DataPropertyName = "Sirina";
            this.sirinaDataGridViewTextBoxColumn.HeaderText = "Sirina";
            this.sirinaDataGridViewTextBoxColumn.Name = "sirinaDataGridViewTextBoxColumn";
            // 
            // kvadraturaDataGridViewTextBoxColumn
            // 
            this.kvadraturaDataGridViewTextBoxColumn.DataPropertyName = "Kvadratura";
            this.kvadraturaDataGridViewTextBoxColumn.HeaderText = "Kvadratura";
            this.kvadraturaDataGridViewTextBoxColumn.Name = "kvadraturaDataGridViewTextBoxColumn";
            // 
            // tepisiBindingSource
            // 
            this.tepisiBindingSource.DataMember = "Tepisi";
            this.tepisiBindingSource.DataSource = this._TepisiBaza_2018DataSet1;
            // 
            // _TepisiBaza_2018DataSet1
            // 
            this._TepisiBaza_2018DataSet1.DataSetName = "_TepisiBaza_2018DataSet1";
            this._TepisiBaza_2018DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tepisiTableAdapter
            // 
            this.tepisiTableAdapter.ClearBeforeFill = true;
            // 
            // Tepisi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Tepisi";
            this.Text = "Tepisi";
            this.Load += new System.EventHandler(this.Tepisi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tepisiBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._TepisiBaza_2018DataSet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private _TepisiBaza_2018DataSet1 _TepisiBaza_2018DataSet1;
        private System.Windows.Forms.BindingSource tepisiBindingSource;
        private _TepisiBaza_2018DataSet1TableAdapters.TepisiTableAdapter tepisiTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn musterijaIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn duzinaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sirinaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kvadraturaDataGridViewTextBoxColumn;
    }
}