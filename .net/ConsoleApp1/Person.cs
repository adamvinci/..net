using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace be.ipl.domaine
{

    [Serializable]
    public class Person
    {


        private readonly string name;
        private readonly string firstname;
        private readonly DateTime birthDate;

        public virtual String getName()
        {
            return name;
        }

        public String getFirstname()
        {
            return firstname;
        }

        public String getBirthDate()
        {
  
            return birthDate.ToString("dd-MM-yyyy");
        }


        public Person(String name, String firstname, DateTime birthDate)
        {
            this.name = name;
            this.firstname = firstname;
            this.birthDate = birthDate;
        }

        public override string ToString()
        {
            return "Person [name = " + name + ", firstname = " + firstname + ", birthDate =  " + getBirthDate() + "]";
        }


    }

}

