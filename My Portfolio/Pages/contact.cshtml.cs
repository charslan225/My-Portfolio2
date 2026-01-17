using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace My_Portfolio.Pages
{
public class ContactModel : PageModel
{
private readonly EmailServices _email;


public ContactModel(EmailServices email)
{
_email = email;
}

[Required(ErrorMessage = "Name is required")]
[BindProperty] public string Name { get; set; }
[Required(ErrorMessage = "Email is required")]
[EmailAddress(ErrorMessage = "Invalid email address")]
[BindProperty] public string Email { get; set; }
[Required(ErrorMessage = "Message is required")]
[BindProperty] public string Message { get; set; }


public void OnGet() { }


public IActionResult OnPost()
{
    if (!ModelState.IsValid)
    {
        TempData["Error"] = "Please fill all fields correctly.";
        return Page();
    }

    _email.Send(Name, Email, Message);

    TempData["Success"] = "Message sent successfully!";

    // 🔥 MOST IMPORTANT LINE
    return RedirectToPage();
}
}
}
