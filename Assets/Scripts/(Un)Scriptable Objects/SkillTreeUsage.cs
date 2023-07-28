using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillTreeUsage : MonoBehaviour
{
    public int cost; // the cost of unlocking the skill

    public void SkillTreeLeaves(GameObject click) { // The function that gives permanent stat boosts based off the button pressed
        // Getting the amount of skill points
        var skillPoints = GameObject.Find("Player").GetComponent<PlayerStats>().skillPoints; // Gets the amount of the skillpoints the player has from the playerstats script

        // Usage
        if (skillPoints >= cost) {   /// if the player has enough points to expend
            skillPoints -= cost;    // Expends skill points based off the cost

            // change the transparancy of the children
            for (int i = 0; i < 2; i++) {   // for each of the skill trees children
                click.transform.GetChild(i).GetComponent<Image>().color = new Color(255, 255, 255, 255);    // Updates the color of the children
            }
        
        } else {   // if the player doesn't have the resources to spend
            // run an error message
            var errorMessage = GameObject.FindObjectOfType<ErrorMessage>(); // FInds the error message script
            if (errorMessage != null) { // If the script can be found
                errorMessage.StartFunction($"You do Not Have Enough Skill Points!\nYou Need {cost}");
            }
        }
        
    }
}
