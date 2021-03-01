using BTProject.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BTProject.Actions.GetMovies
{
    public interface IMovieService
    {
        Task<HttpResponseMessage> GetMovies(Movie model);
    }
}
