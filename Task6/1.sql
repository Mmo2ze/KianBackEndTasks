use Kian;

--p1
select *
from students
where students.Fullname like 'A%';

select *
from INSTRUCTORS
where Fullname like '%Fathy%';



--2
select (select Count(*) from students)    as studentsCount,
       (select Count(*) from INSTRUCTORS) as instructoresCount,
       (select Count(*) from Courses)     as coursesCount;

--p3
select c.Name                                                           as CourseName,
       (select Count(*) from Enrollments e where c.id = e.CourseId)     as EnrollCount,
       (select Fullname from INSTRUCTORS i where i.id = c.InstructorId) as InstructorName
from Courses c;



select avg(Grade)
from Enrollments as AverageGrade;


select c.Name                                                         as courseName,
       (select avg(grade) from Enrollments e where e.CourseId = c.id) as AverageGrade
from Courses c;
--p4
select c.Name as courseName
from Courses c
         join Enrollments e on c.id = e.CourseId
group by c.Name
having count(*) > 1;

--p5
select *
From students
order by EnrolmentDate;

select *
From INSTRUCTORS
order by HireDate;




--p6
SELECT Fullname as studentName, Name as courseName ,Grade as studentGrade
FROM dbo.students
         FULL OUTER JOIN dbo.Enrollments
                         on students.id = Enrollments.StudentId
         FULL OUTER JOIN dbo.Courses
                         on Enrollments.CourseId = Courses.id

select c.Name as CourseName,
       (select Fullname from INSTRUCTORS i where i.id = c.InstructorId) as InstructorName
from Courses c;