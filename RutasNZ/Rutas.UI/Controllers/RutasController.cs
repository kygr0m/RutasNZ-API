using Microsoft.AspNetCore.Mvc;

namespace Rutas.UI.Controllers
{
    using global::Rutas.UI.Models;
    using global::Rutas.UI.Models.DTO;
    using Microsoft.AspNetCore.Mvc;
    using System.Reflection;
    using System.Text;
    using System.Text.Json;

    namespace Rutas.UI.Controllers
    {
        public class RutasController : Controller
        {
            private readonly IHttpClientFactory httpClientFactory;

            public RutasController(IHttpClientFactory httpClientFactory)
            {
                this.httpClientFactory = httpClientFactory;
            }

            public async Task<IActionResult> Index()
            {
                List<RutaDto> respuesta = new List<RutaDto>();
                try
                {
                    var cliente = httpClientFactory.CreateClient();

                    var respuestaHtpp = await cliente.GetAsync("http://localhost:5105/api/Rutas");

                    respuestaHtpp.EnsureSuccessStatusCode();

                    respuesta.AddRange(await respuestaHtpp.Content.ReadFromJsonAsync<IEnumerable<RutaDto>>());
                }
                catch (Exception ex)
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
            public async Task<IActionResult> Agregar(AgregarRutaVista modelo)
            {
                var cliente = httpClientFactory.CreateClient();
                var respuestaHtpp = new HttpRequestMessage()
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri("http://localhost:5105/api/Rutas"),
                    Content = new StringContent(JsonSerializer.Serialize(modelo), Encoding.UTF8, "application/json")
                };

                var respuestaMensajeHtpp = await cliente.SendAsync(respuestaHtpp);

                respuestaMensajeHtpp.EnsureSuccessStatusCode();

                var respuesta = await respuestaMensajeHtpp.Content.ReadFromJsonAsync<RutaDto>();

                if (respuesta != null)
                {
                    return RedirectToAction("Index", "Rutas");
                }

                return View();
            }

            [HttpGet]
            public async Task<IActionResult> Editar(Guid id)
            {
                var cliente = httpClientFactory.CreateClient();
                var ruta_entera = $"http://localhost:5105/api/Rutas/{id}";
                var respuesta = await cliente.GetFromJsonAsync<RutaDto>(ruta_entera);

                if (respuesta != null)
                {
                    return View(respuesta);
                }

                return View(null);
            }

            [HttpPost]
            public async Task<IActionResult> Editar(RutaDto peticion)
            {
                var cliente = httpClientFactory.CreateClient();
                var httpPeticion = new HttpRequestMessage()
                {
                    Method = HttpMethod.Put,
                    RequestUri = new Uri($"http://localhost:5105/api/Rutas/{peticion.Id_ruta}"),
                    Content = new StringContent(JsonSerializer.Serialize(peticion), Encoding.UTF8, "application/json")
                };
                var httpRespuesta = await cliente.SendAsync(httpPeticion);
                httpRespuesta.EnsureSuccessStatusCode();

                var respuesta = await httpRespuesta.Content.ReadFromJsonAsync<RutaDto>();
                if (respuesta != null)
                {
                    return RedirectToAction("Index", "Rutas");
                }

                return View();
            }

            [HttpPost]
            public async Task<IActionResult> Eliminar(RutaDto respuesta)
            {
                try
                {
                    var cliente = httpClientFactory.CreateClient();
                    var httpsRespuesta = await cliente.DeleteAsync($"http://localhost:5105/api/Rutas/{respuesta.Id_ruta}");
                    httpsRespuesta.EnsureSuccessStatusCode();
                    return RedirectToAction("Index", "Rutas");
                }
                catch (Exception ex)
                {

                }

                return View("Editar");
            }
        }
    }
}
