using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUsage : MonoBehaviour
{
    public GameObject desctext;    // The text item that has the description
    public GameObject statText;    // The text item that has the stats

    public GameObject nameText;
    public GameObject quantityText;

    public GameObject imageFrame;
    public GameObject image;

    public GameObject[] slot = new GameObject[7];   // A list that contains all of the slots in the inventory

    private void OnEnable()
    {
        ClearDescription();  // Clears the description at the start to remove the text thats there to show what goes in the specific box  
    }

    public void OnHover(GameObject hover)
    {
        try
        {
            var player = GameObject.Find("Player").gameObject;  // Find the player game object
            var inventory = player.GetComponent<Inventory>().inventory; // Get the player's inventory list

            for (int i = 0; i < 7; i++) // Loop through the inventory slots
            {
                if (hover.gameObject.name == slot[i].gameObject.name)   // Check if the hovered object matches the item in the current slot
                {   // The code inside this if statement will execute only when the hovered object matches the item in the current slot
                    var item = inventory[i].GetComponent<Item>();   // Get the Item component of the item in the inventory slot

                    // Update the description text box with the item description and quantity
                    desctext.GetComponent<Text>().text = item.description;
                    
                    // Update the stats text box with the item stats
                    statText.GetComponent<Text>().text = item.stats;

                    // The Quantity of the item
                    quantityText.GetComponent<Text>().text = item.quantity.ToString();

                    // The name of the item
                    nameText.GetComponent<Text>().text = item.gameObject.name;
                    image.GetComponent<Image>().sprite = inventory[i].GetComponent<SpriteRenderer>().sprite;  

                    // display the image
                    imageFrame.SetActive(true);
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



    public void OnHoverExit()
    {
        ClearDescription(); // clears the description when the player stops hovering on a slot
    }

    public void OnClick(GameObject click)
    {
        try
        {
            var player = GameObject.Find("Player").gameObject;  // Find the player game object
            var inventory = player.GetComponent<Inventory>().inventory; // Get the player's inventory list

            for (int i = 0; i < 7; i++) // Loop through the inventory slots
            {
                if (click.gameObject.name == slot[i].gameObject.name)   // Check if the clicked object matches the item in the current slot
                {
                    var item = inventory[i].GetComponent<Item>();   // Get the Item component of the item in the inventory slot

                    item.Usage(); // Use the item's ability

                    // Update the description text box with the current item description and quantity
                    desctext.GetComponent<Text>().text = item.description;

                    // The Quantity of the item
                    quantityText.GetComponent<Text>().text = item.quantity.ToString();

                    // The Name of the item
                    nameText.GetComponent<Text>().text = item.gameObject.name;
                    
                    // Update the stats text box with the current item stats
                    statText.GetComponent<Text>().text = item.stats;

                    if (item.quantity <= 0)
                    {
                        inventory[i] = null; // Set the inventory slot to null if the item quantity reaches 0
                        ClearDescription(); // Clear the description and stats text boxes

                        // The code inside this if statement will execute only when the item quantity reaches 0
                        // It performs actions such as using the item's ability, decreasing the quantity, and updating the text boxes
                        // If the item is completely depleted (quantity reaches 0), it sets the inventory slot to null and clears the text boxes
                    }
                }
            }
        }
        catch (System.Exception e)
        {
            ClearDescription(); // If an exception occurs (e.g., empty inventory slot), clear the description and stats text boxes

            print(e);

            // The code inside the try block attempts to find the item in the inventory corresponding to the clicked object
            // If successful, it uses the item's ability, decreases the quantity, and updates the text boxes
            // If there's an exception (e.g., empty inventory slot), it will catch the exception and clear the description and stats text boxes
        }
    }

    private void ClearDescription() // A function to avoid the repition of code
    {
        desctext.GetComponent<Text>().text = "";    // Sets the text boxes to blank
        statText.GetComponent<Text>().text = "";    //

        nameText.GetComponent<Text>().text = "";    // Sets the text boxes to blank
        quantityText.GetComponent<Text>().text = "";

        // hide the image
        imageFrame.SetActive(false);
    }
}
