using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D player; // Player
    public float moveForce = 1f; //Movementspeed
    
    void Start()
    {
        player = this.GetComponent<Rigidbody2D>(); //player rigidbody initializing
        
    }


    void FixedUpdate()
    {
        // recording player movement in a vector
        Vector2 moveVector = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal"),CrossPlatformInputManager.GetAxis("Vertical")) * moveForce;

        if (moveVector.sqrMagnitude> 0.01)
        {
            player.MovePosition(player.position + moveVector * moveForce * Time.fixedDeltaTime); // will move the position of the player
        }
        

        //recording player rotation in a vector
        Vector2 lookVector = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal_2"), CrossPlatformInputManager.GetAxis("Vertical_2")) ;
        //condition for checking if the look joystick is released 
        if (lookVector.sqrMagnitude> 0.01) 
        {
            float angle = Mathf.Atan2(lookVector.y, lookVector.x) * Mathf.Rad2Deg;            
            player.rotation = angle;
        }        
    }

    void Update()
    {
        player.velocity = new Vector3(0, 0, moveForce);

        //Bounds
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -16.89f, 16.89f), Mathf.Clamp(transform.position.y, -9.13f, 9.13f)); 
    }

    //Movement with Arrows
    void HandleMovementInput () {
        float _horizontal = Input.GetAxis("Horizontal");
        float _vertical = Input.GetAxis("Vertical"); 

        Vector3 _movement = new Vector3(_horizontal, 0, _vertical);
        transform.Translate(_movement * moveForce * Time.deltaTime,Space.World);
    }
}
