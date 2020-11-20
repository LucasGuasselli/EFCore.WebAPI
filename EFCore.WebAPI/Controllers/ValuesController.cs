using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCore.Dominio;
using EFCore.Repo;
using Microsoft.AspNetCore.Mvc;

namespace EFCore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public readonly HeroiContext _context;
        public ValuesController(HeroiContext context)
        {
            _context = context;
        }

        
        // GET api/values
        [HttpGet("filtro/{nome}")]
        public ActionResult GetFiltro(string nome)
        {
            // LINQ Method
            var listHeroi = _context.Herois.
                            Where(h => h.Nome.Contains(nome))
                            .ToList();
            
            // LINQ Query
           //var listHeroi = (from heroi in _context.Herois
           //                 where heroi.Nome.Contains(nome)
           //                  select heroi).ToList();
                return Ok(listHeroi);      
        }

        // GET api/values/5
        [HttpGet("Atualizar/{nameHero}")]
        public ActionResult Get(string nameHero)
        {
            // var heroi = new Heroi { Nome = nameHero };

            var heroi = _context.Herois.
                         Where(h => h.Id == 3)
                         .FirstOrDefault();
            heroi.Nome = "Homem Aranha";
            // _contexto.Add(heroi);
            _context.SaveChanges();
            
            // retorna um status
            return Ok();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}