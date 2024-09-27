using DWP0_PRAC_IV_CB100420.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace DWP0_PRAC_IV_CB100420.ViewModes;
public class EmpleadoVM
{
    //Primera propiedad publica hacia nuestro modelo empleado

    public Empleado oEmpleado { get; set; }
    //otras propiedad tipo lista utilizamos razor 
    public List<SelectListItem> oListaCargo { get; set; }
}