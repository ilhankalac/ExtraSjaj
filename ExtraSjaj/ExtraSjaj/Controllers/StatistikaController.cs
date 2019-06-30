using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExtraSjaj.Common.Interfaces;
using ExtraSjaj.Common.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExtraSjaj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatistikaController : ControllerBase
    {

        public IUnitOfWork _unitOfWork { get; }


        public StatistikaController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost("totalYear/")]
        public IActionResult getZaradaByYear(DateFormat dateTime)
        {
            return Ok(_unitOfWork.Racuni.zaradaOdabraneGodine(dateTime.time));
        }
        [HttpPost("totalMonth/")]
        public IActionResult getZaradaByMonth(DateFormat dateTime)
        {
            return Ok(_unitOfWork.Racuni.zaradaNaOdabranomMesecu(dateTime.time));
        }


        [HttpPost("avgYear/")]
        public IActionResult getProsecnaGodisnjaZarada(DateFormat dateTime)
        {
            return Ok(_unitOfWork.Racuni.prosecnaGodisnjaZarada(dateTime.time));
        }

        [HttpPost("avgMonth/")]
        public IActionResult getProsecnaMesecnaZarada(DateFormat dateTime)
        {
            return Ok(_unitOfWork.Racuni.prosecnaMesecnaZarada(dateTime.time));
        }

        [HttpGet]
        public IActionResult getStatistika()
        {            
            return Ok(_unitOfWork.Racuni.statistika());
        }

    }

    public class DateFormat
    {
        public DateTime time { get; set; }
    }
}