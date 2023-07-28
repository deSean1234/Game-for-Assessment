using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingEnter : MonoBehaviour
{
    public GameObject objToMove;    // The Object to be moved
    public float posX;              // The position on the x axis
    public float posY;              // The position on the y axis

    public GameObject messageBox;   // A message box to tell the user to press input
    public AudioSource source;      // Audio objects to play sound
    public AudioClip doorSound;     // The audio clip to be played when the button is hovered
    public GameObject screen;            // A screen to have a pseudo Animation

    private bool canEnterBuilding = false; // If the player can enter the building
    public bool requiresInput;             // If the building requires input to enter

    public GameObject newLocationMessage;  // The message box for the new location 
    public string location;                // The location of the thing

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K) && canEnterBuilding)
        {
            StartCoroutine(MovePlayer(posX, posY));     // Moves the player to the correct spot
            canEnterBuilding = false;   // Because the player has already entered the building
        }
    }

    // check if the player collides with an input needed door
    private void OnTriggerEnter2D(Collider2D other) {
        if (requiresInput)    // if it is a door and thus require the player to input
        {  
            canEnterBuilding = true;
            // Display the message box
            MessageAnimation.Play(messageBox, 0, 1, 0.075f, true, true, false, 0); // accesses the function from another script that changes the transparency
        } else  // the door does not require input 
        {    
            StartCoroutine(MovePlayer(posX, posY));     // Moves the player to the entered position
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        canEnterBuilding = false;
        MessageAnimation.Play(messageBox, 1, 2, -0.075f, true, true, false, 0);    // Hides the screen

    }

    public IEnumerator MovePlayer(float x, float y) {
        MessageAnimation.Play(screen, 0, 1, 0.035f, true, false, false, 0);
        MessageAnimation.Play(screen, 1, 2, -0.035f, true, false, true, 0.75f);

        newLocationMessage.transform.GetChild(0).gameObject.GetComponent<Text>().text = location;
        var time = GameObject.Find("EventSystem").GetComponent<TimeCycle>().time;
        newLocationMessage.transform.GetChild(1).gameObject.GetComponent<Text>().text = time;

        yield return new WaitForSeconds(0.7f);

        objToMove.transform.position = new Vector2(x, y);      

        newLocationMessage.SetActive(true);

        yield return new WaitForSeconds(1f);

        for (float trans = 1f; trans > 0; trans-= 0.035f)
        {
            for (int j = 0; j < 2; j++)
            {
                newLocationMessage.transform.GetChild(j).gameObject.GetComponent<Text>().color = new Color(255, 255, 255, trans);
            }
            yield return new WaitForSeconds(0.035f);
        }

    }
}
