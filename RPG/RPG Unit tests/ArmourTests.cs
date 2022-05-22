using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RPG;


namespace RPGTests
{
    
    [TestClass]
    public class ArmourTests
    {
        [TestMethod]
        public void TestDefaultConstructor_Returns_CorrectValues()
        {
            
            string expectedArmourName = "Cardboard box";
            int expectedArmourMagicalPower = 0;
            ItemRarity expectedArmourRarity = ItemRarity.Common;
            int expectedArmourBuyValue = 0;
            double expectedArmourSellValue = 0;
            bool expectedArmourEquipped = false;
            double expectedArmourWeight = 0.2;
            double expectedArmourDefence = 0;
            int expectedArmourHealth = 100;
            ArmourMaterial expectedArmourMaterial = ArmourMaterial.Cardboard;
            ArmourType expectedArmourType = ArmourType.Head;


            // Act - what you want to test
            Armour testArmour = new Armour();

            string actualArmourName = testArmour.ItemName;
            int actualArmourMagicalPower = testArmour.ItemMagicalPower;
            ItemRarity actualArmourRarity = testArmour.ItemRarity;
            double actualArmourBuyValue = testArmour.ItemBuyValue;
            double actualArmourSellValue = testArmour.ItemSellValue;
            double actualArmourWeight = testArmour.ItemWeight;
            int actualArmourHealth = testArmour.ItemHealth;
            bool actualArmourEquipped = testArmour.Equipped;
            double actualArmourDefence = testArmour.ArmourDefence;
            ArmourMaterial actualArmourMaterial = testArmour.ArmourMaterial;
            ArmourType actualArmourType = testArmour.ArmourType;

            // Assert - that the actual values are equal to the expected values
            // Normally you should only ever have 1 assert
            // You can have more than one assert when the things we are testing are very
            // closely related such as ensuring all the default values for a default constuctor 
            // are correct.

            // Assert
            Assert.AreEqual(expectedArmourName, actualArmourName);
            Assert.AreEqual(expectedArmourMagicalPower, actualArmourMagicalPower);
            Assert.AreEqual(expectedArmourRarity, actualArmourRarity);
            Assert.AreEqual(expectedArmourBuyValue, actualArmourBuyValue);
            Assert.AreEqual(expectedArmourSellValue, actualArmourSellValue);
            Assert.AreEqual(expectedArmourWeight, actualArmourWeight);
            Assert.AreEqual(expectedArmourHealth, actualArmourHealth);
            Assert.AreEqual(expectedArmourEquipped, actualArmourEquipped);
            Assert.AreEqual(expectedArmourDefence, actualArmourDefence);
            Assert.AreEqual(expectedArmourMaterial, actualArmourMaterial);
            Assert.AreEqual(expectedArmourType, actualArmourType);

        }

        [TestMethod]
        public void TestToString_Returns_CorrectString()
        {
            // Arrange
            string expectedReturnedString = "Cardboard box|Type:Head|Material:Cardboard|Defence:0|Health:100|Rarity:Common|Magical Power:0|Value:0|Weight:0.2|Armour Health:100";
            Armour testArmour = new Armour();


            // Act
            string actualReturnedString = testArmour.ToString();

            // Assert
            Assert.AreEqual(expectedReturnedString, actualReturnedString);
        }
        [TestMethod]
        public void TestArmourMaterialError()
        {
            ArmourMaterial test1 = ArmourMaterial.Wood;
            ArmourMaterial expectedReturnedMaterial = ArmourMaterial.Wood;
            Assert.AreEqual(test1, expectedReturnedMaterial);
            


        }
        

        [TestMethod]
        public void TestEquipped()
        {
            Armour test1 = new Armour();
            Armour test2 = new Armour();

            test1.Equipped = true;
            Assert.AreNotEqual(test1.Equipped, test2.Equipped);
        }

        [TestMethod]
        public void TestArmourType()
        {
            Armour test1 = new Armour();
            Armour test2 = new Armour();

            test1.ArmourType = ArmourType.Chest;
            Assert.AreNotEqual(test1.ArmourType, test2.ArmourType);
        }

    }

}
