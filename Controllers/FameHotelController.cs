using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Fame_Hotel.Models;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using System.Diagnostics;

namespace Fame_Hotel.Controllers
{
    public class FameHotelController : Controller
    {
        private readonly FameHotelContext _context;

        public FameHotelController(FameHotelContext context)
        {
            _context = context;
        }

        public IActionResult mainpage()
        {
            return View();
        }

        public IActionResult accommodation()
        {
            return View();
        }

        public IActionResult restoranBar()
        {
            return View();
        }

        public IActionResult poolBeach()
        {
            return View();
        }

        public IActionResult contact()
        {
            return View();
        }

        public IActionResult gallery()
        {
            return View();
        }
        public IActionResult showReservation()
        {
            return View();
        }
        public IActionResult reservation()
        {
            return View();
        }
        public IActionResult success()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateReservation(Reservation model)
        {
            if (ModelState.IsValid)
            {
                _context.Add(model);
                await _context.SaveChangesAsync();

                var accountSid = "ACeeea8a6a406ddd71ec0ee4e33d4eb9e2"; // Twilio hesap SID
                var authToken = "3daed055feec9f73a3b367a3677b2bbd"; // Twilio Auth Token
                TwilioClient.Init(accountSid, authToken);

                var messageOptions = new CreateMessageOptions(
                new PhoneNumber("+905447700595"));
                messageOptions.From = new PhoneNumber("+12622052311");
                messageOptions.Body = $"Your reservation registered under the name of {model.FirstName} {model.LastName} for {model.AdultCount} adults and {model.ChildCount} children between {model.EntryDate} - {model.ExitDate} has been received. Thank you for choosing us, we wish you a good holiday. - Fame Hotel";


                var message = MessageResource.Create(messageOptions);
                Console.WriteLine(message.Sid); // Log mesaj ID'si

                TempData["SuccessMessage"] = "Your reservation has been created.";
                return RedirectToAction("success");
            }

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
