using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestionTache
{
    class TacheData
    {
        private IList<Tache> tacheList;

        public TacheData()
        {
            Tache t1 = new Tache("tache1",5,false);
            Tache t2 = new Tache("tache2",4,true);
            Tache t3 = new Tache("tache3",3,false);
            Tache t4 = new Tache("tache4",8,false);
            Tache t5 = new Tache("tache5",9,true);

            tacheList = new List<Tache>();
            tacheList.Add(t1);
            tacheList.Add(t2);
      


        }

        public IList<Tache> getTacheList
        {
            get { return tacheList; }
        }

    }
    public class Tache
    {
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public bool Termine { get; set; }
        public int Priorite { get; set; }

        public Tache(string description,int priorite,bool termine)
        {
            Date = DateTime.Now;
            Description = description;
            Termine = termine;
            Priorite = priorite;
        }
        
    }
}
