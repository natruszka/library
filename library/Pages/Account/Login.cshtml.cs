using System.Security.Claims;
using library.DTOs;
using library.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace library.Pages.Account;
[IgnoreAntiforgeryToken(Order = 1001)]
public class Login : PageModel
{
    [BindProperty] public RegisterDto NewRegister { get; set; } = null!;
    private readonly MemberService _memberService;

    public Login(MemberService memberService)
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
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var result = await _memberService.Login(NewRegister);
            if (result is null)
            {
                return Page();
            }
            var claims = new List<Claim>()
            {
                new(ClaimTypes.Name, NewRegister.Username),
                new(ClaimTypes.Sid, result.Id.ToString()),
                new("Role", result.IsStaff.ToString())
            };

            var identity = new ClaimsIdentity(claims, "MyCookieAuth");
            ClaimsPrincipal claimsPrincipal = new(identity);

            await HttpContext.SignInAsync("AuthCookie", claimsPrincipal);

            return RedirectToPage("/Index");
        }
        catch
        {
            return RedirectToPage("/Account/Login");
        }
    }
}