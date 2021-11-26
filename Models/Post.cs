﻿using Microsoft.AspNetCore.Identity;

namespace Shortcutt.Models
{
    public class Post
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public bool IsActive { get; set; } = false;
        public string UserId { get; set; }
        public IdentityUser User { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; }
    }
}
