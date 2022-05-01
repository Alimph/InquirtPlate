using InquiryPlate.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Inquiry.Controllers
{
    public class InquiryPlateController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public InquiryPlateController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> GetInquiry(PlateModel model)
        {
            if (ModelState.IsValid)
            {
                var plate = await _appDbContext.Plates.Include(x => x.Infractions).FirstOrDefaultAsync(p => p.LicensePlate == model.LicensePlate);
                if (plate != null)
                    return new JsonResult(plate.Infractions);
            }
            return NotFound();
        }

        public class PlateModel
        {
            public string LicensePlate { get; set; }
        }
    }
}