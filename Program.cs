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