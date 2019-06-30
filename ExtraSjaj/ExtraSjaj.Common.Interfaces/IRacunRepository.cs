using ExtraSjaj.Common.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExtraSjaj.Common.Interfaces
{
    public interface IRacunRepository : IRepository<Racun>
    {
        Task<IEnumerable<Racun>> getRacuniByMusterijaId(int MusterijaId);

        //update Racuna after adding or removing tepih from the total
        void tepihAkcija(Tepih tepih);
        double zaradaNaOdabranomMesecu(DateTime time);
        double zaradaOdabraneGodine(DateTime time);

        double prosecnaMesecnaZarada(DateTime time);
        double prosecnaGodisnjaZarada(DateTime time);

        void naplacivanje(int id);

        object statistika();
    }
}
