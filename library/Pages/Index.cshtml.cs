﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace library.Pages;
[Authorize]
public class Index : PageModel
{
    public void OnGet()
    {
        
    }
}