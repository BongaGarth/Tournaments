using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Model.ViewModels;

namespace Template.BusinessLogic.Tournament
{
    public interface ITournamentBusiness
    {
        void AddTournament(TournamentModel model);
        List<TournamentViewModel> GetAllTournaments();
        void Delete(int Id);
        TournamentViewModel GetById(int Id);
    }
}
