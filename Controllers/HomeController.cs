using DWP0_PRAC_IV_CB100420.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using DWP0_PRAC_IV_CB100420.ViewModes;
using System.Collections.Generic;
namespace DWP0_PRAC_IV_CB100420.Controllers
{
    public class HomeController : Controller
    {
        private readonly DbcrudcoreContext _DBContext;

        public HomeController(DbcrudcoreContext context)
        {
            _DBContext = context;
        }

        public IActionResult Index()//implementamos logica
        {//Creamos listas de empleados 
            List<Empleado> lista = _DBContext.Empleados.Include(c => c.oCargo).ToList();
            return View(lista); //le pasamos la lista a nuestra vista
        }

        public IActionResult Privacy()
        {

            return View();
        }
        [HttpGet]
        public IActionResult Empleado_Detalle()
        {
            //creamos un objeto
            EmpleadoVM oEmpleadoVM = new EmpleadoVM()
            {
                //le pasamos un empleado vacio 
                oEmpleado = new Empleado(),
                oListaCargo = _DBContext.Cargos.Select(Cargo => new SelectListItem()
                {
                    Text = Cargo.Descripcion,
                    Value = Cargo.IdCargo.ToString()
                }).ToList()
            };
            return View(oEmpleadoVM); //le pasamos la lista a nuestra vista
        }

        [HttpPost]
        public IActionResult Empleado_Detalle(EmpleadoVM oEmpleadoVM) //metodo para guardar empleado en la bd
        {
            if (oEmpleadoVM.oEmpleado.IdEmpleado == 0)
            {

                _DBContext.Empleados.Add(oEmpleadoVM.oEmpleado);//aqui lo guardamos temporalmente 
            }
            _DBContext.SaveChanges(); //Escribimos en la BD

            return RedirectToAction("Index", "Home");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
