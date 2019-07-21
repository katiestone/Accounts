using System;
using System.Collections.Generic;
using System.Text;

namespace AccountsUtility
{
    class Rate
    {
        public Currency currency;

        public float rate;

        public double getRate(Currency currency)
        {
            if (Currency.USD == currency)
            {
                return 6.9;
            }
            else if (Currency.Yen == currency)
            {
                return 0.06394;
            }
            else
            {
                return 1;
            }
        }
    }
}
