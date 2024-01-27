namespace AssignmentDTwo.Models
{
    public class WorksFor
    {
        public int ID { get; set; }
        public Instructor Instructor { get; set; }
        public Course Course { get; set; }
    }
}
