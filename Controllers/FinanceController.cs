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
    [Route("finances")]
    public class FinancaController : ControllerBase
    {

        [HttpGet]
        [Route("")]
        public ActionResult<List<Finance>> GetFinances([FromServices] DataContext context)
        {
            var finances = (context.Finances.ToList());
            return Ok(finances);
        }

        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<Finance> GetFinanceById(int id, [FromServices] DataContext context)
        {
            var finance = context.Finances.FirstOrDefault(x => x.Id == id);

            if (finance == null)
                return NotFound("Finança não encontrada");

            return Ok(finance);
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Finance>> AddFinance([FromBody] Finance model, [FromServices] DataContext context)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                context.Finances.Add(model);

                await context.SaveChangesAsync();

                return Ok(model);
            }
            catch (Exception error)
            {
                return BadRequest(new { Message = "Não foi possível criar a finança", Details = error });
            }

        }


        [HttpPut]
        [Route("")]
        public async Task<ActionResult<Finance>> UpdateFinance(int id, [FromBody] Finance model, [FromServices] DataContext context)
        {
            if (id != model.Id)
                return NotFound(new { message = "Finança não encontrada" });

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            model.UpdatedDate = DateTime.Now;

            try
            {
                context.Entry<Finance>(model).State = EntityState.Modified;

                await context.SaveChangesAsync();

                return Ok(model);
            }
            catch (Exception error)
            {
                return BadRequest(new { Message = "Não foi possível atualizar a finança", Details = error });
            }

        }

    }
}