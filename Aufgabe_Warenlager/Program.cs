using Aufgabe_Warenlager.Models;

namespace Aufgabe_Warenlager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductContext context = new ProductContext();

           // context.SavetoDatabase();


           // Console.WriteLine(context);


            var aus = context.Artikeln.Where(x => x.Istbestand - (x.VerbrauchProTag + x.BestelldauerInTagen + 2) < 0 );

            foreach ( var item in aus )
            {
                Console.WriteLine(item);
            }


        }
    }
}
