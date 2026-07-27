using Microsoft.AspNetCore.Mvc;
using BackendApi.Models; // models del usuario
namespace BackendApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuariosController : ControllerBase
{
    //bd puente
    private readonly AppDbContext _context;

    //recibe bd y la guarda
    public UsuariosController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult ObtenerUsuarios()
    {
        var lista = _context.Usuarios.ToList();
        return Ok(lista);
    }

    [HttpGet("{id}")]
    public IActionResult ObtenerUsuarioPorId(int id)
    {
        var usuario = _context.Usuarios.Find(id);

        if (usuario == null) return NotFound("No existe ese usuario");
        return Ok(usuario);
    }

    [HttpPost]
    public IActionResult RegistrarUsuario([FromBody] Usuario usuario)
    {
        _context.Usuarios.Add(usuario);
        _context.SaveChanges();

        return Ok(new { mensaje = "Guardado con éxito", usuario });
    }

    [HttpPut("{id}")]
    public IActionResult ActualizarUsuario(int id, [FromBody] Usuario usuarioActualizado)
    {
        var usuario = _context.Usuarios.Find(id);
        if (usuario == null) return NotFound("No existe");

        usuario.Nombre = usuarioActualizado.Nombre;
        usuario.Email = usuarioActualizado.Email;

        _context.SaveChanges();

        return Ok(new { mensaje = "Actualizado", usuario });
    }

    [HttpDelete("{id}")]
    public IActionResult EliminarUsuario(int id)
    {
        var usuario = _context.Usuarios.Find(id);
        if (usuario == null) return NotFound("No existe");

        _context.Usuarios.Remove(usuario);
        _context.SaveChanges();

        return Ok(new { mensaje = "Eliminado" });
    }
}