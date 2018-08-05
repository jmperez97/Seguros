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
    public class ClientesXpolizaController : Controller
    {
		public DataAccess.DataAccess data = new DataAccess.DataAccess();
        // GET: ClientesXpoliza
        public ActionResult ClientesXpoliza()
        {
			ViewData["Polizas"] = data.ListarPolizas();
			ViewData["Clientes"] = data.ListarClientes();

			return View(data.ListarClientesXPoliza());
        }
		[HttpPost]
		public async Task<ActionResult> Crear(ClientesXpoliza cd)
		{
			HttpResponseMessage response = new HttpResponseMessage();
			try
			{
				cd.InicioVigencia = DateTime.Now;

				data.crearClientesXpoliza(cd);



			}
			catch (Exception ex)
			{
				System.Console.WriteLine(ex.Message);
			}
			return View(response);
		}
		[HttpGet]
		public async Task<ActionResult>  Desactivar(int id)
		{
			data.ActualizarClientesXpoliza(id);

			return View(data.ListarClientesXPoliza());
		}

	}
}