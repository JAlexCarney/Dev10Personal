SELECT
    Course.CourseName,
    StartDate,
    EndDate,
    Teacher.FirstName,
    Teacher.LastName
FROM Section
INNER JOIN Course ON Course.CourseID = Section.CourseID
INNER JOIN Teacher ON Teacher.TeacherID = Section.TeacherID
INNER JOIN Semester ON Semester.SemesterID = Section.SemesterID
INNER JOIN [Period] ON [Period].[PeriodID] = Section.[PeriodID]
WHERE SectionID = 2;

SELECT
    Student.StudentId AS 'Id',
    LastName,
    FirstName,
    CurrentGrade
FROM Student
JOIN SectionRoster ON Student.StudentID = SectionRoster.StudentID
WHERE SectionID = 1;
