using Autofac;
using Microsoft.AspNetCore.Mvc;
using ServiceContract;
using Services;

namespace Ddependancy.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICitiesService _citiesService1;
        private readonly ICitiesService _citiesService2;
        private readonly ICitiesService _citiesService3;
        private readonly ILifetimeScope _lifetimeScope;

        public HomeController(ICitiesService citiesService1, ICitiesService citiesService2, ICitiesService citiesService3, ILifetimeScope lifetimeScope)
        {
            _citiesService1 = citiesService1;
            _citiesService2 = citiesService2;
            _citiesService3 = citiesService3;//new CitiesService();
            _lifetimeScope = lifetimeScope;

        }

        [Route("/")]
        public IActionResult Index()
        { 
            List<string> cities = _citiesService1.GetCities();
            ViewBag.InstancedId_CitiesService_1=_citiesService1.Id;
            ViewBag.InstancedId_CitiesService_2 = _citiesService2.Id;
            ViewBag.InstancedId_CitiesService_3 = _citiesService3.Id;

            using (ILifetimeScope scope = _lifetimeScope.BeginLifetimeScope())
            {
                ICitiesService citiesService=scope.Resolve<ICitiesService>();


                ViewBag.InstancedId_CitiesService_InScope=citiesService.Id;
            }
            return View(cities);
        }
    }
}
