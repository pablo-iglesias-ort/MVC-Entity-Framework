using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Entity_Framework.Models
{
	public class Contacto
	{
		// Propiedades de la entidad

		[Key]
		public Guid Id { get; set; }

		[Required]
		[EmailAddress]
		public string Email { get; set; }

		public int Celular { get; set; }

		[MaxLength(50, ErrorMessage = "El maximo permitido para la cuenta de {0} es {1}")]
		public string Instagram { get; set; }

		[MaxLength(40, ErrorMessage = "El maximo permitido para la cuenta de {0} es {1}")]
		public string Twitter { get; set; }

		[MaxLength(30, ErrorMessage = "El maximo permitido para la cuenta de {0} es {1}")]
		public string Facebook { get; set; }



		// Relaciones con otras entidades

		[ForeignKey(nameof(Estudiante))]
		public Guid EstudianteId { get; set; }
		public Estudiante Estudiante { get; set; }
	}
}
