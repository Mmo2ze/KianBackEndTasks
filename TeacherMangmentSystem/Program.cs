﻿// See https://aka.ms/new-console-template for more information

using TeacherMangmentSystem.Models;

List<Teacher> teachers = [];
List<Student> students = [];
List<Course> courses = [];

void AddTeacher(string name, string subject, Grade grade)
{
    var teacher = new Teacher(name, subject, grade);
    teachers.Add(teacher);
    courses.Add(teacher.Course);
}

void AddStudent(string name, Grade grade)
{
    var student = new Student(name, grade);
    students.Add(student);
}

Grade SelectGrade()
{
    Console.WriteLine("Select Grade:\n" +
                      "1. First\n" +
                      "2. Second\n" +
                      "3. Third");
    var choice = Console.ReadKey();

    switch (choice.KeyChar)
    {
        case '1':
            return Grade.First;
        case '2':
            return Grade.Second;
        case '3':
            return Grade.Third;
        default:
            Console.WriteLine("\nInvalid choice.");
            return SelectGrade();
    }
}

Grade? SelectGradeOrAll()
{
    Console.WriteLine("Select Grade to view Teachers or press 'a' for All:\n" +
                      "1. First\n" +
                      "2. Second\n" +
                      "3. Third\n" +
                      "a. All");
    var choice = Console.ReadKey();
    switch (choice.KeyChar)
    {
        case '1':
            return Grade.First;
        case '2':
            return Grade.Second;
        case '3':
            return Grade.Third;
        case 'a':
        case 'A':
            return null; 
        default:
            Console.WriteLine("\nInvalid choice.");
            return SelectGradeOrAll();
    }


}

while (true)
{
    Console.WriteLine("-----------------------------------------------------------------------------------");
    Console.WriteLine($"1.Add Student \n" +
                      $"2.Add Teacher\n" +
                      $"3.Show Students\n" +
                      $"4.Show Teachers\n" +
                      $"5.Edit Student\n" +
                      $"6.Edit Teacher\n");
    Console.WriteLine("-----------------------------------------------------------------------------------");

    var choice = Console.ReadKey();
    switch (choice.KeyChar)
    {
        case '1':
        {
            Console.WriteLine("\nEnter Student Name:");
            var name = Console.ReadLine();
            if (!string.IsNullOrEmpty(name))
            {
                var grade = SelectGrade();
                AddStudent(name, grade);
                Console.WriteLine($"Student {name} added successfully.");
            }
            else
            {
                Console.WriteLine("Invalid name. Please try again.");
            }

            break;
        }
        case '2':
        {
            Console.WriteLine("\nEnter Teacher Name:");
            var name = Console.ReadLine();
            Console.WriteLine("Enter Subject:");
            var subject = Console.ReadLine();
            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(subject))
            {
                var grade = SelectGrade();
                AddTeacher(name, subject, grade);
                Console.WriteLine($"Teacher {name} added successfully.");
            }
            else
            {
                Console.WriteLine("Invalid name or subject. Please try again.");
            }

            break;
        }
        case '3':
        {
            var grade = SelectGradeOrAll();
            var filteredStudents = grade.HasValue
                ? students.Where(s => s.Grade == grade.Value).ToList()
                : students.OrderBy(s => s.Grade).ToList();
            Console.WriteLine("\nStudents List:");
            Console.WriteLine("ID\tName\tGrade");
            foreach (var student in filteredStudents)
            {
                var coursesSting = student.Courses.Count > 0
                    ? "Courses:" + string.Join(", ", student.Courses.Select(c => c.Subject))
                    : "No Classes";
                Console.WriteLine($"{student.Id}\t{student.Name}\t {coursesSting}\t {student.Grade}");
            }

            break;
        }
        case '4':
        {
            var grade = SelectGradeOrAll();
            var filteredTeachers = grade.HasValue
                ? teachers.Where(t => t.Grade == grade.Value).ToList()
                : teachers.OrderBy(t => t.Grade).ToList();


            Console.WriteLine("\nTeacher List:");
            Console.WriteLine("ID\tName\tSubject\tGrade");
            foreach (var teacher in filteredTeachers)
            {
                Console.WriteLine($"{teacher.Id}\t{teacher.Name}\t{teacher.Course.Subject}\t {teacher.Grade}");
            }

            break;
        }
        case '5':
        {
            Console.WriteLine("\nEnter Student ID to edit:");
            var sId = Console.ReadLine();
            try
            {
                var studentId = int.Parse(sId!);
                var student = students.FirstOrDefault(s => s.Id == studentId);
                if (student is null)
                    Console.WriteLine("Student not found.");
                else
                {
                    Console.WriteLine("1. Edit Name\n" +
                                      "2. Add Class\n" +
                                      "3. Remove Class" +
                                      "4. Delete student");
                    var editChoice = Console.ReadKey();
                    switch (editChoice.KeyChar)
                    {
                        case '1':
                        {
                            Console.WriteLine("\nEnter New Name:");
                            var newName = Console.ReadLine();
                            if (!string.IsNullOrEmpty(newName))
                            {
                                student.Name = newName;
                                Console.WriteLine($"Student name updated to {newName}.");
                            }
                            else
                            {
                                Console.WriteLine("Invalid name. Please try again.");
                            }

                            break;
                        }
                        case '2':
                        {
                            if (courses.Where(x => x.Grade == student.Grade).ToList().Count == 0)
                            {
                                Console.WriteLine("\nNo classes available to add. Please add a class first.");
                                break;
                            }
                            Console.WriteLine("\nAvailable Classes:");
                            foreach (var course in courses.Where(x => x.Grade == student.Grade))
                            {
                                Console.WriteLine($"{course.Id}. {course.Subject}");
                            }

                            Console.WriteLine("Enter Class ID to add:");
                            var classId = int.Parse(Console.ReadLine()!);
                            var courseToAdd = courses.FirstOrDefault(c => c.Id == classId);
                            if (courseToAdd != null)
                            {
                                student.AddClass(courseToAdd);
                                Console.WriteLine($"Class {courseToAdd.Subject} added to student {student.Name}.");
                            }
                            else
                            {
                                Console.WriteLine("Class not found.");
                            }

                            break;
                        }
                        case '3':
                        {
                            Console.WriteLine("\nClasses for this Student:");
                            foreach (var course in student.Courses)
                            {
                                Console.WriteLine($"{course.Id}. {course.Subject}");
                            }

                            Console.WriteLine("Enter Class ID to remove:");
                            var classId = int.Parse(Console.ReadLine() ?? "0");
                            var courseToRemove = student.Courses.FirstOrDefault(c => c.Id == classId);
                            if (courseToRemove != null)
                            {
                                student.RemoveClass(courseToRemove);
                                Console.WriteLine(
                                    $"Class {courseToRemove.Subject} removed from student {student.Name}.");
                            }
                            else
                            {
                                Console.WriteLine("Class not found.");
                            }

                            break;
                        }
                        case '4':
                        {
                            Console.WriteLine("\nAre you sure you want to delete this student? (y/n)");
                            var confirm = Console.ReadKey();
                            if (confirm.KeyChar is 'y' or 'Y')
                            {
                                students.Remove(student);

                                Console.WriteLine($"\nStudent {student.Name} deleted successfully.");
                            }
                            else
                            {
                                Console.WriteLine("\nDeletion cancelled.");
                            }

                            break;
                        }
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid input. Please enter a valid Student ID.");
            }

            break;
        }
        case '6':
        {
            Console.WriteLine("\nEnter Teacher ID to edit:");
            var tId = Console.ReadLine();
            try
            {
                var teacherId = int.Parse(tId!);
                var teacher = teachers.FirstOrDefault(t => t.Id == teacherId);
                if (teacher is null)
                    Console.WriteLine("Teacher not found.");
                else
                {
                    Console.WriteLine("1. Edit Name\n" +
                                      "2. Edit Subject\n" +
                                      "3. Delete Teacher");
                    var editChoice = Console.ReadKey();
                    switch (editChoice.KeyChar)
                    {
                        case '1':
                        {
                            Console.WriteLine("\nEnter New Name:");
                            var newName = Console.ReadLine();
                            if (!string.IsNullOrEmpty(newName))
                            {
                                teacher.Name = newName;
                                Console.WriteLine($"Teacher name updated to {newName}.");
                            }
                            else
                            {
                                Console.WriteLine("Invalid name. Please try again.");
                            }

                            break;
                        }
                        case '2':
                        {
                            Console.WriteLine("\nEnter New Subject:");
                            var newSubject = Console.ReadLine();
                            if (!string.IsNullOrEmpty(newSubject))
                            {
                                teacher.Course.Subject = newSubject;
                                Console.WriteLine($"Teacher subject updated to {newSubject}.");
                            }
                            else
                            {
                                Console.WriteLine("Invalid subject. Please try again.");
                            }

                            break;
                        }
                        case '3':
                        {
                            Console.WriteLine("\nAre you sure you want to delete this teacher? (y/n)");
                            var confirm = Console.ReadKey();
                            if (confirm.KeyChar is 'y' or 'Y')
                            {
                                teachers.Remove(teacher);
                                var studentWithSameCourse =
                                    students.Where(s => s.Courses.Contains(teacher.Course)).ToList();
                                foreach (var student in studentWithSameCourse)
                                {
                                    student.RemoveClass(teacher.Course);
                                }

                                courses.Remove(teacher.Course);
                                Console.WriteLine($"\nTeacher {teacher.Name} deleted successfully.");
                            }
                            else
                            {
                                Console.WriteLine("\nDeletion cancelled.");
                            }

                            break;
                        }
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid input. Please enter a valid Teacher ID.");
            }

            break;
        }
    }
}