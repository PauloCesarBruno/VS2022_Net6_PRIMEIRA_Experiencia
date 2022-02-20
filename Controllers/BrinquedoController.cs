using Brinquedos_NET6.Models;
using Brinquedos_NET6.Models.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Brinquedos_NET6.Controllers
{
    public class BrinquedoController : Controller
    {
        private readonly DataContext _context;

        public BrinquedoController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Brinquedos.ToListAsync());
        }

        [HttpGet]
        public IActionResult Criar()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        [HttpPost]
        public async Task<IActionResult> Criar(Brinquedo model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(model);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IActionResult> Detalhes(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var brinquedo = await _context.Brinquedos.FindAsync(id);
            if (brinquedo == null)
            {
                return NotFound();
            }
            return View(brinquedo);
        }

        [HttpGet]
        public IActionResult Atualizar(int? Id)
        {
            try
            {
                if (Id != null)
                {
                    #pragma warning disable CS8600 // Conversão de literal nula ou possível valor nulo em tipo não anulável.
                    Brinquedo model = _context.Brinquedos.Find(Id);
                    #pragma warning restore CS8600 // Conversão de literal nula ou possível valor nulo em tipo não anulável.
                    return View(model);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Atualizar(int? Id, Brinquedo model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (Id != null)
                    {
                        _context.Update(model);
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        return View(model);
                    }
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Excluir(int? Id)
        {
            try
            {
                if (Id != null)
                {
                    #pragma warning disable CS8600 // Conversão de literal nula ou possível valor nulo em tipo não anulável.
                    Brinquedo model = _context.Brinquedos.Find(Id);
                    #pragma warning restore CS8600 // Conversão de literal nula ou possível valor nulo em tipo não anulável.
                    return View(model);
                }
                else
                {
                    return NotFound();
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        [HttpPost]
        public async Task <IActionResult> Excluir(int? Id, Brinquedo model)
        {
            try
            {
                if (Id != null)
                {
                    _context.Brinquedos.Remove(model);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return NotFound();
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
