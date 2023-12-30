using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Accounting.Service.Application.UseCases.Account.Create.Response;
using Project.Accounting.Service.Domain.Commom;

namespace Project.Accounting.Service.Api.Controllers
{
    public class DefaultController : ControllerBase
    {
        protected async Task<ObjectResult> DefaultResponse<T>(BaseResult<T> result, int successStatusCode)
        {
            try
            {
                if (result.Error)
                {
                    return StatusCode(400, null);
                }
                else if (result.Result is null)
                {
                    return StatusCode(404, null);
                }

                return StatusCode(successStatusCode, result);
            }
            catch (Exception ex)
            {
                var errorResult = new BaseResult<CreatePersonResponse>(new CreatePersonResponse
                {
                    Created = false,
                }, true, new List<string> { ex.Message });

                return StatusCode(500, errorResult);
            }
        }
    }
}
