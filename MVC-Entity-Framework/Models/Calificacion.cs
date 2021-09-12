using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Entity_Framework.Models
{
	public class Calificacion
	{
		// Propiedades de la entidad

		[Key]
		public Guid Id { get; set; }

		[Required(ErrorMessage = "Este campo es obligatorio")]
		public int Valor { get; set; }


		// Relaciones con otras entidades

		[Required]
		[ForeignKey(nameof(Materia))]
		public Guid MateriaId { get; set; }
		public Materia Materia { get; set; }

		[Required]
		[ForeignKey(nameof(Estudiante))]
		public Guid EstudianteId { get; set; }
		public Estudiante Estudiante { get; set; }
	}
}
