using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestUsuarios.Clases
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public byte Activo { get; set; }
    }
}
