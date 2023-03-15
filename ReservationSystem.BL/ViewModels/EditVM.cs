using ReservationSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.BL.ViewModels;

public class EditVM
{        
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public Severity Severity { get; set; }

    
}
