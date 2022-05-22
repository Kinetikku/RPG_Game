/*
* Item.cs
*
* Version information v0.1
* Author: Dr. Shane Wilson
* Date: 04/04/2022
* Description: Item class for objects that characters may have in their inventory
* Copyright notice
*/



using System;


namespace RPG
{
    public enum ItemRarity { Common, Uncommon, Rare, Legendary, Mythic};

    /// <summary>
    /// The Item class acts as the base class for all objects within the RPG game.
    /// </summary>
    public class Item
    {
        //Item class Fields
        // If the value is >0 then the item has magical properties. Valid values [0..10]
        private int _itemMagicalPower;
        // Cannot be empty
        private string _itemName;
        // How rare the item is. Used to modify the attributes of some derived objects.
        private ItemRarity _itemRarity;
        // How much it would cost to buy new. Must >=0
        private double _itemBuyValue;
        // How much you would get if you sold the item. Must >=0
        private double _itemSellValue;
        //How much the item weighs in kg. Must be > 0
        private double _itemWeight;
        // The health of the item. Must be in range [1..100]. 
        private int _itemHealth;

        // TODO - Implement Item class properties and methods as required.
        // Remember to throw an appropriate exception if any method or Property
        // is given an invalid argument.

        //Properties **** REMOVE 
        public int ItemMagicalPower
        {
            get { return _itemMagicalPower; }
            set {
                if (value >= 0)
                    _itemMagicalPower = value;
                else
                    throw new ArgumentException();
            }
        }

        public string ItemName {
            get { return _itemName; }
            set {
                if (value.Length > 0)
                    _itemName = value;
                else
                    throw new ArgumentException();
            }
        }
        public ItemRarity ItemRarity {
            get { return _itemRarity; }
            set {
                if (value == ItemRarity.Common || value == ItemRarity.Uncommon || value == ItemRarity.Rare || value == ItemRarity.Legendary || value == ItemRarity.Mythic)
                    _itemRarity = value;
                else
                    throw new ArgumentException();
            }
        }
        public double ItemBuyValue {
            get { return _itemBuyValue; }
            set {
                if (value >= 0)
                    _itemBuyValue = value;
                else
                    throw new ArgumentException();
            }
        }
        public double ItemSellValue {
            get { return _itemSellValue; }
            set {
                if (value >= 0)
                    _itemSellValue = value;
            }
        }
        public double ItemWeight {
            get { return _itemWeight; }
            set {
                if (value > 0)
                    _itemWeight = value;
                else
                    throw new ArgumentException();
            }
        }
        public int ItemHealth {
            get { return _itemHealth; }
            set {
                if (value > 0 && value < 101)
                    _itemHealth = value;
                else
                    throw new ArgumentException();
            }
        }

        /// <summary>
        /// The default constructor for <c>Item</c> should create an Item object
        /// with the following default values:
        /// ItemName = "RANDOM ITEM";
        /// ItemRarity = Legendary
        /// ItemMagicalPower = 5
        /// ItemBuyValue = set to itemRarity*_itemMagicalPower + itemRarity*10;
        /// ItemSellValue - set to 1/2 of the ItemBuyValue;
        /// ItemWeight = 0.2;
        /// ItemHealth = 100;
        /// </summary>
        public Item()
        {
            ItemName = "RANDOM ITEM";
            ItemRarity = ItemRarity.Legendary;
            ItemMagicalPower = 5;
            ItemBuyValue = ((int) _itemRarity * _itemMagicalPower) + ((int) _itemRarity * 10);
            ItemSellValue = _itemBuyValue / 2;
            ItemWeight = 0.2;
            ItemHealth = 100;
        }

        /// <summary>
        /// The <c>Item</c> constructor creates an item object using the arguments supplied. 
        /// An ArgumentException exception should be thrown if one of the arguments provided
        /// to the method is not valid.
        /// </summary>
        /// <param name="itemMagicalPower">the magical power of the item</param>
        /// <param name="itemName">the name of the item</param>
        /// <param name="itemRarity">how rare the item is</param>
        /// <param name="itemBuyValue">the cost to buy the item new</param>
        /// <param name="itemSellValue">the value of the item if sold</param>
        /// <param name="itemWeight">the weight of the item in kg</param>
        public Item(int itemMagicalPower, string itemName, ItemRarity itemRarity, 
            double itemBuyValue, double itemSellValue, double itemWeight, int itemHealth)
        {
            ItemName = itemName;
            ItemRarity = itemRarity;
            ItemMagicalPower = itemMagicalPower;
            ItemBuyValue = itemBuyValue;
            ItemSellValue = itemSellValue;
            ItemWeight = itemWeight;
            ItemHealth = itemHealth;
        }

        /// <summary>
        /// The <c>ToString</c> method should override the base object ToString method by 
        /// returning a string as follows:
        /// "_itemName | Rarity: _itemRarity | Magical power: _itemMagicalPower | 
        /// Value: _itemSellValue | Weight: _itemWeight | Item Health: _itemHealth"
        /// </summary>
        /// <returns>A string summarising the attributes of the item</returns>
        public override string ToString()
        {
            return $"{ItemName} | Rarity: {ItemRarity} | Magical power: {ItemMagicalPower} " +
                $"| Value: {ItemSellValue} | Weight: {ItemWeight} | Item Health: {ItemHealth}";
        }

    }
}