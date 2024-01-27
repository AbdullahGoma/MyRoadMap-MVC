namespace AssignmentDTwo.Models
{
    public class Course
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public float Degree { get; set; }
        public float MinDegree { get; set; }
        public int DepartmentID { get; set; }
        // Navigation property
        public virtual Department Department { get; set; }

        public virtual ICollection<WorksFor> WorksFors { get; set; }
        public virtual ICollection<CourseResult> CourseResults { get; set; }
    }
}
