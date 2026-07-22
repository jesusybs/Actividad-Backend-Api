using Microsoft.AspNetCore.Mvc;
using BackendApi.Models; // models del usuario
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

    [HttpGet("{id}")]//get
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
    [HttpPost] //es un envio, un post
    public IActionResult RegistrarUsuario([FromBody] Usuario usuario)
    {
        return Ok(new
        {
            mensaje = "Usuario registrado correctamente",
            usuario
        });
    }
    [HttpPut("{id}")]//put, q vamos a editar
    public IActionResult ActualizarUsuario(int id, [FromBody] Usuario usuario)
    {
        usuario.Id = id;
        return Ok(new
        {
            mensaje = "Usuario actualizado",
            usuario
        });
    }
    [HttpDelete("{id}")]
    public IActionResult EliminarUsuario(int id)
    {
        return Ok(new
        {
            mensaje = $"Usuario {id} eliminado correctamente"
        });
    }

}