using AspNetCore.Raw.Attributes;
using AspNetCore.Raw.DTOs.Requests;
using AspNetCore.Raw.DTOs.Responses;

namespace AspNetCore.Raw.Controllers.Custom
{
    public sealed class CustomController : ControllerBase
    {
        [Route("api/post")]
        public CustomDtoResponse Post(CustomDtoRequest request)
        {
            return new CustomDtoResponse(request.Name);
        }
    }
}
