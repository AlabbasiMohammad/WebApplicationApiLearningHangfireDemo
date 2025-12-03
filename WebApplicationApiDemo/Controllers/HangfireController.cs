using Microsoft.AspNetCore.Mvc;
using WebApplicationApiDemo.Data;
using WebApplicationApiDemo.General.Interfaces;

namespace WebApplicationApiDemo.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class HangfireController : Controller
    {

        private readonly ApiDbContext _context;

        public HangfireController(ApiDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Welcome()
        {
            var jobId = Hangfire.BackgroundJob.Enqueue<IEmailService> (x  => x.SendWelcomeEmail("Welcome to our app.", "name"));
            return Ok($"Job id: {jobId}. welcome email sent to the user.");
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Discount()
        {
            int seconds = 30;
            var jobId = Hangfire.BackgroundJob.Schedule<IEmailService>(x  => x.SendWelcomeEmail("Welcome to our app.", "name"), TimeSpan.FromSeconds(seconds));
            return Ok($"Job id: {jobId}. Discount mail will be sent in {seconds} seconds.");
        }


        [HttpPost]
        [Route("[action]")]
        public IActionResult DatabaseUpdate()
        {
            Hangfire.RecurringJob.AddOrUpdate("DatabaseUpdateJob", () => Console.WriteLine("Database updated."), Hangfire.Cron.Minutely);
            return Ok($"Database update job scheduled to run every minute.");
        }


        [HttpPost]
        [Route("[action]")]
        public IActionResult Confirm()
        {
            var parentJobId = Hangfire.BackgroundJob.Schedule(() => Console.WriteLine("You asked to be unsubscribed."), TimeSpan.FromSeconds(10));

            var jobId = Hangfire.BackgroundJob.ContinueJobWith(parentJobId, () => Console.WriteLine("Unsubscription confirmed."));
            //var jobId = Hangfire.BackgroundJob.ContinueJobWith("DatabaseUpdateJob", () => Console.WriteLine("Database update confirmed."));
            return Ok($"Job id: {jobId}. Confirmation job created.");
        }

        //public void SendWelcomeEmail(string text) {
        //    Console.WriteLine($"Sending welcome email with text: {text}");
        //}
    }
}
