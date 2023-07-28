using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTree : MonoBehaviour
{
    // The skill tree object
    public GameObject st; // st for skill tree

    public bool isActive = false; // if the st is open

    // Update is called once per frame
    void Update()
    {
        // This will be changed so that the player can only open the ui in certain places
        // Opening and Closing the Skill Tree UI
        if (Input.GetKeyDown(KeyCode.J)) {
            isActive = !isActive; // Toggle the isActive flag to its opposite state
            st.SetActive(isActive); // Activate or deactivate the UI based on the isActive flag
        }
    }
}
