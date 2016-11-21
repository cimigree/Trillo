using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trello.Models;

namespace Trello.Controllers
{
    public class HomeController : Controller
    {
        // This establishes a connection to the Database.
        private TrelloDbContext db = new TrelloDbContext();

        // This action creates our home view, which will display all of the taskcards.
        public ActionResult Index()
        {
            return View(db.Trillos.OrderBy(c => c.SortOrder).ToList());
        }

        //This action (function/method) will be called to create a new card.
        public ActionResult CreateTask()
        {
            return View();
        }

        // Displaying users task individually (when clicked on and after new one is created or edited)
        public ActionResult ViewTask(int ID)
        {
            Trillo myTrello = db.Trillos.Find(ID);
            ViewBag.Message = "Your contact page.";
            return View(myTrello);

        }

        // Finding a task by ID and bringing it up to edit

        public ActionResult EditTask(int ID)
        {
            Trillo myTrello = db.Trillos.Find(ID);
            return View(myTrello);

        }

        //Save a task after it has been edited and updated and then display the new task.

        public ActionResult UpdateTask(int ID, string TaskName, string Notes, DateTime DueDate)
        {
            Trillo myTrello = db.Trillos.Find(ID);
            myTrello.TaskName = TaskName;
            myTrello.Notes = Notes;
            myTrello.DueDate = DueDate;
            db.SaveChanges();
            return RedirectToAction("Index", new { ID = myTrello.ID });

        }

        // Displaying all of the Trello cards
        public ActionResult DisplayTasks()
        {
            return View(db.Trillos.OrderBy(c=> c.SortOrder).ToList());
        }

        //Finding correct task by ID, removing it, displaying the homepage with all of the tasks

        public ActionResult Delete(int ID)
        {
            Trillo myTrello = db.Trillos.Find(ID);
            db.Trillos.Remove(myTrello);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        //This happens when save is clicked. Takes in the CreateTask and saves it to the database and then displays the task.
        public ActionResult SaveTask(string TaskName, string Notes, DateTime DueDate)
        {
            Trillo myTrello = new Trillo();
            myTrello.TaskName = TaskName;
            myTrello.Notes = Notes;
            myTrello.DueDate = DueDate;
            myTrello.SortOrder = 1000;
            db.Trillos.Add(myTrello);
            db.SaveChanges();
            return RedirectToAction("Index");

        
        }
    

        public string UpdateOrder(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Trillo myTrello = db.Trillos.Find(array[i]);
                       myTrello.SortOrder = i;
            }
            db.SaveChanges();
            return "Order is now updated!";

        }
        








    }
}