-- Create DATABASE  Kian;
use Kian ;
SELECT * FROM dbo.students;
SELECT Fullname,EnrolmentDate  FROM dbo.students
SELECT Fullname as studentName,Name as courseName FROM dbo.students 
FULL OUTER JOIN  dbo.Enrollments 
on students.id = Enrollments.StudentId
FULL OUTER JOIN dbo.Courses
on Enrollments.CourseId = Courses.id

UPDATE students
SET Fullname = 'Ahmed Mohsen'
WHERE id = 1;

UPDATE Enrollments 
SET Grade = 95
WHERE id = 1;
delete Enrollments
where StudentId= 4;
delete StudentProfiles
where StudentId = 4;

delete  students
where id = 4;

delete  Courses
where Courses.InstructorId = 4;

