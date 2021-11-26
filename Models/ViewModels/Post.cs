using Microsoft.AspNetCore.Identity;
using Shortcutt.Models;
using System.ComponentModel.DataAnnotations;

namespace Shortcutt.ViewModels
{
    public class CreatePost
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Location { get; set; }
        public IFormFile? Image { get; set; }
        public Post MapToPost()
        {
            return new Post { Title = Title, Description = Description, Location = Location };
        }
    }
}
