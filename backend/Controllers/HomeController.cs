using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

public class HomeController : Controller {
    private readonly TravelSettings Settings;

    public HomeController(IOptions<TravelSettings> settings) {
        this.Settings = settings.Value;
    }

    public IActionResult Index() {
        var model = new {
            TravelSettings = this.Settings,

            // testing xss
            TestString = "</script><script>alert('hahah')</script>"
        };

        return View(model);
    }
}