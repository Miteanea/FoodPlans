﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinnerPlans.Models
{
    internal class Recipe
    {
        public Recipe()
        {
            ID = GetID();
        }

        private RecipeID GetID()
        {
            return new RecipeID();
        }

        public RecipeID ID { get; set; }
        public string Title { get; set; }
        public Origin Origin { get; set; }
    }

    internal enum Origin
    {
        Italian,
        Thai,
        Russian
    }
}