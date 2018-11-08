using ExtraSjaj.Modeli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExtraSjaj.Common.Interfaces
{
    public interface IRacunRepository : IRepository<Racun>
    {
        int ukupanBrojRacuna();
        Task<List<Racun>> racuniSelektovanogDatuma(MonthCalendar monthCalendar);
    }
}
