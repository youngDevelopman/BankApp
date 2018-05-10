using System;
using System.Collections.Generic;
using System.Text;

namespace BankLibrary
{
    interface IAccount
    {
        // Положить деньги на счёт
        void Put(decimal sum);
        // Снять со счёта
        decimal Withdraw(decimal sum);
    }
}
