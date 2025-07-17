-- Create DATABASE  Kian;
use Kian ;
Create TABLE students (
                          id INT PRIMARY KEY ,
                          Fullname VARCHAR(100) NOT NULL,
                          EnrolmentDate DATE NOT NULL,

);
Create TABLE  StudentProfiles (
                                  id INT PRIMARY KEY ,
                                  StudentId INT NOT NULL,
                                  Address VARCHAR(255) NOT NULL,
                                  PhoneNumber VARCHAR(14) NOT NULL,
                                  FOREIGN KEY (StudentId) REFERENCES students(id)
);

Create TABLE INSTRUCTORS (
                             id INT PRIMARY KEY ,
                             Fullname VARCHAR(100) NOT NULL,
                             HireDate DATE NOT NULL
);

Create TABLE Courses (
                         id INT PRIMARY KEY ,
                         Name VARCHAR(100) NOT NULL,
                         InstructorId INT NOT NULL,
                         FOREIGN KEY (InstructorId) REFERENCES INSTRUCTORS(id)
);

Create TABLE Enrollments (
                             id INT PRIMARY KEY ,
                             StudentId INT NOT NULL,
                             CourseId INT NOT NULL,
                             Grade INT NOT NULL ,
                             FOREIGN KEY (StudentId) REFERENCES students(id) ,
                             FOREIGN KEY (CourseId) REFERENCES Courses(id)
);

