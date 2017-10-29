using GestionActivos.Dtos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace GestionActivos.WebApi.Controllers
{
    public class ActivosController : Controller
    {
        HttpClient client;
        string url = "http://localhost:50142/api/Activo";
        HttpClient clientAreas;
        string urlAreas = "http://localhost:50142/api/Area";
        HttpClient clientTiposActivo;
        string urlTiposActivo = "http://localhost:50142/api/TipoActivo";
        HttpClient clientPersonas;
        string urlPersonas = "http://localhost:50142/api/Persona";
        public ActivosController()
        {
            InitializeActivos();
            InitializeAreas();
            InitializePersonas();
            InitializeTiposActivo();
        }

        private void InitializeActivos()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

        }

        private void InitializeAreas()
        {
            clientAreas = new HttpClient();
            clientAreas.BaseAddress = new Uri(urlAreas);
            clientAreas.DefaultRequestHeaders.Accept.Clear();
            clientAreas.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }


        private void InitializeTiposActivo()
        {
            clientTiposActivo = new HttpClient();
            clientTiposActivo.BaseAddress = new Uri(urlTiposActivo);
            clientTiposActivo.DefaultRequestHeaders.Accept.Clear();
            clientTiposActivo.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        private void InitializePersonas()
        {
            clientPersonas = new HttpClient();
            clientPersonas.BaseAddress = new Uri(urlPersonas);
            clientPersonas.DefaultRequestHeaders.Accept.Clear();
            clientPersonas.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }
        // GET: Activos
        public async Task<ActionResult> Index()
        {
            HttpResponseMessage responseMessage = await client.GetAsync(url);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                var ciudades = JsonConvert.DeserializeObject<List<ActivosDto>>(responseData);
                return View(ciudades);
            }
            return View("Error");
        }

        // GET: Activos/Details/5
        public async Task<ActionResult> Details(int id)
        {
            HttpResponseMessage responseMessage = await client.GetAsync(url + "/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                var activo = JsonConvert.DeserializeObject<ActivosDto>(responseData);
                return View(activo);
            }
            return View("Error");
        }

        // GET: Activos/Create
        public async Task<ActionResult> Create()
        {
            HttpResponseMessage responseMessageTiposActivos = await clientTiposActivo.GetAsync(urlTiposActivo);
            HttpResponseMessage responseMessageAreas = await clientTiposActivo.GetAsync(urlAreas);
            HttpResponseMessage responseMessagePersonas = await clientTiposActivo.GetAsync(urlPersonas);

            if (responseMessageTiposActivos.IsSuccessStatusCode & responseMessagePersonas.IsSuccessStatusCode & responseMessageAreas.IsSuccessStatusCode)
            {
                var responseDataTiposActivo = responseMessageTiposActivos.Content.ReadAsStringAsync().Result;
                var tiposActivos = JsonConvert.DeserializeObject<List<TipoActivosDto>>(responseDataTiposActivo);
                ViewBag.TipoActivoId = new SelectList(tiposActivos, "TipoActivoId", "Nombre");

                var responseDataAreas = responseMessageAreas.Content.ReadAsStringAsync().Result;
                var areas = JsonConvert.DeserializeObject<List<AreaDto>>(responseDataAreas);
                ViewBag.AreaId = new SelectList(areas, "AreaId", "Nombre");

                var responseDataPersonas = responseMessagePersonas.Content.ReadAsStringAsync().Result;
                var personas = JsonConvert.DeserializeObject<List<PersonaDto>>(responseDataPersonas);
                ViewBag.PersonaId = new SelectList(personas, "PersonaId", "Nombre");
            }
            return View();
        }



        // POST: Activos/Create
        [HttpPost]
        public async Task<ActionResult> Create(ActivosDto activos)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    HttpResponseMessage responseMessage = await clientAreas.PostAsJsonAsync(url, activos);
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                    return RedirectToAction("Error");
                }

                HttpResponseMessage responseMessageTiposActivos = await clientTiposActivo.GetAsync(urlTiposActivo);
                HttpResponseMessage responseMessageAreas = await clientTiposActivo.GetAsync(urlAreas);
                HttpResponseMessage responseMessagePersonas = await clientTiposActivo.GetAsync(urlPersonas);

                if (responseMessageTiposActivos.IsSuccessStatusCode & responseMessagePersonas.IsSuccessStatusCode & responseMessageAreas.IsSuccessStatusCode)
                {
                    var responseDataTiposActivo = responseMessageTiposActivos.Content.ReadAsStringAsync().Result;
                    var tiposActivos = JsonConvert.DeserializeObject<List<TipoActivosDto>>(responseDataTiposActivo);
                    ViewBag.TipoActivoId = new SelectList(tiposActivos, "TipoActivoId", "Nombre");

                    var responseDataAreas = responseMessageAreas.Content.ReadAsStringAsync().Result;
                    var areas = JsonConvert.DeserializeObject<List<AreaDto>>(responseDataAreas);
                    ViewBag.AreaId = new SelectList(areas, "AreaId", "Nombre");

                    var responseDataPersonas = responseMessagePersonas.Content.ReadAsStringAsync().Result;
                    var personas = JsonConvert.DeserializeObject<List<PersonaDto>>(responseDataPersonas);
                    ViewBag.PersonaId = new SelectList(personas, "PersonaId", "Nombre");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Activos/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            HttpResponseMessage responseMessage = await client.GetAsync(url+"/"+id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                var activo = JsonConvert.DeserializeObject<ActivosDto>(responseData);
                return View(activo);
            }
            return View("Error");
        }

        // POST: Activos/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, ActivosDto activo)
        {
            try
            {
                // TODO: Add update logic here
                HttpResponseMessage responseMessage = await client.PutAsJsonAsync(url + "/" + id, activo);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Error");
            }
            catch
            {
                return View();
            }
        }

        // GET: Activos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Activos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
