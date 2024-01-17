using System.Security.Claims;
using AspNetCoreHero.ToastNotification.Abstractions;
using library.DTOs;
using library.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Npgsql;

namespace library.Pages.Register;

[IgnoreAntiforgeryToken(Order = 1001)]
public class Register : PageModel
{
    [TempData]
    public string FormResult { get; set; }
    [BindProperty] public RegisterDto NewRegister { get; set; } = null!;
    [BindProperty] public MemberDto NewMember { get; set; } = null!;
    private readonly MemberService _memberService;

    public Register(MemberService memberService, INotyfService toastNotifService)
    {
        _memberService = memberService;

    }
    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPost()
    {
        try
        {
            await _memberService.AddNewMember(NewMember, NewRegister);
            var claims = new List<Claim>()
            {
                // new(ClaimTypes.Name, result.UserName),
                // new(ClaimTypes.GivenName, result.DisplayName),
                // new(ClaimTypes.Sid, result.Id)
            };
            var identity = new ClaimsIdentity(claims, "AuthCookie");
            ClaimsPrincipal claimsPrincipal = new(identity);
            
            await HttpContext.SignInAsync("AuthCookie", claimsPrincipal);

            return RedirectToPage("/Index");
        }
        catch (NpgsqlException ex)
        {
            Console.WriteLine(ex.Message);
            return Page();
        }
    }
}