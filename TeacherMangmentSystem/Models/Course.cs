namespace TeacherMangmentSystem.Models;

public class Course
{
    private static int ClassCount { get; set; } = 0;
    public int Id { get; set; }
    public string Subject { get; set; }
    public int TeacherId { get; set; } = 0;

    public Course(string subject)
    {
        Id = ++ClassCount;
        Subject = subject;
    }




}