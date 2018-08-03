using Seguros.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Seguros.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return RedirectToAction("Loguin", "Loguin");
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
		[HttpGet]
		public async Task<ActionResult> SingUp(string usuario, string pass)
		{
			// var me= new  HttpRequestMessage()

			var val = validar(usuario, pass);
			if (val)
			{
				//HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, val);
				//return RedirectToAction("Polizas", "Polizas");
				return RedirectToAction("Polizas", "Polizas");
			}
			else
			{
				return View();
			}


		}
		public static bool validar(string usuario, string pass)
		{
			try
			{
				using (var db = new Model1())
				{
					var temp = db.usuarios.Where(x => x.login == usuario && x.password == pass).FirstOrDefault();
					if (temp.idUsuario.ToString() != string.Empty)
					{
						return true;
					}
					else
					{
						return false;
					}
				}
			}

			catch (Exception ex)
			{
				return false;
			}
		}
	}
}