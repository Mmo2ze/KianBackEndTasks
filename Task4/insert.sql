-- Insert Students
INSERT INTO students (id, Fullname, EnrolmentDate) VALUES
                                                       (1, 'Ahmed Mostafa', '2023-09-01'),
                                                       (2, 'Laila Mahmoud', '2022-08-15'),
                                                       (3, 'Omar Youssef', '2023-01-20'),
                                                       (4, 'Mona Khaled', '2024-02-10');

-- Insert Student Profiles
INSERT INTO StudentProfiles (id, StudentId, Address, PhoneNumber) VALUES
                                                                      (1, 1, '12 Nile Street, Cairo', '01012345678'),
                                                                      (2, 2, '45 Tahrir Square, Giza', '01198765432'),
                                                                      (3, 3, '7 Alexandria Road, Alex', '01234567890'),
                                                                      (4, 4, '22 Nasr City, Cairo', '01099887766');

-- Insert Instructors
INSERT INTO INSTRUCTORS (id, Fullname, HireDate) VALUES
                                                     (1, 'Dr. Amr Fathy', '2021-05-01'),
                                                     (2, 'Prof. Salma Ezz', '2020-09-15'),
                                                     (3, 'Prof. Mona Fathy', '2020-06-15'),
                                                     (4, 'Dr. Tamer ElBaz', '2022-11-10');

-- Insert Courses
INSERT INTO Courses (id, Name, InstructorId) VALUES
                                                 (1, 'Database Systems', 1),
                                                 (2, 'Operating Systems', 2), 
                                                 (3, 'Backend', 3),
                                                 (4, 'Web Development', 4);

-- Insert Enrollments
INSERT INTO Enrollments (id, StudentId, CourseId, Grade) VALUES
                                                             (1, 1, 1, 90),
                                                             (2, 1, 2, 85),
                                                             (3, 2, 1, 78),
                                                             (4, 2, 3, 88),
                                                             (5, 3, 3, 91),
                                                             (6, 4, 1, 95);
