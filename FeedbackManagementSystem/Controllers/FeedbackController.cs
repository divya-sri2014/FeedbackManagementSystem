using System.Collections.Generic;
using System.Linq;
using FeedbackManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace FeedbackManagementSystem.Controllers
{
    public class FeedbackController : Controller
    {
        private static readonly List<Feedback> FeedbackList = new();
        private static int _nextId = 1;

        // Display all feedback records
        public IActionResult Index()
        {
            var feedbacks = FeedbackList
                .OrderByDescending(f => f.DateSubmitted)
                .ToList();

            return View(feedbacks);
        }

        // Display the feedback form
        [HttpGet]
        public IActionResult Create()
        {
            return View(new Feedback());
        }

        // Process submitted feedback
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Feedback feedback)
        {
            if (!ModelState.IsValid)
            {
                return View(feedback);
            }

            feedback.Id = _nextId++;
            feedback.DateSubmitted = System.DateTime.Now;

            FeedbackList.Add(feedback);

            TempData["SuccessMessage"] =
                "Feedback submitted successfully.";

            return RedirectToAction(nameof(Index));
        }

        // Delete a feedback record
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var feedback = FeedbackList
                .FirstOrDefault(f => f.Id == id);

            if (feedback != null)
            {
                FeedbackList.Remove(feedback);

                TempData["SuccessMessage"] =
                    "Feedback deleted successfully.";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}