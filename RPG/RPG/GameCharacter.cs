/*
* GameCharacter.cs - 
*
* Version information v0.1
* Author: Dr. Shane Wilson
* Date: 04/04/2022
* Description: Acts as the base class for game character RPG classes
* Copyright notice
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    public enum CharacterState { Idle, Resting, Sleeping, Eating, Walking, Defending, Dead, Attacking, Running, Fleeing };
    
    /// <summary> Class <c> GameCharacter </c> implements the base class 
    /// for a simple RGP game character.
    /// </summary>

    public class GameCharacter
    {
        // Class fields 
        //Currently equiped items.
        private int _currentWeaponsEquiped = 0;

        // Lists that are designed to store the different item types. Might implement later.
        private List<Weapon> inventoryWeapon = new List<Weapon>();
        private List<Food> inventoryFood = new List<Food>();
        private List<Armour> inventoryArmour = new List<Armour>();
        // List that will store all items picked up.
        private List<Item> inventoryItems = new List<Item>();
        // List that will keep track of equiped weapons.
        List<Weapon> equipedWeapons = new List<Weapon>();

        // Static field recording the number of game characters
        private static int s_numberOfCharacters = 0;

        // The attack skill of the character. Must be in the range [0..100]
        private int _attackSkill;
        // The defence skill of the character. Must be in the range [0..100]
        private int _defenceSkill;

        // The level of the character. Valid range [0..100]
        private int _level;
        // The experience of the character. Valid range [0..100]
        // If the player reaches 100 xp, they increase by 1 level and _xp resets to 0
        private int _xp; 

        // Cannot be empty
        private string _name;
        // The current state of the game character
        private CharacterState _characterState;
        // _health must be in range [0..100]. If 0 then character state should be dead.
        private int _health;
        // _stamina must be in the range [0..100]
        private int _stamina;
        // The strength of the character. Must be in the range [0..100]
        private int _strength;
        // _totalWeightOfItems cannot exceed weightLimit
        private double _totalWeightOfItems;
        // _weightLimit must be > 0
        private double _weightLimit;


        // GameCharacter inventory
        // NOTE: The GameCharacter's inventory (items, food, weapons, armour) must be stored within the class.
        // You need to select appropriate collection(s) to allow the character to pickup and drop game items.


        // Implement class properties as required. It should not be possible to set invalid values. 
        public int AttackSkill
        {
            get { return _attackSkill; }
            set
            {
                if (value >= 0 && value <= 100)
                    _attackSkill = value;
                else
                    throw new ArgumentException();
            }
        }

        public int DefenceSkill
        {
            get { return _defenceSkill; }
            set
            {
                if (value >= 0 && value <= 100)
                    _defenceSkill = value;
                else
                    throw new ArgumentException();
            }
        }

        public int Level
        {
            get { return _level; }
            set
            {
                if (value >= 0 && value <= 100)
                    _level = value;
                else
                    throw new ArgumentException();
            }
        }

        public int XP
        {
            get { return _xp; }
            set
            {
                if (value >= 0 && value <= 100)
                    _xp = value;
                else
                    throw new ArgumentException();
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (value.Length > 0)
                    _name = value;
                else
                    throw new ArgumentException();
            }
        }

        public CharacterState CharacterState
        {
            get { return _characterState; }
            set
            {
                if (value == CharacterState.Idle || value == CharacterState.Resting || value == CharacterState.Sleeping || value == CharacterState.Eating || value == CharacterState.Walking || value == CharacterState.Defending || value == CharacterState.Dead || value == CharacterState.Attacking || value == CharacterState.Running || value == CharacterState.Fleeing)
                    _characterState = value;
                else
                    throw new ArgumentException();
            }
        }

        public int Health
        {
            get { return _health; }
            set
            {
                if (value >= 0 && value <= 100)
                    _health = value;
                else
                    throw new ArgumentException();
            }
        }

        public int Stamina
        {
            get { return _stamina; }
            set
            {
                if (value >= 0 && value <= 100)
                    _stamina = value;
                else
                    throw new ArgumentException();
            }
        }

        public int Strength
        {
            get { return _strength; }
            set
            {
                if (value >= 0 && value <= 100)
                    _strength = value;
                else
                    throw new ArgumentException();
            }
        }

        public double WeightLimit
        {
            get { return _weightLimit; }
            set
            {
                if (value > 0)
                    _weightLimit = value;
                else
                    throw new ArgumentException();
            }
        }

        public double TotalWeightOfItems
        {
            get { return _totalWeightOfItems; }
            set
            {
                if (value < WeightLimit)
                    _totalWeightOfItems = value;
                else
                    throw new ArgumentException();
            }
        }
        // Class methods

        //Default constructor
        /// <summary>
        /// Method <c>GameCharacter</c> initialises the game character with the following default values
        /// name="Random characterX", where "x" represents the number of characters created. Set Health=100, 
        /// weightLimit=30, _totalWrightOfItems = 0, no items in the inventory. Set all other numeric 
        /// attributes to a random value within the valid ranges. Should increment s_numberOfCharacters.
        /// </summary>
        public GameCharacter()
        {
            Name = "Random Character" + s_numberOfCharacters.ToString();
            Health = 100;
            WeightLimit = 30;
            TotalWeightOfItems = 0;
            AttackSkill = 20;
            DefenceSkill = 20;
            Level = 0;
            XP = 0;
            CharacterState = CharacterState.Idle;
            Stamina = 9;
            Strength = 20;
            s_numberOfCharacters++;
        }

        /// <summary>
        /// Method <c>GameCharacter</c> initialises a game character with the arguments supplied.
        /// The character should start with nothing in their inventory. 
        /// Should increment s_numberOfCharacters.
        /// </summary>
        /// <param name="attackSkill">A value [0..100] that specifies how skilfull the character is when attacking</param>
        /// <param name="defenceSkill">A value [0..100] that specifies how skilfull the character is when defending</param>
        /// <param name="level">A value [0..100] specifying the characters level</param>
        /// <param name="xp">A value [0..100] specifying the current experience gained</param>
        /// <param name="name">The name of the character</param>
        /// <param name="health">the starting health of the character</param>
        /// <param name="stamina">A value [0..100] specifying the stamina of the character</param>
        /// <param name="strength">A value [0..100] specifying the characters strength</param>
        /// <param name="weightLimit">the maximum amount of weight the character can carry</param>
        /// <param name="state">the starting state of the character</param>
        public GameCharacter(int attackSkill, int defenceSkill, int level, int xp, string name, 
            int health, int stamina, int strength, double weightLimit, CharacterState state)
        {
            AttackSkill = attackSkill;
            DefenceSkill = defenceSkill;
            Level = level;
            XP = xp;
            Name = name;
            Health = health;
            Stamina = stamina;
            Strength = strength;
            WeightLimit = weightLimit;
            CharacterState = state;
        }


        /// <summary>
        /// Method <c>Attack</c> should return a string "CharacterName is attacking param.CharacterName
        /// with a <equippedWeapon.ItemName>"
        /// Example output “Lord Percival is attacking Lord Blackadder with a sword"
        /// If the attacker is using no weapon
        /// Example output "Lord Percival is attacking Lord Blackader"
        /// If the attacker is using two weapons:
        /// Example output “Lord Percival is attacking Lord Blackadder with a sword and a knife"
        /// Should set the character state appropriately.
        /// </summary>
        /// <param name="character">The character this character should attack</param>
        /// <returns>A string formatted as described above.</returns>
        /// 
        public string Attack(GameCharacter character)
        {      
            if (equipedWeapons.Count() == 1)
                return $"{this.Name} is attacking {character.Name} with a {equipedWeapons[0].ItemName}";
            else if (equipedWeapons.Count() == 2)           
                return $"{this.Name} is attacking {character.Name} with a {equipedWeapons[0].ItemName} and a {equipedWeapons[1].ItemName}";
            else
                return $"{this.Name} is attacking {character.Name} bare handed.";
        }

        /// <summary>
        /// Method <c>Defend</c> sets the character's status to defend. Characters can only 
        /// defend if stamina is >0. 
        /// </summary>
        /// <returns>True if character state set to defending otherwise false</returns>
        public bool Defend()
        {
            if (Stamina > 0 && CharacterState != CharacterState.Defending)
            {
                CharacterState = CharacterState.Defending;
                return true;
            }
            else
                return false;
        }


        /// <summary>
        /// The <c>Train method</c> adds 10 xp points but costs 5 units of stamina.
        /// </summary>
        public void Train()
        {
            if (Stamina >= 5)
            {
                XP += 10;
                Stamina -= 5;
            }
        }


        /// <summary>
        /// Method <c>Eat</c> consumes amount the item of of food at the index provided.
        /// Logic for the eat method:
        /// If the item at inventoryItemIndex is of the class Food, the item is consumed and 
        /// removed from the inventory. Eating the item should replenish the characters health and stamina. 
        /// 1 units each of health and stamina = 25 calories. 
        /// The state of the food modifies the calorie content for only food with positive calorie
        /// values, as follows: Fresh 100% of calories, stale 60%, Mouldy 40%, rotten 10%
        /// Eg. an apple is 52 calories per 100g. 100g of mouldy apple will give only 20.8 (52*.4) calories.
        /// Health or stamina should not exceed 100.
        /// Consuming poisonous food (food with a negative calorie value) should reduce the health  and 
        /// stamina accordingly. When the eat method is invoked, the character's status should also change 
        /// to "Eating"
        /// Return true if the item was food and consumed, otherwise false.
        /// </summary>
        /// <param name="inventoryIndex">The index into the inventory for the food item to consume</param>
        /// <returns>
        /// A boolean value indicating if the item at inventoryIndex was food and therefore consumed. 
        /// </returns>
        public bool Eat(int inventoryIndex)
        {
            if (inventoryItems[inventoryIndex] is Food && inventoryIndex < inventoryItems.Count())
            {
                this.CharacterState = CharacterState.Eating;
                if (this.Health + (52 / 25) > 100)
                    this.Health = 100;
                if (this.Stamina + (52 / 25) > 100)
                    this.Stamina = 100;
                if (this.Health + (52 / 25) < 100)
                    this.Health += (52 / 25);
                if (this.Stamina + (52 / 25) < 100)
                    this.Stamina += (52 / 25);

                inventoryItems.RemoveAt(inventoryIndex);
                return true;
            }
            else
                return false;
        }


        /// <summary>
        /// The EquipWeapon will equip the weapon at inventoryWeaponIndex
        /// If the item in the inventory index is a weapon the method should return true, otherwise 
        /// false. If the weapon requires both hands (doubleHanded = true) the character must unequip 
        /// any weapons or shields they are currently holding.
        /// </summary>
        /// <param name="inventroyWeaponIndex">The index into the inventory for the weapon to equip</param>
        /// <returns>True if weapon equipped otherwise false </returns>
        public bool EquipWeapon(int inventoryWeaponIndex)
        {
            if (inventoryWeaponIndex < inventoryItems.Count() && inventoryItems[inventoryWeaponIndex] is Weapon)
            {
                Weapon currentWeapon = (Weapon)inventoryItems[inventoryWeaponIndex];

                if (currentWeapon.DoubleHanded && !currentWeapon.WeaponEquipped)
                {
                    foreach (Weapon weapon in inventoryItems)
                    {
                        if (weapon.WeaponEquipped)
                        {
                            weapon.WeaponEquipped = false;
                            equipedWeapons.Remove(weapon);
                        }
                    }
                    equipedWeapons.Add(currentWeapon);
                    _currentWeaponsEquiped = 2;
                }
                else if (!currentWeapon.DoubleHanded && !currentWeapon.WeaponEquipped && _currentWeaponsEquiped <= 2)
                {
                    _currentWeaponsEquiped += 1;

                    currentWeapon.WeaponEquipped = true;

                    inventoryItems[inventoryWeaponIndex] = currentWeapon;
                    equipedWeapons.Add(currentWeapon);
                    return true;
                }
                
                return false;                
            }
            else
                return false;
        }

        /// <summary>
        /// If the item in the inventory at inventoryWeaponIndex is a weapon, unequip it and return 
        /// true, otherwise false. Weapons that are unequipped remain in the inventory.
        /// </summary>
        /// <param name="inventroyWeaponIndex">The index into the inventory for the weapon to unequip</param>
        /// <returns>True if weapon unequipped otherwise false </returns>
        public bool UnequipWeapon(int inventoryWeaponIndex)
        {
            if (inventoryWeaponIndex < inventoryItems.Count() && inventoryItems[inventoryWeaponIndex] is Weapon)
            {
                Weapon _currentWeapon = (Weapon)inventoryItems[inventoryWeaponIndex];

                if (equipedWeapons.Contains(_currentWeapon))
                {
                    _currentWeapon.WeaponEquipped = false;
                    equipedWeapons.Remove(_currentWeapon);
                    inventoryItems[inventoryWeaponIndex] = _currentWeapon;
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }


        /// <summary>
        /// The <c>WearArmour</c> method is used to "put on" an item of armour at armourIndex in the 
        /// inventory. The character can only hold one shield at a time. If a shield is already 
        /// equipped and the armourIndex argument points to another shield, then the shield at 
        /// armourIndex is equipped instead. If the armourIndex points to a wearable piece of armour 
        /// the GameCharacter should put it on. The character may wear multiple pieces of armour 
        /// but can only wear one head armour item, one chest armour item. Two leg items, two arm items.
        /// As with a shield, putting on a wearable item will remove any item currently in that location.
        /// </summary>
        /// <param name="armourIndex">The index into the inventory for the armour to wear</param>
        /// <returns>True if the item at armourIndex is put on by the character, otherwise false.</returns>
        public bool WearArmour(int armourIndex)
        {
            // TO DO - add your implementation
            throw new NotImplementedException();
        }

        /// <summary>
        /// The method <c>RemoveArmour</c> should remove the item of armour at armourIndex from the gameCharacter. 
        /// The character essentially takes off the piece of armour but it remains in their inventory.
        /// </summary>
        /// <param name="armourIndex">The index into the inventory for the armour to remove</param>
        /// <returns>True if the item at armourIndex is removed by the character, otherwise false.</returns>
        public bool RemoveArmour(int armourIndex)
        {
            // TO DO - add your implementation
            throw new NotImplementedException();
        }

        /// <summary>
        /// <c>Walk</c> sets the character state to walking if the character's stamina >=5. 
        /// Character's stamina should be reduced by 5 if they start walking.
        /// </summary>
        /// <returns>True if the character's state changes, otherwise false.</returns>
        public bool Walk()
        {
            if (CharacterState == CharacterState.Walking)
                return false;
            else if (Stamina >= 5)
            {
                CharacterState = CharacterState.Walking;
                Stamina -= 5;
                return true;
            }
            return false;
        }

        /// <summary>
        /// The <c>Flee</c> method sets the characters state to fleeing if stamina >=10
        /// and reduces the stamina by 10.
        /// </summary>
        /// <returns>True if the character's state changes, otherwise false.</returns>
        public bool Flee()
        {
            if (CharacterState == CharacterState.Fleeing)
                return false;
            else if (Stamina >= 10)
            {
                CharacterState = CharacterState.Fleeing;
                Stamina -= 10;
                return true;
            }
            return false;
        }

        /// <summary>
        /// <c>Run</c> sets the character state to running if stamina >=15 
        /// and reduces stamina by 15.
        /// </summary>
        /// <returns>True if the character's state changes, otherwise false.</returns>
        public bool Run()
        {
            if (CharacterState == CharacterState.Running)
                return false;
            else if (Stamina >= 15)
            {
                CharacterState = CharacterState.Running;
                Stamina -= 15;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Sets the character state to sleeping and adds 20 stamina.
        /// </summary>
        public void Sleep()
        {
            CharacterState = CharacterState.Sleeping;
            Stamina += 20;
        }

        /// <summary>
        /// Sets the character state to resting and adds 5 stamina.
        /// </summary>
        public void Rest()
        {
            CharacterState = CharacterState.Resting;
            Stamina += 5;
        }

        /// <summary>
        /// If the character is sleeping the <c>WakeUp</c> method should change the character's state to Idle
        /// If the character is not sleeping, the method should not change the character's state.
        /// </summary>
        public void WakeUp()
        {
            if (CharacterState == CharacterState.Sleeping)
                CharacterState = CharacterState.Idle;
        }

        /// <summary>
        /// The Method <c>GetArmour</c> should return the armour item at index. 
        /// </summary>
        /// <param name="index">The index into the inventory for the armour to return</param>
        /// <returns>Return the armour item at index. If item at index is not a piece of 
        /// armour return a temp armour object called "EmptyArmour.</returns>
        public Armour GetArmour(int index)
        {
            if (inventoryItems[index] is Armour)
                return (Armour)inventoryItems[index];
            else
                return new Armour(0,"EmptyArmour",ItemRarity.Common,0,0,0,0,0,ArmourType.Chest,ArmourMaterial.Leather);
        }

        /// <summary>
        /// The Method <c>GetWeapon</c> should return the weapon item at index. If the index
        /// is an invalid value return a temp weapon item with the name "EmptyWeapon" and 
        /// all numeric attributes set to 0
        /// </summary>
        /// <param name="index">The index into the inventory to the weapon to return</param>
        /// <returns>A weapon object at index if valid otherwise an empty weapon</returns>
        public Weapon GetWeapon(int index)
        {
            if (inventoryItems[index] is Weapon)
                return (Weapon)inventoryItems[index];
            else
                return new Weapon(0, "EmptyWeapon", ItemRarity.Common, 0, 0, 0, 0, 0, false, false);
        }


        /// <summary>
        /// The method <c>PickUpItem</c> should add the item to the inventory if the weight 
        /// of the item plus the current weight of all items carried by the character does 
        /// not exceed the character's weightlimit. Return true if the character picks up 
        /// the item, otherwise false.
        /// </summary>
        /// <param name="itemtoPickUp">An item to add to the inventory</param>
        /// <returns></returns>
        public bool PickUpItem(Item itemtoPickUp)
        {
            _totalWeightOfItems = 0;

            foreach (Item item in inventoryItems)
            {
                _totalWeightOfItems += item.ItemWeight;
            }

            if (_totalWeightOfItems + itemtoPickUp.ItemWeight < _weightLimit)
            {
                _totalWeightOfItems += itemtoPickUp.ItemWeight;

                inventoryItems.Add(itemtoPickUp);

                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// The method <c>DropItem</c> removes the item from the inventory if the 
        /// character is carrying it and returns true. If the characher is not carrying the 
        /// item there is no change and return false
        /// </summary>
        /// <param name="armour">An item  to remove from the inventory</param>
        /// <returns>True if the item is dropped otherwise false.</returns>
        public bool DropItem(Item itemToDrop)
        {
            foreach (Item item in inventoryFood)
            {
                if (item.Equals(itemToDrop))
                {
                    Console.WriteLine($"{itemToDrop} has been dropped!");
                    return true;
                }
            }
            foreach (Item item in inventoryWeapon)
            {
                if (item.Equals(itemToDrop))
                {
                    Console.WriteLine($"{itemToDrop} has been dropped!");
                    return true;
                }
            }
            foreach (Item item in inventoryArmour)
            {
                if (item.Equals(itemToDrop))
                {
                    Console.WriteLine($"{itemToDrop} has been dropped!");
                    return true;
                }
            }
            foreach (Item item in inventoryItems)
            {
                if (item.Equals(itemToDrop))
                {
                    Console.WriteLine($"{itemToDrop} has been dropped!");
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// The method <c>DropItem</c> removes the item from the inventory at inventoryIndex.
        /// If the inventory index is valid remove the item from the inventory and return true.
        /// Otherwise return false.
        /// </summary>
        /// <param name="inventoryIndex">An index to the item to remove from the inventory</param>
        /// <returns>True if the item is dropped otherwise false.</returns>
        public bool DropItem(int inventoryIndex)
        {

            if (inventoryItems[inventoryIndex] != null)
            {
                Console.WriteLine($"{inventoryItems[inventoryIndex].ItemName} has been dropped!");
                inventoryItems.RemoveAt(inventoryIndex);
                return true;
            }
            else if (inventoryFood[inventoryIndex] != null)
            {
                Console.WriteLine($"{inventoryFood[inventoryIndex].ItemName} has been dropped!");
                inventoryFood.RemoveAt(inventoryIndex);
                return true;
            }
            else if (inventoryWeapon[inventoryIndex] != null)
            {
                Console.WriteLine($"{inventoryWeapon[inventoryIndex].ItemName} has been dropped!");
                inventoryWeapon.RemoveAt(inventoryIndex);
                return true;
            }
            else if (inventoryArmour[inventoryIndex] != null)
            {
                Console.WriteLine($"{inventoryArmour[inventoryIndex].ItemName} has been dropped!");
                inventoryArmour.RemoveAt(inventoryIndex);
                return true;
            }
            else
                return false;
        }


        /// <summary>
        ///  The method <c>DamageArmour</c> should reduce the health of all the equipped/worn armour
        ///  items by the amount. If the health of any piece of armour is <=0 the item should be "destroyed"
        ///  and removed from the character's inventory.
        /// </summary>
        /// <param name="amount">The amount to damage the armour by</param>
        /// <returns>Return True if any item of armour is destroyed, otherwise false.</returns>
        public bool DamageArmour(int amount)
        {
            foreach (Armour armour in inventoryItems)
            {
                if (armour.ItemHealth - amount <= 0 && armour.Equipped)
                {
                    inventoryItems.Remove(armour);
                    return true;
                }
                else if (armour.ItemHealth - amount > 0 && armour.Equipped)
                {
                    armour.ItemHealth -= amount;
                    return false;
                }
            }
            return false;
        }


        /// <summary>
        /// The GetCharacterDefencedefence returns the defence value of the character
        /// The value is determined by totalling the armourDefence values of all 
        /// armour items currently equipped by the game character.
        /// </summary>
        /// <returns>The total defence value of the character</returns>
        public double GetCharacterDefence()
        {
            double _characterDefence = 0;

            foreach (Armour armour in inventoryItems)
            {
                if (armour.Equipped)
                {
                    _characterDefence += armour.ArmourDefence;
                }
            }
            return _characterDefence;
        }

        /// <summary>
        /// The GetCharacterAttackValue method returns the total attack value of the character.
        /// The total attack value is determined by totalling the weaponHitStrength values of all
        /// weapons currently equipped/held by the game character plus the characters strength.
        /// EG character _strength = 45. They are holding an Axe with _weaponHitStrength of 23
        /// Character attack value is 68
        /// </summary>
        /// <returns>The total attack value of the character</returns>
        public double GetCharacterAttackValue()
        {
            double _characterAttack = 0;

            foreach (Weapon weapon in inventoryItems)
            {
                if (weapon.WeaponEquipped)
                {
                    _characterAttack += weapon.WeaponHitStrength;
                }
            }
            return _characterAttack + this.Strength;
        }


        /// <summary>
        ///  The method <c>DamageWeapon</c> should reduce the health of the equipped weapons
        ///  by the amount. If the health of the item is <=0 the weapon should be removed 
        ///  from the character's inventory.
        /// </summary>
        /// <param name="amount">The amount to damage the weapon by</param>
        /// <returns>Return True of a weapon is damaged. Otherwise false</returns>
        public bool DamageWeapon(int amount)
        {
            foreach (Weapon weapon in inventoryItems)
            {
                if (weapon.ItemHealth - amount <= 0 && weapon.WeaponEquipped)
                {
                    inventoryItems.Remove(weapon);
                    return true;
                }
                else if (weapon.ItemHealth - amount > 0 && weapon.WeaponEquipped)
                {
                    weapon.ItemHealth -= amount;
                    return false;
                }
            }
            return false;
        }

        /// <summary>
        /// The method <c>PrintAllItems</c> will display a list of all items that the character is currently carrying.
        /// </summary>
        /// <returns>void</returns>
        public void PrintAllItems()
        {            
            foreach (Item item in inventoryItems)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public override string ToString()
        {
            return $"Name: {Name}\nHealth: {Health}\nAttack: {AttackSkill}\nDefence: {DefenceSkill}\nStamina: {Stamina}\nStrength: {Strength}\nLevel: {Level}\nWeight Limit: {WeightLimit}\nCharacter State: {CharacterState}";
        }

    }

}
