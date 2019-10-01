﻿using DinnerPlans.Models;
using System;
using System.Collections.Generic;

namespace DinnerPlans.Services.LibraryUpdaters
{
    internal class IngredientLibraryUpdater : ILibraryUpdater<Ingredient>
    {
        private string _repositoryPath;

        public IngredientLibraryUpdater(string recipeRepoPath)
        {
            _repositoryPath = recipeRepoPath;
        }

        private List<Ingredient> _updatedIngredients;
        public void UpdateLibrary(List<Ingredient> repo)
        {
            _updatedIngredients = repo;
            UpdateIngredients();
        }

        private void UpdateIngredients()
        {
            throw new NotImplementedException();
        }
    }
}