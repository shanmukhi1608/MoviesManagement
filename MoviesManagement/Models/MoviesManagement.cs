using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MoviesManagement.Models
{
    public class MoviesManagement
    {
        [Required]
        [Key]
        [Display(Name = "MovieId")]
        public int movie_id { get; set; }

        [Display(Name = "Title")]
        [Required(ErrorMessage = "*")]
        public string movie_title { get; set; }

        [Display(Name = "Year")]
        [Required(ErrorMessage = "*")]
        [RegularExpression(@"^(\d{4})$",ErrorMessage = "Invalid year format")]
        public int movie_year { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Language")]
        public string movie_language { get; set; }

        [Display(Name = "Date of Release")]
        [Required(ErrorMessage = "*")]
        [RegularExpression(@"(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$", ErrorMessage = "Invalid date format.")]
        public string movie_date_release { get; set; }

        [Display(Name = "Movie Origin Country")]
        [Required(ErrorMessage = "*")]
        public string movie_ori_country { get; set; }
    }
}
