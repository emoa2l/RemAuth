using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SharpArch.NHibernate.Contracts.Repositories;
using RemAuth.Domain;
using SharpArch.NHibernate.Web.Mvc;
using SharpArch.Domain;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization;

namespace RemAuth.Web.Mvc.Controllers
{    
    public class AuthenticatorsController : Controller
    {

       private INHibernateRepository<Authenticator> authenticatorRepository;

       /// <summary>
       /// 
       /// </summary>
       /// <param name="authenticatorRepository"></param>
       public AuthenticatorsController(INHibernateRepository<Authenticator> authenticatorRepository)
       {
          this.authenticatorRepository = authenticatorRepository;
       }

       /// <summary>
       /// 
       /// </summary>
       /// <returns></returns>
       public ActionResult Index()
       {
          var authenticators = authenticatorRepository.GetAll();
          return View(authenticators);
       }

       [HttpGet]
       [Authorize]
       public ActionResult Create()
       {
          return View();
       }

       [Transaction]
       //[ValidateAntiForgeryToken]
       [Authorize]
       [HttpPost]
       public ActionResult Create(Authenticator authenticator)
       {
          if (ModelState.IsValid && authenticator.IsValid())
          {
             this.authenticatorRepository.SaveOrUpdate(authenticator);
             return this.RedirectToAction("Index");
          }

          return View(authenticator);
       }

       /// <summary>
       /// 
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
       [HttpGet]
       [Authorize]
       public ActionResult Update(int? id)
       {
          if (!id.HasValue)
          {
             // MvcContrib strongly typed redirect
             return this.RedirectToAction("Index");
          }

          var authenticator = this.authenticatorRepository.Get(id.Value);
          return View(authenticator);
       }

       /// <summary>
       /// 
       /// </summary>
       /// <param name="authenticator"></param>
       /// <returns></returns>
       [Transaction]
       [ValidateAntiForgeryToken]
       [HttpPost]
       [Authorize]
       public ActionResult Update(Authenticator authenticator)
       {
          if (ModelState.IsValid && authenticator.IsValid())
          {
             this.authenticatorRepository.SaveOrUpdate(authenticator);
             return this.RedirectToAction("Index");
          }

          return View(authenticator);
       }
       
       public JsonResult Service_List()           
       {
          var authenticators = authenticatorRepository.GetAll();    
          return Json(authenticators, JsonRequestBehavior.AllowGet);
       }
    }
}
