using Frameworks.Models;

namespace Frameworks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductContext context = new ProductContext();



            //Category category = new Category() { Name = "Lebensmittel" };
            //context.Categories.Add(category);
            //context.Products.Add(new Product()
            //{
            //    Name = "Banane",
            //    Price = 1.99,
            //    Category = category
            //});

            //context.SaveChanges();

            List<Product> lst = context.Products.Where(x => x.Price == 1.99).ToList();
            List<Category> cat = context.Categories.ToList();

            lst.ForEach(x => { 
                Console.WriteLine(x);
                if(x.Category != null)
                {
                    Console.WriteLine(x.Category.Name);
                }

            }) ;
            
        }
    }
}
