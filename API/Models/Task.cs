namespace API.Models
{
    public class Tasks
    {
        public int id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; } 
        public DateTime Duedate { get; set; }
        public string Status { get; set; }
        public string Assignee { get; set; }
    }
}

