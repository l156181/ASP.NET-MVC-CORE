using System;
using entity_frawework_core_1.Model;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace entity_frawework_core_1
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var context = new AluraFilmesContext()){   
                
                // foreach(var actor in context.Actor){
                //     Console.WriteLine(actor);
                    
                // }

                // Console.WriteLine();

                // foreach(var film in context.Film){
                //     Console.WriteLine(film);
                // }

                // Console.WriteLine();

                // foreach(var category in context.Category){
                //     Console.WriteLine(category);
                // }

                // Console.WriteLine();
                
                var languages = context.Language.Include(l => l.FilmLanguage);

                foreach(var language in languages){                    
                    Console.WriteLine();
                    Console.WriteLine(language);

                    foreach(var film in language.FilmLanguage){
                        Console.WriteLine();
                        Console.WriteLine("".PadRight(20) + film);
                    }
                }
            }
        }
    }
}



// A form of the how set value to a shadow property                    
// Actor is object of the type Actor
// last_update is the name of the attributte
// context.Entry(actor).Property("last_update").CurrentValue = DateTime.Now;

// Get value od the shadow property  
// context.Entry(actor).Property("last_update").CurrentValue ;

// Use value of the shadow property in the LinQ statement
//var actors = context.Actor.OrderByDescending(a => EF.Property<DateTime>(a,"last_update"));