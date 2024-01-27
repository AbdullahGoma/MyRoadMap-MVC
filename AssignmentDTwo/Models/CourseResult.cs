namespace AssignmentDTwo.Models
{
    public class CourseResult
    {
        public int Id { get; set; }
        public double Degree { get; set; }
        public int CourseID { get; set; }
        public Course Course { get; set; }
        public int TraineeID { get; set; }
        public Trainee Trainee { get; set; }
    }
}
