using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Votr.DAL;
using Votr.Models;

namespace Votr.Controllers
{
    public class PollController : Controller
    {
        private VotrRepository Repo = new VotrRepository();
        // GET: Poll
        public ActionResult Index()
        {
            //ViewBag.Polls = Repo.GetPolls();
            return View(Repo.GetPolls());
        }

        // GET: Poll/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Poll/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Poll/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                string Title = collection.Get("Title");
<<<<<<< HEAD
                DateTime StartDate = DateTime.Parse(collection.Get("StartDate"));
                DateTime EndDate = DateTime.Parse(collection.Get("EndDate"));

                string[] keys = collection.AllKeys;
                List<string> options = new List<string>();

                foreach (var key in keys)
                {
                    if(key.Contains("option-"))
                    {
                        options.Add(collection.Get(key));
                    }
                }

                //User
                string user_id = User.Identity.GetUserId();
                ApplicationUserManager manager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
                ApplicationUser user = manager.FindById(user_id);
                Repo.AddPoll(Title, StartDate, EndDate, user, options);
=======
                string StartDate = collection.Get("StartDate");
                string EndDate = collection.Get("EndDate");
                string Option1 = collection.Get("option-1");
>>>>>>> a813e6c2d88c3b5b1209cc349493afe36c032139

                int test = 1;
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Poll/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            Poll found_poll = Repo.GetPollOrNull(id);
            if (found_poll == null)
            {
                return RedirectToAction("Index");
            }
            return View(found_poll);
        }

        // POST: Poll/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include ="PollId,Title,StartDate,EndDate")]Poll poll_to_edit)
        {
            if (ModelState.IsValid)
            {
                Repo.EditPoll(poll_to_edit);
            }
            return RedirectToAction("Index");
        }

        // GET: Poll/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            Poll found_poll = Repo.GetPollOrNull(id);
            if (found_poll != null)
            {
                Repo.RemovePoll(id);
            }
            return RedirectToAction("Index");
        }

        // POST: Poll/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
