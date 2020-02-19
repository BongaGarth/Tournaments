using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Model.CoreHelpers;

namespace Template.Model.Models
{
    public class EventModel
    {
        public int TournamentID { get; set; }
        public string EventName { get; set; }
        public Int16 EventNumber { get; set; }
        public DateTime EvenStarTime { get; set; }
        public DateTime EventEndTime { get; set; }
        public bool AutoClose { get; set; }

    }
}
