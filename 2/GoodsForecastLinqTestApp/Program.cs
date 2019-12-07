using System;
using System.Collections.Generic;
using System.Linq;

namespace GoodsForecastLinqTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Group g1 = new Group( 1,"Игрушки");
            Group g2 = new Group(2,"Кулинария");
            Group g3 = new Group(3, "Лекарства");
            
            IEnumerable<Group> groups = new Group[]
            {
                g1,
                g2,
                g3
            };
            
            List<int> productsIds = new List<int>{2,4,8,11,153};
            
            //2.1
            IEnumerable<First.Product> productsFirst = new First.Product[]
            {
                new First.Product(1,"Мишка",g1), 
                new First.Product(2,"Haskell",g1),
                new First.Product(3,"Машинка",g1),
                
                new First.Product(4,"Best practice cook book",g2),
                new First.Product(5,"Каши за 5 минут",g2),
                
                new First.Product(6,"Анальгин",g3),
                new First.Product(7,"Лечебные травы",g3), 
            };
            
            var resultFirst = productsFirst
                .Where(p => productsIds.Contains(p.Id))
                .Select(p => new { ProductName = p.Name, GroupName = p.Group.Name});

            Console.WriteLine("2.1");
            
            foreach (var rf in resultFirst)
            {
                Console.WriteLine(rf);
            }
            
            //2.2
            //Если мы говорим о сущностях получаемых из реляционной БД. То тут нарушена ссылочная целостность
            IEnumerable<Second.Product> productsSecond = new[]
            {
                new Second.Product(1, "Мишка", 1),
                new Second.Product(2, "Кролик", 1),
                new Second.Product(3, "Машинка", 1),

                new Second.Product(4, "Best practice cook book", 2),
                new Second.Product(5, "Каши за 5 минут", 2),

                new Second.Product(6, "Анальгин", 3),

                new Second.Product(7, "Лечебные травы", 5),

                new Second.Product(8, "Что-то ещё", 12)
            };

            var resultSecond =
                from product in productsSecond
                where productsIds.Contains(product.Id)
                join @group in groups on product.GroupId equals @group.Id into outer
                from o in outer.DefaultIfEmpty()
                select new {ProductName = product.Name, GroupName = o?.Name ?? "No Group"};

            Console.WriteLine("2.2");

            foreach (var rs in resultSecond)
            {
                Console.WriteLine(rs);
            }

            Console.ReadKey();
        }
    }
}