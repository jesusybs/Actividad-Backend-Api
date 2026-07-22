using Microsoft.AspNetCore.Mvc; //Permite utlizar controladores,rutas y respuestas Http

namespace BackendApi.Controllers; 

[ApiController] //Inidica que la clase funcionara como un controlador de una API
[Route("api/[controller]")] //Define la ruta de una API
public class ClientesController : ControllerBase // Proporciona funciones de respuesta (Ok(), NotFound(), Badrequest())
{
    
    [HttpGet] //Indica que el metodo respondera a solicitudes GET
    public IActionResult ObtenerClientes()
    {
        var clientes = new[]
        {
            new
            {
            Id= 1,
            Nombre = "Juan M",
            Telefono= "77777776"
            },
            new
            {
            Id= 2,
            Nombre = "Maria Becerra",
            Telefono= "77777778"
            },
            new
            {
            Id= 3,
            Nombre = "Carlos Martinez",
            Telefono= "77777779"
            }
        };
        return Ok(clientes);
        
    }
    [HttpGet("{id}")] //get
    public IActionResult ObtenerClientePorId(int id)
    {
        var cliente = new
        {
            Id= id,
            Nombre = "Cliente Ejemplo",
            Telefono= "70000000"
        };
        return Ok(cliente);
    }
    [HttpPost] //es un envio, un post
    public IActionResult RegistrarCliente([FromBody] Cliente cliente)
    {
        return Ok(new
        {
            mensaje = "Cliente registrado correctamente",cliente
        });
    }
    [HttpPut("{id}")]//put, q vamos a editar
    public IActionResult ActualizarCliente(int id, [FromBody] Cliente cliente)
    {
        cliente.Id = id;
        return Ok(new
        {
            mensaje = "Cliente actualizado",cliente
        });
    }


}