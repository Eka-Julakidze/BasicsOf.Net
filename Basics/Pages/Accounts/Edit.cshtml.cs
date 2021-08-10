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
    public class EditModel : PageModel
    {
        private readonly IAccountData accountData;

        [BindProperty]
        public Account Account { get; set; }

        public EditModel(IAccountData accountData)
        {
            this.accountData = accountData;
        }
        public IActionResult OnGet(int? accountId)
        {
            if (accountId.HasValue)
            {
                Account = accountData.GetById(accountId.Value);
            }
            else 
            {
                Account = new Account();
            }

            if (Account == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();          
            if (Account.Id > 0)
                accountData.Update(Account);
            else
                accountData.Add(Account);            
            accountData.Commit();
            TempData["Message"] = "Account Saved!";
            return RedirectToPage("./Detail", new { accountId = Account.Id });
        }
    }
}
