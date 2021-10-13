using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_Entity_Framework.Data;
using MVC_Entity_Framework.Models;

namespace MVC_Entity_Framework.Controllers
{
    public class MateriasController : Controller
    {
        private readonly MVC_Entity_FrameworkContext _context;

        public MateriasController(MVC_Entity_FrameworkContext context)
        {
            _context = context;
        }

        // GET: Materias
        public async Task<IActionResult> Index()
        {
            return View(await _context.Materias.ToListAsync());
        }

        // GET: Materias/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materia = _context.Materias.FirstOrDefault(mat => mat.Id == id);
            if (materia == null)
            {
                return NotFound();
            }

            return View(materia);
        }

        // GET: Materias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Materias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre")] Materia materia)
        {
            if (ModelState.IsValid)
            {
                materia.Id = Guid.NewGuid();
                _context.Add(materia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(materia);
        }

        // GET: Materias/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materia = await _context.Materias.FindAsync(id);
            if (materia == null)
            {
                return NotFound();
            }
            return View(materia);
        }

        // POST: Materias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Nombre")] Materia materia)
        {
            if (id != materia.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(materia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MateriaExists(materia.Id))
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
            return View(materia);
        }

        // GET: Materias/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materia = await _context.Materias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (materia == null)
            {
                return NotFound();
            }

            return View(materia);
        }

        // POST: Materias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var materia = await _context.Materias.FindAsync(id);
            _context.Materias.Remove(materia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MateriaExists(Guid id)
        {
            return _context.Materias.Any(e => e.Id == id);
        }


        List<string> Nombres = new List<string>() { "Jose", "Francisco", "Pablo", "Franco", "Jose", "Francisco", "Paula", "Juana" };
        List<int> Valores = new List<int>() { 3, 4, 25, 90, -10, 0, 44 };
        List<Materia> Materias = new List<Materia>() {
            { new Materia(){ Id = Guid.NewGuid(), Nombre = "PNT1" } },
            { new Materia(){ Id = Guid.NewGuid(), Nombre = "THP" } },
            { new Materia(){ Id = Guid.NewGuid(), Nombre = "P1" } },
            { new Materia(){ Id = Guid.NewGuid(), Nombre = "TP1" } },
        };

        private List<string> ObtenerNombresDeMaterias(List<Materia> materias)
        {
            List<string> resultado = new List<string>();
			foreach (var materia in materias)
			{
                resultado.Add(materia.Nombre);
			}
            return resultado;
        }

        public class NombreMateria
        {
            public string Nombre { get; set; }
            public NombreMateria(string nombre) 
            {
                Nombre = nombre;
            }
        }

        private List<string> ObtenerNombresDeMateriasConLINQ(List<Materia> materias)
        {
            return materias.Select(m => m.Nombre).ToList();
        }

        private List<NombreMateria> ObtenerNombresDeMateriasConLINQ2(List<Materia> materias)
        {
            return materias.Select(m => new NombreMateria(m.Nombre)).ToList();
        }

        private string BuscarNombre(string nombreABuscar)
        {
            int i = 0;
            string nombreEncontrado = null;
            while(i < Nombres.Count && nombreEncontrado == null)
            {
                if (Nombres[i] == nombreABuscar)
                {
                    nombreEncontrado = Nombres[i];
                }
                i++;
            }
            return nombreEncontrado;
        }

        private string BuscarNombreConLINQ(string nombreABuscar)
        {
            //return Nombres.Where(n => n == nombreABuscar).ToList();
            return Nombres.First(n => n == nombreABuscar);
        }

        private bool ExisteValor(int valorABuscar)
        {
            int i = 0;
            bool valorEncontrado = false;
            while (i < Nombres.Count && !valorEncontrado)
            {
                if (Valores[i] == valorABuscar)
                {
                    valorEncontrado = true;
                }
                i++;
            }
            return valorEncontrado;
        }

        private bool ExisteValorConLINQ(int valorABuscar)
        {
            return Valores.Any(v => v == valorABuscar);
            //return Valores.Any();
        }

        private List<int> ValoresMayoresA(int valor)
        {
            int i = 0;
            List<int> valores = new List<int>();
            while (i < Valores.Count)
            {
                if (Valores[i] > valor)
                {
                    valores.Add(Valores[i]);
                }
                i++;
            }
            return valores;
        }

        private List<int> ValoresMayoresAConLINQ(int valor)
        {
            //var resultado = Valores.Where(v => v > valor);
            //return resultado.ToList();

            return Valores.Where(v => v > valor).ToList();

        }

        private List<int> ValoresMenoresA(int valor)
        {
            int i = 0;
            List<int> valores = new List<int>();
            while (i < Valores.Count)
            {
                if (Valores[i] < valor)
                {
                    valores.Add(Valores[i]);
                }
                i++;
            }
            return valores;
        }

        private List<int> ValoresMenoresAConLINQ(int valor)
        {        
            return Valores.Where(v => v < valor).ToList();
        }


        private List<int> ValoresMenoresAYMultiplosDe2(int valor)
        {
            int i = 0;
            List<int> valores = new List<int>();
            while (i < Valores.Count)
            {
                if (Valores[i] < valor && Valores[i] % 2 == 0)
                {
                    valores.Add(Valores[i]);
                }
                i++;
            }
            return valores;
        }

        private List<int> ValoresMenoresAYMultiplosDe2ConLINQ(int valor)
        {
            return Valores.Where(v => v < valor && v % 2 == 0).ToList();
        }

    }
}
