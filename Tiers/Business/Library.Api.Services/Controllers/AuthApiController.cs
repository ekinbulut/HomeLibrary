using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Library.Api.Objects;

namespace Library.Api.Services.Controllers
{
    [RoutePrefix("api/auth")]
    [AllowAnonymous]
    public class AuthApiController : BaseApiController
    {
        [Route("gettoken")]
        [HttpPost]
        public AuthOutputDto GetToken(AuthInputDto input)
        {
            //TODO : do authentication and set principles

            return null;
        }
    }
}
