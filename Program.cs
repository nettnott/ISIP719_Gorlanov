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
    public string Age;
    public double Price;

    public enum tipOfkNIGGa { roman, detective, darkfantasy, hren };


    public kNIGGi(string name, string author, double price, string age, int genreChoice)
    {
        ID = _nextId++;
        Name = name;
        Author = author;
        Price = price;
        Age = age;
        Genre = (tipOfkNIGGa)(genreChoice - 1);
    }

   /* private static int choosegenre()
    {
        Console.WriteLine("choose genre:");
        Console.WriteLine("1 - Roman");
        Console.WriteLine("2 - Detective");
        Console.WriteLine("3 - Dark Fantasy");
        Console.WriteLine("4 - other hren`");
        int genreChoice = Convert.ToInt32(Console.ReadLine());
        return genreChoice;
    }*/

    public void DisplayInfo()
    {
        Console.WriteLine($"ID: {ID} | name: {Name} | author: {Author} | genre: {Genre} | price: {Price} | year of publishing: {Age}");
    }

    private static List<kNIGGi> kniggis = new List<kNIGGi>();


    public static void AddKNIGGy()
    {
        Console.WriteLine("adding a kNIGGy");

        Console.Write("input name: ");
        string name = Console.ReadLine();

        Console.Write("input author: ");
        string author = Console.ReadLine();

        Console.Write("input year of publishing: ");
        string age = Console.ReadLine();

        Console.Write("input price: ");
        double price = Convert.ToDouble(Console.ReadLine());
        if (price < 0)
        {
            Console.WriteLine("nado normalno!");
            return;
        }

        Console.WriteLine("choose genre:");
        Console.WriteLine("1 - Roman");
        Console.WriteLine("2 - Detective");
        Console.WriteLine("3 - Dark Fantasy");
        Console.WriteLine("4 - other hren`");
        int genreChoice = Convert.ToInt32(Console.ReadLine());

        var knigga = new kNIGGi(name, author, price, age, genreChoice);
        kniggis.Add(knigga);

        Console.WriteLine($"Successfully added! ID: {knigga.ID}");
    }

    public static void DelKNIGGy()
    {
        Console.WriteLine("deleting kniggy");

        Console.Write("input ID of the book: ");
        int id = Convert.ToInt32(Console.ReadLine());
        if (id < 1)
        {
            Console.WriteLine("nado normalno!");
            return;
        }

        var knigga = kniggis.FirstOrDefault(p => p.ID == id);
        if (kniggis != null)
        {
            kniggis.Remove(knigga);
            Console.WriteLine("Kniggi bolshe net!");
        }
        else
        {
            Console.WriteLine("takoi kniggi net");
        }
    }

}