using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtraSjaj.Modeli
{
    public class Musterija
    {
        public int Id { get; set; }
        public string ImePrezime { get; set; }
        public int BrojTepiha { get; set; }
        public string BrojTelefona { get; set; }
        public string Adresa { get; set; }
        public DateTime VremeDolaskaTepiha { get; set; }
        public bool Platio { get; set; }

        public double Racun { get; set; }
    }
}
