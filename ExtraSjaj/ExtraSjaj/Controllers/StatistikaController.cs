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
        [HttpGet]
        public IActionResult getZaradaByMonth(DateTime dateTime)
        {
            return Ok(_unitOfWork.Racuni.zaradaNaOdabranomMesecu(dateTime));
        }

    }
}