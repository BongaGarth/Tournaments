using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Data.Entities
{
    public class Event 
    {
        public int EventID { get; set; }
        public int TournamentID { get; set; }
        public string EventName { get; set; }
        public Int16 EventNumber { get; set; }
        public DateTime EvenStarTime { get; set; }
        public DateTime EventEndTime { get; set; }
        public bool AutoClose { get; set; }
        public Tournament Tournament { get; set; }
        public ICollection<EventDetail> EventDetails { get; set; }
    }
}
