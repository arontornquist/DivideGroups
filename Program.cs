using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivideGroups
{
    class Program
    {
        static void Main(string[] args)
        {
            
            List<Person> listOfEveryone = AskForNames();
            GroupDivision.NumberOfGroups(listOfEveryone);
            List<Group> randomGroup = GroupDivision.RandomGroups(listOfEveryone);
            PrintGroups(randomGroup);
            
        }


        private static List<Person> AskForNames()//Frågar efter om namn vill läsas från fil, annars tar metoden namn som inmatning från consollen
        {
            bool controll = true;
            List<Person> listOfPersons = new List<Person>();
            Console.Write("Vill du läsa in din namnlista från fil (filformat: Kalle m, Lisa k etc), y/n: ");
            string response = Console.ReadLine().ToLower();
            do
            {
                List<string> tempList = new List<string>();
                controll = true; // denna variabeln var redan true innan
                if (response == "y")//om man svarar yes tolkas det som no vilket är default
                {
                    tempList = File.ReadAllText("nameList.txt").Split(',').ToList();
                }
                else
                {
                    Console.Write("Önskas en könsfördelad lista (y/n): ");
                    if (Console.ReadLine().ToLower().Equals("y"))
                    {
                        Console.Write("Ange alla personer inklusive kön (ex Lisa k, Kalle m,): ");
                        tempList = Console.ReadLine().Split(',').ToList();
                    }
                    else
                    {
                        Console.Write("Ange alla personer (ex Lisa, Kalle): ");
                        tempList = Console.ReadLine().Split(',').ToList();
                    }
                }
                foreach (var person in tempList)
                {
                    string[] a = person.Trim().Split(' ');
                    if (a.Length == 2)
                    {
                       Gender tempGender = ParseGender(person);
                       Person x = new Person(a[0], tempGender);
                       listOfPersons.Add(x);
                    }
                    else
                    {
                       Console.WriteLine("Felinmatning, försök igen!");
                       Console.WriteLine();
                       controll = false;
                    }
                }
            } while (!controll);
            return listOfPersons;
        }
    
        //TODO: Gender som enum utan Parsemetod.
        private static Gender ParseGender(string person)//Tilldelar kön för medlemmarna, om input matchar k eller m.
        {
            string[] a = person.Trim().Split(' ');

            if (a.Length >= 2)
            {
                if (a[1].ToLower().Equals("k"))
                    return Gender.Female;
                else if (a[1].ToLower().Equals("m"))
                    return Gender.Male;
                else
                    return Gender.Other;
            }
            else
                return Gender.Unknown;
        }

        private static void PrintGroups(List<Group> sortedGroups)//Skriver ut namnen i grupperna med färg beroende på kön
        {
            foreach (var group in sortedGroups)
            {
                Console.WriteLine();
                Console.WriteLine(group.GroupName);
                foreach (var person in group.Members)
                {
                    if (person.gender == Gender.Male)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine($"{person.name}");
                        Console.ResetColor();
                    }
                    else if (person.gender == Gender.Female)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"{person.name}");
                        Console.ResetColor();
                    }
                    else
                        Console.WriteLine($"{person.name}");
                }
            }
            Console.WriteLine();
        }

    }
}
