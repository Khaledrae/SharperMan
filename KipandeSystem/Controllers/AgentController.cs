using KipandeSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace KipandeSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentController : ControllerBase

    {
        [HttpGet]
        public IEnumerable<Agent> GetAgents() {
            return AgentRepository.AgentRepo;
        }
    }
}
