using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

Console.WriteLine("это штука для учета tovarov");

public class Tvari
{
    private static int _nextId = 1;

    public int ID;
    public string Name;
    public double Price;
    public int Quantity;
    public bool IsOnSklad;
    public TvarCategory Category;

    public void IsThere()
    {
        if (Quantity > 0)
        {
            IsOnSklad = true;
        }
        else
        {
            IsOnSklad = false;
        }
    }

    public enum TvarCategory { tabak, pivo, nenujnoe};


    public Tvari()
    {
        ID = _nextId++;
        Console.Write("input name: ");
        Name = Console.ReadLine();
        Console.Write("input price: ");
        Price = Convert.ToDouble(Console.ReadLine());
        Console.Write("input quantity: ");
        Quantity = Convert.ToInt32(Console.ReadLine());
        IsThere();

        Console.WriteLine("choose category:");
        Console.WriteLine("1 - Tabak");
        Console.WriteLine("2 - Pivo");
        Console.WriteLine("3 - Nenujnoe");
        int categoryChoice = Convert.ToInt32(Console.ReadLine());
        Category = (TvarCategory)(categoryChoice - 1);
    }
};

public class MainShit
{
    private static List<Tvari> products = new List<Tvari>();

}