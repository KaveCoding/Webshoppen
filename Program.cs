using EF_Demo_many2many2.Models;
using Microsoft.EntityFrameworkCore;

namespace EF_Demo_many2many2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var myDb = new MyDBContext())
            {
                var movie1 = new Movie { Name = "Top Gun: Maverick" };
                var movie2 = new Movie { Name = "Snowpierces" };
                var movie3 = new Movie { Name = "Edge of Tomorrow" };
                var movie4 = new Movie { Name = "A Quiet Place" };
                myDb.AddRange(
                    new Actor
                    {
                        Name = "Tom Cruise",
                        Movies = new List<Movie> { movie1, movie3 }
                    },
                    new Actor
                    {
                        Name = "Jennifer Connelly",
                        Movies = new List<Movie> { movie1, movie2 }
                    },
                    new Actor
                    {
                        Name = "Emily Blunt",
                        Movies = new List<Movie> { movie3, movie4 }
                    });

                myDb.SaveChanges();



                foreach (var actor in myDb.Actors.Include(m => m.Movies))
                {
                    Console.WriteLine("Actor: " + actor.Name );

                    foreach(var movie in actor.Movies)
                    {
                        Console.WriteLine("   Movie: " + movie.Name);
                    }
                }
                Console.WriteLine("---------------------");
                foreach (var movie in myDb.Movies.Include(m => m.Actors))
                {
                    Console.WriteLine("Movie: " + movie.Name);
                    
                    foreach (var actor in movie.Actors)
                    {
                        Console.WriteLine("   Actor: " + actor.Name);
                    }
                }


            }
        }
    }
}