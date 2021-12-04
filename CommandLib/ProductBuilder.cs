using System;
using System.Collections.Generic;

namespace CommandLib {
    // Used to create Products (Product is internal to CommandLib.dll)
    public class ProductBuilder {
        private int _id;
        private string _name;
        private List<Price> _prices;

        public ProductBuilder() {
            _id = -1;
            _prices = new List<Price>();
        }

        public ProductBuilder SetId(int id) {
            _id = id;
            return this;
        }

        public ProductBuilder SetName(string name) {
            _name = name;
            return this;
        }

        public ProductBuilder AddPrice(Price price) {
            _prices.Add(price);
            return this;
        }

        public Product Build() {
            TrySetDefault();
            return new Product(_id, _name, _prices);
        }

        private void TrySetDefault() {
            if (_id == -1) {
                var r = new Random();
                _id = r.Next();
            }

            if (string.IsNullOrEmpty(_name)) {
                _name = "Default";
            }
        }
    }
}