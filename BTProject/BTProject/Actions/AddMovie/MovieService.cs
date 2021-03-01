using BTProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;

namespace BTProject.Actions.AddMovie
{
    public class MovieService : IMovieService
    {
        private readonly DataContext con;

        public MovieService(DataContext context)
        {
            con = context;
        }

        public async Task<ContentResult> Add(Movie _mov)
        {
            Movie mov = new Movie();
            mov.imdbID = _mov.imdbID;
            mov.userID = _mov.userID;
            mov.Title = _mov.Title;
            mov.Year = _mov.Year;

            var add = await con.Movie.AddAsync(mov);
            var res = con.SaveChanges();
            if (res == 1)
            {
                var result = new ContentResult
                {
                    Content = "Succsess",
                    StatusCode = 2
                };

                return result;
            }
            else
            {
                var result = new ContentResult
                {
                    Content = "Error",
                    StatusCode = 1
                };

                return result;
            }
        }

        public string GetMovie(int userid)
        {
            var movies = con.Movie.Where(x => x.userID.Equals(userid)).ToList();
           
            if(movies != null)
            {
                return JsonSerializer.Serialize(movies);           
            }
            else
            {
                return "Hata";
            }


        }

        public ContentResult Delete(string imdbID, int userID)
        {
            var data = con.Movie.SingleOrDefault(x => x.imdbID.Equals(imdbID) & x.userID.Equals(userID));
            var delete = con.Movie.Remove(data);
            var save = con.SaveChanges();
            var res = new ContentResult
            {
                StatusCode = 2
            };
            return res;
        }
    }
}
