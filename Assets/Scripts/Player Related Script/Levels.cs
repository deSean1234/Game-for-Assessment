using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Levels : MonoBehaviour
{
    /*
        #2A2A2A - level 0 - 29
        #80FF56 - level 30 - 79
        #A42D2A - level 80 - 119
        #7C00FF - level 120 - 189
        #FF8C00 - level 190 - 239
        Chroma - level 240+ (Toggle and Customizer in settings)
    */

    // Update is called every frame
    public void Update() {
        // getting the level text
        try {
            var buffer = GameObject.Find("Level Text");
            buffer.GetComponent<Text>().text = "" + GetComponent<PlayerStats>().level;

            var level = GetComponent<PlayerStats>().level;
            if (level < 30) {buffer.GetComponent<Text>().color = new Color(42f, 42f, 42f);}
            else if (level > 29 && level < 80 ) {buffer.GetComponent<Text>().color = new Color(128f, 255f, 86f);}
            else if (level > 79 && level < 120 ) {buffer.GetComponent<Text>().color = new Color(164, 45, 42);}
            else if (level < 190 ) {buffer.GetComponent<Text>().color = new Color(124, 0, 255);}
            else if (level < 240 ) {buffer.GetComponent<Text>().color = new Color(255, 140, 0);}
            else if (level >= 240 ) {buffer.GetComponent<Text>().color = new Color(128, 255, 86);}

        } catch { return; }

        // updating the level to the player level -  this will be moved to the level up when that is coded so its not updating every frame
        
        // changing the colour of the letter text
        





        
    }
}
