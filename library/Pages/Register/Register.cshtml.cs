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
    [BindProperty] public RegisterDto NewRegister { get; set; } = null!;
    [BindProperty] public MemberDto NewMember { get; set; } = null!;
    private readonly MemberService _memberService;

    public Register(MemberService memberService)
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
            var id = await _memberService.AddNewMember(NewMember, NewRegister);
            var claims = new List<Claim>()
            {
                new(ClaimTypes.Name, NewRegister.Username),
                new(ClaimTypes.Sid, id),
                new("Role", NewMember.IsStaff.ToString())
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