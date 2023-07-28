using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EasterEggPerson : MonoBehaviour
{
    // Message Box
    public GameObject mb;

    // list of messages
    public string[] message = new string[1];

    void OnMouseOver() {
        if (Input.GetMouseButtonDown(0)) {
            StartCoroutine(Chat());
        } 
    }



    bool isExecuting = false;
    public IEnumerator Chat() {
        if (isExecuting) { yield break; }   // if the message is already playing stop a second from playing

        isExecuting = true;

        mb.GetComponent<Image>().color = new Color(0, 0, 0, 150/255f);  // resets the opacity of the message

        mb.SetActive(true);
        mb.transform.GetChild(0).GetComponent<Text>().text = message[Random.Range(0, 6)];

        // wait before closing hiding the box
        yield return new WaitForSeconds(1f);

        // Hiding the box
        for (float transparency = 150/255f; transparency > 0; transparency-=0.07f)
        {
            yield return new WaitForSeconds(.02f);
            mb.GetComponent<Image>().color = new Color(0f, 0f, 0f, transparency);    // Sets the screens transparency to the value
        }

        mb.SetActive(false);

        isExecuting = false;

    }
}
