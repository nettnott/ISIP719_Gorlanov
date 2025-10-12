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
        return $"Студент: {Name} ({Id}), {Major}, {Year} курс";
    }

    public override string GetDetailedInfo()
    {
        var coursesInfo = _courses.Any()
            ? string.Join(", ", _courses.Select(c => c.Name))
            : "нет курсов";

        return $"Студент ID: {Id}\n" +
               $"Имя: {Name}\n" +
               $"Возраст: {Age}\n" +
               $"Контакт: {ContactInfo}\n" +
               $"Специальность: {Major}\n" +
               $"Курс: {Year}\n" +
               $"Записан на курсы: {coursesInfo}";
    }
}