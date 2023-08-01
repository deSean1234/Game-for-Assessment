using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldBorder : MonoBehaviour
{
    float time = 0; // Initialize the damage dealing timer
    float damage = 1; // The base amount of damage while drowning

    private void OnTriggerStay2D(Collider2D other)
    {
        // Check if the colliding object is the player
        if (other.gameObject.name == "Player")
        {
            time += Time.deltaTime; // Increment the timer with the time passed since the last frame

            const float damageInterval = 2f; // Set the time interval to deal damage (2 seconds)
            if (time >= damageInterval)
            {
                PlayerStats playerStats = other.GetComponent<PlayerStats>();
                
                playerStats.health -= damage; // Deal damage to the player
                damage *= 2; // Increase the damage for the next tick (exponential increase)
                time = 0; // Reset the timer

                print(damage);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Check if the colliding object is the player
        if (other.gameObject.name == "Player")
        {
            damage = 1; // Reset the damage back to its base value
            print(damage);
        }
    }
}