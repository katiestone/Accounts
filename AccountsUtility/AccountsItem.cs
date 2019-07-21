using System;

namespace AccountsUtility
{
    public class AccountItem
    {
        public string name;
        public Categoy categoy;
        public string cotent;
        public string note;
        public Money money;
        public DateTime occuredTime;

        public AccountItem(string name, Categoy categoy, string cotent, string note, Money money, DateTime occuredTim){
            this.name = name;
            this.categoy = categoy;
            this.cotent = cotent;
            this.note = note;
            this.money = money;
            this.occuredTime = occuredTim;
            }

        public bool IsIncome() {
            return this.categoy == Categoy.Income;
        }

        public bool IsSpending()
        {
            return this.categoy == Categoy.Spending;
        }

        public override string ToString()
        {
            return $"name:{this.name}. cotent:{this.cotent}. note:{this.note}. amount:{Enum.GetName(typeof(Currency), this.money.currency)} {this.money.amount}. date:{this.occuredTime.ToString()}.";
        }

    }


    public enum Categoy
    {
        Spending = 1,
        Income = 2
    }
}
