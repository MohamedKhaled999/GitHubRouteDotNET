using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEMOAdv3
{
    internal class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }

        public override string ToString()
        {
            return $"Id : {Id} , Title : {Title} , price : {Price}";
        }
        public override int GetHashCode()
        {
            // + 
            // 100 , avatar , 120  = 100 + 500 + 120  = 750
            // 120 , avatar , 100  = 120 + 500 + 100  = 750 


            return HashCode.Combine(Id, Title, Price);   
        }

        public override bool Equals(object? obj)
        {
            Movie movie = obj as Movie;
            if(movie == null) return false;
            return this.Id.Equals(movie.Id) && this.Title.Equals(movie.Title) && this.Price.Equals(movie.Price);

        }
    }
}
