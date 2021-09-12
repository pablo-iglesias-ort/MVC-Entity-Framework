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


Agregar el siguiente package al proyecto: Microsoft.EntityFrameworkCore.Design version 3.1.15 3.1.9

Ir a Herramientas > Administrador de paquetes NuGet > Consola del Administrador de paquetes y ejecutar el siguiente comando
dotnet tool install --global dotnet-ef --version 3.1.15
posicionarse en la carpeta del proyecto: cd RUTA-DEL-PROYECTO
dotnet ef migrations add "Version_Inicial"
dotnet ef database update


