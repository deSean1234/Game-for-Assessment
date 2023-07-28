using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armour : MonoBehaviour
{
    // The type of armour
    public enum Type { Headwear, Torso, Boots, Talisman, Cloak, Socks }    // The different types of potions
    public Type type;   // Buff for the specific potion

    // The Stats of the armour peice
    [Header("These stats are added to the players")]
    public int maxHealth;
    public float healthRegen;
    public float moveSpeed;
    public int strength;

    public float damageReduction;
    public float baseDamageMultiplier;

    public float baseMagicReduction;
    public int magicCapacity;
    public int baseMagicCost;

    // Dictionary to map armour types to slots
    Dictionary<Type, int> armourSlots = new Dictionary<Type, int>()
    {
        { Type.Headwear, 0 },
        { Type.Torso, 1 },
        { Type.Boots, 2 },
        { Type.Talisman, 3 },
        { Type.Cloak, 4 },
        { Type.Socks, 5 }
    };

    // List of armour slots
    GameObject[] armour;

    private void Start()
    {
        var player = GameObject.Find("Player"); // Find the player
        armour = player.GetComponent<Inventory>().armour;   // Get the armour slots from the inventory
    }

    public void ArmourEquip()
    {
        // Check if the armour slot is already occupied
        if (armourSlots.ContainsKey(type)) // Check if the armour type exists in the armourSlots dictionary
        {
            int slotIndex = armourSlots[type]; // Get the slot index corresponding to the armour type
            if (armour[slotIndex] == null) // Check if the slot is empty
            {
                armour[slotIndex] = gameObject; // Equip the new armour piece
                _Armour();
            } else // If the slot is not empty
            {
                var errorMessage = GameObject.FindObjectOfType<ErrorMessage>();
                if (errorMessage != null)
                {
                    errorMessage.StartFunction($"You Already Have {type} Equipped");
                    return; // Exits the function if it fails;
                }
            }
        }

        GetComponent<Item>().quantity--; // Decrease the item's quantity by 1
    }

    public void _Armour() {
        // Get the players stats
        var player = GameObject.FindObjectOfType<PlayerStats>();
        player.maxHealth += maxHealth;
        player.healthRegen += healthRegen;
        player.moveSpeed += moveSpeed;
        player.strength += strength;
        player.damageReduction += damageReduction;
        player.baseDamageMultiplier += baseDamageMultiplier; 
        player.baseMagicReduction += baseMagicReduction;
        player.magicCapacity += magicCapacity;
        player.baseMagicCost += baseMagicCost;
    }

    public void ArmourRemove() {
        // Get the players stats
        var player = GameObject.FindObjectOfType<PlayerStats>();
        player.maxHealth -= maxHealth;
        player.healthRegen -= healthRegen;
        player.moveSpeed -= moveSpeed;
        player.strength -= strength;
        player.damageReduction -= damageReduction;
        player.baseDamageMultiplier -= baseDamageMultiplier; 
        player.baseMagicReduction -= baseMagicReduction;
        player.magicCapacity -= magicCapacity;
        player.baseMagicCost -= baseMagicCost;
    }
}
