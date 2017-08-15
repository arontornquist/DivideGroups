namespace DivideGroups
{
    class Person
    {
        public string name;
        public Gender gender;

        public Person(string _name, Gender _gender)
        {
            name = _name;
            gender = _gender;
        }
        public Person(string _name)
        {
            name = _name;
            gender = Gender.Unknown;
        }
    }
}
