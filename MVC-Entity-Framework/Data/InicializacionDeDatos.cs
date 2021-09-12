using MVC_Entity_Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Entity_Framework.Data
{
	public static class InicializacionDeDatos
	{
		public static void Inicializar(MVC_Entity_FrameworkContext context)
		{
			context.Database.EnsureCreated();

			if (context.MateriasEstudiantes.Any())
			{
				// Si ya hay datos aqui, significa que ya los hemos creado previamente
				return;
			}

			var estudiante = context.Estudiantes.First();
			var materia = context.Materias.First();

			var relacionMateriaEstudiante = new MateriaEstudiante();

			relacionMateriaEstudiante.Id = Guid.NewGuid();
			relacionMateriaEstudiante.EstudianteId = estudiante.Id;
			relacionMateriaEstudiante.MateriaId = materia.Id;

			context.MateriasEstudiantes.Add(relacionMateriaEstudiante);
			context.SaveChanges();
		}
	}
}
