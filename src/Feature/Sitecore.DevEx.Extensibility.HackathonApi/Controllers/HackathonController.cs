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
        private readonly IHackathonApiService _cacheService;

        public HackathonController(IHackathonApiService cacheService)
        {
            _cacheService = cacheService;
        }

 

        [HttpPost]
        [Route("global")]
        public IHttpActionResult ClearCache()
        {
            var result = "";// _cacheService.ClearAll();
            return Json(result);
        }
    }
}