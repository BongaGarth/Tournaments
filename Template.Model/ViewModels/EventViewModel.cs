using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Model.ViewModels
{
    public class EventViewModel
    {
        public int EventID { get; set; }
        public int TournamentID { get; set; }
        public string EventName { get; set; }
        public Int16 EventNumber { get; set; }
        public DateTime EvenStarTime { get; set; }
        public DateTime EventEndTime { get; set; }
        public bool AutoClose { get; set; }

        public List<EventDetailsViewModel> Details { get; set; }
    }
}
