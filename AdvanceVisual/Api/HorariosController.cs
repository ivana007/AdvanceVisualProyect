using System;
using System.Collections;
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
using Microsoft.VisualBasic.CompilerServices;

namespace AdvanceVisual.Api
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class HorariosController : ControllerBase
    {
        private readonly DataContext contexto;
        private readonly IConfiguration config;


        public HorariosController(DataContext contexto, IConfiguration config)
        {
            this.contexto = contexto;
            this.config = config;
        }
        // GET: api/Horarios
        [HttpGet]
        public async Task<IActionResult> CuentaAsistencias()///devuelve la cantidad de turnos sacados x el cliente.sirve para todas las clases
        {
            var usuario = contexto.Clientes.FirstOrDefault(x => x.Email == User.Identity.Name);
            var asistenciaTotal = contexto.Horarios.Include(x => x.Cliente).Where(x =>x.ClienteId==usuario.ClienteId).Count();
            return Ok(asistenciaTotal);
        }
       




        // GET: api/Horarios/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Horarios
        [HttpPost]
        public async Task<IActionResult> CuentaAsistenciasPorClases([FromBody] Clase clase)
        {
            var usuario= contexto.Clientes.FirstOrDefault(x => x.Email == User.Identity.Name);
            var asistenciaTotal = contexto.Horarios.Include(x => x.Cliente).Include(x => x.Clase).Where(x => x.Cliente.Email == usuario.Email && x.Clase.ClaseId == clase.ClaseId).Count();

            return Ok(asistenciaTotal);
        }

        // POST: api/Horarios
        [HttpPost]
        //public async Task<IActionResult> ControlCupos([FromBody]Horario horario,Clase clase)
        //{
        //   // ParseTimeSpan("23:0:0");
        //    var usuario = contexto.Clientes.FirstOrDefault(x => x.Email == User.Identity.Name);
        //    var cupoTotal = contexto.Horarios.Include(x => x.Cliente).Include(x => x.Clase).Where(x => x.Cliente.Email == usuario.Email && x.Clase.ClaseId == clase.ClaseId  && x.Fecha == horario.Fecha && x.Hora == horario.Hora).Count();

        //    return Ok(cupoTotal);
        //}

        
        // POST: api/Horarios
        [HttpPost()]
        public async Task<IActionResult> Post(Horario horario)//guardar un horario nuevo ..la validacion la hago en la app 
        {
            try
            {
                if (ModelState.IsValid)
                {
                    horario.ClienteId = contexto.Clientes.AsNoTracking().Single(x => x.Email == User.Identity.Name).ClienteId;

                    //entidad.Propietario = null;
                    contexto.Horarios.Add(horario);
                    contexto.SaveChanges();
                    /// return CreatedAtAction(nameof(Get), new { id = entidad.IdPropietario }, entidad);
                    return Ok(horario);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }



        // PUT: api/Horarios/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] Horario horario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    horario.ClienteId = contexto.Clientes.AsNoTracking().Single(x => x.Email == User.Identity.Name).ClienteId;
                    //entidad.IdPropietario = id;
                    contexto.Horarios.Update(horario);
                    contexto.SaveChanges();
                    return Ok(horario);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)//dar de baja un turno
        {
            try
            {
                var entidad = contexto.Horarios.Include(x => x.Cliente).FirstOrDefault(x => x.HorarioId == id && x.Cliente.Email == User.Identity.Name);
                if (ModelState.IsValid)

                {
                    // debo controlar que sea una hora antes del turno para poder cancelar
                    DateTime horaActual = DateTime.Now;
                    int hora = horaActual.Hour;
                    if (entidad.Hora.Hour.Equals(hora))
                    {
                        contexto.Horarios.Remove(entidad);
                        contexto.SaveChanges();
                        return Ok("Turno cancelado");
                    }
                    return Ok("Nose puede cancelar turno , tiempo de tolerancia excedido");
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            
        }
    }
}
