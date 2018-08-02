using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Seguros.Models;

namespace Seguros.Controllers
{
    public class PolizasController : Controller
    {
        // GET: Polizas
        public ActionResult Polizas()
        {
            return View();
        }
		[HttpPost]
		public async Task<ActionResult> Crear(Poliza cd)
		{
			HttpResponseMessage response = new HttpResponseMessage();
			try
			{
		
			}
			catch (Exception ex)
			{
				System.Console.WriteLine(ex.Message);
			}
			return View(response);
		}
		private static HttpClient GetClient()
		{
			HttpClient client = new HttpClient(new HttpClientHandler() { UseDefaultCredentials = true });
			client.BaseAddress = new Uri(ConfigurationManager.AppSettings["ApiUrl"]);
			return client;
		}
	}
}