using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Model.ViewModels
{
    public class TournamentViewModel
    {
        public int TournamentID { get; set; }
        public string TournamentName { get; set; }
        public List<EventViewModel> Events { get; set; }
    }
}
