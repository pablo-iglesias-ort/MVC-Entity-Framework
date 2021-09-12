# MVC-Entity-Framework

Crear una carpeta en el directorio raiz que se llame "Data"
Definir una clase que herede de DbContext (using Microsoft.EntityFrameworkCore)

Usar el siguiente constructor como ejemplo:
public MVC_Entity_FrameworkContext (DbContextOptions<MVC_Entity_FrameworksContext> opciones): base(opciones)
{
}

Agregar un DbSet para cada entidad del modelo, como en el siguiente ejemplo:
public DbSet<Estudiante> Estudiante { get; set; }



Comados EF

