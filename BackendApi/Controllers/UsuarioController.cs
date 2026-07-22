using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers;

[ApiController]
[Route("api/[controller]")] 
public class UsuariosController : ControllerBase 
{

    [HttpGet] 
    public IActionResult ObtenerUsuarios()
    {
        var usuarios = new[]
        {
            new
            {
                Id = 1,
                Nombre = "Admin",
                Email = "admin@coffe.com"
            },
            new
            {
                Id = 2,
                Nombre = "Usuario Normal",
                Email = "usuario@coffe.com"
            },
            new
            {
                Id = 3,
                Nombre = "Invitado",
                Email = "invitado@coffe.com"
            }
        };
        return Ok(usuarios);

    }

    [HttpGet("{id}")]
    public IActionResult ObtenerUsuarioPorId(int id)
    {
        var usuario = new
        {
            Id = id,
            Nombre = "Usuario Ejemplo",
            Email = "ejemplo@coffe.com"
        };
        return Ok(usuario);
    }

}