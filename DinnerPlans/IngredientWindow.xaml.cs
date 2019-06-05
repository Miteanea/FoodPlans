﻿using DinnerPlans.Models;
using DinnerPlans.Services;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DinnerPlans
{
    /// <summary>
    /// Interaction logic for IngredientWindow.xaml
    /// </summary>
    public partial class IngredientWindow : Window
    {
        public IngredientWindow()
        {
            InitializeComponent();

            _ingredients = DataHandler.IngredientsRepository.Ingredients;

            UnitSelector.ItemsSource = Enum.GetValues( typeof( UnitType ) ).Cast<UnitType>();

            // ExistingIngridients.Items.Clear();
            ExistingIngridients.ItemsSource = _ingredients;
        }

        public Ingredient Ingredient { get; set; }
        private ObservableCollection<Ingredient> _ingredients { get; set; }

        private void Add_Ingredient_Clicked( object sender , RoutedEventArgs e )
        {
            //"Add & Save" Button" => 1) Saves the ingredient to ingredient collection
            //                            2)closes the window and sends the ingredient to caller.
            if(ExistingIngridients.SelectedItem != null)
            {
                Ingredient = ExistingIngridients.SelectedItem as Ingredient;
            }
            else
            {
                Ingredient = MapUserInputToIngredient();
            }

            this.DialogResult = true;
            this.Close();
        }

        private Ingredient MapUserInputToIngredient()
        {
            int calories;
            int carbs;
            int proteins;
            int sugars;
            int fats;
            int satfats;
            UnitType unit;

            if(int.TryParse( CaloriesNewIngredient.Text , out calories ) &&
                int.TryParse( CarbsNewIngredient.Text , out carbs ) &&
                int.TryParse( ProteinsNewIngredient.Text , out proteins ) &&
                int.TryParse( SugarsNewIngredient.Text , out sugars ) &&
                int.TryParse( FatsNewIngredient.Text , out fats ) &&
                int.TryParse( SatFatsNewIngredient.Text , out satfats ) &&
                Enum.TryParse( UnitSelector.Text , out unit ))
            {
                return new Ingredient
                {
                    Name = NameNewIngredient.Text ,
                    Unit = unit ,
                    NutritionData = new NutritionData( NutritionDataType.Ingredient )
                    {
                        Calories = calories ,
                        CarbsGr = carbs ,
                        ProteinsGr = proteins ,
                        FatsGr = fats ,
                        SatFatsGr = satfats ,
                        SugarsGr = sugars
                    }
                };
            }
            else
            {
                throw new InvalidCastException();
            }
        }

        private void SaveIngredientChanges( object sender , RoutedEventArgs e )
        {
            DataHandler.SaveIngredientChanges();
        }

        private void TextBox_TextChanged( object sender , TextChangedEventArgs e )
        {
            // throw new NotFiniteNumberException();
        }

        private void TextBox_GotKeyboardFocus( object sender , KeyboardFocusChangedEventArgs e )
        {
            if(e.KeyboardDevice.IsKeyDown( Key.Tab ))
                ( (TextBox)sender ).SelectAll();
        }
    }
}