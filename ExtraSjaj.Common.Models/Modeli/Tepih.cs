using System;
using System.ComponentModel.DataAnnotations.Schema;



namespace ExtraSjaj.Modeli
{
    [Table("Tepisi")]
    public class Tepih
    {
        //fdsa
        public int Id { get; set; }
        public float Duzina { get; set; }
        public float Sirina { get; set; }
        public float Kvadratura { get; set; }

        public int RacunId { get; set; }
        public virtual Racun Racun { get; set; }

    }
}
