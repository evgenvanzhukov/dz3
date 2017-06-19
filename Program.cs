using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Price> pricelist = new List<Price>(10);
            pricelist.Add(new Price {Name = "Огурец", PriceKG = 90 });
            pricelist.Add(new Price { Name = "Капуста", PriceKG = 80 });
            pricelist.Add(new Price { Name = "Грибы", PriceKG = 300 });
            pricelist.Add(new Price { Name = "Помидоры", PriceKG = 130 });
            pricelist.Add(new Price { Name = "Финики", PriceKG = 100 });
            pricelist.Add(new Price { Name = "Орехи", PriceKG = 600 });
            pricelist.Add(new Price { Name = "Мандарины", PriceKG = 150 });
            pricelist.Add(new Price { Name = "Апельсины", PriceKG = 120 });
            pricelist.Add(new Price { Name = "Яблоки", PriceKG = 80 });
            pricelist.Add(new Price { Name = "Черешня", PriceKG = 200 });


            List<Items> buyList = new List<Items>();
            buyList.Add(new Items {Name= "Черешня", KG = 2 });
            buyList.Add(new Items { Name = "Яблоки", KG = 5 });
            buyList.Add(new Items { Name = "Огурец", KG = 3 });
            buyList.Add(new Items { Name = "Капуста", KG = 1 });
            buyList.Add(new Items { Name = "Орехи", KG = 0.5 });
            buyList.Add(new Items { Name = "Помидоры", KG = 3 });
            buyList.Add(new Items { Name = "Финики", KG = 1.5 });
            buyList.Add(new Items { Name = "Апельсины", KG = 4 });


            double allprice = 0;
            double allves = 0;
            foreach (Items item in buyList)
            {
                var priceitem = (from price in pricelist where price.Name.Equals(item.Name) select price.PriceKG);
                allprice = allprice + item.KG * priceitem.Sum();
                //allprice = allprice + item.KG*priceitem; 
                allves = allves + item.KG;
            }
            var avg = allprice / allves;
            Console.WriteLine(avg);
            Console.ReadLine();

        }
    }


    class Price:Items
    {
        public int PriceKG { get; set; }
    }

    class Items
    {
        public string Name { get; set; }
        public double KG { get; set; }
    }
}
