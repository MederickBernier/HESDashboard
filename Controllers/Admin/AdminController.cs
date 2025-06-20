using Microsoft.AspNetCore.Mvc;

namespace HESDashboard.Controllers.Admin;
public class AdminController : Controller {
    public IActionResult Index() {
        return View();
    }
}
