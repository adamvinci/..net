using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp1
{
    [Serializable]
    public class Actor : be.ipl.domaine.Person
    {


        private readonly int sizeInCentimeter;
        private List<Movie> movies;

        public int getSizeInCentimeter()
        {
            return sizeInCentimeter;
        }



        public Actor(String name, String firstname, DateTime birthDate, int sizeInCentimeter) : base(name, firstname, birthDate) { 
            this.sizeInCentimeter = sizeInCentimeter;
            movies = new List<Movie>();
        }



        public String ToString()
        {
            return "Actor [name = " + getName() + " firstname = " + getFirstname() + " sizeInCentimeter = " + sizeInCentimeter + " birthdate = " + getBirthDate() + "]";
        }

        /**
         * 
         * @return list of movies in which the actor has played
         */
        public IEnumerable<Movie> Movies()
        {
            return movies;
        }

        /**
         * add movie to the list of movies in which the actor has played
         * @param movie
         * @return false if the movie is null or already present
         */
        public bool addMovie(Movie movie)
        {
            if ((movie == null) || movies.Contains(movie))
                return false;

            if (!movie.containsActor(this))
                movie.addActor(this);

            movies.Add(movie);

            return true;
        }

        public bool containsMovie(Movie movie)
        {
            return movies.Contains(movie);
        }

        public override String getName()
        {
            return base.getName().ToUpper();
        }

    }
}
