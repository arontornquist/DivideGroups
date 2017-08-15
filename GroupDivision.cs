using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivideGroups
{
    class GroupDivision
    {
        public static int numberOfGroups;
        public static int personsPerGroup;
        public static Random random = new Random();

        public static void NumberOfGroups(List<Person> personList)
        {
            Console.Write("Hur många grupper vill du göra: ");
            numberOfGroups = int.Parse(Console.ReadLine());
            personsPerGroup = personList.Count / numberOfGroups;
            if (personList.Count % numberOfGroups > 0)
                personsPerGroup++;
        }

        static List<Group> CreateGroups()
        {
            List<Group> listOfGroups = new List<Group>();
            for (int i = 0; i < numberOfGroups; i++)
            {
                Group x = new Group();
                x.GroupName = $"Grupp {(i + 1)}";
                listOfGroups.Add(x);
            }
            return listOfGroups;
        }

        public static List<Group> RandomGroups(List<Person> nameList)
        {
            List<Group> listOfGroups = CreateGroups();
            for (int j = 0; j < listOfGroups.Count; j++)
            {
                List<Person> tempList = new List<Person>();
                for (int i = 0; i < personsPerGroup; i++)
                {
                    int index = random.Next(0, nameList.Count);
                    if (nameList.Count() > 0)
                    {
                        tempList.Add(nameList[index]);
                        nameList.RemoveAt(index);
                    }
                }
                listOfGroups[j].Members = tempList.ToList();
            }
            return listOfGroups;
        }
    }
}
