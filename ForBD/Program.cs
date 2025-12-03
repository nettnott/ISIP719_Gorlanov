using ConsoleApp1;
using ForBD;
using System;
using System.Collections.Generic;
using System.Linq;
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
        List<Details> listdetails = Core.Context.Details.ToList();
        List<Storage> liststorage = Core.Context.Storage.ToList();
        List<DetailsGarage> listall = Core.Context.DetailsGarage.ToList();


        static void Main(string[] args)
        {
            Console.WriteLine("");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    break;
                case "2":
                    break;
                case "3":
                    break;

            }

        }
        public void NewClient()
        {
            int clientid = Randoms.Rand.Next(listall.Count());

        }
    }

    public class Client
    {
        public int clientid;
        public string name;
        public DetailsGarage brokenDetail;
        
        
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

        public void BuyDetail(DetailsGarage Det, List<DetailsGarage> listall)
        {
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
        //shows info
        public void ShowUpDetails(DetailsGarage Det, List<DetailsGarage> listall)
        {
            foreach (DetailsGarage d in listall)
            {
                Console.WriteLine($"ID: {Det.DetailID} | Name: {Det.Details.Name} | Cost: {Det.Details.Cost} | Quantity: {Det.Count}");
            }
        }
    }

    class Program
    {
        static int choice;
        static int choice2;
        static Player player = new Player("sasalele", 5630);

        static void Main(string[] args)
        {
            // Основной цикл while, условие choice == 0 является условием выхода (Конец)
            while (choice == 52) // Условие на схеме "choice == 0" ведет к "true" (Конец), 
                                // поэтому цикл продолжается пока choice == 0 или пока не будет введено другое значение
            {
                Console.WriteLine("--- MENU ---");
                Console.WriteLine("1. See the storage");
                Console.WriteLine("2. Buy details");
                Console.WriteLine("3. Start ur work");
                Console.WriteLine("0. Выход из игры");
                Console.Write("input ur choice: ");

                // Ввод с клавиатуры (choice)
                string input = Console.ReadLine();
                if (!int.TryParse(input, out choice))
                {
                    Console.WriteLine("incorrect input, try again");
                    choice = 52; // Сбрасываем выбор, чтобы продолжить цикл
                    continue;
                }

                // Switch choice
                switch (choice)
                {
                    case 1: // Выход склада (условный блок 1 на схеме)
                        ShowStock();
                        choice = 52; // Возврат в главный цикл
                        break;
                    case 2: // Покупка Деталей (условный блок 2 на схеме)
                        PurchaseDetails();
                        choice = 52; // Возврат в главный цикл
                        break;
                    case 3: // Работа с заказом (условный блок 3 на схеме)
                        HandleOrder();
                        choice = 52; // Возврат в главный цикл
                        break;
                    case 0: // Выход из программы (пользовательский выбор)
                        Console.WriteLine("Exit");
                        choice = 0; // Устанавливаем значение, отличное от 0, чтобы выйти из while
                        break;
                    default:
                        Console.WriteLine("There`s no such a choice, choose normally");
                        choice = 52; // Продолжить цикл
                        break;
                }

                // Если choice не 0, цикл завершается
            }

            // Конец (выход из приложения)
            Console.WriteLine("That`s all");
        }

        // --- Методы, соответствующие блокам на схеме ---

        static void ShowStock()
        {
            Console.WriteLine("Вы покинули склад. Возврат в главное меню.");
        }

        static void PurchaseDetails()
        {
            Console.WriteLine("Меню закупки деталей. (Логика покупки здесь...)");
        }

        static void HandleOrder()
        {
            // Симуляция приезда клиента
            Console.WriteLine("\nПриехал новый клиент!");

            // Выбор (отказ/принятие) заказа (как на схеме)
            Console.Write("Принять заказ? (1 - Да, 2 - Нет): ");
            string input2 = Console.ReadLine();
            if (!int.TryParse(input2, out choice2))
            {
                Console.WriteLine("Некорректный ввод.");
                return; // Возврат в главное меню
            }

            // choice2-1 (проверка, как на схеме)
            if (choice2 == 1) // true ветка
            {
                // Метод: Проверка наличия детали (как на схеме)
                CheckPartAvailability();
            }
            else // false ветка
            {
                // Метод: Выдача штрафа отк(аз) (как на схеме)
                IssueRefusalPenalty();
            }
        }

        static void CheckPartAvailability()
        {
            // Эта логика должна взаимодействовать с вашими данными склада
            Console.WriteLine("Проверка наличия необходимой детали на складе...");
            bool hasPart = false; // Заглушка, замените на вашу логику

            if (hasPart)
            {
                Console.WriteLine("Деталь есть. Ремонт выполнен успешно.");
                player.moneyBalance += 1000; // Пример
            }
            else
            {
                Console.WriteLine("Детали нет. Принят неправильный заказ.");
                // Логика штрафа за неправильный ремонт из вашего описания
                player.moneyBalance -= 1500; // Пример
            }
        }

        static void IssueRefusalPenalty()
        {
            Console.WriteLine("Клиенту отказано в обслуживании. Выдача штрафа.");
            player.moneyBalance -= 200; // Штраф за отказ
        }
    }
}
