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
    [ApiController]
    [Route("api/[controller]")]

    public class UsuarioController : ControllerBase
    {
        private readonly ConexionBDD conexion;

        public UsuarioController(ConexionBDD conexion)
        {
            this.conexion = conexion;
        }

        //GET
        [HttpGet]
        public IEnumerable<Usuario> Get()
        {
            return conexion.Usuario.ToList();
        }
        
        [HttpGet("{id}")]
        public Usuario Get(int id)
        {
            
            var usuario = conexion.Usuario.FirstOrDefault(u => u.Id == id);
            return usuario;
        } 
        
        [HttpPost]
        public ActionResult Post([FromBody]Usuario usuario)
        {
            try
            {
                conexion.Usuario.Add(usuario);
                conexion.SaveChanges();
                return Ok();
            }
            catch(Exception e)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public ActionResult Put(int id,[FromBody] Usuario usuario)
        {
            try
            {
                if(usuario.Id==id)
                {
                    conexion.Entry(usuario).State = EntityState.Modified;
                    conexion.SaveChanges();
                    
                }
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {

            var usuario = conexion.Usuario.FirstOrDefault(t => t.Id == id);
            if (usuario!=null)
            {
                conexion.Remove(usuario);
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
