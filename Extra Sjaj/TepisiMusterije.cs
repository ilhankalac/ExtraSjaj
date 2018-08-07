using ExtraSjaj.Modeli;
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
        public TepisiMusterije(string  IdMusterije)
        {
            InitializeComponent();
            this.IdMusterije = IdMusterije;
            SqlDataAdapter sda = new SqlDataAdapter("select t.Sirina as 'Širina/m', t.Duzina as 'Dužina/m',  t.Kvadratura as 'Kvadratura/m2'  from Tepisi t join Musterijas m on m.Id = t.MusterijaId where t.MusterijaId = "+IdMusterije, konekcija);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;


        }
    }
}
