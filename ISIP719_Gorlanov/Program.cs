using System;
using System.Collections;
using static System.Net.Mime.MediaTypeNames;

Console.WriteLine("это штука для учета расходов");

Console.WriteLine("HOW MUCH POSITIONS DO U WANT TO INPUT (from 2 to 40)");
int n = Convert.ToInt32(Console.ReadLine());

double[] cost = new double [n];
string[] prod = new string [n];

for (int i = 0; i < n; i++)
{

    Console.WriteLine("Write ur data in format: 'name';'cost'");
    string tupoyvvod = Console.ReadLine();
    string[] idiotizm = tupoyvvod.Split(';');
    prod[i] = idiotizm[0].Trim();
    cost[i] = double.Parse(idiotizm[1].Trim());
};

double summa(double[] cost)
{
    double sum = 0;
    foreach (double c in cost)
    {
        sum += c;
    };
    return sum;
};

void menu()
{
    Console.WriteLine();
    Console.WriteLine("What do u want to do?");
    Console.WriteLine("Press 1 to see your data, 2 to see stats, 3 to sort by cost");
    Console.WriteLine("4 to convert money, 5 to search by name, 0 to exit");
    int option = Convert.ToInt32(Console.ReadLine());

    switch (option)
    {
        case 1: //see 
            Console.WriteLine();
            for (int s = 0; s < prod.Length; s++)
            {
                Console.WriteLine($"{prod[s]} {cost[s]}");
            }
            break;

        case 2: // stats

            Console.WriteLine("What do u want to see?");
            Console.WriteLine("Press 1 to see average, 2 to see max, 3 to see min, 4 to see sum");
            int stat = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            switch (stat)
            {
                case 1: // average

                    double avg = summa(cost) / cost.Length;
                    Console.WriteLine($"average = {avg}");
                    break;

                case 2: // max

                    double maxon = 0;
                    foreach (double i in cost)
                    {
                        if (i > maxon)
                        {
                            maxon = i;
                        }
                    };
                    Console.WriteLine($"max = {maxon}");
                    break; 

                case 3: // min

                    double minipig = 99999999999;
                    foreach (double i in cost)
                    {
                        if (i < minipig)
                        {
                            minipig = i;
                        }
                    };
                    Console.WriteLine($"min = {minipig}");
                    break;

                case 4: // summa

                    Console.WriteLine($"summa = {summa(cost)}");
                    break;
            };
            break;

        case 3: // bubble sort

            for (int j = 0; j <= cost.Length - 2; j++)
            {
                for (int i = 0; i <= cost.Length - 2; i++)
                {
                    if (cost[i] > cost[i + 1])
                    {
                        double temp = cost[i + 1];
                        string tmp = prod[i+1];
                        cost[i + 1] = cost[i];
                        prod[i+1] = prod[i];
                        cost[i] = temp;
                        prod[i] = tmp;
                    }
                }
            }
            for (int s = 0; s < prod.Length; s++)
            {
                Console.WriteLine($"{prod[s]} {cost[s]}");
            };
            break;

        case 4: // convertation

            Console.WriteLine();
            Console.WriteLine("How do you want to convert?");
            Console.WriteLine("Press 1 to input ur course (rub to smth), 2 to choose from the list");
            int crsopt = Convert.ToInt32(Console.ReadLine());
            switch (crsopt)
            {
                case 1:
                    Console.WriteLine("write your course");
                    double course = Convert.ToDouble(Console.ReadLine());
                    for (int s = 0; s < prod.Length; s++)
                    {
                        Console.WriteLine($"{prod[s]} {cost[s] / course}");
                    };
                    break ;
                case 2:
                    Console.WriteLine("Choose a course");
                    Console.WriteLine("1 - rub to usd: 90,25; 2 - rub to eur: 98,50; 3 - rub to jpy: 0,59");
                    int val = Convert.ToInt32(Console.ReadLine());
                    switch (val)
                    {
                        case 1: //to usd
                            Console.WriteLine("rub to usd");
                            for (int s = 0; s < prod.Length; s++)
                            {
                                Console.WriteLine($"{prod[s]} {cost[s] / 90,25}");
                            };
                            break;
                        case 2: // to eur
                            Console.WriteLine("rub to eur");
                            for (int s = 0; s < prod.Length; s++)
                            {
                                Console.WriteLine($"{prod[s]} {cost[s] / 98,50}");
                            };
                            break;
                        case 3: // to jpy
                            Console.WriteLine("rub to jpy");
                            for (int s = 0; s < prod.Length; s++)
                            {
                                Console.WriteLine($"{prod[s]} {cost[s] / 0,59}");
                            };
                            break;
                    }
                    break ;
            }
            break;

        case 5: // search by name

            Console.WriteLine("Vvedite nachalo stroki");
            string search = Console.ReadLine();
            for (int i = 0; i < prod.Length; i++)
            {
                bool result = prod[i].ToLower().Contains(search.ToLower());
                if (result == true)
                {
                    Console.WriteLine($"{prod[i]} {cost[i]}");
                }
            };
            break;

        case 0: // exit
            return;
    };
    menu();
};
menu();