using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Scaffolding_Validaciones_Routing.Models
{
	public class Estudiante
	{
		[Required]
		public Guid Id { get; set; }

		public int Dni { get; set; }

		[Required]
		public string Nombre { get; set; }

		[Required(ErrorMessage = "Debe ingresar el apellido")]
		public string Apellido { get; set; }
	}
}
