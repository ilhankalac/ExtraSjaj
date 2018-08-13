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
    public partial class frmArhivaMusterija : Form
    {
        SqlConnection konekcija = new SqlConnection(Konekcija.konString);
        public frmArhivaMusterija()
        {
            InitializeComponent();
            citajTabeluMusterijeFromSql();
        }

        public void citajTabeluMusterijeFromSql()
        {

           

            SqlDataAdapter sda = new SqlDataAdapter("select m.id,row_number() over (order by m.Id) as 'Br.Mušterije'," +
                "m.ImePrezime as 'Ime i Prezime',m.BrojTepiha as 'Br.Tepiha',m.BrojTelefona as 'Br. Tel.',m.Adresa, " +
                "sum(isnull(t.kvadratura,0)) as 'Kvadratura Tepiha', m.VremeDolaskaTepiha as 'Tepisi dostavljeni', m.Racun as 'Račun/Eur', m.Platio as 'Plaćeno' " +
                "from Musterijas m left join Tepisi t on t.MusterijaId = m.Id " +
                "where m.Platio = 1" +
                "" +
                "group by m.id, m.ImePrezime, m.BrojTepiha, m.BrojTelefona, m.Adresa, m.VremeDolaskaTepiha,m.Racun, m.Platio" +
                " order by m.Id asc", konekcija);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

//        Danas
//Juče
//Ove nedjelje
//Prošle nedjelje
//Ovog mjeseca
//Prošlog mjeseca
//Prošle godine
//Sve vrijeme
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selektovaniPeriod = 0;
            string selektovaniDeoDatuma = "";

            switch (comboBox1.Text)
            {
                case "Danas":
                    {
                        selektovaniPeriod = 0;
                        selektovaniDeoDatuma = "day";
                        break;
                    }
                case "Juče":
                    {
                        selektovaniPeriod = 1;
                        selektovaniDeoDatuma = "day";
                        break;
                    }

                case "Ove nedjelje":
                    {
                        selektovaniPeriod = 0;
                        selektovaniDeoDatuma = "week";
                        break;
                    }

                case "Prošle nedjelje":
                    {
                        selektovaniPeriod = 1;
                        selektovaniDeoDatuma = "week";
                        break;
                    }

                case "Ovog mjeseca":
                    {
                        selektovaniPeriod = 0;
                        selektovaniDeoDatuma = "month";
                        break;
                    }
                case "Prošlog mjeseca":
                    {
                        selektovaniPeriod = 1;
                        selektovaniDeoDatuma = "month";
                        break;
                    }
                case "Ove godine":
                    {
                        selektovaniPeriod = 0;
                        selektovaniDeoDatuma = "year";
                        break;
                    }
                case "Prošle godine":
                    {
                        selektovaniPeriod = 1;
                        selektovaniDeoDatuma = "year";
                        break;
                    }
                default:
                    selektovaniDeoDatuma = "";
                    selektovaniPeriod = 0;
                    break;
            }

            arhivaMusterijaUOdredjenomPeriodu(selektovaniPeriod, selektovaniDeoDatuma);


        }
        void arhivaMusterijaUOdredjenomPeriodu(int selektovaniPeriod, string selektovaniDeoDatuma)
        {
            SqlDataAdapter sda = new SqlDataAdapter("select m.id,row_number() over (order by m.Id) as 'Br.Mušterije'," +
               "m.ImePrezime as 'Ime i Prezime',m.BrojTepiha as 'Br.Tepiha',m.BrojTelefona as 'Br. Tel.',m.Adresa, " +
               "sum(isnull(t.kvadratura,0)) as 'Kvadratura Tepiha', m.VremeDolaskaTepiha as 'Tepisi dostavljeni', m.Racun as 'Račun/Eur', m.Platio as 'Plaćeno' " +
               "from Musterijas m left join Tepisi t on t.MusterijaId = m.Id " +
               "where m.Platio = 1 " +
               " and  datediff("+selektovaniDeoDatuma+", m.VremeDolaskaTepiha, getdate()) = " + selektovaniPeriod+
               " group by m.id, m.ImePrezime, m.BrojTepiha, m.BrojTelefona, m.Adresa, m.VremeDolaskaTepiha,m.Racun, m.Platio" +
               " order by m.Id asc", konekcija);

            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
