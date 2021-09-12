using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Entity_Framework.Models
{
	public class MateriaEstudiante
	{
		// Propiedades de la entidad

		[Key]
		public Guid Id { get; set; }


		// Relaciones con otras entidades

		[Required]
		[ForeignKey(nameof(MateriaId))]
		public Guid MateriaId { get; set; }
		public Materia Materia { get; set; }

		[Required]
		[ForeignKey(nameof(EstudianteId))]
		public Guid EstudianteId { get; set; }
		public Estudiante Estudiante { get; set; }
	}
}
