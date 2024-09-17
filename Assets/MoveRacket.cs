using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRacket : MonoBehaviour
{
    public float speed = 30;
    public float zAngle = 10;
    public string axis = "Vertical";

    private Rigidbody2D paddle;

    void Start()
    {
        paddle = GetComponent<Rigidbody2D>();
    }

    // Physics-related updates should stay in FixedUpdate()
    void FixedUpdate()
    {
        float v = Input.GetAxisRaw(axis);
        paddle.velocity = new Vector2(0, v) * speed;
    }

    // Key input detection should be in Update() for more consistent responsiveness
    void Update()
    {
        // Rotate the paddle once when 'A' is pressed
        if (Input.GetKeyDown(KeyCode.A))
            transform.Rotate(Vector3.forward * zAngle);

        // Rotate the paddle once when 'D' is pressed
        if (Input.GetKeyDown(KeyCode.D))
            transform.Rotate(-Vector3.forward * zAngle);
    }
}
