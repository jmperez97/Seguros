using Seguros.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Seguros.DataAccess
{
	public class DataAccess
	{
		public bool GuardarPoliza(Poliza cd)
		{
			try
			{
				using (var db = new Model1())
				{

					db.Polizas.Add(cd);
					db.SaveChanges();
					return true;

				}

			}
			catch (Exception)
			{

				return false;
			}



		}
		public IEnumerable<Poliza> ListarPolizas()
		{

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
		public IEnumerable<Cliente> ListarClientes()
		{

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
		public IEnumerable<Poliza> ConsultarPoliza(int id)
		{

			try
			{

				using (var db = new Model1())
				{

					var tem = db.Polizas.ToList().Where(x => x.idPoliza == id).ToList();

					return tem;


				}
			}
			catch (Exception ex)
			{
				throw;
			}

		}
		public bool CrearCliente(Cliente cd)
		{

			try
			{
				using (var db = new Model1())
				{

					db.Clientes.Add(cd);
					db.SaveChanges();

					return true;
				}
			}
			catch (Exception ex)
			{
				return false;
			}

		}


		public  bool EditarPoliza(Poliza cd)
		{
			try
			{
				using (var db = new Model1())
				{
					var temp = db.Polizas.ToList().Where(x => x.idPoliza == cd.idPoliza).FirstOrDefault();
					temp = cd;
					db.SaveChanges();
				}
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}
		public bool EditarCliente(Cliente cd)
		{
			try
			{
				using (var db = new Model1())
				{
					var temp = db.Clientes.ToList().Where(x => x.idCliente == cd.idCliente).FirstOrDefault();
					temp = cd;
					db.SaveChanges();
				}
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}
		public IEnumerable<Cliente> ConsultarCliente(int id)
		{

			try
			{

				using (var db = new Model1())
				{

					var tem = db.Clientes.ToList().Where(x => x.idCliente == id).ToList();

					return tem;


				}
			}
			catch (Exception ex)
			{
				throw;
			}

		}

	}

}

