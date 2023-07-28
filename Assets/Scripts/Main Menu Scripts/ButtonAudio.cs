using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAudio : MonoBehaviour
{
    public AudioSource source;
    public AudioClip hoverSound;    // The audio clip to be played when the button is hovered

    // The different textures of the cursor
    public Texture2D normalCursor;  //  A normal pointer cursor
    public Texture2D handCursor;    //  A hand select cusor

    public void OnButtonHover() {
        Debug.Log("Button Hover Sound");
        Cursor.SetCursor(handCursor, Vector2.zero, CursorMode.Auto);
        source.PlayOneShot(hoverSound); // Plays the button hover sound when the function is run
    }

    public void OnButtonExit() {
        Debug.Log("Cursor off Button");
        Cursor.SetCursor(normalCursor, Vector2.zero, CursorMode.Auto);
    }
}
