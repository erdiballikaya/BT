using BTProject.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTProject.Actions.AddMovie
{
    public interface IMovieService
    {
        Task<ContentResult> Add(Movie _mov);
        string GetMovie(int imdbID);
        ContentResult Delete(string imdbID, int userID);
    }
}
