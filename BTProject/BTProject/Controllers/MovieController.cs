using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BTProject.Actions.AddMovie;
using BTProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace BTProject.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MovieController : Controller
    {
        private readonly IMovieService Movie;

        public MovieController(IMovieService loginService)
        {
            this.Movie = loginService;
        }

        [HttpPost]
        public async Task<IActionResult> Add(Movie _mov)
        {
            return Ok(Movie.Add(_mov));
        }
        [HttpGet]
        public IActionResult GetMovie(int userid)
        {
            return Ok(Movie.GetMovie(userid));
        }

        [HttpGet]
        public IActionResult Delete(string imdbID, int userID)
        {
            return Ok(Movie.Delete(imdbID, userID));
        }
    }
}
