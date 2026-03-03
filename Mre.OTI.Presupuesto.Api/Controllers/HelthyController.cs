using Microsoft.AspNetCore.Mvc;

namespace Mre.OTI.Presupuesto.Api.Controllers
{
    [Route("v1/rree/spp/presupuesto/seg/helthy")]
    [ApiController]
    public class HealtyController : ControllerBase
    {

        [HttpGet]
        //[Authorize]
        public IActionResult Helthy()
        {
            return Ok("Helthy**");
        }
    }
}
