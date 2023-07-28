using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject inventoryUI;  // The inventory ui
    public bool isInvOpen = false;  // if the inventory is open or not

    // List of Items in the Inventory   // The inventory itself
    public GameObject[] inventory = new GameObject[7];
    /*
        the entire inventory is stored in this list
        to get the images to show in the ui, it gets the sprite from the list item
    */
    public GameObject[] armour = new GameObject[6];

    // List of Slots
    GameObject[] slot = new GameObject[7];
    public GameObject slots;    // The parent object that groups all of the slots together

    GameObject[] armourSlot = new GameObject[6];
    public GameObject armourSlots;  // The parent object grouping the armour slots


    public Sprite defaultImage; // the default image for if a slot has no object in it

    // Update is called once per frame
    void Update()
    {
        // Opening the inventory
        if (Input.GetKeyDown(KeyCode.E) && CanOpenInv()) {
            if (!isInvOpen) {
                isInvOpen = true;
                inventoryUI.SetActive(true);
            } else {
                isInvOpen = false;
                inventoryUI.SetActive(false);
            }
        }


        if (Input.GetKeyDown(KeyCode.Escape)) { // if the user presses the escape key
            isInvOpen = false;
            inventoryUI.SetActive(false);       // Closes the inventory
        }


        // Inventory Stuff
        for (int i = 0; i < 7; i++) {   // repeats for every slot

            slot[i] = slots.transform.GetChild(i).gameObject;   // the first slot is the first child in the grouped slots
            var imageChild = slot[i].transform.GetChild(0).gameObject;  // Gets to the image child by taking the slot then getting the child which is an ui image
            var invImage = imageChild.GetComponent<Image>();  // From that child it gets the image component

            if (inventory[i] == null) { // if the inventory 'slot' has nothing in it (in quotations becuase it is taking the value of the list)
                invImage.sprite = defaultImage; // takes the sprite for the image component of the image child and sets it to a default image
                invImage.color = new Color(255f, 255f, 255f, 135f);   // sets the transparency of the default image as slightly transparent for aesthetics
            } else {    // else, in this case if the inventory 'slot' has an object in it
                invImage.sprite = inventory[i].GetComponent<SpriteRenderer>().sprite;   
                // ^ Takes the object in the list value, goes to the sprite renderer component, and takes the sprite attatched to it
                // ^^ Then, the inventory image, which is the image component on the image child is set as the new value
                invImage.color = new Color(255f, 255f, 255f, 255f);   // sets the colour as a solid block as the default image is slightly transparant
            }
        }

        // Armour Slots
        for (int i = 0; i < 6; i++)
        {
            armourSlot[i] = armourSlots.transform.GetChild(i).gameObject;   // the first slot is the first child in the grouped slots
            var imageChild = armourSlot[i].transform.GetChild(0).gameObject;  // Gets to the image child by taking the slot then getting the child which is an ui image
            var invImage = imageChild.GetComponent<Image>();  // From that child it gets the image component

            if (armour[i] == null) { // if the inventory 'slot' has nothing in it (in quotations becuase it is taking the value of the list)
                invImage.sprite = defaultImage; // takes the sprite for the image component of the image child and sets it to a default image
                invImage.color = new Color(255f, 255f, 255f, 135f);   // sets the transparency of the default image as slightly transparent for aesthetics
            } else {    // else, in this case if the inventory 'slot' has an object in it
                invImage.sprite = armour[i].GetComponent<SpriteRenderer>().sprite;   
                // ^ Takes the object in the list value, goes to the sprite renderer component, and takes the sprite attatched to it
                // ^^ Then, the inventory image, which is the image component on the image child is set as the new value
            }
        }

    }

    // Adding an item to the inventory // picking up an item
    private void OnTriggerEnter2D(Collider2D item) {
        if (item.gameObject.tag == "Equipable") {
            try {
                for (int i = 0; i < 7; i++)
                {
                    // if the item exists in the inventory
                    try {   // try catch block because error if inv is empty
                        if (inventory[i].GetComponent<Item>().ID == item.GetComponent<Item>().ID) {
                            // if the amount is less than max quanity
                            if (inventory[i].GetComponent<Item>().quantity < inventory[i].GetComponent<Item>().maxQuantity) {
                                inventory[i].GetComponent<Item>().quantity++;   // increase the quantity
                                break;
                            } else {
                                Debug.Log("Too much of one item");
                            }
                        }
                    } catch {}

                    // if the item doesn't already exist in the ineventory
                    if (inventory[i] == null) {
                        inventory[i] = item.gameObject;
                        item.GetComponent<Item>().quantity++;
                        break;
                    } else {
                        continue;
                    }
                }
                item.gameObject.SetActive(false);  // hides the object from the game without deleting it from existance which means the list can hold the object
                // If I destroy the object then the array would say the object is missing
            } catch {
                var errorMessage = GameObject.FindObjectOfType<ErrorMessage>();
                if (errorMessage != null)
                {
                    errorMessage.StartFunction($"Inventory is Full!");
                    return; // Exits the function if it fails;
                }
            }
        }
    }

    bool CanOpenInv() { // if the player can open the inventory 
        try {
            GameObject pm = GameObject.Find("Pause Menu UI");   // tries to find the pause menu ui
            if (pm.activeInHierarchy) {}    // I have zero idea what this line does, but if I delete it the function doesn't work properly
            return false;   // the pause menu must be open and so the user cannot open their inventory
        } catch {   // because it becomes null the if statement fails and so it runs the catch block
            return true;    // the pause menu is not open and so the inv can be openned
        }
    }
}
