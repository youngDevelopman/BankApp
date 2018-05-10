using System;
using System.Collections.Generic;
using System.Text;

namespace BankLibrary
{
    public class DemandAccount:Account
    {
        public DemandAccount(decimal sum, int percentage):base(sum,percentage)
        {

        }

       public override void Open()
       {
            base.OnOpened(new AccountEventArgs("Открыт новый счёт до востребования! Id счета: " + this.Id, this.Id));
       }
    }
}
