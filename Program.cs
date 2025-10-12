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

        return $"Преподаватель ID: {Id}\n" +
               $"Имя: {Name}\n" +
               $"Возраст: {Age}\n" +
               $"Контакт: {ContactInfo}\n" +
               $"Кафедра: {Department}\n" +
               $"Специализация: {Specialization}\n" +
               $"Ведет курсы: {coursesInfo}";
    }
}