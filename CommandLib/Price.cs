using System;

namespace CommandLib {
    public sealed class Price {
        public enum CurrencyType {
            Euro,
            Dollar
        }

        public int Id { get; internal set; }
        public DateTime DateTime { get; internal set; }
        public int ProductForeignKey { get; internal set; }
        public CurrencyType Currency { get; internal set; }
        public float Amount { get; internal set; }

        internal Price() { } // Default constructor required for EF CORE ORM

        internal Price(int id, CurrencyType currency, float amount, int productForeignKey, DateTime dateTime) {
            Id = id;
            Currency = currency;
            Amount = amount;
            ProductForeignKey = productForeignKey;
            DateTime = dateTime;
        }
    }
}