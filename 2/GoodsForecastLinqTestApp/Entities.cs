namespace GoodsForecastLinqTestApp
{
    public class Group
    {
        public Group()
        {
            
        }
        public Group(int id, string name)
        {
            Id = id;
            Name = name;
        }
        
        public int Id { get; set; }

        public string Name { get; set; }
    }
    
    namespace First
    {
        public class Product
        {
            public Product()
            {
                
            }

            public Product(int id, string name, Group group)
            {
                Id = id;
                Name = name;
                GroupId = group.Id;
                Group = group;
            }
            
            public int Id { get; set; }

            public string Name { get; set; }

            public int GroupId { get; set; }

            public Group Group { get; set; }
        }    
    }

    namespace Second
    {
        public class Product
        {
            public Product(int id, string name, int groupId)
            {
                Id = id;
                Name = name;
                GroupId = groupId;
            }
            
            public int Id { get; set; }

            public string Name { get; set; }

            public int GroupId { get; set; }
        }
    }
}

    