using Seguros.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Seguros.Controllers
{
	public class LoguinController : Controller
	{
		private Model1 db = new Model1();
		// GET: Loguin
		public ActionResult Loguin()
		{
			return View();
		}

		// GET: Loguin/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: Loguin/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: Loguin/Create
		[HttpGet]
		public async Task<ActionResult> SingUp(string usuario, string pass)
        {
            

				var val = validar(usuario,pass);
				if (val)
				{

				return RedirectToAction("Polizas", "Polizas");
			}
				else
				{
					return Loguin();
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
