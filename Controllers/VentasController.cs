using Microsoft.AspNetCore.Mvc;
using ProyectoExamen.DTOs;
using ProyectoExamen.Services;

namespace ProyectoExamen.Controllers
{
    public class VentasController : Controller
    {
        private readonly IVentaService _service;

        public VentasController(IVentaService service)
        {
            _service = service;
        }

        // hacemos get a las ventas
        public async Task<IActionResult> Index(string filtro)
        {
            IEnumerable<VentaDTO> ventas;

            if (string.IsNullOrEmpty(filtro))
            {
                ventas = await _service.GetAllVentasAsync();
            }
            else
            {
                ventas = await _service.GetVentasByProductoAsync(filtro);
            }

            ViewBag.Filtro = filtro;
            return View(ventas);
        }

        // aqui get ventas crearte
        public IActionResult Create()
        {
            return View();
        }

        // post ventas create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VentaDTO ventaDto)
        {
            if (!ModelState.IsValid)
            {
                return View(ventaDto);
            }

            var (success, message) = await _service.CreateVentaAsync(ventaDto);

            if (!success)
            {
                ModelState.AddModelError("", message);
                return View(ventaDto);
            }

            TempData["Success"] = message;
            return RedirectToAction(nameof(Index));
        }

        // y post ventas delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteVentaAsync(id);
            TempData["Success"] = "Venta eliminada correctamente";
            return RedirectToAction(nameof(Index));
        }
    }
}
