using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

Console.WriteLine("это штука для учета tovarov");
Tvari.menu();
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

    public enum TvarCategory { tabak, pivo, nenujnoe };


    public Tvari(string name, double price, int quantity, int categoryChoice)
    {
        ID = _nextId++;
        //Console.Write("input name: ");
        Name = name;
        //Console.Write("input price: ");
        Price = price;
        //Console.Write("input quantity: ");
        Quantity = quantity;
        IsThere();

        Category = (TvarCategory)(categoryChoice - 1);
    }

    private static int choosecategory()
    {
        Console.WriteLine("choose category:");
        Console.WriteLine("1 - Tabak");
        Console.WriteLine("2 - Pivo");
        Console.WriteLine("3 - Nenujnoe");
        int categoryChoice = Convert.ToInt32(Console.ReadLine());
        return categoryChoice;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"ID: {ID} | name: {Name} | category: {Category} | price: {Price} | quantity: {Quantity} | is on sklad: {(IsOnSklad ? "yeah" : "no.")}");
    }

    public void dobKolvo(int amount)
    {
        if (amount > 0)
        {
            Quantity += amount;
            Console.WriteLine($"Successfully addded, new quantity: {Quantity}");
        }
        else
        {
            Console.WriteLine("Napishite normalno ny emoe!");
        }
    }

    public bool delKolvo(int amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Napishite normalno ny emoe!");
            return false;
        }

        if (Quantity >= amount)
        {
            Quantity -= amount;
            Console.WriteLine($"Successfully prodano. {Quantity} styki left");
            return true;
        }
        else
        {
            Console.WriteLine($"Ny nifiga sebe! a eshche chego! There are only {Quantity} shtyki");
            return false;
        }
    }

    private static List<Tvari> products = new List<Tvari>();


    public static void AddTvar()
    {
        Console.WriteLine("=== adding tvar ===");

        Console.Write("input name: ");
        string name = Console.ReadLine();

        Console.Write("input price: ");
        double price = Convert.ToDouble(Console.ReadLine());
        if (price < 0)
        {
            Console.WriteLine("nado normalno!");
            return;
        }

        Console.Write("Skolko: ");
        int quantity = Convert.ToInt32(Console.ReadLine());
        if (quantity < 0)
        {
            Console.WriteLine("normalno nadooo!");
            return;
        }

        Console.WriteLine("choose category:");
        Console.WriteLine("1 - Tabak");
        Console.WriteLine("2 - Pivo");
        Console.WriteLine("3 - Nenujnoe");
        int categoryChoice = Convert.ToInt32(Console.ReadLine());

        var product = new Tvari(name, price, quantity, categoryChoice);
        products.Add(product);

        Console.WriteLine($"Successfully added! ID: {product.ID}");
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

    public static void OrderTvar()
    {
        Console.WriteLine("=== zakazat postavku ===");
        Console.Write("input ID postavki: ");
        int id = Convert.ToInt32(Console.ReadLine());
        if (id < 1)
        {
            Console.WriteLine("nado normalno!");
            return;
        }

        var product = products.FirstOrDefault(p => p.ID == id);
        if (product == null)
        {
            Console.WriteLine("Takoi tvari net!");
            return;
        }

        Console.Write($"Seichas {product.Quantity} Tvarei. Input amount for postavka: ");
        int amount = Convert.ToInt32(Console.ReadLine());
        if (amount <= 0)
        {
            Console.WriteLine("Napishite normalno!");
            return;
        }

        product.dobKolvo(amount);
    }

    public static void SellTvar()
    {
        Console.WriteLine("=== sell tvar ===");
        Console.Write("input ID of the tvar: ");
        int id = Convert.ToInt32(Console.ReadLine());
        if (id < 1)
        {
            Console.WriteLine("nado normalno!");
            return;
        }

        var product = products.FirstOrDefault(p => p.ID == id);
        if (product == null)
        {
            Console.WriteLine("takoi tvari net");
        }
        else
        {
            Console.Write($"Dostupno {product.Quantity} tvarei. Skoka hotite prodat?");
            int amount = Convert.ToInt32(Console.ReadLine());
            if (amount <= 0)
            {
                Console.WriteLine("Napishite normalno!");
                return;
            }

            product.delKolvo(amount);
        }
    }

    public static void SearchTvar()
    {
        Console.WriteLine("=== poisk tvarei ===");
        Console.WriteLine("1 - po ID");
        Console.WriteLine("2 - po name");
        Console.WriteLine("3 - po categorii");
        Console.Write("Choose ur path: ");

        var choice = Console.ReadLine();
        IEnumerable<Tvari> results = null;

        switch (choice)
        {
            case "1":
                Console.Write("input ID of the tvar: ");
                int id = Convert.ToInt32(Console.ReadLine());
                if (id < 1)
                {
                    Console.WriteLine("nado normalno!");
                    return;
                }
                else
                {
                    results = products.Where(p => p.ID == id);
                }
                break;
            case "2":
                Console.Write("input name: ");
                string name = Console.ReadLine();
                results = products.Where(p => p.Name.Contains(name));
                break;
            case "3":
                var category = (TvarCategory)(choosecategory() - 1);
                results = products.Where(p => p.Category == category);
                break;
            default:
                Console.WriteLine("napishite normalno");
                return;
        }

        if (results != null && results.Any())
        {
            Console.WriteLine("resultati:");
            foreach (var product in results)
            {
                product.DisplayInfo();
            }
        }
        else
        {
            Console.WriteLine("nichego net");
        }
    }

    public static void ShowAll()
    {
        Console.WriteLine("=== sow all tvarei ===");
        if (products.Any())
        {
            foreach (var product in products)
            {
                product.DisplayInfo();
            }
        }
        else
        {
            Console.WriteLine("nichego net!");
        }
    }

    public static void menu()
    {
        Console.WriteLine("=== menu ===");
        Console.WriteLine("1 - add tvar");
        Console.WriteLine("2 - delete tvar");
        Console.WriteLine("3 - zakazat postavku tvari");
        Console.WriteLine("4 - sell tvar");
        Console.WriteLine("5 - search tvar");
        Console.WriteLine("6 - show tvar");
        Console.WriteLine("0 - exit");
        Console.Write("choose ");
        var choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
                AddTvar();
                break;
            case "2":
                DelTvar();
                break;
            case "3":
                OrderTvar();
                break;
            case "4":
                SellTvar();
                break;
            case "5":
                SearchTvar();
                break;
            case "6":
                ShowAll();
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
};