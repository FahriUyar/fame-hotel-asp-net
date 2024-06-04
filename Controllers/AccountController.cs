using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Fame_Hotel.Models;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
 
namespace Fame_Hotel.Controllers
{
    public class AccountController : Controller
    {
        private readonly FameHotelContext _context;

        public AccountController(FameHotelContext context)
        {
            _context = context;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(Reservation model)
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
                messageOptions.Body = messageOptions.Body = $"Your reservation registered under the name of {model.FirstName} {model.LastName} for {model.AdultCount} adults and {model.ChildCount} children between {model.EntryDate} - {model.ExitDate} has been received. Thank you for choosing us, we wish you a good holiday. - Fame Hotel";


                var message = MessageResource.Create(messageOptions);
                Console.WriteLine(message.Sid); // Log mesaj ID'si

                TempData["SuccessMessage"] = "Your reservation has been created.";
            }

            return View(model);
        }

    }
}

