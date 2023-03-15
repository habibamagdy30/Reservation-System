using ReservationSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.BL.ViewModels;
//public record DeveloperAddVM(string Name);

public class AddVM
{
   
    public string? Title { get; set; }
    public string? Description { get; set; }
    public Severity Severity { get; set; }
    
};
