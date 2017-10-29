
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
    public class CiudadesController : Controller
    {
        HttpClient client;
        string url = "http://localhost:50142/api/Ciudad";
        public CiudadesController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }
        // GET: Ciudades
        public async Task<ActionResult> Index()
        {
            HttpResponseMessage responseMessage = await client.GetAsync(url);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                var ciudades = JsonConvert.DeserializeObject<List<CiudadDto>>(responseData);
                return View(ciudades);
            }
            return View("Error");
        }

        // GET: Ciudades/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Ciudades/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ciudades/Create
        [HttpPost]
        public async Task<ActionResult> Create(CiudadDto ciudad)
        {
            try
            {
                // TODO: Add insert logic here
                HttpResponseMessage responseMessage = await client.PostAsJsonAsync(url, ciudad);
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

        // GET: Ciudades/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Ciudades/Edit/5
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

        // GET: Ciudades/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Ciudades/Delete/5
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
