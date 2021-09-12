using Microsoft.EntityFrameworkCore;
using MVC_Entity_Framework.Models;

namespace MVC_Entity_Framework.Data
{
    public class MVC_Entity_FrameworkContext : DbContext
    {
        public MVC_Entity_FrameworkContext (DbContextOptions<MVC_Entity_FrameworkContext> opciones) : base(opciones)
        {
        }

        public DbSet<Calificacion> Calificaciones { get; set; }
        public DbSet<Contacto> Contactos { get; set; }
        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Materia> Materias { get; set; }
        public DbSet<MateriaEstudiante> MateriasEstudiantes { get; set; }
    }
}
