using System;
using System.Web.Mvc;

namespace GridComponent.Controllers
{
    public interface IHomeController
    {
        // ActionResult Create(object obj, Type t);
        ActionResult Update(object obj, Type t);
        ActionResult Delete(object obj, Type t);
    }
}