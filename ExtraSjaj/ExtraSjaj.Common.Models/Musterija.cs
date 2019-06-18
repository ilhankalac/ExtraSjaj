using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ExtraSjaj.Common.Models
{
    [Table("Musterije")]
    public class Musterija
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string BrojTelefona { get; set; }
        public string Adresa { get; set; }
        public DateTime VrijemeKreiranjaMusterije { get; set; }
    }
}
