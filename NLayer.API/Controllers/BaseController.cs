using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTO_S;
namespace NLayer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        [NonAction]
        public IActionResult CreateActionResult<T>(CustomResponseDTO<T> response)
        {
            if (response.StatusCode == 204)
                return new ObjectResult(null)
                {
                    StatusCode = response.StatusCode
                };


            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode
            };
        }
    }
}
