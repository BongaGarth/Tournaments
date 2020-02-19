using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Model.ViewModels
{
    public class EventDetailsViewModel
    {
        public int EventDetailID { get; set; }
        public int EventID { get; set; }
        public string EventDetailsName { get; set; }
        public int EventDetailNumber { get; set; }
        public decimal EventOdd { get; set; }
        public int FinishingPosition { get; set; }
        public bool FirstTimer { get; set; }
    }
}
