using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    // The movespeed of the player
    public float moveSpeed;

    // The object that will move; the player
    public Rigidbody2D rb;

    // The player animation
    public Animator animator;

    // YOu just got vectored
    Vector2 movement;

    // Update is called once per frame
    void FixedUpdate()
    {
        var player = GameObject.Find("Player");
        moveSpeed = player.GetComponent<PlayerStats>().moveSpeed;

        movement.x = Input.GetAxisRaw("Horizontal");  // Taking the user of the input from "a", or "d", and setting it as a positive/negative value in order for the position to be moved by the value timesed by the movespeed
        movement.y = Input.GetAxisRaw("Vertical");    // The same but for vertical

        animator.SetFloat("Horizontal", movement.x);     // Takes the value of the horizontal input, between -1 and 1, and sets the horizontal float in the animator to this value. This causes the player to play and animation depending on the value 
        animator.SetFloat("Vertical", movement.y);  // The same for vertical, value between -1 and 1, sets the animator number to this value, plays animation depending on value
        animator.SetFloat("Speed", movement.sqrMagnitude);  // This takes the speed of the player, and sets the speed float to that value. The animator checks if this value is less than very small, and if it is plays an idle animation

        if (movement.magnitude > 1f) {
            movement.Normalize();
        }
        rb.MovePosition(rb.position + movement * moveSpeed  *  Time.fixedDeltaTime);    // It takes the position of the player and then adds the vertical and horizontal movement, which is between 1 and -1, timesed by the movement speed to simulate moving
    }
}
