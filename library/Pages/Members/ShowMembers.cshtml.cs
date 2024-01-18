using library.Entities;
using library.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace library.Pages.Members;
[Authorize]
public class ShowMembers : PageModel
{
    public List<Member> Members { get; set; } = new();
    private readonly MemberService _memberService;

    public ShowMembers(MemberService memberService)
    {
        _memberService = memberService;
    }
    public async Task OnGet()
    {
        Members = new List<Member>(_memberService.GetAllMembers());
    }
}