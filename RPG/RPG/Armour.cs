/*
* Armour.cs
*
* Version information v0.1
* Author: Dr. Shane Wilson
* Date: 04/04/2022
* Description: Armour class for Armour that characters may have
* Copyright notice
*/

using System;

namespace RPG
{
    //Enumeration for armour types
    public enum ArmourMaterial { Cardboard, Leather, Wood, Iron, Steel };
    public enum ArmourType { Head, Chest, Arms, Legs, Shield }; 

    /// <summary>
    /// The Armour class implements a piece of armour that a character has in their inventory. 
    /// Each item of armour is either be worn on a body partsuch as gloves or a helmet or can be carried
    /// such as a shield. Naturally a game character can only wear one head armour item, one chest 
    /// armour item. Two leg items, two arm items. They can also hold only one shield at a time. 
    /// </summary>
    public class Armour : Item
    {
        // Armour class Fields

        // The defensive value of the armour. Must be in range [1..100]
        private int _armourDefence;
        // A simple boolean flag. True means the armour is being held (shield) or worn (eg gloves)
        //Default value is false.
        private bool _equipped; 
        private ArmourMaterial _armourMaterial;
        private ArmourType _armourType;
        

        // TODO - Implement Armour class properties as required. Remember to throw appropriate
        // exceptions as required if a Property is given an invalid argument.

        public int ArmourDefence
        { get { return _armourDefence; }
            set { if (value >= 0) _armourDefence = value;
             else
                throw new ArgumentException("Defense value must be greater than 0");
            }
        }
        public bool Equipped
        {
            get { return _equipped; }
            set
            {
                if (value == true || value == false) _equipped = value;
                else
                    throw new ArgumentException("Equipped value must be true or false");
            }
        }
        public ArmourMaterial ArmourMaterial
            { get{ return _armourMaterial; }
              set 
            {
                if (value == ArmourMaterial.Cardboard || value == ArmourMaterial.Leather || value == ArmourMaterial.Wood || value == ArmourMaterial.Iron || value == ArmourMaterial.Steel)
                {
                    _armourMaterial = value;
                }
                else throw new ArgumentException("Armour material must be a valid material");
            }
        
        
        }
        public ArmourType ArmourType
        {
            get { return _armourType; }
            set
            {
                if (value == ArmourType.Head || value == ArmourType.Chest || value == ArmourType.Arms || value == ArmourType.Arms|| value == ArmourType.Legs || value == ArmourType.Shield)
                {
                    _armourType= value;
                }
                else throw new ArgumentException("Armour type must be a valid type");
            }


        }
       


        // Armour class Methods

        /// <summary>
        /// The default constructor for <c>Armour</c> should create an armour object
        /// with the following default values:
        /// ArmourName = "Cardboard box";
        /// ArmourMagicalPower = 0
        /// ArmourRarity = Common
        /// ArmourBuyValue = 0.0;
        /// ArmourSellValue = 0.0;
        /// Equipped = false;
        /// ArmourWeight = 0.2;
        /// ArmourDefence = 0;
        /// ArmourHealth = 100;
        /// ArmourMaterial = ArmourMaterial.Cardboard;
        /// ArmourType = ArmourType.Head;
        /// </summary>
        public Armour()
        {
            // TO DO - add your implementation
            //throw new NotImplementedException();
            ItemName = "Cardboard box";
            ItemMagicalPower = 0;
            ItemRarity = ItemRarity.Common;
            ItemBuyValue = 0.0;
            ItemSellValue = 0.0;
            Equipped = false;
            ItemWeight = 0.2;
            ArmourDefence = 0;
            ItemHealth = 100;
            ArmourMaterial = ArmourMaterial.Cardboard;
            ArmourType = ArmourType.Head;
            
        }


        /// <summary>
        /// The non-default constructor for <c>Armour</c> should initialise the new armour object. 
        /// All new items of armour are not equipped by default. 
        /// </summary>
        /// <param name="armourName"></param>
        /// <param name="armourValue"></param>
        /// <param name="armourweight"></param>
        /// <param name="defence"></param>
        /// <param name="armourHealth"></param>
        /// <param name="type"></param>
        public Armour(int itemMagicalPower, string itemName, ItemRarity itemRarity,
            double itemBuyValue, double itemSellValue, double itemWeight, int armourDefence, 
            int itemHealth, ArmourType armourType, ArmourMaterial armourMaterial)
            : base(itemMagicalPower, itemName, itemRarity, itemBuyValue, itemSellValue, itemWeight, itemHealth)
        
        {
            // TO DO - add your implementation
           
            this.ArmourDefence= armourDefence;
            this.ArmourType = armourType;
            this.ArmourMaterial = armourMaterial;
            Equipped = false;
            
        }


        /// <summary>
        /// The <c>ToString</c> method should override the base object ToString method by 
        /// returning a string as follows:
        /// "_itemName | Type: _armourType | Material: _armourMaterial | Defence: _armourDefence | 
        /// Health: _armourHealth | Rarity: _itemRarity | Magical power: _itemMagicalPower | 
        /// Value: _itemSellValue | Weight: _itemWeight | Armour Health: _itemHealth"
        /// </summary>
        /// <returns>A string summarising the attributes of the item</returns>
        public override string ToString()
        {
            // TO DO - add your implementation
            return ItemName + "|" + "Type:" + _armourType + "|" + "Material:" + _armourMaterial + "|" + "Defence:" + _armourDefence + "|" + "Health:" + ItemHealth + "|" +
            "Rarity" + ItemRarity + "|" + "Magical Power" + ItemMagicalPower + "|" + "Value" + ItemSellValue + "|" + "Weight" + ItemWeight + "|" + "Armour Health" + ItemHealth;
            

        }


    }
}
