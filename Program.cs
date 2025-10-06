using System;
using System.Collections;
using System.Diagnostics;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

Console.WriteLine("eto shtuka dly kNIGG");

public class kNIGGi
{
    private static int _nextId = 1;

    public int ID;
    public string Name;
    public string Author;
    public tipOfkNIGGa Genre;
    public int Age;
    public double Price;

    public enum tipOfkNIGGa { roman, detective, darkfantasy, hren };


    public kNIGGi(string name, string author, double price, int age, int genreChoice)
    {
        ID = _nextId++;
        //Console.Write("input name: ");
        Name = name;
        //Console.Write("input price: ");
        Price = price;
        //Console.Write("input quantity: ");
        Quantity = quantity;
        IsThere();

        genre = (tipOfkNIGGa)(genreChoice - 1);
    }

    private static int choosegenre()
    {
        Console.WriteLine("choose genre:");
        Console.WriteLine("1 - Roman");
        Console.WriteLine("2 - Detective");
        Console.WriteLine("3 - Dark Fantasy");
        Console.WriteLine("4 - other hren`");
        int genreChoice = Convert.ToInt32(Console.ReadLine());
        return genreChoice;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"ID: {ID} | name: {Name} | category: {Category} | price: {Price} | quantity: {Quantity} | is on sklad: {(IsOnSklad ? "yeah" : "no.")}");
    }
}