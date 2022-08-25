using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriFy.Car.Downloader.Dtos
{
    public class RepuveFileInput
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        public string HtmlContent { get; set; }

        [Required]
        public string Filename { get; set; }
    }
}
