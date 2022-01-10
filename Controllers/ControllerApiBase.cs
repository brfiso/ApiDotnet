using Microsoft.AspNetCore.Mvc;

namespace AulaApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public abstract class ControllerApiBase : ControllerBase
    {
        public string RetornaMensagemApi()
        {
            return "Mensagem API";
        }
    }
}
