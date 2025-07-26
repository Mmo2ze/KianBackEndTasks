namespace TeacherMangmentSystem.Models;

public class Teacher
{
    private static int TeacherCount { get; set; } = 0;
    public int Id { get; set; }
    public string Name { get; set; }
    public Course Course { get; set; }
    public Grade  Grade { get; set; }
    public Teacher(string teacherName , string subject,Grade grade)
    {
        Course course = new Course(subject,grade);
        Id = ++TeacherCount;
        Name = teacherName;
        course.TeacherId = Id;
        Course = course;
        Grade = grade;
    }
        
    
    
}