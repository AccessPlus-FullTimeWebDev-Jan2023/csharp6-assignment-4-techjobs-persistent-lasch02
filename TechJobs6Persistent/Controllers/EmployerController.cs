using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechJobs6Persistent.Data;
using TechJobs6Persistent.Models;
using TechJobs6Persistent.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobs6Persistent.Controllers
{
    public class EmployerController : Controller
    { 
        //giving our employer controller access to the database thru the db context
    private JobDbContext context;

        public EmployerController(JobDbContext dbContext)
        {
            context = dbContext;
        }

        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            List<Employer> employers = context.Employers.ToList();
            return View(employers);
        }

        [HttpGet]
        public IActionResult Create()
        {
            //sets up Employer view model to determine and validate datat coming into the form
            AddEmployerViewModel addEmployerViewModel = new AddEmployerViewModel(); //Linda

            return View(addEmployerViewModel);
        }

        [HttpPost]
        public IActionResult ProcessCreateEmployerForm(AddEmployerViewModel addEmployerViewModel)
        {
            if (ModelState.IsValid)
            {
                //Employer the Employer = context.Employers.Find(addEmpoyerViewModel.EmployerId);
                Employer theEmployer = new Employer
                {
                    Name = addEmployerViewModel.Name,
                    Location = addEmployerViewModel.Location
                    //Employer = theEmployer
                };

                context.Employers.Add(theEmployer);
                context.SaveChanges();

                return Redirect("/Employer");
            }
            return View("Create", addEmployerViewModel);
        }

        public IActionResult About(int id)
        {
            //finding employer id and passing into the view
            Employer theEmployer = context.Employers.Find(id);
            //List<Employer> possibleEmployers = context.Employers.ToList();

            return View(theEmployer);
        }

    }
}

