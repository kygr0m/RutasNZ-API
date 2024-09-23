using Microsoft.AspNetCore.Mvc;
using Rutas.UI.Models;
using Rutas.UI.Models.DTO;
using System.Reflection;
using System.Text;
using System.Text.Json;

namespace Rutas.UI.Controllers
{
    public class RegionesController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;

        public RegionesController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            List<RegionDto> respuesta = new List<RegionDto>();
            try
            {
                var cliente = httpClientFactory.CreateClient();

                var respuestaHtpp = await cliente.GetAsync("http://localhost:5105/api/Region");

                respuestaHtpp.EnsureSuccessStatusCode();

                 respuesta.AddRange(await respuestaHtpp.Content.ReadFromJsonAsync<IEnumerable<RegionDto>>());

               
            }
            catch (Exception ex )
            {

                
            }
            
            return View(respuesta);
        }


        [HttpGet]
        public IActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Agregar(AgregarRegionVista modelo)
        {
            var cliente = httpClientFactory.CreateClient();
            var respuestaHtpp = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("http://localhost:5105/api/Region"),
                Content = new StringContent(JsonSerializer.Serialize(modelo), Encoding.UTF8, "application/json")
            };

            var respuestaMensajeHtpp = await cliente.SendAsync(respuestaHtpp);

            respuestaMensajeHtpp.EnsureSuccessStatusCode();

            var respuesta = await respuestaMensajeHtpp.Content.ReadFromJsonAsync<RegionDto>();

            

            if (respuesta != null)
            {
                return RedirectToAction("Index", "Regiones");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Editar (Guid id)
        {
           
            var cliente = httpClientFactory.CreateClient();
            var respuesta = await cliente.GetFromJsonAsync<RegionDto>($"http://localhost:5105/api/Region/{id.ToString()}");

                if (respuesta != null)
                {
                return View(respuesta);
                }


            return View(null);

        }

        [HttpPost]
        public async Task<IActionResult> Editar (RegionDto peticion)
        {
            var cliente = httpClientFactory.CreateClient();
            var httpPeticion = new HttpRequestMessage()
            {
                Method = HttpMethod.Put,
                RequestUri = new Uri($"http://localhost:5105/api/Region/{peticion.Id_Region}"),
                Content = new StringContent(JsonSerializer.Serialize(peticion), Encoding.UTF8, "application/json")
            };
           var httpRespuesta =  await cliente.SendAsync(httpPeticion);
            httpRespuesta.EnsureSuccessStatusCode();

            var respuesta = await httpRespuesta.Content.ReadFromJsonAsync<RegionDto>();
            if(respuesta != null)
            {
                return RedirectToAction("Index", "Regiones");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Eliminar(RegionDto respuesta)
        {
            try
            {
                var cliente = httpClientFactory.CreateClient();
                var httpsRespuesta = await cliente.DeleteAsync($"http://localhost:5105/api/Region/{respuesta.Id_Region}");
                httpsRespuesta.EnsureSuccessStatusCode();
                return RedirectToAction("Index", "Regiones");
            }
            catch (Exception ex)
            {

             
            }

            return View("Editar");
            
        }
    }
}
