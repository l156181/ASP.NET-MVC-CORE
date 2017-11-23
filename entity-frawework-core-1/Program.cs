using System;
using entity_frawework_core_1.Model;


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
            }
        }
    }
}
