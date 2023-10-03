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

        private readonly IproductsService _prodserv;
        public IndexModel(IproductsService prodserv)
        {
            _prodserv=prodserv; 
        }

        public void OnGet()
        { 
            Prods = _prodserv.GetProducts();
        }
    }
}