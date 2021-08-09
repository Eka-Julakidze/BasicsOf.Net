using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Basics.Core;
using Basics.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace Basics.Pages.Accounts
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IAccountData accountData;

        [BindProperty(SupportsGet=true)]
        public string SearchTerm { get; set; }
        public IEnumerable<Account> Accounts { get; set; }

        public ListModel(IConfiguration config, IAccountData accountData)
        {
            this.config = config;
            this.accountData = accountData;
        }

        public void OnGet()
        {       
            Accounts = accountData.GetAccountByName(SearchTerm);
        }
    }
}
