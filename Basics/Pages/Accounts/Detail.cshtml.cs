using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Basics.Core;
using Basics.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Basics.Pages.Accounts
{
    public class DetailModel : PageModel
    {
        private readonly IAccountData accountData;

        public DetailModel(IAccountData accountData)
        {
            this.accountData = accountData;
        }
        public Account Account { get; set; }
        [TempData]
        public string Message { get; set; }

        public IActionResult OnGet(int accountId)
        {

            Account = accountData.GetById(accountId);
            if (Account == null)
                return RedirectToPage("./NotFound");
            return Page();
        }
    }
}
