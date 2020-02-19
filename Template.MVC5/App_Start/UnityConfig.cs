using System.Web.Mvc;
using Template.BusinessLogic;
using Template.BusinessLogic.EventBusiness;
using Template.BusinessLogic.Tournament;
using Unity;
using Unity.Mvc5;

namespace Template.MVC5
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers
            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IRegisterBusiness, RegisterBusiness>();
            container.RegisterType<ILoginBusiness, LoginBusiness>();
            container.RegisterType<ITournamentBusiness, TournamentBusiness>();
            container.RegisterType<IRolesBusiness, RoleBusiness>();
            container.RegisterType<IEventService, EventService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}