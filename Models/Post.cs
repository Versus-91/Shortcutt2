using Microsoft.AspNetCore.Identity;

namespace Shortcutt.Models
{
    public class Post
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public int MyProperty { get; set; }
        public string UserId { get; set; }
        public IdentityUser User { get; set; }
    }
}
