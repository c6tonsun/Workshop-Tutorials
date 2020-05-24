using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField]
    private float speed = 1;

    private int score;

    // Start is called before the first frame update
    void Start()
    {
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
        // did user start pressing SPACE
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private void Movement()
    {
        // saving user input
        float xForce = Input.GetAxis("Horizontal");
        float zForce = Input.GetAxis("Vertical");

        // making vector using input to move on the floor
        Vector3 forceVector = new Vector3(xForce * speed, 0, zForce * speed);

        // tells physics engine to move player by giving it force boost
        rb.AddForce(forceVector);
    }

    private void Jump()
    {
        // making vector using hardcoded value
        Vector3 jumpVector = new Vector3(0, 200, 0);

        // tells physics engine to add force to up direction
        rb.AddForce(jumpVector);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pickup")
        {
            score++;
            Debug.Log("Score: " + score);
            Destroy(other.gameObject);
        }
    }
}
