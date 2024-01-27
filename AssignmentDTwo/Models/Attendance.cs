namespace AssignmentDTwo.Models
{
    public class Attendance
    {
        public int TraineeID { get; set; }
        public DateTime Date { get; set; }
        public virtual Trainee Trainee { get; set; }
        public int InstructorID { get; set; }
        public virtual Instructor Instructor { get; set; }
    }
}
