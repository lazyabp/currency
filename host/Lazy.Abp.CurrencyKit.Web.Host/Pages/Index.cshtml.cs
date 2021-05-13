using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace Lazy.Abp.CurrencyKit.Pages
{
    public class IndexModel : CurrencyKitPageModel
    {
        public void OnGet()
        {
            
        }

        public async Task OnPostLoginAsync()
        {
            await HttpContext.ChallengeAsync("oidc");
        }
    }
}