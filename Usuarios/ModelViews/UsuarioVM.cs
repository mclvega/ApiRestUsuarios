using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Usuarios.ModelViews
{
    public class UsuarioVM
    { 
        public HttpClient Initial()
        {
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri("https://localhost:44337/");
            return cliente;
        }
    }
}
