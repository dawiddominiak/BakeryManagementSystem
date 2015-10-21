using System;
using System.Text;
using Shared.Exceptions;

namespace Shared.Structs
{
    public struct Money : IEquatable<Money>
    {
        public decimal Amount { get; private set; }
        public Currency Currency { get; private set; }

        public Money(decimal amount) : this(amount, Currency.Undefined)
        {
            if (amount != 0m)
            {
                throw new NoCurrencySpecifiedException();
            }
        }

        public Money(decimal amount, Currency currency) : this()
        {
            Amount = amount;
            Currency = currency;
        }

        public static Money operator +(Money money1, Money money2)
        {
            var currency = GetDefinedCurrency(money1, money2);
            
            return new Money(money1.Amount + money2.Amount, currency);
        }

        public static Money operator -(Money money1, Money money2)
        {

            var currency = GetDefinedCurrency(money1, money2);

            return new Money(money1.Amount - money2.Amount, currency);
        }

        public static Money operator *(Money money, int times)
        {

            return new Money
            {
                Amount = money.Amount * times,
                Currency = money.Currency
            };
        }

        public static Money operator *(int times, Money money)
        {
            return new Money
            {
                Amount = money.Amount * times,
                Currency = money.Currency
            };
        }

        public static Money operator /(Money money, int divident)
        {

            return new Money
            {
                Amount = money.Amount / divident,
                Currency = money.Currency
            };
        }

        private static Currency GetDefinedCurrency(Money money1, Money money2)
        {

            if (money1.Currency == Currency.Undefined || money2.Currency == Currency.Undefined)
            {
                if (money1.Currency != Currency.Undefined)
                {
                    return money1.Currency;
                }

                if (money2.Currency != Currency.Undefined)
                {
                    return money2.Currency;
                }
            } else if (money1.Currency == money2.Currency)
            {
                return money1.Currency;
            }
            else
            {
                throw new DifferentOperationCurrenciesException("Different currencies in addition.");
            }

            return Currency.Undefined; //It shouldn't occur
        }

        public static bool operator ==(Money money1, Money money2)
        {
            return (money1.Amount == money2.Amount && money1.Currency == money2.Currency);
        }

        public static bool operator !=(Money money1, Money money2)
        {

            return !(money1 == money2);
        }

        public static Money FromNative(decimal amount, string currency)
        {
            Currency enumerableCurrency;
            Enum.TryParse(currency, out enumerableCurrency);

            return new Money
            {
                Amount = amount,
                Currency = enumerableCurrency
            };
        }

        public override int GetHashCode()
        {
            var hashStringBuilder = new StringBuilder();
            hashStringBuilder.Append(Amount);
            hashStringBuilder.Append(Currency.GetHashCode());

            return hashStringBuilder.ToString().GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is Money && Equals((Money)obj);
        }

        public bool Equals(Money other)
        {
            return (Amount == other.Amount && Currency == other.Currency);
        }
    }
}
