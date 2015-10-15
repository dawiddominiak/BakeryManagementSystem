using System;
using System.Text;

namespace Shared.Structs
{
    public class Money : IEquatable<Money>, IValueObject<Money>
    {
        public decimal Amount { get; set; }
        public Currency Currency { get; set; }

        public static Money operator +(Money money1, Money money2)
        {

            if(money1.Currency == money2.Currency)
            {
                return new Money
                {
                    Amount = money1.Amount + money2.Amount,
                    Currency = money1.Currency
                };
            }
            else
            {
                throw new Exceptions.DifferentOperationCurrenciesException("Different currencies in addition.");
            }
        }

        public static Money operator -(Money money1, Money money2)
        {

            if (money1.Currency == money2.Currency)
            {
                return new Money
                {
                    Amount = money1.Amount + money2.Amount,
                    Currency = money1.Currency
                };
            }
            else
            {
                throw new Exceptions.DifferentOperationCurrenciesException("Different currencies in subtraction.");
            }
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

        public static bool operator ==(Money money1, Money money2)
        {
            if (money1 == null && money2 == null)
            {
                return true;
            }

            if (money1 == null || money2 == null)
            {
                return false;
            }

            return (money1.Amount == money2.Amount && money1.Currency == money2.Currency);
        }

        public static bool operator !=(Money money1, Money money2)
        {

            return !(money1 == money2);
        }

        public static Money FromNative(decimal amount, string currency)
        {
            Currency enumerableCurrency;
            Currency.TryParse(currency, out enumerableCurrency);

            return new Money
            {
                Amount = amount,
                Currency = enumerableCurrency
            };
        }

        public bool Equals(Money otherMoney)
        {
            return SameValueAs(otherMoney);
        }

        public override bool Equals(object o)
        {
            return SameValueAs((Money)o);
        }

        public override int GetHashCode()
        {
            var hashStringBuilder = new StringBuilder();
            hashStringBuilder.Append(Amount);
            hashStringBuilder.Append(Currency.GetHashCode());

            return hashStringBuilder.ToString().GetHashCode();
        }

        public bool SameValueAs(Money other)
        {
            return (Amount == other.Amount && Currency == other.Currency);
        }
    }
}
