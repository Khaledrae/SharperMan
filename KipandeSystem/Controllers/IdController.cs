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
        public ActionResult<IdDTO> SearchId(int IdNo)
        {
            if (IdNo <= 0)
                return BadRequest();

            Id ids = IdRepository.IdRepo.FirstOrDefault(n => n.IdNo == IdNo);
            if (ids != null)
            {
                int AgentId = ids.Agency;
                Agent agent = AgentRepository.AgentRepo.FirstOrDefault(o => o.AgentId == AgentId);
                if (agent != null)
                {
                    IdDTO idDTO = new()
                    {
                        IdNo = ids.IdNo,
                        FirstName = ids.FirstName,
                        LastName = ids.LastName,
                        DateOfIssue = ids.DateOfIssue,
                        SerialNo = ids.SerialNo,
                        AgencyId = agent.AgentId,
                        AgencyName = agent.AgentName,
                        AgencyTel = agent.AgentTel
                    };
                    return Ok(idDTO);
                }
                else
                    return NotFound();
            }
            else
                return NotFound($"id {ids} not found");
        }
        [HttpPost("save", Name = "SaveNewId")]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(typeof(int), 500)]
        public ActionResult<Id> SaveNewId([FromBody]Id dto)
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
