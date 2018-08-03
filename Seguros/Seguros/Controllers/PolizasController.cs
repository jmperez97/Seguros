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
			ViewBag.Message = "Test";
			return View();
        }
		public ActionResult ListarPolizas()
		{

			
			return View(Listar());
		}

		public ActionResult Editar(int id)
		{


			return View(Listar());
		}

		public ActionResult EditarPoliza(int id)
		{			
			return View(ConsultarPoliza(id));
		}
		private Model1 db = new Model1();
		[HttpPost]
		public async Task<ActionResult> Crear(Poliza cd)
		{
			HttpResponseMessage response = new HttpResponseMessage();
			try
			{
				using (var db = new Model1())
				{
				
						db.Polizas.Add(cd);
						db.SaveChanges();		
					
					
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
		public  IEnumerable<Poliza> Listar()
		{
			HttpResponseMessage response = new HttpResponseMessage();
			try
			{
				using (var db = new Model1())
				{

					return db.Polizas.ToList();


				}
			}
			catch (Exception ex)
			{
				throw;
			}
			
		}
		public Poliza ConsultarPoliza(int id)
		{
			var pol = new Poliza();
			HttpResponseMessage response = new HttpResponseMessage();
			try
			{
				using (var db = new Model1())
				{

					var tem = db.Polizas.ToList().Where(x => x.idPoliza == id).ToList();

					return tem.FirstOrDefault();


				}
			}
			catch (Exception ex)
			{
				throw;
			}

		}


	}
}