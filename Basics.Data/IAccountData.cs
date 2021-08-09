using Basics.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Basics.Data
{
    public interface IAccountData
    {
        IEnumerable<Account> GetAccountByName(string name);
        Account GetById(int id);
        Account Add(Account acc);
    }

    public class InMemoryAccountData : IAccountData
    {
        List<Account> accounts;
        public InMemoryAccountData()
        {
            accounts = new List<Account>()
            { new Account{ Id=1, Name="Linus", Lastname="Torvalds", Age=51, Citizenship="Finnish"},
              new Account{ Id=2, Name="Anders", Lastname="Hejlsberg", Age=60, Citizenship="Danish"},
              new Account{ Id=3, Name="James", Lastname="Goslink", Age=66, Citizenship="Canadian"},
              new Account{ Id=4, Name="Dennis", Lastname="Ritchie", Age=70, Citizenship="American"},
            };
        }

        public Account Add(Account acc)
        {
            accounts.Add(acc);
            acc.Id = accounts.Max(a => a.Id) + 1;
            return acc;
        }

        public IEnumerable<Account> GetAccountByName(string name=null)
        {
            return from a in accounts
                   where string.IsNullOrEmpty(name) || a.Name.StartsWith(name)
                   orderby a.Name
                   select a;

        }

        public Account GetById(int id)
        {
            return accounts.SingleOrDefault(a => a.Id == id);
        }

        public Account Update(Account acc)
        {
            var account = accounts.SingleOrDefault(r => r.Id == acc.Id);
            if (account != null)
            {
                account.Name = acc.Name;
                account.Lastname = acc.Lastname;
                account.Age = acc.Age;
                account.Citizenship = acc.Citizenship;
               
            }
            return account;
        }
    }
}
