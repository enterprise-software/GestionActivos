
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
    public class TipoActivosController : Controller
    {
        HttpClient client;
        string url = "http://localhost:50142/api/TipoActivo";
        public TipoActivosController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }
        // GET: TipoActivoMVC
        public async Task<ActionResult> Index()
        {
            HttpResponseMessage responseMessage = await client.GetAsync(url);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                var tipoActivos = JsonConvert.DeserializeObject<List<TipoActivosDto>>(responseData);
                return View(tipoActivos);
            }
            return View("Error");
        }

        // GET: TipoActivoMVC/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TipoActivoMVC/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoActivoMVC/Create
        [HttpPost]
        public async Task<ActionResult> Create(TipoActivosDto tiposActivo)
        {
            try
            {
                // TODO: Add insert logic here
                HttpResponseMessage responseMessage = await client.PostAsJsonAsync(url, tiposActivo);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "TipoActivos");
                }
                return RedirectToAction("Error");
            }
            catch
            {
                return View();
            }
        }

        // GET: TipoActivoMVC/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TipoActivoMVC/Edit/5
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

        // GET: TipoActivoMVC/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TipoActivoMVC/Delete/5
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
