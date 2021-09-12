using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Entity_Framework.Models
{
	public class Estudiante
	{
		// Propiedades de la entidad

		[Key]
		public Guid Id { get; set; }

		[Required(ErrorMessage = "Este campo es requerido")]
		[Range(1,999999999, ErrorMessage = "El valor debe estar entre {1} y {2}")]
		public int Dni { get; set; }

		[Required(ErrorMessage = "El {0} es requerido")]
		[MaxLength(40, ErrorMessage = "El maximo permitido para el {0} es {1}")]
		public string Nombre { get; set; }

		[Required(ErrorMessage = "El {0} es requerido")]
		[MaxLength(80, ErrorMessage = "El maximo permitido para el {0} es {1}")]
		public string Apellido { get; set; }

		[Required(ErrorMessage = "Debe informar su fecha de nacimiento")]		
		[Display(Name = "Fecha de Nacimiento")]
		public DateTime FechaDeNacimiento { get; set; }


		// Relaciones con otras entidades

		[ForeignKey(nameof(ContactoId))]
		public Guid ContactoId { get; set; }
		public Contacto Contacto { get; set; }

		
		public IEnumerable<Calificacion> Calificaciones { get; set; }

		public IEnumerable<MateriaEstudiante> Materias { get; set; }
	}
}
