namespace Bidding.Web.Pages;

public class LoginModel : PageModel
{
    public async Task<IActionResult> Login()
    {
        var form = await HttpContext.Request.ReadFormAsync();
        var email = form["email"];
        var password = form["password"];

        if(username == "admin" && password == "admin")
        {
            return RedirectToPage("/Home");
        }
    }

}