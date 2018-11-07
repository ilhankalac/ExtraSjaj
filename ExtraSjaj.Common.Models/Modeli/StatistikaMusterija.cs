using System.ComponentModel.DataAnnotations.Schema;

namespace ExtraSjaj.Modeli
{

    [Table("StatistikeMusterija")]
    public class StatistikaMusterija
    {
        public int Id { get; set; }

        public decimal UkupnoNovca { get; set; }
        public int BrojOpranihTepiha { get; set; }


        public int MusterijaId { get; set; }
        public virtual Musterija Musterija { get; set; }
    }
}
