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
		public DataAccess.DataAccess data = new DataAccess.DataAccess();

		public ActionResult Clientes()
		{


			return View();
		}
		public ActionResult ListarCliente()
		{


			return View(Listar());
		}
		public ActionResult EditarCliente(int id)
		{
			return View(ConsultarCliente(id));
		}


		public Cliente ConsultarCliente(int id)
		{
			var pol = new Cliente();
			HttpResponseMessage response = new HttpResponseMessage();
			try
			{
				return data.ConsultarCliente(id).FirstOrDefault();
			}
			catch (Exception ex)
			{
				throw;
			}

		}

		public IEnumerable<Cliente> Listar()
		{

			try
			{
				return data.ListarClientes();
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
				

					data.CrearCliente(cd);


				
			}
			catch (Exception ex)
			{
				System.Console.WriteLine(ex.Message);
			}
			return View(response);
		}
		[HttpPost]
		public async Task<ActionResult> EditarCL(Cliente cd)
		{

			try
			{
				data.EditarCliente(cd);
				return View();

			}
			catch (Exception ex)
			{
				throw;
			}
		}
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