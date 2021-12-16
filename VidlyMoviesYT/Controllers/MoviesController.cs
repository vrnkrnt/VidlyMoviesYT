using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyMoviesYT.Models;
using VidlyMoviesYT.ViewModels;


namespace VidlyMoviesYT.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random

        //Här vill vi ha ActionResult då den har många fler funktioner. 
        public ActionResult Random() 
        {
            var movie = new Movie() { Name = "Shrek" };
            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1"},
                new Customer { Name = "Customer 2"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);

            //return Content("Hello World!");
            //return HttpNotFound(); 
            //return new EmptyResult(); //Om man inte vill returnera någonting
        }

        public ActionResult Edit(int id)
        {
            return Content("id: " + id);
            //Exempel på länk som fungerar med kod: https://localhost:44394/Movies/Edit/1
        }

        //public ActionResult Edit(int movieId)
        //{
        //    return Content("id: " + movieId);
        ////Exempel på länk som fungerar med kod: https://localhost:44394/Movies/Edit/MovieId=1
        //}


        //? = att man kan ha nullvärnden

        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;

            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";

            return Content(String.Format("Pageindex: {0}&sortBy={1}", pageIndex, sortBy));
            //https://localhost:44394/Movies - Här kommer metoden visa index 1 och sort by name
            //https://localhost:44394/Movies?pageIndex=2&sortBy=ReleaseDate - Här har vi ändrat index och sortering
        }


        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

    }
}