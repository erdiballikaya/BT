using BTProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BTProject.Actions.GetMovies
{
    public class MovieService : IMovieService
    {
        private readonly DataContext con;

        public MovieService(DataContext context)
        {
            con = context;
        }

        public async Task<HttpResponseMessage> GetMovies(Movie mov)
        {
            return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
        }

    }
}
