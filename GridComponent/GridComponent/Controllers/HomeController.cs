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

        public ViewResult Apartments()
        {
            var entities = _entitiesService.GetAllEntities<Apartment>();
            return View(entities);
        }

        [HttpPost]
        public RedirectToRouteResult Create(Client obj)
        {
            var result = _entitiesService.SaveEntity(obj);
            return RedirectToAction("Index");
        }

        //[HttpPost]
        //public ActionResult Update(object obj, Type t)
        //{
        //    try
        //    {
        //        using (var context = new EntitiesContext<Client>())
        //        {
        //            var client = new Client
        //            {
        //                //    BirthDate = new DateTime(1997, 2, 11),
        //                Name = "TEST",
        //                Surname = "TEST",
        //                //   RegistrationDate = new DateTime(2012, 4, 6)
        //            };

        //            context.Entities.Add(client);
        //            context.SaveChanges();
        //        }

        //        using (var context = new EntitiesContext<Apartment>()) //<T>
        //        {
        //            var apartment = new Apartment
        //            {
        //                City = "Odessa",
        //                ConstructDate = new DateTime(1947, 11, 3)
        //            };

        //            context.Entities.Add(apartment);
        //            context.SaveChanges();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        var message = ex.Message;
        //    }

        //    return new HttpStatusCodeResult(200);
        //}

        //[HttpPost]
        //public ActionResult Delete(object obj, Type t)
        //{
        //    try
        //    {
        //        using (var context = new EntitiesContext<Client>())
        //        {
        //            context.Entities.Remove(new Client());
        //            context.SaveChanges();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        var message = ex.Message;
        //    }

        //    return RedirectToAction("Index");
        //}

        public JsonResult GetFormatSpecification(string type)
        {
            var typeFormatSpecification = FormatSpecificationFactory.Create(type);
            return Json(typeFormatSpecification, JsonRequestBehavior.AllowGet);
        }
    }
}