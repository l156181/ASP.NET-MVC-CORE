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
                
                foreach(var actor in context.Actor){
                    Console.WriteLine(actor);
                    
                }

                foreach(var film in context.Film){
                    Console.WriteLine(film);
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