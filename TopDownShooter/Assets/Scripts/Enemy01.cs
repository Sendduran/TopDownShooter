using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy01 : MonoBehaviour
{
    //Enemy movement speed
    [SerializeField]
    private float movementSpeed = 0.0f;
    //Enemy Rigidbody2D
    public Rigidbody2D myRigidbody2D;
    //rotate speed
    public float rotateSpeed;
    //Target = Player
    private Transform target;
    //Player direction
    private Vector3 targetDirection;
    //rotate direction
    Vector3  rotateDirection;
    //enemy health 
    public int health = 100;
    //game object animation
    public GameObject DeathEffect;



    // Start is called before the first frame update
    void Start()
    {   
        //Assiging the Variable to Rigidbody2D
        myRigidbody2D = GetComponent<Rigidbody2D>();
        //Assiging the transform of Player
        target = GameObject.FindGameObjectWithTag ("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        RotateGameObject(target,rotateSpeed,1.0f);
    }

    private void Movement()
    {
        // move sprite towards the target location
        transform.position = Vector2.MoveTowards(transform.position, target.position, movementSpeed * Time.deltaTime);
    }
    
    private void RotateGameObject(Transform target, float RotationSpeed, float offset)
    {
        //get the direction of the other object from current object
        Vector3 targetDirection = target.position - transform.position;
        //get the angle from current direction facing to desired target
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
        //set the angle into a quaternion + sprite offset depending on initial sprite facing direction
        Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, angle + offset));
        //Roatate current game object to face the target using a slerp function which adds some smoothing to the move
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, RotationSpeed * Time.deltaTime);
    }

    public void TakeDamage(int damage) {
        health -= damage;
        if (health <= 0) {
            Die();
        }
    }

    void Die() {
        Instantiate(DeathEffect, transform.position, Quaternion.identity);
        this.gameObject.SetActive(false);
    }

}
