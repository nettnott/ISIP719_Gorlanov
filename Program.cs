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
        var professorName = _professor?.Name ?? "не назначен";
        return $"Курс: {Name} ({Id}), {Credits} кредитов, Преподаватель: {professorName}";
    }

    public string GetDetailedInfo()
    {
        var professorInfo = _professor?.Name ?? "не назначен";
        var studentsInfo = _students.Any()
            ? string.Join("\n  ", _students.Select(s => s.Name))
            : "нет студентов";

        return $"Курс ID: {Id}\n" +
               $"Название: {Name}\n" +
               $"Описание: {Description}\n" +
               $"Кредиты: {Credits}\n" +
               $"Преподаватель: {professorInfo}\n" +
               $"Студенты ({_students.Count}):\n  {studentsInfo}";
    }
}