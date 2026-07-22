using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ServiciosController : ControllerBase
{
    [HttpGet]
    public IActionResult ObtenerServicios()
    {
        var servicios = new[]
        {
            new
            {
                Id = 1,
                Nombre = "Mantenimiento Preventivo",
                Precio = 100.00,
                Categoria = "Soporte"
            },
            new
            {
                Id = 2,
                Nombre = "Reparación de Hardware",
                Precio = 250.00,
                Categoria = "Técnico"
            },
            new
            {
                Id = 3,
                Nombre = "Instalación de Software",
                Precio = 150.00,
                Categoria = "Software"
            },
            new
            {
                Id = 4,
                Nombre = "Consultoría IT",
                Precio = 120.00,
                Categoria = "Consultoría"
            },
            new
            {
                Id = 5,
                Nombre = "Limpieza de Virus",
                Precio = 200.00,
                Categoria = "Seguridad"
            }
        };
        return Ok(servicios);
    }

    [HttpGet("{id}")]
    public IActionResult ObtenerServicioPorId(int id)
    {
        var servicio = new
        {
            Id = id,
            Nombre = "Servicio Ejemplo",
            Precio = 0.00,
            Categoria = "General"
        };
        return Ok(servicio);
    }
}