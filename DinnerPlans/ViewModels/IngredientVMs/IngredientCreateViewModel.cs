﻿using DinnerPlans.Models;
using DinnerPlans.Services.DataService;
using DinnerPlans.ViewModels.Commands;
using System.Windows.Input;
using System.Threading.Tasks;

namespace DinnerPlans.ViewModels.IngredientVMs
{
    internal class IngredientCreateViewModel : ViewModelBase
    {
        public IngredientCreateViewModel(IDataService data, Ingredient ingredient = null)
        {
            if (ingredient == null)
            {
                Ingredient = new Ingredient();
            }
            else
            {
                Ingredient = ingredient;
            }

            _data = data;
        }

        private IDataService _data;

        public event OnDoneEditingEventHandler DoneEditing;

        public delegate void OnDoneEditingEventHandler();

        public Ingredient Ingredient { get; set; }

        public ICommand SaveIngredientCommand
        {
            get
            {
                return new RelayCommand(SaveIngredient);
            }
        }

        private void SaveIngredient(object obj)
        {
            SaveIngredientAsync();
        }

        private async Task SaveIngredientAsync()
        {
            await _data.SaveIngredientAsync(Ingredient);
            Ingredient = new Ingredient();
            DoneEditing.Invoke();
        }
    }
}