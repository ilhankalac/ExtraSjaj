using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ExtraSjaj.Common.Models
{
    [Table("Tepisi")]
    public class Tepih
    {
        public int Id { get; set; }
        public double Duzina { get; set; }
        public double Sirina { get; set; }
        public double Kvadratura { get; set; }

        public int RacunId { get; set; }
        public virtual Racun Racun { get; set; }
    }
}
