using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiRestUsuarios.Clases;
using ApiRestUsuarios.Conexion;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiRestUsuarios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoController : ControllerBase
    {
        private readonly ConexionBDD conexion;

        public TipoController(ConexionBDD conexion)
        {
            this.conexion = conexion;
        }

        //GET
        [HttpGet]
        public IEnumerable<TipoUsuario> Get()
        {
            return conexion.TipoUsuario.ToList();
        }

        [HttpGet("{id}")]
        public TipoUsuario Get(string id)
        {
            int cod = int.Parse(id);
            var tipo = conexion.TipoUsuario.FirstOrDefault(u => u.Id == cod);
            return tipo;
        }

        [HttpPost]
        public ActionResult Post([FromBody] TipoUsuario tipo)
        {
            try
            {
                conexion.TipoUsuario.Add(tipo);
                conexion.SaveChanges();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] TipoUsuario tipo)
        {

            if (tipo.Id == id)
            {
                conexion.Entry(tipo).State = EntityState.Modified;
                conexion.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {

            var tipo = conexion.TipoUsuario.FirstOrDefault(t => t.Id == id);
            if (tipo != null)
            {
                conexion.Remove(tipo);
                conexion.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }

        }
    }
}
