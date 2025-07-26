namespace TeacherMangmentSystem.Models;

public class Student
{
    private static int StudentCount { get; set; } = 0;
    public int Id { get; set; }
    public string Name { get; set; }
    public Grade Grade { get; set; }
    public List<Course> Courses { get; set; } = new List<Course>();

    public Student(string name,Grade grade)
    {
        Id = ++StudentCount;
        Name = name;
        Grade = grade;
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