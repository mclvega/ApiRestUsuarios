using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Usuarios.Models;
using Usuarios.ModelViews;

namespace Usuarios.Controllers
{
    public class HomeController : Controller
    {

        UsuarioVM usuarioVM = new UsuarioVM();

        public async Task<IActionResult> Index()
        {
            List<Usuario> usuarios = new List<Usuario>();
            HttpClient cliente = usuarioVM.Initial();
            HttpResponseMessage res = await cliente.GetAsync("api/usuario");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                usuarios = JsonConvert.DeserializeObject<List<Usuario>>(results);
            }
            return View(usuarios);
        }

        public async Task<IActionResult> Detalles(int Id)
        {
            var usuario = new Usuario();
            HttpClient cliente = usuarioVM.Initial();
            HttpResponseMessage res = await cliente.GetAsync($"api/usuario/{Id}");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                usuario = JsonConvert.DeserializeObject<Usuario>(results);

            }
            return View(usuario);
        }


       

        public async Task<IActionResult> Editar(int Id)
        {
            var usuario = new Usuario();
            HttpClient cliente = usuarioVM.Initial();
            HttpResponseMessage res = await cliente.GetAsync($"api/usuario/{Id}");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                usuario = JsonConvert.DeserializeObject<Usuario>(results);

            }
            return View(usuario);
        }

        [HttpPost]
        public IActionResult Editar(Usuario usuario)
        {
            HttpClient cliente = usuarioVM.Initial();
            var putTask = cliente.PutAsJsonAsync<Usuario>("api/usuario/"+usuario.Id, usuario);
            putTask.Wait();
            var result = putTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();



        }

        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Usuario usuario)
        {
            HttpClient cliente = usuarioVM.Initial();
            var postTask = cliente.PostAsJsonAsync<Usuario>("api/usuario", usuario);
            postTask.Wait();
            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();



        }

        public async Task<IActionResult> Borrar(int id)
        {
            var usuario = new Usuario();
            HttpClient cliente = usuarioVM.Initial();
            HttpResponseMessage res = await cliente.DeleteAsync($"api/usuario/{id}");

            return RedirectToAction("Index");
        }

    




        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
