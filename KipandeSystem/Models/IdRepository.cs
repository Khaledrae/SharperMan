namespace KipandeSystem.Models
{
    public class IdRepository
    {
        public static List<Id> IdRepo { get; set; } =
            [
                new Id
                {
                    IdNo = 45,
                    DateOfIssue = "12-02-2021",
                    LastName = "Matta",
                    Agency =   7,
                    FirstName = "Julius",
                    SerialNo =59040322,
                    Status = "Lost"
                },
                new () {
                    IdNo = 34,
                    DateOfIssue = "12-02-2011",
                    LastName = "Kimani",
                    Agency =   8,
                    FirstName = "Jane",
                    SerialNo = 43495932,
                    Status = "Found"
                }
            ];
    }
}
