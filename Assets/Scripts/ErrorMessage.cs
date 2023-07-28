using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ErrorMessage : MonoBehaviour
{
    public GameObject messageBox;   // the message box gameobject
    public Text messageText;        // the text on the message box

    bool isCoroutineExecuting = false;  // if the courotine is executing

    public void StartFunction(string message) {
        StartCoroutine(Error(message));     // runs the function to show then hide the message box
    }

    public IEnumerator Error(string error) {
        if (isCoroutineExecuting) { // if the function is already going
            yield break;    // it doesn't need to run twice so a breal
        }

        isCoroutineExecuting = true;    // at the start, it is executing

        // resetting the message box
        messageBox.GetComponent<Image>().color = new Color(0, 0, 0, 0.5882f);   // sets the colour of the box to black and slightly transparent
        messageText.GetComponent<Text>().color = new Color(255, 255, 255, 1);   // sets the text colour to white and non transparent

        messageBox.SetActive(true); // activating the message box
        messageText.text = error;   // setting the text in the message box to the error

        // Wait for time to hide  message
        yield return new WaitForSeconds(2f);    // waiting time for reading the message

        for (float transparency = 0.5882f; transparency > 0f; transparency-=0.03f) {  // While the screen is not dark

            yield return new WaitForSeconds(.02f);  // Waits for time before running the next code without freezing the entire game

            messageBox.GetComponent<Image>().color = new Color(0, 0, 0, transparency);  // updates the boxes transparency
            messageText.GetComponent<Text>().color = new Color(255, 255, 255, transparency);    // update text transparency
        }

        isCoroutineExecuting = false;   // at the end, it is no longer executing

    }
}
