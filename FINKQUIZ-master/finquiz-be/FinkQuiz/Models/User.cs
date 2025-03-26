using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace FinkQuiz.Models
{
    public abstract class User : IdentityUser
    {
        // Note: IdentityUser already has Id, UserName, Email, PasswordHash
        // So we only need to add additional properties
        
        [StringLength(50)]
        public string FirstName { get; set; }
        
        [StringLength(50)]
        public string LastName { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
} 