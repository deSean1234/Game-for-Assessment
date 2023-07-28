using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCycle : MonoBehaviour
{
    public int seconds = 00;
    public int minutes = 00;
    public int hours = 0;

    [HideInInspector] public string time;

    private void Start() {
        StartCoroutine(InGameTimeCycle());  // this is temporay as eventually game time will need to be saved
    }

    public IEnumerator InGameTimeCycle() {
        string am;
        while (true){
            if (hours >= 12) {
                am = "pm";  // because it is in the afternoon, 12 or later
            } else { am = "am";}    // when it zero or less than 12, or in the morning 

            time = ($"{hours.ToString().PadLeft(2, '0')}:{minutes.ToString().PadLeft(2, '0')}{am}");


            // showing day night cycle
            if (hours == 6 || hours == 21) {
                // StartCoroutine(DayNightCycle(hours));
            }

            // wait a new second
            yield return new WaitForSeconds(.1f); // waits a tenth of a second to represent each day being a tenth of a real day - 24m
            seconds++;

            // updating the time
            if (seconds == 60) {
                minutes++;
                seconds = 0;
                if (minutes == 60) {
                    hours++;
                    minutes = 0;
                    if (hours == 24) {
                        // New day
                        hours = 0;
                    }
                }
            }

            
        }
    }

    public GameObject nightScreen;
    public IEnumerator DayNightCycle(int time) {
        print("Function Called");
        if (time == 21) {
            print("Night Time");
            for (float transparency = 0; transparency <= 150/255f; transparency += 0.01f)
            {
                yield return new WaitForSeconds(.02f);
                nightScreen.GetComponent<Image>().color = new Color (0, 0, 0, transparency);
            }
        } else if (time == 6) {
            print("Day TIme");
            for (float i = 150/255f; i >= 0; i -= 0.01f)
            {
                yield return new WaitForSeconds(.02f);
                nightScreen.GetComponent<Image>().color = new Color (0, 0, 0, i);
            }
        }
    }
}
