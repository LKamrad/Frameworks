using AufgabeSchnecke.Models;

namespace AufgabeSchnecke
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (SchneckerennenContext context = new SchneckerennenContext())
            {

                //Rennschnecke mike = new Rennschnecke("Mike", 4);
                //Rennschnecke alice = new Rennschnecke("Alice", 5);
                //Rennschnecke lilith = new Rennschnecke("Lilith", 5);
                //Rennschnecke jack = new Rennschnecke("Jack", 4);
                //Rennschnecke judith = new Rennschnecke("Judith", 5);
                //Rennschnecke joe = new Rennschnecke("Joe", 4);
                //Rennschnecke slick = new Rennschnecke("Slick", 5);

                //Rennen grandTour = new Rennen("Grand Tour", 7, 40);

                //grandTour.AddRennschnecke(mike);
                //grandTour.AddRennschnecke(alice);
                //grandTour.AddRennschnecke(lilith);
                //grandTour.AddRennschnecke(jack);
                //grandTour.AddRennschnecke(judith);
                //grandTour.AddRennschnecke(joe);
                //grandTour.AddRennschnecke(slick);

                //Wettbüro wtb = new Wettbüro(grandTour, 4, "WTBBüro");

                //wtb.WetteAnnehmen("Alice", 40, "Livia");
                //wtb.WetteAnnehmen("Lilith", 30, "Robert");
                //wtb.WetteAnnehmen("Jack", 25, "John");
                //wtb.WetteAnnehmen("Mike", -25, "Gertrude");
                //wtb.WetteAnnehmen("Judith", 100, "Rafael");
                //wtb.WetteAnnehmen("joe", -15, "Livia");
                //wtb.WetteAnnehmen("slick", 20, "John");

                //context.WettBüro.Add(wtb);



                foreach(var item in context.WettBüro)
                {
                    if(item.Rennen != null)
                    {
                        Console.WriteLine(item.Rennen.Name);
                    }
                    
                }


                context.SaveChanges();

                
            }
                

            


        }
    }
}
