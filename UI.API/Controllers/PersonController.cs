using Core.Abstracts.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private IPersonService _service;

        public PersonController(IPersonService service)
        {
            _service=service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.GetPeopleForList());
        }
    }
}
