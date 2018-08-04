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
using Seguros.DataAccess;

namespace Seguros.Controllers
{
    public class PolizasController : Controller
    {
		// GET: Polizas
		public DataAccess.DataAccess data = new DataAccess.DataAccess();
        public ActionResult Polizas()
        {
			ViewBag.Message = "Test";
			return View();
        }
		public ActionResult ListarPolizas()
		{

			
			return View(data.ListarPolizas());
		}

		public ActionResult Editar(int id)
		{


			return View(data.ListarPolizas());
		}

		public ActionResult EditarPoliza(int id)
		{			
			return View(ConsultarPoliza(id));
		}

		[HttpPost]
		public async Task<ActionResult> Crear(Poliza cd)
		{
			HttpResponseMessage response = new HttpResponseMessage();
			try
			{
			var res=	data.GuardarPoliza(cd);
				if (res)
				{
					return RedirectToAction("Poliza", "ListarPolizas", new { area = "ListarPolizas" });
				}
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

		public Poliza ConsultarPoliza(int id)
		{
			var pol = new Poliza();
			HttpResponseMessage response = new HttpResponseMessage();
			try
			{
				return data.ConsultarPoliza(id).FirstOrDefault();
			}
			catch (Exception ex)
			{
				throw;
			}

		}
		[HttpPost]
		public async Task<ActionResult> EditarPoliza(Poliza cd)
		{

			try
			{
				 data.EditarPoliza(cd);
				return View();
				
			}
			catch (Exception ex)
			{
				throw;
			}	
		}


	}
}