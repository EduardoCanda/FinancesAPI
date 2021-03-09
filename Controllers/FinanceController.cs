using System.Collections.Generic;
using FinancesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinancesAPI.Controllers
{
    [Route("finances")]
    public class FinancaController : ControllerBase
    {

        [HttpGet]
        [Route("")]
        //public Task<ActionResult<Finance>> GetFinances() {
        public object GetFinances() {
            return Ok(new List<Finance>());
        }



    }
}