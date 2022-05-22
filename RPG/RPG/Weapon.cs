/*
* Weapon.cs
*
* Version information v0.1
* Author: Dr. Shane Wilson
* Date: 04/04/2022
* Description: Weapon class for weapons that characters may have
* Copyright notice
*/

/// <summary> Class <c> Weapon </c> implements a weapon object for RGP game characters.
/// </summary>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
   public class Weapon : Item
    {
        // The damage the weapon does. Valid range [1..100]
        private int _weaponHitStrength;
        private bool doubleHanded; // Does the weapon require both hands? True or false.
        private bool weaponEquipped; // Is the weapon being held, true or false.

        // Implement Weapon class Properties as required. Remember to throw appropriate
        // exceptions as required if the set is given an invalid argument

        public int WeaponHitStrength
        { 
            get { return _weaponHitStrength;} 
            
            set
            {
                if ((value >= 1) && (value <= 100))
                {
                    _weaponHitStrength = value;
                }
                else
                {
                    throw new ArgumentException("WeaponHitStrength - invalid range (must be between 1 to 100)");
                }
            }
        
        }
        public bool DoubleHanded
        {
            get { return doubleHanded;}

            set
            {
                if ((value == true) || (value == false))
                {
                    doubleHanded = value;
                }
                else
                {
                    throw new ArgumentException("DoubleHanded - invalid input [true or false]");
                }
            }

        }
        public bool WeaponEquipped 
        {
            get { return weaponEquipped; }

            set
            {
                if ((value == true) || (value == false))
                {
                    weaponEquipped = value;
                }
                else
                {
                    throw new ArgumentException("WeaponEquipped - invalid input [true or false]");
                }
            }

        }


        //Weapons class Methods
            /// <summary>
            /// The default constructor for <c>Weapon</c> should create an weapon object
            /// with the following default values:
            /// WeaponName = "Spoon";
            /// WeaponMagicalPower =0
            /// WeaponRarity = Common
            /// WeaponBuyValue = 0.5;
            /// WeaponSellValue = 0.25;
            /// WeaponWeight = 0.1;
            /// WeaponHitStrength = 1;
            /// WeaponHealth = 100;
            /// DoubleHanded = false;
            /// WeaponEquipped = false;
            /// </summary>
        public Weapon()
        {
            // TO DO - add your implementation
            ItemName = "Spoon"; 
            ItemMagicalPower = 0;
            ItemRarity = ItemRarity.Common;
            ItemBuyValue = 0.5;
            ItemSellValue = 0.25;
            ItemWeight = 0.1;
            WeaponHitStrength = 1;
            ItemHealth = 100;
            DoubleHanded = false;
            WeaponEquipped = false;

           // throw new NotImplementedException();
        }
        
        public Weapon(int itemMagicaPower, string itemName, ItemRarity itemRarity,  double itemBuyValue, double itemSellValue, double itemWeight, int itemHealth, int _weaponHitStrength, bool doubleHanded, bool weaponEquipped)
            : base(itemMagicaPower, itemName, itemRarity, itemBuyValue, itemSellValue, itemWeight, itemHealth)

        {
            // TO DO - add your implementation
            WeaponHitStrength = _weaponHitStrength;
            DoubleHanded = doubleHanded;
            WeaponEquipped = weaponEquipped;

            //throw new NotImplementedException();
        }

        /// <summary>
        /// The <c>ToString</c> method should override the base object ToString method by 
        /// returning a string as follows:
        /// "_itemName | Hit Strength: _weaponHitStrength | Double handed: True or False
        /// Equipped: True or False | Rarity: _itemRarity | Magical power: _itemMagicalPower 
        /// | Value: _itemSellValue | Weight: _itemWeight | Armour Health: _itemHealth"
        /// </summary>
        /// <returns>A string summarising the attributes of the item</returns>
        public override string ToString()
        {
            // TO DO - add your implementation
            return ItemName + " | " + "Hit Strength: " + _weaponHitStrength + " | " + "Double Handed: " + doubleHanded +
                              " | " + "Equipped: " + weaponEquipped + " | " + "Rarity: " + ItemRarity + " | " + "Magical Power: " + ItemMagicalPower +
                " | " + "Value: " + ItemSellValue + " | " + "Weight: " + ItemWeight + " | " + "Weapon Health: " + ItemHealth;


            //throw new NotImplementedException();
        }

    }
}
