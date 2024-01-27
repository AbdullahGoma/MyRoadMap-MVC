namespace AssignmentDTwo.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int InstructorID { get; set; }
        public virtual Instructor Instructor { get; set; }
    }
}
