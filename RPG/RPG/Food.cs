/*
* Food.cs
*
* Version information v0.1
* Author: Dr. Shane Wilson
* Date: 04/04/2022
* Description: Food class for objects that characters may have in their inventory and the can
* comsume to regain health.
* Copyright notice
*/



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    public enum FoodState { Fresh, Stale, Mouldy, Rotten };

    /// <summary>
    /// The class <c>Food</c> represents items of food that game characters can consume 
    /// to regain health.
    /// </summary>
    public class Food : Item
    {
        // Food class Fields

        // The state of the food modifies the calorie content for only food with positive calorie values, as follows:
        // Fresh 100% of calories, stale 60%, Mouldy 40%, rotten 10%
        private FoodState _foodState;
        // Calories per 100grams. Must be in the range [-1000 to 1000].
        // Food with a negative value is poisonous and will reduce the characters health if eaten.
        private int _calories;

        /* Exemplar calories of sample food per 100g
        * Apple 52 calories
        * Steak 271 calories
        * Mushroom 22 calories
        * Bread 264 calories 
        
        100g of stale bread would provide 158.4 calories.
         */
 


        // Food class Properties
        /// <summary>
        /// Make sure to c=use double == to comapre the value inputted, to the current state of freshness.
        /// If food is not fresh, apply a deduction to the overall calorie amount. Make sure semicolons are correct.
        /// </summary>
        public FoodState FoodState{

            get { return _foodState; }
            set{

                if (value == FoodState.Fresh)
                    _foodState = value;

                else if (value == FoodState.Stale)
                    _foodState = value;

                else if (value == FoodState.Mouldy)
                    _foodState = value;

                else if (value == FoodState.Rotten)
                    _foodState = value;

                else
                    throw new ArgumentException();
            }
        }

       public int Calories{   
            
            get { return _calories; }
            set{   
                if((value <=-1000) && (value <=1000))
                
                    _calories = value;   
            
            }
       }

        /// <summary>
        /// Make sure we check the commas and parameter order.
        /// </summary>
        /// <param name="itemMagicalPower"></param>
        /// <param name="itemName"></param>
        /// <param name="itemRarity"></param>
        /// <param name="itemBuyValue"></param>
        /// <param name="itemSellValue"></param>
        /// <param name="itemWeight"></param>
        /// <param name="itemHealth"></param>
        /// <param name="foodState"></param>
        /// <param name="calories"></param>

        public Food(int itemMagicalPower, string itemName, ItemRarity itemRarity, double itemBuyValue, double itemSellValue, double itemWeight, int itemHealth, FoodState foodState, int calories)
                    : base(itemMagicalPower, itemName, itemRarity, itemBuyValue, itemSellValue, itemWeight, itemHealth)
        {
            FoodState = foodState;
            Calories = calories;
        }


        // TODO - Implement Item class properties and methods as required.
        // Remember to throw an appropriate exception if any method or Property
        // is given an invalid argument.

        /// <summary>
        /// The <c>GetTotalCalories method returns the total calories of the item of food.
        /// This is calculated based on the state of the food, the calories per 100 grams 
        /// and the total weight of the item of food.</c>
        /// </summary>
        /// <returns>A double representing to total calorie content of the food item </returns>
        public double GetTotalCalories(FoodState FoodState, int calories){
            
            double fState = 0;
            
            if(FoodState == FoodState.Fresh)

                fState = 1;

            else if(FoodState == FoodState.Stale)
                fState = 0.6;

            else if(FoodState == FoodState.Mouldy)
                fState = 0.4;

            else if(FoodState == FoodState.Rotten)
                fState = 0.1;

            else
                throw new NotImplementedException();

             double _allCals = 0;
            _allCals = (fState * Calories);

            return _allCals;

            throw new NotImplementedException();
        }

        /// <summary>
        /// The <c>ToString</c> method should override the base object ToString method by 
        /// returning a string as follows:
        /// "_itemName | State: _foodState | Total Calories <TODO Calclculate the total calories of this item of food> | 
        /// Rarity: _itemRarity | Magical power: _itemMagicalPower | Value: _itemSellValue | Weight: _itemWeight"
        /// </summary>
        /// <returns>A string summarising the attributes of the item</returns>
        public override string ToString(){

            return ItemName + "|" + "State:" + FoodState + "|" + "Total Calories:" + Calories +
                   "|" + "Rarity:" + ItemRarity + "|" + "Magical Power:" + ItemMagicalPower + "|" + 
                    "Value:" + ItemSellValue + "|" + "Weight:" + ItemWeight;

            throw new NotImplementedException();

        }
   
    }
}
