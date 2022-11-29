using Microsoft.AspNetCore.Mvc;
using UsuariosApi.Data.Dto;

namespace UsuariosApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CadastroController : ControllerBase
    {
        [HttpPost]
        public IActionResult CadastraUsuario(CreateUsuarioDto createUsuarioDto)
        {
            return Ok();
        }
    }
}
