using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Humanizer.Localisation;
using Microsoft.Extensions.Localization;
using WebApplication1.Controllers;

namespace WebApplication1.Models
{
    public class NewsMessage
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "TitleRequired")]
        [Display(Name ="Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "MessageRequired")]
        [Display(Name = "Message")]
        public string Message { get; set; }

        [Required(ErrorMessage = "DateRequired")]
        [Display(Name = "Date")]
        public DateTime Date { get; set; }

    }
}
