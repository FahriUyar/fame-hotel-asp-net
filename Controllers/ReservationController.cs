using Microsoft.AspNetCore.Mvc;
using Fame_Hotel.Models;
using Microsoft.EntityFrameworkCore;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using System;
using System.Threading.Tasks;

namespace Fame_Hotel.Controllers
{
    public class ReservationController : Controller
    {
        private readonly FameHotelContext _context;

        public ReservationController(FameHotelContext context)
        {
            _context = context;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveReservation(Reservation model)
        {
            if (ModelState.IsValid)
            {
                bool result = await SaveReservationToDB(model);
                if (result)
                {
                    TempData["FirstName"] = model.FirstName;
                    TempData["LastName"] = model.LastName;
                    TempData["EntryDate"] = model.EntryDate != DateTime.MinValue ? model.EntryDate.ToString("yyyy-MM-dd") : null;
                    TempData["ExitDate"] = model.ExitDate != DateTime.MinValue ? model.ExitDate.ToString("yyyy-MM-dd") : null;
                    TempData["AdultCount"] = model.AdultCount;
                    TempData["ChildCount"] = model.ChildCount;
                    TempData["ShowRooms"] = true; // Odalar bölümünün görünürlüğünü kontrol etmek için

                    TempData["Success"] = true;
                    TempData["SuccessMessage"] = "Your reservation has been successfully saved.";
                }
                else
                {
                    TempData["ErrorMessage"] = "Failed to save reservation.";
                }
            }
            return View("ShowReservation", model);
        }

        private async Task<bool> SaveReservationToDB(Reservation model)
        {
            _context.Reservations.Add(model);
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Database save error: " + ex.Message);
                return false;
            }
        }

        public IActionResult Payment()
        {
            var model = new Reservation
            {
                FirstName = TempData["FirstName"]?.ToString(),
                LastName = TempData["LastName"]?.ToString(),
                //EntryDate = TempData["EntryDate"] != null ? DateTime.Parse(TempData["EntryDate"].ToString()) : (DateTime?)null,
                //ExitDate = TempData["ExitDate"] != null ? DateTime.Parse(TempData["ExitDate"].ToString()) : (DateTime?)null,
                AdultCount = TempData["AdultCount"] != null ? int.Parse(TempData["AdultCount"].ToString()) : 0,
                ChildCount = TempData["ChildCount"] != null ? int.Parse(TempData["ChildCount"].ToString()) : 0
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SubmitReservation(Reservation model)
        {
            if (ModelState.IsValid)
            {
                var accountSid = "ACeeea8a6a406ddd71ec0ee4e33d4eb9e2"; // Twilio hesap SID
                var authToken = "3daed055feec9f73a3b367a3677b2bbd"; // Twilio Auth Token
                TwilioClient.Init(accountSid, authToken);

                var messageOptions = new CreateMessageOptions(
                new PhoneNumber("+905447700595"));
                messageOptions.From = new PhoneNumber("+12622052311");

                //string entryDateStr = model.EntryDate.HasValue ? model.EntryDate.Value.ToString("yyyy-MM-dd") : "N/A";
                //string exitDateStr = model.ExitDate.HasValue ? model.ExitDate.Value.ToString("yyyy-MM-dd") : "N/A";

                messageOptions.Body = $"Your reservation registered under the name of {model.FirstName} {model.LastName} for {model.AdultCount} adults and {model.ChildCount} children between {model.EntryDate} - {model.ExitDate} has been received. Thank you for choosing us, we wish you a good holiday. - Fame Hotel";

                var message = await MessageResource.CreateAsync(messageOptions);
                Console.WriteLine("SMS sent: " + message.Sid); // Log mesaj ID'si

                TempData["SuccessMessage"] = "SMS confirmation sent.";
                return RedirectToAction("ShowReservation");
            }
            else
            {
                // ModelState geçersizse hata mesajlarını kontrol et
                Console.WriteLine("ModelState is invalid:");
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        Console.WriteLine(error.ErrorMessage);
                    }
                }

                TempData["ErrorMessage"] = "Failed to submit reservation. Please check the form fields.";
                return View("Payment", model);
            }
        }
    }
}