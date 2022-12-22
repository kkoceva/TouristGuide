using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static TouristGuide.Areas.Admin.Constants.AdminConstants;

namespace TouristGuide.Areas.Admin.Controllers
{
    [Area(AreaName)]
    [Route("/Admin/[controller]/[Action]/{id?}")]
    [Authorize(Roles = AdminRoleName)]

    public class BaseController : Controller
    {
    }
}
