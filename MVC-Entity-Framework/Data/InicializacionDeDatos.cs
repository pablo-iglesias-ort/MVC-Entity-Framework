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

			using (var transaccion = context.Database.BeginTransaction())
			{
				try
				{
					if (context.MateriasEstudiantes.Any())
					{
						// Si ya hay datos aqui, significa que ya los hemos creado previamente
						return;
					}

					var nuevoEstudiante = new Estudiante();
					nuevoEstudiante.Apellido = "Iglesias";
					nuevoEstudiante.Nombre = "Pablo";
					nuevoEstudiante.Id = Guid.NewGuid();
					nuevoEstudiante.FechaDeNacimiento = DateTime.Now.Date;
					nuevoEstudiante.Dni = 1234;
					context.Estudiantes.Add(nuevoEstudiante);

					var nuevaMateria = new Materia();
					nuevaMateria.Id = Guid.NewGuid();
					nuevaMateria.Nombre = "PNT1";
					context.Materias.Add(nuevaMateria);
					context.SaveChanges();

					var estudiante = context.Estudiantes.First();
					var materia = context.Materias.First();

					var relacionMateriaEstudiante = new MateriaEstudiante();

					relacionMateriaEstudiante.Id = Guid.NewGuid();
					relacionMateriaEstudiante.EstudianteId = estudiante.Id;
					relacionMateriaEstudiante.MateriaId = materia.Id;

					context.MateriasEstudiantes.Add(relacionMateriaEstudiante);
					context.SaveChanges();

					transaccion.Commit();
				}
				catch
				{
					transaccion.Rollback();
				}
			}			

		}
	}
}
