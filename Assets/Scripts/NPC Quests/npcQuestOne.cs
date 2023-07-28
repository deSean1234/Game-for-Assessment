using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class npcQuestOne : MonoBehaviour
{
    // number for keeping track of messages
    int messageNumber = 0;

    // The stuff that the npc needs and if the player has given the item
    

    // the message string
    public string[] message = new string[3];

    // the message box
    public GameObject mb;

    // if the player can talk
    bool canTalk = false;
    // if the player knows what he wants
    bool canGive = false;

    // the gameobject the player needs to bring
    public GameObject req;

    private void Update() {

        if (canTalk) {  // if the player is in range of the player
            if (Input.GetKeyDown(KeyCode.Space)) {  // if the player presses the spacebar
                // show message if not already
                mb.SetActive(true);
                
                var inventory = GameObject.Find("Player").GetComponent<Inventory>().inventory;  // getting the players inventory
                // looping through the inventory to find the item
                for (int i = 0; i < 7; i++) // loops through inv
                {
                    if (inventory[i] == req && canGive) {  // if the inv has the item
                        inventory[i] = null;    // remove the item
                        var player = GameObject.Find("Player");
                        player.GetComponent<PlayerStats>().exp += 15;
                        messageNumber = 4;      // set the message to the gratitude message
                    }
                }

                mb.transform.GetChild(0).GetComponent<Text>().text = message[messageNumber];    // display the message

                messageNumber++;    // go to the next message
        
                // if the player can give the item
                if (messageNumber == 2) {   // if the npc has described what he wantss
                    canGive = true; // becasue the player has heard the req they can now give the item
                }

                // if the player doesn't have the item
                if (messageNumber == 3) {   // if the message number is one up than the that's not what I need
                    messageNumber = 2;  // sets the message to the right one
                }

                // if the player has completed the quest
                if (messageNumber == 8) {   // if its one up. If this was 7 then the message would be the right one, but it would hide after pressing for the first time
                    messageNumber = 6;  // loop back to the thank you that is displayed next time the space is press, because it is six it gets pressed twice to reach 8
                    mb.SetActive(false);    // hide the message once it reaches 8
                }
            } 
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.name == "Player") {    // if it is the player in the trigger   
            // Setting the message as instructions for the player
            mb.SetActive(true);
            mb.transform.GetChild(0).GetComponent<Text>().text = "Greetings Adventurer!";
            canTalk = true; // the player is in range to talk with the npc
        }
    }

    private void OnTriggerExit2D(Collider2D other) {    // if the player walks away
        if (other.gameObject.name == "Player") {    // if the player is in range
            mb.SetActive(false);    // Hide the message board
            canTalk = false;        // the player is no longer in range to talk with the npc
        }
    }
}
