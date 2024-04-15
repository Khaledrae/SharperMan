using KipandeSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace KipandeSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdController : ControllerBase
    {
        [HttpGet]
        [Route("All", Name = "GetAllIds")]
        public ActionResult<IEnumerable<Id>> GetIds()
        {
            return Ok(IdRepository.IdRepo);
        }
        //Search Agency
        [HttpGet("search")]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(typeof(int), 404)]
        [ProducesResponseType(typeof(int), 500)]
        public ActionResult<Agent> whoHasMyId(int agentId)
        {
            if (agentId <= 0)
                return BadRequest();
            Agent ag = AgentRepository.AgentRepo.FirstOrDefault(n => n.AgentId == agentId);
            if (ag != null)
                return Ok(ag);
            else
            {
                return NotFound();
            }
        }
        [HttpGet("{IdNo}", Name = "SearchId")]
        public ActionResult<Id> SearchId(int IdNo)
        {
            if (IdNo <= 0)
                return BadRequest();

            Id ids = IdRepository.IdRepo.FirstOrDefault(n => n.IdNo == IdNo);
            if (ids != null)
            {
                /*int AgentId = ids.Agency;
                Agent agent = AgentRepository.AgentRepo.FirstOrDefault( o => o.AgentId == AgentId);
                if (agent != null) 
                    return Ok(agent);
                else
                    return NotFound();
                */
                return Ok(ids);
            }
            else
                return NotFound($"id {ids} not found");
        }
        [HttpPost("save", Name = "SaveNewId")]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(typeof(int), 500)]
        public ActionResult<IdDTO> SaveNewId([FromBody]IdDTO dto)
        {
            if (dto ==  null)
                return BadRequest();
            Id id = new Id
            {
                IdNo = dto.IdNo,
                DateOfIssue = dto.DateOfIssue,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                SerialNo = dto.SerialNo,
            };
            IdRepository.IdRepo.Add(id);

            return Ok(id);
        }
        
    }
}
