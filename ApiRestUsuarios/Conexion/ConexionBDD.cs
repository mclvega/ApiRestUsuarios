using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestUsuarios.Conexion
{
    public class ConexionBDD:DbContext
    {
        public ConexionBDD(DbContextOptions<ConexionBDD> opciones):base(opciones)
        {
                
        }

        public DbSet<ApiRestUsuarios.Clases.Usuario> Usuario
        { 
            get; 
            set; 
        }

        public DbSet<ApiRestUsuarios.Clases.TipoUsuario> TipoUsuario
        {
            get;
            set;
        }
    }
}
