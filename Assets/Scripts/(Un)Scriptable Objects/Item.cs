using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Item : MonoBehaviour
{
    public int ID;  // The identification code of the item
    // these are hidden in inspector as they are set when the item script is added, and don't need to be changed
    [HideInInspector] public int quantity = 0;    // the amount of the item the player has; default 0
    [HideInInspector] public int maxQuantity = 64; // The max amount a player can hold of an item

    public enum Type{ Potion, Weapon, Scroll, Armour }    // The different types of items
    public Type type;   // The type for specific item

    public string description;  // The description of the item
    public string stats;        // Item Stats

    GameObject[] armour;
    
    public void Start() {
        var player = GameObject.Find("Player");
        armour = player.GetComponent<Inventory>().armour;
    }

    public void Usage() {
        
        if (type == Type.Potion) {
            GetComponent<Potions>().Potion();   //
        }
        
        if (type == Type.Armour) {
            GetComponent<Armour>().ArmourEquip();
        } 

        if (type == Type.Weapon) {
            var errorMessage = GameObject.FindObjectOfType<ErrorMessage>();
            if (errorMessage != null)
            {
                errorMessage.StartFunction($"You have no knowledge on how to use this item.");
                return; // Exits the function if it fails;
            }
        }
    }
}