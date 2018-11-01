using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExtraSjaj.Modeli
{
    [Table("Racuni")]
    public class Racun
    {
        public int Id { get; set; }
        public double Vrijednost { get; set; }
       
        public bool Placen { get; set; }
        public DateTime VrijemeKreiranjaRacuna { get; set; }
        public int BrojTepiha { get; set; }
        public DateTime VrijemePlacanjaRacuna { get; set; }


        public int MusterijaId { get; set; }
        public virtual Musterija Musterija { get; set; }

    }
}
