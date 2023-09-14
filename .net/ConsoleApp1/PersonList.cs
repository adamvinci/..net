using be.ipl.domaine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{

    public class PersonList
    {

        private static PersonList instance;
        private Dictionary<String, Person> personMap;

        private PersonList()
        {
            personMap = new Dictionary<String, Person>();
        }

        public static PersonList getInstance()
        {

            if (instance == null)
                instance = new PersonList();

            return instance;
        }

        public void addPerson(Person person)
        {
            if (person == null)
                throw new Exception();
            personMap.Add(person.getName(), person);
        }

        public IEnumerable<Person> personList()
        {
            return personMap.Values;
        }

    }
}
