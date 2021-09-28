using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseConstructors
{
    class Program
    {
        static void Main(string[] args)
        {
            Coffee coffee1 = new Coffee();
            Coffee coffee2 = new Coffee("Fourth Espresso", true, 170, "Arabica", "Dark", "Columbia");

            //1 definir outro tipo de beverage e instanciar algumas instancias
            Beer def = new Beer();
            Beer erdinger = new Beer("Erdinger", true, 2, "Wheat", "Weissbier", "Germany");
            Beer mikkeller = new Beer("Mikkeller", true, 2, "Malt", "IPA", "Denmark");
            Beer superBock = new Beer("Super Bock", true, 2, "Barley", "Pilsner", "Portugal");
            Beer stellaArtois = new Beer("Franciscano", true, 2, "Malt", "Pilsner", "Belgium");

            // 2 colecionar as instancias de todas as bebidas numa coleção generica

            List<Beverage> beverages = new List<Beverage>();
            beverages.Add(coffee1);
            beverages.Add(coffee2);
            beverages.Add(erdinger);
            beverages.Add(mikkeller);
            beverages.Add(superBock);
            beverages.Add(stellaArtois);
            beverages.Add(def);

            // 3 num foreach imprimir todas as beverages

            foreach (Beverage b in beverages)
            {
                switch (b.GetType().Name)
                {
                    case "Coffee":
                        var c = (Coffee)b;
                        Console.WriteLine("Coffee Name: {0}", c.Name);
                        Console.WriteLine("Fair Trade: {0}", c.IsFairTrade);
                        Console.WriteLine("Serving Temperature: {0}", c.GetServingTemperature());
                        Console.WriteLine("Bean Type: {0}", c.Bean);
                        Console.WriteLine("Roast Type: {0}", c.Roast);
                        Console.WriteLine("Country of Origin: {0}", c.CountryOfOrigin);
                        Console.WriteLine();
                        break;
                    case "Beer":
                        var d = (Beer)b;
                        Console.WriteLine("Beer Name: {0}", d.Name);
                        Console.WriteLine("Fair Trade: {0}", d.IsFairTrade);
                        Console.WriteLine("Serving Temperature: {0}", d.GetServingTemperature());
                        Console.WriteLine("Grain Type: {0}", d.Cereal);
                        Console.WriteLine("Beer Type: {0}", d.TypeOf);
                        Console.WriteLine("Country of Origin: {0}", d.CountryOfOrigin);
                        Console.WriteLine();
                        break;
                }
            }
            Console.WriteLine("End of the list");
            Console.Read();
        }
    }
}
