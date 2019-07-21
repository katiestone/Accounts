using System;
using AccountsUtility;

namespace Accounts
{
    class Program
    {
        static void Main(string[] args)
        {
            Account account = new Account();
            AccountItem accountItem1 = new AccountItem("jipiao", Categoy.Spending, "flying to qingdao", "", new Money(Currency.CYN, 800), DateTime.Parse("2019-05-21"));
            AccountItem accountItem2 = new AccountItem("shoes", Categoy.Spending, "sneakers", "", new Money(Currency.CYN, 200), DateTime.Parse("2019-03-16"));
            AccountItem accountItem3 = new AccountItem("skirt", Categoy.Spending, "red short skirt", "", new Money(Currency.USD, 20), DateTime.Parse("2019-05-18"));
            AccountItem accountItem4 = new AccountItem("payment", Categoy.Income, "May pament", "", new Money(Currency.CYN, 8000), DateTime.Parse("2019-05-21"));
            AccountItem accountItem5 = new AccountItem("payment", Categoy.Income, "March payment", "", new Money(Currency.CYN, 8000), DateTime.Parse("2019-03-25"));
            AccountItem accountItem6 = new AccountItem("lotion", Categoy.Spending, "Da Bao lotion", "", new Money(Currency.Yen, 1200), DateTime.Parse("2019-03-4"));

            account.Add(accountItem1);
            account.Add(accountItem2);
            account.Add(accountItem3);
            account.Add(accountItem4);
            account.Add(accountItem5);
            account.Add(accountItem6);

            Money revenue05 = account.TotalRevenue(DateTime.Parse("2019-05"));
            Money revenue03 = account.TotalRevenue(DateTime.Parse("2019-03"));
            Money expenditure05 = account.TotalExpenditure(DateTime.Parse("2019-05"));
            Money expenditure03 = account.TotalExpenditure(DateTime.Parse("2019-03"));
            Money income05 = account.TotalIncome(DateTime.Parse("2019-05"));
            Money income03 = account.TotalIncome(DateTime.Parse("2019-03"));

            Console.WriteLine(revenue03.amount.ToString());
            Console.WriteLine(revenue05.amount.ToString());
            Console.WriteLine(expenditure03.amount.ToString());
            Console.WriteLine(expenditure05.amount.ToString());
            Console.WriteLine(income03.amount.ToString());
            Console.WriteLine(income05.amount.ToString());

            foreach (AccountItem item in account.Display(DateTime.Parse("2019-03")))
            {
                Console.WriteLine(item.ToString());
            };
            foreach (AccountItem item in account.Display(DateTime.Parse("2019-05")))
            {
                Console.WriteLine(item.ToString());
            };

            //Console.WriteLine(accountItem1.ToString());
        }
    }
}
