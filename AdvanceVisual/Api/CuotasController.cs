using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdvanceVisual.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AdvanceVisual.Api
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CuotasController : ControllerBase
    {
        private readonly DataContext contexto;
        private readonly IConfiguration config;


        public CuotasController(DataContext contexto, IConfiguration config)
        {
            this.contexto = contexto;
            this.config = config;
        }
        // GET: api/Cuotas
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var usuario = User.Identity.Name;

                return Ok(contexto.Cuotas.Include(x => x.Clase).Include(x => x.Cliente).Where(x => x.Cliente.Email == usuario).Select(x=>x.Clase));//lista las clases que pago de un cliente
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        // GET: api/Cuotas/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Cuotas
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Cuotas/5
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
