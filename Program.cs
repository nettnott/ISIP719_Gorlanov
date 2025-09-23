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

    public enum TvarCategory { tabak, pivo, nenujnoe };


    public Tvari(string name, double price, int quantity, int categoryChoice)
    {
        ID = _nextId++;
        //Console.Write("input name: ");
        Name = Console.ReadLine();
        //Console.Write("input price: ");
        Price = Convert.ToDouble(Console.ReadLine());
        //Console.Write("input quantity: ");
        Quantity = Convert.ToInt32(Console.ReadLine());
        IsThere();

        Category = (TvarCategory)(categoryChoice - 1);
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
        string name = Console.ReadLine();

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

    public static void OrderSupply()
    {
        Console.WriteLine("=== zakazat postavku ===");
        Console.Write("input ID postavki: ");

        Console.Write("input ID: ");
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

    // 4. Продать товар
    public static void SellProduct()
    {
        Console.WriteLine("=== sell tvar ===");
        Console.Write("input id tvari ");

        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Некорректный ID!");
            return;
        }

        var product = products.FirstOrDefault(p => p.ID == id);
        if (product == null)
        {
            Console.WriteLine("Товар не найден!");
            return;
        }

        Console.Write($"Доступное количество: {product.Quantity}. Введите количество для продажи: ");
        if (!int.TryParse(Console.ReadLine(), out int amount) || amount <= 0)
        {
            Console.WriteLine("Некорректное количество!");
            return;
        }

        product.SellQuantity(amount);
    }

    // 5. Поиск товаров
    public static void SearchProducts()
    {
        Console.WriteLine("\n=== ПОИСК ТОВАРОВ ===");
        Console.WriteLine("1 - По ID");
        Console.WriteLine("2 - По названию");
        Console.WriteLine("3 - По категории");
        Console.Write("Выберите тип поиска: ");

        var choice = Console.ReadLine();
        IEnumerable<Tvari> results = null;

        switch (choice)
        {
            case "1":
                Console.Write("Введите ID: ");
                if (int.TryParse(Console.ReadLine(), out int id))
                {
                    results = products.Where(p => p.ID == id);
                }
                break;
            case "2":
                Console.Write("Введите название: ");
                string name = Console.ReadLine();
                results = products.Where(p => p.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
                break;
            case "3":
                var category = ChooseCategory();
                results = products.Where(p => p.Category == category);
                break;
            default:
                Console.WriteLine("Некорректный выбор!");
                return;
        }

        if (results != null && results.Any())
        {
            Console.WriteLine("\nРезультаты поиска:");
            foreach (var product in results)
            {
                product.DisplayInfo();
            }
        }
        else
        {
            Console.WriteLine("Товары не найдены!");
        }
    }

    // 6. Показать все товары
    public static void ShowAllProducts()
    {
        Console.WriteLine("\n=== ВСЕ ТОВАРЫ ===");
        if (products.Any())
        {
            foreach (var product in products)
            {
                product.DisplayInfo();
            }
        }
        else
        {
            Console.WriteLine("Товаров нет!");
        }
    }

};
