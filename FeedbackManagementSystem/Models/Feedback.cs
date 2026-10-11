using System;
using System.ComponentModel.DataAnnotations;

namespace FeedbackManagementSystem.Models
{
    public class Feedback
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter your name.")]
        [StringLength(50, MinimumLength = 2,
            ErrorMessage = "Name must contain 2 to 50 characters.")]
        [Display(Name = "Full Name")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter your email.")]
        [EmailAddress(ErrorMessage = "Enter a valid email address.")]
        [Display(Name = "Email Address")]
        public string Email { get; set; } = string.Empty;

        [Range(1, 5,
            ErrorMessage = "Please select a rating from 1 to 5.")]
        [Display(Name = "Rating")]
        public int Rating { get; set; }

        [Required(ErrorMessage = "Please enter your feedback.")]
        [StringLength(500, MinimumLength = 10,
            ErrorMessage = "Feedback must contain 10 to 500 characters.")]
        [Display(Name = "Comments")]
        public string Comments { get; set; } = string.Empty;

        public DateTime DateSubmitted { get; set; } = DateTime.Now;
    }
}