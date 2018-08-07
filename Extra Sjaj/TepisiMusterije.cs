﻿using ExtraSjaj.Modeli;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExtraSjaj
{
    public partial class TepisiMusterije : Form
    {
        SqlConnection konekcija = new SqlConnection(Konekcija.konString);
        
        public string IdMusterije { get; set; }
        public string ImeMusterije { get; set; }
        public TepisiMusterije(string  IdMusterije, string ImeMusterije)
        {
            InitializeComponent();
            this.IdMusterije = IdMusterije;
            int i = 0;
            SqlDataAdapter sda = new SqlDataAdapter("select row_number() over (order by t.MusterijaId) as 'Br. Tepiha', t.Sirina as 'Širina/m', t.Duzina as 'Dužina/m',  t.Kvadratura as 'Kvadratura/m2'  from Tepisi t join Musterijas m on m.Id = t.MusterijaId where t.MusterijaId = "+IdMusterije, konekcija);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            
            dataGridView1.DataSource = dt;
            double racun = 0;

            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                if (item.Cells[0].Value == null) break;
                //var nesto = item.Cells[3].Value.ToString();
                racun += Convert.ToDouble(item.Cells[3].Value.ToString());

            }
            label2.Text += " "+racun.ToString()+" EUR";
            label1.Text = ImeMusterije+" - tepisi";

        }
    }
}
