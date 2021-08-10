using System.Linq;
using Basics.Core;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Basics.Data
{
    public class SqlAccountData : IAccountData
    {
        private readonly BasicsDbContext db;

        public SqlAccountData(BasicsDbContext db)
        {
            this.db = db;
        }
        public IEnumerable<Account> GetAccountByName(string name)
        {
            var query = from a in db.Accounts
                        where a.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                        orderby a.Name
                        select a;
            return query;
        }

        public Account GetById(int id)
        {
            return db.Accounts.Find(id);
        }
        public Account Add(Account acc)
        {
            db.Add(acc);
            return acc;
        }
      
        public Account Delete(int id)
        {
            var account = GetById(id);
            if (account != null)
            {
                db.Accounts.Remove(account);
            }
            return account;
       }
   
        public Account Update(Account acc)
        {
            var entity = db.Accounts.Attach(acc);
            entity.State = EntityState.Modified;
            return acc;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }
    }
}
