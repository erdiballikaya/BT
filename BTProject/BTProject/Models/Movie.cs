using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BTProject.Models
{
    public class Movie
    {
        [Key]
        public int id { get; set; }
        public int userID { get; set; }
        public string imdbID { get; set; }
        public string Title { get; set; }
        public string Year { get; set; }


    }
}
