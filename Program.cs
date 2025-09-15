using System;
using static System.Net.Mime.MediaTypeNames;

double[] cost = [];
string[] prod = [];

Console.WriteLine("это штука для учета расходов");

Console.WriteLine("What do u want to do?");
Console.WriteLine("Press 1 to input data, 2 to see stats, 3 to sort by cost");
Console.WriteLine("4 to convert money, 5 to search by name, 6 to see your data, 0 to exit");
int option = Convert.ToInt32(Console.ReadKey());

switch (option)
{
    case 1: //input data
        Console.WriteLine("HOW MUCH POSITIONS DO U WANT TO INPUT (from 2 to 40)");
        int i = Convert.ToInt32(Console.ReadKey());
        for (int j = 0; j < i; j++)
        {
            Console.WriteLine("Write ur data in format: 'name'; 'cost'");
            string tupoyvvod = Console.ReadLine();
            string[] idiotizm = tupoyvvod.Split(';');
            prod[prod.Length + j] = idiotizm[0].Trim();
            cost[cost.Length + j] = int.Parse(idiotizm[1].Trim());
        };
        break;

    case 2: // stats

    case 3: // bubble sort

    case 4: // convertation

    case 5: // search by name

    case 6: //see 

        for (int s = 0; s < prod.Length; s++)
        {
            Console.WriteLine($"{prod[s]} {cost[s]}");
        }
        break;

    case 0: // exit
        break;
};