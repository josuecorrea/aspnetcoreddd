using Microsoft.AspNetCore.Mvc;
using Project.Accounting.Service.Domain.Commom;

namespace Project.Accounting.Service.Api.Controllers
{
    public class DefaultController : ControllerBase
    {
        protected async Task<ObjectResult> DefaultResponse<T>(BaseResult<T> result, int successStatusCode)
        {
            if (result.Error)
            {
                return StatusCode(400, result);
            }
            else if (result.Result is null)
            {
                return StatusCode(404, null);
            }

            return StatusCode(successStatusCode, result);
        }
    }
}