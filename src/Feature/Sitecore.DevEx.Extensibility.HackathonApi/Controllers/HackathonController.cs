using Sitecore.DevEx.Extensibility.HackathonApi.Services;
using System.Diagnostics.CodeAnalysis;
using System.Web.Http;


namespace Sitecore.DevEx.Extensibility.HackathonApi.Controllers
{
    [Authorize]
    [RoutePrefix("sitecore/api/hackathon")]
    [ExcludeFromCodeCoverage]
    public class HackathonController : ApiController
    {
        private readonly IHackathonApiService _apiService;

        public HackathonController(IHackathonApiService apiService)
        {
            _apiService = apiService;
        }
        public HackathonController( )
        {
            
        }


        [HttpPost]
        [Route("clearcache")]
        public IHttpActionResult ClearCache()
        {
            var result = _apiService.ClearCache();
            return Json(result);
        }
    }
}