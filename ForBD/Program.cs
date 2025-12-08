using ConsoleApp1;
using ForBD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class Randoms
    {
        public static Random Rand = new Random();
    }
    public class Game
    {
        public static List<Details> listdetails = Core.Context.Details.ToList();
        public static List<Storage> liststorage = Core.Context.Storage.ToList();
        public static List<DetailsGarage> listall = Core.Context.DetailsGarage.ToList();

        static int choice;
        static int choice2;
        static Player player = new Player("sasalele", 5630);

        public static void Main(Player player, List<Details> listdetails, List<Storage> liststorage, List<DetailsGarage> listall)
        {
            Detail d = new Detail();
            
            while (choice == 52) 
            {
                Console.WriteLine("--- MENU ---");
                Console.WriteLine("1. See the storage");
                Console.WriteLine("2. Buy details");
                Console.WriteLine("3. Start ur work");
                Console.WriteLine("0. Exit");
                Console.Write("input ur choice: ");

                string input = Console.ReadLine();
                if (!int.TryParse(input, out choice))
                {
                    Console.WriteLine("incorrect input, try again");
                    choice = 52;
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        d.ShowUpDetails(listall);
                        choice = 52;
                        break;
                    case 2:
                        player.BuyDetail(listall);
                        choice = 52; 
                        break;
                    case 3: 
                        HandleOrder();
                        choice = 52;
                        break;
                    case 0:
                        Console.WriteLine("Exit");
                        choice = 0;
                        break;
                    default:
                        Console.WriteLine("There`s no such a choice, choose normally");
                        choice = 52;
                        break;
                }
            }
        }

        static void HandleOrder()
        {
            Client.NewVisitor(Game.listdetails);

            Console.Write("Accept the order? (1 - Yes, 2 - Nah): ");
            string input2 = Console.ReadLine();
            if (!int.TryParse(input2, out choice2))
            {
                Console.WriteLine("There`s no such a choice, choose normally");
                return;
            }

            if (choice2 == 1)
            {
                CheckPartAvailability();
            }
            else
            {
                IssueRefusalPenalty();
            }
        }

        static void CheckPartAvailability()
        {
            bool hasPart = false;
            if ((listall.Where(p => p.DetailID == Client.brokenDetail.ID).Count() < 0))
            {
                hasPart = false;
            }
            else
            {
                hasPart = true;
            }

            if (hasPart)
            {
                Console.WriteLine("Suuccesfully");
                player.moneyBalance += 1000;
            }
            else
            {
                Console.WriteLine("Theres no such a detail");
                player.moneyBalance -= 1500;
            }
        }

        static void IssueRefusalPenalty()
        {
            Console.WriteLine("Клиенту отказано в обслуживании. Выдача штрафа.");
            player.moneyBalance -= 200; // Штраф за отказ
        }
    }

    public static class Client
    {
        public static string name = ClientsNames[Randoms.Rand.Next(ClientsNames.Count())];
        public static Details brokenDetail = Game.listdetails[Randoms.Rand.Next(Game.listdetails.Count())];

        public static List<string> ClientsNames = new List<string> { "Sanya", "Danya", "Dima", "Diana", "NATO", "Apelsin Orechovich", "GVV", "Kovalskiy", "1Cfan", "Nastiks", "Nasosalchik" };

        public static void NewVisitor(List<Details> listdetails)
        {
            Console.WriteLine("There`s a new client!");
            Console.WriteLine($"Name: {Client.name} | Broken detail: {Client.brokenDetail}");
        }
    }
    public class Player
    {
        public string Imya;
        public double moneyBalance;
        public Player(string name, double moneyBalance)
        {
            this.Imya = name;
            this.moneyBalance = moneyBalance;
        }

        public void BuyDetail(List<DetailsGarage> listall)
        {
            DetailsGarage Det = new DetailsGarage();
            Console.WriteLine("input a number of the detail u want to buy");
            int choice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("input a quantity");
            int quantity = Convert.ToInt32(Console.ReadLine());
            if ((choice <= listall.Count()) & (quantity > 0))
            {
                DetailsGarage selectedDetail = listall[choice];
                double totalCost = Convert.ToDouble(Det.Details.Cost * quantity);
                Console.WriteLine($"successfully bought {quantity} of {listall[choice].Details.Name}");
            }
            else
            {
                Console.WriteLine("input correct value");
            }
        }

    }
    public class Detail
    {
        public int DetailID;
        public string Name;
        public double Cost;
        public Detail()
        {

        }
        public void ShowUpDetails(List<DetailsGarage> listall)
        {
            foreach (DetailsGarage Det in listall)
            {
                Console.WriteLine($"ID: {Det.DetailID} | Name: {Det.Details.Name} | Cost: {Det.Details.Cost} | Quantity: {Det.Count}");
            }
        }
    }

}
