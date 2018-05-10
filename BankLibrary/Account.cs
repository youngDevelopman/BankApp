using System;
using System.Collections.Generic;
using System.Text;

namespace BankLibrary
{
    public abstract class Account:IAccount
    {
        protected internal event AccountStateHandler Withdrawed;
        protected internal event AccountStateHandler Added;
        protected internal event AccountStateHandler Opened;
        protected internal event AccountStateHandler Closed;
        protected internal event AccountStateHandler Calculated;

        protected int id = 0;
        protected int percentage = 0;
        protected int days = 0;
        protected decimal sum = 0;
        static int counter = 0;

        public Account(decimal sum, int percentage)
        {
            this.sum = sum;
            this.percentage = percentage;
        }
        
        public decimal CurrentSum
        {
            get { return sum; }
        }

        public int Percentage
        {
            get { return percentage; }
        }

        public int Id
        {
            get { return id; }
        }

        private void CallEvent(AccountEventArgs e,AccountStateHandler handler)
        {
            if(handler != null && e != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnOpened(AccountEventArgs e)
        {
            CallEvent(e, Opened);
        }

        protected virtual void OnWithdrawed(AccountEventArgs e)
        {
            CallEvent(e, Withdrawed);
        }

        protected virtual void OnAdded(AccountEventArgs e)
        {
            CallEvent(e, Added);
        }

        protected virtual void OnClosed(AccountEventArgs e)
        {
            CallEvent(e, Closed);
        }

        protected virtual void OnCalculated(AccountEventArgs e)
        {
            CallEvent(e, Calculated);
        }

        public virtual void Put(decimal sum)
        {
            this.sum += sum;
            OnAdded(new AccountEventArgs("На счет поступило " + sum, sum));
        }

        public virtual decimal Withdraw(decimal sum)
        {
            if(this.sum >= sum)
            {
                this.sum -= sum;
                OnWithdrawed(new AccountEventArgs("Со счета снято " + sum, sum));
            }
            else
            {
                OnWithdrawed(new AccountEventArgs("Недостаточно денег на счету", 0));
            }
            return sum;
        }

        public virtual void Open()
        {
            OnOpened(new AccountEventArgs("Открыт новый депозитный счет. Id счета : " + this.Id, this.CurrentSum));
        }

        protected internal void IncrementDays()
        {
            days++;
        }

        protected internal virtual void Calculate()
        {
            decimal increment = sum * percentage / 100;
            sum += increment;
            OnCalculated(new AccountEventArgs("Начислены проценты в размере" + increment, increment));
        }
    }
}
