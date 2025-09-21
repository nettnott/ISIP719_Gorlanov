using System;
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
    Console.WriteLine("What do u want to do?");
    Console.WriteLine("Press 1 to see your data, 2 to see stats, 3 to sort by cost");
    Console.WriteLine("4 to convert money, 5 to search by name, 6 to add more data, 0 to exit");
    int option = Convert.ToInt32(Console.ReadLine());

    switch (option)
    {
        case 1: //see 

            for (int s = 0; s < prod.Length; s++)
            {
                Console.WriteLine($"{prod[s]} {cost[s]}");
            }
            break;

        case 2: // stats

            Console.WriteLine("What do u want to see?");
            Console.WriteLine("Press 1 to see average, 2 to see max, 3 to see min, 4 to see sum");
            int stat = Convert.ToInt32(Console.ReadLine());

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

        case 4: // convertation

        case 5: // search by name

        case 6: // input

            Console.WriteLine("HOW MUCH POSITIONS DO U WANT TO INPUT (from 2 to 40)");
            int n = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Write ur data in format: 'name';'cost'");
                string tupoyvvod = Console.ReadLine();
                string[] idiotizm = tupoyvvod.Split(';');
                prod[prod.Length + i - 1] = idiotizm[0].Trim();
                cost[prod.Length + i - 1] = double.Parse(idiotizm[1].Trim());
            };
            break;

        case 0: // exit
            return;
    };
    menu();
}

menu();