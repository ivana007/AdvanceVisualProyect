using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdvanceVisual.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace AdvanceVisual.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClasesController : ControllerBase
    {
        private readonly DataContext contexto;
        private readonly IConfiguration config;


        public ClasesController(DataContext contexto, IConfiguration config)
        {
            this.contexto = contexto;
            this.config = config;
        }
        // GET: api/Clases
        [HttpGet]
        public async Task<IActionResult> Get()
        {
          
            return Ok(contexto.Clases);
        }

        // GET: api/Clases/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Clases
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Clases/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
