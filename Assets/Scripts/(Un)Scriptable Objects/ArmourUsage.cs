using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmourUsage : MonoBehaviour
{
    // armour slots
    public GameObject[] armourSlots = new GameObject[6];

    public void OnClick(GameObject click) {
        // Getting the inventory
        var player = GameObject.Find("Player");
        var inventory = player.GetComponent<Inventory>().inventory;

        // getting the armour slots
        var armour = player.GetComponent<Inventory>().armour;

        // looping through each of the armour
        for (int i = 0; i < 6; i++)
        {
            // checking if the player clicked on the slot
            if (click.gameObject.name == armourSlots[i].gameObject.name) { // if the player clicked on the slots
                // removing the armour from the armour list
                for (int j = 0; j < 7; j++)
                {
                    if (inventory[j] == null) {
                        inventory[j] = armour[i];
                        armour[i].gameObject.GetComponent<Armour>().ArmourRemove();
                        armour[i].gameObject.GetComponent<Item>().quantity++;
                        armour[i] = null;
                        ClearDescription();
                    } else {
                        if (j == 6) {
                            var errorMessage = GameObject.FindObjectOfType<ErrorMessage>();
                            if (errorMessage != null)
                            {
                                errorMessage.StartFunction($"Inventory Full!");
                            }
                            break;
                        }
                        continue;
                    }
                }
                
            }
        }
    }

    // The text object
    public GameObject desctext;    // The text item that has the description
    public GameObject statText;    // The text item that has the stats

    public GameObject nameText;
    public GameObject quantityText;

    public GameObject imageFrame;
    public GameObject image;

    public void OnHover(GameObject hover)
    {
        try
        {
            var player = GameObject.Find("Player").gameObject;  // Find the player game object
            var armour = player.GetComponent<Inventory>().armour; // Get the player's inventory list

            for (int i = 0; i < 6; i++) // Loop through the inventory slots
            {
                if (hover.gameObject.name == armourSlots[i].gameObject.name)   // Check if the hovered object matches the item in the current slot
                {   // The code inside this if statement will execute only when the hovered object matches the item in the current slot
                    var item = armour[i].GetComponent<Item>();   // Get the Item component of the item in the inventory slot

                    // Update the description text box with the item description and quantity
                    desctext.GetComponent<Text>().text = item.description;
                    
                    // Update the stats text box with the item stats
                    statText.GetComponent<Text>().text = item.stats;

                    // Displaying that the peice is equiped
                    quantityText.GetComponent<Text>().text = "Equipped";

                    // The name of the item
                    nameText.GetComponent<Text>().text = item.gameObject.name;

                    // display the image
                    imageFrame.SetActive(true);
                    image.GetComponent<Image>().sprite = armour[i].GetComponent<SpriteRenderer>().sprite;  
                }
            }
        }
        catch
        {
            ClearDescription(); // If an exception occurs (e.g., empty inventory slot), clear the description and stats text boxes

            // The code inside the try block attempts to find the item in the inventory corresponding to the hovered object
            // If successful, it updates the description and stats text boxes with the item details
            // If there's an exception (e.g., empty inventory slot), it will catch the exception and clear the description and stats text boxes
        }
    }


    // Clearing the desc when the player stops hoveirng
    public void OnHoverExit()
    {
        ClearDescription(); // clears the description when the player stops hovering on a slot
    }

    // A function to avoid the repition of code
    private void ClearDescription()
    {
        desctext.GetComponent<Text>().text = "";    // Sets the text boxes to blank
        statText.GetComponent<Text>().text = "";    //

        nameText.GetComponent<Text>().text = "";    // Sets the text boxes to blank
        quantityText.GetComponent<Text>().text = "";

        // hide the image
        imageFrame.SetActive(false);
    }

}
