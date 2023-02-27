using Application.Common.Interfaces;
using Application.MainIndex;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebUI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public IEnumerable<KeyValuePair<string, string>> IssueKeyValue { get; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            IIndex getIssues = new GetIssues();
            IssueKeyValue = getIssues.IssueKeyValue.Select(x => new KeyValuePair<string, string>("./" + x.Key + "Pages/Index", x.Value));
        }
    }
}