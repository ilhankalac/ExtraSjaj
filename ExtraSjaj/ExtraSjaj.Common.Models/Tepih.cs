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
        public float Duzina { get; set; }
        public float Sirina { get; set; }
        public float Kvadratura { get; set; }

        public int RacunId { get; set; }
        public virtual Racun Racun { get; set; }
    }
}
