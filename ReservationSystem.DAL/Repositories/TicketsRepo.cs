using ReservationSystem.DAL.Context;
using ReservationSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ReservationSystem.DAL.Repositories;

public class TicketsRepo : ITicketsRepo
{
    private readonly ReservationContext _context;

    public TicketsRepo(ReservationContext context)
    {
        _context = context;
    }
    public void Add(Ticket ticket)
    {
        _context.Set<Ticket>().Add(ticket);
    }

    public void Delete(int id)
    {
        var ticketToDelete = Get(id);
        if (ticketToDelete != null)
        {
            _context.Set<Ticket>().Remove(ticketToDelete);
        }
    }

    public Ticket? Get(int id)
    {
        return _context.Set<Ticket>().Find(id);
    }

    public IEnumerable<Ticket> GetAll()
    {
        return _context.Set<Ticket>();
    }

    public void Update(Ticket ticket)
    {
       
    }
    public int SaveChanges()
    {
        return _context.SaveChanges();
    }

}
