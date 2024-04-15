namespace KipandeSystem.Models
{
    public class AgentRepository
    {
        public static List<Agent> AgentRepo { get; set; } =
            [
                new Agent{
                    AgentId = 7,
                    AgentLocation = "Tudor",
                    AgentCounty = 1,
                    AgentName = "Ma'ake Amina",
                    AgentTel = 732839402
                },
                new Agent{
                    AgentId = 8,
                    AgentLocation = "Kariobangi",
                    AgentCounty = 47,
                    AgentName = "Boasty",
                    AgentTel = 739940320
                },
            ];
    }
}
