using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp1
{
    [Serializable]
    public class Director : be.ipl.domaine.Person
    {


        private List<Movie> directedMovies;

        public Director(String name, String firstname, DateTime birthDate):base (name, firstname, birthDate){

            directedMovies = new List<Movie>();
        }

        public bool addMovie(Movie movie)
        {

            if (directedMovies.Contains(movie))
                return false;

            if (movie.getDirector() == null)
                movie.setDirector(this);

            directedMovies.Add(movie);

            return true;

        }

        public IEnumerable<Movie> Movies()
        {
            return directedMovies;
        }


    }
}
