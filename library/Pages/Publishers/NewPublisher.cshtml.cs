using library.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace library.Pages.Publishers;

[IgnoreAntiforgeryToken(Order = 1001)]
[Authorize(Policy = "IsStaff")]
public class NewPublisher : PageModel
{
    [BindProperty] public String Name { get; set; } = string.Empty;
    private readonly IPublisherService _publisherService;

    public NewPublisher(IPublisherService publisherService)
    {
        _publisherService = publisherService;
    }
    
    public async Task OnGet()
    {
        
    }

    public async Task<IActionResult> OnPostAsync()
    {
        await _publisherService.AddNewPublisher(Name);
        return RedirectToPage("/Publishers/ShowPublishers");
    }
}