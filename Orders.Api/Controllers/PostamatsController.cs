using Microsoft.AspNetCore.Mvc;
using Orders.BusinessLogic.Services.Postamats.Interfaces;

namespace Orders.Api.Controllers
{
    [Route("postamats")]
    [ApiController]
    public class PostamatsController : ControllerBase
    {
        private readonly IPostamatsService _postamatsService;

        public PostamatsController(
            IPostamatsService postamatsService
            )
        {
            _postamatsService = postamatsService;
        }

        [HttpGet("{postamatId}")]
        public IActionResult GetOrder(string postamatId)
        {
            var postamat = _postamatsService.GetPostamat(postamatId);
            if (postamat == null)
                return NotFound();

            return Ok(postamat);
        }
    }
}
