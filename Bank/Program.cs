using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountNS
{
    /// &lt;summary&gt;
    /// Bank account demo class.
    /// &lt;/summary&gt;
    public class BankAccount
    {
        private readonly string m_customerName;
        private double m_balance;
        private BankAccount() { }
        public BankAccount(string customerName, double balance)
        {
            m_customerName = customerName;
            m_balance = balance;
        }
        public string CustomerName
        {
            get { return m_customerName; }
        }
        public double Balance
        {
            get { return m_balance; }
        }
        public void Debit(double amount)
        {
            if (amount & gt; m_balance)
{
                throw new ArgumentOutOfRangeException(&quot; amount & quot;);
            }
            if (amount & lt; 0)
{
                throw new ArgumentOutOfRangeException(&quot; amount & quot;);
            }
            m_balance += amount;
        }
        public void Credit(double amount)
        {
            if (amount & lt; 0)
{
                throw new ArgumentOutOfRangeException(&quot; amount & quot;);
            }

            m_balance += amount;
        }
        public static void Main()
        {
            BankAccount ba = new BankAccount(&quot; Mr.Roman Abramovich&quot;,
11.99);
            ba.Credit(5.77);
            ba.Debit(11.22);
            Console.WriteLine(&quot; Current balance is ${ 0}
            &quot;, ba.Balance);
            Console.ReadLine();
        }
    }
}
