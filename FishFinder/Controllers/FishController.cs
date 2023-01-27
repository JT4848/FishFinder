﻿using FishFinder.Models;
using Microsoft.AspNetCore.Mvc;

namespace FishFinder.Controllers
{
    public class FishController : Controller
    {
        private readonly IFishRepository repo;

        public FishController(IFishRepository repo)
        {
            this.repo = repo;
        }


        public IActionResult Index()
        {
            var fish = repo.GetAllFish();
            return View(fish);
        }

        public IActionResult ViewFish(int id)
        {
            var fish = repo.GetFish(id);
            return View(fish);
        }

        public IActionResult UpdateFish(int id)
        {
            Fish fish = repo.GetFish(id);
            if (fish == null)
            {
                return View("FishNotFound");
            }
            return View(fish);
        }

        public IActionResult UpdateFishToDatabase(Fish fish)
        {
            repo.UpdateFish(fish);

            return RedirectToAction("ViewFish", new { id = fish.FishId });
        }

        public IActionResult InsertFish()
        {
            var fish = repo.AssignFish();
            return View(fish);
        }

        public IActionResult InsertFishToDatabase(Fish fishToInsert)
        {
            repo.InsertFish(fishToInsert);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteFish(Fish fish)
        {
            repo.DeleteFish(fish);
            return RedirectToAction("Index");
        }


    }
}
