using System.Collections.Generic;

namespace DivideGroups
{
    class Group
    {
        public string GroupName { get; set; }
        public List<Person> Members { get; set; }
        public string GroupLeader { get; set; }

        //public Group (List<Person> members)
        //{
        //    Members = members;
        //}
    }
}
