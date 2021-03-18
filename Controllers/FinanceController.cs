using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinancesAPI.Data;
using FinancesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinancesAPI.Controllers
{
    [Route("Finance")]
    public class FinanceController : ControllerBase
    {
        private readonly DataContext _context;

        public FinanceController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public ActionResult<List<Finance>> GetFinances()
        {
            var finances = _context.Finances.ToList();
            return Ok(finances);
        }

        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<Finance> GetFinanceById(int id)
        {
            var finance = _context.Finances.FirstOrDefault(x => x.Id == id);

            if (finance == null)
                return NotFound(new { Message = "Finança não encontrada" });

            return Ok(finance);
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Finance>> AddFinance([FromBody] Finance model)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                _context.Finances.Add(model);

                await _context.SaveChangesAsync();

                return Ok(new { Message = "Finança cadastrada com sucesso!" });
            }
            catch (Exception error)
            {
                return BadRequest(new { Message = "Não foi possível criar a finança", Details = error });
            }

        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<Finance>> UpdateFinance(int id, [FromBody] Finance model)
        {

            var finance = _context.Finances.FirstOrDefault(x => x.Id == id);

            if (finance == null)
                return NotFound("Finança não encontrada");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            finance.UpdatedDate = DateTime.Now;

            try
            {
                _context.Entry<Finance>(finance).State = EntityState.Modified;

                await _context.SaveChangesAsync();

                return Ok(new { Message = "Finança atualizada com sucesso!" });
            }
            catch (Exception error)
            {
                return BadRequest(new { Message = "Não foi possível atualizar a finança", Details = error });
            }

        }

    }
}