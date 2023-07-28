using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potions : MonoBehaviour
{
    // This script goes on a potion gameobject
    // The item script will also go on the gameobject
    public enum Buff{ Health, Speed, Immunity, Strength, DamageReduction }    // The different types of potions
    public Buff buff;   // buff for the specific potion

    public enum Size{ Small, Medium, Large }    // The different sizes of potions, larger sizes will have larger effect
    public Size size;   // size of specific potion

    // What gets buffed
    public GameObject buffer;

    // Update is called once per frame
    public void Potion()
    {   
        var player = buffer.GetComponent<PlayerStats>();    // Getting the player stats script
        // Small potions, small buff
        if (size == Size.Small) {
            if (buff == Buff.Health) { player.health += 10; } // Will grant health
            if (buff == Buff.Speed) { player.moveSpeed += 0.15f; }  // Will Increase the speed of the player
            if (buff == Buff.Immunity) {}   // Will grant damage immunity to the player while the effect is active
            if (buff == Buff.Strength) {}   // Will Give an increase in damage to the player
            if (buff == Buff.DamageReduction) {}    // Reduces the damage taken to the player
        }

        // Medium Potions, Medium Buff
        if (size == Size.Medium) {
            if (buff == Buff.Health) { player.health += 35; } // Will grant health
            if (buff == Buff.Speed) { player.moveSpeed += .3f; }  // Will Increase the speed of the player
            if (buff == Buff.Immunity) {}   // Will grant damage immunity to the player while the effect is active
            if (buff == Buff.Strength) {}   // Will Give an increase in damage to the player
            if (buff == Buff.DamageReduction) {}    // Reduces the damage taken to the player
        }

        // Large Potions, large buff
        if (size == Size.Large) {
            if (buff == Buff.Health) { player.health += 75; } // Will grant health
            if (buff == Buff.Speed) { player.moveSpeed += .6f; }  // Will Increase the speed of the player
            if (buff == Buff.Immunity) {}   // Will grant damage immunity to the player while the effect is active
            if (buff == Buff.Strength) {}   // Will Give an increase in damage to the player
            if (buff == Buff.DamageReduction) {}    // Reduces the damage taken to the player
        }

        GetComponent<Item>().quantity--; // Decrease the item's quantity by 1
    }
}