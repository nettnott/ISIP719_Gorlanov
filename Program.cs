using System;
using System.Collections;
using static System.Net.Mime.MediaTypeNames;
using System.Collections.Generic;
using System.Linq;

public interface IUniversityMember
{
    string GetInfo();
    string GetDetailedInfo();
}

public abstract class Person : IUniversityMember
{
    private string _name;
    private int _age;
    private string _contactInfo;
    private int _id;

    public int Id => _id;
    public string Name => _name;
    public int Age => _age;
    public string ContactInfo => _contactInfo;

    protected Person(int id, string name, int age, string contactInfo)
    {
        _id = id;
        _name = name;
        _age = age;
        _contactInfo = contactInfo;
    }

    public abstract string GetInfo();
    public abstract string GetDetailedInfo();

    public override string ToString()
    {
        return GetInfo();
    }
}

public class Student : Person
{
    private string _major;
    private int _year;
    private List<Course> _courses;

    public string Major => _major;
    public int Year => _year;
    public IReadOnlyList<Course> Courses => _courses.AsReadOnly();

    public Student(int id, string name, int age, string contactInfo, string major, int year)
        : base(id, name, age, contactInfo)
    {
        _major = major;
        _year = year;
        _courses = new List<Course>();
    }

    public void EnrollInCourse(Course course)
    {
        if (!_courses.Contains(course))
        {
            _courses.Add(course);
            course.AddStudent(this);
        }
    }

    public void DropCourse(Course course)
    {
        if (_courses.Contains(course))
        {
            _courses.Remove(course);
            course.RemoveStudent(this);
        }
    }

    public override string GetInfo()
    {
        return $"Studwnt: {Name} ({Id}), {Major}, {Year} grade";
    }

    public override string GetDetailedInfo()
    {
        var coursesInfo = _courses.Any()
            ? string.Join(", ", _courses.Select(c => c.Name))
            : "no courses";

        return $"Student ID: {Id}\n" +
               $"name: {Name}\n" +
               $"age: {Age}\n" +
               $"contact info: {ContactInfo}\n" +
               $"major: {Major}\n" +
               $"grade: {Year}\n" +
               $"couarses info: {coursesInfo}";
    }
}

public class Professor : Person
{
    private string _department;
    private string _specialization;
    private List<Course> _coursesTeaching;

    public string Department => _department;
    public string Specialization => _specialization;
    public IReadOnlyList<Course> CoursesTeaching => _coursesTeaching.AsReadOnly();

    public Professor(int id, string name, int age, string contactInfo, string department, string specialization)
        : base(id, name, age, contactInfo)
    {
        _department = department;
        _specialization = specialization;
        _coursesTeaching = new List<Course>();
    }

    public void AssignToCourse(Course course)
    {
        if (!_coursesTeaching.Contains(course))
        {
            _coursesTeaching.Add(course);
            course.AssignProfessor(this);
        }
    }

    public void RemoveFromCourse(Course course)
    {
        if (_coursesTeaching.Contains(course))
        {
            _coursesTeaching.Remove(course);
            if (course.Professor == this)
            {
                course.RemoveProfessor();
            }
        }
    }

    public override string GetInfo()
    {
        return $"Professor: {Name} ({Id}), {Department}, {Specialization}";
    }

    public override string GetDetailedInfo()
    {
        var coursesInfo = _coursesTeaching.Any()
            ? string.Join(", ", _coursesTeaching.Select(c => c.Name))
            : "no courses";

        return $"Professor ID: {Id}\n" +
               $"name: {Name}\n" +
               $"age: {Age}\n" +
               $"contact info: {ContactInfo}\n" +
               $"department: {Department}\n" +
               $"specialization: {Specialization}\n" +
               $"courses info: {coursesInfo}";
    }
}

public class Course : IUniversityMember
{
    private int _id;
    private string _name;
    private string _description;
    private int _credits;
    private Professor _professor;
    private List<Student> _students;

    public int Id => _id;
    public string Name => _name;
    public string Description => _description;
    public int Credits => _credits;
    public Professor Professor => _professor;
    public IReadOnlyList<Student> Students => _students.AsReadOnly();

    public Course(int id, string name, string description, int credits)
    {
        _id = id;
        _name = name;
        _description = description;
        _credits = credits;
        _students = new List<Student>();
        _professor = null;
    }

    public void AssignProfessor(Professor professor)
    {
        _professor = professor;
    }

    public void RemoveProfessor()
    {
        _professor = null;
    }

    public void AddStudent(Student student)
    {
        if (!_students.Contains(student))
        {
            _students.Add(student);
        }
    }

    public void RemoveStudent(Student student)
    {
        if (_students.Contains(student))
        {
            _students.Remove(student);
        }
    }

    public string GetInfo()
    {
        var professorName = _professor?.Name ?? "no prof";
        return $"grade: {Name} ({Id}), {Credits} credits, prof: {professorName}";
    }

    public string GetDetailedInfo()
    {
        var professorInfo = _professor?.Name ?? "no prof";
        var studentsInfo = _students.Any()
            ? string.Join("\n  ", _students.Select(s => s.Name))
            : "no students";

        return $"course ID: {Id}\n" +
               $"name: {Name}\n" +
               $"description: {Description}\n" +
               $"credits: {Credits}\n" +
               $"prof: {professorInfo}\n" +
               $"students ({_students.Count}):\n  {studentsInfo}";
    }
}
public class UniversitySystem
{
    private List<Student> _students;
    private List<Professor> _professors;
    private List<Course> _courses;
    private int _nextStudentId;
    private int _nextProfessorId;
    private int _nextCourseId;

    public IReadOnlyList<Student> Students => _students.AsReadOnly();
    public IReadOnlyList<Professor> Professors => _professors.AsReadOnly();
    public IReadOnlyList<Course> Courses => _courses.AsReadOnly();

    public UniversitySystem()
    {
        _students = new List<Student>();
        _professors = new List<Professor>();
        _courses = new List<Course>();
        _nextStudentId = 1;
        _nextProfessorId = 1;
        _nextCourseId = 1;
    }

    public Student AddStudent(string name, int age, string contactInfo, string major, int year)
    {
        var student = new Student(_nextStudentId++, name, age, contactInfo, major, year);
        _students.Add(student);
        return student;
    }

    public Student GetStudent(int id)
    {
        return _students.FirstOrDefault(s => s.Id == id);
    }

    public Professor AddProfessor(string name, int age, string contactInfo, string department, string specialization)
    {
        var professor = new Professor(_nextProfessorId++, name, age, contactInfo, department, specialization);
        _professors.Add(professor);
        return professor;
    }

    public Professor GetProfessor(int id)
    {
        return _professors.FirstOrDefault(p => p.Id == id);
    }

    public Course AddCourse(string name, string description, int credits)
    {
        var course = new Course(_nextCourseId++, name, description, credits);
        _courses.Add(course);
        return course;
    }

    public Course GetCourse(int id)
    {
        return _courses.FirstOrDefault(c => c.Id == id);
    }
    public void EnrollStudentInCourse(int studentId, int courseId)
    {
        var student = GetStudent(studentId);
        var course = GetCourse(courseId);

        if (student != null && course != null)
        {
            student.EnrollInCourse(course);
        }
    }

    public void AssignProfessorToCourse(int professorId, int courseId)
    {
        var professor = GetProfessor(professorId);
        var course = GetCourse(courseId);

        if (professor != null && course != null)
        {
            professor.AssignToCourse(course);
        }
    }
}

public class ConsoleMenu
{
    private UniversitySystem _university;

    public ConsoleMenu(UniversitySystem university)
    {
        _university = university;
    }

    public void ShowMainMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("uni system");
            Console.WriteLine("1 - students");
            Console.WriteLine("2 - professors");
            Console.WriteLine("3 - courses");
            Console.WriteLine("4 - all data");
            Console.WriteLine("0 - exit");
            Console.Write("choose ur option: ");

            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    ShowStudentMenu();
                    break;
                case "2":
                    ShowProfessorMenu();
                    break;
                case "3":
                    ShowCourseMenu();
                    break;
                case "4":
                    ShowAllData();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("da mojno pj normalno pisat");
                    Console.ReadKey();
                    break;
            }
        }
    }

    private void ShowStudentMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("students");
            Console.WriteLine("1 - add");
            Console.WriteLine("2 - show all");
            Console.WriteLine("3 - show abt specific one");
            Console.WriteLine("4 - made a student attend a course");
            Console.WriteLine("5 - show student`s courses");
            Console.WriteLine("0 - back");
            Console.Write("choose a n option: ");

            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    AddStudent();
                    break;
                case "2":
                    ShowAllStudents();
                    break;
                case "3":
                    ShowStudentDetails();
                    break;
                case "4":
                    EnrollStudentInCourse();
                    break;
                case "5":
                    ShowStudentCourses();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("wroongggggggggg");
                    break;
            }
            Console.WriteLine("press any key...");
            Console.ReadKey();
        }
    }

    private void ShowProfessorMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("professors");
            Console.WriteLine("1 - add");
            Console.WriteLine("2 - show all");
            Console.WriteLine("3 - show specific");
            Console.WriteLine("4 - give prof a course");
            Console.WriteLine("0 - back");
            Console.Write("Choose ur option: ");

            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    AddProfessor();
                    break;
                case "2":
                    ShowAllProfessors();
                    break;
                case "3":
                    ShowProfessorDetails();
                    break;
                case "4":
                    AssignProfessorToCourse();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("wwrooooonggggggg");
                    break;
            }
            Console.WriteLine("Нажмите любую клавишу...");
            Console.ReadKey();
        }
    }

    private void ShowCourseMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("courses");
            Console.WriteLine("1 - add");
            Console.WriteLine("2 - show all");
            Console.WriteLine("3. - show specififc");
            Console.WriteLine("4 - show stuudents who attend");
            Console.WriteLine("0 - back");
            Console.Write("choose an option: ");

            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    AddCourse();
                    break;
                case "2":
                    ShowAllCourses();
                    break;
                case "3":
                    ShowCourseDetails();
                    break;
                case "4":
                    ShowCourseStudents();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("swrooonggg");
                    break;
            }
            Console.WriteLine("Нажмите любую клавишу...");
            Console.ReadKey();
        }
    }

    // Реализация методов меню
    private void AddStudent()
    {
        Console.Write("name: ");
        var name = Console.ReadLine();
        Console.Write("age: ");
        var age = int.Parse(Console.ReadLine());
        Console.Write("contact info: ");
        var contact = Console.ReadLine();
        Console.Write("major: ");
        var major = Console.ReadLine();
        Console.Write("grade: ");
        var year = int.Parse(Console.ReadLine());

        var student = _university.AddStudent(name, age, contact, major, year);
        Console.WriteLine($"added with ID: {student.Id}");
    }

    private void AddProfessor()
    {
        Console.Write("name: ");
        var name = Console.ReadLine();
        Console.Write("age: ");
        var age = int.Parse(Console.ReadLine());
        Console.Write("contact info: ");
        var contact = Console.ReadLine();
        Console.Write("department: ");
        var department = Console.ReadLine();
        Console.Write("specialization: ");
        var specialization = Console.ReadLine();

        var professor = _university.AddProfessor(name, age, contact, department, specialization);
        Console.WriteLine($"professor added with ID: {professor.Id}");
    }

    private void AddCourse()
    {
        Console.Write("name: ");
        var name = Console.ReadLine();
        Console.Write("description: ");
        var description = Console.ReadLine();
        Console.Write("credits: ");
        var credits = int.Parse(Console.ReadLine());

        var course = _university.AddCourse(name, description, credits);
        Console.WriteLine($"course added with ID: {course.Id}");
    }

    private void ShowAllStudents()
    {
        Console.WriteLine("\n=== ВСЕ СТУДЕНТЫ ===");
        foreach (var student in _university.Students)
        {
            Console.WriteLine(student.GetInfo());
        }
    }

    private void ShowAllProfessors()
    {
        Console.WriteLine("\n=== ВСЕ ПРЕПОДАВАТЕЛИ ===");
        foreach (var professor in _university.Professors)
        {
            Console.WriteLine(professor.GetInfo());
        }
    }

    private void ShowAllCourses()
    {
        Console.WriteLine("\n=== ВСЕ КУРСЫ ===");
        foreach (var course in _university.Courses)
        {
            Console.WriteLine(course.GetInfo());
        }
    }

    private void ShowStudentDetails()
    {
        Console.Write("Введите ID студента: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var student = _university.GetStudent(id);
            if (student != null)
            {
                Console.WriteLine(student.GetDetailedInfo());
            }
            else
            {
                Console.WriteLine("Студент не найден.");
            }
        }
    }

    private void ShowProfessorDetails()
    {
        Console.Write("Введите ID преподавателя: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var professor = _university.GetProfessor(id);
            if (professor != null)
            {
                Console.WriteLine(professor.GetDetailedInfo());
            }
            else
            {
                Console.WriteLine("Преподаватель не найден.");
            }
        }
    }

    private void ShowCourseDetails()
    {
        Console.Write("Введите ID курса: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var course = _university.GetCourse(id);
            if (course != null)
            {
                Console.WriteLine(course.GetDetailedInfo());
            }
            else
            {
                Console.WriteLine("Курс не найден.");
            }
        }
    }

    private void EnrollStudentInCourse()
    {
        Console.Write("Введите ID студента: ");
        if (int.TryParse(Console.ReadLine(), out int studentId))
        {
            Console.Write("Введите ID курса: ");
            if (int.TryParse(Console.ReadLine(), out int courseId))
            {
                _university.EnrollStudentInCourse(studentId, courseId);
                Console.WriteLine("Студент записан на курс.");
            }
        }
    }

    private void AssignProfessorToCourse()
    {
        Console.Write("Введите ID преподавателя: ");
        if (int.TryParse(Console.ReadLine(), out int professorId))
        {
            Console.Write("Введите ID курса: ");
            if (int.TryParse(Console.ReadLine(), out int courseId))
            {
                _university.AssignProfessorToCourse(professorId, courseId);
                Console.WriteLine("Преподаватель назначен на курс.");
            }
        }
    }

    private void ShowStudentCourses()
    {
        Console.Write("Введите ID студента: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var student = _university.GetStudent(id);
            if (student != null)
            {
                Console.WriteLine($"Курсы студента {student.Name}:");
                foreach (var course in student.Courses)
                {
                    Console.WriteLine($"  - {course.Name}");
                }
            }
            else
            {
                Console.WriteLine("Студент не найден.");
            }
        }
    }

    private void ShowCourseStudents()
    {
        Console.Write("Введите ID курса: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var course = _university.GetCourse(id);
            if (course != null)
            {
                Console.WriteLine($"Студенты курса {course.Name}:");
                foreach (var student in course.Students)
                {
                    Console.WriteLine($"  - {student.Name}");
                }
            }
            else
            {
                Console.WriteLine("Курс не найден.");
            }
        }
    }

    private void ShowAllData()
    {
        Console.WriteLine("\n=== ВСЕ ДАННЫЕ УНИВЕРСИТЕТА ===");

        Console.WriteLine("\n--- СТУДЕНТЫ ---");
        foreach (var student in _university.Students)
        {
            Console.WriteLine(student.GetDetailedInfo());
            Console.WriteLine();
        }

        Console.WriteLine("\n--- ПРЕПОДАВАТЕЛИ ---");
        foreach (var professor in _university.Professors)
        {
            Console.WriteLine(professor.GetDetailedInfo());
            Console.WriteLine();
        }

        Console.WriteLine("\n--- КУРСЫ ---");
        foreach (var course in _university.Courses)
        {
            Console.WriteLine(course.GetDetailedInfo());
            Console.WriteLine();
        }
    }
}