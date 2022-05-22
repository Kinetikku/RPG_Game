using System;
using RPG;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RPG_Unit_tests
{
    [TestClass]
    public class RPGItemsTests
    {
      
        /// <summary>
        /// A test method to ensure that the default item constructor creates the items
        /// with correct values
        /// </summary>
        [TestMethod]
        //Naming tests should follow: Method, scenario, expected behaviour
        //TestSetArmourName_Returns_DefaultConstructorValue

        public void TestDefaultItemConstructor_Returns_CorrectDefaultValues()
        {
            // The AAA format is popular for unit tests 
            // Alternatives include Given When Then for BDD testing

            // Arrange objects and variables for the unit test
            string expectedItemName = "RANDOM ITEM";
            int expectedItemMagicalPower = 5;
            ItemRarity expectedItemRarity = ItemRarity.Legendary;
            int expectedItemBuyValue = 45;
            double expectedItemSellValue = 22.5;
            double expectedItemWeight = 0.2;
            int expectedItemHealth = 100;

            
            // Act - what you want to test
            Item testItem = new Item();

            string actualItemName = testItem.ItemName;
            int actualItemMagicalPower = testItem.ItemMagicalPower;
            ItemRarity actualItemRarity = testItem.ItemRarity;
            double actualItemBuyValue = testItem.ItemBuyValue;
            double actualItemSellValue = testItem.ItemSellValue;
            double actualItemWeight = testItem.ItemWeight;
            int actualItemHealth = testItem.ItemHealth;

            // Assert - that the actual values are equal to the expected values
            // Normally you should only ever have 1 assert
            // You can have more than one assert when the things we are testing are very
            // closely related such as ensuring all the default values for a default constuctor 
            // are correct.

            // Assert
            Assert.AreEqual(expectedItemName, actualItemName);
            Assert.AreEqual(expectedItemMagicalPower, actualItemMagicalPower);
            Assert.AreEqual(expectedItemRarity, actualItemRarity);
            Assert.AreEqual(expectedItemBuyValue, actualItemBuyValue);
            Assert.AreEqual(expectedItemSellValue, actualItemSellValue);
            Assert.AreEqual(expectedItemWeight, actualItemWeight);
            Assert.AreEqual(expectedItemHealth, actualItemHealth);

        }

        [TestMethod]
        public void TestItemToString_Returns_CorrectlyFormattedString()
        {
            // Arrange
            string expectedReturnedString = "RANDOM ITEM | Rarity: Legendary | Magical power: 5 " +
                $"| Value: 22.5 | Weight: 0.2 | Item Health: 100";
            Item testItem = new Item();


            // Act
            string actualReturnedString = testItem.ToString();

            // Assert
            Assert.AreEqual(expectedReturnedString, actualReturnedString);
        }

    }
}
