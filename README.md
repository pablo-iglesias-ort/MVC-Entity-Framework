# MVC-Entity-Framework

Crear una carpeta en el directorio raiz que se llame "Data"
Definir una clase que herede de DbContext (using Microsoft.EntityFrameworkCore)

Usar el siguiente constructor como ejemplo:
public MVC_Entity_FrameworkContext (DbContextOptions<MVC_Entity_FrameworksContext> opciones): base(opciones)
{
}

Agregar un DbSet para cada entidad del modelo, como en el siguiente ejemplo:
public DbSet<Estudiante> Estudiante { get; set; }

Ir a la clase StartUp y registrar el contexto, como en el siguiente ejemplo:
metodo -> public void ConfigureServices(IServiceCollection services)
  services.AddDbContext<MVC_Entity_FrameworkContext>(opciones => opciones.UseSqlite("filename=BaseDeDatos.db"));


Agregar el siguiente package al proyecto: Microsoft.EntityFrameworkCore.Design version 3.1.15

Ir a Herramientas > Administrador de paquetes NuGet > Consola del Administrador de paquetes y ejecutar el siguiente comando
dotnet tool install --global dotnet-ef --version 3.1.15
posicionarse en la carpeta del proyecto: cd RUTA-DEL-PROYECTO
dotnet ef migrations add "Version_Inicial"
dotnet ef database update

Si es necesario evolucionar la estructura de datos se pueden seguir agregnado migrations, pero en el caso particular de sqlite esto no es soportado al 100%, por lo cual
lo recomendado es:
1) Eliminar todos los archivos de la carpeta "Migrations" 
2) Ejecutar nuevamente el "migrations add"
3) Eliminar la Base de datos
4) Ejecutar nuevamente el "database update"
