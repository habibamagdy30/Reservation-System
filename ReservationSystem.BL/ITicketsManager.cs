using ReservationSystem.BL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.BL
{
    public interface ITicketsManager
    {
        List<TicketReadVM> GetAll();
        TicketReadVM? Get(int id);
        void Add(AddVM ticket);

      //  void Remove(AddVM ticket);

        void Remove(int id);

        void Edit(EditVM ticket);
        EditVM GetTickForEdit(int id);
    }
}
