using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 30;

    // Function to calculate hit factor
    float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketHeight)
    {
        return (ballPos.y - racketPos.y) / racketHeight;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Initial Velocity
        GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
    }

    // Modify the ball's velocity based on the racket's rotation
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "RacketLeft")
        {
            // Get the y factor based on the hit position
            float y = hitFactor(transform.position, col.transform.position, col.collider.bounds.size.y);

            // Get the racket's rotation in degrees and convert it to radians
            float racketRotation = col.transform.eulerAngles.z * Mathf.Deg2Rad;

            // Adjust the ball's direction based on the paddle's rotation
            Vector2 dir = new Vector2(1, y).normalized;

            // Apply rotation to the direction vector (influenced by paddle rotation)
            dir = Quaternion.Euler(0, 0, col.transform.eulerAngles.z) * dir;

            // Set the ball's velocity
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }

        /* Uncomment this section for the right racket
        if (col.gameObject.name == "RacketRight")
        {
            float y = hitFactor(transform.position, col.transform.position, col.collider.bounds.size.y);

            Vector2 dir = new Vector2(-1, y).normalized;

            dir = Quaternion.Euler(0, 0, col.transform.eulerAngles.z) * dir;

            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }
        */
    }
}
