using ASP.HOTELS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HotelsAsp.Controllers
{
    public class HotelsController : Controller
    {
        private static List<Hotel> _hotels = new List<Hotel>();

        public IActionResult Index()
        {
            return View(_hotels);
        }

        public IActionResult Details(int id)
        {
            Hotel hotel = _hotels.Find(h => h.HotelId == id);

            if (hotel == null)
            {
                return NotFound();
            }

            List<Hotel> hotelList = new List<Hotel> { hotel };

            return View(hotelList);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Hotel hotelToRemove = _hotels.Find(h => h.HotelId == id);

            if (hotelToRemove == null)
            {
                return NotFound();
            }

            _hotels.Remove(hotelToRemove);

            TempData["success"] = "Hotel deleted successfully";

            return RedirectToAction("Index");
        }

        public IActionResult CreateHotel()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddHotel(Hotel newHotel)
        {
            newHotel.HotelId = _hotels.Count + 1;
            _hotels.Add(newHotel);
            return RedirectToAction("Index");
        }
    }
}