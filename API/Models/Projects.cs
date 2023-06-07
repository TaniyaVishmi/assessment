namespace API.Models
{
    public class Projects
    {
        public int id { get; set; }
        public string Projectname { get; set; }
        public DateTime Created { get; set; } = DateTime.UtcNow;
        public DateTime Duedate { get; set; }

    }
}
