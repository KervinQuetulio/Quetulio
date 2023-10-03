using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Quetulio.Models;
using Quetulio.Services;

namespace Quetulio.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public List<products> Prods;


        public void OnGet()
        {
            productsService prdsrvs = new productsService(); 
            Prods = prdsrvs.GetProducts();
        }
    }
}