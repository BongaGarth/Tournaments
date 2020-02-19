using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Data.Entities
{
    public class Tournament
    {
        public int TournamentID { get; set; }
        public string TournamentName { get; set; }
        public ICollection<Event> Events { get; set; }
    }
}
