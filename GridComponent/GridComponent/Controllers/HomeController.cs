using System.Web.Mvc;
using GridComponent.Models;
using GridComponent.Models.FormatSpecification;
using GridComponent.Services;

namespace GridComponent.Controllers
{
    public class HomeController : Controller
    {
        private readonly EntitiesService _entitiesService = new EntitiesService();

        public ViewResult Index()
        {
            var entities = _entitiesService.GetAllEntities<Client>();
            return View(entities);
        }

        [HttpPost]
        public RedirectToRouteResult Create(Client obj)
        {
            _entitiesService.SaveEntity(obj);
            return RedirectToAction("Index");
        }

        public JsonResult GetFormatSpecification(string type)
        {
            var typeFormatSpecification = FormatSpecificationFactory.Create(type);
            return Json(typeFormatSpecification, JsonRequestBehavior.AllowGet);
        }
    }
}