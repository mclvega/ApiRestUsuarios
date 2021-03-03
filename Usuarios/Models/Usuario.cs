using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Usuarios.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public byte Activo { get; set; }
    }
}
