using ConsoleApp1;
using ForBD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{


    public class Game
    {
        List<Details> listdetails = Core.Context.Details.ToList();
        List<Storage> liststorage = Core.Context.Storage.ToList();
        List<DetailsGarage> listall = Core.Context.DetailsGarage.ToList();


        static void Work(string[] args)
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
            if ((choice <= 10) & (choice >= 0) & (quantity > 0))
            {
                DetailsGarage selectedDetaiil = listall[choice];
                double totalCost = Convert.ToDouble(Det.Details.Cost * quantity);

                if (moneyBalance >= totalCost)
                {
                    moneyBalance -= totalCost;
                     = from p in listall where p.ElementAt(choice);
                    //Det.Storage.Add()
                    Console.WriteLine($"successfully bought {quantity} of {listall[choice].Details.Name}");
                }
                else
                {
                    Console.WriteLine("not enough money!");
                }
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
    public class Car
    {

    }

}
