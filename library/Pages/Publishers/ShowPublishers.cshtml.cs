using library.Entities;
using library.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace library.Pages.Publishers;
[Authorize]
public class ShowPublishers : PageModel
{
    public List<Publisher> Publishers { get; set; } = new();
    private readonly IPublisherService _publisherService;

    public ShowPublishers(IPublisherService publisherService)
    {
        _publisherService = publisherService;
    }
    public void OnGet()
    {
        Publishers = new List<Publisher>(_publisherService.GetAllPublishers());
    }
    
}