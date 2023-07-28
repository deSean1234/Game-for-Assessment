using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Spells : MonoBehaviour
{
    string equippedSpell;

    private void Update() {
        // Getting the user input from 1-6
        equippedSpell = Console.ReadKey().ToString();

        if (Input.GetMouseButtonDown(0)) {  // If the user clicks first mouse button
            UseSpell(equippedSpell);
        }
    }

    public void UseSpell(string spell) {
        switch (spell)
        {
            case "1":
                FireBall();
                break;
            case "2":
                Lightning();
                break;
            case "3":
                Ice();
                break;
            case "4":
                WaterWall();
                break;
            case "5":
                GravityPull();
                break;
            case "6":
                QuestionMark();
                break;
            
            case "q":
                // Unequip
                break;

            
            default:
                return;
        }

    }

    // A function for each spell
    public void FireBall() {print("This is a test");}

    public void Lightning() {print("This is a test");}

    public void Ice() {print("This is a test");}

    public void WaterWall() {print("This is a test");}

    public void GravityPull() {print("This is a test");}

    public void QuestionMark() {print("This is a test");}
}
