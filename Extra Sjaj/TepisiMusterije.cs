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
        public string ImeMusterije { get; set; }
        public TepisiMusterije(string  IdMusterije, string ImeMusterije)
        {
            InitializeComponent();
            this.IdMusterije = IdMusterije;
            
            SqlDataAdapter sda = new SqlDataAdapter("select t.id,row_number() over (order by t.MusterijaId) as 'Br. Tepiha', t.Sirina as 'Širina/m', t.Duzina as 'Dužina/m',  t.Kvadratura as 'Kvadratura/m2'  from Tepisi t join Musterijas m on m.Id = t.MusterijaId where t.MusterijaId = "+IdMusterije, konekcija);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            
            
            dataGridView1.DataSource = dt;
            label1.Text = ImeMusterije + " - tepisi";
            racunZaMusteriju();

        }

        private void btnDodajTepih_Click(object sender, EventArgs e)
        {

            SqlCommand komanda = new SqlCommand(@"insert into Tepisi(Duzina,Sirina,Kvadratura, MusterijaId)" +
                "values ((" + textBox1.Text.ToString() + ")," +
                "(" + textBox2.Text.ToString() + ")," +
                "(" + Convert.ToDouble(textBox1.Text) * Convert.ToDouble(textBox2.Text) + ")," +
                "(" + IdMusterije.ToString() + ")); ", konekcija);

            konekcija.Open();
            komanda.ExecuteNonQuery();
            konekcija.Close();
            IscitajTabeluTepisiZaMusteriju();
            racunZaMusteriju();
        }

        public void IscitajTabeluTepisiZaMusteriju()
        {

            SqlDataAdapter sda = new SqlDataAdapter("select t.id, m.ImePrezime , t.Sirina as 'Širina/m' , t.Duzina as 'Dužina/m'  , t.Kvadratura as 'Kvadratura/m2'  from Tepisi t join Musterijas m on m.Id = t.MusterijaId where m.Id = "+IdMusterije, konekcija);
            DataTable dt = new DataTable();

            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void btnZaBrisanjeTepiha_Click(object sender, EventArgs e)
        {
          


        }
        void racunZaMusteriju()
        {
            
            label2.Text = "Račun:";
            double racun = 0;
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                if (item.Cells[0].Value == null) break;
                //var nesto = item.Cells[3].Value.ToString();
                racun += Convert.ToDouble(item.Cells[4].Value.ToString());

            }
            label2.Text += " " + racun.ToString() + " EUR";
           
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(MessageBox.Show("Da li si siguran da zelis obrisati selektovani tepih?", "Poruka", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)== DialogResult.Yes)
            {
                string idSelektovanogTepiha = dataGridView1.SelectedCells[0].Value.ToString();
                SqlCommand komanda = new SqlCommand(@"delete from Tepisi where id = "+idSelektovanogTepiha, konekcija);

                konekcija.Open();
                komanda.ExecuteNonQuery();
                konekcija.Close();
                IscitajTabeluTepisiZaMusteriju();


                racunZaMusteriju();


            }
        }
    }
}
