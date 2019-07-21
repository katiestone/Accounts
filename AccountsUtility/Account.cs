using System;
using System.Collections.Generic;
using System.Text;

namespace AccountsUtility
{
    public class Account
    {
        public List<AccountItem> list = new List<AccountItem>();

        public void Add(AccountItem accountItem) {
            if (accountItem != null) {
                list.Add(accountItem);
            }
        }

        public bool Remove(AccountItem accountItem) {
            if (accountItem != null) {
                return list.Remove(accountItem);
            }
            return false;
        }

        public Money TotalRevenue(DateTime time)
        {
            Money money = new Money(Currency.CYN, 0);
            foreach (AccountItem m in list)
            {
                if (DateTimeExtension.isSameMonth(m.occuredTime,time))
                {
                    Money monTmp = new Money(m.money.currency, m.money.amount);
                    if (!monTmp.currency.Equals(Currency.CYN))
                    {
                        double rate = new Rate().getRate(m.money.currency);
                        monTmp.currency = Currency.CYN;
                        monTmp.amount *= rate;
                        if (m.categoy.Equals(Categoy.Income))
                        {
                            money += monTmp;
                        }
                        else {
                            money -= monTmp;
                        }
                    }
                    else
                    {
                        if (m.categoy.Equals(Categoy.Income))
                        {
                            money += monTmp;
                        }
                        else
                        {
                            money -= monTmp;
                        }
                    }
                }
            }
            return money;
        }

        public Money Total(DateTime time)
        {
            return Calculate(accuntItem =>
                accuntItem.occuredTime.isSameMonth(time)
            );
        }

        public Money TotalExpenditure(DateTime time)
        {
            Money money = new Money(Currency.CYN, 0);
            foreach (AccountItem m in list)
            {
                DateTime date = m.occuredTime;
                if (m.categoy.Equals(Categoy.Spending) && DateTimeExtension.isSameMonth(m.occuredTime, time))
                {
                    Money monTmp = new Money(m.money.currency, m.money.amount);
                    if (!monTmp.currency.Equals(Currency.CYN))
                    {
                        double rate = new Rate().getRate(m.money.currency);
                        monTmp.currency = Currency.CYN;
                        monTmp.amount *= rate;
                        money += monTmp;
                    }
                    else
                    {
                        money += monTmp;
                    }
                }
            }
            return money;
        }

        public Money Calculate(Predicate predicate)
        {
            Money money = new Money(Currency.CYN, 0);
            foreach (AccountItem m in list)
            {
                DateTime date = m.occuredTime;
                if (predicate(m))
                {
                    Money monTmp = new Money(m.money.currency, m.money.amount);
                    if (monTmp.currency != Currency.CYN)
                    {
                        double rate = new Rate().getRate(m.money.currency);
                        monTmp.currency = Currency.CYN;
                        monTmp.amount *= rate;
                        money += monTmp;
                    }
                    else
                    {
                        money += monTmp;
                    }
                }
            }
            return money;
        }

        public Money TotalIncome(DateTime time)
        {
            Money money = new Money(Currency.CYN, 0);
            foreach (AccountItem m in list)
            {
                DateTime date = m.occuredTime;
                if (Matches(date, m, Categoy.Income))
                {
                    Money monTmp = new Money(m.money.currency, m.money.amount);
                    if (monTmp.currency != Currency.CYN)
                    {
                        double rate = new Rate().getRate(m.money.currency);
                        monTmp.currency = Currency.CYN;
                        monTmp.amount *= rate;
                        money += monTmp;
                    }
                    else
                    {
                        money += monTmp;
                    }
                }
            }
            return money;
        }

        public IEnumerable<AccountItem> Display(DateTime time)
        {
            foreach (AccountItem m in list)
            {
                if (DateTimeExtension.isSameMonth(m.occuredTime, time))
                {
                    yield return m;
                }
            }
        }
        /*
        private DateTime getFirstDate(DateTime time)
        {
            return time.AddDays(1 - time.Day);
        }

        private DateTime getLastDate(DateTime date)
        {
            return date.AddDays(1 - date.Day).AddMonths(1).AddDays(-1);
        }
        */
        private bool Matches(DateTime dateTime, AccountItem accountItem, Categoy categoy) {
            return DateTimeExtension.isSameMonth(accountItem.occuredTime, dateTime) && categoy.Equals(accountItem.categoy);
        }

    }


    public delegate bool Predicate(AccountItem accountItem);
}
