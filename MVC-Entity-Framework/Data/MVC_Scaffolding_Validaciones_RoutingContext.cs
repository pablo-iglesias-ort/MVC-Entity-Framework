using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVC_Scaffolding_Validaciones_Routing.Models;

namespace MVC_Scaffolding_Validaciones_Routing.Data
{
    public class MVC_Scaffolding_Validaciones_RoutingContext : DbContext
    {
        public MVC_Scaffolding_Validaciones_RoutingContext (DbContextOptions<MVC_Scaffolding_Validaciones_RoutingContext> options)
            : base(options)
        {
        }

        public DbSet<MVC_Scaffolding_Validaciones_Routing.Models.Estudiante> Estudiante { get; set; }
    }
}
