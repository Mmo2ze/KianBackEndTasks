namespace TeacherMangmentSystem.Models;

public class Course
{
    private static int ClassCount { get; set; } = 0;
    public int Id { get; set; }
    public string Subject { get; set; }
    public int TeacherId { get; set; } = 0;
    public Grade  Grade { get; set; }

    public Course(string subject,Grade grade)
    {
        Id = ++ClassCount;
        Subject = subject;
        Grade = grade;
    }




}