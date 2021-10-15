using Microsoft.AspNetCore.Hosting;
using MVC_Entity_Framework.Data;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace MVC_Entity_Framework
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var host = CreateHostBuilder(args).Build();

			InicializarDatos(host);

			host.Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>();
				});

		public static void InicializarDatos(IHost host)
		{			
			using (var scope = host.Services.CreateScope())
			{
				var services = scope.ServiceProvider;
				var context = services.GetRequiredService<MVC_Entity_FrameworkContext>();
				InicializacionDeDatos.Inicializar(context);				
			}
		}
	}
}
