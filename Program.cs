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


    public static void AddTvar()
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
        kNIGGi.Add(knigga);

        Console.WriteLine($"Successfully added! ID: {knigga.ID}");
    }

    public static void DelTvar()
    {
        Console.WriteLine("=== deleting tvar ===");

        Console.Write("input ID of the tvar: ");
        int id = Convert.ToInt32(Console.ReadLine());
        if (id < 1)
        {
            Console.WriteLine("nado normalno!");
            return;
        }

        var product = products.FirstOrDefault(p => p.ID == id);
        if (product != null)
        {
            products.Remove(product);
            Console.WriteLine("Tvari bolshe net!");
        }
        else
        {
            Console.WriteLine("takoi tvari net");
        }
    }

}