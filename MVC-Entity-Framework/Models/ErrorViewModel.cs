using System;
using System.Collections.Generic;
using System.Linq;

namespace MVC_Entity_Framework.Models
{
	public class ErrorViewModel
	{
		public string RequestId { get; set; }

		public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

		public int Sumar(int x, int y)
		{
			return x + y;
		}

		public int SumarConLambdas(int x, int y) => x + y;

		public void OtroMetodo()
		{
			var listaDeNombres = new List<string>();
			listaDeNombres.Add("Pablo");
			listaDeNombres.Add("Jose");
			listaDeNombres.Add("Pedro");
			listaDeNombres.Add("Raul");
			listaDeNombres.Add("Tomas");

			var existe = ExisteUnNombre(listaDeNombres, "Pedro");
		}

		private bool ExisteUnNombre(List<string> listaDeNombres, string nombre)
		{
			int i = 0;
			while (i < listaDeNombres.Count)
			{
				if (listaDeNombres[i] == nombre)
				{
					return true;
				}
				i++;
			}
			return false;
		}

		private bool ExisteUnNombreConLinq(List<string> listaDeNombres, string nombre)
		{			
			return listaDeNombres.Any(n => n == nombre);
		}

		public class Persona
		{
			public int Dni { get; set; }
			public string Nombre { get; set; }
			public string Apellido { get; set; }
		}

		private bool ExistePersona(List<Persona> listaDePersonas, Persona persona)
		{
			int i = 0;
			while (i < listaDePersonas.Count)
			{
				if (listaDePersonas[i].Dni == persona.Dni)
				{
					return true;
				}
				i++;
			}
			return false;
		}

		private bool ExistePersonaConLinq(List<Persona> listaDePersonas, Persona persona)
		{
			return listaDePersonas.Any(x => x.Dni == persona.Dni);
		}

		private List<Persona> BuscarPersonasConApellido(List<Persona> listaDePersonas, string apellido)
		{
			int i = 0;
			List<Persona> personasARetornar = new List<Persona>();

			foreach (var item in listaDePersonas)
			{
				if (item.Apellido == apellido)
				{
					personasARetornar.Add(item);
				}
			}
			return personasARetornar;
		}

		private List<Persona> BuscarPersonasConApellidoConLinq(List<Persona> listaDePersonas, string apellido)
		{
			return listaDePersonas.Where(n => n.Apellido == apellido).ToList();
		}

		private Persona BuscarPersonasConDni(List<Persona> listaDePersonas, int dni)
		{
			//return listaDePersonas.First(n => n.Dni == dni);
			return listaDePersonas.FirstOrDefault(n => n.Dni == dni);
		}

		private List<string> ObtenerNombresDePersonas(List<Persona> listaDePersonas)
		{
			int i = 0;
			var	nombres = new List<string>();

			foreach (var item in listaDePersonas)
			{
				nombres.Add(item.Nombre);
			}
			return nombres;
		}

		private List<string> ObtenerApellidosDePersonas(List<Persona> listaDePersonas)
		{
			int i = 0;
			var apellidos = new List<string>();

			foreach (var item in listaDePersonas)
			{
				apellidos.Add(item.Apellido);
			}
			return apellidos;
		}


		private List<string> ObtenerNombresDePersonasConLinq(List<Persona> listaDePersonas)
		{
			return listaDePersonas.Select(x => x.Nombre).ToList();
		}

		private List<string> ObtenerApellidosDePersonasConLinq(List<Persona> listaDePersonas)
		{
			return listaDePersonas.Select(x => x.Apellido).ToList();
		}

		public class NuevaClase 
		{
			public int MyProperty { get; set; }
			public string OtherProperty { get; set; }

			public NuevaClase(int myProperty, string otherProperty)
			{
				this.MyProperty = myProperty;
				this.OtherProperty = otherProperty;
			}

		}

		private List<NuevaClase> Prueba2(List<Persona> listaDePersonas)
		{
			return listaDePersonas.Select(x => new NuevaClase(1,x.Apellido)).ToList();
		}


		private string BuscarNombreDePersonaConDni(List<Persona> listaDePersonas, int dni)
		{
			return listaDePersonas.Where(x => x.Dni == dni).Select(p => p.Nombre).FirstOrDefault();
		}
	}
}
