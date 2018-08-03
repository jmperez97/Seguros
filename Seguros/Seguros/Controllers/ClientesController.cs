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
    public class ClientesController : Controller
    {
        private Model1 db = new Model1();

		public ActionResult Clientes()
		{


			return View();
		}
		public ActionResult ListarCliente()
		{


			return View(Listar());
		}
		public IEnumerable<Cliente> Listar()
		{
			HttpResponseMessage response = new HttpResponseMessage();
			try
			{
				using (var db = new Model1())
				{

					return db.Clientes.ToList();


				}
			}
			catch (Exception ex)
			{
				throw;
			}

		}

		[HttpPost]
		public async Task<ActionResult> Crear(Cliente cd)
		{
			HttpResponseMessage response = new HttpResponseMessage();
			try
			{
				using (var db = new Model1())
				{

					db.Clientes.Add(cd);
					db.SaveChanges();


				}
			}
			catch (Exception ex)
			{
				System.Console.WriteLine(ex.Message);
			}
			return View(response);
		}

	}
}