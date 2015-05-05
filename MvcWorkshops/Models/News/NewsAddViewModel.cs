using System.ComponentModel.DataAnnotations;

namespace MvcWorkshops.Models.News
{
    public class NewsAddViewModel
    {
        [Required]
        public string Message { get; set; }

        public string UserIp { get; set; }
    }
}