using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ExtraSjaj.Common.Models
{
    [Table("Users")]
    public class User
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string JMBG { get; set; }

        public string BrojTelefona { get; set; }

    }
}
