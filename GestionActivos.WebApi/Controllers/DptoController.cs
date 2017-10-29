
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
    public class DptoController : Controller
    {
        HttpClient clientAreas;
        string urlAreas = "http://localhost:50142/api/Area";
        HttpClient clientCiudades;
        string urlCiudades= "http://localhost:50142/api/Ciudad";
        public DptoController()
        {
            InitializeAreas();
            InitializeCiudades();
        }

        private void InitializeAreas()
        {
            clientAreas = new HttpClient();
            clientAreas.BaseAddress = new Uri(urlAreas);
            clientAreas.DefaultRequestHeaders.Accept.Clear();
            clientAreas.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        private void InitializeCiudades()
        {
            clientCiudades = new HttpClient();
            clientCiudades.BaseAddress = new Uri(urlCiudades);
            clientCiudades.DefaultRequestHeaders.Accept.Clear();
            clientCiudades.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

        }
        // GET: Areas
        public async Task<ActionResult> Index()
        {
            HttpResponseMessage responseMessage = await clientAreas.GetAsync(urlAreas);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                var areas = JsonConvert.DeserializeObject<List<AreaDto>>(responseData);
                return View(areas);
            }
            return View("Error");
        }

        // GET: Areas/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Areas/Create
        public async  Task<ActionResult> Create()
        {
            HttpResponseMessage responseMessage = await clientCiudades.GetAsync(urlCiudades);

            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                var ciudades = JsonConvert.DeserializeObject<List<CiudadDto>>(responseData);
                ViewBag.CiudadId = new SelectList(ciudades, "CiudadId", "Nombre");
            }
            return View();
        }

        // POST: Areas/Create
        [HttpPost]
        public async Task<ActionResult> Create(AreaDto newarea)
        {
            try
            {
                // TODO: Add insert logic here
                HttpResponseMessage responseMessage = await clientAreas.PostAsJsonAsync(urlAreas, newarea);
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

        // GET: Areas/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Areas/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Areas/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Areas/Delete/5
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
