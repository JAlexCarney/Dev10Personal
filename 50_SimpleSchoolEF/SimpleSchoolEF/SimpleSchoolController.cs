using System.Linq;
using SimpleSchoolEF.Core;
using Microsoft.EntityFrameworkCore;

namespace SimpleSchoolEF
{
    public class SimpleSchoolController
    {
        private ConsoleIO io = new ConsoleIO();
        private SimpleSchoolContext context;

        public SimpleSchoolController(SimpleSchoolContext context) 
        {
            this.context = context;
        }

        public void Run() 
        {
            MenuLoop();
        }

        private void MenuLoop() 
        {
            while (true) 
            {
                io.Clear();
                io.PrintLineYellow("Simple School");
                io.PrintLineYellow("=============");
                io.PrintLine("");
                io.PrintLineYellow("Main Menu");
                io.PrintLineYellow("=========");
                io.PrintLineDarkYellow("0. Exit");
                io.PrintLineDarkYellow("1. Display Courses by Subject");
                io.PrintLineDarkYellow("2. Display Course Schedule By StudentId");
                io.PrintLineDarkYellow("3. Display Section Information By SectionId");
                io.PrintLineDarkYellow("4. Display Top Three Teachers By Sections Tuaght");

                int choice = io.ReadInt("Enter Choice: ", 0, 4);
                switch (choice) 
                {
                    case 0:
                        return;
                    case 1:
                        DisplayCoursesBySubject();
                        break;
                    case 2:
                        DisplayCourseScheduleByStudentId();
                        break;
                    case 3:
                        DisplaySectionInformationBySectionId();
                        break;
                    case 4:
                        DisplayTopThreeTeachersBySectionsTuaght();
                        break;
                }
                io.ReadString("Press Enter To Continue...");
            }
        }

        private void DisplayCoursesBySubject() 
        {
            io.Clear();
            io.PrintLineYellow("Display Courses by Subject");
            io.PrintLineYellow("==========================");
            io.PrintLine("");
            var CoursesWithSubjects = context.Course
                .Include(c => c.Subject)
                .ToList()
                .GroupBy(c => c.Subject.SubjectName);
            
            foreach (var subject in CoursesWithSubjects) 
            {
                io.PrintLineDarkYellow($"{subject.Key}");
                io.PrintLineDarkYellow($"-------------");
                foreach (var Course in subject)
                {
                    io.PrintLineDarkYellow($"   {Course.CourseName}");
                }
                io.PrintLine("");
            }
        }

        private void DisplayCourseScheduleByStudentId() 
        {
            io.Clear();
            io.PrintLineYellow("Display Courses by StudentId");
            io.PrintLineYellow("============================");
            io.PrintLine("");
            int studentId = io.ReadInt("Enter StudentId: ");

            var CourseSchedule = context.Section
                .Include(s => s.SectionRosters).ThenInclude(s => s.Student)
                .Include(s => s.Teacher)
                .Include(s => s.Course)
                .Include(s => s.Period)
                .Include(s => s.Semester)
                .Where(s => s.SectionRosters.Any(sr => sr.Student.StudentID == studentId));

            io.PrintLine("");
            string labels = $"{"Teacher",-25}{"Course",-20}{"S",-3}{"Start Date",-12}{"End Date",-12}{"Time",-19}";
            io.PrintLineYellow(labels);
            io.PrintLineYellow(new string('=', labels.Length));
            foreach (Section section in CourseSchedule) 
            {
                io.PrintLineDarkYellow($"{$"{section.Teacher.LastName}, {section.Teacher.FirstName}",-25}{section.Course.CourseName,-20}{section.Semester.SemesterID,-3}{section.Semester.StartDate,-12:d}{section.Semester.EndDate,-12:d}{$"{section.Period.StartTime}-{section.Period.EndTime}",-19}");
            }
            io.PrintLine("");
        }

        private void DisplaySectionInformationBySectionId() 
        {
            io.Clear();
            io.PrintLineYellow("Display Section Information By SectionId");
            io.PrintLineYellow("========================================");
            io.PrintLine("");
            int sectionId = io.ReadInt("Enter SectionId: ");

            Section section = context.Section
                .Include(s => s.SectionRosters).ThenInclude(s => s.Student)
                .Include(s => s.Teacher)
                .Include(s => s.Course)
                .Include(s => s.Period)
                .Include(s => s.Semester)
                .Where(s => s.SectionID == sectionId)
                .FirstOrDefault();

            io.PrintLine("");
            io.PrintLineDarkYellow($"Section ID: {section.SectionID}");
            io.PrintLineDarkYellow($"    Course: {section.Course.CourseName}");
            io.PrintLineDarkYellow($"Start Date: {section.Semester.StartDate:d}");
            io.PrintLineDarkYellow($"  End Date: {section.Semester.EndDate:d}");
            io.PrintLineDarkYellow($"   Teacher: {section.Teacher.LastName}, {section.Teacher.FirstName}");
            io.PrintLine("");
            io.PrintLineYellow($"{"ID",-3}{"Name",-25}{"Grade",-7}");
            foreach (SectionRoster sectionRoster in section.SectionRosters) 
            {
                Student student = sectionRoster.Student;
                string currentGrade = sectionRoster.CurrentGrade.HasValue ? sectionRoster.CurrentGrade.ToString() : "N/A";
                io.PrintLineDarkYellow($"{student.StudentID,-3}{$"{student.LastName}, {student.FirstName}",-25}{currentGrade,-7}");
            }
            io.PrintLine("");
        }

        private void DisplayTopThreeTeachersBySectionsTuaght() 
        {
            io.Clear();
            io.PrintLineYellow("Display Top Three Teachers By Sections Tuaght");
            io.PrintLineYellow("=============================================");
            io.PrintLine("");

            var TopThreeTeachers = context.Teacher
                    .Include(t => t.Sections)
                    .Select(t => new
                    {
                        FirstName = t.FirstName,
                        LastName = t.LastName,
                        SectionsTuaght = t.Sections.Count()
                    })
                    .OrderByDescending(t => t.SectionsTuaght)
                    .Take(3);

            io.PrintLineYellow($"{"Teacher",-25}{"#Sections",-15}");
            foreach (var teacher in TopThreeTeachers) 
            {
                io.PrintLineDarkYellow($"{$"{teacher.LastName}, {teacher.FirstName}",-25}{teacher.SectionsTuaght,-15}");
            }
        }
    }
}
