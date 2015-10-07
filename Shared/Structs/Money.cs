﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Structs
{
    public class Money : IEquatable<Money>
    {
        public decimal Amount { get; set; }
        public Currency Currency { get; set; }

        public bool Equals(Money otherMoney)
        {

            if (this.Amount == otherMoney.Amount && this.Currency == otherMoney.Currency)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

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

            return (money1.Amount == money2.Amount && money1.Currency == money2.Currency);
        }

        public static bool operator !=(Money money1, Money money2)
        {

            return !(money1 == money2);
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
            var money = (Money) obj;

            return (money.Amount == Amount && money.Currency == Currency);
        }
    }
}