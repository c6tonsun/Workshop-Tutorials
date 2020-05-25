using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Objects rigidbody component
    private Rigidbody rb;

    [SerializeField]
    private float speed = 1;

    private int score;

    // Start is called before the first frame update
    void Start()
    {
        // Get the rigidbody component from the gameObject and assign it to the rb variable
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        UserInput();
        Movement();
    }

    private void UserInput()
    {
        // Has the user pressed down the space key
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private void Movement()
    {
        // Forces on the x and y axis's taken from the Unity input class
        // Both are a value between -1 and 1
        float xForce = Input.GetAxis("Horizontal");
        float zForce = Input.GetAxis("Vertical");

        // Creating a Vector3 with the force values
        Vector3 forceVector = new Vector3(xForce * speed, 0, zForce * speed);

        // Adding force to the objects Rigidbody equal to the forceVector
        rb.AddForce(forceVector);
    }

    private void Jump()
    {
        // Vector with a value of 200 on the y axis
        Vector3 jumpVector = new Vector3(0, 200, 0);

        // Adds force to the rigidbody equal to the jumpVector
        rb.AddForce(jumpVector);
    }

    // OnTriggerEnter is called when the object collides with a trigger collider
    private void OnTriggerEnter(Collider other)
    {
        // Does the collided objects tag equal "Pickup"
        if (other.tag == "Pickup")
        {
            score++;
            Debug.Log("Score: " + score);
            
            // Destroy the other object
            Destroy(other.gameObject);
        }
    }
}
