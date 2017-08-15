﻿using System;
using System.Collections.Generic;
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


        private static List<Person> AskForNames()
        {
            bool controll = true;
            List<Person> listOfPersons = new List<Person>();
            Console.Write("Vill du läsa in din namnlista från fil (filformat: Kalle m, Lisa k etc), y/n: ");
            string respons = Console.ReadLine();

            Console.Write("Önskas en könsfördelad lista (y/n): ");
            if (Console.ReadLine().ToLower().Equals("y"))
            {
                do
                {
                    controll = true;
                    Console.Write("Ange alla personer inklusive kön (ex Lisa k, Kalle m,): ");
                    List<string> tempList = Console.ReadLine().Split(',').ToList();
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
            }
            else
            {
                
                Console.Write("Ange alla personer (ex Lisa,Kalle): ");
                List<string> tempList = Console.ReadLine().Split(',').ToList(); //, StringSplitOptions.RemoveEmptyEntries);
                foreach (var person in tempList)
                {    
                    Gender tempGender = ParseGender(person);
                    Person x = new Person(person, tempGender);
                    listOfPersons.Add(x);     
                }
                
            }
            return listOfPersons;
        }
    

        private static Gender ParseGender(string person)
        {
            string[] a = person.Trim().Split(' ');

            if (a[1].ToLower().Equals("k"))
                return Gender.Female;
            else if (a[1].ToLower().Equals("m"))
                return Gender.Male;
            else
                return Gender.Other;
        }

        private static void PrintGroups(List<Group> sortedGroups)
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