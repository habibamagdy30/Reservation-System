using ReservationSystem.BL.ViewModels;
using ReservationSystem.DAL.Models;
using ReservationSystem.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.BL
{
    public class TicketsManager : ITicketsManager
    {
        private readonly ITicketsRepo _ticketsRepo;

        public TicketsManager(ITicketsRepo ticketsRepo)
        {
            _ticketsRepo = ticketsRepo;
        }
        public void Add(AddVM ticketVM)
        {
            var ticket = new Ticket
            { //Id = ticketVM.Id,
                Title = ticketVM.Title,
                Description= ticketVM.Description,
                Severity= ticketVM.Severity,
            };

            _ticketsRepo.Add(ticket);
            _ticketsRepo.SaveChanges();
        }

        public void Edit(EditVM ticketVM)
        {
            var ticketToEdit = _ticketsRepo.Get(ticketVM.Id);

            ticketToEdit.Title = ticketVM.Title;
            ticketToEdit.Description = ticketVM.Description;
            ticketToEdit.Severity = ticketVM.Severity;

           // _ticketsRepo.Update(ticket);
            _ticketsRepo.SaveChanges();
        }

        public TicketReadVM? Get(int id)
        {
            var ticketFromDB = _ticketsRepo.Get(id);
            if (ticketFromDB == null)
            {
                return null;
            }
            return new TicketReadVM(ticketFromDB.Id, ticketFromDB.Title,ticketFromDB.Description,ticketFromDB.Severity);
        }

        public List<TicketReadVM> GetAll()
        {
            var ticketsFromDB = _ticketsRepo.GetAll();
            return ticketsFromDB.Select(d => new TicketReadVM(d.Id, d.Title,d.Description,d.Severity))
                .ToList();
        }

        public void Remove(int id)
        {
            var ticketToDelete = _ticketsRepo.Get(id);
            _ticketsRepo.Delete(ticketToDelete.Id);
            _ticketsRepo.SaveChanges();

        }

        public EditVM GetTickForEdit(int id)
        {
            var ticketToEdit = _ticketsRepo.Get(id);
            return =  new EditVM
            {
                Id = ticketToEdit.Id,
                Title= ticketToEdit.Title,
                Description = ticketToEdit.Description,
                Severity = ticketToEdit.Severity,
            };
        }
    }
}
