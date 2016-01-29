using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using GridComponent.Models;
using GridComponent.Models.DataAccess;
using GridComponent.Models.FormatSpecification;
using Newtonsoft.Json;

namespace GridComponent.Controllers
{
    public class HomeController : Controller, IHomeController
    {
        private readonly List<Client> clients = new List<Client>
            {
               new Client()
                {
                   BirthDate = new DateTime(1997, 2, 11),
                    Name = "Joseph",
                    Surname = "Secret",
                    RegistrationDate = new DateTime(2012, 4, 6)
                },
            };


        public ViewResult Index()
        {
            return View(clients);
        }

        [HttpPost]
        public HttpStatusCodeResult Create()
        {
            try
            {
                var json = JsonConvert.DeserializeObject(Request.Form["String"]);
                var data = Request.Form["String"];
                
            }
            catch (Exception ex)
            {
                var error = ex.Message;
            }

            return new HttpStatusCodeResult(HttpStatusCode.OK);

            //   return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        [HttpPost]
        public ActionResult Update(object obj, Type t)
        {
            try
            {
                using (var context = new EntitiesContext<Client>())
                {
                    var client = new Client
                    {
                        //    BirthDate = new DateTime(1997, 2, 11),
                        Name = "TEST",
                        Surname = "TEST",
                        //   RegistrationDate = new DateTime(2012, 4, 6)
                    };

                    context.Entities.Add(client);
                    context.SaveChanges();
                }

                using (var context = new EntitiesContext<Apartment>()) //<T>
                {
                    var apartment = new Apartment
                    {
                        City = "Odessa",
                        ConstructDate = new DateTime(1947, 11, 3)
                    };

                    context.Entities.Add(apartment);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                var message = ex.Message;
            }

            return new HttpStatusCodeResult(200);
        }

        [HttpPost]
        public ActionResult Delete(object obj, Type t)
        {
            try
            {
                using (var context = new EntitiesContext<Client>())
                {
                    context.Entities.Remove(new Client());
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                var message = ex.Message;
            }

            return RedirectToAction("Index");
        }

        public JsonResult GetFormatSpecification(string type)
        {
            var typeFormatSpecification = FormatSpecificationFactory.Create(type);
            return Json(typeFormatSpecification, JsonRequestBehavior.AllowGet);
        }
    }
}