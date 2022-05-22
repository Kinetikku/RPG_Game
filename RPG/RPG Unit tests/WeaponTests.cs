using Microsoft.VisualStudio.TestTools.UnitTesting;
using RPG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Tests
{
    [TestClass()]
    public class WeaponTests
    {
        [TestMethod()]
        public void Deafault_Constructor_WeaponTest()
        {
            string expectedItemName = "Spoon";
            int expectedItemMagicalPower = 0;
            ItemRarity expectedItemRarity = ItemRarity.Common;
            double expectedItemBuyValue = 0.5;
            double expectedItemSellValue = 0.25;
            double expectedItemWeight = 0.1;
            int expectedItemHealth = 100;
            int expectedWeaponHitStrength = 1;
            bool expectedDoubleHanded = false;
            bool expectedWeaponEquipped = false;

            Weapon testWeapon = new Weapon();

            string actualItemName = testWeapon.ItemName;
            int actualItemMagicalPower = testWeapon.ItemMagicalPower;
            ItemRarity actualItemRarity = testWeapon.ItemRarity;
            double actualItemBuyValue = testWeapon.ItemBuyValue;
            double actualItemSellValue = testWeapon.ItemSellValue;
            double actualItemWeight = testWeapon.ItemWeight;
            int actualItemHealth = testWeapon.ItemHealth;
            int actualWeaponHitStrength = testWeapon.WeaponHitStrength;
            bool actualDoubleHanded = testWeapon.DoubleHanded;
            bool actualWeaponEquipped = testWeapon.WeaponEquipped;


            Assert.AreEqual(expectedItemName, actualItemName);
            Assert.AreEqual(expectedItemMagicalPower, actualItemMagicalPower);
            Assert.AreEqual(expectedItemRarity, actualItemRarity);
            Assert.AreEqual(expectedItemBuyValue, actualItemBuyValue);
            Assert.AreEqual(expectedItemSellValue, actualItemSellValue);
            Assert.AreEqual(expectedItemWeight, actualItemWeight);
            Assert.AreEqual(expectedItemHealth, actualItemHealth);
            Assert.AreEqual(expectedWeaponHitStrength, actualWeaponHitStrength);
            Assert.AreEqual(expectedDoubleHanded, actualDoubleHanded);
            Assert.AreEqual(expectedWeaponEquipped, actualWeaponEquipped);
        }

        [TestMethod]
        public void TestWeaponToString_Returns_CorrectlyFormattedString()
        {
            string expectedReturnedString = "Sppon | Hit Strength: 1 | Double Handed: False | Equipped: False | Rarity: Common | Magical power: 0 " +
                $" | Value: 0.25 | Weight: 0.1 | Item Health: 100";

            Weapon testWeapon = new Weapon();

            string actualReturnedString = testWeapon.ToString();

            Assert.AreEqual(expectedReturnedString, actualReturnedString);
        }


    }
}