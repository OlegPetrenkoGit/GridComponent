using System;
using System.Collections.Generic;
using System.Web.Mvc;
using GridComponent.DataAccess;
using GridComponent.Models;

namespace GridComponent.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            var clients = new List<Client>
            {
                new Client()
                {
                    BirthDate = new DateTime(1992, 7, 23),
                    Login = "Anthony",
                    Password = "Hidden",
                    RegistrationDate = new DateTime(2010, 11, 12)
                },

                new Client()
                {
                    BirthDate = new DateTime(1997, 2, 11),
                    Login = "Joseph",
                    Password = "Secret",
                    RegistrationDate = new DateTime(2012, 4, 6)
                },
            };

            return View(clients);
        }

        public HttpStatusCodeResult Save()
        {
            try
            {
                using (var context = new EntitiesContext<Client>()) //<T>
                {
                    var client = new Client
                    {
                        BirthDate = new DateTime(1997, 2, 11),
                        Login = "TEST",
                        Password = "TEST",
                        RegistrationDate = new DateTime(2012, 4, 6)
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
    }
}