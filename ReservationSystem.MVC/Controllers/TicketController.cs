using Microsoft.AspNetCore.Mvc;
using ReservationSystem.BL;
using ReservationSystem.BL.ViewModels;
using ReservationSystem.DAL.Models;

namespace ReservationSystem.MVC.Controllers
{
    public class TicketController : Controller
    {
        private readonly ITicketsManager _ticketsManager;

        public TicketController(ITicketsManager ticketsManager)
        {
            _ticketsManager = ticketsManager;
        }
        public IActionResult Index()
        {
            return View(_ticketsManager.GetAll());
        }

        public IActionResult Details(int id)
        {
            var ticket = _ticketsManager.Get(id);
            if (ticket is null)
            {
                View("TicketNotFound");
            }
            return View(ticket);
        }
        #region add
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddVM ticket)
        {
            _ticketsManager.Add(ticket);
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Edit
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var ticketToEdit = _ticketsManager.Get(id);
            if (ticketToEdit is null)
            {
                View("TicketNotFound");
            }
            var ticketVM = new EditVM
            {
                Id = ticketToEdit.Id,
                Title= ticketToEdit.Title,
                Description = ticketToEdit.Description,
                Severity = ticketToEdit.Severity,
            };
            return View(ticketVM);
        }

        [HttpPost]
        public IActionResult Edit(EditVM ticket)
        {
            _ticketsManager.Edit(ticket);
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Delete

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var ticketToDelete = _ticketsManager.Get(id);

            var ticketVM = new DeleteVM
            {
                Id = ticketToDelete.Id,
                Title = ticketToDelete.Title,
                Description = ticketToDelete.Description,
                Severity = ticketToDelete.Severity,
            };
            return View(ticketVM);
        }

        [HttpPost]
        public IActionResult Delete(DeleteVM ticket)
        {
            _ticketsManager.Remove(ticket.Id);
            return RedirectToAction(nameof(Index));
        }


        #endregion
    }
}
