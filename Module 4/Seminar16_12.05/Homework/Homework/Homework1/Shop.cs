using System;


namespace Homework
{
    class Shop : IEntity
    {
        public long Id { get; }
        public string Name { get; }

        public Shop(long id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
