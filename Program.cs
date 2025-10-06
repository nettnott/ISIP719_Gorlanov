using System;
using System.Collections;
using System.Diagnostics;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

Console.WriteLine("eto shtuka dly kNIGG");
kNIGGi.menu();
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

    public static void SearchKNIGGy()
    {
        Console.WriteLine("poisk knigg");
        Console.WriteLine("1 - po name");
        Console.WriteLine("2 - po autor");
        Console.WriteLine("3 - po genry");
        Console.Write("Choose ur path: ");

        var choice = Console.ReadLine();
        IEnumerable<kNIGGi> results = null;

        switch (choice)
        {
            case "1":
                Console.Write("input name of the knigga: ");
                string name = Console.ReadLine();
                results = kniggis.Where(p => p.Name.Contains(name));
                break;
            case "2":
                Console.Write("input author: ");
                string author = Console.ReadLine();
                results = kniggis.Where(p => p.Name.Contains(author));
                break;
            case "3":
                var genre = (tipOfkNIGGa)(choosegenre() - 1);
                results = kniggis.Where(p => p.Genre == genre);
                break;
            default:
                Console.WriteLine("napishite normalno");
                return;
        }

        if (results != null && results.Any())
        {
            Console.WriteLine("resultati:");
            foreach (var kniggi in results)
            {
                kniggi.DisplayInfo();
            }
        }
        else
        {
            Console.WriteLine("nichego net");
        }
    }

    public static void SortKniggi()
    {
        Console.WriteLine("sort knigg");
        Console.WriteLine("1 - po name");
        Console.WriteLine("2 - po year");
        Console.Write("Choose ur path: ");

        var choice = Console.ReadLine();
        IEnumerable<kNIGGi> results = null;

        switch (choice)
        {
            case "1":
                results = kniggis.OrderBy(p => p.Name).ToList();
                Console.WriteLine("Sorted kNIGGies:");
                foreach (var p in results)
                    Console.WriteLine(p);
                break;
            case "2":
                results = kniggis.OrderBy(p => p.Age).ToList();
                Console.WriteLine("Sorted kNIGGies:");
                foreach (var p in results)
                    Console.WriteLine(p);
                break;
            default:
                Console.WriteLine("napishite normalno");
                return;
        }

        if (results != null && results.Any())
        {
            Console.WriteLine("resultati:");
            foreach (var kniggi in results)
            {
                kniggi.DisplayInfo();
            }
        }
        else
        {
            Console.WriteLine("nichego net");
        }
    }

    public static void TheMost()
    {

    }
    public static void GroupByAuthor() 
    {

    }

    public static void menu()
    {
        Console.WriteLine("menu");
        Console.WriteLine("1 - add kniggy");
        Console.WriteLine("2 - delete kniggy");
        Console.WriteLine("3 - search kniggy");
        Console.WriteLine("4 - sort kniggi");
        Console.WriteLine("5 - show the cheapest and the most expensive ones");
        Console.WriteLine("6 - group by author");
        Console.WriteLine("0 - exit");
        Console.Write("choose ");
        var choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
                AddKNIGGy();
                break;
            case "2":
                DelKNIGGy();
                break;
            case "3":
                SearchKNIGGy();
                break;
            case "4":
                SortKniggi();
                break;
            case "5":
                TheMost();
                break;
            case "6":
                GroupByAuthor();
                break;
            case "0":
                Console.WriteLine("exit");
                return;
            default:
                Console.WriteLine("nado normalno");
                break;
        }
        menu();
    }

}