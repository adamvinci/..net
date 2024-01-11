using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace taches
{
    internal class Taches
    {
       private List<Tach> taches;
        public Taches() {
        taches = new List<Tach>();
            taches.Add(new Tach("tache1"));
                }
        public List<Tach> TachesList {  get { return taches; } }
        public class Tach
        {
            private string _description;
            private int _priorite;
            private DateTime date;
            private bool termine;

            public Tach(string description) 
            {
                _description = description;
                date = DateTime.Now;
                termine = false;
                _priorite = 4;                    
             }

            public string Description {  get { return _description;  } set { _description = value; } }

            public DateTime Date { get { return date; } set { date = value; } }

            public bool Termine { get { return termine; } set { termine = value; } }
            public int Priorite { get { return _priorite; } set { _priorite = value; } }

        }
    }
}
