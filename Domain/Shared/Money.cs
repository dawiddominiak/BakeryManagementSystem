using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Shared
{
    class Money : IEquatable<Money>
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
                throw new Exception("Different currencies in addition.");
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
                throw new Exception("Different currencies in subtraction.");
            }
        }
    }
}
