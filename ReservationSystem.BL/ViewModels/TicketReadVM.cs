using ReservationSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.BL.ViewModels;

public record TicketReadVM(int Id, string Title,string Description,Severity Severity)
{
    public string titleMarkup => $"<h4> {Title} </h4?";

    public string descriptionMarkup => $"<h4> {Description} </h4?";

    public string severityMarkup => $"<h4> {Severity} </h4?";


};
