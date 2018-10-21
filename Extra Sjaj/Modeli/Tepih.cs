using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExtraSjaj.Modeli
{
    [Table("Tepisi")]
    public class Tepih
    {
        public int Id { get; set; }
        public float Duzina { get; set; }
        public float Sirina { get; set; }
        public float Kvadratura { get; set; }

        public int RacunId { get; set; }
        public virtual Racun Racun { get; set; }

    }
}
