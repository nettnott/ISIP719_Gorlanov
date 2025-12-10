using ConsoleApp1;
using ForBD;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

/*
вывод названия компании GMWOG||GG.MOW||WONGG 
Меню:
1. Вход/регистрация - вепрос есть ли акк и там или регистрация, или то же самое, но без создания экземпляра, чисто проверка
2. Посмотреть товары

Регистрация
 1. Создать экземпляр класса пользователя из БД
 2. Попросить пользователя заполнить экземпляр данными: ник, логин, пароль + повторить пароль
 3. Проверить не занят ли логин(почта/телефон) введённый пользователем пользователя
 4. Если все ок попросить пользователя ввести пароль + повторить пароль
5. Если все прошло успешно добавить пользователя и вернуться в меню

После входа новое меню (добавить флаг при регистрации/входе). дальше все в отдельном цикле пока этот флаг true
1. Посмотреть товары
2. Посмотреть корзину
3. История покупок
4. Выйти из аккаунта: флаг false -> возврат в главное меню

Посмотреть товары:

если в акке:
Вывод списка товаров, снизу меню с ReadKey где или заказать (если true), или просто скип и возврат в главное меню
////// Если заказать то сперва проверка в акке или нет
ввод айди товара и количества - добавление в бд - вывод соо о добавлении - возврат в меню или продолжение покупки
////// если нет: соо вы не в акке и предложение войти

если не в акке: не показывать заказать

Посмотреть корзину:
Вывоод корзины, после 2-3 все равно остается меню блока
Меню:
1, Вернуться в главное для юзера
2. Заказать вещь: выбор вещи по айди - выбор пвз - добавление в бд + соо с инфой о заказе
3. Заказать всчю корзину: выбор пвз - добавление в бд + соо с инфой о заказе (пвз + дата + что (вся корзина/одна вещь и что за вещь))

История покупок:
1. Вернуться в меню
2. Вывод заказов по пользователю (мб потом добавить получен/возврат/в дороге)
3. меню с сортировкой по дате от свежих к старым и наоборот (очищение экрана + заньво вывод и менюшки)

 */

namespace ConsoleApp1
{

    static class ConsoleApp1
    {
        public static void Main(string[] args)
        {
            Nagiev.Sasalele();
        }
    }

    public static class Nagiev
    {
        public static void Sasalele()
        {

        }
    }
}
    //public static class Game
    //{
    //    public static Random rand = new Random();
    //    public static List<Storage> storages = Core.Context.Storage.ToList();
    //    public static Storage storgs = storages[0];
    //    public static List<DetailsGarage> detailsGarages = Core.Context.DetailsGarage.ToList();
    //    public static List<Details> details = Core.Context.Details.ToList();

    //    public static bool buyflag;
    //    public static int carscount;
    //    public static int quantity;
    //    public static int choiceB;   

    //    public static void Sasalele()
    //    {

    //        int choice = 0;
    //            while (choice != 52 & storgs.Balance > 0)
    //            {
    //                Console.Clear();

    //            if (buyflag)
    //            {
    //                if (carscount > 0 & carscount <= 2)
    //                {
    //                    Console.WriteLine($"U will receive ur item after handling {carscount} cars");
    //                }
    //                if (carscount < 0)
    //                {
    //                    AddingDetail(quantity, choiceB);
    //                    Console.WriteLine("Your detail is finally there!");
    //                }
    //                carscount -= 1;
    //                Console.ReadKey();
    //            }

    //            Console.WriteLine("--- MENU ---");
    //                Console.WriteLine("1. See the storage");
    //                Console.WriteLine("2. Buy details");
    //                Console.WriteLine("3. Start ur work");
    //                Console.WriteLine("52. Exit");
    //                Console.Write("input ur choice: ");

    //            string input = Console.ReadLine();

    //                if (!int.TryParse(input, out choice))
    //                {
    //                    Console.WriteLine("incorrect input, try again");
    //                    //choice = 52;
    //                    continue;
    //                }
                    
    //                switch (choice)
    //                {
    //                    case 1:
    //                        PrintDetailOnSklad();
    //                        Console.ReadKey();
    //                        //choice = 52;
    //                        break;
    //                    case 2:
    //                        BayProduct();
    //                        Console.ReadKey();
    //                        //choice = 52;
    //                        break;
    //                    case 3:
    //                        Client.NewVisitor();
    //                        HandleOrder();
    //                        Console.ReadKey();
    //                        //choice = 52;
    //                        break;
    //                    case 0:
    //                        Console.WriteLine("Exit");
    //                        Console.WriteLine($"U`ve finished with {storgs.Balance} money in ur pocket");
    //                        Console.ReadKey();
    //                        choice = 52;
    //                        break;
    //                    default:
    //                        Console.WriteLine("There`s no such a choice, choose normally");
    //                        Console.ReadKey();
    //                        //choice = 52;
    //                        break;
    //                }
    //            }
    //        Console.Clear();
    //        Console.WriteLine($"U lose! Ur balance is {storgs.Balance}");
    //        Console.ReadKey();
    //    }

    //    public static void PrintDetailOnSklad()
    //    {
    //        Console.WriteLine($"Ur balance is {storgs.Balance}");
    //        foreach (var item in detailsGarages)
    //            Console.WriteLine($"ID: {item.ID} | Name: {item.Details.Name} Cost: {item.Details.Cost} Quantity on sklad: {item.Count}");
    //    }

    //    public static void PrintDetail()
    //    {
    //        foreach (var item in details)
    //            Console.WriteLine($"ID: {item.ID} | Name: {item.Name} Cost: {item.Cost}");
    //    }

    //    public static void BayProduct()
    //    {
    //        PrintDetail();
    //        Console.WriteLine("Write down ID of the wanted detail");
    //        choiceB = int.Parse(Console.ReadLine());
    //        if ((choiceB <= details.Count()) & (choiceB > 0))
    //        {
    //            Console.WriteLine("input a quantity");
    //            quantity = Convert.ToInt32(Console.ReadLine());
    //            if (quantity > 0)
    //            {
    //                var SelectToBuy = detailsGarages.FirstOrDefault(d => d.Details.ID == choiceB);
    //                Console.WriteLine($"Successfully bought {quantity} of {SelectToBuy.Details.Name}.");
    //            }
    //            else
    //            {
    //                Console.WriteLine("input a correct value");
    //                buyflag = false;
    //            }
    //            buyflag = true;
    //            carscount = 2;
    //        }
    //        else
    //        {
    //            Console.WriteLine("input a correct value");
    //            buyflag = false;
    //        }
    //    }

    //    public static void AddingDetail(int quantity, int choiceB)
    //    {
    //        var SelectToBuy = detailsGarages.FirstOrDefault(d => d.Details.ID == choiceB);
    //        if (SelectToBuy == null)
    //        {
    //            DetailsGarage Det = new DetailsGarage();
    //            Det.StorageID = 1;
    //            Det.DetailID = choiceB;
    //            Det.Count = quantity;
    //            int a = detailsGarages.Count();
    //            Det.ID = a++;
    //            Core.Context.DetailsGarage.Add(Det);
    //            Core.Context.SaveChanges();
    //        }
    //        else
    //        {
    //            SelectToBuy.Count += quantity;
    //            Core.Context.SaveChanges();
    //        }
    //        buyflag = false;
    //    }
    //    //public static void CarsCounter(bool bougtsmthnew, int carscount)
    //    //{
    //    //    if (bougtsmthnew)
    //    //    {
    //    //        if (carscount > 0 & carscount <= 2)
    //    //        {
    //    //            Console.WriteLine($"U will receive it after handling {carscount} cars");
    //    //            carscount -= 1;
    //    //        }
    //    //    }
    //    //}

    //    public static void HandleOrder()
    //    {
    //        Console.WriteLine("what do u wanna do?");
    //        Console.WriteLine("1 - handle order | 2 - refuse to work | 3 - look up ur storage | 4 - buy details");
    //        string ch = Console.ReadLine();
    //        if (ch == "1")
    //        {
    //            Service();
    //        }
    //        else if (ch == "2")
    //        {
    //            TakeShtr();
    //        }
    //        else if (ch == "3")
    //        {
    //            PrintDetailOnSklad();
    //            HandleOrder();
    //        }
    //        else if (ch == "4")
    //        {
    //            BayProduct();
    //            HandleOrder();
    //        }
    //        else
    //        {
    //            Console.WriteLine("input a correct value");
    //        }
    //    }

    //    public static void Service()
    //    {
    //        bool hasPart = false;
    //        if ((detailsGarages.Where(p => p.DetailID == Client.brokenDetail.ID).Count() < 0))
    //        {
    //            hasPart = false;
    //        }
    //        else
    //        {
    //            hasPart = true;
    //        }

    //        if (hasPart)
    //        {
    //            DetailsGarage SelectToRepair = detailsGarages.FirstOrDefault(d => d.DetailID == Client.brokenDetail.ID);
    //            SelectToRepair.Count -= 1;
    //            storgs.Balance -= SelectToRepair.Details.Cost;
    //            Console.WriteLine("Succesfully repaired");
    //            storgs.Balance += 1000;
    //            Core.Context.SaveChanges();
    //            Console.WriteLine($"Your balance is now: {storgs.Balance}");
    //        }
    //        else
    //        {
    //            Console.WriteLine("Theres no such a detail");
    //            storgs.Balance -= 1500;
    //            Console.WriteLine($"Your balance is now: {storgs.Balance}");
    //        }
    //    }

    //    public static void TakeShtr()
    //    {
    //        Console.WriteLine("Straaaf.");
    //        storgs.Balance -= 1000;
    //        Console.WriteLine($"Your balance is now: {storgs.Balance}");
    //    }


    //    public static class Client
    //    {
    //        public static List<string> ClientsNames = new List<string> { "Sanya", "Danya", "Dima", "Diana", "NATO", "Apelsin Orechovich", "GVV", "Kovalskiy", "1Cfan", "Nastiks", "Nasosalchik" };
    //        public static string name = ClientsNames[rand.Next(ClientsNames.Count())];
    //        public static Details brokenDetail = details[rand.Next(details.Count())];


    //        public static void NewVisitor()
    //        {
    //            name = ClientsNames[rand.Next(ClientsNames.Count())];
    //            brokenDetail = details[rand.Next(details.Count())];
    //            Console.WriteLine("There`s a new client!");
    //            Console.WriteLine($"Name: {Client.name} | Broken detail: {Client.brokenDetail.Name}");

    //        }
    //    }


        //public static class Randoms
        //{
        //    public static Random Rand = new Random();
        //}
        //public class Game
        //{
        //    public static List<Details> listdetails = Core.Context.Details.ToList();
        //    public static List<Storage> liststorage = Core.Context.Storage.ToList();
        //    public static List<DetailsGarage> listall = Core.Context.DetailsGarage.ToList();

        //    public static int choice;
        //    public static int choice2;
        //    public static Player player = new Player("sasalele", 5630);

        //    public static void Sasalele()
        //    {
        //        Detail d = new Detail();
        //        choice = 52;
        //        while (choice == 52) 
        //        {
        //            Console.WriteLine("--- MENU ---");
        //            Console.WriteLine("1. See the storage");
        //            Console.WriteLine("2. Buy details");
        //            Console.WriteLine("3. Start ur work");
        //            Console.WriteLine("0. Exit");
        //            Console.Write("input ur choice: ");

        //            string input = Console.ReadLine();
        //            if (!int.TryParse(input, out choice))
        //            {
        //                Console.WriteLine("incorrect input, try again");
        //                choice = 52;
        //                continue;
        //            }

        //            switch (choice)
        //            {
        //                case 1:
        //                    d.ShowUpDetails(listall);
        //                    choice = 52;
        //                    break;
        //                case 2:
        //                    player.BuyDetail(listall);
        //                    choice = 52; 
        //                    break;
        //                case 3: 
        //                    HandleOrder();
        //                    choice = 52;
        //                    break;
        //                case 0:
        //                    Console.WriteLine("Exit");
        //                    choice = 0;
        //                    break;
        //                default:
        //                    Console.WriteLine("There`s no such a choice, choose normally");
        //                    choice = 52;
        //                    break;
        //            }
        //        }
        //    }

        //    static void HandleOrder()
        //    {
        //        Client.NewVisitor(Game.listdetails);

        //        Console.Write("Accept the order? (1 - Yes, 2 - Nah): ");
        //        string input2 = Console.ReadLine();
        //        if (!int.TryParse(input2, out choice2))
        //        {
        //            Console.WriteLine("There`s no such a choice, choose normally");
        //            return;
        //        }

        //        if (choice2 == 1)
        //        {
        //            CheckPartAvailability();
        //        }
        //        else
        //        {
        //            IssueRefusalPenalty();
        //        }
        //    }

        //    static void CheckPartAvailability()
        //    {
        //        bool hasPart = false;
        //        if ((listall.Where(p => p.DetailID == Client.brokenDetail.ID).Count() < 0))
        //        {
        //            hasPart = false;
        //        }
        //        else
        //        {
        //            hasPart = true;
        //        }

        //        if (hasPart)
        //        {
        //            Console.WriteLine("Suuccesfully");
        //            player.moneyBalance += 1000;
        //        }
        //        else
        //        {
        //            Console.WriteLine("Theres no such a detail");
        //            player.moneyBalance -= 1500;
        //        }
        //    }

        //    static void IssueRefusalPenalty()
        //    {
        //        Console.WriteLine("Straaaf.");
        //        player.moneyBalance -= 200;
        //    }
        //}

        //public static class Client
        //{
        //    public static string name = ClientsNames[Randoms.Rand.Next(ClientsNames.Count())];
        //    public static Details brokenDetail = Game.listdetails[Randoms.Rand.Next(Game.listdetails.Count())];

        //    public static List<string> ClientsNames = new List<string> { "Sanya", "Danya", "Dima", "Diana", "NATO", "Apelsin Orechovich", "GVV", "Kovalskiy", "1Cfan", "Nastiks", "Nasosalchik" };

        //    public static void NewVisitor(List<Details> listdetails)
        //    {
        //        Console.WriteLine("There`s a new client!");
        //        Console.WriteLine($"Name: {Client.name} | Broken detail: {Client.brokenDetail}");
        //    }
        //}
        //public class Player
        //{
        //    public string Imya;
        //    public double moneyBalance;
        //    public int ID;
        //    public Player(string name, double moneyBalance)
        //    {
        //        this.Imya = name;
        //        this.moneyBalance = moneyBalance;
        //        ID = 1;
        //    }

        //    public void BuyDetail(List<DetailsGarage> listall)
        //    {
        //        //DetailsGarage Det = new DetailsGarage();
        //        Console.WriteLine("input a number of the detail u want to buy");
        //        int choice = Convert.ToInt32(Console.ReadLine());
        //        Console.WriteLine("input a quantity");
        //        int quantity = Convert.ToInt32(Console.ReadLine());
        //        if ((choice <= listall.Count()) & (quantity > 0))
        //        {
        //            DetailsGarage selectedDetail = listall.FirstOrDefault(l => l.DetailID == choice);
        //            if (selectedDetail == null)
        //            {
        //                DetailsGarage Det = new DetailsGarage();
        //                Det.StorageID = ID;
        //                Det.DetailID = choice;
        //                Det.Count = quantity;
        //                int a = listall.Count();
        //                Det.ID = a++;
        //                Core.Context.DetailsGarage.Add(Det);
        //                Core.Context.SaveChanges();
        //            }
        //            selectedDetail.Count = quantity;
        //            //savebd
        //            double totalCost = Convert.ToDouble(selectedDetail.Details.Cost * selectedDetail.Count);
        //            Console.WriteLine($"successfully bought {selectedDetail.Count} of {selectedDetail.Details.Name}");
        //        }
        //        else
        //        {
        //            Console.WriteLine("input correct value");
        //        }
        //    }

        //}
        //public class Detail
        //{
        //    public int DetailID;
        //    public string Name;
        //    public double Cost;
        //    public Detail()
        //    {

        //    }
        //    public void ShowUpDetails(List<DetailsGarage> listall)
        //    {
        //        foreach (DetailsGarage Det in listall)
        //        {
        //            Console.WriteLine($"ID: {Det.DetailID} | Name: {Det.Details.Name} | Cost: {Det.Details.Cost} | Quantity: {Det.Count}");
        //        }
        //    }
        //}

//    }
//}
