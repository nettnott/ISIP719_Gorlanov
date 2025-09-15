using System;
int[] cost = [];
string[] prod = [];

Console.WriteLine("это штука для учета расходов");
void menu()
{
    Console.WriteLine("What do u want to do?");
    Console.WriteLine("Press 1 to input data, 2 to see stats, 3 to sort by cost");
    Console.WriteLine("4 to convert money, 5 to search by name, 0 to exit");
    char option = Convert.ToChar(Console.ReadKey());
};
menu();

switch (option)
{
    case '1': //input data


    case '2': // stats

    case '3': // bubble sort

    case '4': // convertation

    case '5': // search by name

    case '0': // exit
        break;
}