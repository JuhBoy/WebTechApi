using System.Collections.Generic;

namespace CommandLib {
    public sealed class Product {
        public int Id { get; internal set; }
        public string Name { get; internal set; }
        public IList<Price> Prices { get; internal set; }

        internal Product() { } // Default constructor required for EF CORE ORM
        
        internal Product(int id, string name, IList<Price> prices) { // FORCING the type to be instantied by the lib. (internal)
            Id = id;
            Name = name;
            Prices = prices;
        }
    }
}