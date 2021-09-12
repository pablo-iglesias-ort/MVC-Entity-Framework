using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_Scaffolding_Validaciones_Routing.Data;
using MVC_Scaffolding_Validaciones_Routing.Models;

namespace MVC_Scaffolding_Validaciones_Routing.Controllers
{
    public class EstudianteController : Controller
    {
        private readonly MVC_Scaffolding_Validaciones_RoutingContext _context;
        static readonly List<Estudiante> estudiantes = new List<Estudiante>() 
        {
            { 
                new Estudiante()
                {
                    Id = Guid.NewGuid(),
                    Apellido = "Iglesias",
                    Nombre = "Pablo",
                    Dni = 12312312
                }
            },
            {
                new Estudiante()
                {
                    Id = Guid.NewGuid(),
                    Apellido = "Gomez",
                    Nombre = "Jose",
                    Dni = 33312312
                }
            },
        };

        public EstudianteController(MVC_Scaffolding_Validaciones_RoutingContext context)
        {
            _context = context;            
        }

        // GET: Estudiante
        public async Task<IActionResult> Index()
        {            
            return View(estudiantes);
            //return View(await _context.Estudiante.ToListAsync());
        }

        // GET: Estudiante/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var estudiante = await _context.Estudiante.FirstOrDefaultAsync(m => m.Id == id);
            var estudiante = estudiantes.FirstOrDefault(e => e.Id == id);
            if (estudiante == null)
            {
                return NotFound();
            }

            return View(estudiante);
        }

        // GET: Estudiante/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Estudiante/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Dni,Nombre,Apellido")] Estudiante estudiante)
        {
            if (ModelState.IsValid)
            {
                estudiante.Id = Guid.NewGuid();
                //_context.Add(estudiante);
                //await _context.SaveChangesAsync();
                estudiantes.Add(estudiante);
                return RedirectToAction(nameof(Index));
            }
            return View(estudiante);
        }

        // GET: Estudiante/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var estudiante = await _context.Estudiante.FindAsync(id);
            var estudiante = estudiantes.FirstOrDefault(e => e.Id == id);
            if (estudiante == null)
            {
                return NotFound();
            }
            return View(estudiante);
        }

        // POST: Estudiante/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Dni,Nombre,Apellido")] Estudiante estudiante)
        {
            if (id != estudiante.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //_context.Update(estudiante);
                    //await _context.SaveChangesAsync();
                    var estudianteExistente = estudiantes.FirstOrDefault(e => e.Id == id);
                    estudianteExistente.Apellido = estudiante.Apellido;
                    estudianteExistente.Nombre = estudiante.Nombre;
                    estudianteExistente.Dni = estudiante.Dni;
                }
                //catch (DbUpdateConcurrencyException)
                catch (Exception)
                {
                    if (!EstudianteExists(estudiante.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(estudiante);
        }

        // GET: Estudiante/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

			//var estudiante = await _context.Estudiante.FirstOrDefaultAsync(m => m.Id == id);
			var estudiante = estudiantes.FirstOrDefault(e => e.Id == id);

            if (estudiante == null)
            {
                return NotFound();
            }

            return View(estudiante);
        }

        // POST: Estudiante/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            //var estudiante = await _context.Estudiante.FindAsync(id);
            //_context.Estudiante.Remove(estudiante);
            //await _context.SaveChangesAsync();
            if (id == null)
            {
                return NotFound();
            }
            var estudiante = estudiantes.FirstOrDefault(e => e.Id == id);

            if (estudiante == null)
            {
                return NotFound();
            }
            estudiantes.RemoveAll(e => e.Id == id);

            return RedirectToAction(nameof(Index));
        }

        private bool EstudianteExists(Guid id)
        {
            return estudiantes.Exists(e => e.Id == id);
            //return _context.Estudiante.Any(e => e.Id == id);
        }
    }
}
