using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Entity_Framework.Models
{
	public class Materia
	{
		// Propiedades de la entidad

		[Key]
		public Guid Id { get; set; }

		[Required(ErrorMessage = "Este campo es obligatorio")]
		public string Nombre { get; set; }


		// Relaciones con otras entidades

		public IEnumerable<MateriaEstudiante> Estudiantes { get; set; }

		public IEnumerable<Calificacion> Calificaciones { get; set; }
	}
}
