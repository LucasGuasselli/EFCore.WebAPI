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
        [HttpGet]
        public ActionResult Get()
        {
            // LINQ Method
            //var listHeroi = _context.Herois.ToList();
            
            // LINQ Query
            var listHeroi = (from heroi in _context.Herois select heroi).ToList();
                return Ok(listHeroi);      
        }

        // GET api/values/5
        [HttpGet("{nameHero}")]
        public ActionResult<string> Get(string nameHero)
        {
            var heroi = new Heroi { Nome = nameHero };
            
                _context.Herois.Add(heroi);
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