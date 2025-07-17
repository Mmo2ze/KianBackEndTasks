use Kian ;

ALTER TABLE students
    ADD Email varchar(255);
ALTER  TABLE Enrollments
DROP FK__Enrollmen__Cours__17036CC0; -- change Foreign Key name after using 1.sql so we can get the FK name

DROP TABLE Courses;

ALTER TABLE StudentProfiles
DROP  COLUMN Address;
