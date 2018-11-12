using ExtraSjaj.Modeli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExtraSjaj.Common.Interfaces
{
    public interface IMusterijaRepository : IRepository<Musterija>
    {
     
        Task<List<Musterija>> pretragaMusterija(TextBox textBox);
        Task<List<Musterija>> sortiranjeMusterijaPoProfitu();
    }
}
