using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class LogoutModel : PageModel
{
    public IActionResult OnGet()
    {
        // =============================
        // 1) Eliminar toda la sesión
        // =============================
        HttpContext.Session.Clear();

        // ==========================================================
        // 2) Seguridad adicional: eliminar cookie de autenticación
        //    (si se llegara a usar en el futuro)
        // ==========================================================
        Response.Cookies.Delete(".AspNetCore.Session");

        // =============================================
        // 3) Redirigir al Login (que es /Index)
        // =============================================
        return RedirectToPage("/Index");
    }
}
