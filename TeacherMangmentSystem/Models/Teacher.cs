namespace TeacherMangmentSystem.Models;

public class Teacher
{
    private static int TeacherCount { get; set; } = 0;
    public int Id { get; set; }
    public string Name { get; set; }
    public Course Course { get; set; }
    public Teacher(string teacherName , string subject)
    {
        Course course = new Course(subject);
        Id = ++TeacherCount;
        Name = teacherName;
        course.TeacherId = Id;
        Course = course;
    }
    
    
}