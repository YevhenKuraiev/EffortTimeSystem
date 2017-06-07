namespace ETS.Contracts.DataContracts
{
    public class TaskEntity
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public ProjectEntity Project { get; set; }
    }
}
