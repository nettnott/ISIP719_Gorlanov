using System;
using static System.Net.Mime.MediaTypeNames;

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

//main code

Console.WriteLine("это штука для учета расходов");

Console.WriteLine("HOW MUCH POSITIONS DO U WANT TO INPUT (from 2 to 40)");
int n = Convert.ToInt32(Console.ReadLine());

double[] cost = new double[n];
string[] prod = new string[n];

for (int i = 0; i < n; i++)
{
    Console.WriteLine("Write ur data in format: 'name';'cost'");
    string tupoyvvod = Console.ReadLine();
    string[] idiotizm = tupoyvvod.Split(';');
    prod[i] = idiotizm[0].Trim();
    cost[i] = double.Parse(idiotizm[1].Trim());
};

menu();