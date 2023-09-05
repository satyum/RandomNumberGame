using Microsoft.AspNetCore.Mvc;
using System;
using RandomNumberGame.Models;
namespace RandomNumberGame.Controllers
{
    public class HomeController : Controller
    {
        private readonly int _minNumber = 1;
        private readonly int _maxNumber = 100;
        private readonly Random _random = new Random();
        private int _targetNumber;

        public IActionResult Index()
        {
            // Generate a random target number between _minNumber and _maxNumber
            _targetNumber = _random.Next(_minNumber, _maxNumber + 1);

            // Initialize the view model with the initial game state
            var viewModel = new RandomNumberViewModel
            {
                MinNumber = _minNumber,
                MaxNumber = _maxNumber,
                Guess = 0,
                Message = "Guess a number between 1 and 100."
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult CheckGuess(RandomNumberViewModel viewModel)
        {
            if (viewModel.Guess == _targetNumber)
            {
                viewModel.Message = "Congratulations! You guessed the correct number.";
            }
            else if (viewModel.Guess < _targetNumber)
            {
                viewModel.Message = "Try a higher number.";
            }
            else
            {
                viewModel.Message = "Try a lower number.";
            }

            return View("Index", viewModel);
        }
    }
}

