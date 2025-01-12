using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class NewsMessage
    {
        public int? Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Titel is vereist.")]
        public string Title { get; set; }
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "Bericht mag niet leeg zijn.")]
        public string Message { get; set; }
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "Bericht mag niet leeg zijn.")]
		public DateTime Date { get; set; }

    }
}
