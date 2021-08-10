using Basics.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Basics.Data
{
    public interface IAccountData
    {
        IEnumerable<Account> GetAccountByName(string name);
        Account GetById(int id);
        Account Add(Account acc);
        Account Delete(int id);
        Account Update(Account acc);
        int Commit();
    }
}
