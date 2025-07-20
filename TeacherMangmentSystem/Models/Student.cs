namespace TeacherMangmentSystem.Models;

public class Student
{
    private static int StudentCount { get; set; } = 0;
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Course> Courses { get; set; } = new List<Course>();

    public Student(string name)
    {
        Id = ++StudentCount;
        Name = name;
    }

    public void AddClass(Course course)
    {
        if (!Courses.Contains(course))
        {
            Courses.Add(course);
        }
    }

    public void RemoveClass(Course course)
    {
        if (Courses.Contains(course))
        {
            Courses.Remove(course);
        }
    }
}