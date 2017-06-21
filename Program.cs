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
            List<Price> priceList = new List<Price>(10);
            Price.Initprice(priceList);


            List<Items> buyList = new List<Items>();
            Items.initBuyList(buyList);


            decimal allprice = new Decimal(0.00);
            decimal allves = new Decimal(0.00);



            var result = buyList.Join(
                priceList,
                __buy => __buy.Name,
                __price => __price.Name,
                (__buy, __price) => new
                {
                    money = __buy.KG*__price.PriceKG, ves =  __buy.KG
                });
            allprice = result.Sum(__m => __m.money);
            allves = result.Sum(__v => __v.ves);

            decimal avg = (allprice / allves);
            
            Console.WriteLine("{0:C}",avg);
            Console.ReadLine();

        }
    }


    public class Price:Items
    {
        public decimal PriceKG { get; set; }

        public static void Initprice(List<Price> priceList)
        {
            priceList.Add(new Price { Name = "Огурец", PriceKG = 90 });
            priceList.Add(new Price { Name = "Капуста", PriceKG = 80 });
            priceList.Add(new Price { Name = "Грибы", PriceKG = 300 });
            priceList.Add(new Price { Name = "Помидоры", PriceKG = 130 });
            priceList.Add(new Price { Name = "Финики", PriceKG = 100 });
            priceList.Add(new Price { Name = "Орехи", PriceKG = 600 });
            priceList.Add(new Price { Name = "Мандарины", PriceKG = 150 });
            priceList.Add(new Price { Name = "Апельсины", PriceKG = 120 });
            priceList.Add(new Price { Name = "Яблоки", PriceKG = 80 });
            priceList.Add(new Price { Name = "Черешня", PriceKG = 200 });
        }

    }

    public class Items
    {
        public string Name { get; set; }
        public decimal KG { get; set; }

        public static void initBuyList(List<Items> buyList)
        {
            buyList.Add(new Items { Name = "Черешня", KG = 2 });
            buyList.Add(new Items { Name = "Яблоки", KG = 5 });
            buyList.Add(new Items { Name = "Огурец", KG = 3 });
            buyList.Add(new Items { Name = "Капуста", KG = 1 });
            buyList.Add(new Items { Name = "Орехи", KG = 2.50m });
            buyList.Add(new Items { Name = "Помидоры", KG = 3 });
            buyList.Add(new Items { Name = "Финики", KG = 1.50m });
            buyList.Add(new Items { Name = "Апельсины", KG = 4 });
        }
    }


}
